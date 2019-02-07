using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpotifyAPI.Enums;

namespace SpotifyApiTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Setup()
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
    }
}
