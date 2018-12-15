using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CustomStrategyGameBackend.ComModels;
using CustomStrategyGameBackend.Models;

namespace CustomStrategyGameBackend.Facades
{
    public static class LogoutFacade
    {
        public static void Logout(string token_Id, string uname)
        {
            using (var entity = new GameModel())
            {
                try
                {
                    Gamer gamer = entity.Gamers
                        .Where(g => (g.Uname == uname))
                        .FirstOrDefault();
                    if(gamer != null)
                    {
                        gamer.IsOnline = false;
                        LoginSession loginSession = entity.LoginSessions
                            .Where(lS => (lS.Login_Session_Id == token_Id))
                            .FirstOrDefault();
                        if (loginSession != null)
                        {
                            entity.LoginSessions.Remove(loginSession);
                            Logger.LogGenerator.GenerateLog(new Logger.Log() { IsException = true, Msg = uname + " logged out of system", Status_code = 501, Timespan = DateTime.Now.TimeOfDay });
                        }
                    }
                }
                catch(Exception ex)
                {
                    Logger.LogGenerator.GenerateLog(new Logger.Log() { IsException = true, Msg = token_Id + " logout failed", Status_code = 501, Timespan = DateTime.Now.TimeOfDay });
                }
            }
        }
    }
}