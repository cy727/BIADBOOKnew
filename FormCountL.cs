using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BIADBOOK
{
	/// <summary>
	/// FormCountL 的摘要说明。
	/// </summary>
	public class FormCountL : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Data.SqlClient.SqlConnection sqlConn;
		private System.Data.SqlClient.SqlCommand sqlComm;
		private System.Drawing.Printing.PrintDocument pd;
		private System.Data.SqlClient.SqlDataReader sqldr;
		public Font printfont; 
		string[] lines;
		public string strConn;

		private System.Windows.Forms.TreeView booktv;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;


		public FormCountL()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		private void FormCountL_Load(object sender, System.EventArgs e)
		{
			sqlConn.ConnectionString=strConn;
			sqlComm.Connection=sqlConn;

			InitTreeView();
		}

		private void InitTreeView()
		{
			string st1,st2,st3;
			string stt1,stt2,stt3;

			sqlComm.CommandText="SELECT COUNT(*),sum(馆藏量) FROM book";

			sqlConn.Open();
			sqldr=sqlComm.ExecuteReader();
			sqldr.Read();
			st1=sqldr.GetValue(0).ToString();
			stt1=sqldr.GetValue(1).ToString();
			sqldr.Close();


			sqlComm.CommandText="SELECT COUNT(*),sum(馆藏量) FROM book WHERE 图书分类号<>'建' and 图书分类号<>'结' and 图书分类号<>'暖' and 图书分类号<>'卫' and 图书分类号<>'电' and 图书分类号<>'施' and 图书分类号<>'样' and 图书分类号<>'材' and 图书分类号<>'总' and 图书分类号<>'构1' and 图书分类号<>'构2' and 图书分类号<>'构3' and 图书分类号<>'构4' and 图书分类号<>'构5' and 图书分类号<>'结1' and 图书分类号<>'外' and 图书分类号<>'内' and 图书分类号<>'饰' and 图书分类号<>'构'  ";
			sqldr=sqlComm.ExecuteReader();
			sqldr.Read();
			st2=sqldr.GetValue(0).ToString();
			stt2=sqldr.GetValue(1).ToString();
			sqldr.Close();

			sqlComm.CommandText="SELECT COUNT(*),sum(馆藏量) FROM book WHERE 图书分类号='建' or 图书分类号='结' or 图书分类号='暖' or 图书分类号='卫' or 图书分类号='电' or 图书分类号='施' or 图书分类号='样' or 图书分类号='材' or 图书分类号='总' or 图书分类号='构1' or 图书分类号='构2' or 图书分类号='构3' or 图书分类号='构4' or 图书分类号='构5' or 图书分类号='结1' or 图书分类号='外' or 图书分类号='内' or 图书分类号='饰' or 图书分类号='构'";
			sqldr=sqlComm.ExecuteReader();
			sqldr.Read();
			st3=sqldr.GetValue(0).ToString();
			stt3=sqldr.GetValue(1).ToString();
			sqldr.Close();

			booktv.BeginUpdate();
			booktv.Nodes.Clear();

			TreeNode rootNode= new TreeNode(System.DateTime.Now.Year.ToString() +"年"+System.DateTime.Now.Month.ToString()+"月"+System.DateTime.Now.Day.ToString()+"日，图书馆馆藏信息：");
			booktv.Nodes.Add(rootNode);

			TreeNode tnBook1 = new TreeNode("共有图书："+st1+"种，"+stt1+"本（其中有图书"+st2+"种，"+stt2+"本，资料"+st3+"种，"+stt3+"本）");
			rootNode.Nodes.Add(tnBook1);
				
			TreeNode tnBook01 = new TreeNode("");
			rootNode.Nodes.Add(tnBook01);

			sqlComm.CommandText="SELECT COUNT(*),sum(馆藏量) FROM book WHERE 文种号='1' and 图书分类号<>'建' and 图书分类号<>'结' and 图书分类号<>'暖' and 图书分类号<>'卫' and 图书分类号<>'电' and 图书分类号<>'施' and 图书分类号<>'样' and 图书分类号<>'材' and 图书分类号<>'总' and 图书分类号<>'构1' and 图书分类号<>'构2' and 图书分类号<>'构3' and 图书分类号<>'构4' and 图书分类号<>'构5' and 图书分类号<>'结1' and 图书分类号<>'外'  and 图书分类号<>'内' and 图书分类号<>'饰' and 图书分类号<>'构' ";
			sqldr=sqlComm.ExecuteReader();
			sqldr.Read();

			TreeNode tnBook2 = new TreeNode("中文图书："+sqldr.GetValue(0).ToString()+"种，"+sqldr.GetValue(1).ToString()+"本");
			rootNode.Nodes.Add(tnBook2);
			sqldr.Close();

			sqlComm.CommandText="SELECT COUNT(*),sum(馆藏量) FROM book WHERE (文种号 = N'2') AND (图书分类号 NOT LIKE N'建%') AND (图书分类号 NOT LIKE N'结%') AND (图书分类号 NOT LIKE N'暖%') AND (图书分类号 NOT LIKE N'卫%') AND (图书分类号 NOT LIKE N'电%') AND (图书分类号 NOT LIKE N'施%') AND (图书分类号 NOT LIKE N'材%') AND (图书分类号 NOT LIKE N'总%') AND (图书分类号 NOT LIKE N'内%') AND (图书分类号 NOT LIKE N'构%') AND (图书分类号 NOT LIKE N'外%') AND (图书分类号 NOT LIKE N'样%') AND (图书分类号 NOT LIKE N'饰%')";
			sqldr=sqlComm.ExecuteReader();
			sqldr.Read();

			TreeNode tnBook3 = new TreeNode("西文图书："+sqldr.GetValue(0).ToString()+"种，"+sqldr.GetValue(1).ToString()+"本");
			rootNode.Nodes.Add(tnBook3);
			sqldr.Close();

			sqlComm.CommandText="SELECT COUNT(*),sum(馆藏量) FROM book WHERE 文种号='4' and 图书分类号<>'建' and 图书分类号<>'结' and 图书分类号<>'暖' and 图书分类号<>'卫' and 图书分类号<>'电' and 图书分类号<>'施' and 图书分类号<>'样' and 图书分类号<>'材' and 图书分类号<>'总' and 图书分类号<>'构1' and 图书分类号<>'构2' and 图书分类号<>'构3' and 图书分类号<>'构4' and 图书分类号<>'构5' and 图书分类号<>'结1' and 图书分类号<>'外' and 图书分类号<>'内' and 图书分类号<>'饰' and 图书分类号<>'构'  ";
			sqldr=sqlComm.ExecuteReader();
			sqldr.Read();

			TreeNode tnBook4 = new TreeNode("日文图书："+sqldr.GetValue(0).ToString()+"种，"+sqldr.GetValue(1).ToString()+"本");
			rootNode.Nodes.Add(tnBook4);
			sqldr.Close();

			sqlComm.CommandText="SELECT COUNT(*),sum(馆藏量) FROM book WHERE 图书分类号='建' or 图书分类号='结' or 图书分类号='暖' or 图书分类号='卫' or 图书分类号='电' or 图书分类号='施' or 图书分类号='样' or 图书分类号='材' or 图书分类号='总' or 图书分类号='构1' or 图书分类号='构2' or 图书分类号='构3' or 图书分类号='构4' or 图书分类号='构5' or 图书分类号='结1' or 图书分类号='内' or 图书分类号='饰' or 图书分类号='构' and 图书分类号<>'外'";;
			sqldr=sqlComm.ExecuteReader();
			sqldr.Read();

			TreeNode tnBook02 = new TreeNode("");
			rootNode.Nodes.Add(tnBook02);

			TreeNode tnBook5 = new TreeNode("中文资料："+sqldr.GetValue(0).ToString()+"种，"+sqldr.GetValue(1).ToString()+"本");
			rootNode.Nodes.Add(tnBook5);
			sqldr.Close();

			sqlComm.CommandText="SELECT COUNT(*),sum(馆藏量) FROM book WHERE (文种号 = N'2') AND (图书分类号 LIKE N'外%')";
			sqldr=sqlComm.ExecuteReader();
			sqldr.Read();

			TreeNode tnBook6 = new TreeNode("西文资料："+sqldr.GetValue(0).ToString()+"种，"+sqldr.GetValue(1).ToString()+"本");
			rootNode.Nodes.Add(tnBook6);
			sqldr.Close();

			sqlComm.CommandText="SELECT COUNT(*),sum(馆藏量) FROM book WHERE (文种号 = N'4') AND (图书分类号 LIKE N'外%')";
			sqldr=sqlComm.ExecuteReader();
			sqldr.Read();

			TreeNode tnBook7 = new TreeNode("日文资料："+sqldr.GetValue(0).ToString()+"种，"+sqldr.GetValue(1).ToString()+"本");
			rootNode.Nodes.Add(tnBook7);
			sqldr.Close();



			sqlConn.Close();
			booktv.EndUpdate();
			rootNode.Expand();

			makebufferprint();

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
			this.booktv = new System.Windows.Forms.TreeView();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.sqlConn = new System.Data.SqlClient.SqlConnection();
			this.sqlComm = new System.Data.SqlClient.SqlCommand();
			this.pd = new System.Drawing.Printing.PrintDocument();
			this.SuspendLayout();
			// 
			// booktv
			// 
			this.booktv.ImageIndex = -1;
			this.booktv.Location = new System.Drawing.Point(8, 8);
			this.booktv.Name = "booktv";
			this.booktv.SelectedImageIndex = -1;
			this.booktv.Size = new System.Drawing.Size(520, 232);
			this.booktv.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(128, 256);
			this.button1.Name = "button1";
			this.button1.TabIndex = 1;
			this.button1.Text = "打印";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(216, 256);
			this.button2.Name = "button2";
			this.button2.TabIndex = 2;
			this.button2.Text = "打印预览";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(400, 256);
			this.button3.Name = "button3";
			this.button3.TabIndex = 3;
			this.button3.Text = "关 闭";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// pd
			// 
			this.pd.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pd_PrintPage);
			// 
			// FormCountL
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(544, 294);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.booktv);
			this.Name = "FormCountL";
			this.Text = "FormCountL";
			this.Load += new System.EventHandler(this.FormCountL_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void button3_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void makebufferprint()
		{
			ArrayList buffer=new ArrayList();
			//printer

			TreeNode tnroot=booktv.Nodes[0];

			buffer.Add(tnroot.Text);

			foreach(TreeNode tns in tnroot.Nodes)
			{
				buffer.Add("--"+tns.Text);
			}
			

			lines=(string[])buffer.ToArray(typeof(string));
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			pd.DocumentName="统计报表";
			pd.DefaultPageSettings.Margins=new System.Drawing.Printing.Margins(100,100,100,100);

			
			System.Windows.Forms.PrintDialog plg=new PrintDialog();
			plg.AllowPrintToFile=true;
			plg.AllowSelection=true;
			plg.AllowSomePages=true;
			plg.Document=pd;

			if(plg.ShowDialog()==DialogResult.OK)
			{
				pd.Print();
			
			}

		}

		private void pd_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			int nCount=0 ;
			float fltLines=0;
			float fltYPos=0;

			printfont=new Font("宋体",12F,System.Drawing.FontStyle.Bold);
			
			while(nCount<lines.Length)
			{
				fltYPos=10+(nCount*printfont.GetHeight(e.Graphics));
				e.Graphics.DrawString(lines[nCount],
					printfont,Brushes.Black,100,fltYPos);
				nCount++;
			}

			e.HasMorePages=false;
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			PrintPreviewDialog ppd=new PrintPreviewDialog();


			pd.DocumentName="统计报表";
			pd.DefaultPageSettings.Margins=new System.Drawing.Printing.Margins(100,100,100,100);
			//PrintPreviewControl
			ppd.Document=pd;
			ppd.ShowDialog();
		}

	}
}
