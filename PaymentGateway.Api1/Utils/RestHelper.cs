using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Api.Utils
{
    internal static class RestHelper
    {

        public static async Task<string> Post(string request, string postData)
        {
            var req = CreatePostRequest(request, postData);
            return await PostInternal(req);

        }

        private static async Task<string> PostInternal(HttpWebRequest req)
        {
            var httpWebResponse = await req.GetResponseAsync();
            using (var reader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                return reader.ReadLine();
            }
        }

        private static HttpWebRequest CreatePostRequest(string request, string postData)
        {
            var req = (HttpWebRequest)WebRequest.Create(request);
            req.Method = WebRequestMethods.Http.Post;
            req.ContentType = Constants.Http.Header.ContentTypeJson;
            req.Accept = Constants.Http.Header.AcceptJson;
            var encoding = Encoding.UTF8;
            var _byte = encoding.GetBytes(postData);
            req.ContentLength = _byte.Length;
            req.AutomaticDecompression = DecompressionMethods.GZip;
            req.ServicePoint.Expect100Continue = false; //http://haacked.com/archive/2004/05/15/http-web-request-expect-100-continue.aspx
            using (var st = req.GetRequestStream())
            {
                st.Write(_byte, 0, _byte.Length);
            }
            return req;
        }
    }
}
