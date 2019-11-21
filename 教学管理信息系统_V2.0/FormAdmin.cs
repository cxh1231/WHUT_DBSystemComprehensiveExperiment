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
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
            InitSupplyCourse();
        }


        void InitSupplyCourse()
        {
            string sql = "select Cname,Tname,Cintroduction from Course,Teacher where Course.Tno=Teacher.Tno and Course.Cstatus='待审核'";
            DataSet dataSet = GetData(sql);
            gridControlNewSupply.DataSource = dataSet.Tables["Course"];
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



        private void simpleButtonTeacher_Click(object sender, EventArgs e)
        {
            FormAdminTeacherInfo formAdminTeacherInfo = new FormAdminTeacherInfo();
            formAdminTeacherInfo.Show();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButtonStudent_Click(object sender, EventArgs e)
        {
            FormAdminStudentInfo formAdminStudentInfo = new FormAdminStudentInfo();
            formAdminStudentInfo.Show();
        }

        private void simpleButtonClass_Click(object sender, EventArgs e)
        {
            FormAdminCourseInfo formAdminCourseInfo = new FormAdminCourseInfo();
            formAdminCourseInfo.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;       //获取当前时间
            labelControlTime.Font = new Font("宋体", 11);  //设置label1显示字体
            labelControlTime.Text = time.ToString(); //显示当前时间
        }
    }
}
