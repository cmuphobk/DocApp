using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DocAppBackendWithAuth.Models;
using DocAppBackendWithAuth.Logic;
using Microsoft.AspNet.Identity;

namespace DocAppBackendWithAuth.Controllers
{
    [Authorize]
    [RoutePrefix("api/ChatApi")]
    public class ChatApiController : ApiController
    {
        [HttpGet]
        [Route("Dialogs")]
        public IEnumerable<DialogModel> GetDialogs()
        {
            var list = new List<DialogModel>();

            var userId = User.Identity.GetUserId();
            new ChatLogic().getDialogs(userId).ForEach(t => list.Add(t.toModel()));
            return list;
        }

        [HttpGet]
        [Route("Messages")]
        public IEnumerable<MessageModel> GetMessagess(int dialogId)
        {
            var list = new List<MessageModel>();
            new ChatLogic().getMessages(dialogId).ForEach(t => list.Add(t.toModel()));
            return list;
        }
    }
}
