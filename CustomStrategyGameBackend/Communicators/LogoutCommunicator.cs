using CustomStrategyGameBackend.ComModels;
using CustomStrategyGameBackend.Facades;
using Newtonsoft.Json;
using System;

namespace CustomStrategyGameBackend.Communicators
{
    public class LogoutCommunicator
    {
        public void GetLoggedOut(string value)
        {
            try
            {
                MessageWrapper messageWrapper = JsonConvert.DeserializeObject<MessageWrapper>(value);

                if (new MessageWrapper<TokenUname>().MessageType == messageWrapper.MessageType)
                {
                    TokenUname tokenUname = (TokenUname)messageWrapper.Message;
                    LogoutFacade.Logout(tokenUname.Token_Id, tokenUname.Uname);
                }
                else
                {
                    Logger.LogGenerator.GenerateLog(new Logger.Log() { IsException = true, Msg = "Some invalid format attempted login while online", Status_code = 501, Timespan = DateTime.Now.TimeOfDay });
                }
            }
            catch(Exception ex)
            {
                Logger.LogGenerator.GenerateLog(new Logger.Log() { IsException = true, Msg = "Weird server error occured.", Status_code = 501, Timespan = DateTime.Now.TimeOfDay });
            }
        }
    }
}