using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Spotify.Domain.Entities.Base
{
    /// <summary> Абстрактный класс, который добавляет потомку Имя и Идентификатор </summary>
    public abstract class NamedEntity : IdEntity
    {
        /// <summary> Название экземпляра класса </summary>
        [Required]
        public string Name {get; set;}
    }
}
