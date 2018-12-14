using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace CustomStrategyGameBackend.Encryptors
{
    public static class NewToken
    {
        private static int Next(int lim)
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            var byteArray = new byte[4];
            provider.GetBytes(byteArray);
            return (int)BitConverter.ToUInt32(byteArray, 0);
        }
        private static string GetRandomAlphaNumeric(int length)
        {
            var chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            return new string(chars.Select(c => chars[(Math.Abs(Next(chars.Length))%chars.Length)]).Take(length).ToArray());
        }

        public static string GetNewToken(int bitLength)
        {
            return NewToken.GetRandomAlphaNumeric(bitLength);
        }
    }
}