using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data ;
using System.Data.SqlClient ;
using System.IO ;
namespace BIADBOOK
{
	/// <summary>
	/// ReaderTag 的摘要说明。
	/// </summary>
	public class ReaderTag : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox3;
	
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TabControl tabControl2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Label ylblBH;
		private System.Windows.Forms.Label ylblSM;
		private System.Windows.Forms.Label ylblWZH;
		private System.Windows.Forms.Label ylblTSFLH;
		private System.Windows.Forms.Label ylblZCH;
		private System.Windows.Forms.Button btnSMseach;
		private System.Windows.Forms.Button btnSSHseach;
		private System.Windows.Forms.TextBox txtSM;
		private System.Windows.Forms.TextBox txtWZH;
		private System.Windows.Forms.TextBox txtTSFLH;
		private System.Windows.Forms.TextBox txtZCH;
		private System.Windows.Forms.Button btnPrint;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private string ConnSt="";
		public ReaderTag()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}
		//重载构造,需求数据库连接字符串
		public ReaderTag(string connStr)
		{
			this.ConnSt =connStr.Trim ();
			InitializeComponent();
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.btnSMseach = new System.Windows.Forms.Button();
			this.btnSSHseach = new System.Windows.Forms.Button();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.tabControl2 = new System.Windows.Forms.TabControl();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.txtSM = new System.Windows.Forms.TextBox();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.txtZCH = new System.Windows.Forms.TextBox();
			this.txtTSFLH = new System.Windows.Forms.TextBox();
			this.txtWZH = new System.Windows.Forms.TextBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.ylblZCH = new System.Windows.Forms.Label();
			this.ylblTSFLH = new System.Windows.Forms.Label();
			this.ylblWZH = new System.Windows.Forms.Label();
			this.ylblSM = new System.Windows.Forms.Label();
			this.ylblBH = new System.Windows.Forms.Label();
			this.btnPrint = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabControl2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(8, 16);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(144, 208);
			this.tabControl1.TabIndex = 7;
			// 
			// tabPage1
			// 
			this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tabPage1.Controls.Add(this.button1);
			this.tabPage1.Controls.Add(this.textBox1);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Location = new System.Drawing.Point(4, 21);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(136, 183);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "按书名";
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Location = new System.Drawing.Point(8, 96);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(120, 24);
			this.button1.TabIndex = 2;
			this.button1.Text = "查找";
			// 
			// textBox1
			// 
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox1.Location = new System.Drawing.Point(8, 24);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(120, 64);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "textBox1";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "书名:";
			// 
			// tabPage2
			// 
			this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tabPage2.Controls.Add(this.textBox3);
			this.tabPage2.Controls.Add(this.textBox2);
			this.tabPage2.Controls.Add(this.label4);
			this.tabPage2.Controls.Add(this.label3);
			this.tabPage2.Controls.Add(this.label2);
			this.tabPage2.Location = new System.Drawing.Point(4, 21);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(136, 183);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "按索书号";
			// 
			// textBox3
			// 
			this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox3.Location = new System.Drawing.Point(8, 152);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(120, 21);
			this.textBox3.TabIndex = 5;
			this.textBox3.Text = "textBox3";
			// 
			// textBox2
			// 
			this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox2.Location = new System.Drawing.Point(8, 72);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(120, 40);
			this.textBox2.TabIndex = 4;
			this.textBox2.Text = "textBox2";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 56);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 16);
			this.label4.TabIndex = 2;
			this.label4.Text = "图书分类号:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 128);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 16);
			this.label3.TabIndex = 1;
			this.label3.Text = "种次号:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 16);
			this.label2.TabIndex = 0;
			this.label2.Text = "文种号:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tabControl1);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(160, 232);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(40, 16);
			this.label5.TabIndex = 0;
			this.label5.Text = "书名:";
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label6.Location = new System.Drawing.Point(8, 16);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(48, 16);
			this.label6.TabIndex = 1;
			this.label6.Text = "文种号:";
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label7.Location = new System.Drawing.Point(8, 40);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(80, 16);
			this.label7.TabIndex = 2;
			this.label7.Text = "图书分类号:";
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label8.Location = new System.Drawing.Point(8, 64);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(48, 16);
			this.label8.TabIndex = 3;
			this.label8.Text = "种次号:";
			// 
			// btnSMseach
			// 
			this.btnSMseach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSMseach.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btnSMseach.Location = new System.Drawing.Point(296, 56);
			this.btnSMseach.Name = "btnSMseach";
			this.btnSMseach.Size = new System.Drawing.Size(88, 24);
			this.btnSMseach.TabIndex = 8;
			this.btnSMseach.Text = "查找";
			this.btnSMseach.Click += new System.EventHandler(this.btnSMseach_Click);
			// 
			// btnSSHseach
			// 
			this.btnSSHseach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSSHseach.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btnSSHseach.Location = new System.Drawing.Point(296, 56);
			this.btnSSHseach.Name = "btnSSHseach";
			this.btnSSHseach.Size = new System.Drawing.Size(88, 24);
			this.btnSSHseach.TabIndex = 9;
			this.btnSSHseach.Text = "查找";
			this.btnSSHseach.Click += new System.EventHandler(this.btnSSHseach_Click);
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label10.Location = new System.Drawing.Point(8, 72);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(96, 16);
			this.label10.TabIndex = 12;
			this.label10.Text = "图书分类号:";
			// 
			// label11
			// 
			this.label11.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label11.Location = new System.Drawing.Point(8, 96);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(64, 16);
			this.label11.TabIndex = 13;
			this.label11.Text = "种次号:";
			// 
			// label12
			// 
			this.label12.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label12.Location = new System.Drawing.Point(128, 24);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(56, 16);
			this.label12.TabIndex = 14;
			this.label12.Text = "书名:";
			// 
			// label13
			// 
			this.label13.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label13.Location = new System.Drawing.Point(8, 24);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(48, 16);
			this.label13.TabIndex = 15;
			this.label13.Text = "编号:";
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label9.Location = new System.Drawing.Point(8, 48);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(64, 16);
			this.label9.TabIndex = 11;
			this.label9.Text = "文种号:";
			// 
			// tabControl2
			// 
			this.tabControl2.Controls.Add(this.tabPage3);
			this.tabControl2.Controls.Add(this.tabPage4);
			this.tabControl2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.tabControl2.Location = new System.Drawing.Point(8, 8);
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.SelectedIndex = 0;
			this.tabControl2.Size = new System.Drawing.Size(400, 120);
			this.tabControl2.TabIndex = 16;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.txtSM);
			this.tabPage3.Controls.Add(this.btnSMseach);
			this.tabPage3.Controls.Add(this.label5);
			this.tabPage3.Location = new System.Drawing.Point(4, 25);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(392, 91);
			this.tabPage3.TabIndex = 0;
			this.tabPage3.Text = "按书名查找";
			// 
			// txtSM
			// 
			this.txtSM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtSM.Location = new System.Drawing.Point(56, 16);
			this.txtSM.MaxLength = 100;
			this.txtSM.Multiline = true;
			this.txtSM.Name = "txtSM";
			this.txtSM.Size = new System.Drawing.Size(232, 64);
			this.txtSM.TabIndex = 9;
			this.txtSM.Text = "";
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.txtZCH);
			this.tabPage4.Controls.Add(this.txtTSFLH);
			this.tabPage4.Controls.Add(this.txtWZH);
			this.tabPage4.Controls.Add(this.label6);
			this.tabPage4.Controls.Add(this.label7);
			this.tabPage4.Controls.Add(this.label8);
			this.tabPage4.Controls.Add(this.btnSSHseach);
			this.tabPage4.Location = new System.Drawing.Point(4, 25);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(392, 91);
			this.tabPage4.TabIndex = 1;
			this.tabPage4.Text = "按索书号查找";
			// 
			// txtZCH
			// 
			this.txtZCH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtZCH.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtZCH.Location = new System.Drawing.Point(88, 56);
			this.txtZCH.MaxLength = 4;
			this.txtZCH.Name = "txtZCH";
			this.txtZCH.Size = new System.Drawing.Size(152, 23);
			this.txtZCH.TabIndex = 12;
			this.txtZCH.Text = "";
			// 
			// txtTSFLH
			// 
			this.txtTSFLH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtTSFLH.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtTSFLH.Location = new System.Drawing.Point(88, 32);
			this.txtTSFLH.MaxLength = 8;
			this.txtTSFLH.Name = "txtTSFLH";
			this.txtTSFLH.Size = new System.Drawing.Size(192, 23);
			this.txtTSFLH.TabIndex = 11;
			this.txtTSFLH.Text = "";
			// 
			// txtWZH
			// 
			this.txtWZH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtWZH.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtWZH.Location = new System.Drawing.Point(88, 8);
			this.txtWZH.MaxLength = 1;
			this.txtWZH.Name = "txtWZH";
			this.txtWZH.Size = new System.Drawing.Size(104, 23);
			this.txtWZH.TabIndex = 10;
			this.txtWZH.Text = "";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.ylblZCH);
			this.groupBox4.Controls.Add(this.ylblTSFLH);
			this.groupBox4.Controls.Add(this.ylblWZH);
			this.groupBox4.Controls.Add(this.ylblSM);
			this.groupBox4.Controls.Add(this.ylblBH);
			this.groupBox4.Controls.Add(this.label9);
			this.groupBox4.Controls.Add(this.label10);
			this.groupBox4.Controls.Add(this.label13);
			this.groupBox4.Controls.Add(this.label11);
			this.groupBox4.Controls.Add(this.label12);
			this.groupBox4.Controls.Add(this.btnPrint);
			this.groupBox4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.groupBox4.Location = new System.Drawing.Point(16, 136);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(384, 120);
			this.groupBox4.TabIndex = 17;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "预览";
			// 
			// ylblZCH
			// 
			this.ylblZCH.Location = new System.Drawing.Point(104, 96);
			this.ylblZCH.Name = "ylblZCH";
			this.ylblZCH.Size = new System.Drawing.Size(136, 16);
			this.ylblZCH.TabIndex = 25;
			this.ylblZCH.Text = "ylblZCH";
			// 
			// ylblTSFLH
			// 
			this.ylblTSFLH.Location = new System.Drawing.Point(104, 72);
			this.ylblTSFLH.Name = "ylblTSFLH";
			this.ylblTSFLH.Size = new System.Drawing.Size(168, 16);
			this.ylblTSFLH.TabIndex = 24;
			this.ylblTSFLH.Text = "ylblTSFLH";
			// 
			// ylblWZH
			// 
			this.ylblWZH.Location = new System.Drawing.Point(104, 48);
			this.ylblWZH.Name = "ylblWZH";
			this.ylblWZH.Size = new System.Drawing.Size(144, 16);
			this.ylblWZH.TabIndex = 23;
			this.ylblWZH.Text = "ylblWZH";
			// 
			// ylblSM
			// 
			this.ylblSM.Location = new System.Drawing.Point(176, 24);
			this.ylblSM.Name = "ylblSM";
			this.ylblSM.Size = new System.Drawing.Size(200, 16);
			this.ylblSM.TabIndex = 22;
			this.ylblSM.Text = "ylblSM";
			// 
			// ylblBH
			// 
			this.ylblBH.Location = new System.Drawing.Point(56, 24);
			this.ylblBH.Name = "ylblBH";
			this.ylblBH.Size = new System.Drawing.Size(64, 16);
			this.ylblBH.TabIndex = 21;
			this.ylblBH.Text = "ylblBH";
			// 
			// btnPrint
			// 
			this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPrint.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btnPrint.Location = new System.Drawing.Point(296, 88);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new System.Drawing.Size(80, 24);
			this.btnPrint.TabIndex = 20;
			this.btnPrint.Text = "打印...";
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(8, 128);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(400, 136);
			this.button4.TabIndex = 19;
			this.button4.Text = "button4";
			// 
			// ReaderTag
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(416, 269);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.tabControl2);
			this.Controls.Add(this.button4);
			this.Name = "ReaderTag";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "查找打印书签";
			this.Load += new System.EventHandler(this.ReaderTag_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.tabControl2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

	
		//	打印
		private void ReaderTag_Load(object sender, System.EventArgs e)
		{
			try
			{
				string SysPath;
				SysPath=Directory.GetCurrentDirectory().ToString()+"\\Config.ini";
				//判断Config.ini文件是否存在
				if(File.Exists(SysPath))
				{
					//截入Config.ini文件中的各参数
					IniFile ini = new IniFile(SysPath);
					//[DataBase]ConnectionString
					if(ini.IniReadValue("DataBase","ConnectionString")!="")
					{ 
						this.ConnSt=ini.IniReadValue("DataBase","ConnectionString").Trim(); 
					}
				}
				NullFormContrl();
			}
			catch{}
		}
		//按索书号查找
		private void btnSSHseach_Click(object sender, System.EventArgs e)
		{
			try
			{
				NullFormContrl();
				string selectSSH="select * from book where 文种号='"+this.txtWZH .Text .Trim()+"' and 图书分类号='"+this.txtTSFLH .Text .Trim ()+"' and 种次号='"+this.txtZCH .Text .Trim ()+"'";
				ExeSql(selectSSH.Trim ());
			}
			catch{}
		}
		//按书名查找
		private void btnSMseach_Click(object sender, System.EventArgs e)
		{
			try
			{
				NullFormContrl();
				string selectSM="select * from book where 书名='"+this.txtSM .Text .Trim ()+"'";
				ExeSql(selectSM.Trim ());
			}
			catch{}
		}

		private void ExeSql(string Sql)
		{
			try
			{
				SqlConnection cnn=new SqlConnection (this.ConnSt );
				SqlCommand cmd =new SqlCommand(Sql.Trim (),cnn);
				SqlDataReader DR;
				cnn.Open ();
				DR=cmd.ExecuteReader ();
				while(DR.Read ())
				{
					this.ylblBH .Text =DR["ID"].ToString ();
					this.ylblSM .Text =DR["书名"].ToString ();
					this.ylblWZH .Text =DR["文种号"].ToString ();
					this.ylblTSFLH .Text =DR["图书分类号"].ToString ();
					this.ylblZCH .Text =DR["种次号"].ToString ();
				}
				cnn.Close ();
			}
			catch(Exception es){MessageBox.Show (es.ToString ());}

		}

		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			PrintBarCode temp=new PrintBarCode(this.ylblWZH.Text .Trim (),this.ylblTSFLH .Text .Trim (),this.ylblZCH .Text .Trim ());//(文种号(1),图书分类号(8),种次号(4)
			temp.ShowDialog ();
		}
	
		private void NullFormContrl()
		{
			this.ylblWZH .Text ="";
			this.ylblZCH.Text ="";
			this.ylblTSFLH .Text ="";
			this.ylblSM .Text ="";
			this.ylblBH .Text ="";

		}

	
	}
}
