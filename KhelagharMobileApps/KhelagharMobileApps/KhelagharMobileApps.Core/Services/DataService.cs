using KhelagharMobileApps.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KhelagharMobileApps.Core.Services
{
  public class DataService
  {
    public static List<MenuItem> GetMenuList()
    {
      var menuList = new List<MenuItem>();
      menuList.Add(new MenuItem() { Title = "Committee Members", Description = "Committee Members List View", Url = "NavigationPage/MainPage/WorkersPage", IslogOut = false });
      menuList.Add(new MenuItem() { Title = "New Asar", Description = "New Asar Entry View", Url = "NavigationPage/MainPage/NewAsar", IslogOut = false });
      menuList.Add(new MenuItem() { Title = "Asar Search", Description = "Asar Search View", Url = "NavigationPage/MainPage",IslogOut=false });
      menuList.Add(new MenuItem() { Title = "Logout", Description = "Logout Action", Url = "/Login", IslogOut = true });
      return menuList;
    }
  }
}
