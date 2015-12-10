using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chief.Base;

namespace Chief
{
    public class Member : Data, IComparable
    {
        /// <summary>
        /// 排序类型
        /// </summary>
        public string SortType { get; set; }

        // 天赋武功
        public KongFu BornKongFu;

        public int CompareTo(object obj)
        {
            var other = obj as Member;

            if (other == null)
            {
                return 1;
            }

            switch (SortType)
            {
                case "按血":
                    return other.Health - Health;
                case "按攻":
                    return other.Attack - Attack;
                case "按防":
                    return other.Defence - Defence;
                case "按内":
                    return other.Magic - Magic;
                case "按平均":
                    return (int)(other.Attack + other.Defence + other.Health + other.Magic) - (int)(Attack + Defence + Health + Magic);
                case "按综合":
                    return (int)(other.Attack * 0.4 + other.Defence * 0.3 + other.Health * 0.2 + other.Magic * 0.1) - (int)(Attack * 0.4 + Defence * 0.3 + Health * 0.2 + Magic * 0.1);
            }

            return (int)(other.Attack * 0.4 + other.Defence * 0.3 + other.Health * 0.2 + other.Magic * 0.1) - (int)(Attack * 0.4 + Defence * 0.3 + Health * 0.2 + Magic * 0.1);
        }

        public void ToMember(string input)
        {
            var splits = input.Split(',');

            if (splits.Length == 9)
            {
                Name = splits[0];
                Health = Convert.ToInt32(splits[1]);
                Attack = Convert.ToInt32(splits[2]);
                Defence = Convert.ToInt32(splits[3]);
                Magic = Convert.ToInt32(splits[4]);
                HealthAdd = Convert.ToSingle(splits[5]);
                AttackAdd = Convert.ToSingle(splits[6]);
                DefenceAdd = Convert.ToSingle(splits[7]);
                MagicAdd = Convert.ToSingle(splits[8]);
            }
        }

        /// <summary>
        /// 预测
        /// </summary>
        /// <returns></returns>
        public Member Forecast()
        {
            if (Level < 2)
            {
                throw new Exception("要预测的等级需要大于1");
            }

            var newMember = new Member();

            newMember = MemberwiseClone() as Member;
            newMember.Health += Convert.ToInt32(newMember.HealthAdd * (Level - 1));
            newMember.Attack += Convert.ToInt32(newMember.AttackAdd * (Level - 1));
            newMember.Defence += Convert.ToInt32(newMember.DefenceAdd * (Level - 1));
            newMember.Magic += Convert.ToInt32(newMember.MagicAdd * (Level - 1));

            return newMember;
        }

        /// <summary>
        /// 计算增量
        /// </summary>
        /// <param name="newMember"></param>
        public void CalculateAdd(Member newMember)
        {
            if (Level < 2)
            {
                throw new Exception("要预测的等级需要大于1");
            }

            HealthAdd = (float)(newMember.Health - Health) / (Level - 1);
            AttackAdd = (float)(newMember.Attack - Attack) / (Level - 1);
            DefenceAdd = (float)(newMember.Defence - Defence) / (Level - 1);
            MagicAdd = (float)(newMember.Magic - Magic) / (Level - 1);
        }

        public string ToString(string type)
        {
            if (type.ToUpper() == "ALL")
            {
                return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}", Name, Health, Attack, Defence, Magic, HealthAdd.ToString("f"), AttackAdd.ToString("f"), DefenceAdd.ToString("f"), MagicAdd.ToString("f"));
            }

            return string.Format("{0},{1},{2},{3},{4}", Name, Health, Attack, Defence, Magic);
        }

        public void AddBornKongFu()
        {
            BornKongFu.GetAttribute();

            switch (BornKongFu.Category)
            {
                case 1:
                    Health = Convert.ToInt32(Health + Health * BornKongFu.HealthAdd);
                    break;
                case 2:
                    Attack = Convert.ToInt32(Attack + Attack * BornKongFu.AttackAdd);
                    break;
                case 3:
                    Defence = Convert.ToInt32(Defence + Defence * BornKongFu.DefenceAdd);
                    break;
                case 4:
                    Magic = Convert.ToInt32(Magic + Magic * BornKongFu.MagicAdd);
                    break;
            }
        }

        public void AddSecret(Secret secret)
        {
            secret.Calculate();
            Health += secret.Health;
            Attack += secret.Attack;
            Defence += secret.Defence;
            Magic += secret.Magic;
        }
    }
}
