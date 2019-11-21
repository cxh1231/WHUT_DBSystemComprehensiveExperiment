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
    public partial class FormAdminTeacherInfo : Form
    {
        public FormAdminTeacherInfo()
        {
            InitializeComponent();

            loadTeacherInfo();
            showAllCollage();

        }

        //private void gridControl1_Click(object sender, EventArgs e)
        //{

        //}

        void loadTeacherInfo()
        {
            //设置查询语句
            String sql = "select Tno,Tname,CollName,Tsex,Tethnic,Thome,Tbirth,Ttechnical from Teacher,Collage where Teacher.Tcollage = Collage.CollNo";

            //连接到数据库并执行查询，获取查询结果data
            DataSet dataSet = GetData(sql);

            //将查询结果显示到表格中
            gridControlTeacherInfo.DataSource = dataSet.Tables["Teacher"];

        }


        /*点击事件：刷新按钮·点击事件*/
        private void simpleButtonRefresh_Click(object sender, EventArgs e)
        {
            loadTeacherInfo();

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

        /*当打开界面的时候，就执行一次，刷新学院树*/
        private void showAllCollage()
        {
            string sql = "select CollName from Collage";

            DataSet dataSet = GetData(sql);

            //循环，将查询的学院信息显示在树中
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                //添加一级节点
                DevExpress.XtraTreeList.Nodes.TreeListNode FistLevelNode = treeListCollageList.AppendNode(null, null);
                //添加第一节点显示的值
                FistLevelNode.SetValue(treeListCollageList.Columns[0], dataRow["CollName"].ToString().Trim());

            }
        }


        /*学院  树节点  点击事件*/
        private void treeListCollageList_MouseClick(object sender, MouseEventArgs e)
        {

            string selectCollage = treeListCollageList.FocusedNode.GetDisplayText(0);

            string sql = "select Tno,Tname,CollName,Tsex,Tethnic,Thome,Tbirth,Ttechnical from Teacher, Collage where Teacher.Tcollage = Collage.CollNo and CollName = '" + selectCollage + "'";

            //连接到数据库并执行查询，获取查询结果data
            DataSet dataSet = GetData(sql);

            //将查询结果显示到表格中
            gridControlTeacherInfo.DataSource = dataSet.Tables["Teacher"];

        }

        /*添加新教师*/
        private void simpleButtonAddTeacher_Click(object sender, EventArgs e)
        {
            FormAdminAddteacher formAddteacher = new FormAdminAddteacher();
            formAddteacher.Show();


        }

        private void simpleButtonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
