using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO ;
using System.Data ;
using System.Data .SqlClient ;


namespace BIADBOOK
{
	/// <summary>
	/// frmBookLocationManager 的摘要说明。
	/// </summary>
	public class frmBookLocationManager : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.ListView viewProducts;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblTotel;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnNew;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Data.DataSet dataSet1;
		private System.Windows.Forms.Label label3;
		private string ConnStr;
		public frmBookLocationManager()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
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
			System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
																													 "11234",
																													 "2",
																													 "3"}, -1);
			System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
																													 "sdfs",
																													 "sdf",
																													 "sdf"}, -1);
			this.btnSave = new System.Windows.Forms.Button();
			this.viewProducts = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.lblTotel = new System.Windows.Forms.Label();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnNew = new System.Windows.Forms.Button();
			this.dataSet1 = new System.Data.DataSet();
			this.label3 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
			this.SuspendLayout();
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(504, 312);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(72, 24);
			this.btnSave.TabIndex = 11;
			this.btnSave.Text = "退出";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// viewProducts
			// 
			this.viewProducts.AllowColumnReorder = true;
			this.viewProducts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.viewProducts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						   this.columnHeader1,
																						   this.columnHeader2,
																						   this.columnHeader3});
			this.viewProducts.FullRowSelect = true;
			this.viewProducts.GridLines = true;
			this.viewProducts.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.viewProducts.HideSelection = false;
			listViewItem1.Tag = "123";
			listViewItem2.Tag = "adf";
			this.viewProducts.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
																						 listViewItem1,
																						 listViewItem2});
			this.viewProducts.Location = new System.Drawing.Point(8, 40);
			this.viewProducts.Name = "viewProducts";
			this.viewProducts.Size = new System.Drawing.Size(442, 244);
			this.viewProducts.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.viewProducts.TabIndex = 12;
			this.viewProducts.View = System.Windows.Forms.View.Details;
			this.viewProducts.Click += new System.EventHandler(this.viewProducts_Click);
			this.viewProducts.DoubleClick += new System.EventHandler(this.viewProducts_DoubleClick);
			this.viewProducts.SelectedIndexChanged += new System.EventHandler(this.viewProducts_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "书架编号";
			this.columnHeader1.Width = 70;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "书架位置";
			this.columnHeader2.Width = 135;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "房间信息";
			this.columnHeader3.Width = 220;
			// 
			// label2
			// 
			this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label2.Location = new System.Drawing.Point(8, 296);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(572, 2);
			this.label2.TabIndex = 13;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 16);
			this.label1.TabIndex = 14;
			this.label1.Text = "书架信息";
			// 
			// lblTotel
			// 
			this.lblTotel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblTotel.Location = new System.Drawing.Point(344, 16);
			this.lblTotel.Name = "lblTotel";
			this.lblTotel.Size = new System.Drawing.Size(100, 16);
			this.lblTotel.TabIndex = 15;
			this.lblTotel.Text = "label3";
			// 
			// btnEdit
			// 
			this.btnEdit.Location = new System.Drawing.Point(464, 72);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(116, 23);
			this.btnEdit.TabIndex = 18;
			this.btnEdit.TabStop = false;
			this.btnEdit.Text = "修改";
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(464, 104);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(116, 23);
			this.btnDelete.TabIndex = 17;
			this.btnDelete.TabStop = false;
			this.btnDelete.Text = "删除";
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnNew
			// 
			this.btnNew.Location = new System.Drawing.Point(464, 40);
			this.btnNew.Name = "btnNew";
			this.btnNew.Size = new System.Drawing.Size(116, 23);
			this.btnNew.TabIndex = 16;
			this.btnNew.TabStop = false;
			this.btnNew.Text = "添加";
			this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
			// 
			// dataSet1
			// 
			this.dataSet1.DataSetName = "NewDataSet";
			this.dataSet1.Locale = new System.Globalization.CultureInfo("zh-CN");
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label3.Location = new System.Drawing.Point(256, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 16);
			this.label3.TabIndex = 21;
			this.label3.Text = "记录总数:";
			// 
			// frmBookLocationManager
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(584, 346);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btnEdit);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnNew);
			this.Controls.Add(this.lblTotel);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.viewProducts);
			this.Controls.Add(this.btnSave);
			this.Name = "frmBookLocationManager";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "书架信息维护";
			this.Load += new System.EventHandler(this.frmBookLocationManager_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
		
		}

		private void frmBookLocationManager_Load(object sender, System.EventArgs e)
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
						this.ConnStr=ini.IniReadValue("DataBase","ConnectionString").Trim(); 
					}
				}
				/////////////////////////////////////////////////////////////////////////
				RefreshBookList();
			}
			catch{}
		}
		private void RefreshBookList()
		{
			try
			{
				SqlConnection conn =new SqlConnection (this.ConnStr .Trim ());
				SqlCommand cmd=new SqlCommand ("select * from BookLocation",conn);
				SqlDataReader DR;
				ListViewItem lvi;
				int i=0;
				viewProducts.Items .Clear ();
				conn.Open ();
				DR=cmd.ExecuteReader ();
				while(DR.Read ())
				{
					lvi = new ListViewItem(DR["BookLocationId"].ToString ());
					lvi.Tag =DR["BookLocationId"].ToString ();
					lvi.SubItems.Add  (DR["BookLocationInfo"].ToString ());
					lvi.SubItems.Add (DR["BookRoomInfo"].ToString ());
					viewProducts.Items.Add (lvi);
					i=i+1;
				}
				conn.Close ();
				lblTotel.Text =i.ToString ();
			}
			catch{}
			//listViewitem


		}

		private void viewProducts_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void viewProducts_Click(object sender, System.EventArgs e)
		{
		
		}

		private void viewProducts_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
				ListViewItem lvi = viewProducts.FocusedItem;
				frmBookListInfo fBLI=new frmBookListInfo (lvi.Text,lvi.SubItems[1].Text,lvi.SubItems [2].Text ,"update",this);
				fBLI.ShowDialog ();
				//MessageBox.Show (lvi.Text.ToString () ,lvi.Tag.ToString () );
			}
			catch{}
		}

		private void btnNew_Click(object sender, System.EventArgs e)
		{
			try
			{
				//ListViewItem lvi = viewProducts.FocusedItem;
				frmBookListInfo fBLI=new frmBookListInfo ("","","","add",this);
				fBLI.ShowDialog();
			}
			catch{}
		}

		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			try
			{
				ListViewItem lvi = viewProducts.FocusedItem;
				frmBookListInfo fBLI=new frmBookListInfo (lvi.Text,lvi.SubItems[1].Text,lvi.SubItems [2].Text ,"update",this);
				fBLI.ShowDialog ();
			}
			catch{}
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			try{
				ListViewItem lvi = viewProducts.FocusedItem;
				MessageBoxButtons buttons = MessageBoxButtons.YesNo;
				DialogResult result;
				result = MessageBox.Show("删除记录:"+lvi.Text ,"提示",buttons);

				if(result == DialogResult.Yes)
				{
					string sql="delete BookLocation where BookLocationId='"+lvi.Text .Trim ()+"'";
					this.ExeSql (sql);
				}
				this.RefreshBookList ();
			}
			catch{}
		}
		public void ExeSql(string Sql)
		{
			try
			{
				SqlConnection cnn=new SqlConnection (this.ConnStr.Trim ());
				SqlCommand cmd =new SqlCommand(Sql.Trim (),cnn);
				
				cnn.Open ();
				cmd.ExecuteNonQuery ();
				cnn.Close ();
				this.RefreshBookList ();
			}
			catch(Exception es){MessageBox.Show (es.ToString ());}

		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			this.Close ();
		}
	}
}
