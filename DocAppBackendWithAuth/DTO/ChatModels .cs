using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocAppBackendWithAuth.Models
{
    [Serializable]
    public class DialogModel{

        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        public string IdFirstUser { get; set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        public string IdSecondUser { get; set; }

        /// <summary>
        /// Пользователь Имя
        /// </summary>
        public string UsernameFirstUser { get; set; }

        /// <summary> 
        /// Пользователь Имя
        /// </summary>
        public string UsernameSecondUser { get; set; }

        /// <summary>
        /// Сообщения
        /// </summary>
        public List<MessageModel> Messages { get; set; }

    }

    [Serializable]
    public class MessageModel
    {

        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор отправителя
        /// </summary>
        public string IdSender { get; set; }
        
        /// <summary>
        /// Имя отправителя
        /// </summary>
        public string NameSender { get; set; }

        /// <summary>
        /// Сообщение
        /// </summary>
        public string Text { get; set; }

    }

    [Serializable]
    public class SearchUserModel
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public string IdentityId { get; set; }
    }
}