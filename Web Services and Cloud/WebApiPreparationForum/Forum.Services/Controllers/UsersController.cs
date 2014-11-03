using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ValueProviders;
using Forum.Data;
using Forum.Model;
using Forum.Repositories;
using Forum.Services.Attributes;
using Forum.Services.Models;
using System.Text;

namespace Forum.Services.Controllers
{
    public class UsersController : BaseController
    {
        private IRepository<User> repository; 
        private const int MinUsernameLength = 6;
        private const int MaxUsernameLength = 30;
        private const string SessionKeyChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private const string ValidUsernameChars = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM_1234567890";
        private const string ValidNicknameChars = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM_1234567890 -";
        private const int Sha1Length = 40;
        private const int SessionKeyLength = 50;
        private static readonly Random rand = new Random();
        
        public UsersController(IRepository<User> repository)
        {
            this.repository = repository;
        }

        [HttpPost, ActionName("register")]
        public HttpResponseMessage RegisterUser(UserModel model)
        {
            var registerResponse = this.PerformOperationAndHandleExceptions(() =>
                {
                    this.ValidateUsername(model.Username);
                    this.ValidateNickname(model.Nickname);
                    this.ValidateAuthCode(model.AuthCode);
                    var usernameToLower = model.Username.ToLower();
                    var nicknameToLower = model.Nickname.ToLower();
                    var user = repository.All()
                        .FirstOrDefault(usr => usr.Username == usernameToLower || usr.Nickname == nicknameToLower);
                    if (user != null)
                    {
                        throw new InvalidOperationException("User allready exist");
                    }

                    user = new User()
                        {
                            Username = usernameToLower,
                            Nickname = model.Nickname,
                            AuthCode = model.AuthCode,
                        };

                    repository.Add(user);
                    user.SessionKey = this.GenerateSessionKey(user.UserId);
                    repository.Update(user.UserId, user);

                    var userModel = new LoggedUserModel()
                        {
                            Nickname = user.Nickname,
                            SessionKey = user.SessionKey
                        };

                    var response = this.Request.CreateResponse(HttpStatusCode.Created, userModel);
                    return response;
                });
            return registerResponse;
        }

        [HttpPost, ActionName("login")]
        public HttpResponseMessage LoginUser(UserModel model)
        {
            var baseResponse = this.PerformOperationAndHandleExceptions(() =>
            {
                this.ValidateUsername(model.Username);
                this.ValidateAuthCode(model.AuthCode);
                var usernameToLower = model.Username.ToLower();
                var user = repository.All()
                    .FirstOrDefault(usr => usr.Username == usernameToLower && usr.AuthCode == model.AuthCode);

                if (user == null)
                {
                    throw new InvalidOperationException("Username is not exist!");
                }

                if (user.SessionKey == null)
                {
                    user.SessionKey = this.GenerateSessionKey(user.UserId);
                    repository.Update(user.UserId, user);
                }

                var userModel = new LoggedUserModel()
                {
                    Nickname = user.Nickname,
                    SessionKey = user.SessionKey
                };

                var response = this.Request.CreateResponse(HttpStatusCode.Created, userModel);
                return response;
            });
            return baseResponse;
        }

        [HttpPut, ActionName("logout")]
        public HttpResponseMessage LogoutUser([ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var logoutResponse = this.PerformOperationAndHandleExceptions(() =>
                {
                    var user = this.repository.All().SingleOrDefault(usr => usr.SessionKey == sessionKey);
                    if (user == null)
                    {
                        throw new InvalidOperationException("User allready exist");
                    }

                    user.SessionKey = null;
                    this.repository.Update(user.UserId, user);

                    var response = this.Request.CreateResponse(HttpStatusCode.OK);
                    return response;
                });
            return logoutResponse;
        }

        private void ValidateAuthCode(string authCode)
        {
            if (authCode == null || authCode.Length != Sha1Length)
            {
                throw new ArgumentOutOfRangeException("Password should be encrypted!");
            }
        }

        private void ValidateNickname(string nickname)
        {
            if (nickname == null)
            {
                throw new ArgumentNullException("Username can not be null!");
            }
            else if (nickname.Length < MinUsernameLength || nickname.Length > MaxUsernameLength)
            {
                throw new ArgumentOutOfRangeException(string.Format("Username must be more than {0} and less than {1}!", MinUsernameLength, MaxUsernameLength));
            }
            else if (nickname.Any(ch => !ValidNicknameChars.Contains(ch)))
            {
                throw new ArgumentOutOfRangeException("username must contains only laters, digits, '.', ',' and '_'");
            }
        }

        private void ValidateUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException("Username can not be null!");
            }
            else if (username.Length < MinUsernameLength || username.Length > MaxUsernameLength)
            {
                throw new ArgumentOutOfRangeException(string.Format("Username must be more than {0} and less than {1}!", MinUsernameLength, MaxUsernameLength));
            }
            else if (username.Any(ch => !ValidUsernameChars.Contains(ch)))
            {
                throw new ArgumentOutOfRangeException("username must contains only laters, digits, '.', ',' and '_'");
            }
        }

        private string GenerateSessionKey(int userId)
        {
            StringBuilder sessionKeyBuilder = new StringBuilder(SessionKeyLength);
            sessionKeyBuilder.Append(userId);
            while (sessionKeyBuilder.Length < SessionKeyLength)
            {
                var index = rand.Next(SessionKeyChars.Length);
                sessionKeyBuilder.Append(SessionKeyChars[index]);
            }

            return sessionKeyBuilder.ToString();
        }
    }
}
