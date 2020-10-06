using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Spotify.Domain.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Confirmed { get; set; }
        public string Biography { get; set; }
        public DateTime CreationDate { get; set; }

        public IEnumerable<AuthorAlbum> Albums { get; set; }

        public Image Image { get; set; }
    }
}
