using DocAppBackendWithAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocAppBackendWithAuth.Entity.POCO
{
    public class Departament
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
        /// Женщина
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
        /// Удален ли
        /// </summary>
        public bool isDelete { get; set; }

        /// <summary>
        /// Группы
        /// </summary>
        public List<Group> groups { get; set; }

        public DepartamentModel toModel()
        {
            var groupsModel = new List<GroupModel>();
            this.groups.ForEach(t =>
            {
                groupsModel.Add(t.toModel());
            });
            return new DepartamentModel
            {
                id = this.id,
                name = this.name,
                smallImage = this.smallImage,
                bigImage = this.bigImage,                
                groups = groupsModel,
                isMale = this.isMale,
                isFemale = this.isFemale,
                bigImageWoman = this.bigImageWoman
                
            };

        }
    }
}
