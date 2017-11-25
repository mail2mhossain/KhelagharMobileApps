using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KhelagharMobileApps.Core.Models;

namespace KhelagharMobileApps.Core.Services
{
  public class KgApiService : BaseProvider, IKgApiService
  {
    public KgApiService()
    {
    }
    public async Task<List<AsarDetailInfo>> GetAsarDetailInfo(string queryUrl)
    {
      return await Get<List<AsarDetailInfo>>(queryUrl);
    }
    public async Task<List<AsarInfo>> GetAsarInfo(string queryUrl)
    {
      return await Get<List<AsarInfo>>(queryUrl);
    }
    public async Task<List<UpojelaInfo>> GetSubdistricts(string queryUrl)
    {
      return await Get<List<UpojelaInfo>>(queryUrl);
    }
    public async Task<List<WorkerInfo>> GetCommitteeMembers(string queryUrl)
    {
      return await Get<List<WorkerInfo>>(queryUrl);
    }
    public async Task<bool> IsLoggedIn(string loginUrl)
    {
      return await GetLogin(loginUrl);
    }
  }
}
