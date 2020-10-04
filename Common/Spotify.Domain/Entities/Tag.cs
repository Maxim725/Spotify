using Spotify.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Spotify.Domain.Entities
{
    public class Tag : NamedEntity
    {
        public IEnumerable<int> TagIds { get; set; }
        
        [ForeignKey(nameof(TagIds))]
        public virtual IEnumerable<Tag> Tags { get; set; }
    }
}
