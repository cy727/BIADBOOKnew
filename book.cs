using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.Data.OracleClient;

namespace BIADBOOK
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class library : System.Windows.Forms.Form
	{
		private System.Windows.Forms.StatusBar sBar;
		private System.Windows.Forms.MainMenu bookMenu;
		private System.Windows.Forms.ToolBar tBar;
		private System.Windows.Forms.ImageList iList1;
		private System.Windows.Forms.ToolBarButton tBarButton6;
		private System.Windows.Forms.Timer btimer;
		private System.Windows.Forms.StatusBarPanel sbp1;
		private System.Windows.Forms.StatusBarPanel sbp2;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.TreeView tv;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.DataGrid dg;
		public System.Data.SqlClient.SqlConnection sqlConn;
		private System.Data.SqlClient.SqlDataAdapter sDAdapter;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		private BIADBOOK.dsBook dsBook1;
		//private bool bDataLoaded = false;
		private System.Windows.Forms.MenuItem miMange;
		private System.Windows.Forms.MenuItem miDetail;
		private DataView dv;
		public string strC1="",strC2="",strC3="";
		private System.Windows.Forms.MenuItem MiBor;
		private System.Windows.Forms.MenuItem MiHelp;
		private System.Windows.Forms.MenuItem miAbout;
		private System.Windows.Forms.MenuItem miBo;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem miQb;
		//public string strConn,strhrConn,OracleconnString;

        public string strConn, strhrConn;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem miRFID;
		private System.Windows.Forms.MenuItem miSJWH;
		private System.Windows.Forms.MenuItem miSearch;
		private System.Windows.Forms.MenuItem miReader;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem miSave;

        


		private void PopulateTreeView()
		{
			string sttw,stts;


			tv.BeginUpdate();
			tv.Nodes.Clear();

			TreeNode rootNode= new TreeNode("建院图书馆",5,5);

			TreeNode rnbook = new TreeNode("图书",5,5);
			rootNode.Nodes.Add(rnbook);
			TreeNode rndocu = new TreeNode("资料",5,5);
			rootNode.Nodes.Add(rndocu);

			TreeNode rnbookc = new TreeNode("中文图书",5,5);
			rnbook.Nodes.Add(rnbookc);
			TreeNode rnbookw = new TreeNode("西文图书",5,5);
			rnbook.Nodes.Add(rnbookw);
			TreeNode rnbookj = new TreeNode("日文图书",5,5);
			rnbook.Nodes.Add(rnbookj);

			TreeNode rndocuc = new TreeNode("中文资料",5,5);
			rndocu.Nodes.Add(rndocuc);
			TreeNode rndocuw = new TreeNode("西文资料",5,5);
			rndocu.Nodes.Add(rndocuw);
			TreeNode rndocuj = new TreeNode("日文资料",5,5);
			rndocu.Nodes.Add(rndocuj);
			
			DataTable tableBook;
			tableBook=dsBook1.Tables["book"];
			



			foreach( DataRow row in tableBook.Rows)
			{
				//rootNode.Nodes.Add(tnBook);
				TreeNode tnBook = new TreeNode(row["书名"].ToString(),0,1);
				TreeNode tnwzh = new TreeNode("文种号："+row["文种号"].ToString(),2,2);
				TreeNode tntsflh = new TreeNode("图书分类号："+row["图书分类号"].ToString(),3,3);
				TreeNode tnzch = new TreeNode("种次号："+row["种次号"].ToString(),4,4);

				
				sttw=row["文种号"].ToString();
				stts=row["图书分类号"].ToString();
				switch(sttw)
				{
					case "1":
						if(stts=="建" || stts=="结" || stts=="暖" || stts=="卫" || stts=="电" || stts=="施" || stts=="材" || stts=="样" || stts=="总" || stts=="内" || stts=="饰" || stts=="构" || stts=="构1" || stts=="构2" || stts=="构3" || stts=="构4" || stts=="构5" || stts=="结1" || stts=="结")
						{
							rndocuc.Nodes.Add(tnBook);

						}
						else
						{
							rnbookc.Nodes.Add(tnBook);
						}
						break;
					case "2":
						if(stts=="外")
						{
							rndocuw.Nodes.Add(tnBook);
						}
						else
						{
							rnbookw.Nodes.Add(tnBook);
						}
						break;
					case "4":
						if(stts=="外")
						{
							rndocuj.Nodes.Add(tnBook);
						}
						else
						{
							rnbookj.Nodes.Add(tnBook);
						}
						break;

				}

				tnBook.Nodes.Add(tnwzh);
				tnBook.Nodes.Add(tntsflh);
				tnBook.Nodes.Add(tnzch);

			}

			
			rnbook.Expand();
			rndocu.Expand();
			rnbookc.Expand();
			//rnbookw.Expand();
			//rnbookj.Expand();

			tv.Nodes.Add(rootNode);


			tv.EndUpdate();
			tv.Nodes[0].Expand();

			tv.Nodes[0].Nodes[1].Nodes[2].EnsureVisible();

		}


		
		private System.ComponentModel.IContainer components;

		public library()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			//strConn="workstation id=MP-LIU;packet size=4096;integrated security=SSPI;data source=.;persist security info=False;initial catalog=library";
		
		//	strConn="workstation id=home;packet size=4096;integrated security=SSPI;data source=.;persist security info=False;initial catalog=library";
			strConn="workstation id=CHENYI;packet size=4096;user id=sa;password=biadlib2004;data source=\"172.16.0.11\";;initial catalog=library";

			//strhrConn="workstation id=CHENYI;packet size=4096;user id=sa;password=icone;data source=\"172.16.0.136\";persist security info=False;initial catalog=ecard";

            strhrConn = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=172.16.5.192) (PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=orcl)));Persist Security Info=True;User Id=NCHR; Password=NCHR";

            //OracleConn = new OracleConnection(OracleconnString);

            //try
            //{
            //    OracleConn.Open();//打开指定的连接                  
            //    OracleCommand com = OracleConn.CreateCommand();
            //    com.CommandText = "select * FROM V_SYS_PSN ";//写好想执行的Sql语句                  
            //    OracleDataReader odr = com.ExecuteReader();
            //    while (odr.Read())//读取数据，如果返回为false的话，就说明到记录集的尾部了                   
            //    {
            //        MessageBox.Show(odr.GetValue(4).ToString());
            //        break;
            //    }
            //    odr.Close();//关闭reader.这是一定要写的 
            //}
            //catch
            //{
            //    MessageBox.Show("erro");//如果发生异常，则提示出错             
            //}
            //finally
            //{
            //    OracleConn.Close();//关闭打开的连接             
            //}


			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//			
			InitializeComponent();

			sqlConn.ConnectionString=strConn;

			dv= new DataView();

			//sDAdapter.Fill(dsBook1);
			BookReadLibrary();


		}

		private void BookReadLibrary()
		{
			this.Cursor=Cursors.WaitCursor;
            //sBar.Text=""
			dsBook1.Clear();
			sDAdapter.Fill(dsBook1);
			PopulateTreeView();
			this.Cursor=Cursors.Arrow;
            
		}


		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(library));
            this.sBar = new System.Windows.Forms.StatusBar();
            this.sbp1 = new System.Windows.Forms.StatusBarPanel();
            this.sbp2 = new System.Windows.Forms.StatusBarPanel();
            this.bookMenu = new System.Windows.Forms.MainMenu(this.components);
            this.miMange = new System.Windows.Forms.MenuItem();
            this.miDetail = new System.Windows.Forms.MenuItem();
            this.miSave = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.MiBor = new System.Windows.Forms.MenuItem();
            this.miBo = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.miQb = new System.Windows.Forms.MenuItem();
            this.MiHelp = new System.Windows.Forms.MenuItem();
            this.miAbout = new System.Windows.Forms.MenuItem();
            this.miRFID = new System.Windows.Forms.MenuItem();
            this.miSJWH = new System.Windows.Forms.MenuItem();
            this.miSearch = new System.Windows.Forms.MenuItem();
            this.miReader = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.tBar = new System.Windows.Forms.ToolBar();
            this.tBarButton6 = new System.Windows.Forms.ToolBarButton();
            this.iList1 = new System.Windows.Forms.ImageList(this.components);
            this.btimer = new System.Windows.Forms.Timer(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tv = new System.Windows.Forms.TreeView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.dg = new System.Windows.Forms.DataGrid();
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.sDAdapter = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.dsBook1 = new BIADBOOK.dsBook();
            ((System.ComponentModel.ISupportInitialize)(this.sbp1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbp2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBook1)).BeginInit();
            this.SuspendLayout();
            // 
            // sBar
            // 
            this.sBar.Location = new System.Drawing.Point(0, 523);
            this.sBar.Name = "sBar";
            this.sBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.sbp1,
            this.sbp2});
            this.sBar.ShowPanels = true;
            this.sBar.Size = new System.Drawing.Size(792, 22);
            this.sBar.TabIndex = 0;
            // 
            // sbp1
            // 
            this.sbp1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.sbp1.Name = "sbp1";
            this.sbp1.Text = "北京市建筑设计研究院 图书管理 就绪.....";
            this.sbp1.Width = 675;
            // 
            // sbp2
            // 
            this.sbp2.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.sbp2.Name = "sbp2";
            // 
            // bookMenu
            // 
            this.bookMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miMange,
            this.MiBor,
            this.MiHelp,
            this.miRFID});
            // 
            // miMange
            // 
            this.miMange.Index = 0;
            this.miMange.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miDetail,
            this.miSave,
            this.menuItem9,
            this.menuItem3,
            this.menuItem2,
            this.menuItem10});
            this.miMange.Text = "图书管理(&L)";
            // 
            // miDetail
            // 
            this.miDetail.Index = 0;
            this.miDetail.Text = "图书馆藏量统计(&E)";
            this.miDetail.Click += new System.EventHandler(this.miDetail_Click);
            // 
            // miSave
            // 
            this.miSave.Index = 1;
            this.miSave.Text = "图书借阅统计(&M)";
            this.miSave.Click += new System.EventHandler(this.menuItem8_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 2;
            this.menuItem9.Text = "-";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 3;
            this.menuItem3.Text = "图书入库(A)";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 4;
            this.menuItem2.Text = "-";
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 5;
            this.menuItem10.Text = "退出(&X)";
            this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
            // 
            // MiBor
            // 
            this.MiBor.Index = 1;
            this.MiBor.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miBo,
            this.menuItem1,
            this.miQb});
            this.MiBor.Text = "借书管理(&B)";
            // 
            // miBo
            // 
            this.miBo.Index = 0;
            this.miBo.Text = "借阅管理(&R)";
            this.miBo.Click += new System.EventHandler(this.miBo_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 1;
            this.menuItem1.Text = "-";
            // 
            // miQb
            // 
            this.miQb.Index = 2;
            this.miQb.Text = "借书查询";
            this.miQb.Click += new System.EventHandler(this.miQb_Click);
            // 
            // MiHelp
            // 
            this.MiHelp.Index = 2;
            this.MiHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miAbout});
            this.MiHelp.Text = "帮助(&H)";
            // 
            // miAbout
            // 
            this.miAbout.Index = 0;
            this.miAbout.Text = "关于(&A)";
            this.miAbout.Click += new System.EventHandler(this.miAbout_Click);
            // 
            // miRFID
            // 
            this.miRFID.Index = 3;
            this.miRFID.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miSJWH,
            this.miSearch,
            this.miReader,
            this.menuItem4});
            this.miRFID.Text = "RFID管理";
            // 
            // miSJWH
            // 
            this.miSJWH.Index = 0;
            this.miSJWH.Text = "书架信息维护";
            this.miSJWH.Click += new System.EventHandler(this.miSJWH_Click);
            // 
            // miSearch
            // 
            this.miSearch.Index = 1;
            this.miSearch.Text = "查找打印";
            this.miSearch.Click += new System.EventHandler(this.miSearch_Click);
            // 
            // miReader
            // 
            this.miReader.Enabled = false;
            this.miReader.Index = 2;
            this.miReader.Text = "阅读器";
            this.miReader.Visible = false;
            this.miReader.Click += new System.EventHandler(this.miReader_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 3;
            this.menuItem4.Text = "统计图书";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // tBar
            // 
            this.tBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.tBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.tBarButton6});
            this.tBar.DropDownArrows = true;
            this.tBar.ImageList = this.iList1;
            this.tBar.Location = new System.Drawing.Point(0, 0);
            this.tBar.Name = "tBar";
            this.tBar.ShowToolTips = true;
            this.tBar.Size = new System.Drawing.Size(792, 28);
            this.tBar.TabIndex = 1;
            this.tBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tBar_ButtonClick);
            // 
            // tBarButton6
            // 
            this.tBarButton6.ImageIndex = 5;
            this.tBarButton6.Name = "tBarButton6";
            // 
            // iList1
            // 
            this.iList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iList1.ImageStream")));
            this.iList1.TransparentColor = System.Drawing.Color.Transparent;
            this.iList1.Images.SetKeyName(0, "");
            this.iList1.Images.SetKeyName(1, "");
            this.iList1.Images.SetKeyName(2, "");
            this.iList1.Images.SetKeyName(3, "");
            this.iList1.Images.SetKeyName(4, "");
            this.iList1.Images.SetKeyName(5, "");
            // 
            // btimer
            // 
            this.btimer.Interval = 1000;
            this.btimer.Tick += new System.EventHandler(this.btimer_Tick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            // 
            // tv
            // 
            this.tv.Dock = System.Windows.Forms.DockStyle.Left;
            this.tv.ImageIndex = 0;
            this.tv.ImageList = this.imageList1;
            this.tv.Location = new System.Drawing.Point(0, 28);
            this.tv.Name = "tv";
            this.tv.SelectedImageIndex = 0;
            this.tv.Size = new System.Drawing.Size(320, 495);
            this.tv.TabIndex = 2;
            this.tv.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_AfterSelect);
            this.tv.DoubleClick += new System.EventHandler(this.dDetail_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(320, 28);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 495);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // dg
            // 
            this.dg.DataMember = "";
            this.dg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dg.Location = new System.Drawing.Point(323, 28);
            this.dg.Name = "dg";
            this.dg.ReadOnly = true;
            this.dg.Size = new System.Drawing.Size(469, 495);
            this.dg.TabIndex = 4;
            this.dg.Navigate += new System.Windows.Forms.NavigateEventHandler(this.dg_Navigate);
            // 
            // sqlConn
            // 
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
            this.sqlConn.InfoMessage += new System.Data.SqlClient.SqlInfoMessageEventHandler(this.sqlConnection1_InfoMessage);
            // 
            // sDAdapter
            // 
            this.sDAdapter.InsertCommand = this.sqlInsertCommand1;
            this.sDAdapter.SelectCommand = this.sqlSelectCommand1;
            this.sDAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "book", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("书名", "书名"),
                        new System.Data.Common.DataColumnMapping("并列提名", "并列提名"),
                        new System.Data.Common.DataColumnMapping("副提名", "副提名"),
                        new System.Data.Common.DataColumnMapping("并列副提名", "并列副提名"),
                        new System.Data.Common.DataColumnMapping("国别", "国别"),
                        new System.Data.Common.DataColumnMapping("第一责任者", "第一责任者"),
                        new System.Data.Common.DataColumnMapping("其他责任者", "其他责任者"),
                        new System.Data.Common.DataColumnMapping("版本", "版本"),
                        new System.Data.Common.DataColumnMapping("有关责任者", "有关责任者"),
                        new System.Data.Common.DataColumnMapping("出版地", "出版地"),
                        new System.Data.Common.DataColumnMapping("出版者", "出版者"),
                        new System.Data.Common.DataColumnMapping("出版日期", "出版日期"),
                        new System.Data.Common.DataColumnMapping("页数", "页数"),
                        new System.Data.Common.DataColumnMapping("开本", "开本"),
                        new System.Data.Common.DataColumnMapping("附图", "附图"),
                        new System.Data.Common.DataColumnMapping("附件", "附件"),
                        new System.Data.Common.DataColumnMapping("价格", "价格"),
                        new System.Data.Common.DataColumnMapping("附注", "附注"),
                        new System.Data.Common.DataColumnMapping("文种号", "文种号"),
                        new System.Data.Common.DataColumnMapping("图书分类号", "图书分类号"),
                        new System.Data.Common.DataColumnMapping("种次号", "种次号"),
                        new System.Data.Common.DataColumnMapping("年代顺序号", "年代顺序号"),
                        new System.Data.Common.DataColumnMapping("入库日期", "入库日期"),
                        new System.Data.Common.DataColumnMapping("馆藏量", "馆藏量"),
                        new System.Data.Common.DataColumnMapping("借出书量", "借出书量"),
                        new System.Data.Common.DataColumnMapping("借出次数", "借出次数"),
                        new System.Data.Common.DataColumnMapping("拒借次数", "拒借次数"),
                        new System.Data.Common.DataColumnMapping("拒借标记", "拒借标记"),
                        new System.Data.Common.DataColumnMapping("有效规范", "有效规范"),
                        new System.Data.Common.DataColumnMapping("失效规范", "失效规范"),
                        new System.Data.Common.DataColumnMapping("指针", "指针"),
                        new System.Data.Common.DataColumnMapping("内容提要", "内容提要")})});
            // 
            // sqlInsertCommand1
            // 
            this.sqlInsertCommand1.CommandText = resources.GetString("sqlInsertCommand1.CommandText");
            this.sqlInsertCommand1.Connection = this.sqlConn;
            this.sqlInsertCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@书名", System.Data.SqlDbType.NVarChar, 60, "书名"),
            new System.Data.SqlClient.SqlParameter("@并列提名", System.Data.SqlDbType.NVarChar, 60, "并列提名"),
            new System.Data.SqlClient.SqlParameter("@副提名", System.Data.SqlDbType.NVarChar, 60, "副提名"),
            new System.Data.SqlClient.SqlParameter("@并列副提名", System.Data.SqlDbType.NVarChar, 60, "并列副提名"),
            new System.Data.SqlClient.SqlParameter("@国别", System.Data.SqlDbType.NVarChar, 8, "国别"),
            new System.Data.SqlClient.SqlParameter("@第一责任者", System.Data.SqlDbType.NVarChar, 50, "第一责任者"),
            new System.Data.SqlClient.SqlParameter("@其他责任者", System.Data.SqlDbType.NVarChar, 30, "其他责任者"),
            new System.Data.SqlClient.SqlParameter("@版本", System.Data.SqlDbType.NVarChar, 4, "版本"),
            new System.Data.SqlClient.SqlParameter("@有关责任者", System.Data.SqlDbType.NVarChar, 12, "有关责任者"),
            new System.Data.SqlClient.SqlParameter("@出版地", System.Data.SqlDbType.NVarChar, 12, "出版地"),
            new System.Data.SqlClient.SqlParameter("@出版者", System.Data.SqlDbType.NVarChar, 30, "出版者"),
            new System.Data.SqlClient.SqlParameter("@出版日期", System.Data.SqlDbType.NVarChar, 7, "出版日期"),
            new System.Data.SqlClient.SqlParameter("@页数", System.Data.SqlDbType.NVarChar, 10, "页数"),
            new System.Data.SqlClient.SqlParameter("@开本", System.Data.SqlDbType.NVarChar, 4, "开本"),
            new System.Data.SqlClient.SqlParameter("@附图", System.Data.SqlDbType.NVarChar, 3, "附图"),
            new System.Data.SqlClient.SqlParameter("@附件", System.Data.SqlDbType.NVarChar, 18, "附件"),
            new System.Data.SqlClient.SqlParameter("@价格", System.Data.SqlDbType.NVarChar, 9, "价格"),
            new System.Data.SqlClient.SqlParameter("@附注", System.Data.SqlDbType.NVarChar, 10, "附注"),
            new System.Data.SqlClient.SqlParameter("@文种号", System.Data.SqlDbType.NVarChar, 1, "文种号"),
            new System.Data.SqlClient.SqlParameter("@图书分类号", System.Data.SqlDbType.NVarChar, 8, "图书分类号"),
            new System.Data.SqlClient.SqlParameter("@种次号", System.Data.SqlDbType.NVarChar, 4, "种次号"),
            new System.Data.SqlClient.SqlParameter("@年代顺序号", System.Data.SqlDbType.NVarChar, 20, "年代顺序号"),
            new System.Data.SqlClient.SqlParameter("@入库日期", System.Data.SqlDbType.DateTime, 4, "入库日期"),
            new System.Data.SqlClient.SqlParameter("@馆藏量", System.Data.SqlDbType.Float, 8, "馆藏量"),
            new System.Data.SqlClient.SqlParameter("@借出书量", System.Data.SqlDbType.Float, 8, "借出书量"),
            new System.Data.SqlClient.SqlParameter("@借出次数", System.Data.SqlDbType.Float, 8, "借出次数"),
            new System.Data.SqlClient.SqlParameter("@拒借次数", System.Data.SqlDbType.Float, 8, "拒借次数"),
            new System.Data.SqlClient.SqlParameter("@拒借标记", System.Data.SqlDbType.Bit, 1, "拒借标记"),
            new System.Data.SqlClient.SqlParameter("@有效规范", System.Data.SqlDbType.Bit, 1, "有效规范"),
            new System.Data.SqlClient.SqlParameter("@失效规范", System.Data.SqlDbType.Bit, 1, "失效规范"),
            new System.Data.SqlClient.SqlParameter("@指针", System.Data.SqlDbType.Float, 8, "指针"),
            new System.Data.SqlClient.SqlParameter("@内容提要", System.Data.SqlDbType.NVarChar, 1200, "内容提要")});
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "SELECT 书名, 并列提名, 副提名, 并列副提名, 国别, 第一责任者, 其他责任者, 版本, 有关责任者, 出版地, 出版者, 出版日期, 页数, 开本," +
    " 附图, 附件, 价格, 附注, 文种号, 图书分类号, 种次号, 年代顺序号, 入库日期, 馆藏量, 借出书量, 借出次数, 拒借次数, 拒借标记, 有效规范" +
    ", 失效规范, 指针, 内容提要 FROM book ORDER BY ID";
            this.sqlSelectCommand1.Connection = this.sqlConn;
            // 
            // dsBook1
            // 
            this.dsBook1.DataSetName = "dsBook";
            this.dsBook1.Locale = new System.Globalization.CultureInfo("zh-CN");
            this.dsBook1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // library
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(792, 545);
            this.Controls.Add(this.dg);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.tv);
            this.Controls.Add(this.tBar);
            this.Controls.Add(this.sBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.bookMenu;
            this.Name = "library";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BIAD图书管理";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Closed += new System.EventHandler(this.CloseForm);
            this.Load += new System.EventHandler(this.library_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sbp1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbp2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBook1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			
			Application.Run(new library());
		}

		private void library_Load(object sender, System.EventArgs e)
		{
			btimer.Start();
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
		
		}

		private void btimer_Tick(object sender, System.EventArgs e)
		{
			DateTime d1 = DateTime.Now ;

			sBar.Panels[1].Text=d1.ToLongTimeString() ;
		}

		private void CloseForm(object sender, System.EventArgs e)
		{
			btimer.Stop();
		}


		private void menuItem10_Click(object sender, System.EventArgs e)
		{
			
            //this.Close();
		}

		private void sqlConnection1_InfoMessage(object sender, System.Data.SqlClient.SqlInfoMessageEventArgs e)
		{
		
		}

		private void menuItem8_Click(object sender, System.EventArgs e)
		{
			FormCount formC=new FormCount();
			formC.strConn =strConn;

			formC.ShowDialog(this);
			
		}

		private void tBar_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			about about1=new about();
			
			if (about1.ShowDialog(this) == DialogResult.OK)
			{
			}
		}

		private void tv_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			string sbInfo="";
			string dgcaption="",tf="";
			
			int num;

			this.Cursor=Cursors.WaitCursor;
			dg.DataSource=null;

			TreeNode tn=tv.SelectedNode;
			////
			if (tn.ImageIndex==5)
			{ //root
				tf=tn.Text;
				switch(tf)
				{
					case "建院图书馆":

						dv.Table=dsBook1.Tables["book"];
						dv.RowFilter="";
						dgcaption="全部记录：";
						sbInfo="共有"+dsBook1.Tables["book"].Rows.Count.ToString()+"条记录";
						dgcaption+=sbInfo;
						break;

					case "图书":

						dv.Table=dsBook1.Tables["book"];
						dv.RowFilter="图书分类号<>'建' and 图书分类号<>'结' and 图书分类号<>'暖' and 图书分类号<>'卫' and 图书分类号<>'电' and 图书分类号<>'施' and 图书分类号<>'样' and 图书分类号<>'材' and 图书分类号<>'总' and 图书分类号<>'构1' and 图书分类号<>'构2' and 图书分类号<>'构3' and 图书分类号<>'构4' and 图书分类号<>'构5' and 图书分类号<>'结1' and 图书分类号<>'外' and 图书分类号<>'内' and 图书分类号<>'饰' and 图书分类号<>'构'  ";
						dgcaption="图书：";
						sbInfo="共有"+dv.Count.ToString()+"条记录";
						dgcaption+=sbInfo;
						break;

					case "西文图书":

						dv.Table=dsBook1.Tables["book"];
						dv.RowFilter="文种号='2' and 图书分类号<>'建' and 图书分类号<>'结' and 图书分类号<>'暖' and 图书分类号<>'卫' and 图书分类号<>'电' and 图书分类号<>'施' and 图书分类号<>'样' and 图书分类号<>'材' and 图书分类号<>'总' and 图书分类号<>'构1' and 图书分类号<>'构2' and 图书分类号<>'构3' and 图书分类号<>'构4' and 图书分类号<>'构5' and 图书分类号<>'结1' and 图书分类号<>'外' and 图书分类号<>'内' and 图书分类号<>'饰' and 图书分类号<>'构'  ";
						dgcaption="西文图书：";
						sbInfo="共有"+dv.Count.ToString()+"条记录";
						dgcaption+=sbInfo;
						break;

					case "中文图书":
						dv.Table=dsBook1.Tables["book"];
						dv.RowFilter="文种号='1' and 图书分类号<>'建' and 图书分类号<>'结' and 图书分类号<>'暖' and 图书分类号<>'卫' and 图书分类号<>'电' and 图书分类号<>'施' and 图书分类号<>'样' and 图书分类号<>'材' and 图书分类号<>'总' and 图书分类号<>'构1' and 图书分类号<>'构2' and 图书分类号<>'构3' and 图书分类号<>'构4' and 图书分类号<>'构5' and 图书分类号<>'结1' and 图书分类号<>'外'  and 图书分类号<>'内' and 图书分类号<>'饰' and 图书分类号<>'构' ";
						dgcaption="中文图书：";
						sbInfo="共有"+dv.Count.ToString()+"条记录";
						dgcaption+=sbInfo;
						break;

					case "日文图书":
						dv.Table=dsBook1.Tables["book"];
						dv.RowFilter="文种号='4' and 图书分类号<>'建' and 图书分类号<>'结' and 图书分类号<>'暖' and 图书分类号<>'卫' and 图书分类号<>'电' and 图书分类号<>'施' and 图书分类号<>'样' and 图书分类号<>'材' and 图书分类号<>'总' and 图书分类号<>'构1' and 图书分类号<>'构2' and 图书分类号<>'构3' and 图书分类号<>'构4' and 图书分类号<>'构5' and 图书分类号<>'结1' and 图书分类号<>'外'  and 图书分类号<>'内' and 图书分类号<>'饰' and 图书分类号<>'构' ";
						dgcaption="日文图书：";
						sbInfo="共有"+dv.Count.ToString()+"条记录";
						dgcaption+=sbInfo;
						break;

					case "资料":
						dv.Table=dsBook1.Tables["book"];
						dv.RowFilter="图书分类号='建' or 图书分类号='结' or 图书分类号='暖' or 图书分类号='卫' or 图书分类号='电' or 图书分类号='施' or 图书分类号='样' or 图书分类号='材' or 图书分类号='总' or 图书分类号='构1' or 图书分类号='构2' or 图书分类号='构3' or 图书分类号='构4' or 图书分类号='构5' or 图书分类号='结1' or 图书分类号='外' or 图书分类号='内' or 图书分类号='饰' or 图书分类号='构'";
						dgcaption="资料：";
						sbInfo="共有"+dv.Count.ToString()+"条记录";
						dgcaption+=sbInfo;
						break;

					case "中文资料":
						dv.Table=dsBook1.Tables["book"];
						dv.RowFilter="图书分类号='建' or 图书分类号='结' or 图书分类号='暖' or 图书分类号='卫' or 图书分类号='电' or 图书分类号='施' or 图书分类号='样' or 图书分类号='材' or 图书分类号='总' or 图书分类号='构1' or 图书分类号='构2' or 图书分类号='构3' or 图书分类号='构4' or 图书分类号='构5' or 图书分类号='结1' or 图书分类号='内' or 图书分类号='饰' or 图书分类号='构' and 图书分类号<>'外'";
						dgcaption="资料：";
						sbInfo="共有"+dv.Count.ToString()+"条记录";
						dgcaption+=sbInfo;
						break;

					case "西文资料":
						dv.Table=dsBook1.Tables["book"];
						dv.RowFilter="图书分类号='外' and 文种号='2'";
						dgcaption="资料：";
						sbInfo="共有"+dv.Count.ToString()+"条记录";
						dgcaption+=sbInfo;
						break;
					
					case "日文资料":
						dv.Table=dsBook1.Tables["book"];
						dv.RowFilter="图书分类号='外' and 文种号='4'";
						dgcaption="资料：";
						sbInfo="共有"+dv.Count.ToString()+"条记录";
						dgcaption+=sbInfo;
						break;

				}
				
				strC1="";strC2="";strC3="";

			}
			else if (tn.ImageIndex==0 || tn.ImageIndex==1)
			{
				dv.Table=dsBook1.Tables["book"];
				//dv.RowFilter="书名='"+tn.Text+"'";
				foreach(TreeNode tns in tn.Nodes)
				{
					switch(tns.ImageIndex)
					{
						case 2:
							strC1=tns.Text;
							num=strC1.IndexOf("：",0);
							strC1=strC1.Remove(0,num+1);
							break;
						case 3:
							strC2=tns.Text;
							num=strC2.IndexOf("：",0);
							strC2=strC2.Remove(0,num+1);
							break;
						case 4:
							strC3=tns.Text;
							num=strC3.IndexOf("：",0);
							strC3=strC3.Remove(0,num+1);
							break;

					}
				}
				dv.RowFilter="文种号='"+strC1+"' AND 图书分类号='"+strC2+"' AND 种次号='"+strC3+"'";

				sbInfo="选择了记录："+strC1+" "+strC2+" "+strC3;

//				sbInfo=dv.RowFilter;
				dgcaption="书名记录："+tn.Text;

			}

			dg.DataSource=dv;
			dg.CaptionText=dgcaption;
			sBar.Panels[0].Text=sbInfo;

			this.Cursor=Cursors.Arrow;

		}

		private void miDetail_Click(object sender, System.EventArgs e)
		{
			
			FormCountL formCL=new FormCountL();
			formCL.strConn =strConn;

			formCL.ShowDialog(this);

		}
		private void dDetail_Click(object sender, System.EventArgs e)
		{
			
			FormBook formB=new FormBook();
			formB.sc1=strC1;
			formB.sc2=strC2;
			formB.sc3=strC3;
			formB.strConn=strConn;

			formB.ShowDialog(this);
			if(formB.isChange) BookReadLibrary();


		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
		
		}

		private void miAbout_Click(object sender, System.EventArgs e)
		{
			about about1=new about();
			
			about1.ShowDialog(this);

		}

		private void miBo_Click(object sender, System.EventArgs e)
		{
			FormBor fBor=new FormBor();
			fBor.strConn =strConn;
			fBor.strhrConn =strhrConn;
			fBor.ShowDialog(this);
		}

		private void miQb_Click(object sender, System.EventArgs e)
		{
			FormQue fQue=new FormQue();
			fQue.strConn =strConn;
			fQue.strhrConn =strhrConn;
			fQue.ShowDialog(this);
		
		}

		private void dg_Navigate(object sender, System.Windows.Forms.NavigateEventArgs ne)
		{
		
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			FormBook formB=new FormBook();
			formB.sc1="";
			formB.sc2="";
			formB.sc3="";
			formB.strConn=strConn;
			formB.ShowDialog(this);

			if(formB.isChange) BookReadLibrary();
		}

		private void miSJWH_Click(object sender, System.EventArgs e)
		{
			//书架信息维护
			frmBookLocationManager frmbookLocation=new frmBookLocationManager ();
			frmbookLocation.ShowDialog ();
		}

		private void miSearch_Click(object sender, System.EventArgs e)
		{	//查找打印
			ReaderTag RT=new ReaderTag ();
			RT.ShowDialog ();
		}

		private void miReader_Click(object sender, System.EventArgs e)
		{	//阅读器
			frmReaderSetting frmRS=new frmReaderSetting ();
			frmRS.ShowDialog ();
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{//统计图书
			BookList booklist=new BookList ();
			booklist.ShowDialog ();
		
		}
	}
}
