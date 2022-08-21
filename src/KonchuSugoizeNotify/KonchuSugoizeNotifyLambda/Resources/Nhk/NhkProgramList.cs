using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KonchuSugoizeNotifyLambda.Resources.Nhk
{

    public class NhkProgramObject
    {
        [JsonPropertyName("list")]
        public NhkProgramList List { get; set; } = new NhkProgramList();

        public static NhkProgramObject InitInstance()
        {
            return new NhkProgramObject
            {
                List = new NhkProgramList
                {
                    G1 = new List<NhkProgram>(),
                    E1 = new List<NhkProgram>(),
                    E4 = new List<NhkProgram>(),
                    S1 = new List<NhkProgram>(),
                    S3 = new List<NhkProgram>(),
                    R1 = new List<NhkProgram>(),
                    R2 = new List<NhkProgram>(),
                    R3 = new List<NhkProgram>()
                }
            };
        }

        public void Merge(NhkProgramObject? anotherNhkProgramObject)
        {
            if (anotherNhkProgramObject == null) return;
            if (List == null) List = anotherNhkProgramObject.List;
            else List.Merge(anotherNhkProgramObject.List);
        }

        public static NhkProgramObject? Merge(List<NhkProgramObject> nhkProgramObjects)
        {
            if (nhkProgramObjects == null || nhkProgramObjects.Count == 0) return null;

            NhkProgramObject ret = new NhkProgramObject();
            nhkProgramObjects.ForEach(p =>
            {
                ret.Merge(p);
            });
            return ret;
        }
    }

    public class NhkProgramList
    {
        [JsonPropertyName(NhkService.G1_ID)]
        public List<NhkProgram>? G1 { get; set; }

        [JsonPropertyName(NhkService.E1_ID)]
        public List<NhkProgram>? E1 { get; set; }

        [JsonPropertyName(NhkService.E4_ID)]
        public List<NhkProgram>? E4 { get; set; }

        [JsonPropertyName(NhkService.S1_ID)]
        public List<NhkProgram>? S1 { get; set; }

        [JsonPropertyName(NhkService.S3_ID)]
        public List<NhkProgram>? S3 { get; set; }

        [JsonPropertyName(NhkService.R1_ID)]
        public List<NhkProgram>? R1 { get; set; }

        [JsonPropertyName(NhkService.R2_ID)]
        public List<NhkProgram>? R2 { get; set; }

        [JsonPropertyName(NhkService.R3_ID)]
        public List<NhkProgram>? R3 { get; set; }

        public void Merge(NhkProgramList anotherNhkProgramList)
        {
            if (anotherNhkProgramList == null) return;

            G1 = GenerateMergedNhkProgramList(G1, anotherNhkProgramList.G1);
            E1 = GenerateMergedNhkProgramList(E1, anotherNhkProgramList.E1);
            E4 = GenerateMergedNhkProgramList(E4, anotherNhkProgramList.E4);
            S1 = GenerateMergedNhkProgramList(S1, anotherNhkProgramList.S1);
            S3 = GenerateMergedNhkProgramList(S3, anotherNhkProgramList.S3);
            R1 = GenerateMergedNhkProgramList(R1, anotherNhkProgramList.R1);
            R2 = GenerateMergedNhkProgramList(R2, anotherNhkProgramList.R2);
            R3 = GenerateMergedNhkProgramList(R3, anotherNhkProgramList.R3);
        }

        private List<NhkProgram>? GenerateMergedNhkProgramList(List<NhkProgram>? target, List<NhkProgram>? anotherValue)
        {
            if (target == null)
            {
                return anotherValue;
            }
            else if (anotherValue != null)
            {
                target.AddRange(anotherValue);
            }
            return target;
        }
    }
}
