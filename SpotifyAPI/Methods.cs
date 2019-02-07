using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SpotifyAPI.Models;

namespace SpotifyAPI
{
    class Methods
    {
        //Task<Token> task = GetToken();
        private static readonly HttpClient client = new HttpClient();

        internal static string GetToken()
        {
            Token token = new Token();
            string url5 = "https://accounts.spotify.com/api/token";
            var clientid = "dc562108d7f446be8f2ab1e26a2e2642";
            var clientsecret = "5927676d8f7f47fcabf6efc6f983e33b";

            //request to get the access token
            var encode_clientid_clientsecret = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", clientid, clientsecret)));

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url5);

            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Accept = "application/json";
            webRequest.Headers.Add("Authorization: Basic " + encode_clientid_clientsecret);

            var request = ("grant_type=client_credentials");
            byte[] req_bytes = Encoding.ASCII.GetBytes(request);
            webRequest.ContentLength = req_bytes.Length;

            Stream strm = webRequest.GetRequestStream();
            strm.Write(req_bytes, 0, req_bytes.Length);
            strm.Close();

            HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
            String json = "";
            using (Stream respStr = resp.GetResponseStream())
            {
                using (StreamReader rdr = new StreamReader(respStr, Encoding.UTF8))
                {
                    //should get back a string i can then turn to json and parse for accesstoken
                    json = rdr.ReadToEnd();
                    rdr.Close();
                }
            }

            token = JsonConvert.DeserializeObject<Token>(json);
            return token.access_token;
        }

        //public static async Task<Token> GetToken()
        //{
        //    string clientId = "dc562108d7f446be8f2ab1e26a2e2642";
        //    string clientSecret = "5927676d8f7f47fcabf6efc6f983e33b";
        //    string credentials = String.Format("{0}:{1}", clientId, clientSecret);

        //    using (var client = new HttpClient())
        //    {
        //        //Define Headers
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials)));

        //        //Prepare Request Body
        //        List<KeyValuePair<string, string>> requestData = new List<KeyValuePair<string, string>>();
        //        requestData.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));

        //        FormUrlEncodedContent requestBody = new FormUrlEncodedContent(requestData);

        //        //Request Token
        //        var request = await client.PostAsync("https://accounts.spotify.com/api/token", requestBody);
        //        var response = await request.Content.ReadAsStringAsync();
        //        return JsonConvert.DeserializeObject<Token>(response);
        //    }
        //}
        //public static async Task<Token> GetToken()
        //{
        //    Console.WriteLine("Getting Token");
        //    string clientId = "dc562108d7f446be8f2ab1e26a2e2642";
        //    string clientSecret = "5927676d8f7f47fcabf6efc6f983e33b";
        //    string credentials = String.Format("{0}:{1}", clientId, clientSecret);

        //    using (var client = new HttpClient())
        //    {
        //        //Define Headers
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials)));

        //        //Prepare Request Body
        //        List<KeyValuePair<string, string>> requestData = new List<KeyValuePair<string, string>>();
        //        requestData.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));

        //        FormUrlEncodedContent requestBody = new FormUrlEncodedContent(requestData);

        //        //Request Token
        //        var request = await client.PostAsync("https://accounts.spotify.com/api/token", requestBody);
        //        var response = await request.Content.ReadAsStringAsync();
        //        return JsonConvert.DeserializeObject<Token>(response);
        //    }
        //}
        public string GetAccessToken()
        {
            Token token = new Token();
            string url5 = "https://accounts.spotify.com/api/token";
            var clientid = "dc562108d7f446be8f2ab1e26a2e2642";
            var clientsecret = "5927676d8f7f47fcabf6efc6f983e33b";

            //request to get the access token
            var encode_clientid_clientsecret = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", clientid, clientsecret)));

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url5);

            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Accept = "application/json";
            webRequest.Headers.Add("Authorization: Basic " + encode_clientid_clientsecret);

            var request = ("grant_type=client_credentials");
            byte[] req_bytes = Encoding.ASCII.GetBytes(request);
            webRequest.ContentLength = req_bytes.Length;

            Stream strm = webRequest.GetRequestStream();
            strm.Write(req_bytes, 0, req_bytes.Length);
            strm.Close();

            HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
            String json = "";
            using (Stream respStr = resp.GetResponseStream())
            {
                using (StreamReader rdr = new StreamReader(respStr, Encoding.UTF8))
                {
                    //should get back a string i can then turn to json and parse for accesstoken
                    json = rdr.ReadToEnd();
                    rdr.Close();
                }
            }
            return token.access_token;
        }

        public static async Task<string> AsyncPost(string url, Dictionary<string, string> values)
        {
            var content = new FormUrlEncodedContent(values);


            var response = await client.PostAsync(url, content);

            var responseString = await response.Content.ReadAsStringAsync();

            return responseString;
        }


        private static string HttpMethodWithAuthHeader(string url, string AuthCode, Method method, string body)
        {

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            httpWebRequest.Method = method.ToString();

            httpWebRequest.Headers.Add(HttpRequestHeader.Authorization + ": Bearer " + AuthCode);
            httpWebRequest.ContentType = "application/json";

            try
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(body);
                    streamWriter.Flush();
                    streamWriter.Close();

                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        return result;
                    }
                }
            }
            catch (WebException wex)
            {
                throw new Exception("");
            }
        }



        private static string HttpMethodWithAuthHeader(string url, string AuthCode, Method method)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            httpWebRequest.Method = method.ToString();

            httpWebRequest.Headers.Add(HttpRequestHeader.Authorization + ": Bearer " + AuthCode);
            httpWebRequest.ContentType = "application/json";

            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    return result;
                }
            }
            catch (WebException wex)
            {

                throw new ArgumentException();
            }
        }


        public static dynamic SendGetRequest(string endpointUrl)
        {
            string url = Constant.baseUrl + endpointUrl;
            var token = GetToken();
            var json = HttpMethodWithAuthHeader(url, token, Method.GET);

                return json;
        }


        public static dynamic SendPostRequest(string endpointUrl, string jsonData)
        {
            string url = Constant.baseUrl + endpointUrl;

            var json = HttpMethodWithAuthHeader(url, Constant.AuthCode, Method.POST, jsonData);

            return json;
        }


        public static dynamic SendPostRequest(string endpointUrl)
        {
            string url = Constant.baseUrl + endpointUrl;

            var json = HttpMethodWithAuthHeader(url, Constant.AuthCode, Method.POST);

            return json;
        }


        public static dynamic SendDeleteRequest(string endpointUrl, string body)
        {
            string url = Constant.baseUrl + endpointUrl;

            var json = HttpMethodWithAuthHeader(url, Constant.AuthCode, Method.DELETE, body);

            return json;
        }


        public static dynamic SendDeleteRequest(string endpointUrl)
        {
            string url = Constant.baseUrl + endpointUrl;

            var json = HttpMethodWithAuthHeader(url, Constant.AuthCode, Method.DELETE);

            return json;
        }

        private enum Method
        {
            POST = 0,
            GET = 1,
            DELETE = 2,
        }

    }
}
