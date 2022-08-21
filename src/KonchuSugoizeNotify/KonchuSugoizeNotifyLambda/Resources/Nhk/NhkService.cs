using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonchuSugoizeNotifyLambda.Resources.Nhk
{
    public class NhkService
    {
        public string Id { get; set; }
        public string Name { get; set; }

        private NhkService(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public const string G1_ID = "g1";
        public const string E1_ID = "e1";
        public const string E4_ID = "e4";
        public const string S1_ID = "s1";
        public const string S3_ID = "s3";
        public const string R1_ID = "r1";
        public const string R2_ID = "r2";
        public const string R3_ID = "r3";

        public static NhkService G1 = new NhkService(G1_ID, "ＮＨＫ総合１");
        public static NhkService E1 = new NhkService(E1_ID, "ＮＨＫＥテレ１");
        public static NhkService E4 = new NhkService(E4_ID, "ＮＨＫワンセグ２");
        public static NhkService S1 = new NhkService(S1_ID, "ＮＨＫＢＳ１");
        public static NhkService S3 = new NhkService(S3_ID, "ＮＨＫＢＳプレミアム");
        public static NhkService R1 = new NhkService(R1_ID, "ＮＨＫラジオ第1");
        public static NhkService R2 = new NhkService(R2_ID, "ＮＨＫラジオ第2");
        public static NhkService R3 = new NhkService(R3_ID, "ＮＨＫＦＭ");

        public static List<NhkService> GetAllNhkServices()
        {
            return new List<NhkService> { G1, E1, E4, S1, S3, R1, R2, R3 };
        }

        public static List<NhkService> GetFreeTvNhkService()
        {
            return new List<NhkService> { G1, E1, E4 };
        }

        public static List<NhkService> GetPremiumTvNhkService()
        {
            return new List<NhkService> { S1, S3 };
        }

        public static List<NhkService> GetRadioNhkService()
        {
            return new List<NhkService> { R1, R2, R3 };
        }
    }
}
