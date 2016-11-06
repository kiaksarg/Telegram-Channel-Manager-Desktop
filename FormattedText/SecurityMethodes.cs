using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace Helpers.Security
{
    public static class SecurityMethodes
    {
        public static string RNDString(int count = 20)
        {
            var rnd = new Random();
            string ut = "";
            for (int i = 0; i < count - 2; i++)
            {
                if (i % 2 == 0)
                    ut += (char)rnd.Next(97, 122);
                else
                    ut += rnd.Next(1000, 9999999).ToString()[rnd.Next(0, 3)];
            }

            return ut + DateTime.Now.Millisecond;
        }
        public static byte[] GenerateSalt()
        {
            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[32];
                randomNumberGenerator.GetBytes(randomNumber);
                return randomNumber;
            }
        }
        public static byte[] GenerateIdentifier()
        {
            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[64];
                randomNumberGenerator.GetBytes(randomNumber);
                return randomNumber;
            }
        }

        public static string GenerateRandomCode(int codeCount, bool isAlphabet = false)
        {
            string allChar = (isAlphabet) ? "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z" : "1,2,3,4,5,6,7,8,9";
            string[] allCharArray = allChar.Split(',');
            string randomCode = "";
            int temp = -1;

            Random rand = new Random();
            for (int i = 0; i < codeCount; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(i * temp * ((int)DateTime.Now.Ticks));
                }
                int t = rand.Next(allChar.Split(',').Count());
                if (temp != -1 && temp == t)
                {
                    return GenerateRandomCode(codeCount);
                }
                temp = t;
                randomCode += allCharArray[t];
            }
            return randomCode;
        }

        public static byte[] HashPassword(byte[] toBeHashed, byte[] salt, int numberOfRounds)
        {
            using (var rfc2898 = new Rfc2898DeriveBytes(toBeHashed, salt, numberOfRounds))
            {
                return rfc2898.GetBytes(32);

            }
        }
    }
}