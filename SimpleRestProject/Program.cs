using SpotifyAPI;
using SpotifyAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleRestProject
{
    class Program
    {
        public static bool authenticated = false;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            string clientID = "dc562108d7f446be8f2ab1e26a2e2642";
            string redirectID = "http%3A%2F%2Flocalhost%3A62177";
            string state = "123";
            List<Scope> scope = new List<Scope>()
            {
                Scope.UserReadPrivate, Scope.UserReadBirthdate, Scope.UserModifyPlaybackState, Scope.UserModifyPlaybackState, Scope.UserFollowRead, Scope.UserFollowModify, Scope.UserReadRecentlyPlayed, Scope.UserReadPlaybackState
            };
            Spotify api = new Spotify(clientID, redirectID, state, scope, true);
            api.Authenticated += Api_Authenticated;

            Task.Run(() =>
            {
                api.Authenticate(true);
            });
            while (authenticated == false)
            {
                // refatorar
            }
            Console.WriteLine(api.GetAlbunsByGenre("rock", "50", "50"));


            Console.ReadLine();

        }

        private static void Api_Authenticated(object sender, EventArgs e)
        {
            //Do something
            authenticated = true;
        }
    }
}
