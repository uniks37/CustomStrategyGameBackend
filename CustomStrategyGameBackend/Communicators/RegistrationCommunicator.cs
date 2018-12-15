using CustomStrategyGameBackend.ComModels;
using CustomStrategyGameBackend.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;

namespace CustomStrategyGameBackend.Communicators
{
    public class RegistrationCommunicator
    {
        internal HttpResponseMessage GetRegistered(string modelString)
        {
            try
            {
                HttpResponseMessage response;

                RegisterGamerInfo registerGamerInfo = JsonConvert.DeserializeObject<RegisterGamerInfo>(Encrypt.DecryptString(modelString, "enigma"));
                RegistrationStatus registrationStatus = Facades.RegisterFacade.RegisterGamer(registerGamerInfo.Uname, registerGamerInfo.EmailId, registerGamerInfo.Password);
                if (registrationStatus.ErrorCode == 200)
                {
                    response = new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent(JsonConvert.SerializeObject(registrationStatus), Encoding.ASCII, "application/json")
                    };
                }
                else
                {
                    response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent(JsonConvert.SerializeObject(registrationStatus), Encoding.ASCII, "application/json")
                    };
                }
                return response;
            }
            catch (Exception e)
            {
                RegistrationStatus regStatus = new RegistrationStatus(502, "Internal Server Error");
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(regStatus), Encoding.ASCII, "application/json")
                };
                return response;
            }
        }
    }
}