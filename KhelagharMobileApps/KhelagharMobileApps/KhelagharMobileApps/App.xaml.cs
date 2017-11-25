using DryIoc;
using Prism.DryIoc;
using KhelagharMobileApps.Views;
using Xamarin.Forms;
using KhelagharMobileApps.Core.Services;
using KhelagharMobileApps.Core.Interfaces;
using KhelagharMobileApps.Services;

namespace KhelagharMobileApps
{
  public partial class App : PrismApplication
  {
    public App(IPlatformInitializer initializer = null) : base(initializer) { }

    protected override void OnInitialized()
    {
      InitializeComponent();

      //NavigationService.NavigateAsync("/MasterPage/NavigationPage/MainPage");
      NavigationService.NavigateAsync("NavigationPage/Login");
    }

    protected override void RegisterTypes()
    {
      Container.RegisterTypeForNavigation<NavigationPage>();
      Container.RegisterTypeForNavigation<MasterPage>();
      Container.RegisterTypeForNavigation<MainPage>();
      Container.RegisterTypeForNavigation<LoginPage>("Login");
      Container.RegisterTypeForNavigation<NewAsar>();
      Container.RegisterTypeForNavigation<AsarDetailPage>();
      Container.RegisterTypeForNavigation<WorkersPage>();

      Container.Register<IKgApiService, KgApiService>();
      Container.Register<IAuthenticationService, AuthenticationService>(Reuse.Singleton);
    }
  }
}
