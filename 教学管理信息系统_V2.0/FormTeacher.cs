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
    public partial class FormTeacher : Form
    {
        public static string Tno;

        public FormTeacher()
        {
            Tno = FormLogin.userID;
            InitializeComponent();
            InitMyCourse();
            InitMyTask();
            InitTeacherName();
            //MessageBox.Show(Tno);
        }
        
        private void timer1_Tick(object sender, EventArgs e)    //接着在定时器触发事件中添加获取时间和显示时间函数
        {
            DateTime time = DateTime.Now;       //获取当前时间
            labelControlTime.Font = new Font("宋体", 11);  //设置label1显示字体
            labelControlTime.Text = time.ToString(); //显示当前时间
        }

        void InitMyTask(string Tno, String Cweeks)
        {
            /*将开课信息显示在主界面上*/
            string sql = "select Cname,CourseSchedule.Clesson,Cweek,Csection,Caddress from Course,CourseSchedule where Course.Cno=CourseSchedule.Cno and Tno='" + Tno + "' and Cweeks='" + Cweeks + "'";

            DataSet dataSet = GetData(sql);

            gridControlMyTask.DataSource = dataSet.Tables["Course"];
        }



        private void InitMyCourse()
        {
            string sql = "select Cno,Cname,Cstatus from Course where Tno='" + Tno + "'";

            DataSet dataSet = GetData(sql);

            gridControlMyCourse.DataSource = dataSet.Tables["Course"];
        }

        private void InitMyTask()
        {
            string sql = "select Cname,Cload from Course where Cstatus='已开课' and Tno='"+Tno+"'";

            DataSet dataSet = GetData(sql);

            gridControlMyTask.DataSource = dataSet.Tables["Course"];
        }

        private void InitTeacherName()
        {
            string sql = "select Tname from Teacher where Tno='" + Tno + "'";
            string Tname = "";

            DataSet dataSet = GetData(sql);

            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                Tname = dataRow["Tname"].ToString();//成功获取老师姓名
            }

            labelControlTeacherName.Text = Tname+"，欢迎登陆！";

            string Cweeks = "1";
            InitMyTask(Tno, Cweeks);
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
            myda.Fill(dataSet, "Course");
            mycon.Close();
            return dataSet;
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButtonTeacher_Click(object sender, EventArgs e)
        {
            FormTeacherCourse formTeacherCourse = new FormTeacherCourse();
            formTeacherCourse.Show();
        }

        private void simpleButtonStudent_Click(object sender, EventArgs e)
        {
            FormTeacherTask formTeacherTask = new FormTeacherTask();
            formTeacherTask.Show();
        }

        private void simpleButtonClass_Click(object sender, EventArgs e)
        {
            FormTeacherGradeSys formTeacherGradeSys = new FormTeacherGradeSys();
            formTeacherGradeSys.Show();
        }

        /*点击查询按钮*/
        private void simpleButtonSearch_Click(object sender, EventArgs e)
        {
            if (comboBoxEditCweeks.SelectedIndex>=0)
            {
                string Cweeks = comboBoxEditCweeks.Properties.Items[comboBoxEditCweeks.SelectedIndex].ToString();


                InitMyTask(Tno, Cweeks);

                labelControlIntro.Text = "本学期　第" + Cweeks + "周　的课程安排如下";

            }

        }

        /*星期选择变化*/
        private void WeeksSelectedChanged(object sender, EventArgs e)
        {
            string Cweeks = comboBoxEditCweeks.Properties.Items[comboBoxEditCweeks.SelectedIndex].ToString();
            InitMyTask(Tno, Cweeks);

            labelControlIntro.Text = "本学期　第" + Cweeks + "周　的课程安排如下";
        }
    }
}
