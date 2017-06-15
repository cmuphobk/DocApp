using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;
using DocAppBackendWithAuth.Models;


namespace DocAppBackendWithAuth.Entity.POCO
{
    public class BaseUser
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Идентификатор соединения
        /// </summary>
        public string ConnectionId { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string SecondName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; }


        /// <summary>
        /// Пометка об удалении
        /// </summary>
        public bool IsDeleted { get; set; }


        /// <summary>
        /// Полное ФИО
        /// </summary>
        [NotMapped]
        public string FullName
        {
            get { return String.Join(" ", new List<string> { Surname, Name, SecondName }); }
        }

        /// <summary>
        /// Пользователь
        /// </summary>
        public virtual IdentityUser User { get; set; }


        public SearchUserModel toSearchModel()
        {
            return new SearchUserModel
            {
                UserName = this.User.UserName,
                IdentityId = this.User.Id
            };
        }

    }
}
