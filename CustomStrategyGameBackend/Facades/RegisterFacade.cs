using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using CustomStrategyGameBackend.Models;

namespace CustomStrategyGameBackend.Facades
{
    public static class RegisterFacade
    {
        public static int RegisterGamer(string uname, string email, string password)
        {
            using (var entity = new GameModel())
            {
                if((entity.Gamers.Where(g => ((g.Uname == uname) || (g.Email_Id == email))).FirstOrDefault()) == null)
                {
                    Logger.LogGenerator.GenerateLog(new Logger.Log() { IsException = true, Msg = uname + " registered", Status_code = 200, Timespan = DateTime.Now.TimeOfDay });
                    string extractedPassword = Encrypt.DecryptString(password, "enigma");
                    entity.Gamers.Add(new Gamer() { Email_Id = email, Uname = uname, Password = Encoding.ASCII.GetString(new SHA256Managed().ComputeHash(Encoding.ASCII.GetBytes(extractedPassword))), Games_Lost = 0, Games_Total = 0, Games_Won = 0 });
                    entity.SaveChanges();
                    return 200;
                }
                else
                {
                    Logger.LogGenerator.GenerateLog(new Logger.Log() { IsException = true, Msg = uname + " already exists", Status_code = 202, Timespan = DateTime.Now.TimeOfDay });
                    return 202;
                }
            }
        }
    }
}