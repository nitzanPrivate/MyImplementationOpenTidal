using NUnit.Framework;
using OpenTidl;
using OpenTidlExercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TidlTests
{
    [TestFixture]
    public class OpenTidlTests
    {
        private TidlBL tidlController;
        [SetUp]
        public void Setup()
        {
            tidlController = new TidlBL();

        }

        [Test]
        public async Task CreateNewPlaylist()
        {
            //Arrange
            string playlistName = "My api playlist";

            //Act
            var newPlaylist = await tidlController.CreateUserPlaylist(playlistName);

            //Assert
            var userPlaylists = await tidlController.GetUserPlaylists();
            Assert.IsTrue(userPlaylists.Items.Any(playlist => playlist.Uuid == newPlaylist.Uuid));
            Assert.IsTrue(userPlaylists.Items.Any(playlist => playlist.Title == playlistName));
        }
    }
}
