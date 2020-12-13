using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Spotify.DAL
{
    public interface IFileStorage<T>
    {
        void Init(SpotifyDbContext context);

        string StoreFile(T fid, byte[] fileData);

        byte[] GetFileById(T fid);

        void RemoveFileById(T fuid);
    }
}
