using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Spotify.Domain.Entities.Base
{
    /// <summary> Абстрактный класс, который добавляет потомку Идентификатор </summary>
    public abstract class IdEntity
    {
        /// <summary> Идентификатор экземпляра класса </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
