using Acr.UserDialogs;
using KhelagharMobileApps.Core.Interfaces;
using KhelagharMobileApps.Core.Services;
using Plugin.Connectivity;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhelagharMobileApps.Services
{
  public class AuthenticationService : IAuthenticationService
  {
    INavigationService _navigationService { get; }
    private readonly IKgApiService _apiService;

    public AuthenticationService(INavigationService navigationService, IKgApiService apiService)
    {
      _navigationService = navigationService;
      _apiService = apiService;
    }

    public async Task<bool> Login(string username, string password)
    {
      string queryUrl = "Login?username=" + username + "&password=" + password;
      return await _apiService.IsLoggedIn(queryUrl);
    }

    public void Logout()
    {
      //Settings.Current.UserName = string.Empty;
      _navigationService.NavigateAsync("/Login");
    }
  }
}
