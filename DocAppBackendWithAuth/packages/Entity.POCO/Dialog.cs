using DocAppBackendWithAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocAppBackendWithAuth.Entity.POCO
{
    public class Dialog
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        public BaseUser FirstUser { get; set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        public BaseUser SecondUser { get; set; }

        /// <summary>
        /// Сообщения
        /// </summary>
        public List<Message> Messages { get; set; }

        public DialogModel toModel()
        {
            return new DialogModel
            {
                Id = this.Id,
                IdFirstUser = this.FirstUser.User.Id,
                IdSecondUser = this.SecondUser.User.Id,
                UsernameFirstUser = this.FirstUser.User.UserName,
                UsernameSecondUser = this.SecondUser.User.UserName
            };

        }
    }
}
