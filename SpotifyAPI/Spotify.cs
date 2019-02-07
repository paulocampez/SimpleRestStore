using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using SpotifyAPI.Enums;
using Newtonsoft.Json;
using System.Web;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using SpotifyAPI.Enums;
//using SpotifyAPI.Models;

namespace SpotifyAPI
{
    public class Spotify
    {
        private Authentication auth;

        public event EventHandler Authenticated;

        #region Authentication

        public Spotify(string clientID, string redirectUri, string state, List<Scope> scopes, bool showDialog)
        {
            auth = new Authentication(clientID, redirectUri, state, scopes, showDialog);
        }

        public void Authenticate(bool launchBrowser)
        {
            Constant.AuthCode = auth.Authenticate(launchBrowser);
            OnAuthentication(EventArgs.Empty);
        }

        protected void OnAuthentication(EventArgs e)
        {
            Authenticated?.Invoke(this, e);
        }


        public string GetAuthenticationUrl()
        {
            return auth.BuildUrl();
        }

        #endregion
        
        public dynamic GetAlbum(string id)
        {
            //Token token = Methods.GetToken().Result;
            string endpointUrl = "albums/" + id;

            return Methods.SendGetRequest(endpointUrl);
        }

        public dynamic AuthenticateWithToken()
        {


            return "";
        }
        public dynamic GetAlbunsBySeveralIds(string id)
        {
            id = id.Replace(",", "%2C");
            string endpointUrl = "albums?ids="+id;
            return Methods.SendGetRequest(endpointUrl);
        }
        public dynamic GetAlbunsByGenre(string genre, string offset = "0", string limit = "0")
        {
            string endpointUrl = "search?q=" + genre+"&type=album&limit="+limit;
            return Methods.SendGetRequest(endpointUrl);
        }
        public dynamic GetArtistByGenre(string genre, string offset = "0", string limit = "0")
        {
            string endpointUrl = "search?q=genre%3A"+genre+"&type=artist&limit="+limit;
            return Methods.SendGetRequest(endpointUrl);
        }
        public dynamic GetAlbumByArtist(string artist, string offset = "0", string limit = "1")
        {
            string endpointUrl = "artists/" + artist + "/albums?limit="+limit;
            return Methods.SendGetRequest(endpointUrl);
        }
    }
}
