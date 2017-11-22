﻿using KhelagharMobileApps.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhelagharMobileApps.Core.Services
{
  public interface IKgApiService
  {
    Task<List<AsarInfo>> GetAsars(string queryUrl);
    Task<List<UpojelaInfo>> GetSubdistricts(string queryUrl);
    Task<bool> IsLoggedIn(string queryUrl);
  }
}
