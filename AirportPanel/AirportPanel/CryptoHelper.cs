using System.Security.Cryptography;
using System.Text;

namespace AirportPanel
{
    public static class CryptoHelper
    {
        public static string GetStringHashSha256(string inputData)
        {
            var passwordBytes = ASCIIEncoding.ASCII.GetBytes(inputData);

            var cryptoProvider = SHA256.Create();
            var hashPassword = cryptoProvider.ComputeHash(passwordBytes);

            var resultStringHash = ByteArrayToString(hashPassword);

            return resultStringHash;
        }

        private static string ByteArrayToString(byte[] arrInput)
        {
            StringBuilder sOutput = new StringBuilder(arrInput.Length);
            for (var i = 0; i < arrInput.Length - 1; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2"));
            }
            return sOutput.ToString();
        }

    }
}
