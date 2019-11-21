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
    public partial class FormStudentCourse : Form
    {
        string Sno = "";

        public FormStudentCourse()
        {
            Sno = FormStudent.Sno;
            InitializeComponent();
            InitCourseAble();
            IninCourseSelected();
        }

        /*获得当前学生学号*/

        /*刷新可选课程列表*/
        void InitCourseAble()
        {
            string sql = "";
            string Smajor = "";

            /*首先获得当前学生的专业号*/
            sql = "select MajorNo from Class, Student where Student.Sno = '" + Sno + "' and Student.Sclass = Class.ClassNo";
            DataSet dataSet = GetData(sql);
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                Smajor = dataRow["MajorNo"].ToString();//成功获取学院号
            }

            /*筛选出当前专业可选的课程信息，并显示在表中*/
            //sql = "select Cno,Cname,Tname,Ctype,Ccredit,Cload,Cselected from Course, Teacher where MajorNo = '"+ Smajor +"' and Course.Tno = Teacher.Tno and Cstatus = '选课中'";
            sql = "select Cno, Cname, Tname, Ctype, Ccredit, Cload, Cselected from Course, Teacher where MajorNo = '" + Smajor + "' and Course.Tno = Teacher.Tno and Cstatus = '选课中' and Cno not in(select Cno from Grade where Sno = '" + Sno + "')";
            dataSet = GetData(sql);
            gridControlCourseAble.DataSource = dataSet.Tables["Student"];

            /*如果表中没有数据，按钮不可访问*/
            if (gridView2.RowCount == 0) 
                 simpleButtonAddNewCourse.Enabled = false;
            else if(gridView2.RowCount > 0)
                simpleButtonAddNewCourse.Enabled = true;

        }


        /*刷新已选课列表*/
        void IninCourseSelected()
        {
            /*筛选出当前学生已选的课程*/
            string sql = "select Cno, Cname, Tname, Ctype, Ccredit, Cload, Cselected from Course, Teacher where Course.Tno = Teacher.Tno and Cstatus = '选课中' and Cno in(select Cno from Grade where Sno = '" + Sno + "')";
            DataSet dataSet = GetData(sql);
            gridControlCourseSelected.DataSource = dataSet.Tables["Student"];

            /*如果表中没有数据，按钮不可访问*/
            if(gridView1.RowCount==0)
                simpleButtonDeleteCourse.Enabled = false;
            else if (gridView1.RowCount > 0)            
                simpleButtonDeleteCourse.Enabled = true;           

        }


        /*添加选课记录*/
        private void simpleButtonAddNewCourse_Click(object sender, EventArgs e)
        {
            /*获取当前选中的课程号*/
            int selectedHandle = this.gridView2.GetSelectedRows()[0];
            string Cno = this.gridView2.GetRowCellValue(selectedHandle, "Cno").ToString();

            /*首先判断当前课程是否有冲突*/
            string sql = "(select Cweeks,Cweek,Csection from CourseSchedule where Cno = '" + Cno + "' ) InterSect (select Cweeks, Cweek, Csection from Course, Grade, CourseSchedule where Grade.Cno = CourseSchedule.Cno and Grade.Cno = Course.Cno and Grade.Sno = '" + Sno + "')";
            DataSet dataSet = GetData(sql);
            string conflict = "";
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                conflict = conflict + "第" +dataRow["Cweeks"].ToString()+"周星期"+ dataRow["Cweek"].ToString()+"第"+dataRow["Csection"].ToString()+"节课\n";//成功获取已选人数
            }
            /*有冲突就退出*/
            if (conflict != "")
            {
                MessageBox.Show("当前选中课程和 " + conflict +" 的课程有冲突！请选择其他课程！","提示",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                return;
            }


            /**没有冲突，继续进行*/
            /*获取当前课程已选人数*/
            sql = "select Cselected from Course where Cno='" + Cno + "'";
            dataSet = GetData(sql);
            string Cselected = "",Cload="";
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                Cselected = dataRow["Cselected"].ToString();//成功获取已选人数
            }

            sql = "select Cload from Course where Cno='" + Cno + "'";
            dataSet = GetData(sql);
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                Cload = dataRow["Cload"].ToString();//成功获取课程容量
            }
                       
            /*课程数加一*/
            int num = int.Parse(Cselected);
            int load = int.Parse(Cload);

            //已选等于容量
            if (num >= load) 
            {
                MessageBox.Show("当前课程容量已满，请刷新！");
                return;
            }
            else
            {
                num++;
                string newCselected = num.ToString();

                /*修改插入信息*/
                sql = "insert into Grade(Cno,Sno) values('" + Cno + "','" + Sno + "');update Course set Cselected='" + newCselected + "' where Cno='" + Cno + "';";

                try
                {
                    //连接数据库
                    string con = "";//, sql = "";//con为连接数据库的字符，sql为SQL查询语句
                    con = "Data Source=CHENXIUHAO;Initial Catalog=教学管理信息系统;Integrated Security=True";
                    SqlConnection mycon = new SqlConnection(con);
                    mycon.Open();//打开数据库
                                 //MessageBox.Show(sql);
                    SqlCommand sqlCommand = new SqlCommand(sql, mycon);
                    sqlCommand.ExecuteNonQuery();
                    mycon.Close();



                    //MessageBox.Show("添加成功！");
                }
                catch (Exception)
                {
                    throw;
                }
                /*刷新*/
                InitCourseAble();
                IninCourseSelected();
            }

        }

        /*删除选课记录*/
        private void simpleButtonDeleteCourse_Click(object sender, EventArgs e)
        {
            /*获取当前选中的课程号*/
            int selectedHandle = this.gridView1.GetSelectedRows()[0];
            string Cno = this.gridView1.GetRowCellValue(selectedHandle, "Cno").ToString();

            /*判断课程是否处于选课状态*/
            string sql = "select Cstatus from Course where Cno='" + Cno + "'";
            DataSet dataSet = GetData(sql);
            string Cstatus = "";
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                Cstatus = dataRow["Cstatus"].ToString();
            }

            /*如果不处于选课状态，禁止退选*/
            if (Cstatus != "选课中")
            {
                MessageBox.Show("当前课程不处于选课状态，禁止退选！","提示");
                return;
            }


            /*获取当前课程已选人数*/
            sql = "select Cselected from Course where Cno='" + Cno + "'";
            dataSet = GetData(sql);
            string Cselected = "";
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                Cselected = dataRow["Cselected"].ToString();
            }
            /*课程数加一*/
            int num = int.Parse(Cselected);
            num--;
            string newCselected = num.ToString();


            /*更新数据*/
            sql = "delete from Grade where Cno='" + Cno + "' and Sno='" + Sno + "';update Course set Cselected='" + newCselected + "' where Cno='" + Cno + "';";
            try
            {
                //连接数据库
                string con = "";//, sql = "";//con为连接数据库的字符，sql为SQL查询语句
                con = "Data Source=CHENXIUHAO;Initial Catalog=教学管理信息系统;Integrated Security=True";
                SqlConnection mycon = new SqlConnection(con);
                mycon.Open();//打开数据库
                //MessageBox.Show(sql);
                SqlCommand sqlCommand = new SqlCommand(sql, mycon);
                sqlCommand.ExecuteNonQuery();
                mycon.Close();

                /*刷新*/
                InitCourseAble();
                IninCourseSelected();

                //MessageBox.Show("添加成功！");
            }
            catch (Exception)
            {
                throw;
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
            myda.Fill(dataSet, "Student");
            mycon.Close();
            return dataSet;
        }

        private void courseAble_Click(object sender, MouseEventArgs e)
        {

        }

        private void courseSelected_Click(object sender, MouseEventArgs e)
        {

        }

        /*已选课程清单为空*/
        private void courseSelectedEmpty(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
        {

        }

        /*刷新按钮*/
        private void simpleButtonRefresh_Click(object sender, EventArgs e)
        {

            /*刷新*/
            InitCourseAble();
            IninCourseSelected();

        }
    }
}
