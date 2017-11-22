using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhelagharMobileApps.Core.Models
{
  public class UpojelaInfo
  {
    #region Primitive Properties
    public int AreaId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string District { get; set; }
    public string Division { get; set; }
    public string AreaType { get; set; }
    public string Area
    {
      get
      {
        if(AreaType == "SubDistrict")
        {
          return Name + " -> " + District + " -> " + Division;
        }
        else
        {
          return Name + " -> " + Division;
        }
      }
    }
    #endregion
  }
}
