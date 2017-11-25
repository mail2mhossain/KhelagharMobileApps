﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhelagharMobileApps.Core.Models
{
  public class AsarInfo
  {
    public int AsarId { get; set; }
    public string NameTosearch { get; set; }
    public string AsarName { get; set; }
    public string AsarType { get; set; }
    public string CommitteeType { get; set; }
    public string AsarStatus { get; set; }
    public string Contacts { get; set; }
    public string AddressLine { get; set; }
    public string Subdistrict { get; set; }
    public string District { get; set; }
    public string Division { get; set; }
    public string President { get; set; }
    public string PresidentMobileNo { get; set; }
    public string PresidentEmailAddress { get; set; }
    public string Secretary { get; set; }
    public string SecretaryMobileNo { get; set; }
    public string SecretaryEmailAddress { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
  }
}
