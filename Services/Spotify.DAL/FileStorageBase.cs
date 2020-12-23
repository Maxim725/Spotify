using System;
using System.Collections.Generic;
using Spotify.Domain.Entities;
using Spotify.Domain.Entities.Intermediate;
using System.IO;
using System.Text;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Spotify.DAL
{
    public class FileStorageBase : IFileStorage<int>
    {
        private string defaultDataFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "_Data");

        public void Init(SpotifyDbContext context)
        {
            if (!Directory.Exists(defaultDataFolderPath))
            {
                Directory.CreateDirectory(defaultDataFolderPath);

                foreach (string dataType in Enum.GetNames(typeof (FileStorageFileType)))
                {
                    string subDir = Path.Combine(Path.Combine(defaultDataFolderPath, dataType));
                    Directory.CreateDirectory(subDir);
                }

                string deafultTrackPath = Path.Combine(Directory.GetCurrentDirectory(), "InitialData/Ionics - Awkward Mystery.mp3");
                string defaultCoverPath = Path.Combine(Directory.GetCurrentDirectory(), "InitialData/default-cover.png");
                string defaultAvatarPath = Path.Combine(Directory.GetCurrentDirectory(), "InitialData/default-avatar.jpg");
                byte[] trackData = File.ReadAllBytes(deafultTrackPath);
                byte[] coverData = File.ReadAllBytes(defaultCoverPath);
                byte[] avatarData = File.ReadAllBytes(defaultAvatarPath);

                Track testTrack = context.Tracks
                    .Where(x => x.Title == "Awkward Mystery")
                    .FirstOrDefault();

                if (testTrack == null)
                {
                    string trackPath = StoreFile(FileStorageFileType.Track, context.Tracks.Count() + 1, trackData, Path.GetExtension(deafultTrackPath));
                    string coverPath = StoreFile(FileStorageFileType.Cover, context.Albums.Count() + 1, coverData, Path.GetExtension(defaultCoverPath));
                    string avatarPath = StoreFile(FileStorageFileType.Avatar, 1, avatarData, Path.GetExtension(defaultAvatarPath));
                    testTrack = AddTestTrackToDb(context, trackPath, coverPath, avatarPath);
                }
            }
        }

        private Track AddTestTrackToDb(SpotifyDbContext context, string trackPath, string coverPath, string avatarPath)
        {
            Author testAuthor = new Author
            {
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                Name = "Ionics",
                Description = "",
                Plays = 0,
                Avatar = avatarPath
            };

            context.Authors.Add(testAuthor);
            context.SaveChanges();

            Album testAlbum = new Album
            {
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                PublishedOn = DateTime.Now,
                Description = "",
                Authors = new List<AlbumAuthor>(),
                CreatedById = 1,
                Title = "Awkward Mystery",
                Plays = 0,
                Cover = coverPath
            };

            context.Albums.Add(testAlbum);
            context.SaveChanges();

            Track testTrack = new Track
            {
                CreatedOn = DateTime.Now,
                CreatedById = 1,
                AlbumId = testAlbum.AlbumId,
                Title = "Awkward Mystery",
                Duration = 2 * 60 + 6,
                Plays = 0,
                Path = trackPath
            };

            context.Tracks.Add(testTrack);
            context.SaveChanges();

            TrackAuthor testTrackAuthor = new TrackAuthor
            {
                TrackId = testTrack.TrackId,
                AuthorId = testAuthor.AuthorId
            };

            context.TrackAuthor.Add(testTrackAuthor);
            context.SaveChanges();

            return testTrack;
        }

        public string StoreFile(FileStorageFileType ftype, int fid, byte[] fileData, string ext)
        {
            string generatedName = GenerateStringById(fid);
            string filePath = Path.Combine(defaultDataFolderPath, ftype.ToString(), generatedName + ext);
            Console.WriteLine(filePath);
            File.WriteAllBytes(filePath, fileData);

            return $"/{ftype}s/{generatedName + ext}";
        }

        private string GenerateStringById(int seed)
        {
            return seed.ToString("X8");
        }
    }
}
