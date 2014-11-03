using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Web.Http;
using System.Web.Http.ValueProviders;
using Giftable.API.AuthenticationHeaders;
using Giftable.API.Models;
using Giftable.Data;
using Giftable.Models;

namespace Giftable.API.Controllers
{
    public class UsersController : BaseApiController
    {
        private const int TokenLength = 50;
        private const string TokenChars = "qwertyuiopasdfghjklmnbvcxzQWERTYUIOPLKJHGFDSAZXCVBNM";
        private const int MinUsernameLength = 6;
        private const int MaxUsernameLength = 30;
        private const int AuthenticationCodeLength = 40;
        private const string ValidUsernameChars = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM1234567890_.@";

        [HttpPost]
        [ActionName("register")]
        public HttpResponseMessage RegisterUser(UserModel model)
        {
            return this.ExecuteOperationAndHandleExceptions(() =>
            {
                this.ValidateUser(model);
                this.ValidateEmail(model.Email);

                var context = new ApplicationDbContext();
                var dbUser = this.GetUserByUsernameOrEmail(model, context);
                if (dbUser != null)
                {
                    throw new InvalidOperationException("This user already exists in the database");
                }
                dbUser = new User()
                {
                    Username = model.Username,
                    Email = model.Email,
                    AuthenticationCode = model.AuthCode
                };
                context.Users.Add(dbUser);

                context.SaveChanges();

                var responseModel = new RegisterUserResponseModel()
                {
                    Id = dbUser.Id,
                    Username = dbUser.Username,
                    AccessToken=dbUser.AccessToken
                };

                var response = this.Request.CreateResponse(HttpStatusCode.Created, responseModel);
                return response;
            });
        }

        [HttpPost]
        [ActionName("token")]
        public HttpResponseMessage LoginUser(UserModel model)
        {
            return this.ExecuteOperationAndHandleExceptions(() =>
            {
                //this.ValidateUser(model);
                if (model == null)
                {
                    throw new FormatException("invalid username and/or password");
                }
                this.ValidateAuthCode(model.AuthCode);
                try
                {
                    this.ValidateUsername(model.Username);
                }
                catch (Exception ex)
                {
                    this.ValidateEmail(model.Email);
                }

                var context = new ApplicationDbContext();
                var username = ((string.IsNullOrEmpty(model.Username)) ? model.Email : model.Username).ToLower();
                var user = context.Users.FirstOrDefault(u => u.Username == username || u.Email == username);
                if (user == null)
                {
                    throw new InvalidOperationException("Invalid username or password");
                }
                if (user.AccessToken == null)
                {
                    user.AccessToken = this.GenerateAccessToken(user.Id);
                    context.SaveChanges();
                }
                var responseModel = new LoginResponseModel()
                {
                    Id = user.Id,
                    Username = user.Username,
                    AccessToken = user.AccessToken
                };
                var response = this.Request.CreateResponse(HttpStatusCode.OK, responseModel);
                return response;
            });
        }

        [HttpPut]
        [ActionName("logout")]
        public HttpResponseMessage LogoutUser(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
            string accessToken)
        {
            return this.ExecuteOperationAndHandleExceptions(() =>
            {
                var context = new ApplicationDbContext();
                var user = this.GetUserByAccessToken(accessToken, context);
                user.AccessToken = null;
                context.SaveChanges();

                var response = this.Request.CreateResponse(HttpStatusCode.NoContent);
                return response;
            });
        }

        [HttpGet]
        [ActionName("friends")]
        public HttpResponseMessage GetFriends(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
            string accessToken)
        {
            return this.ExecuteOperationAndHandleExceptions(() =>
            {
                var context = new ApplicationDbContext();
                var user = this.GetUserByAccessToken(accessToken, context);

                var responseModel = user.Friends.AsQueryable()
                                        .Select(x => new FriendModel
                                        {
                                            Id = x.Id,
                                            Email = x.Email,
                                            AuthCode = x.AuthenticationCode,
                                            Username = x.Username
                                        });

                var response = this.Request.CreateResponse(HttpStatusCode.OK, responseModel);

                return response;
            });
        }

        [HttpGet]
        [ActionName("search-friends")]
        public HttpResponseMessage GetFriends(string email,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
            string accessToken)
        {
            return this.ExecuteOperationAndHandleExceptions(() =>
            {
                var context = new ApplicationDbContext();
                var user = this.GetUserByAccessToken(accessToken, context);
                var targetedUser = context.Users.FirstOrDefault(x => x.Email == email);
                if (targetedUser == null)
                {
                    return this.Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    var responseModel = user.Friends.AsQueryable()
                                        .Select(x => new FriendModel
                                        {
                                            Id = x.Id,
                                            Email = x.Email,
                                            AuthCode = x.AuthenticationCode,
                                            Username = x.Username
                                        });

                    var response = this.Request.CreateResponse(HttpStatusCode.OK, responseModel);

                    return response;
                }
            });
        }

        [HttpGet]
        [ActionName("friend-details")]
        public HttpResponseMessage GetFriends(int id,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
            string accessToken)
        {
            return this.ExecuteOperationAndHandleExceptions(() =>
            {
                var context = new ApplicationDbContext();
                var user = this.GetUserByAccessToken(accessToken, context);

                var responseModel = user.Friends.AsQueryable()
                                        .Where(x => x.Id == id)
                                        .Select(x => new FriendModel
                                        {
                                            Id = x.Id,
                                            Email = x.Email,
                                            AuthCode = x.AuthenticationCode,
                                            Username = x.Username
                                        }).FirstOrDefault();

                var response = this.Request.CreateResponse(HttpStatusCode.OK, responseModel);

                return response;
            });
        }

        [HttpPut]
        [ActionName("make-friends-with")]
        public HttpResponseMessage MakeFriendsWih(string email,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
            string accessToken)
        {
            return this.ExecuteOperationAndHandleExceptions(() =>
            {
                var context = new ApplicationDbContext();
                var user = this.GetUserByAccessToken(accessToken, context);
                var futureFriend = context.Users.FirstOrDefault(x => x.Email == email);
                //Invite friend to join our app
                if (futureFriend == null)
                {
                    //TODO: email to invite user into out app
                    //try
                    //{
                    //    MailAddress mail = new MailAddress(email);
                    //    MailMessage message = new System.Net.Mail.MailMessage();
                    //    message.To.Add(email);
                    //    message.Subject = "This is the Subject line";
                    //    message.From = new System.Net.Mail.MailAddress("From@online.microsoft.com");
                    //    message.Body = "This is the message body";
                    //    System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("yoursmtphost");
                    //    smtp.Send(message);
                    //}
                    //catch
                    //{
                        
                    //}
                }
                else
                {
                    user.Friends.Add(futureFriend);
                    context.SaveChanges();
                }

                var model = new FriendModel()
                {
                    Id = futureFriend.Id,
                    AuthCode = futureFriend.AuthenticationCode,
                    Email = futureFriend.Email,
                    Username = futureFriend.Username
                };

                var response = this.Request.CreateResponse(HttpStatusCode.OK, model);

                return response;
            });
        }

        [HttpPut]
        [ActionName("upload-avatar")]
        public HttpResponseMessage UploadAvatar(AvatarModel model,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
            string accessToken)
        {
            return this.ExecuteOperationAndHandleExceptions(() =>
            {
                var context = new ApplicationDbContext();
                var user = this.GetUserByAccessToken(accessToken, context);
                if (user == null)
                {
                    user.Avatar = model.Url;
                }
                else
                {
                    return this.Request.CreateResponse(HttpStatusCode.BadRequest);
                }

                var response = this.Request.CreateResponse(HttpStatusCode.NoContent);

                return response;
            });
        }

        private User GetUserByUsernameOrEmail(UserModel model, ApplicationDbContext context)
        {
            var usernameToLower = model.Username.ToLower();
            var emailToLower = model.Email.ToLower();
            var dbUser = context.Users.FirstOrDefault(u => u.Username == usernameToLower || u.Email == emailToLower);
            return dbUser;
        }

        private string GenerateAccessToken(int userId)
        {
            StringBuilder tokenBuilder = new StringBuilder(TokenLength);
            tokenBuilder.Append(userId);
            while (tokenBuilder.Length < TokenLength)
            {
                var index = rand.Next(TokenChars.Length);
                var ch = TokenChars[index];
                tokenBuilder.Append(ch);
            }

            return tokenBuilder.ToString();
        }

        private void ValidateEmail(string email)
        {
            try
            {
                new MailAddress(email);
            }
            catch (FormatException ex)
            {
                throw new FormatException("Email is invalid", ex);
            }
        }

        private void ValidateUser(UserModel userModel)
        {
            if (userModel == null)
            {
                throw new FormatException("Username and/or password are invalid");
            }
            this.ValidateUsername(userModel.Username);
            this.ValidateAuthCode(userModel.AuthCode);
        }

        private void ValidateAuthCode(string authCode)
        {
            if (string.IsNullOrEmpty(authCode) || authCode.Length != AuthenticationCodeLength)
            {
                throw new FormatException("Password is invalid");
            }
        }

        private void ValidateUsername(string username)
        {
            if (username.Length < MinUsernameLength || MaxUsernameLength < username.Length)
            {
                throw new FormatException(
                    string.Format("Username must be between {0} and {1} characters",
                        MinUsernameLength,
                        MaxUsernameLength));
            }
            if (username.Any(ch => !ValidUsernameChars.Contains(ch)))
            {
                throw new FormatException("Username contains invalid characters");
            }
        }
    }
}