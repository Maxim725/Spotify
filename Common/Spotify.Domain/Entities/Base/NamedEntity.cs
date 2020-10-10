using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Spotify.Domain.Entities.Base
{
    /// <summary>
    /// Абстрактный класс для сущностей у котопых есть имя.
    /// </summary>
    public abstract class NamedEntity : IdEntity
    {
        /// <value>
        /// Имя сущности.
        /// </value>
        [Required(ErrorMessage = "Имя сущности не установлено.")]
        public string Name {get; set;}
    }
}
