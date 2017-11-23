using KhelagharMobileApps.Core.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace KhelagharMobileApps.ViewModels
{
  public class MasterPageViewModel : ViewModelBase
  {
    private ObservableCollection<Core.Models.MenuItem> _menuList;
    private DelegateCommand<ItemTappedEventArgs> _navigatedItem = null;
    private readonly INavigationService _navigationService;

    public MasterPageViewModel(INavigationService navigationService)
      : base(navigationService)
    {
      Title = "Main Page";
      _navigationService = navigationService;
    }
    public ObservableCollection<Core.Models.MenuItem> MenuList
    {
      get { return _menuList; }
      set { SetProperty(ref _menuList, value); }
    }
    public DelegateCommand<ItemTappedEventArgs> NavigateTo
    {
      get
      {
        if (_navigatedItem == null)
        {
          _navigatedItem = new DelegateCommand<ItemTappedEventArgs>(async selected =>
          {
            Core.Models.MenuItem item = (Core.Models.MenuItem)selected.Item;
            await _navigationService.NavigateAsync(item.Url);
          });
        }
        return _navigatedItem;
      }
    }
    public override void OnNavigatedTo(NavigationParameters parameters)
    {
      MenuList = new ObservableCollection<Core.Models.MenuItem>(DataService.GetMenuList());
    }
  }
}
