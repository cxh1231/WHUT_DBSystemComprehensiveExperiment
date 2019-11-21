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
    public partial class FormAdminCourseSchedule : Form
    {
        string Cno = "";
        int nowLesson = 1;

        public FormAdminCourseSchedule()
        {
            InitializeComponent();
            InitCourseInfo();
        }

        void InitCourseInfo()
        {
            nowLesson = 1;
            Cno = FormAdminCourseInfo.clickCno;

            if (Cno == "")
            {
                DialogResult result = MessageBox.Show("请返回选中一条课程记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                simpleButtonAdd.Enabled = false;
                simpleButtonBack.Enabled = true;                
                //if (result == DialogResult.OK) ;
                    //this.Close();
            }
            else
            {
                string Cname = "", Clesson = "";

                /*获取课程名*/
                string sql = "select Cname from Course where Cno='" + Cno + "'";
                DataSet dataSet = GetData(sql);
                foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                {
                    Cname = dataRow["Cname"].ToString();
                }

                /*获取课程学时*/
                sql = "select Clesson from Course where Cno='" + Cno + "'";
                dataSet = GetData(sql);
                foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                {
                    Clesson = dataRow["Clesson"].ToString();
                }                

                sql = "select Cno from CourseSchedule where Cno='" + Cno + "'";
                dataSet = GetData(sql);
                foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                {
                    nowLesson++;
                }

                if (nowLesson > int.Parse(Clesson))
                {
                    MessageBox.Show("当前课程已经排课，请返回刷新重试！", "提示");
                    simpleButtonAdd.Enabled = false;
                    simpleButtonBack.Enabled = true;
                    return;
                }
                else if (nowLesson == 1) 
                {

                }
                else
                {
                    MessageBox.Show("当前课程前" + --nowLesson + "课时已排课，请继续排课！", "提示");
                    nowLesson++;
                }

                /*设置到界面中*/
                textEditCno.Text = Cno;
                textEditCname.Text = Cname;
                textEditClesson.Text = Clesson;
                textEditNowLesson.Text = nowLesson.ToString();
            }
        }

        /*获取表格数据，并添加到数据库*/
        void addLesson()
        {
            //comboBoxEditSex.SelectedIndex == -1
            if (comboBoxEditCweeks.SelectedIndex == -1)
            {
                MessageBox.Show("请选择上课周次！");
            }
            else if (comboBoxEditCweek.SelectedIndex == -1)
            {
                MessageBox.Show("请选择上课星期！");
            }
            else if (comboBoxEditCsection.SelectedIndex == -1)
            {
                MessageBox.Show("请选择上课节次！");
            }
            else if (comboBoxEditCaddress.SelectedIndex == -1)
            {
                MessageBox.Show("请选择上课地点！");
            }
            else
            {
                string Clesson = textEditNowLesson.Text;
                string Cweeks = comboBoxEditCweeks.Properties.Items[comboBoxEditCweeks.SelectedIndex].ToString();
                string Cweek = comboBoxEditCweek.Properties.Items[comboBoxEditCweek.SelectedIndex].ToString();
                string Csection = comboBoxEditCsection.Properties.Items[comboBoxEditCsection.SelectedIndex].ToString();
                string Caddress = comboBoxEditCaddress.Properties.Items[comboBoxEditCaddress.SelectedIndex].ToString();

                /*判断当前老师在这周这星期这次课有没有记录*/                
                string sql = "select Cname from Course, CourseSchedule where Cweeks = '" + Cweeks + "' and Cweek = '" + Cweek + "' and Csection = '" + Csection + "'and Course.Cno = CourseSchedule.Cno and Tno = (select Tno from Course where Cno = '" + Cno + "')";
                string selectedCourseName = "";
                DataSet dataSet = GetData(sql);
                foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                {
                    selectedCourseName = dataRow["Cname"].ToString();//成功获取学院号
                }
                /*如果这个时间此老师有课，提示*/
                if (selectedCourseName!="")
                {
                    MessageBox.Show("当前时间，此教师已有课，请安排其他时间！","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }


                /*首先检索数据库中是否已经存在这个信息*/
                //primary key(Cno,Clesson,Cweeks,Cweek,Csection)
                sql = "select Clesson from CourseSchedule where Cno='" + Cno + "' and Cweeks='" + Cweeks + "' and Cweek='" + Cweek + "' and Csection= '" + Csection + "'";
                string result = "";
                dataSet = GetData(sql);
                foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                {
                    result = dataRow["Clesson"].ToString();//成功获取学院号
                }
                //提示重新修改
                if (result != "")
                {
                    MessageBox.Show("本课程“第"+Cweeks+"周 周"+Cweek+" 第"+Csection+"节”的选课信息已存在，和第"+result+"课时时间冲突！请重新选择","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                /*不存在则添加进去*/
                else
                {
                    //连接数据库
                    string con = "";//, sql = "";//con为连接数据库的字符，sql为SQL查询语句
                    con = "Data Source=CHENXIUHAO;Initial Catalog=教学管理信息系统;Integrated Security=True";

                    SqlConnection mycon = new SqlConnection(con);
                    mycon.Open();//打开数据库

                    /*设置SQL语句*/
                    string sql2 = "";
                    if (int.Parse(textEditClesson.Text) == nowLesson)
                    {
                        sql2 = "update Course set Cstatus='已排课' where Cno='" + Cno + "';"; 
                    }
                    sql = "insert into CourseSchedule values('" + Cno + "','" + Clesson + "','" + Cweeks + "','" + Cweek + "','" + Csection + "','" + Caddress + "');" + sql2;

                    SqlCommand sqlCommand = new SqlCommand(sql, mycon);

                    sqlCommand.ExecuteNonQuery();

                    mycon.Close();


                    /*判断要不要继续添加*/
                    if (int.Parse(textEditClesson.Text) == nowLesson) 
                    {
                        MessageBox.Show("所有课时课程已安排完毕，请返回！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        simpleButtonAdd.Enabled = false;
                        simpleButtonBack.Enabled = true;
                    }
                    else
                    {
                        DialogResult diaResult = MessageBox.Show("添加成功！请继续添加", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        nowLesson++;
                        textEditNowLesson.Text = nowLesson.ToString();

                        simpleButtonAdd.Enabled = true;
                        simpleButtonBack.Enabled = false;
                    }
                }
            }
        }

        private void simpleButtonAdd_Click(object sender, EventArgs e)
        {
            addLesson();
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

        private void simpleButtonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
