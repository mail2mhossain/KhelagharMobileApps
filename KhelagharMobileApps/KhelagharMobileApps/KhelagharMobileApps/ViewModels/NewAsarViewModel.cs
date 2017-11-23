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
  public class NewAsarViewModel : ViewModelBase
  {
    private IList<UpojelaInfo> _upojelaList;
    private string _upojelaToSearch = "";
    private ObservableCollection<UpojelaInfo> _upojelas;
    private UpojelaInfo _upojela = null;
    private bool _isUpojelaListVisible = false;
    private DelegateCommand<ItemTappedEventArgs> _selectedUpojela = null;
    private readonly IKgApiService _apiService;
    private readonly INavigationService _navigationService;
    public NewAsarViewModel(IKgApiService apiService, INavigationService navigationService)
        : base(navigationService)
    {
      Title = "New Asar";
      _apiService = apiService;
      _navigationService = navigationService;
      IsUpojelaListVisible = true;
    }
    public string UpojelaToSearch
    {
      get { return _upojelaToSearch; }
      set
      {
        SetProperty(ref _upojelaToSearch, value);
        Entry_TextChanged();
      }
    }
    public bool IsUpojelaListVisible
    {
      get { return _isUpojelaListVisible; }
      set { SetProperty(ref _isUpojelaListVisible, value); }
    }
    public UpojelaInfo Subdistrict
    {
      get { return _upojela; }
      set { SetProperty(ref _upojela, value); }
    }
    public ObservableCollection<UpojelaInfo> Subdistricts
    {
      get { return _upojelas; }
      set { SetProperty(ref _upojelas, value); }
    }
    private void Entry_TextChanged()
    {
      if (UpojelaToSearch.Length > 0)
      {
        IsUpojelaListVisible = true;
        Subdistricts = new ObservableCollection<UpojelaInfo>(_upojelaList.Where(w => w.Name.StartsWith(UpojelaToSearch)).ToList());
      }
      else
      {
        IsUpojelaListVisible = false;
      }
    }
    public DelegateCommand<ItemTappedEventArgs> SelectedUpojela
    {
      get
      {
        if (_selectedUpojela == null)
        {
          _selectedUpojela = new DelegateCommand<ItemTappedEventArgs>(selected =>
          {
            Subdistrict = (UpojelaInfo)selected.Item;
            UpojelaToSearch = Subdistrict.Area;
            IsUpojelaListVisible = false;
          });
        }
        return _selectedUpojela;
      }
    }
    public async override void OnNavigatedTo(NavigationParameters parameters)
    {
      if (CrossConnectivity.Current.IsConnected)
      {
        _upojelaList = await _apiService.GetSubdistricts("AllUpojela");
        Subdistricts = new ObservableCollection<UpojelaInfo>(_upojelaList);
      }
    }
  }
}
