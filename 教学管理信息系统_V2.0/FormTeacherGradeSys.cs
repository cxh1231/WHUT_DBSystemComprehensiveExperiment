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
    public partial class FormTeacherGradeSys : Form
    {
        string Tno = "";

        public FormTeacherGradeSys()
        {
            Tno = FormTeacher.Tno;
            InitializeComponent();
            InitGridView();
        }

        void InitGridView()
        {
            string sql = "select Cno,Cname,Cselected from Course where Tno = '"+Tno+"' and Cstatus = '已开课'";
            DataSet dataSet = GetData(sql);
            gridControlCourseOpen.DataSource = dataSet.Tables["Course"];
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



        /*提交成绩按钮*/
        private void simpleButtonUpdateCourseInfo_Click(object sender, EventArgs e)
        {

        }

        /*点击左侧信息的时候*/
        private void getStuList_MouseClick(object sender, MouseEventArgs e)
        {
            /*只有在表非空的情况下才进行，否则检索溢出*/
            if (gridView1.RowCount != 0)
            {
                /*获取当前选中的课程号*/
                int selectedHandle = this.gridView1.GetSelectedRows()[0];
                string Cno = this.gridView1.GetRowCellValue(selectedHandle, "Cno").ToString();


                /*判断课程是否已结课，如果结课，就不允许输入成绩*/


                /*查询并显示出来*/
                string sql = "select Grade.Sno,Sname,ClassName,GradeNormal,GradeTest,Grade from Grade, Student, Class where Grade.Cno = '"+Cno+"' and Student.Sno = Grade.Sno and ClassNo = Student.Sclass";

                //连接到数据库并执行查询，获取查询结果data
                DataSet dataSet = GetData(sql);
                //将查询结果显示到表格中
                gridControlCourseStu.DataSource = dataSet.Tables["Course"];
            }

        }

        /*输入数据后，换行自动将成绩导入到数据库保存*/
        private void uploadGrade_Click(object sender, MouseEventArgs e)
        {


            
        }

            /*行结束保存*/
        private void lineEndSave_Validated(object sender, EventArgs e)
        {

        }

        private void gridView2_RowLeaveSave(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            /*只有在表非空的情况下才进行，否则检索溢出*/
            if (gridView2.RowCount != 0)
            {
                /*获取当前选中的课程号*/
                int selectedHandle = this.gridView2.GetSelectedRows()[0];
                string Grade = this.gridView2.GetRowCellValue(selectedHandle, "Grade").ToString();
                string Sno = this.gridView2.GetRowCellValue(selectedHandle, "Sno").ToString();


            }
        }
    }
}
