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
        public byte[] GetFileById(FileStorageFileType ftype, int fid)
        {
            string filePath = Path.Combine(defaultDataFolderPath, ftype.ToString(), GenerateStringById(fid));

            if (File.Exists(filePath))
            {
                return File.ReadAllBytes(filePath);
            } else
            {
                return new byte[0];
            }
        }

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
                byte[] trackData = File.ReadAllBytes(deafultTrackPath);

                Track testTrack = context.Tracks
                    .Where(x => x.Title == "Awkward Mystery")
                    .FirstOrDefault();

                if (testTrack == null)
                {
                    string trackPath = StoreFile(FileStorageFileType.Track, context.Tracks.Count() + 1, trackData);
                    testTrack = AddTestTrackToDb(context, trackPath);
                }
            }
        }

        private Track AddTestTrackToDb(SpotifyDbContext context, string path)
        {
            Author testAuthor = new Author
            {
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                Name = "Ionics",
                Description = "",
                Plays = 0,
                Avatar = ""
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
                Cover = ""
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
                Path = path
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

        public void RemoveFileById(FileStorageFileType ftype, int fid)
        {
            throw new NotImplementedException();
        }

        public string StoreFile(FileStorageFileType ftype, int fid, byte[] fileData)
        {
            string filePath = Path.Combine(defaultDataFolderPath, ftype.ToString(), GenerateStringById(fid));
            File.WriteAllBytes(filePath, fileData);

            return filePath;
        }

        private string GenerateStringById(int seed)
        {
            return seed.ToString("X8");
        }
    }
}
