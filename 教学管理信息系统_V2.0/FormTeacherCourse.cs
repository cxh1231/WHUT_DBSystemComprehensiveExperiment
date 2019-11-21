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
    public partial class FormTeacherCourse : Form
    {
        string Tno = ""; 
        public FormTeacherCourse()
        {
            Tno = FormTeacher.Tno;
            InitializeComponent();
            InitCourseList();

        }

        void InitCourseList()
        {
            string sql = "select Cno,Cname,Ctype,Ccredit,Cstatus,Cload,Cselected,Cintroduction from Course where Tno = '" + Tno + "'";
            DataSet dataSet = GetData(sql);
            gridControlCourse.DataSource = dataSet.Tables["Course"];
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



        private void simpleButtonAddNewCourse_Click(object sender, EventArgs e)
        {
            FormTeacherAddCourse formTeacherAddCourse = new FormTeacherAddCourse();
            formTeacherAddCourse.Show();
        }

        private void simpleButtonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButtonRefresh_Click(object sender, EventArgs e)
        {
            InitCourseList();
        }
    }
}
