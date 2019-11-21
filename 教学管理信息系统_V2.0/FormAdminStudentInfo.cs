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
    public partial class FormAdminStudentInfo : Form
    {
        public FormAdminStudentInfo()
        {
            InitializeComponent();
            showAllClass();
            loadStuInfo();
        }

        /*初始化或者刷新所有学生信息*/
        void loadStuInfo()
        {
            //设置查询语句
            String sql = "select Sno,Sname,Ssex,Sethnic,Shome,Sbirth,Syear,ClassName from Student, Class where Sclass = ClassNo";

            //连接到数据库并执行查询，获取查询结果data
            DataSet dataSet = GetData(sql);

            //将查询结果显示到表格中
            gridControlStuInfo.DataSource = dataSet.Tables["Student"];


        }

        /*专业班级树中显示所有的学院专业班级信息*/
        private void showAllClass()
        {

            //string sql = "select CollName,MajorName,ClassName from Collage, Major, Class where Collage.CollNo = Major.CollNo and Major.MajorNo = Class.MajorNo";
            string sql = "select ClassName from Class";
            DataSet dataSet = GetData(sql);


            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                //添加一级节点
                DevExpress.XtraTreeList.Nodes.TreeListNode FistLevelNode = treeListClass.AppendNode(null, null);
                //添加第一节点显示的值
                FistLevelNode.SetValue(treeListClass.Columns[0], dataRow["ClassName"].ToString().Trim());



                /*
                //if (dr["CollName"].ToString().Trim() != "")
                //{
                    DevExpress.XtraTreeList.Nodes.TreeListNode FistLevelNode = treeList1.AppendNode(null, null);//添加一级节点
                    if (FistLevelNode != null)
                        FistLevelNode.SetValue(treeList1.Columns[0], dr["CollName"].ToString().Trim());//添加第一节点显示的值

                    foreach (DataRow dr_ in dataSet.Tables[0].Rows)
                    {
                        //if (dr_["MajorName"].ToString().Trim() != "")
                        //{
                            DevExpress.XtraTreeList.Nodes.TreeListNode SecondLevelNode = null;
                            if (dr["CollName"].ToString().Trim() == dr_["MajorName"].ToString().Trim())
                            {
                                SecondLevelNode = treeList1.AppendNode(null, FistLevelNode.Id);//添加二级节点
                                if (SecondLevelNode != null)
                                    SecondLevelNode.SetValue(treeList1.Columns[0], dr_["MaJorName"].ToString().Trim());//添加节点显示的值

                                foreach (DataRow dr_temp in dataSet.Tables[0].Rows)
                                {
                                    if (dr_temp["ClassName"].ToString().Trim() == dr_["MajorName"].ToString().Trim())
                                    {
                                        DevExpress.XtraTreeList.Nodes.TreeListNode ThirdLevelNode = treeList1.AppendNode(null, SecondLevelNode.Id);//添加三级节点
                                        if (ThirdLevelNode != null)
                                            ThirdLevelNode.SetValue(treeList1.Columns[0], dr_temp["ClassName"].ToString().Trim());//添加节点显示的值         
                                    }
                                }
                            }
                        //}
                   // }

                
                }*/
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

        private void simpleButtonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButtonRefresh_Click(object sender, EventArgs e)
        {
            loadStuInfo();
        }
    }
}
