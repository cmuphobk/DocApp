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
        public int IdFirstUser { get; set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        public int IdSecondUser { get; set; }

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
        /// Сообщение
        /// </summary>
        public string Text { get; set; }

    }

}