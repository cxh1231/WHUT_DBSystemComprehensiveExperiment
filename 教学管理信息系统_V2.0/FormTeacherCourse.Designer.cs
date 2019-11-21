namespace 教学管理信息系统_V2._0
{
    partial class FormTeacherCourse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTeacherCourse));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlCourse = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleButtonBack = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonAddNewCourse = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonUpdateCourseInfo = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonDeleteCourse = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCourse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
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
            this.panelControl1.Size = new System.Drawing.Size(942, 94);
            this.panelControl1.TabIndex = 4;
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
            this.labelControl1.Text = "教学管理信息系统—我的课程管理";
            // 
            // panelControl2
            // 
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 641);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(942, 32);
            this.panelControl2.TabIndex = 5;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.gridControlCourse);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(0, 94);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(942, 441);
            this.panelControl3.TabIndex = 6;
            // 
            // gridControlCourse
            // 
            this.gridControlCourse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlCourse.Location = new System.Drawing.Point(2, 2);
            this.gridControlCourse.MainView = this.gridView1;
            this.gridControlCourse.Name = "gridControlCourse";
            this.gridControlCourse.Size = new System.Drawing.Size(938, 437);
            this.gridControlCourse.TabIndex = 0;
            this.gridControlCourse.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
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
            this.gridView1.GridControl = this.gridControlCourse;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "课程号";
            this.gridColumn1.FieldName = "Cno";
            this.gridColumn1.MinWidth = 25;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 94;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "课程名";
            this.gridColumn2.FieldName = "Cname";
            this.gridColumn2.MinWidth = 25;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 177;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "课程类型";
            this.gridColumn3.FieldName = "Ctype";
            this.gridColumn3.MinWidth = 25;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 111;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "课程学分";
            this.gridColumn4.FieldName = "Ccredit";
            this.gridColumn4.MinWidth = 25;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "课程状态";
            this.gridColumn5.FieldName = "Cstatus";
            this.gridColumn5.MinWidth = 25;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "课堂容量";
            this.gridColumn6.FieldName = "Cload";
            this.gridColumn6.MinWidth = 25;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 67;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "已选人数";
            this.gridColumn7.FieldName = "Cselected";
            this.gridColumn7.MinWidth = 25;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.gridColumn7.Width = 74;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "课程介绍";
            this.gridColumn8.FieldName = "Cintroduction";
            this.gridColumn8.MinWidth = 25;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            this.gridColumn8.Width = 191;
            // 
            // simpleButtonBack
            // 
            this.simpleButtonBack.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonBack.ImageOptions.Image")));
            this.simpleButtonBack.Location = new System.Drawing.Point(797, 572);
            this.simpleButtonBack.Name = "simpleButtonBack";
            this.simpleButtonBack.Size = new System.Drawing.Size(127, 47);
            this.simpleButtonBack.TabIndex = 9;
            this.simpleButtonBack.Text = "返回";
            this.simpleButtonBack.Click += new System.EventHandler(this.simpleButtonBack_Click);
            // 
            // simpleButtonAddNewCourse
            // 
            this.simpleButtonAddNewCourse.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonAddNewCourse.ImageOptions.Image")));
            this.simpleButtonAddNewCourse.Location = new System.Drawing.Point(12, 572);
            this.simpleButtonAddNewCourse.Name = "simpleButtonAddNewCourse";
            this.simpleButtonAddNewCourse.Size = new System.Drawing.Size(170, 47);
            this.simpleButtonAddNewCourse.TabIndex = 8;
            this.simpleButtonAddNewCourse.Text = "申请开通课程";
            this.simpleButtonAddNewCourse.Click += new System.EventHandler(this.simpleButtonAddNewCourse_Click);
            // 
            // simpleButtonRefresh
            // 
            this.simpleButtonRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonRefresh.ImageOptions.Image")));
            this.simpleButtonRefresh.Location = new System.Drawing.Point(633, 572);
            this.simpleButtonRefresh.Name = "simpleButtonRefresh";
            this.simpleButtonRefresh.Size = new System.Drawing.Size(127, 47);
            this.simpleButtonRefresh.TabIndex = 7;
            this.simpleButtonRefresh.Text = "刷新";
            this.simpleButtonRefresh.Click += new System.EventHandler(this.simpleButtonRefresh_Click);
            // 
            // simpleButtonUpdateCourseInfo
            // 
            this.simpleButtonUpdateCourseInfo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonUpdateCourseInfo.ImageOptions.Image")));
            this.simpleButtonUpdateCourseInfo.Location = new System.Drawing.Point(219, 572);
            this.simpleButtonUpdateCourseInfo.Name = "simpleButtonUpdateCourseInfo";
            this.simpleButtonUpdateCourseInfo.Size = new System.Drawing.Size(170, 47);
            this.simpleButtonUpdateCourseInfo.TabIndex = 11;
            this.simpleButtonUpdateCourseInfo.Text = "修改课程信息";
            // 
            // simpleButtonDeleteCourse
            // 
            this.simpleButtonDeleteCourse.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonDeleteCourse.ImageOptions.Image")));
            this.simpleButtonDeleteCourse.Location = new System.Drawing.Point(426, 572);
            this.simpleButtonDeleteCourse.Name = "simpleButtonDeleteCourse";
            this.simpleButtonDeleteCourse.Size = new System.Drawing.Size(170, 47);
            this.simpleButtonDeleteCourse.TabIndex = 10;
            this.simpleButtonDeleteCourse.Text = "申请删除课程";
            // 
            // FormTeacherCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 673);
            this.Controls.Add(this.simpleButtonDeleteCourse);
            this.Controls.Add(this.simpleButtonBack);
            this.Controls.Add(this.simpleButtonUpdateCourseInfo);
            this.Controls.Add(this.simpleButtonAddNewCourse);
            this.Controls.Add(this.simpleButtonRefresh);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormTeacherCourse";
            this.Text = "教学管理信息系统—教师端—我的课程管理";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCourse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraGrid.GridControl gridControlCourse;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.SimpleButton simpleButtonBack;
        private DevExpress.XtraEditors.SimpleButton simpleButtonAddNewCourse;
        private DevExpress.XtraEditors.SimpleButton simpleButtonRefresh;
        private DevExpress.XtraEditors.SimpleButton simpleButtonUpdateCourseInfo;
        private DevExpress.XtraEditors.SimpleButton simpleButtonDeleteCourse;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
    }
}