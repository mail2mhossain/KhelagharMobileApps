using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KhelagharMobileApps.Core.Services
{
  public class LoginService
  {
    private bool isSuccess = false;
    public bool Login(string username, string password)
    {
      HttpClient client = new HttpClient();
      isSuccess = false;
      try
      {
        string LoginUrl = ApiUrl.BaseUrl + "Login?username=" + username + "&password=" + password;
        Task<HttpResponseMessage> getResponse = client.GetAsync(LoginUrl);
        HttpResponseMessage response = getResponse.Result;

        if (response != null)
        {
          if ((int)response.StatusCode == 200)
          {
            isSuccess = true;
          }
        }
        //Task.Run(() => LoadDataAsync(LoginUrl, username, password)).Wait();
      }
      catch (Exception ex)
      {
        isSuccess = false;
      }
      return isSuccess;
    }
    
    private void LoadDataAsync(string uri, string authenticationUserName, string authenticationUserPassword)
    {
      if (!isSuccess)
      {
        HttpClientHandler httpClientHandler = new HttpClientHandler();
        httpClientHandler.AllowAutoRedirect = false;

        using (var httpClient = new HttpClient(httpClientHandler))
        {
          var credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", authenticationUserName, authenticationUserPassword)));
          try
          {
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", credentials);
            httpClient.Timeout = new TimeSpan(0, 0, 10);
            Task<HttpResponseMessage> getResponse = httpClient.GetAsync(uri);
            HttpResponseMessage response = getResponse.Result;
            if ((int)response.StatusCode == 404)
            {
              isSuccess = false;
            }
            else if ((int)response.StatusCode == 500)
            {
              isSuccess = false;
            }
            else if ((int)response.StatusCode == 200)
            {
              isSuccess = true;
            }
            else
            {
              isSuccess = false;
            }
          }
          catch (TimeoutException ex)
          {

          }
          catch (TaskCanceledException ex)
          {
            throw ex;// DisplayAlert("Alert", "You have been alerted", "OK");
          }
        }
      }
    }
  }
}
