using CustomStrategyGameBackend.ComModels;
using CustomStrategyGameBackend.Models;
using System;
using System.Linq;

namespace CustomStrategyGameBackend.Facades
{
    public static class RegisterFacade
    {
        public static RegistrationStatus RegisterGamer(string uname, string email, string password)
        {
            using (var entity = new GameModel())
            {
                if ((entity.Gamers.Where(g => ((g.Uname == uname) || (g.Email_Id == email))).FirstOrDefault()) == null)
                {
                    Logger.LogGenerator.GenerateLog(new Logger.Log() { IsException = true, Msg = uname + " registered", Status_code = 200, Timespan = DateTime.Now.TimeOfDay });
                    entity.Gamers.Add(new Gamer() { Email_Id = email, Uname = uname, Password = password, Games_Lost = 0, Games_Total = 0, Games_Won = 0 });
                    entity.SaveChanges();
                    return new RegistrationStatus(200, "Registered");
                }
                else
                {
                    Logger.LogGenerator.GenerateLog(new Logger.Log() { IsException = true, Msg = uname + " already exists", Status_code = 202, Timespan = DateTime.Now.TimeOfDay });
                    return new RegistrationStatus(202, "User already exists");
                }
            }
        }
    }
}