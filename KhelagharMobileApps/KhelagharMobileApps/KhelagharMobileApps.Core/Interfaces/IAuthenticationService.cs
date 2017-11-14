using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhelagharMobileApps.Core.Interfaces
{
  public interface IAuthenticationService
  {
    bool Login(string username, string password);

    void Logout();
  }
}
