using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoogleOauth
{
    class Program
    {

        public static string ApplicationName = "Google access API using Oauth client";
        public static string ClientId = "847163047043-5ariph6u9cdhhpfeshhiiclassfjfe0l.apps.googleusercontent.com";
        public static string ClientSecret = "2ONYgE3bFyFgPHtyj1cxrE5t";

        public static string[] Scopes =
        {
            GmailService.Scope.GmailCompose,
            GmailService.Scope.GmailSend
        };

        public static UserCredential GetUserCredential(out string error)
        {
            Google.Apis.Auth.OAuth2.UserCredential credential = null;
            error = string.Empty;
            try
            {
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    new ClientSecrets
                    {
                        ClientId = ClientId,
                        ClientSecret = ClientSecret
                    },
                    Scopes,
                    Environment.UserName,
                    CancellationToken.None,
                    new FileDataStore("Google Oauth2 Client App")).Result;
            }
            catch (Exception ex)
            {
                credential = null;
                error = "Failed to UserCredential Initialization : " + ex.ToString();
            }
            return credential;
        }

        static void Main(string[] args)
        {
            Console.Write("Enter your Username : ");
            string username = Console.ReadLine();
            string credentialError = string.Empty;
            string refreshToken = string.Empty;
            Console.WriteLine("Please login to continue...");
            UserCredential credential = GetUserCredential(out credentialError);
            if (credential != null && string.IsNullOrWhiteSpace(credentialError))
            {
                refreshToken = credential.Token.RefreshToken;
                Console.WriteLine("Login Successfull");
            }
            else
            {
                Console.WriteLine("Login failed");
            }
            
            Console.Read();
        }
    }
}
