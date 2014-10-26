namespace BlogSystem.WebApi.Controllers
{
    using Forum.Models;
    using Forum.WebApi.Models;
    using Forum.WebApi.Attributes;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Web.Http;
    using System.Web.Http.ValueProviders;
    using Forum.WebApi.Controllers;

    public class UsersController : BaseApiController
    {
        private const int MinUsernameLength = 6;
        private const int MaxUsernameLength = 30;
        private const int MinNicknameLength = 3;
        private const int MaxNicknameLength = 30;
        private const int Sha1Length = 40;
        private const string ValidUsernameCharacters =
            "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM1234567890_.";
        private const string ValidNicknameCharacters =
            "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM1234567890_. -";
        private const string ValidAuthCodeCharacters =
            "0123456789abcdefABCDEF";

        private static readonly Random rand = new Random();

        private readonly IDbContextFactory<DbContext> contextFactory;

        public UsersController()
        {
            this.contextFactory = new DbForumContextFactory();
        }

        public UsersController(IDbContextFactory<DbContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        [HttpPost]
        [ActionName("register")]
        public HttpResponseMessage RegisterUser([FromBody] UserRegisterLoginModel userModel)
        {
            var responseMessage = this.PerformOperationAndHandleExceptions(() =>
                {
                    this.ValidateUsername(userModel.Username);
                    this.ValidateNickname(userModel.Nickname);
                    this.ValidateAuthCode(userModel.AuthenticationCode);

                    var context = this.contextFactory.Create();

                    using (context)
                    {
                        var usernameToLower = userModel.Username.ToLower();
                        var nicknameToLower = userModel.Nickname.ToLower();

                        var user = context.Set<User>().FirstOrDefault(
                           usr => usr.Username == usernameToLower
                           || usr.Nickname.ToLower() == nicknameToLower);

                        if (user != null)
                        {
                            throw new InvalidOperationException("User already exists!");
                        }

                        user = new User()
                        {
                            Username = usernameToLower,
                            Nickname = userModel.Nickname,
                            AuthenticationCode = userModel.AuthenticationCode
                        };

                        context.Set<User>().Add(user);
                        context.SaveChanges();

                        user.SessionKey = this.GenerateSessionKey(user.Id);
                        context.SaveChanges();

                        var loggedModel = new UserLoggedModel()
                        {
                            Nickname = user.Nickname,
                            SessionKey = user.SessionKey
                        };

                        var response = this.Request.CreateResponse(HttpStatusCode.Created, loggedModel);
                        return response;
                    }
                });

            return responseMessage;
        }

        [HttpPost]
        [ActionName("login")]
        public HttpResponseMessage LoginUser([FromBody] UserRegisterLoginModel userModel)
        {
            var responseMessage = this.PerformOperationAndHandleExceptions(
              () =>
              {
                  this.ValidateUsername(userModel.Username);
                  this.ValidateAuthCode(userModel.AuthenticationCode);

                  var context = this.contextFactory.Create();

                  using (context)
                  {
                      var usernameToLower = userModel.Username.ToLower();

                      var user = context.Set<User>()
                          .Where(x => x.Username == usernameToLower && x.AuthenticationCode == userModel.AuthenticationCode).FirstOrDefault();

                      if (user == null)
                      {
                          throw new InvalidOperationException("Invalid username or password!");
                      }

                      if (user.SessionKey == null)
                      {
                          user.SessionKey = this.GenerateSessionKey(user.Id);
                          context.SaveChanges();
                      }

                      UserLoggedModel loggedUser = new UserLoggedModel()
                      {
                          Nickname = user.Nickname,
                          SessionKey = user.SessionKey
                      };

                      var response = this.Request.CreateResponse(HttpStatusCode.OK, loggedUser);
                      return response;
                  }
              });

            return responseMessage;
        }

        [HttpPut]
        [ActionName("logout")]
        public HttpResponseMessage LogoutUser([ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMessage = this.PerformOperationAndHandleExceptions(() =>
            {
                this.ValidateSessionKey(sessionKey);

                var context = this.contextFactory.Create();

                using (context)
                {
                    var user = context.Set<User>().Where(x => x.SessionKey == sessionKey).FirstOrDefault();

                    if (user == null)
                    {
                        throw new InvalidOperationException("Invalid session key authentication!");
                    }

                    user.SessionKey = null;
                    context.SaveChanges();

                    var resultResponse = this.Request.CreateResponse(HttpStatusCode.OK, "Successfull logout!");
                    return resultResponse;
                }
            });

            return responseMessage;
        }

        private void ValidateAuthCode(string authCode)
        {
            if (authCode == null)
            {
                throw new ArgumentNullException("Authentication code cannot be null!");
            }
            else if (authCode.Length != Sha1Length)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Authentication code must be exactly {0} characters long!", Sha1Length));
            }
            else if (authCode.Any(x => !ValidAuthCodeCharacters.Contains(x)))
            {
                throw new ArgumentOutOfRangeException(
                    "Authentication code must contain only digits and the letters 'a', 'b', 'c', 'd', 'e', 'f'!");
            }
        }

        private void ValidateNickname(string nickname)
        {
            if (nickname == null)
            {
                throw new ArgumentNullException("Nickname cannot be null!");
            }
            else if (nickname.Length < MinNicknameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Nickname must be at least {0} characters long!", MinNicknameLength));
            }
            else if (nickname.Length > MaxNicknameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Nickname must be at most {0} characters long!", MaxNicknameLength));
            }
            else if (nickname.Any(x => !ValidNicknameCharacters.Contains(x)))
            {
                throw new ArgumentOutOfRangeException(
                    "Nickname must contain only latin letters, digits, '.', '_', '-' and ' '!");
            }
        }

        private void ValidateUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException("Username cannot be null!");
            }
            else if (username.Length < MinUsernameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Username must be at least {0} characters long!", MinUsernameLength));
            }
            else if (username.Length > MaxUsernameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Username must be at most {0} characters long!", MaxUsernameLength));
            }
            else if (username.Any(ch => !ValidUsernameCharacters.Contains(ch)))
            {
                throw new ArgumentOutOfRangeException(
                    "Username must contain only latin letters, digits, '.' and '_'!");
            }
        }

        private string GenerateSessionKey(int id)
        {
            StringBuilder sessionKey = new StringBuilder(SessionKeyLength);
            sessionKey.Append(id);

            while (sessionKey.Length < SessionKeyLength)
            {
                var index = rand.Next(ValidSessionKeyChars.Length);
                sessionKey.Append(ValidSessionKeyChars[index]);
            }

            return sessionKey.ToString();
        }
    }
}
