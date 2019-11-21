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
    public partial class FormTeacherAddCourse : Form
    {
        string Cno = "", Cname = "", MajorNo = "", Tno = "", Ctype = "", Ccredit = "", Cstatus = "", Cload = "", Cselected = "", Cintroduction = "";

        public FormTeacherAddCourse()
        {
            Tno = FormTeacher.Tno;
            InitializeComponent();
            InitComboBoxEditCmajor();
        }



        /*开课专业选项有变化，就修改*/
        private void comBoxEditCmajor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string CollNo = "",theNum = "";
            string Cmajor = comboBoxEditCmajor.Properties.Items[comboBoxEditCmajor.SelectedIndex].ToString();

            /*获取专业号*/
            string sql = "select MajorNo from Major where MajorName ='" + Cmajor +"'";
            DataSet dataSet = GetData(sql);
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                MajorNo = dataRow["MajorNo"].ToString();//成功获取专业号
            }

            /*获取学院号*/
            sql = "select CollNo from Major where MajorName ='" + Cmajor + "'";
            dataSet = GetData(sql);
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                CollNo = dataRow["CollNo"].ToString();//成功获取专业号
            }

            /*获取当前课程应该属于的编号*/
            sql = "select Cname from Course where MajorNo = '" + MajorNo + "'";
            dataSet = GetData(sql);
            int num = 1;
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                num++;
            }
            theNum = num.ToString("00");//成功获取编号

            /*将组合成的课程号显示在相应位置*/
            textEditCno.Text = CollNo + MajorNo + theNum;

        }


        private void simpleButtonAdd_Click(object sender, EventArgs e)
        {

            if (textEditCname.Text == "")
            {
                MessageBox.Show("请输入课程名！");
            }
            else if (comboBoxEditCmajor.SelectedIndex == -1)
            {
                MessageBox.Show("请选择开课专业！");
            }
            else if (comboBoxEditCtype.SelectedIndex == -1)
            {
                MessageBox.Show("请选择课程类型！");
            }
            else if (comboBoxEditCcredit.SelectedIndex == -1)
            {
                MessageBox.Show("请选择开课专业！");
            }
            else if (memoEditCintroduction.Text == "")
            {
                MessageBox.Show("请输入课程介绍！");
            }
            else
            {
                Cno = textEditCno.Text;
                Cname = textEditCname.Text;
                //MajorNo
                //Tno
                Ctype = comboBoxEditCtype.Properties.Items[comboBoxEditCtype.SelectedIndex].ToString();
                Ccredit = comboBoxEditCcredit.Properties.Items[comboBoxEditCcredit.SelectedIndex].ToString();
                Cstatus = "待审核";
                Cload = "30";
                Cselected = "0";
                Cintroduction = memoEditCintroduction.Text;

                try
                {

                    //连接数据库
                    string con = "";//, sql = "";//con为连接数据库的字符，sql为SQL查询语句
                    con = "Data Source=CHENXIUHAO;Initial Catalog=教学管理信息系统;Integrated Security=True";

                    SqlConnection mycon = new SqlConnection(con);
                    mycon.Open();//打开数据库

                    string sql = "insert into Course values('" + Cno + "','" + Cname + "','" + MajorNo + "','" + Tno + "','" + Ctype + "','" + Ccredit + "','" + Cstatus + "','" + Cload + "','" + Cselected + "','" + Cintroduction +"')";

                    //MessageBox.Show(sql);

                    SqlCommand sqlCommand = new SqlCommand(sql, mycon);

                    sqlCommand.ExecuteNonQuery();

                    mycon.Close();

                    MessageBox.Show("已提交申请！");

                    this.Close();
                }
                catch (Exception)
                {
                    throw;
                }



            }

        }


        //初始化开课专业下拉列表
        private void InitComboBoxEditCmajor()
        {
            string sql = "select MajorName from Major";

            DataSet dataSet = GetData(sql);

            //循环，将查询的学院信息显示在树中
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                comboBoxEditCmajor.Properties.Items.Add(dataRow["MajorName"]);
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

        private void simpleButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
