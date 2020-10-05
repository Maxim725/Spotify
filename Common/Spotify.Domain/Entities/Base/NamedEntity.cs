using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Spotify.Domain.Entities.Base
{
    public class NamedEntity : IdEntity
    {
        [Required]
        public string Name {get; set;}
    }
}
