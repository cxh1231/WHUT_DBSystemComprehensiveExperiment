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
    public partial class FormStudentGrade : Form
    {
        string Sno = "";
        public FormStudentGrade()
        {
            Sno = FormStudent.Sno;
            InitializeComponent();
            InitGrade();
        }
        /*加载成绩单*/
        void InitGrade()
        {

            string sql = "select Course.Cno,Cname,Ctype,Ccredit,Gtype,Grade from Grade, Course where Course.Cno = Grade.Cno and Grade.Sno = '" + Sno + "'";

            DataSet dataSet = GetData(sql);

            gridControlGrade.DataSource = dataSet.Tables["Grade"];

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
            myda.Fill(dataSet, "Grade");
            mycon.Close();
            return dataSet;
        }


        private void simpleButtonDeleteCourse_Click(object sender, EventArgs e)
        {

        }

        private void simpleButtonRefresh_Click(object sender, EventArgs e)
        {
            InitGrade();
        }
    }
}
