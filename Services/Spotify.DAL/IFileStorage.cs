using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Spotify.DAL
{
    public enum FileStorageFileType {
        Track,
        Avatar,
        AlbumCover
    }


    public interface IFileStorage<T>
    {
        void Init(SpotifyDbContext context);

        string StoreFile(FileStorageFileType ftype, T fid, byte[] fileData, string fmime);

        byte[] GetFileById(FileStorageFileType ftype, T fid);

        void RemoveFileById(FileStorageFileType ftype, T fuid);
    }
}
