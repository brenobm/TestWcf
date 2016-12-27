using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public class Token
    {
        private const int MINUTES_TOLERANCE = 15;
        private const string SHARED_SECRET = "a7d035fa-ddbe-4db5-889b-4de913e8b6fc";
        private const string SPLIT_CHAR = "####";

        private string Password { get; set; }
        private DateTime Validate { get; set; }

        public Token()
        {
            this.Password = GetCryptedPassword();
            this.Validate = DateTime.Now.ToUniversalTime();
        }

        public bool ValidateHash(string hash)
        {
            try
            {
                string plainHash = Crypto.Decrypt(hash, SHARED_SECRET);

                string[] splitHash = plainHash.Split(new string[] { SPLIT_CHAR }, StringSplitOptions.None);

                DateTime hashDate = DateTime.Parse(splitHash[1]);

                if (hashDate.AddMinutes(MINUTES_TOLERANCE) < Validate || hashDate.AddMinutes(-MINUTES_TOLERANCE) > Validate)
                    return false;

                if (!splitHash[0].Equals(Password))
                    return false;

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public string GenerateHash()
        {
            string plainToken = string.Format("{0}{2}{1:yyyy-MM-dd HH:mm:ss}", Password, Validate, SPLIT_CHAR);

            return Crypto.Encrypt(plainToken, SHARED_SECRET);
        }

        private string GetCryptedPassword()
        {
            string cryptPassword = ConfigurationManager.AppSettings["CryptTokenPassword"];

            return Crypto.Decrypt(cryptPassword, SHARED_SECRET);
        }
    }
}
