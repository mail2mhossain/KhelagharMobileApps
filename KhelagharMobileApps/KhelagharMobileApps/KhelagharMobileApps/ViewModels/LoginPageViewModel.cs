using Acr.UserDialogs;
using KhelagharMobileApps.Core.Interfaces;
using Plugin.Connectivity;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhelagharMobileApps.ViewModels
{
  public class LoginPageViewModel : ViewModelBase
  {
    private bool _isAcrivityIndicatorVisible = false;
    private bool _isAcrivityIndicatorRunning = false;
    IAuthenticationService _authenticationService { get; }
    IPageDialogService _pageDialogService { get; }
    public LoginPageViewModel(INavigationService navigationService, IAuthenticationService authenticationService, IPageDialogService pageDialogService)
        : base(navigationService)
    {
      _authenticationService = authenticationService;
      _pageDialogService = pageDialogService;

      Title = "Login";

      LoginCommand = new DelegateCommand(OnLoginCommandExecuted, LoginCommandCanExecute)
          .ObservesProperty(() => UserName)
          .ObservesProperty(() => Password);
    }
    public bool IsActivitiIndicatorVisible
    {
      get { return _isAcrivityIndicatorVisible; }
      set { SetProperty(ref _isAcrivityIndicatorVisible, value); }
    }
    public bool IsActivitiIndicatorRunning
    {
      get { return _isAcrivityIndicatorRunning; }
      set { SetProperty(ref _isAcrivityIndicatorRunning, value); }
    }
    private string _userName;
    public string UserName
    {
      get { return _userName; }
      set { SetProperty(ref _userName, value); }
    }

    private string _password;
    public string Password
    {
      get { return _password; }
      set { SetProperty(ref _password, value); }
    }

    public DelegateCommand LoginCommand { get; }

    private async void OnLoginCommandExecuted()
    {
      IsBusy = true;
      if (!CrossConnectivity.Current.IsConnected)
      {
        await UserDialogs.Instance.AlertAsync("ইনটারনেট সংযোগ নাই। ইন্টারনেট সংযোগ দিন।");
        IsBusy = false;
        return;
      }
      this.IsActivitiIndicatorVisible = true;
      this.IsActivitiIndicatorRunning = true;
      if (_authenticationService.Login(UserName, Password))
      {
        //NavigationParameters param = new NavigationParameters();
        //param.Add("message", "Glad you read the code");
        //await NavigationService.NavigateAsync("ViewA", param);
        //await NavigationService.NavigateAsync("/MainPage");
        await NavigationService.NavigateAsync("/MasterPage/NavigationPage/MainPage");
        //await NavigationService.NavigateAsync("/MainPage/NavigationPage/ViewA?message=Glad%20you%20read%20the%20code");
      }
      else
      {
        await _pageDialogService.DisplayAlertAsync("Logon Error", "User Name or Password is wrong", "Try Again");
      }
      IsBusy = false;
      this.IsActivitiIndicatorVisible = false;
      this.IsActivitiIndicatorRunning = false;
    }

    private bool LoginCommandCanExecute() =>
        !string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Password) && IsNotBusy;
  }
}
