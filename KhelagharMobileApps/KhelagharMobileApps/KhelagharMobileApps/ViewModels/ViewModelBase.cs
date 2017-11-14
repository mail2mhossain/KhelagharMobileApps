using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhelagharMobileApps.ViewModels
{
  public class ViewModelBase : BindableBase, INavigationAware, IDestructible
  {
    protected INavigationService NavigationService { get; private set; }

    private string _title;
    public string Title
    {
      get { return _title; }
      set { SetProperty(ref _title, value); }
    }
    private bool _isBusy;
    public bool IsBusy
    {
      get { return _isBusy; }
      set { SetProperty(ref _isBusy, value, () => RaisePropertyChanged(nameof(IsNotBusy))); }
    }

    public bool IsNotBusy
    {
      get { return !IsBusy; }
    }

    public ViewModelBase(INavigationService navigationService)
    {
      NavigationService = navigationService;
    }

    public virtual void OnNavigatedFrom(NavigationParameters parameters)
    {

    }

    public virtual void OnNavigatedTo(NavigationParameters parameters)
    {

    }

    public virtual void OnNavigatingTo(NavigationParameters parameters)
    {

    }

    public virtual void Destroy()
    {

    }
  }
}
