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
        public byte[] GetFileById(int fid)
        {
            string filePath = Path.Combine(defaultDataFolderPath, GenerateStringBySeed(fid));

            return File.ReadAllBytes(filePath);
        }

        public void Init(SpotifyDbContext context)
        {
            if (!Directory.Exists(defaultDataFolderPath))
            {
                Directory.CreateDirectory(defaultDataFolderPath);

                string deafultTrackPath = Path.Combine(Directory.GetCurrentDirectory(), "InitialData/Ionics - Awkward Mystery.mp3");
                byte[] trackData = File.ReadAllBytes(deafultTrackPath);

                Track testTrack = context.Tracks
                    .Where(x => x.Title == "Awkward Mystery")
                    .FirstOrDefault();

                if (testTrack == null)
                {
                    testTrack = AddTestTrackToDb(context);
                }

                string trackFileId = StoreFile(testTrack.TrackId, trackData);
                Console.WriteLine(trackFileId);
            }
        }

        private Track AddTestTrackToDb(SpotifyDbContext context)
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
                Plays = 0
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

        public void RemoveFileById(int fid)
        {
            throw new NotImplementedException();
        }

        public string StoreFile(int fid, byte[] fileData)
        {
            string filePath = Path.Combine(defaultDataFolderPath, GenerateStringBySeed(fid));
            File.WriteAllBytes(filePath, fileData);

            return filePath;
        }

        private string GenerateStringBySeed(int seed, int length = 32, string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789")
        {
            Random generator = new Random(seed);
            string result = "";

            for (int i = 0; i < length; i++)
            {
                result += alphabet[generator.Next(0, alphabet.Length)];
            }

            return result;
        }

        public bool UploadContent(int id, string initialFolder, IFormFile file)
        {
            DirectoryInfo di = new DirectoryInfo(initialFolder + Path(id));
            if (!di.Exists)
            {
                di.Create();
            }
            return false;

            string Path(int id)
            {

                StringBuilder sb = new StringBuilder();

                int it = id.ToString().Length;

                while (it < 8)
                {
                    sb.Append("0");
                    it++;
                }
                sb.Append(id);

                sb.Insert(0, '/');
                sb.Insert(3, '/');
                sb.Insert(6, '/');
                sb.Insert(9, '/');

                return sb.ToString();
            }
        }
    }
}
