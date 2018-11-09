using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data ;
using System.Data .SqlClient ;
using System.IO;

namespace BIADBOOK
{
	/// <summary>
	/// QueryRFIDBook 的摘要说明。
	/// </summary>
	public class QueryRFIDBook : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public QueryRFIDBook()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		
		private string wzh="";
		private string tsflh="";
		private string zch="";

		public QueryRFIDBook(string WZH,string TSFLH,string ZCH)
		{
			this.wzh =WZH.Trim ();
			this.tsflh =TSFLH.Trim ();
			this.zch =ZCH.Trim ();
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
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.button1 = new System.Windows.Forms.Button();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// listView1
			// 
			this.listView1.AllowColumnReorder = true;
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader1,
																						this.columnHeader2,
																						this.columnHeader3,
																						this.columnHeader4,
																						this.columnHeader5});
			this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(8, 8);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(496, 152);
			this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.listView1.TabIndex = 0;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "编号";
			this.columnHeader1.Width = 110;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "书名";
			this.columnHeader2.Width = 129;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "位架编号";
			this.columnHeader3.Width = 102;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "书架";
			this.columnHeader4.Width = 77;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(184, 168);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(152, 32);
			this.button1.TabIndex = 1;
			this.button1.Text = "退出";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "阅览室";
			this.columnHeader5.Width = 73;
			// 
			// QueryRFIDBook
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(512, 206);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.listView1);
			this.Name = "QueryRFIDBook";
			this.Text = "按索书号明细";
			this.Load += new System.EventHandler(this.QueryRFIDBook_Load);
			this.ResumeLayout(false);

		}
		#endregion
		private string ConnectionStr="";
		
		private void QueryRFIDBook_Load(object sender, System.EventArgs e)
		{
			try
			{
				string QPath;
				QPath=Directory.GetCurrentDirectory().ToString()+"\\Config.ini";
				//判断Config.ini文件是否存在
				if(File.Exists(QPath))
				{
					//截入Config.ini文件中的各参数
					IniFile ini = new IniFile(QPath);
					//[DataBase]ConnectionString
					if(ini.IniReadValue("DataBase","ConnectionString")!="")
					{ 
						this.ConnectionStr=ini.IniReadValue("DataBase","ConnectionString").Trim(); 
					}
				}
				/////////////////////////////////////////////////////////////////////////
				this.RefreshBookList ();
			}
			catch{}

		}
		//根据文种号,图书分类号，种次号查找<图书明细>表中的记录
		public void RefreshBookList()
		{
			try
			{
				string select="";
				this.Cursor = Cursors.WaitCursor;
				select="select BarCode,BookLocationId,BookLocationInfo,BookRoomInfo,BookId,书名,并列提名,副提名,出版地,出版者,出版日期,页数,开本,附件,价格, 附注,文种号,图书分类号,种次号,年代顺序号, 入库日期,馆藏量,借出次数,借出书量,拒借次数,拒借标记,有效规范,失效规范, 指针, 内容提要  FROM 图书明细 where 文种号='"+wzh.Trim ()+"' and 图书分类号='"+tsflh.Trim ()+"' and 种次号='"+zch.Trim ()+"'";

				SqlConnection conn =new SqlConnection (this.ConnectionStr.Trim ());
				SqlCommand cmd=new SqlCommand (select.Trim (),conn);
				SqlDataReader DR;
				ListViewItem lvi;
				int i=0;
				listView1.Items .Clear ();
				conn.Open ();
				DR=cmd.ExecuteReader ();
				while(DR.Read ())
				{
					lvi = new ListViewItem(DR["BarCode"].ToString ());
					lvi.Tag =DR["BarCode"].ToString ();
					lvi.SubItems .Add (DR["书名"].ToString ());

					lvi.SubItems .Add (DR["BookLocationId"].ToString ());
					lvi.SubItems.Add  (DR["BookLocationInfo"].ToString ());
					lvi.SubItems.Add (DR["BookRoomInfo"].ToString ());
				

					listView1.Items.Add (lvi);

					i=i+1;
				}
				conn.Close ();
				this.Cursor = Cursors.Default;
			}
			catch{}
			//listViewitem


		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			this.Close ();
		}
	}
}
