using Giftable.Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Credentials;

namespace Giftable.Library.Helpers
{
    public class CredetentialsManager
    {
        private const string APP_NAME_KEY = "giftableApp";
        private PasswordVault vault = new PasswordVault();

        public LoginResponseModel TakeCredetentialsFromVault()
        {
            LoginResponseModel userInfo = new LoginResponseModel();

            try
            {
                var creds = vault.FindAllByResource(APP_NAME_KEY).FirstOrDefault();
                if (creds != null)
                {
                    userInfo.Username = creds.UserName;
                    userInfo.AccessToken = vault.Retrieve(APP_NAME_KEY, creds.UserName).Password;
                }
            }
            catch (Exception)
            {
                userInfo = null;
                return userInfo;
            }
            return userInfo;
        }

        public void SetCredetentials(string username, string authCode)
        {
            vault.Add(new PasswordCredential(APP_NAME_KEY, username, authCode));
        }

        public void RemoveCredetentials(string username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                vault.Remove(vault.Retrieve(APP_NAME_KEY, username));
            }
        }
    }
}
