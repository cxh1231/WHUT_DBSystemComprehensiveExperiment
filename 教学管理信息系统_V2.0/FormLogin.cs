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

/*
                 string sql = "select Clesson from CourseSchedule where Cno='" + Cno + "' and Cweeks='" + Cweeks + "' and Cweek='" + Cweek + "' and Csection= '" + Csection + "'";
                string result = "";
                DataSet dataSet = GetData(sql);
                foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                {
                    result = dataRow["Clesson"].ToString();//成功获取学院号
                }
     
     */


namespace 教学管理信息系统_V2._0
{
    public partial class FormLogin : Form
    {
        public static string userID;

        public string userPassword;
        
        public FormLogin()
        {
            InitializeComponent();
        }

        /*点击登录按钮操作*/
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //获取两个登陆信息
            userID = comboBoxEditUserName.Text;
            userPassword = textEditPassword.Text;

            if (userID=="")
            {
                MessageBox.Show("请输入用户名！","提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (userPassword=="")
            {
                MessageBox.Show("请输入密码！","提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (radioButtonStudent.Checked)
            {
                //string correctPassword = "";
                //string sql = "select Spassword from Student where Sno='" + userID + "'";
                //DataSet dataSet = GetData(sql);
                //foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                //{
                //    correctPassword = dataRow["Spassword"].ToString();
                //}
                //if (correctPassword == "")
                //{
                //    MessageBox.Show("登录账户不存在，请检查勾选的身份信息！", "提示",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //}
                //else if (correctPassword != userPassword)
                //{
                //    MessageBox.Show("登录密码错误！", "提示",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //}
                //else if (correctPassword == userPassword)
                //{
                    FormStudent formStudent = new FormStudent();
                    formStudent.Show();
                //}
            }
            else if (radioButtonTeacher.Checked)
            {
                //string correctPassword = "";
                //string sql = "select Tpassword from Teacher where Tno='" + userID + "'";
                //DataSet dataSet = GetData(sql);
                //foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                //{
                //    correctPassword = dataRow["Tpassword"].ToString();
                //}
                //if (correctPassword == "")
                //{
                //    MessageBox.Show("登录账户不存在，请检查勾选的身份信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //}
                //else if (correctPassword != userPassword)
                //{
                //    MessageBox.Show("登录密码错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //}
                //else if (correctPassword == userPassword)
                //{
                    FormTeacher formTeacher = new FormTeacher();
                    formTeacher.Show();
                //}
            }
            else if (radioButtonAdmin.Checked)
            {
                //string correctPassword = "";
                //string sql = "select Spassword from Student where Sno='" + userID + "'";
                //DataSet dataSet = GetData(sql);
                //foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                //{
                //    correctPassword = dataRow["Spassword"].ToString();
                //}
                if (userID != "admin")
                {
                    MessageBox.Show("非管理员账户，禁止登陆！", "提示",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                }
                else if ("admin" != userPassword)
                {
                    MessageBox.Show("登录密码错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if ("admin" == userPassword)
                {
                    FormAdmin formAdmin = new FormAdmin();
                    formAdmin.Show();
                }
            }
            else
            {
                MessageBox.Show("请选择身份！","提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void simpleButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
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
            myda.Fill(dataSet, "Teacher");
            mycon.Close();
            return dataSet;
        }

        void getUserInfo()
        {
           // string sql = "select CollNo from Collage where CollName='" + collageSelected + "'";
            //DataSet dataSet = GetData(sql);
          //  foreach (DataRow dataRow in dataSet.Tables[0].Rows)
          //  {
          ////      teacherCollNo = dataRow["CollNo"].ToString();//成功获取学院号
          //  }

        }

        private void selectedUserNameChanged(object sender, EventArgs e)
        {
            textEditPassword.Text = comboBoxEditUserName.Text;
        }
    }
}
