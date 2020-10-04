using Spotify.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spotify.Domain.Entities
{
    public class Image : IdEntity
    {
        public string Path { get; set; }
    }
}
