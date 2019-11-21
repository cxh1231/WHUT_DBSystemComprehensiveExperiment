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
    public partial class FormTeacherTask : Form
    {

        string Tno = ""; 
        public FormTeacherTask()
        {
            Tno= FormLogin.userID;
            InitializeComponent();
            InitMyCourse();

        }


        /*初始化教师的所有课程信息*/
        void InitMyCourse()
        {
            string sql = "select Cno,Cname,Ccredit,Cselected,Cstatus from Course where Tno='" + Tno + "' and Cstatus='选课中' or Cstatus='待开课' or Cstatus='已开课'";

            DataSet dataSet = GetData(sql);

            gridControlMyCourse.DataSource = dataSet.Tables["Course"];
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



        private void selectCourse_Click(object sender, MouseEventArgs e)
        {
            /*只有在表非空的情况下才进行，否则检索溢出*/
            if (gridView1.RowCount != 0)
            {
                /*获取当前选中的课程号*/
                int selectedHandle = this.gridView1.GetSelectedRows()[0];
                string Cno = this.gridView1.GetRowCellValue(selectedHandle, "Cno").ToString();

                /*查询并显示出来*/

                string sql = "select Student.Sno,Sname,ClassName from Student,Class,Grade where Cno = '" + Cno + "' and Grade.Sno = Student.Sno and Student.Sclass = Class.ClassNo";

                //连接到数据库并执行查询，获取查询结果data
                DataSet dataSet = GetData(sql);
                //将查询结果显示到表格中
                gridControlClassStudent.DataSource = dataSet.Tables["Course"];
            }
        }

        private void simpleButtonPrintStuInfo_Click(object sender, EventArgs e)
        {

        }

        private void gridControlMyCourse_Click(object sender, EventArgs e)
        {

        }
    }
}
