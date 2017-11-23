﻿using Acr.UserDialogs;
using KhelagharMobileApps.Core.Interfaces;
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
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KhelagharMobileApps.ViewModels
{
  public class MainPageViewModel : ViewModelBase
  {
    private bool _isAcrivityIndicatorVisible = false;
    private bool _isAcrivityIndicatorRunning = false;
    private bool _isAsarCountVisible = false;
    private string _textToSearch = "";
    private IList<string> _searchOptions = new List<string>();
    private IAuthenticationService _authenticationService { get; }
    private string _selectedOption = String.Empty;
    private ObservableCollection<AsarInfo> _asarList;
    private int _asarCount;
    private readonly IKgApiService _apiService;
    private readonly INavigationService _navigationService;
    public DelegateCommand SearchCommand { get; set; }
    private DelegateCommand<ItemTappedEventArgs> _goToDetailPage = null;
    public MainPageViewModel(IKgApiService apiService, INavigationService navigationService, IAuthenticationService authenticationService)
      : base(navigationService)
    {
      _apiService = apiService;
      _navigationService = navigationService;
      Title = "Asar Search";
      _authenticationService = authenticationService;
      LogoutCommand = new DelegateCommand(OnLogoutCommandExecuted);
      SearchCommand = new DelegateCommand(Search);

      SetAsarSearchOption();
    }
    public DelegateCommand LogoutCommand { get; }
    public void OnLogoutCommandExecuted() =>
        _authenticationService.Logout();
    private void SetAsarSearchOption()
    {
      _searchOptions.Add(AsarSearchOptions.SearchByAsar);
      _searchOptions.Add(AsarSearchOptions.SearchByUpojela);
      _searchOptions.Add(AsarSearchOptions.SearchByJela);

      _selectedOption = _searchOptions[0];
    }
    private async void Search()
    {
      if (!CrossConnectivity.Current.IsConnected)
      {
        await UserDialogs.Instance.AlertAsync("ইনটারনেট সংযোগ নাই। ইন্টারনেট সংযোগ দিন।");
        return;
      }
      string queryUrl = GetQueryUrl();
      if(String.IsNullOrEmpty(_textToSearch.Trim()))
      {
        await UserDialogs.Instance.AlertAsync("কিছু টাইপ করুন।");
        return;
      }
      
      IsAsarCountVisible = false;
      this.IsActivitiIndicatorVisible = true;
      this.IsActivitiIndicatorRunning = true;
      IList<AsarInfo> asars = await _apiService.GetAsars(queryUrl + _textToSearch); 
      Asars = new ObservableCollection<AsarInfo>(asars);
      AsarCount = asars.Count;
      IsAsarCountVisible = true;
      this.IsActivitiIndicatorVisible = false;
      this.IsActivitiIndicatorRunning = false;
    }
    public DelegateCommand<ItemTappedEventArgs> GoToDetailPage
    {
      get
      {
        if (_goToDetailPage == null)
        {
          _goToDetailPage = new DelegateCommand<ItemTappedEventArgs>(async selected =>
          {
            NavigationParameters param = new NavigationParameters();
            param.Add("show", selected.Item);
            await _navigationService.NavigateAsync("AsarDetailPage", param,false,true);
          });
        }
        return _goToDetailPage;
      }
    }
    public IList<string> SearchOptions
    {
      get { return _searchOptions;}
      set { SetProperty(ref _searchOptions, value); }
    }
    public string SelectedOption
    {
      get { return _selectedOption; }
      set { SetProperty(ref _selectedOption, value); }
    }
    public string TextToSearch
    {
      get { return _textToSearch; }
      set { SetProperty(ref _textToSearch, value); }
    }
    public ObservableCollection<AsarInfo> Asars
    {
      get { return _asarList; }
      set { SetProperty(ref _asarList, value); }
    }
    public int AsarCount
    {
      get { return _asarCount; }
      set { SetProperty(ref _asarCount, value); }
    }
    public bool IsAsarCountVisible
    {
      get { return _isAsarCountVisible; }
      set { SetProperty(ref _isAsarCountVisible, value); }
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
   
    
    public override void OnNavigatedTo(NavigationParameters parameters)
    {
      //await Task.Delay(1);
      //IList<AsarInfo> asars = await _apiService.GetAsars(_queryUrl);
      //Asars = new ObservableCollection<AsarInfo>(asars);
    }
    private string GetQueryUrl()
    {
      string queryUrl = "Asar?name=";
      switch (_selectedOption)
      {
        case AsarSearchOptions.SearchByAsar:
          queryUrl = "Asar?name=";
          return queryUrl;
        case AsarSearchOptions.SearchByUpojela:
          queryUrl = "Upojela?upojela=";
          return queryUrl;
        case AsarSearchOptions.SearchByJela:
          queryUrl = "Jela?jela=";
          return queryUrl;
      }
      return queryUrl;
    }
  }
}
