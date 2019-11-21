using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 教学管理信息系统_V2._0
{
    public partial class FormAdminAddteacher : Form
    {
        int thisYear = 2019;

        //职工号，不允许自己赋值
        string teacherNo="";
        string teacherCollNo = "";

        public FormAdminAddteacher()
        {
            InitializeComponent();
            InitComboBoxEditCollage();
            InitComboBoxEditBirthYear(thisYear);
            InitComboBoxEditBirthDay();
        }

        //初始化学院下拉列表
        private void InitComboBoxEditCollage()
        {
            string sql = "select CollName from Collage";

            DataSet dataSet = GetData(sql);

            //循环，将查询的学院信息显示在树中
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                comboBoxEditCollage.Properties.Items.Add(dataRow["CollName"]);
            }
        }

        //初始化两个“年”下拉列表
        private void InitComboBoxEditBirthYear(int thisYear)
        {
            for (int i = thisYear; i >= 1960; i--) 
            {
                comboBoxEditBirthYear.Properties.Items.Add(i);
                comboBoxEditJobYear.Properties.Items.Add(i);
            }
        }


        /*给“日”刷新*/
        private void comboBoxEditBirthMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitComboBoxEditBirthDay();
        }
        //初始化“日”下拉列表
        private void InitComboBoxEditBirthDay()
        {
            string months="";
            //获取选择的月份
            if (comboBoxEditBirthMonth.SelectedIndex != -1)
            {
                months = comboBoxEditBirthMonth.Properties.Items[comboBoxEditBirthMonth.SelectedIndex].ToString();
            }
            else
            {
                return;
            }

            //判断月份的天数并设置
            if (months == "1" || months == "3" || months == "5" || months == "7" || months == "8" || months == "10" || months == "12")
            {
                InitComboBoxEditBirthDay(31);
            }
            else if (months == "4" || months == "6" || months == "9" || months == "11")
            {
                InitComboBoxEditBirthDay(30);
            }
            else
            {
                InitComboBoxEditBirthDay(28);//最好添加瑞年的操作判断
            }
        }
        private void InitComboBoxEditBirthDay(int day){
            for (int i = 1; i <= day; i++) 
            {
                comboBoxEditBirthDay.Properties.Items.Add(i);
            }
        }

        /*连接数据库，得到DataSet类的对象，并返回data*/
        private DataSet GetData(string sql)
        {
            //连接数据库
            string con = "";//, sql = "";//con为连接数据库的字符，sql为SQL查询语句
            con = "Data Source=CHENXIUHAO;Initial Catalog=教学管理信息系统;Integrated Security=True";

            SqlConnection mycon = new SqlConnection(con);
            mycon.Open();//打开数据库

            SqlDataAdapter myda = new SqlDataAdapter(sql, con);
            DataSet dataSet = new DataSet();
            myda.Fill(dataSet, "Teacher");
            mycon.Close();
            return dataSet;
        }

        /*点击确认添加按钮事件*/
        private void simpleButtonAdd_Click(object sender, EventArgs e)
        {
            if (textEditName.Text == "")
            {
                MessageBox.Show("请输入姓名！");
            }
            else if (comboBoxEditSex.SelectedIndex == -1)
            {
                MessageBox.Show("请选择性别！");
            }
            else if (comboBoxEditTechnical.SelectedIndex == -1)
            {
                MessageBox.Show("请选择职称！");
            }
            else if (comboBoxEditTethnic.SelectedIndex == -1)
            {
                MessageBox.Show("请选择民族！");
            }
            else if (comboBoxEditCollage.SelectedIndex == -1)
            {
                MessageBox.Show("请选择学院！");
            }
            else if (textEditHome.Text == "")
            {
                MessageBox.Show("请输入籍贯！");
            }
            else if (comboBoxEditJobYear.SelectedIndex == -1)
            {
                MessageBox.Show("请选择入职年！");
            }
            else if (comboBoxEditBirthYear.SelectedIndex == -1 || comboBoxEditBirthMonth.SelectedIndex == -1 || comboBoxEditBirthDay.SelectedIndex == -1)
            {
                MessageBox.Show("请正确选择生日！");
            }
            else
            {
                string Tno = teacherNo;
                string Tname = textEditName.Text;
                string Tcollage = teacherCollNo;
                string Tsex = comboBoxEditSex.Properties.Items[comboBoxEditSex.SelectedIndex].ToString();
                string Tethnic = comboBoxEditTethnic.Properties.Items[comboBoxEditTethnic.SelectedIndex].ToString();
                string Thome = textEditHome.Text;

                string year = comboBoxEditBirthYear.Properties.Items[comboBoxEditBirthYear.SelectedIndex].ToString();
                string month = comboBoxEditBirthMonth.Properties.Items[comboBoxEditBirthMonth.SelectedIndex].ToString();
                string day = comboBoxEditBirthDay.Properties.Items[comboBoxEditBirthDay.SelectedIndex].ToString();
                string Tbirth = year.PadLeft(4, '0') +"-"+ month.PadLeft(2, '0') +"-"+ day.PadLeft(2, '0');

                string Ttechnical = comboBoxEditTechnical.Properties.Items[comboBoxEditTechnical.SelectedIndex].ToString();
                string Tpassword = teacherNo;

                try {

                    //连接数据库
                    string con = "";//, sql = "";//con为连接数据库的字符，sql为SQL查询语句
                    con = "Data Source=CHENXIUHAO;Initial Catalog=教学管理信息系统;Integrated Security=True";

                    SqlConnection mycon = new SqlConnection(con);
                    mycon.Open();//打开数据库

                    string sql = "insert into Teacher values('" + Tno + "','"+ Tname +"','"+ Tcollage +"','"+ Tsex +"','"+Tethnic+"','"+Thome+"','"+Tbirth+"','"+Ttechnical+"','"+ Tpassword +"')";

                    //MessageBox.Show(sql);

                    SqlCommand sqlCommand = new SqlCommand(sql, mycon);

                    sqlCommand.ExecuteNonQuery();

                    mycon.Close();

                    MessageBox.Show("添加成功！");
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        //所选的学院有变化
        private void comboBoxEditCollage_SelectedIndexChanged(object sender, EventArgs e)
        {
            getTno();
        }

        /*所选的工作年有变化*/
        private void comboBoxEditJobYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            getTno();
        }

        //获取职工号，并设置
        private void getTno()
        {
            string theNum = "0000";

            string collageSelected = "";
            string jobYearSelected = "";
            //获取选中的值
            if (comboBoxEditCollage.SelectedIndex != -1 && comboBoxEditJobYear.SelectedIndex != -1)
            {
                jobYearSelected = comboBoxEditJobYear.Properties.Items[comboBoxEditJobYear.SelectedIndex].ToString();
                collageSelected = comboBoxEditCollage.Properties.Items[comboBoxEditCollage.SelectedIndex].ToString();
            }
            else
            {
                return;
            }

            string sql = "select Tno,CollNo from Teacher, Collage where Teacher.Tcollage = Collage.CollNo and CollName = '" + collageSelected + "'";
            DataSet dataSet = GetData(sql);
            int num = 1;
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                num++;
            }
            theNum = num.ToString("0000");//成功获取编号


            sql = "select CollNo from Collage where CollName='" + collageSelected + "'";
            dataSet = GetData(sql);
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                teacherCollNo = dataRow["CollNo"].ToString();//成功获取学院号
            }

            //组合职工号
            teacherNo= jobYearSelected + teacherCollNo + theNum;

            this.textEditNo.Text = teacherNo;
        }

        private void simpleButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
