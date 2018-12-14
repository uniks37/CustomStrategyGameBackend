using CustomStrategyGameBackend.ComModels;
using CustomStrategyGameBackend.Facades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace CustomStrategyGameBackend.Communicators
{
    public class LoginCommunicator
    {
        public HttpResponseMessage GetLoggedIn(string value)
        {
            try
            {
                HttpResponseMessage response;
                MessageWrapper messageWrapper = JsonConvert.DeserializeObject<MessageWrapper>(value);

                if (new MessageWrapper<TokenUname>().MessageType == messageWrapper.MessageType)
                {
                    TokenUname tokenUname = (TokenUname)messageWrapper.Message;
                    KeyValuePair<int, TokenUname> loggedGamer = LoginFacade.LoginGamer(tokenUname.Token_Id);
                    if (loggedGamer.Key == 200)
                    {
                        response = new HttpResponseMessage(HttpStatusCode.OK)
                        {
                            Content = new StringContent(JsonConvert.SerializeObject(loggedGamer.Value), Encoding.ASCII, "application/json")
                        };
                        return response;
                    }
                    else
                    {
                        response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                        {
                            Content = new StringContent(JsonConvert.SerializeObject(loggedGamer.Value), Encoding.ASCII, "application/json")
                        };
                        return response;
                    }
                }
                else
                {
                    Type messageType = Type.GetType(messageWrapper.MessageType);
                    var message = JsonConvert.DeserializeObject(Convert.ToString(messageWrapper.Message), messageType);
                    LoginGamerInfo loginGamerInfo = (LoginGamerInfo)message;
                    KeyValuePair<int, TokenUname> loggedGamer = LoginFacade.LoginGamer(loginGamerInfo.Uname, loginGamerInfo.Password, loginGamerInfo.RemMe);
                    if (loggedGamer.Key == 200)
                    {
                        response = new HttpResponseMessage(HttpStatusCode.OK)
                        {
                            Content = new StringContent(JsonConvert.SerializeObject(loggedGamer.Value), Encoding.ASCII, "application/json")
                        };
                        return response;
                    }
                    else
                    {
                        response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                        {
                            Content = new StringContent(JsonConvert.SerializeObject(loggedGamer.Value), Encoding.ASCII, "application/json")
                        };
                        return response;
                    }
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}