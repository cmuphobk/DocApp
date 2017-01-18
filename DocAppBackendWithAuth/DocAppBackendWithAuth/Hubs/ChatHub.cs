using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using DocAppBackendWithAuth.Common.IoCContainer;
using DocAppBackendWithAuth.Entity.Repository;
using DocAppBackendWithAuth.Entity.POCO;
using DocAppBackendWithAuth.Entity.Specifications.POCO.User;
using DocAppBackendWithAuth.Entity.Specifications.POCO.Dialog;
using System.Linq.Expressions;
using Microsoft.AspNet.Identity;

namespace DocAppBackendWithAuth.Hubs
{
    public class ChatHub : Hub
    {
        public void Send(int reciepentId, string message)
        {
            var senderConnectionId = Context.ConnectionId;
            
            using (var context = IoCContainer.Get<IEntity>())
            {
                var repositoryUser = context.GetRepository<IRepository<BaseUser>>();
                var repositoryDialog = context.GetRepository<IRepository<Dialog>>();

                var userReciepent = repositoryUser.Find(new Entity.Specifications.POCO.User.ById(reciepentId)).First();
                var reciepentConnectionId = userReciepent.ConnectionId;
                var userSender = repositoryUser.Find(new ByConnectionId(senderConnectionId)).First();

                var dialogList = repositoryDialog.Find(new ByUsers(userSender.Id, userReciepent.Id), new List<Expression<Func<Dialog, object>>>
                {
                    t => t.FirstUser,
                    t => t.SecondUser,
                    t => t.Messages
                });

                if (dialogList.Any())
                {
                    var dialog = dialogList.First();
                    dialog.Messages.Add(new Message {
                        Text = message
                    });
                }else
                {
                    var messages = new List<Message>();
                    messages.Add(new Message {
                        Text = message
                    });
                    repositoryDialog.Add(new Dialog
                    {
                        FirstUser = userSender,
                        SecondUser = userReciepent,
                        Messages = messages
                    });
                }
                context.SaveChanges();
                Clients.All.addMessage(reciepentConnectionId, message);
            }
        }
        /// <summary>
        /// Подключение нового пользователя
        /// </summary>
        /// <param name="userName"></param>
        public void Connect()
        {
            var userId = Context.User.Identity.GetUserId();
            using (var context = IoCContainer.Get<IEntity>())
            {
                var connecionId = Context.ConnectionId;
                var repository = context.GetRepository<IRepository<BaseUser>>();
                var userList = repository.Find(new Entity.Specifications.POCO.User.ByUserId(userId)).ToList();

                if (userList.Any())
                {
                    var user = userList.First();
                    
                    user.ConnectionId = connecionId;
                    context.SaveChanges();
                    // Посылаем сообщение текущему пользователю
                    Clients.Caller.onConnected(connecionId);
                    

                }
                
            }          
        }

        /// <summary>
        /// Отключение пользователя
        /// </summary>
        /// <param name="stopCalled"></param>
        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            using (var context = IoCContainer.Get<IEntity>())
            {
                var connecionId = Context.ConnectionId;
                var repository = context.GetRepository<IRepository<BaseUser>>();
                var userList = repository.Find(new ByConnectionId(connecionId)).ToList();

                if (userList.Any())
                {
                    var user = userList.First();
                    user.ConnectionId = null;
                    context.SaveChanges();
                    Clients.All.onUserDisconnected(connecionId);

                }

                return base.OnDisconnected(stopCalled);

            }
        }
    }
}