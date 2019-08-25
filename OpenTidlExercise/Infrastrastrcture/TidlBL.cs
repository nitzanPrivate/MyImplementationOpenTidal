using NLog;
using OpenTidl;
using OpenTidl.Methods;
using OpenTidl.Models;
using OpenTidl.Models.Base;
using OpenTidlExercise.Common;
using System;
using System.Threading.Tasks;

namespace OpenTidlExercise
{
    public class TidlBL
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private OpenTidlSession session;

        public TidlBL(string username = "sdasdads@mailinator.com", string password = "!QAZ2wsx")
        {
            StaticLogger.LogInfo(this.GetType(), "Gettins session from constructor");
            session = this.Login(username, password);
        }

        private OpenTidlSession Login(string username = "sdasdads@mailinator.com", string password = "!QAZ2wsx")
        {
            StaticLogger.LogInfo(this.GetType(), "Login");
            OpenTidlClient client = new OpenTidlClient(ClientConfiguration.Default);
            return client.LoginWithUsername(username, password, timeout: 100000);
        }


        public async Task<PlaylistModel> CreateUserPlaylist(String title)
        {
            StaticLogger.LogInfo(this.GetType(), "Create user playlist " + title);
            var newPlaylist = await session.CreateUserPlaylist("My api playlist");
            return newPlaylist;
        }


        //public void Task<PlaylistModel> AddPlaylistTracks(String playlistUuid, String playlistETag, IEnumerable<Int32> trackIds, Int32 toIndex = 0)
        //{
        //    logger.Debug("Add playlist tracks");

        //}

  
        //public void DeletePlaylistTracks(String playlistUuid, String playlistETag, IEnumerable<Int32> indices)
        //{
        //    logger.Debug("Delete Playlist tracks");
        //}

        public async Task<JsonList<PlaylistModel>> GetUserPlaylists(Int32 limit = 9999)
        {
            StaticLogger.LogInfo(this.GetType(), "Get user playlists");
            return await session.GetUserPlaylists(limit);
        }

      
    }
}
