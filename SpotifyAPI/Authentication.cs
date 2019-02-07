using SpotifyAPI.Enums;
//using SpotifyAPI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpotifyAPI
{
    class Authentication
    {
        private string _clientID;
        private string _responseType = "token";
        private string _redirectUri;
        private string _state;
        private string _scope;
        private bool _showDialgog;
        private string _url;
        private string ClientId;
        private string ClientSecret;


        public Authentication(string clientID, string redirectUri, string state, ICollection<Scope> scopes, bool showDialog)
        {
            _clientID = "dc562108d7f446be8f2ab1e26a2e2642";
            _redirectUri = redirectUri;
            _state = state;
            _scope = AggregateScope(scopes); //extensoes/permissoes : https://developer.spotify.com/documentation/general/guides/scopes/
            _showDialgog = showDialog;

            _url = BuildUrl();
        }

        public static string AggregateScope(ICollection<Scope> scopes)
        {
            string scopeContents = null;

            foreach (Scope item in scopes)
            {
                scopeContents += item.GetDescription() + "%20";
            }
            scopeContents = scopeContents.Remove(scopeContents.Length - 3);

            return scopeContents;
        }

    

        public string BuildUrl()
        {
            StringBuilder builder = new StringBuilder("https://accounts.spotify.com/authorize?");
            builder.Append("client_id=" + _clientID);
            builder.Append("&redirect_uri=" + _redirectUri);
            builder.Append("&scope=" + _scope);
            builder.Append("&response_type=" + _responseType);
            builder.Append("&state=" + _state);
            builder.Append("&show_dialog=" + _showDialgog);

            return builder.ToString();
        }

        public string Authenticate(bool launchBrowser)
        {
            ManualResetEvent mre = new ManualResetEvent(false);

            string authCode = null;

            Task.Run(() =>
            {
                //cria porta (adicionar no app)
                SimpleServer myServer = new SimpleServer(62177, AuthType.Implicit);
                myServer.Listen();

                myServer.OnAuth += e =>
                {
                    authCode = e.Code;
                    Console.WriteLine(e.Code);
                    mre.Set(); 
                };
            });

            if (launchBrowser == true)
                Process.Start(_url);

            mre.WaitOne();
            return authCode;
        }

    }
}
