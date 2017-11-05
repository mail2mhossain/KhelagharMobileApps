using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KhelagharMobileApps.Core.Services
{
  public class GeoLocationUpdateService
  {
    private bool _isSuccess = false;

    public bool IsSuccess
    {
      get { return _isSuccess; }
    }
    public async Task UpdateGeoLocation(int asarId, decimal latitude, decimal longitude)
    {
      HttpClientHandler httpClientHandler = new HttpClientHandler();
      httpClientHandler.AllowAutoRedirect = false;
      using (var httpClient = new HttpClient(httpClientHandler))
      {
        string emptyContent = String.Empty;
        string responseString = null;
        try
        {
          string uri = ApiUrl.BaseUrl + "UpdateGeoLocation?asarId="+asarId +"&latitude="+latitude +"&longitude="+longitude;
          Task<HttpResponseMessage> getResponse = httpClient.PostAsync(uri, new StringContent(emptyContent));
          HttpResponseMessage response = await getResponse;
          if ((int)response.StatusCode == 404 || (int)response.StatusCode == 500)
          {
            throw new HttpRequestException();
          }
          if ((int)response.StatusCode == 200 || (int)response.StatusCode == 302 || (int)response.StatusCode == 201)
          {
            responseString = await response.Content.ReadAsStringAsync();
            _isSuccess = responseString.Contains("Success") ? true : false;
            
          }
        }
        catch (TaskCanceledException ex)
        {

        }
      }
    }
  }
}
