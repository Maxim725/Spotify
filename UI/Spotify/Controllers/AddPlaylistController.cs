using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spotify.DAL;
using Microsoft.AspNetCore.Identity;
using Spotify.Domain.Entities.Identity;
using Spotify.Domain.Entities.Intermediate;
namespace Spotify.Controllers
{
    [Route("playlist")]
    public class AddPlaylistController : Controller
    {
        public class PlaylistPostModel
        {
            public int UserId { get; set; }
            public IEnumerable<int> TracksId { get; set; }
            public string Title { get; set; }
        }

        private SpotifyDbContext _context;
        public AddPlaylistController(SpotifyDbContext context)
        {
            _context = context;
        }

        [HttpPost("add")]
        public IActionResult Add(PlaylistPostModel model)
        {
            if (model is null)
                return Redirect("");

            //Playlist
            var playlist = _context.Playlists.Add(new Domain.Entities.Playlist
            { /*CreatedBy = _userManager.FindByIdAsync(model.UserId.ToString()).Result,*/
                Title = model.Title,
                CreatedById = model.UserId,
                CreatedOn = DateTime.Now,
                PublishedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                Plays = 0,
                Description = ""
            });
            _context.SaveChanges();

            // UserPlaylist
            _context.UserPlaylist.Add(new UserPlaylist { UserId = model.UserId, PlaylistId = playlist.Entity.PlaylistId });
            _context.SaveChanges();
            
            // TrackPlaylist
            foreach (var trackId in model.TracksId)
                _context.PlaylistTrack.Add(new PlaylistTrack { PlaylistId = playlist.Entity.PlaylistId, TrackId = trackId });
            _context.SaveChanges();

            return Redirect("/debug");
        }
    }
}
