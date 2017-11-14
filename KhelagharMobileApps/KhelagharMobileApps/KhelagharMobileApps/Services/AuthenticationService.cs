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

    public AuthenticationService(INavigationService navigationService)
    {
      _navigationService = navigationService;
    }

    public bool Login(string username, string password)
    {
      LoginService service = new LoginService();
      
      if (service.Login(username, password))
      {
        //Settings.Current.UserName = username;
        return true;
      }

      return false;
    }

    public void Logout()
    {
      //Settings.Current.UserName = string.Empty;
      _navigationService.NavigateAsync("/Login");
    }
  }
}
