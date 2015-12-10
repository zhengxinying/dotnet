using System.Collections.Generic;
using Chief.InOut;
using Chief.Base;

namespace Chief
{
    public class Init
    {
        public static void InitBaseData()
        {
            KongFu();
            Member();

            Constant.MySecret = new Secret() { HealthAdd = 6, AttackAdd = 3, DefenceAdd = 2, MagicAdd = 8 };
        }

        private static void Member()
        {
            Constant.Members = new List<Member>();

            var file = System.Environment.CurrentDirectory + @"\Chief.txt";
            var reader = new Reader();
            var input = reader.ReadText(file);

            foreach (var i in input)
            {
                var member = new Member();
                member.ToMember(i);

                if (member.Name == "韦小宝")
                {
                    member.BornKongFu = Constant.KongFus.Find(f => f.Name == "金钟罩");
                }
                else if (member.Name == "觉远")
                {
                    member.BornKongFu = Constant.KongFus.Find(f => f.Name == "金钟罩");
                }
                else if (member.Name == "阿飞")
                {
                    member.BornKongFu = Constant.KongFus.Find(f => f.Name == "降龙伏虎功");
                }
                else if (member.Name == "上官金虹")
                {
                    member.BornKongFu = Constant.KongFus.Find(f => f.Name == "金钟罩");
                }
                else if (member.Name == "小龙女")
                {
                    member.BornKongFu = Constant.KongFus.Find(f => f.Name == "长生功");
                }

                Constant.Members.Add(member);
            }
        }

        private static void KongFu()
        {
            Constant.KongFus = new List<KongFu>();

            var kf = new KongFu() { Category = 3, Name = "金钟罩", DefenceAdd = 0.1f, Level = 1, Rank = 2, CategoryAdd = 1 };
            Constant.KongFus.Add(kf);

            kf = new KongFu() { Category = 3, Name = "小无相功", DefenceAdd = 0.15f, Level = 1, Rank = 1, CategoryAdd = 2 };
            Constant.KongFus.Add(kf);

            kf = new KongFu() { Category = 3, Name = "玉女心经", DefenceAdd = 0.07f, Level = 1, Rank = 1, CategoryAdd = 3 };
            Constant.KongFus.Add(kf);

            kf = new KongFu() { Category = 2, Name = "降龙伏虎功", AttackAdd = 0.04f, Level = 1, Rank = 3, CategoryAdd = 1 };
            Constant.KongFus.Add(kf);

            kf = new KongFu() { Category = 2, Name = "明玉功", AttackAdd = 0.04f, Level = 1, Rank = 1, CategoryAdd = 2 };
            Constant.KongFus.Add(kf);
            
            kf = new KongFu() { Category = 4, Name = "长生功", MagicAdd = 0.03f, Level = 1, Rank = 2, CategoryAdd = 1 };
            Constant.KongFus.Add(kf);
        }
    }
}
