using Spotify.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Spotify.Domain.Entities
{
    public class TrackTag : NamedEntity
    {
        public IEnumerable<int> GroupTagIds { get; set; }
        
        [ForeignKey(nameof(GroupTagIds))]
        public virtual IEnumerable<TrackTag> Tags { get; set; }
    }
}
