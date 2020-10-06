using Spotify.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Spotify.Domain.Entities
{
    public class TrackTag : NamedEntity
    {
        public int Id { get; set; }
        
        public IEnumerable<TagFamily> TagFamily { get; set; }
    }
}
