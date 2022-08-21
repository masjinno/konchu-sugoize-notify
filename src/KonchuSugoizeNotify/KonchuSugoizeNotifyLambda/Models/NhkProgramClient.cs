using KonchuSugoizeNotifyLambda.Resources.Nhk;
using System.Diagnostics;
using System.Net;
using System.Text.Json;

namespace KonchuSugoizeNotifyLambda.Models
{
    public class NhkProgramClient
    {
        // APIパス
        private const string ProgramListPath = "https://api.nhk.or.jp/v2/pg/list/{0:area}/{1:service}/{2:yyyy-MM-dd}.json?key={apikey}";
        private const string ProgramGenrePath = "https://api.nhk.or.jp/v2/pg/genre/{0:area}/{1:service}/{2:genre}/{3:yyyy-MM-dd}.json?key={4:apikey}";
        private const string ProgramInfoPath = "https://api.nhk.or.jp/v2/pg/info/{0:area}/{1:service}/{2:programId}.json?key={3:apikey}";

        // 昆虫すごいぜがヒットするジャンルコード。以下の3つが該当するが、「自然・動物・環境」で検索することとする。
        // 0802:自然・動物・環境
        // 1008:幼児・小学生
        // 1009:中学生・高校生
        // 参考: https://stabucky.com/wp/archives/6118
        public const string GenreId = "0802";

        // BadGatewayのときのリトライ数
        public const int TotalRetryCount = 3;

        private static readonly HttpClient client = new HttpClient();

        public static object? Get(NhkArea area, NhkService service, string genre, DateTime date, string apikey)
        {
            return Get(area, service, genre, date, apikey, TotalRetryCount);
        }

        private static object? Get(NhkArea area, NhkService service, string genre, DateTime date, string apikey, int retryCount)
        {
            string path = String.Format(ProgramGenrePath, area.Id, service.Id, genre, date, apikey);
            Debug.WriteLine("path=" + path);
            HttpResponseMessage resp = client.GetAsync(path).Result;
            string respBody = resp.Content.ReadAsStringAsync().Result;
            Debug.WriteLine("status=" + resp.StatusCode);
            if (resp.StatusCode == HttpStatusCode.OK)
            {
                return JsonSerializer.Deserialize<NhkProgramObject>(respBody);
            }
            else if (resp.StatusCode == HttpStatusCode.TooManyRequests)
            {
                throw new HttpRequestException("Too many requests. " + path, null, resp.StatusCode);
            }
            else if (resp.StatusCode == HttpStatusCode.BadGateway)
            {
                if (retryCount > 0)
                {
                    return Get(area, service, genre, date, apikey, retryCount - 1);
                }
                else
                {
                    throw new HttpRequestException("BadGateway", null, resp.StatusCode);
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
