namespace 教学管理信息系统_V2._0
{
    partial class FormAdminStudentInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAdminStudentInfo));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.treeListClass = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlStuInfo = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl6 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButtonBack = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonUpdateStudentInfo = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonDeleteStudent = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonAddStudent = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonRefresh = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlStuInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).BeginInit();
            this.panelControl6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Blue;
            this.panelControl1.Appearance.BackColor2 = System.Drawing.Color.Plum;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1262, 94);
            this.panelControl1.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("华文行楷", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl1.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("labelControl1.ImageOptions.Image")));
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(700, 54);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "教学管理信息系统—学生信息管理";
            // 
            // panelControl2
            // 
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 641);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1262, 32);
            this.panelControl2.TabIndex = 4;
            // 
            // panelControl3
            // 
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(0, 94);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(1262, 11);
            this.panelControl3.TabIndex = 5;
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.treeListClass);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl4.Location = new System.Drawing.Point(0, 105);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(246, 536);
            this.panelControl4.TabIndex = 6;
            // 
            // treeListClass
            // 
            this.treeListClass.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1});
            this.treeListClass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListClass.Location = new System.Drawing.Point(2, 2);
            this.treeListClass.Name = "treeListClass";
            this.treeListClass.OptionsBehavior.Editable = false;
            this.treeListClass.Size = new System.Drawing.Size(242, 532);
            this.treeListClass.TabIndex = 0;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "专业班级信息";
            this.treeListColumn1.FieldName = "学院班级信息";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            // 
            // panelControl5
            // 
            this.panelControl5.Controls.Add(this.gridControlStuInfo);
            this.panelControl5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl5.Location = new System.Drawing.Point(246, 105);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(1016, 410);
            this.panelControl5.TabIndex = 7;
            // 
            // gridControlStuInfo
            // 
            this.gridControlStuInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlStuInfo.Location = new System.Drawing.Point(2, 2);
            this.gridControlStuInfo.MainView = this.gridView1;
            this.gridControlStuInfo.Name = "gridControlStuInfo";
            this.gridControlStuInfo.Size = new System.Drawing.Size(1012, 406);
            this.gridControlStuInfo.TabIndex = 0;
            this.gridControlStuInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8});
            this.gridView1.GridControl = this.gridControlStuInfo;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "学号";
            this.gridColumn1.FieldName = "Sno";
            this.gridColumn1.MinWidth = 25;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 140;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "姓名";
            this.gridColumn2.FieldName = "Sname";
            this.gridColumn2.MinWidth = 25;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 132;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "性别";
            this.gridColumn3.FieldName = "Ssex";
            this.gridColumn3.MinWidth = 25;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 95;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "民族";
            this.gridColumn4.FieldName = "Sethnic";
            this.gridColumn4.MinWidth = 25;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 109;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "籍贯";
            this.gridColumn5.FieldName = "Shome";
            this.gridColumn5.MinWidth = 25;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 157;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "生日";
            this.gridColumn6.FieldName = "Sbirth";
            this.gridColumn6.MinWidth = 25;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 147;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "入学年份";
            this.gridColumn7.FieldName = "Syear";
            this.gridColumn7.MinWidth = 25;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.gridColumn7.Width = 93;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "班级";
            this.gridColumn8.FieldName = "ClassName";
            this.gridColumn8.MinWidth = 25;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            this.gridColumn8.Width = 119;
            // 
            // panelControl6
            // 
            this.panelControl6.Controls.Add(this.simpleButtonBack);
            this.panelControl6.Controls.Add(this.simpleButtonUpdateStudentInfo);
            this.panelControl6.Controls.Add(this.simpleButtonDeleteStudent);
            this.panelControl6.Controls.Add(this.simpleButtonAddStudent);
            this.panelControl6.Controls.Add(this.simpleButtonRefresh);
            this.panelControl6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl6.Location = new System.Drawing.Point(246, 539);
            this.panelControl6.Name = "panelControl6";
            this.panelControl6.Size = new System.Drawing.Size(1016, 102);
            this.panelControl6.TabIndex = 8;
            // 
            // simpleButtonBack
            // 
            this.simpleButtonBack.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonBack.ImageOptions.Image")));
            this.simpleButtonBack.Location = new System.Drawing.Point(821, 28);
            this.simpleButtonBack.Name = "simpleButtonBack";
            this.simpleButtonBack.Size = new System.Drawing.Size(127, 47);
            this.simpleButtonBack.TabIndex = 9;
            this.simpleButtonBack.Text = "返回";
            this.simpleButtonBack.Click += new System.EventHandler(this.simpleButtonBack_Click);
            // 
            // simpleButtonUpdateStudentInfo
            // 
            this.simpleButtonUpdateStudentInfo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonUpdateStudentInfo.ImageOptions.Image")));
            this.simpleButtonUpdateStudentInfo.Location = new System.Drawing.Point(68, 28);
            this.simpleButtonUpdateStudentInfo.Name = "simpleButtonUpdateStudentInfo";
            this.simpleButtonUpdateStudentInfo.Size = new System.Drawing.Size(170, 47);
            this.simpleButtonUpdateStudentInfo.TabIndex = 8;
            this.simpleButtonUpdateStudentInfo.Text = "修改学生信息";
            // 
            // simpleButtonDeleteStudent
            // 
            this.simpleButtonDeleteStudent.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonDeleteStudent.ImageOptions.Image")));
            this.simpleButtonDeleteStudent.Location = new System.Drawing.Point(267, 28);
            this.simpleButtonDeleteStudent.Name = "simpleButtonDeleteStudent";
            this.simpleButtonDeleteStudent.Size = new System.Drawing.Size(170, 47);
            this.simpleButtonDeleteStudent.TabIndex = 7;
            this.simpleButtonDeleteStudent.Text = "删除学生信息";
            // 
            // simpleButtonAddStudent
            // 
            this.simpleButtonAddStudent.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonAddStudent.ImageOptions.Image")));
            this.simpleButtonAddStudent.Location = new System.Drawing.Point(466, 28);
            this.simpleButtonAddStudent.Name = "simpleButtonAddStudent";
            this.simpleButtonAddStudent.Size = new System.Drawing.Size(170, 47);
            this.simpleButtonAddStudent.TabIndex = 6;
            this.simpleButtonAddStudent.Text = "添加学生信息";
            // 
            // simpleButtonRefresh
            // 
            this.simpleButtonRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonRefresh.ImageOptions.Image")));
            this.simpleButtonRefresh.Location = new System.Drawing.Point(665, 28);
            this.simpleButtonRefresh.Name = "simpleButtonRefresh";
            this.simpleButtonRefresh.Size = new System.Drawing.Size(127, 47);
            this.simpleButtonRefresh.TabIndex = 5;
            this.simpleButtonRefresh.Text = "刷新";
            this.simpleButtonRefresh.Click += new System.EventHandler(this.simpleButtonRefresh_Click);
            // 
            // FormAdminStudentInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.panelControl6);
            this.Controls.Add(this.panelControl5);
            this.Controls.Add(this.panelControl4);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormAdminStudentInfo";
            this.Text = "教学管理信息系统—管理员端—学生信息管理";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlStuInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).EndInit();
            this.panelControl6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.PanelControl panelControl5;
        private DevExpress.XtraTreeList.TreeList treeListClass;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraGrid.GridControl gridControlStuInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.PanelControl panelControl6;
        private DevExpress.XtraEditors.SimpleButton simpleButtonBack;
        private DevExpress.XtraEditors.SimpleButton simpleButtonUpdateStudentInfo;
        private DevExpress.XtraEditors.SimpleButton simpleButtonDeleteStudent;
        private DevExpress.XtraEditors.SimpleButton simpleButtonAddStudent;
        private DevExpress.XtraEditors.SimpleButton simpleButtonRefresh;
    }
}