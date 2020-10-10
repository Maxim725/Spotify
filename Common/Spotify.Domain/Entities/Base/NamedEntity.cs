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
        public string Name {get; set;}
    }
}
