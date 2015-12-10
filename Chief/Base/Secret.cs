
namespace Chief.Base
{
    /// <summary>
    /// 掌门诀
    /// </summary>
    public class Secret : Data
    {
        public int HealthLevel { get; set; }

        public int AttackLevel { get; set; }

        public int DefenceLevel { get; set; }

        public int MagicLevel { get; set; }

        public void Calculate()
        {
            Health = HealthLevel * (int)HealthAdd;
            Attack = AttackLevel * (int)AttackAdd;
            Defence = DefenceLevel * (int)DefenceAdd;
            Magic = MagicLevel * (int)MagicAdd;
        }
    }
}
