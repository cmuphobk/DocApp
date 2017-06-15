using DocAppBackendWithAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocAppBackendWithAuth.Entity.POCO
{
    public class Message
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        public string Text { get; set; }

        public BaseUser Sender { get; set; }

        public List<Image> Images { get; set; }

        public List<Href> Hrefs { get; set; }

        public List<Document> Documents {get; set; }

        public DateTime? DateTimeSend { get; set; }

        public int? Year { get; set; }

        public MessageModel toModel()
        {
            return new MessageModel
            {
                Id = this.Id,
                Text = this.Text,
                IdSender = this.Sender.User.Id,
                NameSender = this.Sender.Name
            };

        }
    }
}
