
namespace Chief.Base
{
    public class KongFu : Data
    {
        /// <summary>
        /// 加血1，加攻2，加防3，加内4
        /// </summary>
        public int Category { get; set; }

        /// <summary>
        /// 各项分类
        /// </summary>
        public int CategoryAdd { get; set; }

        public void GetAttribute()
        {
            if (Level == 1) return;

            if (Category == 1)
            {
            }
            else if (Category == 2)
            {
                switch (CategoryAdd)
                {
                    // 降龙伏虎功
                    case 1:
                        AttackAdd += (Level - 1) * 0.01f;
                        break;
                    // 明玉功
                    case 2:
                        AttackAdd += (Level - 1) * 0.024f;
                        break;
                }
            }
            else if (Category == 3)
            {
                switch (CategoryAdd)
                {
                    // 金钟罩
                    case 1:
                        DefenceAdd += (Level - 1) * 0.0225f;
                        break;
                    // 小无相功
                    case 2:
                        DefenceAdd += (Level - 1) * 0.03f;
                        break;
                    // 玉女心经
                    case 3:
                        DefenceAdd += (Level - 1) * 0.045f;
                        break;
                }
            }
            else if (Category == 4)
            {
                switch (CategoryAdd)
                {
                    // 长生功
                    case 1:
                        MagicAdd += (Level - 1) * 0.0275f;
                        break;
                }
            }
        }
    }
}
