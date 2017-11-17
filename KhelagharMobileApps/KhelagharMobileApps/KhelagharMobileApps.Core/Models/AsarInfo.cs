using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhelagharMobileApps.Core.Models
{
  public class AsarInfo
  {
    public int AsarId { get; set; }
    public string AsarName { get; set; }
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
    
    public string GeoLocation
    {
      get
      {
        return "Latitude - " + Latitude + ", Longitude - " + Longitude;
      }
    }
    public bool HasGeoLocation
    {
      get
      {
        if (Latitude == 0 && Longitude == 0)
          return false;
        return true;
      }
    }
    public string ContactDetails
    {
      get
      {
        if (Contacts != null)
        {
          string contactDetails = "যোগাযোগ - " + Contacts.Replace("\r\n", " ");
          return contactDetails;
        }
        else
        {
          return "যোগাযোগ - ";
        }
      }
    }
    public string Address
    {
      get
      {
        string address = String.IsNullOrEmpty(AddressLine) ? Subdistrict : AddressLine +  Environment.NewLine + Subdistrict;
        if (District != null)
        {
          address = address + ", জেলা-" + District;
          address = address + ", বিভাগ-" + Division;
        }
        else
        {
          address = address + ", বিভাগ-" + Division;
        }
        return address;
      }
    }
    public string AddressForDetailView
    {
      get
      {
        string address = String.IsNullOrEmpty(AddressLine) ? Subdistrict : AddressLine + ", " + Subdistrict;
        if (District != null)
        {
          address = address + ", জেলা-" + District;
          address = address + ", বিভাগ-" + Division;
        }
        else
        {
          address = address + ", বিভাগ-" + Division;
        }
        return "ঠিকানা - " + address;
      }
    }
    public string DisplayCommitteeType
    {
      get
      {
        return "কমিটির ধরণ - " + CommitteeType;
      }
    }
    public string DisplayAsarStatus
    {
      get
      {
        return "আসরের অবস্থা - " + AsarStatus;
      }
    }
    public string SecretaryMobile
    {
      get
      {
        return "মোবাইল নং - " + SecretaryMobileNo;
      }
    }
    public enum TypeOfCommittee
    {
      পূর্ণাঙ্গ = 1,
      আহ্বায়ক = 2,
      কমিটিবিহীন = 3
    }
    public string SecretaryName
    {
      get
      {
        if(CommitteeType == TypeOfCommittee.আহ্বায়ক.ToString()) return "আহ্বায়ক - " + Secretary;
        return "সাধারণ সম্পাদক - " + Secretary ;
      }
    }
    public bool HasMobileNo
    {
      get
      {
        if (this.SecretaryMobileNo != null)
          return true;
        return false;
      }
    }
  }
}
