using KonchuSugoizeNotifyLambda.Resources;
using KonchuSugoizeNotifyLambda.Resources.Nhk;
using System.Diagnostics;
using System.Text.Json;

namespace KonchuSugoizeNotifyLambda.Models
{
    public class NotifyLogic
    {
        private const string KonchuSugoize = "昆虫すごいぜ";
        private const string KonchuSugoiZ = "昆虫すごいＺ";
        private const string tweetBodyFormat = "{0:title}\n{1:service}　{2:yyyy/M/d} {3:HH:mm}～{4:HH:mm}\n{5:subtitle}";
        private Config config;

        /// <summary>
        /// APIコールのインターバル[ms]
        /// </summary>
        public const int APICallInterval = 2000;

        public void NotifyOfFreeTV()
        {
            Debug.WriteLine("NotifyOfFreeTV");
            this.ProcessToNotify(NhkService.GetFreeTvNhkService());
        }

        public void NotifyOfPremiumTV()
        {
            Debug.WriteLine("NotifyOfPremiumTV");
            this.ProcessToNotify(NhkService.GetPremiumTvNhkService());
        }

        public void NotifyOfRadio()
        {
            Debug.WriteLine("NotifyOfRadio");
            this.ProcessToNotify(NhkService.GetRadioNhkService());
        }

        private void Init()
        {
            this.config = Config.ReadConfig();
        }

        private void ProcessToNotify(List<NhkService> nhkServiceList)
        {
            this.Init();

            List<DateTime> dates = new List<DateTime>();
            for (int offset = 0; offset < 5; offset++) dates.Add(DateTime.Today.AddDays(offset));
            List<NhkArea> nhkAreas = new List<NhkArea> { NhkArea.Tokyo };
            NhkProgramObject programList = NhkApiCaller.GetNhkPrograms(nhkServiceList, dates, nhkAreas, config.NhkApiConfig.ApiKey);
            Debug.WriteLine("★★programList=" + JsonSerializer.Serialize(programList));

            NhkProgramObject filteredProgramList = this.FilterByKonchuSugoize(programList);

            NhkProgramObject summarizedProgramList = this.SummarizeProgram(filteredProgramList);
            Debug.WriteLine("★summarizedProgramList=" + JsonSerializer.Serialize(summarizedProgramList));

            TwitterCaller twitterCaller = new TwitterCaller(this.config.TwitterConfig);
            twitterCaller.PostTweet(this.GenerateTweetBody(summarizedProgramList));
        }

        private NhkProgramObject? FilterByKonchuSugoize(NhkProgramObject programList)
        {
            if (programList == null || programList.List == null) return programList;

            programList.List.G1 = this.FilterByKonchuSugoize(programList.List.G1);
            programList.List.E1 = this.FilterByKonchuSugoize(programList.List.E1);
            programList.List.E4 = this.FilterByKonchuSugoize(programList.List.E4);
            programList.List.S1 = this.FilterByKonchuSugoize(programList.List.S1);
            programList.List.S3 = this.FilterByKonchuSugoize(programList.List.S3);
            programList.List.R1 = this.FilterByKonchuSugoize(programList.List.R1);
            programList.List.R2 = this.FilterByKonchuSugoize(programList.List.R2);
            programList.List.R3 = this.FilterByKonchuSugoize(programList.List.R3);

            return programList;
        }

        private List<NhkProgram> FilterByKonchuSugoize(List<NhkProgram> programList)
        {
            if (programList == null) return programList;
            programList.RemoveAll(p => !(p.Title.Contains(KonchuSugoize) || p.Title.Contains(KonchuSugoiZ)));
            return programList;
        }

        private NhkProgramObject SummarizeProgram(NhkProgramObject programList)
        {
            if (programList == null || programList.List == null)
            {
                throw new ArgumentNullException(nameof(programList));
            }

            NhkProgramObject result = NhkProgramObject.InitInstance();
            result.List.G1 = this.SummarizeProgram(programList.List.G1, result.List.G1);
            result.List.E1 = this.SummarizeProgram(programList.List.E1, result.List.E1);
            result.List.E4 = this.SummarizeProgram(programList.List.E4, result.List.E4);
            result.List.S1 = this.SummarizeProgram(programList.List.S1, result.List.S1);
            result.List.S3 = this.SummarizeProgram(programList.List.S3, result.List.S3);
            result.List.R1 = this.SummarizeProgram(programList.List.R1, result.List.R1);
            result.List.R2 = this.SummarizeProgram(programList.List.R2, result.List.R2);
            result.List.R3 = this.SummarizeProgram(programList.List.R3, result.List.R3);
            return result;
        }

        private List<NhkProgram>? SummarizeProgram(List<NhkProgram>? programList, List<NhkProgram>? result)
        {
            if (programList == null) return null;
            programList.ForEach(p =>
            {
                NhkProgram? sameProgram = result.Find(r => (r.Id == p.Id));
                if (sameProgram == null)
                {
                    sameProgram = p.CopyForInternalLogic();
                    result.Add(sameProgram);
                }
                else
                {
                    sameProgram.Areas.Add(p.Area);
                }
            });
            return result;
        }

        private List<string> GenerateTweetBody(NhkProgramObject nhkPrograms)
        {
            List<string> ret = new List<string>();
            ret.AddRange(this.generateTweetBody(nhkPrograms.List.G1));
            ret.AddRange(this.generateTweetBody(nhkPrograms.List.E1));
            ret.AddRange(this.generateTweetBody(nhkPrograms.List.E4));
            ret.AddRange(this.generateTweetBody(nhkPrograms.List.S1));
            ret.AddRange(this.generateTweetBody(nhkPrograms.List.S3));
            ret.AddRange(this.generateTweetBody(nhkPrograms.List.R1));
            ret.AddRange(this.generateTweetBody(nhkPrograms.List.R2));
            ret.AddRange(this.generateTweetBody(nhkPrograms.List.R3));
            return ret;
        }

        private List<string> generateTweetBody(List<NhkProgram> nhkPrograms)
        {
            List<string> ret = new List<string>();
            if (nhkPrograms != null && nhkPrograms.Count > 0)
            {
                nhkPrograms.ForEach(p => ret.Add(this.GenerateTweetBody(p)));
            }
            return ret;
        }

        private string GenerateTweetBody(NhkProgram nhkProgram)
        {
            const int maxLength = 140;
            DateTime start = DateTime.Parse(nhkProgram.StartTime);
            DateTime end = DateTime.Parse(nhkProgram.EndTime);
            string tweetBody = String.Format(
                tweetBodyFormat,
                nhkProgram.Title,
                nhkProgram.Service.Name,
                start,
                start,
                end,
                nhkProgram.SubTitle);
            if (tweetBody.Length > maxLength)
            {
                tweetBody.Substring(0, maxLength);
            }
            return tweetBody;
        }
    }
}
