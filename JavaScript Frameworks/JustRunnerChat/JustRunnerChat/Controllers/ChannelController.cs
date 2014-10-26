using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using JustRunnerChat.Model;
using JustRunnerChat.Data;
using JustRunnerChat.Models;
using JustRunnerChat.Repositories;

namespace JustRunnerChat.Controllers
{
    public class ChannelController : BaseApiController
    {
        private static PubnubAPI pubnub = new PubnubAPI(
            "pub-c-5093de55-5a92-4b74-9522-d10c4c129dcc",
            "sub-c-20837058-05f4-11e3-991c-02ee2ddab7fe",
            "sec-c-NWJjODE5NGYtNDE1Mi00OWRiLWEwMmMtMjE3NDZlMTk3ODk3", true);
     
        [HttpPost]
        [ActionName("create")]
        public HttpResponseMessage CreateChannel(ChannelCreateModel channelModel)
        {
            var responseMsg = this.PerformOperation(() =>
            {
                ChannelsRepository.CreateChannel(channelModel.Name, channelModel.Nickname, channelModel.Password);
            });

            return responseMsg;
        }

        [HttpPost]
        [ActionName("join")]
        public HttpResponseMessage JoinChannel(ChannelJoinModel channelModel)
        {
            var responseMsg = this.PerformOperation(() =>
            {
                ChannelsRepository.JoinChannel(channelModel.Name, channelModel.Nickname, channelModel.Password);
            });

            return responseMsg;
        }

        [HttpPost]
        [ActionName("exit")]
        public HttpResponseMessage ExitChannel(ChannelExitModel channelModel)
        {
            var responseMsg = this.PerformOperation(() =>
            {
                ChannelsRepository.ExitChannel(channelModel.Name, channelModel.Nickname);
            });

            return responseMsg;
        }

        [HttpPost]
        [ActionName("add-message")]
        public HttpResponseMessage AddMessage(ChannelAddMessageModel channelModel)
        {
            var responseMsg = this.PerformOperation(() =>
            {
                ChannelsRepository.AddMessage(channelModel.Name, channelModel.Nickname, channelModel.Message);
            });

            pubnub.Publish(channelModel.Name, channelModel.Message);

            return responseMsg;
        }

        [HttpGet]
        [ActionName("get-history")]
        public HttpResponseMessage GetHistory(string channelName)
        {
            var responseMsg = this.PerformOperation(() =>
            {
                var history = ChannelsRepository.GetHistory(channelName);
                return history;
            });

            return responseMsg;
        }

        [HttpGet]
        [ActionName("get-channels")]
        public HttpResponseMessage GetChannels()
        {
            var responseMsg = this.PerformOperation(() =>
            {
                var channels = ChannelsRepository.GetChannels();
                return channels;
            });

            return responseMsg;
        }

        [HttpGet]
        [ActionName("get-users")]
        public HttpResponseMessage GetUsers(string channelName)
        {
            var responseMsg = this.PerformOperation(() =>
            {
                var history = ChannelsRepository.GetUsers(channelName);
                return history;
            });

            return responseMsg;
        }
    }
}