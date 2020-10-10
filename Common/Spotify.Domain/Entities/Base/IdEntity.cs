using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Spotify.Domain.Entities.Base
{
    /// <summary>
    /// Абстрактный класс для сущностей, которые имеют уникальный идентификатор.
    /// </summary>
    public abstract class IdEntity
    {
        /// <value>
        /// Идентификатор экземпляра класса.
        /// </value>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
