using SpotifyAPI;
using SpotifyAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace Store
{
    public class Spotify
    {
        /// <summary>
        /// The thread used to run the authentication process.
        /// </summary>
        private Thread authenticationThread;

        /// <summary>
        /// The Spotify API.
        /// </summary>
        public static SpotifyAPI.Spotify Api { get; private set; }

        /// <summary>
        /// List of all search types.
        /// </summary>

        /// <summary>
        /// Initialises the Spotify API.
        /// </summary>
        public Spotify()
        {
            string clientID = "dc562108d7f446be8f2ab1e26a2e2642";
            string redirectID = "http%3A%2F%2Flocalhost%3A62177";
            string state = "123";

            List<Scope> scope = new List<Scope>()
            {
                Scope.UserReadPrivate,
                Scope.UserReadBirthdate,
                Scope.UserModifyPlaybackState,
                Scope.UserModifyPlaybackState,
                Scope.UserFollowRead, Scope.UserFollowModify,
                Scope.UserReadRecentlyPlayed,
                Scope.UserReadPlaybackState
            };

            Api = new SpotifyAPI.Spotify(clientID, redirectID, state, scope, true);
        }

        /// <summary>
        /// Creates a new thread and authenticates the API.
        /// </summary>
        public void Authenticate()
        {
            authenticationThread = new Thread(new ThreadStart(DoAuthentication));
            authenticationThread.Start();
        }

        /// <summary>
        /// Stops the authentication thread.
        /// </summary>
        public void KillAuthenticationThread()
        {
            if (authenticationThread.IsAlive)
            {
                authenticationThread.Abort();
            }
        }

        /// <summary>
        /// Runs the authentication workflow.
        /// </summary>
        private void DoAuthentication()
        {
            Api.Authenticate(true);
        }
    }
}