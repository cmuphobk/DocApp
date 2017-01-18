using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocAppBackendWithAuth.Models
{
    [Serializable]
    public class DepartamentModel{

        /// <summary>
        /// id
        /// </summary>
        public int? id { get; set; }

        /// <summary>
        /// name
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
        /// Маленькое изображение
        /// </summary>
        public byte[] smallImage { get; set; }

        /// <summary>
        /// Большое изображение
        /// </summary>
        public byte[] bigImage { get; set; }

        /// <summary>
        /// Большое изображение
        /// </summary>
        public byte[] bigImageWoman { get; set; }

        /// <summary>
        /// groups
        /// </summary>
        public List<GroupModel> groups { get; set; }

    }

    [Serializable]
    public class GroupModel
    {
        /// <summary>
        /// id
        /// </summary>
        public int? id { get; set; }

        /// <summary>
        /// name
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
        /// Изображение
        /// </summary>
        public byte[] image { get; set; }

        /// <summary>
        /// Большое изображение
        /// </summary>
        public byte[] imageWoman { get; set; }

        /// <summary>
        /// symptoms
        /// </summary>
        public List<SymptomModel> symptoms { get; set; }

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

    }

    [Serializable]
    public class SymptomModel
    {
        /// <summary>
        /// id
        /// </summary>
        public int? id { get; set; }

        /// <summary>
        /// name
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
    }

    
    [Serializable]

    public class DiagnosModel
    {
        /// <summary>
        /// id
        /// </summary>

        public int? id { get; set; }

        /// <summary>
        /// name
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// descripton
        /// </summary>
        public string descripton { get; set; }

        /// <summary>
        /// Изображение
        /// </summary>
        public byte[] image { get; set; }


    }
}