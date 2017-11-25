using KhelagharMobileApps.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhelagharMobileApps.Core.Services
{
  public interface IKgApiService
  {
    Task<List<AsarDetailInfo>> GetAsarDetailInfo(string queryUrl);
    Task<List<AsarInfo>> GetAsarInfo(string queryUrl);
    Task<List<UpojelaInfo>> GetSubdistricts(string queryUrl);
    Task<List<WorkerInfo>> GetCommitteeMembers(string queryUrl);
    Task<bool> IsLoggedIn(string queryUrl);
  }
}
