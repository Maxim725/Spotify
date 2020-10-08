using Spotify.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spotify.Domain.Entities
{
    /// Класс описывающий картинку, хранящуюся в БД
    public class Image : IdEntity
    {
        /// <summary> Путь на сервере до картинки </summary>
        public string Path { get; set; }
    }
}
