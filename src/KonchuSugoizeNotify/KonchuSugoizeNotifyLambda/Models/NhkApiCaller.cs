using KonchuSugoizeNotifyLambda.Resources.Nhk;
using System.Diagnostics;
using System.Text.Json;

namespace KonchuSugoizeNotifyLambda.Models
{
    public class NhkApiCaller
    {
        public static NhkProgramObject? GetNhkPrograms(List<NhkService> nhkServices, List<DateTime> dates, List<NhkArea> nhkAreas, string apikey)
        {
            List<NhkProgramObject> programs = new List<NhkProgramObject>();
            nhkServices.ForEach(nhkService =>
            {
                NhkProgramObject programResult = new NhkProgramObject();
                dates.ForEach(date =>
                {
                    NhkProgramObject programResult = new NhkProgramObject();
                    nhkAreas.ForEach(nhkArea =>
                    {
                        NhkProgramObject? program = (NhkProgramObject?)NhkProgramClient.Get(nhkArea, nhkService, NhkProgramClient.GenreId, date, apikey);

                        Thread.Sleep(NotifyLogic.APICallInterval);
                        // Task.Delay(NotifyLogic.APICallInterval);

                        Debug.WriteLine("★" + JsonSerializer.Serialize(program));
                        if (program != null) programs.Add(program);
                    });
                });
            });

            return NhkProgramObject.Merge(programs);
        }
    }
}
