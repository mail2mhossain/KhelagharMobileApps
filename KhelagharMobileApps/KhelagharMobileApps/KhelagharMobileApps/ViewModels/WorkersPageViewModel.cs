using KhelagharMobileApps.Core.Models;
using KhelagharMobileApps.Core.Services;
using Plugin.Connectivity;
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
  public class WorkersPageViewModel : ViewModelBase
  {
    private IList<AsarInfo> _asarList;
    private string _asarToSearch = String.Empty;
    private ObservableCollection<AsarInfo> _shakhaAsars;
    private AsarInfo _asar = null;
    private bool _isAsarListVisible = false;
    private DelegateCommand<ItemTappedEventArgs> _selectedAsar = null;
    private readonly IKgApiService _apiService;
    private readonly INavigationService _navigationService;
    public WorkersPageViewModel(IKgApiService apiService, INavigationService navigationService)
      : base(navigationService)
    {
      Title = "New Asar";
      _apiService = apiService;
      _navigationService = navigationService;
      _asarList = new List<AsarInfo>();
      _shakhaAsars = new ObservableCollection<AsarInfo>(_asarList);
    }
    public string AsarToSearch
    {
      get { return _asarToSearch; }
      set
      {
        SetProperty(ref _asarToSearch, value);
        Entry_TextChanged();
      }
    }
    public bool IsAsarListVisible
    {
      get { return _isAsarListVisible; }
      set { SetProperty(ref _isAsarListVisible, value); }
    }
    public AsarInfo Asar
    {
      get { return _asar; }
      set { SetProperty(ref _asar, value); }
    }
    public ObservableCollection<AsarInfo> ShakhaAsars
    {
      get { return _shakhaAsars; }
      set { SetProperty(ref _shakhaAsars, value); }
    }
    private void Entry_TextChanged()
    {
      if (AsarToSearch.Length > 0)
      {
        IsAsarListVisible = true;
        ShakhaAsars = new ObservableCollection<AsarInfo>(_asarList.Where(w => w.NameTosearch.StartsWith(AsarToSearch)).ToList());
      }
      else
      {
        IsAsarListVisible = false;
      }
    }
    public DelegateCommand<ItemTappedEventArgs> SelectedAsar
    {
      get
      {
        if (_selectedAsar == null)
        {
          _selectedAsar = new DelegateCommand<ItemTappedEventArgs>(selected =>
          {
            Asar = (AsarInfo)selected.Item;
            AsarToSearch = Asar.AsarName;
            IsAsarListVisible = false;
          });
        }
        return _selectedAsar;
      }
    }
    public async override void OnNavigatedTo(NavigationParameters parameters)
    {
      if (CrossConnectivity.Current.IsConnected)
      {
        _asarList = await _apiService.GetAsarInfo("AllAsar");
        ShakhaAsars = new ObservableCollection<AsarInfo>(_asarList);
      }
    }
  }
}
