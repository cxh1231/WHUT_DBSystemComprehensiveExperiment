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
    public partial class FormStudent : Form
    {
        public static string Sno;

        string Sname ="";
        public FormStudent()
        {
            Sno = FormLogin.userID;
            InitializeComponent();
            InitStuInfo();
        }

        void InitStuInfo()
        {
            //获取学生学号

            /*将界面上方的姓名修改一下*/
            string sql = "select Sname from Student where Sno='" + Sno + "'";
            DataSet dataSet = GetData(sql);
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                Sname = dataRow["Sname"].ToString();//成功获取学生姓名
            }
            labelControlStuName.Text = Sname + "，欢迎登陆！";

            string Cweeks = "1";
            InitMyClassSchedule(Sno, Cweeks);
        }
        void InitMyClassSchedule(string Sno,String Cweeks)
        {
            /*将开课信息显示在主界面上*/
            string sql = "select Cname,CourseSchedule.Clesson,Cweek,Csection,Caddress from Course,CourseSchedule,Grade where Course.Cno=CourseSchedule.Cno and Course.Cno=Grade.Cno and Grade.Sno='" + Sno + "' and Cweeks='" + Cweeks + "'";

            DataSet dataSet = GetData(sql);

            gridControlMyCourseSchedule.DataSource = dataSet.Tables["Course"];
        }

        private void simpleButtonCourseSelected_Click(object sender, EventArgs e)
        {
            FormStudentCourse formStudentCourse = new FormStudentCourse();
            formStudentCourse.Show();
        }

        private void simpleButtonGrade_Click(object sender, EventArgs e)
        {
            FormStudentGrade formStudentGrade = new FormStudentGrade();
            formStudentGrade.Show();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void simpleButtonSearch_Click(object sender, EventArgs e)
        {
            if (comboBoxEditCweeks.SelectedIndex >= 0)
            {
                string Cweeks = comboBoxEditCweeks.Properties.Items[comboBoxEditCweeks.SelectedIndex].ToString();

                InitMyClassSchedule(Sno, Cweeks);

                labelControlIntro.Text = "本学期　第" + Cweeks + "周　的课程安排如下";

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
            myda.Fill(dataSet, "Course");
            mycon.Close();
            return dataSet;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;       //获取当前时间
            labelControlTime.Font = new Font("宋体", 11);  //设置label1显示字体
            labelControlTime.Text = time.ToString(); //显示当前时间
        }

        private void labelControl6_Click(object sender, EventArgs e)
        {

        }

        private void labelControl5_Click(object sender, EventArgs e)
        {

        }
    }
}
