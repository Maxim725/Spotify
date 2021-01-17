using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Spotify.DAL;

namespace Spotify.Controllers
{
    [Route("data")]
    public class DataController : Controller
    {
        private string defaultDataFolderPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "_Data");

        public Tuple<string, byte[]> GetFileById(FileStorageFileType ftype, int fid)
        {
            string filePath = System.IO.Path.Combine(defaultDataFolderPath, ftype.ToString(), GenerateStringById(fid));

            if (System.IO.File.Exists(filePath))
            {
                string mimeType;
                int mimeLength;
                byte[] fullFileData = System.IO.File.ReadAllBytes(filePath);
                byte[] fileData;

                mimeLength = Convert.ToInt32(fullFileData[0]);
                mimeType = Encoding.ASCII.GetString(fullFileData[1..(mimeLength + 1)]);
                fileData = fullFileData[(mimeLength + 1)..];

                return Tuple.Create(mimeType, fileData);
            }
            else
            {
                return null;
            }
        }

        private string GenerateStringById(int seed)
        {
            return seed.ToString("X8");
        }

        private string MimeToExt(string mime)
        {
            switch (mime)
            {
                case "audio/mpeg": return ".mp3";
                case "image/jpeg": return ".jpg";
                case "image/png": return ".png";
                case "image/svg+xml": return ".svg";
            }

            return ".bin";
        }

        private IActionResult DefaultFileGetter(FileStorageFileType type, string fname, int id)
        {
            Tuple<string, byte[]> fileData = GetFileById(type, id);
            if (fileData != null)
                return File(fileData.Item2, fileData.Item1, fname + MimeToExt(fileData.Item1));
            else
                Response.StatusCode = 404;
            return new EmptyResult();
        }

        [HttpGet, Route("track/{id}")]
        public IActionResult Track(int id)
        {
            return DefaultFileGetter(FileStorageFileType.Track, "track", id);
        }

        [HttpGet, Route("avatar/{id}")]
        public IActionResult Avatar(int id)
        {
            return DefaultFileGetter(FileStorageFileType.Avatar, "avatar", id);
        }

        [HttpGet, Route("author-avatar/{id}")]
        public IActionResult AuthorAvatar(int id)
        {
            return DefaultFileGetter(FileStorageFileType.AuthorAvatar, "avatar", id);
        }

        [HttpGet, Route("album-cover/{id}")]
        public IActionResult AlbumCover(int id)
        {
            return DefaultFileGetter(FileStorageFileType.AlbumCover, "cover", id);
        }
    }
}
