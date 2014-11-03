using Giftable.Library.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using Giftable.Library.Helpers;
using Giftable.Library.Model;
using System;
using Newtonsoft.Json;

namespace Giftable.Library.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private const string USER_AUTH_TOKEN = "authCode";
        private const string USER_USERNAME = "username";
        private readonly IDataService _dataService;
        private readonly INavigationService _navigationService;
        private CredetentialsManager credetentialsManager = new CredetentialsManager();
        private string loginUsername;
        private string registerUsername;
        private string email;
        private string authToken;
        private bool isUserLoggedIn;
        private bool isUserRegistered;
        private ICommand _startAnalysisCommand;
        private ICommand _showAnalysisCommand;
        private ICommand loginUserCommand;
        private ICommand registerUserCommand;
        private ICommand logoutCommand;
        private ICommand enableRegisterCommand;

        public string LoginUsername
        {
            get { return this.loginUsername; }
            set 
            {
                this.loginUsername = value;
                this.RaisePropertyChanged("LoginUsername");
            }
        }

        public string RegisterUsername
        {
            get { return this.registerUsername; }
            set
            {
                this.registerUsername = value;
                this.RaisePropertyChanged("RegisterUsername");
            }
        }

        public bool IsUserRegistered
        {
            get { return this.isUserRegistered; }
            set 
            {
                this.isUserRegistered = value;
                this.RaisePropertyChanged("IsUserRegistered");
            }
        }

        public bool IsUserLoggedIn
        {
            get { return this.isUserLoggedIn; }
            set
            {
                this.isUserLoggedIn = value;
                this.RaisePropertyChanged("IsUserLoggedIn");
            }
        }

        public string Email
        {
            get { return this.email; }
            set
            {
                this.email = value;
                this.RaisePropertyChanged("Email");
            }
        }

        public ICommand StartAnalysisCommand
        {
            get
            {
                return _startAnalysisCommand
                    ?? (_startAnalysisCommand = new RelayCommand(ExecuteStartAnalysisCommand));
            }
        }

        public ICommand LoginUserCommand
        {
            get
            {
                if (this.loginUserCommand==null)
                {
                    this.loginUserCommand = new RelayCommand<string>(this.ExecuteLoginUserCommand);
                }

                return this.loginUserCommand;
            }
        }

        public ICommand RegisterUserCommand
        {
            get 
            {
                if (this.registerUserCommand==null)
                {
                    this.registerUserCommand = new RelayCommand<string>(this.ExecuteRegisterUserCommand);
                }
                return this.registerUserCommand;
            }
        }

        public ICommand LogoutCommand
        {
            get
            {
                if (this.logoutCommand==null)
                {
                    this.logoutCommand = new RelayCommand(this.ExecuteLogoutCommand);
                }
                return this.logoutCommand;
            }
        }

        public ICommand EnableRegisterCommand
        {
            get
            {
                if (this.enableRegisterCommand==null)
                {
                    this.enableRegisterCommand = new RelayCommand(this.ExecuteEnableRegisterCommand);
                }
                return this.enableRegisterCommand;
            }
        }

        private void ExecuteEnableRegisterCommand()
        {
            this.IsUserLoggedIn = false;
            this.IsUserRegistered = true;
        }

        private void ExecuteLogoutCommand()
        {
            this._dataService.LogoutUser(this.authToken);
        }

        private async void ExecuteRegisterUserCommand(string password)
        {
            try
            {
                var response = await this._dataService.RegisterUser(this.RegisterUsername, password, this.Email);
                if (response.IsSuccessStatusCode)
                {
                    var userStr = await response.Content.ReadAsStringAsync();
                    var user = JsonConvert.DeserializeObject<LoginResponseModel>(userStr);
                    this.credetentialsManager.SetCredetentials(user.Username, password);
                    this._navigationService.Navigate("ItemsPage", user);
                }
            }
            catch (ArgumentException ae)
            {
                ErrorDisplayer.ShowError(ae.Message);
            }
        }

        private void ExecuteLoginUserCommand(string password)
        {
            this._dataService.LoginUser(this.LoginUsername, password);
        }

        public ICommand ShowAnalysisCommand
        {
            get
            {
                return _showAnalysisCommand
                    ?? (_showAnalysisCommand = new RelayCommand(ExecuteShowAnalysisCommand));
            }
        }

        private void ExecuteStartAnalysisCommand()
        {
            _navigationService.Navigate("Views/StartAnalysis", string.Empty);
        }

        private void ExecuteShowAnalysisCommand()
        {
            _navigationService.Navigate("Views/ShowAnalysis");
        }

        public MainViewModel(INavigationService navigationService, IDataService dataService)
        {
            _navigationService = navigationService;
            _dataService = dataService;
            TakeUserData();
        }

        private void TakeUserData()
        {
            bool isUserLogged = this.CheckIfUserLogged();
            if (!isUserLogged)
            {
                LoginResponseModel user = credetentialsManager.TakeCredetentialsFromVault();
                if (user!=null)
                {
                    this.IsUserLoggedIn = true;
                    this.LoginUsername = user.Username;
                    this.authToken = user.AccessToken;
                    this._navigationService.Navigate("Views/ItemsPage", user);
                }
                else
                {
                    this.IsUserLoggedIn = true;
                }
            }
        }

        private bool CheckIfUserLogged()
        {
            string authTokenFromSettings = Windows.Storage.ApplicationData.Current.LocalSettings.Values[USER_AUTH_TOKEN] as string;
            if (authTokenFromSettings != null)
            {
                this.authToken = authTokenFromSettings;
                this.LoginUsername = Windows.Storage.ApplicationData.Current.LocalSettings.Values[USER_USERNAME] as string;

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
