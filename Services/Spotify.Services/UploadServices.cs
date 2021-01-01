using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spotify.Services
{
    public enum TypeImage
    {
        Avatar = 0,
        Track = 1,
        Album = 2
    }
    public sealed class UploadServices
    {
        public void UploadImage(IFormFile img)
        {
            
        }

        public void UploadTrack(IFormFile track)
        {
        }

        public void Upload(IFormFileCollection files)
        {

        }


    }
}
