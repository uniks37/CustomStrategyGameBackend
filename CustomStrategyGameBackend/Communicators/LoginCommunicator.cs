using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using CustomStrategyGameBackend.Models;
using System.Security.Cryptography;

namespace CustomStrategyGameBackend.Communicators
{
    public static class LoginCommunicator
    {
        public static Random random = new Random();
        public static string GetRandomAlphaNumeric(int length)
        {
            var chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            return new string(chars.Select(c => chars[random.Next(chars.Length)]).Take(length).ToArray());
        }

        public static int GetLoggedIn(string uname, string password)
        {
            using (var entity = new GameModel())
            {
                Gamer gamer = entity.Gamers
                              .Where(g => (g.Email_Id == uname) || (g.Uname == uname))
                              .FirstOrDefault();
                if (gamer == null)
                {
                    Logger.LogGenerator.GenerateLog(new Logger.Log() { IsException = true, Msg = uname + " attempted login", Status_code = 404, Timespan = DateTime.Now.TimeOfDay });
                    return 404;
                }
                else if (gamer.IsOnline)
                {
                    Logger.LogGenerator.GenerateLog(new Logger.Log() { IsException = true, Msg = uname + " attempted login while online", Status_code = 501, Timespan = DateTime.Now.TimeOfDay });
                    return 501;
                }
                else
                {
                    string extractedPassword = Encrypt.DecryptString(password, "enigma");
                    if ((Encoding.ASCII.GetString(new SHA256Managed().ComputeHash(Encoding.ASCII.GetBytes(extractedPassword)))) == gamer.Password)
                    {
                        Logger.LogGenerator.GenerateLog(new Logger.Log() { IsException = true, Msg = uname + " has logged in", Status_code = 200, Timespan = DateTime.Now.TimeOfDay });
                        gamer.IsOnline = true;
                        bool flag = false;
                        while (!flag)
                        {
                            string token = GetRandomAlphaNumeric(128);
                            if (entity.LoginSessions.Where(ls => ls.Login_Session_Id == token).FirstOrDefault() != null)
                            {
                                entity.LoginSessions.Add(new LoginSession() { Login_Session_Id = token, Gamer = gamer });
                                flag = true;
                            }
                        }
                        entity.SaveChanges();
                        return 200;
                    }
                    else
                    {
                        Logger.LogGenerator.GenerateLog(new Logger.Log() { IsException = true, Msg = uname + " tried logging in", Status_code = 202, Timespan = DateTime.Now.TimeOfDay });
                        return 202;
                    }
                }
            }
        }
    }
}