using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonchuSugoizeNotifyLambda.Resources.Nhk
{
    public class NhkArea
    {
        public string Id { get; set; }
        public string Name { get; set; }

        private NhkArea(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public static NhkArea Sapporo = new NhkArea("010", "札幌");
        public static NhkArea Hakodate = new NhkArea("011", "函館");
        public static NhkArea Asahikawa = new NhkArea("012", "旭川");
        public static NhkArea Obihiro = new NhkArea("013", "帯広");
        public static NhkArea Kushiro = new NhkArea("014", "釧路");
        public static NhkArea Kitami = new NhkArea("015", "北見");
        public static NhkArea Muroran = new NhkArea("016", "室蘭");
        public static NhkArea Aomori = new NhkArea("020", "青森");

        public static NhkArea Morioka = new NhkArea("030", "盛岡");
        public static NhkArea Sendai = new NhkArea("040", "仙台");
        public static NhkArea Akita = new NhkArea("050", "秋田");
        public static NhkArea Yamagata = new NhkArea("060", "山形");
        public static NhkArea Fukushima = new NhkArea("070", "福島");
        public static NhkArea Mito = new NhkArea("080", "水戸");
        public static NhkArea Utsunomiya = new NhkArea("090", "宇都宮");
        public static NhkArea Maebashi = new NhkArea("100", "前橋");

        public static NhkArea Saitama = new NhkArea("110", "さいたま");
        public static NhkArea Chiba = new NhkArea("120", "千葉");
        public static NhkArea Tokyo = new NhkArea("130", "東京");
        public static NhkArea Yokohama = new NhkArea("140", "横浜");
        public static NhkArea Niigata = new NhkArea("150", "新潟");
        public static NhkArea Toyama = new NhkArea("160", "富山");
        public static NhkArea Kanazawa = new NhkArea("170", "金沢");
        public static NhkArea Fukui = new NhkArea("180", "福井");

        public static NhkArea Kofu = new NhkArea("190", "甲府");
        public static NhkArea Nagano = new NhkArea("200", "長野");
        public static NhkArea Gifu = new NhkArea("210", "岐阜");
        public static NhkArea Shizuoka = new NhkArea("220", "静岡");
        public static NhkArea Nagoya = new NhkArea("230", "名古屋");
        public static NhkArea Tsu = new NhkArea("240", "津");
        public static NhkArea Otsu = new NhkArea("250", "大津");
        public static NhkArea Kyoto = new NhkArea("260", "京都");

        public static NhkArea Osaka = new NhkArea("270", "大阪");
        public static NhkArea Kobe = new NhkArea("280", "神戸");
        public static NhkArea Nara = new NhkArea("290", "奈良");
        public static NhkArea Wakayama = new NhkArea("300", "和歌山");
        public static NhkArea Tottori = new NhkArea("310", "鳥取");
        public static NhkArea Matsue = new NhkArea("320", "松江");
        public static NhkArea Okayama = new NhkArea("330", "岡山");
        public static NhkArea Hiroshima = new NhkArea("340", "広島");

        public static NhkArea Yamaguchi = new NhkArea("350", "山口");
        public static NhkArea Tokushima = new NhkArea("360", "徳島");
        public static NhkArea Takamatsu = new NhkArea("370", "高松");
        public static NhkArea Matsuyama = new NhkArea("380", "松山");
        public static NhkArea Kochi = new NhkArea("390", "高知");
        public static NhkArea Fukuoka = new NhkArea("400", "福岡");
        public static NhkArea Kitakyushu = new NhkArea("401", "北九州");
        public static NhkArea Saga = new NhkArea("410", "佐賀");

        public static NhkArea Nagasaki = new NhkArea("420", "長崎");
        public static NhkArea Kumamoto = new NhkArea("430", "熊本");
        public static NhkArea Oita = new NhkArea("440", "大分");
        public static NhkArea Miyazaki = new NhkArea("450", "宮崎");
        public static NhkArea Kagoshima = new NhkArea("460", "鹿児島");
        public static NhkArea Okinawa = new NhkArea("470", "沖縄");

        public static List<NhkArea> GetAllNhkAreas()
        {
            return new List<NhkArea>
            {
                Sapporo, Hakodate, Asahikawa, Obihiro, Kushiro, Kitami, Muroran, Aomori,
                Morioka, Sendai, Akita, Yamagata, Fukushima, Mito, Utsunomiya, Maebashi,
                Saitama, Chiba, Tokyo, Yokohama, Niigata, Toyama, Kanazawa, Fukui,
                Kofu, Nagano, Gifu, Shizuoka, Nagoya, Tsu, Otsu, Kyoto,
                Osaka, Kobe, Nara, Wakayama, Tottori, Matsue, Okayama, Hiroshima,
                Yamaguchi, Tokushima, Takamatsu, Matsuyama, Kochi, Fukuoka, Kitakyushu, Saga,
                Nagasaki, Kumamoto, Oita, Miyazaki, Kagoshima, Okinawa
            };
        }

        public static List<NhkArea> GetMainNhkAreas()
        {
            return new List<NhkArea>
            {
                Sapporo, Sendai, Tokyo, Kanazawa, Nagoya, Osaka, Hiroshima, Fukuoka, Okinawa
            };
        }
    }
}
