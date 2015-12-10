using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chief.InOut;
using Chief.Base;

namespace Chief
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();

            Init.InitBaseData();

            this.FormClosed += new FormClosedEventHandler(this.FrmMainClosed);
        }
        private void FrmMainClosed(object sender, FormClosedEventArgs e)        {        }

        #region 初始化按钮
        private void BtnInit_Click(object sender, EventArgs e)
        {
            var member = SearchMemberByName();
            if (member == null) return;

            var newMember = new Member();
            newMember.Name = member.Name;
            newMember.Health = Convert.ToInt32(TxtHealth.Text.Trim());
            newMember.Attack = Convert.ToInt32(TxtAttack.Text.Trim());
            newMember.Defence = Convert.ToInt32(TxtDefence.Text.Trim());
            newMember.Magic = Convert.ToInt32(TxtMagic.Text.Trim());

            var level = Convert.ToInt32(TxtLevel.Text.Trim());
            member.Level = level;
            member.CalculateAdd(newMember);

            MessageBox.Show("成功");
        }
        #endregion

        #region 预测按钮
        private void BtnForecast_Click(object sender, EventArgs e)
        {
            TxtResult.Clear();

            var newMember = OnlyCalculate();

            if (newMember == null) return;

            TxtResult.AppendText(newMember.ToString("part") + "\r\n");
        }
        #endregion

        #region 预测全部按钮
        private void BtnForecastAll_Click(object sender, EventArgs e)
        {
            TxtResult.Clear();

            var newMembers = new List<Member>();

            var level = Convert.ToInt32(TxtLevel.Text.Trim());

            foreach (var member in Constant.Members)
            {
                member.Level = level;
                var newMember = member.Forecast();
                newMember.SortType = CmbSortBy.Text.Trim();
                newMembers.Add(newMember);
            }

            newMembers.Sort();
            foreach (var newMember in newMembers)
            {
                TxtResult.AppendText(newMember.ToString("part") + "\r\n");
            }
        }
        #endregion

        #region 保存按钮
        private void BtnSave_Click(object sender, EventArgs e)
        {
            var file = System.Environment.CurrentDirectory + @"\Chief.txt";
            var writer = new Writer();

            var output = new List<string>();
            foreach (var member in Constant.Members)
            {
                output.Add(member.ToString("all"));
            }
            writer.WriteText(file, output);

            MessageBox.Show("成功");
        }
        #endregion

        #region 综合计算按钮
        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            TxtResult.Clear();

            var member = OnlyCalculate();

            if (member == null) return;

            var kongfuLevel = 1;
            if (!string.IsNullOrEmpty(TxtKongFuLevel.Text))
            {
                kongfuLevel = Convert.ToInt32(TxtKongFuLevel.Text.Trim());
            }

            member.BornKongFu.Level = kongfuLevel;
            member.AddBornKongFu();

            Constant.MySecret.HealthLevel = Convert.ToInt32(TxtHealthLevel.Text.Trim());
            Constant.MySecret.AttackLevel = Convert.ToInt32(TxtAttackLevel.Text.Trim());
            Constant.MySecret.DefenceLevel = Convert.ToInt32(TxtDefenceLevel.Text.Trim());
            Constant.MySecret.MagicLevel = Convert.ToInt32(TxtMagicLevel.Text.Trim());
            member.AddSecret(Constant.MySecret);

            TxtResult.AppendText(member.ToString("part") + "\r\n");
        }
        #endregion

        private Member SearchMemberByName()
        {
            var name = TxtName.Text.Trim();

            var member = Constant.Members.Find(m => m.Name == name);

            if (member == null)
            {
                MessageBox.Show("没有此人");
                return null;
            }

            member.Name = name;
            return member;
        }

        private Member OnlyCalculate()
        {
            var member = SearchMemberByName();
            if (member == null) return null;

            var level = Convert.ToInt32(TxtLevel.Text.Trim());

            member.Level = level;
            return member.Forecast();
        }
    }
}
