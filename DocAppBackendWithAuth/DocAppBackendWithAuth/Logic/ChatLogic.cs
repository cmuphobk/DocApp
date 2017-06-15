using DocAppBackendWithAuth.Common.IoCContainer;
using DocAppBackendWithAuth.Entity.POCO;
using DocAppBackendWithAuth.Entity.Repository;
using DocAppBackendWithAuth.Entity.Specifications.POCO.Diagnos;
using DocAppBackendWithAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace DocAppBackendWithAuth.Logic
{
    public class ChatLogic
    {


        public List<Dialog> getDialogs(string userId)
        {
            var dialogs = new List<Dialog>();
            using (var context = IoCContainer.Get<IEntity>())
            {
                var repositoryUser = context.GetRepository<IRepository<BaseUser>>();
                var repository = context.GetRepository<IRepository<Dialog>>();
                var id = repositoryUser.Find(new Entity.Specifications.POCO.User.ByUserId(userId)).First().Id;
                dialogs.AddRange(repository.Find(new Entity.Specifications.POCO.Dialog.ByUser(id), new List<Expression<Func<Dialog, object>>>
                {
                    t => t.FirstUser,
                    t => t.SecondUser,
                    t => t.FirstUser.User,
                    t => t.SecondUser.User
                }).ToList());

                return dialogs;
            }
        }

        public DialogModel createDialog(string senderId, string reciepentId)
        {

            using (var context = IoCContainer.Get<IEntity>())
            {
                var repositoryUser = context.GetRepository<IRepository<BaseUser>>();

                var sender = repositoryUser.Find(new Entity.Specifications.POCO.User.ByUserId(senderId)).First();
                var reciepent = repositoryUser.Find(new Entity.Specifications.POCO.User.ByUserId(reciepentId)).First();

                var repository = context.GetRepository<IRepository<Dialog>>();

                var dialogList = repository.Find(new Entity.Specifications.POCO.Dialog.ByUsers(sender.Id, reciepent.Id), new List<Expression<Func<Dialog, object>>>
                {
                    t => t.FirstUser,
                    t => t.SecondUser,
                    t => t.Messages
                });

                if(dialogList.Any()){
                    return dialogList.First().toModel();
                }

                var dialog = new Dialog
                {
                    FirstUser = sender,
                    SecondUser = reciepent,
                    Messages = new List<Message>()
                };

                repository.Add(dialog);
                context.SaveChanges();
                return dialog.toModel();
            }
            
        }

        public List<Message> getMessages(int dialogId)
        {
            var messages = new List<Message>();
            using (var context = IoCContainer.Get<IEntity>())
            {
                var repository = context.GetRepository<IRepository<Dialog>>();

                var dialogList = repository.Find(new Entity.Specifications.POCO.Dialog.ById(dialogId), new List<Expression<Func<Dialog, object>>>
                {
                    t => t.Messages,
                    t => t.Messages.Select(q=>q.Sender),
                    t => t.Messages.Select(q=>q.Sender.User)
                });

                if (dialogList.Any())
                {
                    var dialog = dialogList.First();
                    messages.AddRange(dialog.Messages);
                }

                return messages;
            }
        }

        


    }
}