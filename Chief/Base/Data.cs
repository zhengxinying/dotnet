
namespace Chief.Base
{
    public abstract class Data
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 血
        /// </summary>
        public int Health { get; set; }

        /// <summary>
        /// 攻
        /// </summary>
        public int Attack { get; set; }

        /// <summary>
        /// 防
        /// </summary>
        public int Defence { get; set; }

        /// <summary>
        /// 内
        /// </summary>
        public int Magic { get; set; }

        /// <summary>
        /// 血每级增量
        /// </summary>
        public float HealthAdd { get; set; }

        /// <summary>
        /// 攻每级增量
        /// </summary>
        public float AttackAdd { get; set; }

        /// <summary>
        /// 防每级增量
        /// </summary>
        public float DefenceAdd { get; set; }

        /// <summary>
        /// 内每级增量
        /// </summary>
        public float MagicAdd { get; set; }

        /// <summary>
        /// 等级
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 级别：甲1乙2丙3丁4
        /// </summary>
        public int Rank { get; set; }
    }
}
