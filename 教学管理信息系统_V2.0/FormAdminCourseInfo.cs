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
    public partial class FormAdminCourseInfo : Form
    {
        public static string clickCno;

        public FormAdminCourseInfo()
        {
            InitializeComponent();
            showAllClass();
            loadCourseInfo();
        }

        /*加载所有的课程信息，并设置所有按钮不可访问*/
        void loadCourseInfo()
        {
            //设置查询语句
            String sql = "select Cno,Cname,MajorName,Tname,Ctype,Ccredit,Cstatus,Cload,Cselected,Clesson from Course, Teacher, Major where Course.MajorNo = Major.MajorNo and Course.Tno = Teacher.Tno";

            //连接到数据库并执行查询，获取查询结果data
            DataSet dataSet = GetData(sql);
            //将查询结果显示到表格中
            gridControlCourseInfo.DataSource = dataSet.Tables["Course"];
            //simpleButtonAllow.Enabled = true;
            setButtonStatus();
        }


        /*专业班级树中显示所有的学院专业班级信息*/
        private void showAllClass()        {

            //string sql = "select CollName,MajorName,ClassName from Collage, Major, Class where Collage.CollNo = Major.CollNo and Major.MajorNo = Class.MajorNo";
            string sql = "select MajorName from Major";
            DataSet dataSet = GetData(sql);

            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                //添加一级节点
                DevExpress.XtraTreeList.Nodes.TreeListNode FistLevelNode = treeListMajor.AppendNode(null, null);
                //添加第一节点显示的值
                FistLevelNode.SetValue(treeListMajor.Columns[0], dataRow["MajorName"].ToString().Trim());
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

        /*返回按钮*/
        private void simpleButtonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*刷新按钮*/
        private void simpleButtonRefresh_Click(object sender, EventArgs e)
        {
            loadCourseInfo();
        }

        /*点击某个专业后，筛选*/
        private void treeListMajorList_MouseClick(object sender, MouseEventArgs e)
        {
            loadClickMajorCourse();
            setButtonStatus();
        }
        void loadClickMajorCourse()
        {
            string selectMajor = treeListMajor.FocusedNode.GetDisplayText(0);
            //设置查询语句
            String sql = "select Cno,Cname,MajorName,Tname,Ctype,Ccredit,Cstatus,Cload,Cselected from Course, Teacher, Major where Course.MajorNo = Major.MajorNo and Course.Tno = Teacher.Tno and MajorName = '" + selectMajor + "'";
            //连接到数据库并执行查询，获取查询结果data
            DataSet dataSet = GetData(sql);
            //将查询结果显示到表格中
            gridControlCourseInfo.DataSource = dataSet.Tables["Course"];
        }

        /*通过审核*/
        private void simpleButtonAllow_Click(object sender, EventArgs e)
        {
            string Status = "已通过";
            setCourseStatus(Status);
        }

        /*拒绝审核*/
        private void simpleButtonRefuse_Click(object sender, EventArgs e)
        {
            string Status = "未通过";
            setCourseStatus(Status);
        }

        /*开启选课*/
        private void simpleButtonOpenSelect_Click(object sender, EventArgs e)
        {
            string Status = "选课中";
            setCourseStatus(Status);
        }

        /*关闭选课*/
        private void simpleButtonCloseSelect_Click(object sender, EventArgs e)
        {
            string Status = "待开课";
            setCourseStatus(Status);
        }

        /*开始上课*/
        private void simpleButtonCourseStart_Click(object sender, EventArgs e)
        {
            string Status = "已开课";
            setCourseStatus(Status);
        }

        /*设置课程状态*/
        void setCourseStatus(string Cstatus)
        {
            int selectedHandle = this.gridView1.GetSelectedRows()[0];
            string Cno = this.gridView1.GetRowCellValue(selectedHandle, "Cno").ToString();

            try
            {
                //连接数据库
                string con = "";//, sql = "";//con为连接数据库的字符，sql为SQL查询语句
                con = "Data Source=CHENXIUHAO;Initial Catalog=教学管理信息系统;Integrated Security=True";
                SqlConnection mycon = new SqlConnection(con);
                mycon.Open();//打开数据库

                string sql = "update Course set Cstatus='" + Cstatus + "' where Cno='" + Cno + "'";
                //MessageBox.Show(sql);

                SqlCommand sqlCommand = new SqlCommand(sql, mycon);
                sqlCommand.ExecuteNonQuery();
                mycon.Close();
                if (Cstatus == "已通过")
                {
                    MessageBox.Show("已通过审核！");
                }
                else if (Cstatus == "未通过")
                {
                    MessageBox.Show("已拒绝通过！");
                }
                else if (Cstatus == "选课中")
                {
                    MessageBox.Show("已开启选课！");
                }
                else if (Cstatus == "待开课")
                {
                    MessageBox.Show("已关闭选课！");
                }else if (Cstatus == "已开课")
                {
                    MessageBox.Show("已开始上课！");
                }

                /*刷新表格信息*/
                loadClickMajorCourse();

                /*再次将按钮设置成不可访问状态*/
                setButtonStatus();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*安排课表*/
        private void simpleButtonCourseSchedule_Click(object sender, EventArgs e)
        {
            FormAdminCourseSchedule formAdminCourseSchedule = new FormAdminCourseSchedule();
            formAdminCourseSchedule.Show();
        }

        /*根据课程状态来判断各个按钮的可选性*/
        private void CourseList_click(object sender, MouseEventArgs e)
        {
            setButtonStatus();
        }
        void setButtonStatus()
        {
            /*获取选中行的数据*/
            string Cstatus="初始值";
            if (gridView1.RowCount != 0)
            {
                int selectedHandle = this.gridView1.GetSelectedRows()[0];
                Cstatus = this.gridView1.GetRowCellValue(selectedHandle, "Cstatus").ToString();
                string Cno = this.gridView1.GetRowCellValue(selectedHandle, "Cno").ToString();
                clickCno = Cno;
            }


            if (Cstatus == "待审核")
            {
                simpleButtonAllow.Enabled = true;//通过
                simpleButtonRefuse.Enabled = true;//拒绝

                simpleButtonOpenSelect.Enabled = false;
                simpleButtonCloseSelect.Enabled = false;
                simpleButtonCourseSchedule.Enabled = false;
                simpleButtonCourseStart.Enabled = false;
            }
            else if (Cstatus == "已通过")
            {
                simpleButtonAllow.Enabled = false;
                simpleButtonRefuse.Enabled = false;
                simpleButtonOpenSelect.Enabled = false;
                simpleButtonCloseSelect.Enabled = false;
                simpleButtonCourseSchedule.Enabled = true;//排课
                simpleButtonCourseStart.Enabled = false;
            }
            else if (Cstatus == "已排课")
            {
                simpleButtonAllow.Enabled = false;
                simpleButtonRefuse.Enabled = false;
                simpleButtonOpenSelect.Enabled = true;//开启选课
                simpleButtonCloseSelect.Enabled = false;
                simpleButtonCourseSchedule.Enabled = false;
                simpleButtonCourseStart.Enabled = false;
            }
            else if (Cstatus == "选课中")
            {
                simpleButtonAllow.Enabled = false;
                simpleButtonRefuse.Enabled = false;
                simpleButtonOpenSelect.Enabled = false;

                simpleButtonCloseSelect.Enabled = true;
                simpleButtonCourseSchedule.Enabled = true;

                simpleButtonCourseStart.Enabled = false;
            }
            else if (Cstatus == "待开课")
            {
                simpleButtonAllow.Enabled = false;
                simpleButtonRefuse.Enabled = false;
                simpleButtonOpenSelect.Enabled = true;
                simpleButtonCloseSelect.Enabled = false;
                simpleButtonCourseSchedule.Enabled = true;
                simpleButtonCourseStart.Enabled = true;
            }
            else if (Cstatus == "已开课")
            {
                simpleButtonAllow.Enabled = false;
                simpleButtonRefuse.Enabled = false;
                simpleButtonOpenSelect.Enabled = false;
                simpleButtonCloseSelect.Enabled = false;
                simpleButtonCourseSchedule.Enabled = false;
                simpleButtonCourseStart.Enabled = false;
            }
            else if (Cstatus == "初始值")
            {
                simpleButtonAllow.Enabled = false;
                simpleButtonRefuse.Enabled = false;
                simpleButtonOpenSelect.Enabled = false;
                simpleButtonCloseSelect.Enabled = false;
                simpleButtonCourseSchedule.Enabled = false;
                simpleButtonCourseStart.Enabled = false;
            }
        }





    }
}
