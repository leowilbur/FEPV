using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HttpUtils
{


    public enum HttpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }
    public class RestClient
    {
        public string EndPoint { get; set; }
        public HttpVerb Method { get; set; }
        public string ContentType { get; set; }
        public string PostData { get; set; }

        public RestClient()
        {
            EndPoint = "";
            Method = HttpVerb.GET;
            ContentType = "application/json";
            PostData = "";
        }
        public RestClient(string endpoint)
        {
            EndPoint = endpoint;
            Method = HttpVerb.GET;
            ContentType = "text/xml";
            PostData = "";
        }
        public RestClient(string endpoint, HttpVerb method)
        {
            EndPoint = endpoint;
            Method = method;
            ContentType = "application/json";
            PostData = "";
        }

        public RestClient(string endpoint, HttpVerb method, string postData)
        {
            EndPoint = endpoint;
            Method = method;
            ContentType = "application/json";
            PostData = postData;
        }


        public string MakeRequest()
        {
            return MakeRequest("");
        }

        public string MakeRequest(string parameters)
        {
            var request = (HttpWebRequest)WebRequest.Create(EndPoint + parameters);

            request.Method = Method.ToString();
            request.ContentLength = 0;
            request.ContentType = ContentType;
            Console.WriteLine("MakeRequest:");
            if (!string.IsNullOrEmpty(PostData) && Method == HttpVerb.POST)
            {
                var encoding = new UTF8Encoding();
                var bytes = Encoding.GetEncoding("utf-8").GetBytes(PostData);
                request.ContentLength = bytes.Length;

                using (var writeStream = request.GetRequestStream())
                {
                    writeStream.Write(bytes, 0, bytes.Length);
                }
                Console.WriteLine("MakeRequest writeStream");
            }

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var responseValue = string.Empty;
                Console.WriteLine("StatusCode:"+response.StatusCode.ToString().ToUpper());
                if (response.StatusCode.ToString().ToUpper() == "NOCONTENT")
                {
                    return "204";
                }
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    var message = String.Format("Request failed. Received HTTP {0}", response.StatusCode);
                    throw new ApplicationException(message);
                }

                // grab the response
                using (var responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                        using (var reader = new StreamReader(responseStream))
                        {
                            responseValue = reader.ReadToEnd();
                        }
                }

                return responseValue;
            }
        }


        public string ConvertFormData(Dictionary<string, object> formdate, string businessKey)
        {
           
            Dictionary<string, Object> dictionary = new Dictionary<string, Object>();
            Dictionary<string, object> rrr = new Dictionary<string, object>(); ;
            foreach (var varitem in formdate)
            {
                FormDatas data = new FormDatas();
                data.value = varitem.Value.ToString();
                data.type = "String";
                rrr.Add(varitem.Key, data);

            }
            dictionary.Add("variables", rrr);
            if (!string.IsNullOrEmpty(businessKey))
            {
                dictionary.Add("businessKey", businessKey);
            }
            string json = JsonConvert.SerializeObject(dictionary);
            Console.WriteLine(json);
            return json;
        }

    } // 

    public class FormDatas
    {
        public string value { set; get; }

        public string type { set; get; }

    }

}
