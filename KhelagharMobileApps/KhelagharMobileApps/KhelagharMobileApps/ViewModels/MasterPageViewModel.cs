using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KhelagharMobileApps.ViewModels
{
  public class MasterPageViewModel : ViewModelBase
  {
    public MasterPageViewModel(INavigationService navigationService)
      : base(navigationService)
    {
      Title = "Main Page";
      NavigateCommand = new DelegateCommand<string>(OnNavigateCommandExecuted);
    }
    public DelegateCommand<string> NavigateCommand { get; }

    private async void OnNavigateCommandExecuted(string path)
    {
      //await NavigationService.NavigateAsync("NavigationPage/ViewB?message=Glad%20you%20read%20the%20code");
      await NavigationService.NavigateAsync(path);
    }
  }
}
