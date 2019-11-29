# 教学管理信息系统

#### 介绍
这是武汉理工大学“数据库系统综合实验”课程实验项目源码。选题为《教学管理信息系统的设计与实现》。


#### 项目截图
![输入图片说明](https://images.gitee.com/uploads/images/2019/1130/000244_1bdd3dfb_5042354.png "图片1.png")
![输入图片说明](https://images.gitee.com/uploads/images/2019/1130/000252_8d245db3_5042354.png "图片2.png")


#### 开发环境说明
1.  本项目使用VS 2017开发，开发语言：C#；
2.  SQL Server为2017版本：V17.9.1；
3.  【重要】插件：DevExpress。插件官网：[https://www.devexpresscn.com/](https://www.devexpresscn.com/)。
4. 不安装DevExpress，无法打开项目！！！！！！
4. 不安装DevExpress，无法打开项目！！！！！！
4. 不安装DevExpress，无法打开项目！！！！！！


#### 安装教程

1.  首先将【SQL Server】文件夹下的两个数据库文件，导入到Microsoft SQL Server服务器中；
2.  然后将项目代码中的与数据库连接相关的部分的用户名修改为自己的SQL Server服务器的用户名
    如FormLogin.cs项目中的代码：

```
        /*连接数据库，得到DataSet类的对象，并返回data*/
        private DataSet GetData(string sql)
        {
            //连接数据库
            string con = "";//, sql = "";//con为连接数据库的字符，sql为SQL查询语句
            con = "Data Source=这里修改为自己SQL Server用户名;Initial Catalog=教学管理信息系统;Integrated Security=True";
            //con = "Data Source=CHENXIUHAO;Initial Catalog=教学管理信息系统;Integrated Security=True";

            SqlConnection mycon = new SqlConnection(con);
            mycon.Open();//打开数据库

            SqlDataAdapter myda = new SqlDataAdapter(sql, con);
            DataSet dataSet = new DataSet();
            myda.Fill(dataSet, "Teacher");
            mycon.Close();
            return dataSet;
        }
```
用户名在哪儿？如下图所示：
![数据库用户名](https://images.gitee.com/uploads/images/2019/1121/230105_51f2916a_5042354.png "TIM截图20191121230040.png")


#### 关于作者

1.  个人网址：[https://www.cxhit.com](https://www.cxhit.com)
2.  CSDN博客 [https://blog.csdn.net/cxh_1231](https://blog.csdn.net/cxh_1231)
3.  作者GitHub：[https://github.com/cxh1231](https://github.com/cxh1231)
4.  作者微信公众号：知行校园汇
