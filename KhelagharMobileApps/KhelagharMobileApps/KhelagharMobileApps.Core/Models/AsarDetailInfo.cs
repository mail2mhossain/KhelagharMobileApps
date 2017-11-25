using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhelagharMobileApps.Core.Models
{
  public class AsarDetailInfo : AsarInfo
  {
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
        string address = String.IsNullOrEmpty(AddressLine) ? Subdistrict : AddressLine + Environment.NewLine + Subdistrict;
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
        if (CommitteeType == TypeOfCommittee.আহ্বায়ক.ToString()) return "মোবাইল নং - " + PresidentMobileNo;
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
        if (CommitteeType == TypeOfCommittee.আহ্বায়ক.ToString()) return "আহ্বায়ক - " + President;
        return "সাধারণ সম্পাদক - " + Secretary;
      }
    }
    public bool HasMobileNo
    {
      get
      {
        if (CommitteeType == TypeOfCommittee.আহ্বায়ক.ToString())
        {
          if (this.PresidentMobileNo != null)
            return true;
        }
        else
        {
          if (this.SecretaryMobileNo != null)
            return true;
        }
        return false;
      }
    }
  }
}
