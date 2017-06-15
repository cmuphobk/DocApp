using DocAppBackendWithAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocAppBackendWithAuth.Entity.POCO
{
    public class Symptom
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int id { get; set; }


        /// <summary>
        /// Имя
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Мужчина
        /// </summary>
        public bool isMale { get; set; }

        /// <summary>
        /// Женьщина
        /// </summary>
        public bool isFemale { get; set; }

        /// <summary>
        /// Удален ли
        /// </summary>
        public bool isDelete { get; set; }

        /// <summary>
        /// Координата Х
        /// </summary>
        public int coordX { get; set; }

        /// <summary>
        /// Координата Y
        /// </summary>
        public int coordY { get; set; }

        /// <summary>
        /// Радиус
        /// </summary>
        public int coordRadius { get; set; }

        /// <summary>
        /// Симптомы
        /// </summary>
        public List<Group> groups { get; set; }

        public List<Disease> diseases { get; set; }


        public SymptomModel toModel()
        {
            return new SymptomModel
            {
                id = this.id,
                name = this.name,
                isMale = this.isMale,
                isFemale = this.isFemale,
                coordX = this.coordX,
                coordY = this.coordY,
                coordRadius = this.coordRadius
            };

        }
    }
}
