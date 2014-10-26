using JustRunnerChat.Data;
using JustRunnerChat.Model;
using JustRunnerChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JustRunnerChat.Repositories
{
    public class ChannelsRepository
    {
        private const string ValidNameChars = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM_1234567890";

        private const int MinNameChars = 4;
        private const int MaxNameChars = 30;

        private static void ValidateChannelName(string channelName)
        {
            if (channelName == null || channelName.Length < MinNameChars || channelName.Length > MaxNameChars)
            {
                throw new ServerErrorException("Username should be between 4 and 30 symbols long", "INV_CHNAME_LEN");
            }
            else if (channelName.Any(ch => !ValidNameChars.Contains(ch)))
            {
                throw new ServerErrorException("Channel contains invalid characters", "INV_CHNAME_CHARS");
            }
        }

        private static void ValidateNickname(string nickname)
        {
            if (nickname == null || nickname.Length < MinNameChars || nickname.Length > MaxNameChars)
            {
                throw new ServerErrorException("Username should be between 4 and 30 symbols long", "INV_CHNAME_LEN");
            }
            else if (nickname.Any(ch => !ValidNameChars.Contains(ch)))
            {
                throw new ServerErrorException("Username contains invalid characters", "INV_CHNAME_CHARS");
            }
        }

        public static void CreateChannel(string channelName, string userNickname, string password)
        {
            ValidateChannelName(channelName);
            ValidateNickname(userNickname);
            using (ChatContext context = new ChatContext())
            {
                var nameToLower = channelName.ToLower();

                var dbChannel = context.Channels.FirstOrDefault(c => c.Name.ToLower() == nameToLower);

                if (dbChannel != null)
                {
                    if (dbChannel.Name.ToLower() == nameToLower)
                    {
                        throw new ServerErrorException("Channel name already exists", "ERR_DUP_CHNAME");
                    }
                }

                dbChannel = new Channel()
                {
                    Name = nameToLower,
                    Password = password
                };

                var dbUser = context.Users.FirstOrDefault(u => u.Nickname.ToLower() == userNickname.ToLower());
                dbChannel.Users.Add(dbUser);

                context.Channels.Add(dbChannel);
                context.SaveChanges();
            }
        }

        public static void JoinChannel(string channelName, string userNickname, string password)
        {
            ValidateChannelName(channelName);
            ValidateNickname(userNickname);
            using (ChatContext context = new ChatContext())
            {
                var nameToLower = channelName.ToLower();

                var dbChannel = context.Channels.FirstOrDefault(c => c.Name.ToLower() == nameToLower);

                if (dbChannel == null)
                {
                    if (dbChannel.Name.ToLower() == nameToLower)
                    {
                        throw new ServerErrorException("Channel name does not exists.", "ERR_DUP_CHNAME"); //TODO: Fix Error code
                    }
                }

                if (dbChannel.Password != password)
                {
                    throw new ServerErrorException("Password incorrect.", "INV_USR_AUTH"); //TODO: Fix Error code
                }

                var dbUser = context.Users.FirstOrDefault(u => u.Nickname.ToLower() == userNickname.ToLower());

                var alreadyJoinedChannel = dbUser.Channels.FirstOrDefault(ch => ch.Name.ToLower() == channelName.ToLower());
                if (alreadyJoinedChannel != null)
                {
                    throw new ServerErrorException("Already joined channel.", "ERR_JOINED_CHANNEL"); //TODO: Add error code
                }

                dbChannel.Users.Add(dbUser);

                context.SaveChanges();
            }
        }

        public static void ExitChannel(string channelName, string userNickname)
        {
            ValidateChannelName(channelName);
            ValidateNickname(userNickname);
            using (ChatContext context = new ChatContext())
            {
                var nameToLower = channelName.ToLower();

                var dbChannel = context.Channels.FirstOrDefault(c => c.Name.ToLower() == nameToLower);
                var dbUser = context.Users.FirstOrDefault(u => u.Nickname.ToLower() == userNickname.ToLower());

                dbChannel.Users.Remove(dbUser);

                if (dbChannel.Users.Count == 0)
                {
                    context.Channels.Remove(dbChannel);
                }

                context.SaveChanges();
            }
        }

        public static void AddMessage(string channelName, string senderNickname, string messageText)
        {
            ValidateChannelName(channelName);
            ValidateNickname(senderNickname);
            using (ChatContext context = new ChatContext())
            {
                Message currentMsg = new Message()
                {
                    Author = senderNickname,
                    Content = messageText,
                    DateTime = DateTime.Now,
                };

                var dbChannel = context.Channels.FirstOrDefault(c => c.Name.ToLower() == channelName.ToLower());
                dbChannel.History.Add(currentMsg);

                context.SaveChanges();
            }
        }

        public static IEnumerable<MessageModel> GetHistory(string channelName)
        {
            ValidateChannelName(channelName);
            using (ChatContext context = new ChatContext())
            {
                var dbChannel = context.Channels.FirstOrDefault(c => c.Name.ToLower() == channelName.ToLower());

                if (dbChannel == null)
                {
                    throw new ServerErrorException(); //TODO: error messages
                }

                var history = dbChannel.History.OrderBy(x => x.DateTime).ToList();

                var historyModel = history.Select(new Func<Message, MessageModel>(x => new MessageModel()
                {
                    Author = x.Author,
                    Content = x.Content,
                    DateTime = x.DateTime,
                    Channel = x.Channel.Name,
                    MessageId = x.MessageId
                })).ToList();

                return historyModel;
            }
        }

        public static IEnumerable<ChannelModel> GetChannels()
        {
            using (ChatContext context = new ChatContext())
            {
                var channels = context.Channels.Select(new Func<Channel, ChannelModel>(x => new ChannelModel()
                {
                    Name = x.Name
                })).ToList();

                return channels;
            }
        }

        public static IEnumerable<UserModel> GetUsers(string channelName)
        {
            ValidateChannelName(channelName);
            using (ChatContext context = new ChatContext())
            {
                var channel = context.Channels.FirstOrDefault(c => c.Name.ToLower() == channelName.ToLower());

                var users = channel.Users.Select(new Func<User, UserModel>(x => new UserModel()
                {
                    Nickname = x.Nickname
                })).ToList();

                return users;
            }
        }
    }
}