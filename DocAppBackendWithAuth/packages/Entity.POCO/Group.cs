using DocAppBackendWithAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocAppBackendWithAuth.Entity.POCO
{
    public class Group
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
        /// Изображение
        /// </summary>
        public byte[] image { get; set; }

        /// <summary>
        /// Большое изображение
        /// </summary>
        public byte[] imageWoman { get; set; }


        /// <summary>
        /// Системы
        /// </summary>
        public List<Departament> departaments { get; set; }

        /// <summary>
        /// Симптомы
        /// </summary>
        public List<Symptom> symptoms { get; set; }

        public GroupModel toModel()
        {
            var symptomsModel = new List<SymptomModel>();
            this.symptoms.ForEach(t =>
            {
                symptomsModel.Add(t.toModel());
            });
            return new GroupModel
            {
                id = this.id,
                name = this.name,
                image = this.image,
                symptoms = symptomsModel,
                isMale = this.isMale,
                isFemale = this.isFemale,
                imageWoman = this.imageWoman,
                coordX = this.coordX,
                coordY = this.coordY,
                coordRadius = this.coordRadius
            };

        }
    }
}
