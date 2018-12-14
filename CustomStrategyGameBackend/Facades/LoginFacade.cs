using CustomStrategyGameBackend.ComModels;
using CustomStrategyGameBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CustomStrategyGameBackend.Facades
{
    public static class LoginFacade
    {
        public static KeyValuePair<int, TokenUname> LoginGamer(string uname, string password, bool remMe)
        {
            using (var entity = new GameModel())
            {
                Gamer gamer = entity.Gamers
                              .Where(g => (g.Email_Id == uname) || (g.Uname == uname))
                              .FirstOrDefault();
                if (gamer == null)
                {
                    Logger.LogGenerator.GenerateLog(new Logger.Log() { IsException = true, Msg = uname + " attempted login", Status_code = 404, Timespan = DateTime.Now.TimeOfDay });
                    return new KeyValuePair<int, TokenUname>(404, new TokenUname(uname, "No such gamer found"));
                }
                else if (gamer.IsOnline)
                {
                    Logger.LogGenerator.GenerateLog(new Logger.Log() { IsException = true, Msg = uname + " attempted login while online", Status_code = 501, Timespan = DateTime.Now.TimeOfDay });
                    return new KeyValuePair<int, TokenUname>(501, new TokenUname(gamer.Uname, "Already Online"));
                }
                else
                {
                    if (password == gamer.Password)
                    {
                        Logger.LogGenerator.GenerateLog(new Logger.Log() { IsException = true, Msg = uname + " has logged in", Status_code = 200, Timespan = DateTime.Now.TimeOfDay });
                        gamer.IsOnline = true;
                        bool flag = false;
                        string token = null;
                        while (!flag)
                        {
                            token = Encryptors.NewToken.GetNewToken(128);
                            if (entity.LoginSessions.Where(ls => ls.Login_Session_Id == token).FirstOrDefault() == null)
                            {
                                entity.LoginSessions.Add(new LoginSession() { Login_Session_Id = token, Gamer_Id = gamer.Id});
                                flag = true;
                            }
                        }
                        try
                        {
                            entity.SaveChanges();
                        }
                        catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                        {
                            Exception raise = dbEx;
                            foreach (var validationErrors in dbEx.EntityValidationErrors)
                            {
                                foreach (var validationError in validationErrors.ValidationErrors)
                                {
                                    string message = string.Format("{0}:{1}",
                                        validationErrors.Entry.Entity.ToString(),
                                        validationError.ErrorMessage);
                                    // raise a new exception nesting
                                    // the current instance as InnerException
                                    raise = new InvalidOperationException(message, raise);
                                }
                            }
                            throw raise;
                        }
                        return new KeyValuePair<int, TokenUname>(200, new TokenUname(gamer.Uname, token));
                    }
                    else
                    {
                        Logger.LogGenerator.GenerateLog(new Logger.Log() { IsException = true, Msg = uname + " tried logging in", Status_code = 202, Timespan = DateTime.Now.TimeOfDay });
                        return new KeyValuePair<int, TokenUname>(202, new TokenUname(uname, "Password Mismatch"));
                    }
                }
            }
        }
        public static KeyValuePair<int, TokenUname> LoginGamer(string token_Id)
        {
            using (var entity = new GameModel())
            {
                LoginSession loginSession;
                if ((loginSession = entity.LoginSessions.Where(ls => (ls.Login_Session_Id == token_Id)).FirstOrDefault()) != null)
                {
                    Gamer gamer = loginSession.Gamer;
                    if (!gamer.IsOnline)
                    {
                        gamer.IsOnline = true;
                        entity.SaveChanges();
                        Logger.LogGenerator.GenerateLog(new Logger.Log() { IsException = true, Msg = token_Id + " logged in", Status_code = 200, Timespan = DateTime.Now.TimeOfDay });
                        return new KeyValuePair<int, TokenUname>(200, new TokenUname(gamer.Uname, token_Id));
                    }
                    else
                    {
                        Logger.LogGenerator.GenerateLog(new Logger.Log() { IsException = true, Msg = token_Id + " attempted login while online", Status_code = 501, Timespan = DateTime.Now.TimeOfDay });
                        return new KeyValuePair<int, TokenUname>(501, new TokenUname(gamer.Uname, token_Id));
                    }
                }
                else
                {
                    Logger.LogGenerator.GenerateLog(new Logger.Log() { IsException = true, Msg = token_Id + " attempted login", Status_code = 404, Timespan = DateTime.Now.TimeOfDay });
                    return new KeyValuePair<int, TokenUname>(404, new TokenUname(null, token_Id));
                }
            }
        }
    }
}