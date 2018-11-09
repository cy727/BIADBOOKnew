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
	/// Form1 ��ժҪ˵����
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

			TreeNode rootNode= new TreeNode("��Ժͼ���",5,5);

			TreeNode rnbook = new TreeNode("ͼ��",5,5);
			rootNode.Nodes.Add(rnbook);
			TreeNode rndocu = new TreeNode("����",5,5);
			rootNode.Nodes.Add(rndocu);

			TreeNode rnbookc = new TreeNode("����ͼ��",5,5);
			rnbook.Nodes.Add(rnbookc);
			TreeNode rnbookw = new TreeNode("����ͼ��",5,5);
			rnbook.Nodes.Add(rnbookw);
			TreeNode rnbookj = new TreeNode("����ͼ��",5,5);
			rnbook.Nodes.Add(rnbookj);

			TreeNode rndocuc = new TreeNode("��������",5,5);
			rndocu.Nodes.Add(rndocuc);
			TreeNode rndocuw = new TreeNode("��������",5,5);
			rndocu.Nodes.Add(rndocuw);
			TreeNode rndocuj = new TreeNode("��������",5,5);
			rndocu.Nodes.Add(rndocuj);
			
			DataTable tableBook;
			tableBook=dsBook1.Tables["book"];
			



			foreach( DataRow row in tableBook.Rows)
			{
				//rootNode.Nodes.Add(tnBook);
				TreeNode tnBook = new TreeNode(row["����"].ToString(),0,1);
				TreeNode tnwzh = new TreeNode("���ֺţ�"+row["���ֺ�"].ToString(),2,2);
				TreeNode tntsflh = new TreeNode("ͼ�����ţ�"+row["ͼ������"].ToString(),3,3);
				TreeNode tnzch = new TreeNode("�ִκţ�"+row["�ִκ�"].ToString(),4,4);

				
				sttw=row["���ֺ�"].ToString();
				stts=row["ͼ������"].ToString();
				switch(sttw)
				{
					case "1":
						if(stts=="��" || stts=="��" || stts=="ů" || stts=="��" || stts=="��" || stts=="ʩ" || stts=="��" || stts=="��" || stts=="��" || stts=="��" || stts=="��" || stts=="��" || stts=="��1" || stts=="��2" || stts=="��3" || stts=="��4" || stts=="��5" || stts=="��1" || stts=="��")
						{
							rndocuc.Nodes.Add(tnBook);

						}
						else
						{
							rnbookc.Nodes.Add(tnBook);
						}
						break;
					case "2":
						if(stts=="��")
						{
							rndocuw.Nodes.Add(tnBook);
						}
						else
						{
							rnbookw.Nodes.Add(tnBook);
						}
						break;
					case "4":
						if(stts=="��")
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
			// Windows ���������֧���������
			//
			//strConn="workstation id=MP-LIU;packet size=4096;integrated security=SSPI;data source=.;persist security info=False;initial catalog=library";
		
		//	strConn="workstation id=home;packet size=4096;integrated security=SSPI;data source=.;persist security info=False;initial catalog=library";
			strConn="workstation id=CHENYI;packet size=4096;user id=sa;password=biadlib2004;data source=\"172.16.0.11\";;initial catalog=library";

			//strhrConn="workstation id=CHENYI;packet size=4096;user id=sa;password=icone;data source=\"172.16.0.136\";persist security info=False;initial catalog=ecard";

            strhrConn = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=172.16.5.192) (PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=orcl)));Persist Security Info=True;User Id=NCHR; Password=NCHR";

            //OracleConn = new OracleConnection(OracleconnString);

            //try
            //{
            //    OracleConn.Open();//��ָ��������                  
            //    OracleCommand com = OracleConn.CreateCommand();
            //    com.CommandText = "select * FROM V_SYS_PSN ";//д����ִ�е�Sql���                  
            //    OracleDataReader odr = com.ExecuteReader();
            //    while (odr.Read())//��ȡ���ݣ��������Ϊfalse�Ļ�����˵������¼����β����                   
            //    {
            //        MessageBox.Show(odr.GetValue(4).ToString());
            //        break;
            //    }
            //    odr.Close();//�ر�reader.����һ��Ҫд�� 
            //}
            //catch
            //{
            //    MessageBox.Show("erro");//��������쳣������ʾ����             
            //}
            //finally
            //{
            //    OracleConn.Close();//�رմ򿪵�����             
            //}


			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
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
		/// ������������ʹ�õ���Դ��
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

		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
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
            this.sbp1.Text = "�����н�������о�Ժ ͼ����� ����.....";
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
            this.miMange.Text = "ͼ�����(&L)";
            // 
            // miDetail
            // 
            this.miDetail.Index = 0;
            this.miDetail.Text = "ͼ��ݲ���ͳ��(&E)";
            this.miDetail.Click += new System.EventHandler(this.miDetail_Click);
            // 
            // miSave
            // 
            this.miSave.Index = 1;
            this.miSave.Text = "ͼ�����ͳ��(&M)";
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
            this.menuItem3.Text = "ͼ�����(A)";
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
            this.menuItem10.Text = "�˳�(&X)";
            this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
            // 
            // MiBor
            // 
            this.MiBor.Index = 1;
            this.MiBor.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miBo,
            this.menuItem1,
            this.miQb});
            this.MiBor.Text = "�������(&B)";
            // 
            // miBo
            // 
            this.miBo.Index = 0;
            this.miBo.Text = "���Ĺ���(&R)";
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
            this.miQb.Text = "�����ѯ";
            this.miQb.Click += new System.EventHandler(this.miQb_Click);
            // 
            // MiHelp
            // 
            this.MiHelp.Index = 2;
            this.MiHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miAbout});
            this.MiHelp.Text = "����(&H)";
            // 
            // miAbout
            // 
            this.miAbout.Index = 0;
            this.miAbout.Text = "����(&A)";
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
            this.miRFID.Text = "RFID����";
            // 
            // miSJWH
            // 
            this.miSJWH.Index = 0;
            this.miSJWH.Text = "�����Ϣά��";
            this.miSJWH.Click += new System.EventHandler(this.miSJWH_Click);
            // 
            // miSearch
            // 
            this.miSearch.Index = 1;
            this.miSearch.Text = "���Ҵ�ӡ";
            this.miSearch.Click += new System.EventHandler(this.miSearch_Click);
            // 
            // miReader
            // 
            this.miReader.Enabled = false;
            this.miReader.Index = 2;
            this.miReader.Text = "�Ķ���";
            this.miReader.Visible = false;
            this.miReader.Click += new System.EventHandler(this.miReader_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 3;
            this.menuItem4.Text = "ͳ��ͼ��";
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
                        new System.Data.Common.DataColumnMapping("����", "����"),
                        new System.Data.Common.DataColumnMapping("��������", "��������"),
                        new System.Data.Common.DataColumnMapping("������", "������"),
                        new System.Data.Common.DataColumnMapping("���и�����", "���и�����"),
                        new System.Data.Common.DataColumnMapping("����", "����"),
                        new System.Data.Common.DataColumnMapping("��һ������", "��һ������"),
                        new System.Data.Common.DataColumnMapping("����������", "����������"),
                        new System.Data.Common.DataColumnMapping("�汾", "�汾"),
                        new System.Data.Common.DataColumnMapping("�й�������", "�й�������"),
                        new System.Data.Common.DataColumnMapping("�����", "�����"),
                        new System.Data.Common.DataColumnMapping("������", "������"),
                        new System.Data.Common.DataColumnMapping("��������", "��������"),
                        new System.Data.Common.DataColumnMapping("ҳ��", "ҳ��"),
                        new System.Data.Common.DataColumnMapping("����", "����"),
                        new System.Data.Common.DataColumnMapping("��ͼ", "��ͼ"),
                        new System.Data.Common.DataColumnMapping("����", "����"),
                        new System.Data.Common.DataColumnMapping("�۸�", "�۸�"),
                        new System.Data.Common.DataColumnMapping("��ע", "��ע"),
                        new System.Data.Common.DataColumnMapping("���ֺ�", "���ֺ�"),
                        new System.Data.Common.DataColumnMapping("ͼ������", "ͼ������"),
                        new System.Data.Common.DataColumnMapping("�ִκ�", "�ִκ�"),
                        new System.Data.Common.DataColumnMapping("���˳���", "���˳���"),
                        new System.Data.Common.DataColumnMapping("�������", "�������"),
                        new System.Data.Common.DataColumnMapping("�ݲ���", "�ݲ���"),
                        new System.Data.Common.DataColumnMapping("�������", "�������"),
                        new System.Data.Common.DataColumnMapping("�������", "�������"),
                        new System.Data.Common.DataColumnMapping("�ܽ����", "�ܽ����"),
                        new System.Data.Common.DataColumnMapping("�ܽ���", "�ܽ���"),
                        new System.Data.Common.DataColumnMapping("��Ч�淶", "��Ч�淶"),
                        new System.Data.Common.DataColumnMapping("ʧЧ�淶", "ʧЧ�淶"),
                        new System.Data.Common.DataColumnMapping("ָ��", "ָ��"),
                        new System.Data.Common.DataColumnMapping("������Ҫ", "������Ҫ")})});
            // 
            // sqlInsertCommand1
            // 
            this.sqlInsertCommand1.CommandText = resources.GetString("sqlInsertCommand1.CommandText");
            this.sqlInsertCommand1.Connection = this.sqlConn;
            this.sqlInsertCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@����", System.Data.SqlDbType.NVarChar, 60, "����"),
            new System.Data.SqlClient.SqlParameter("@��������", System.Data.SqlDbType.NVarChar, 60, "��������"),
            new System.Data.SqlClient.SqlParameter("@������", System.Data.SqlDbType.NVarChar, 60, "������"),
            new System.Data.SqlClient.SqlParameter("@���и�����", System.Data.SqlDbType.NVarChar, 60, "���и�����"),
            new System.Data.SqlClient.SqlParameter("@����", System.Data.SqlDbType.NVarChar, 8, "����"),
            new System.Data.SqlClient.SqlParameter("@��һ������", System.Data.SqlDbType.NVarChar, 50, "��һ������"),
            new System.Data.SqlClient.SqlParameter("@����������", System.Data.SqlDbType.NVarChar, 30, "����������"),
            new System.Data.SqlClient.SqlParameter("@�汾", System.Data.SqlDbType.NVarChar, 4, "�汾"),
            new System.Data.SqlClient.SqlParameter("@�й�������", System.Data.SqlDbType.NVarChar, 12, "�й�������"),
            new System.Data.SqlClient.SqlParameter("@�����", System.Data.SqlDbType.NVarChar, 12, "�����"),
            new System.Data.SqlClient.SqlParameter("@������", System.Data.SqlDbType.NVarChar, 30, "������"),
            new System.Data.SqlClient.SqlParameter("@��������", System.Data.SqlDbType.NVarChar, 7, "��������"),
            new System.Data.SqlClient.SqlParameter("@ҳ��", System.Data.SqlDbType.NVarChar, 10, "ҳ��"),
            new System.Data.SqlClient.SqlParameter("@����", System.Data.SqlDbType.NVarChar, 4, "����"),
            new System.Data.SqlClient.SqlParameter("@��ͼ", System.Data.SqlDbType.NVarChar, 3, "��ͼ"),
            new System.Data.SqlClient.SqlParameter("@����", System.Data.SqlDbType.NVarChar, 18, "����"),
            new System.Data.SqlClient.SqlParameter("@�۸�", System.Data.SqlDbType.NVarChar, 9, "�۸�"),
            new System.Data.SqlClient.SqlParameter("@��ע", System.Data.SqlDbType.NVarChar, 10, "��ע"),
            new System.Data.SqlClient.SqlParameter("@���ֺ�", System.Data.SqlDbType.NVarChar, 1, "���ֺ�"),
            new System.Data.SqlClient.SqlParameter("@ͼ������", System.Data.SqlDbType.NVarChar, 8, "ͼ������"),
            new System.Data.SqlClient.SqlParameter("@�ִκ�", System.Data.SqlDbType.NVarChar, 4, "�ִκ�"),
            new System.Data.SqlClient.SqlParameter("@���˳���", System.Data.SqlDbType.NVarChar, 20, "���˳���"),
            new System.Data.SqlClient.SqlParameter("@�������", System.Data.SqlDbType.DateTime, 4, "�������"),
            new System.Data.SqlClient.SqlParameter("@�ݲ���", System.Data.SqlDbType.Float, 8, "�ݲ���"),
            new System.Data.SqlClient.SqlParameter("@�������", System.Data.SqlDbType.Float, 8, "�������"),
            new System.Data.SqlClient.SqlParameter("@�������", System.Data.SqlDbType.Float, 8, "�������"),
            new System.Data.SqlClient.SqlParameter("@�ܽ����", System.Data.SqlDbType.Float, 8, "�ܽ����"),
            new System.Data.SqlClient.SqlParameter("@�ܽ���", System.Data.SqlDbType.Bit, 1, "�ܽ���"),
            new System.Data.SqlClient.SqlParameter("@��Ч�淶", System.Data.SqlDbType.Bit, 1, "��Ч�淶"),
            new System.Data.SqlClient.SqlParameter("@ʧЧ�淶", System.Data.SqlDbType.Bit, 1, "ʧЧ�淶"),
            new System.Data.SqlClient.SqlParameter("@ָ��", System.Data.SqlDbType.Float, 8, "ָ��"),
            new System.Data.SqlClient.SqlParameter("@������Ҫ", System.Data.SqlDbType.NVarChar, 1200, "������Ҫ")});
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "SELECT ����, ��������, ������, ���и�����, ����, ��һ������, ����������, �汾, �й�������, �����, ������, ��������, ҳ��, ����," +
    " ��ͼ, ����, �۸�, ��ע, ���ֺ�, ͼ������, �ִκ�, ���˳���, �������, �ݲ���, �������, �������, �ܽ����, �ܽ���, ��Ч�淶" +
    ", ʧЧ�淶, ָ��, ������Ҫ FROM book ORDER BY ID";
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
            this.Text = "BIADͼ�����";
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
		/// Ӧ�ó��������ڵ㡣
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
					case "��Ժͼ���":

						dv.Table=dsBook1.Tables["book"];
						dv.RowFilter="";
						dgcaption="ȫ����¼��";
						sbInfo="����"+dsBook1.Tables["book"].Rows.Count.ToString()+"����¼";
						dgcaption+=sbInfo;
						break;

					case "ͼ��":

						dv.Table=dsBook1.Tables["book"];
						dv.RowFilter="ͼ������<>'��' and ͼ������<>'��' and ͼ������<>'ů' and ͼ������<>'��' and ͼ������<>'��' and ͼ������<>'ʩ' and ͼ������<>'��' and ͼ������<>'��' and ͼ������<>'��' and ͼ������<>'��1' and ͼ������<>'��2' and ͼ������<>'��3' and ͼ������<>'��4' and ͼ������<>'��5' and ͼ������<>'��1' and ͼ������<>'��' and ͼ������<>'��' and ͼ������<>'��' and ͼ������<>'��'  ";
						dgcaption="ͼ�飺";
						sbInfo="����"+dv.Count.ToString()+"����¼";
						dgcaption+=sbInfo;
						break;

					case "����ͼ��":

						dv.Table=dsBook1.Tables["book"];
						dv.RowFilter="���ֺ�='2' and ͼ������<>'��' and ͼ������<>'��' and ͼ������<>'ů' and ͼ������<>'��' and ͼ������<>'��' and ͼ������<>'ʩ' and ͼ������<>'��' and ͼ������<>'��' and ͼ������<>'��' and ͼ������<>'��1' and ͼ������<>'��2' and ͼ������<>'��3' and ͼ������<>'��4' and ͼ������<>'��5' and ͼ������<>'��1' and ͼ������<>'��' and ͼ������<>'��' and ͼ������<>'��' and ͼ������<>'��'  ";
						dgcaption="����ͼ�飺";
						sbInfo="����"+dv.Count.ToString()+"����¼";
						dgcaption+=sbInfo;
						break;

					case "����ͼ��":
						dv.Table=dsBook1.Tables["book"];
						dv.RowFilter="���ֺ�='1' and ͼ������<>'��' and ͼ������<>'��' and ͼ������<>'ů' and ͼ������<>'��' and ͼ������<>'��' and ͼ������<>'ʩ' and ͼ������<>'��' and ͼ������<>'��' and ͼ������<>'��' and ͼ������<>'��1' and ͼ������<>'��2' and ͼ������<>'��3' and ͼ������<>'��4' and ͼ������<>'��5' and ͼ������<>'��1' and ͼ������<>'��'  and ͼ������<>'��' and ͼ������<>'��' and ͼ������<>'��' ";
						dgcaption="����ͼ�飺";
						sbInfo="����"+dv.Count.ToString()+"����¼";
						dgcaption+=sbInfo;
						break;

					case "����ͼ��":
						dv.Table=dsBook1.Tables["book"];
						dv.RowFilter="���ֺ�='4' and ͼ������<>'��' and ͼ������<>'��' and ͼ������<>'ů' and ͼ������<>'��' and ͼ������<>'��' and ͼ������<>'ʩ' and ͼ������<>'��' and ͼ������<>'��' and ͼ������<>'��' and ͼ������<>'��1' and ͼ������<>'��2' and ͼ������<>'��3' and ͼ������<>'��4' and ͼ������<>'��5' and ͼ������<>'��1' and ͼ������<>'��'  and ͼ������<>'��' and ͼ������<>'��' and ͼ������<>'��' ";
						dgcaption="����ͼ�飺";
						sbInfo="����"+dv.Count.ToString()+"����¼";
						dgcaption+=sbInfo;
						break;

					case "����":
						dv.Table=dsBook1.Tables["book"];
						dv.RowFilter="ͼ������='��' or ͼ������='��' or ͼ������='ů' or ͼ������='��' or ͼ������='��' or ͼ������='ʩ' or ͼ������='��' or ͼ������='��' or ͼ������='��' or ͼ������='��1' or ͼ������='��2' or ͼ������='��3' or ͼ������='��4' or ͼ������='��5' or ͼ������='��1' or ͼ������='��' or ͼ������='��' or ͼ������='��' or ͼ������='��'";
						dgcaption="���ϣ�";
						sbInfo="����"+dv.Count.ToString()+"����¼";
						dgcaption+=sbInfo;
						break;

					case "��������":
						dv.Table=dsBook1.Tables["book"];
						dv.RowFilter="ͼ������='��' or ͼ������='��' or ͼ������='ů' or ͼ������='��' or ͼ������='��' or ͼ������='ʩ' or ͼ������='��' or ͼ������='��' or ͼ������='��' or ͼ������='��1' or ͼ������='��2' or ͼ������='��3' or ͼ������='��4' or ͼ������='��5' or ͼ������='��1' or ͼ������='��' or ͼ������='��' or ͼ������='��' and ͼ������<>'��'";
						dgcaption="���ϣ�";
						sbInfo="����"+dv.Count.ToString()+"����¼";
						dgcaption+=sbInfo;
						break;

					case "��������":
						dv.Table=dsBook1.Tables["book"];
						dv.RowFilter="ͼ������='��' and ���ֺ�='2'";
						dgcaption="���ϣ�";
						sbInfo="����"+dv.Count.ToString()+"����¼";
						dgcaption+=sbInfo;
						break;
					
					case "��������":
						dv.Table=dsBook1.Tables["book"];
						dv.RowFilter="ͼ������='��' and ���ֺ�='4'";
						dgcaption="���ϣ�";
						sbInfo="����"+dv.Count.ToString()+"����¼";
						dgcaption+=sbInfo;
						break;

				}
				
				strC1="";strC2="";strC3="";

			}
			else if (tn.ImageIndex==0 || tn.ImageIndex==1)
			{
				dv.Table=dsBook1.Tables["book"];
				//dv.RowFilter="����='"+tn.Text+"'";
				foreach(TreeNode tns in tn.Nodes)
				{
					switch(tns.ImageIndex)
					{
						case 2:
							strC1=tns.Text;
							num=strC1.IndexOf("��",0);
							strC1=strC1.Remove(0,num+1);
							break;
						case 3:
							strC2=tns.Text;
							num=strC2.IndexOf("��",0);
							strC2=strC2.Remove(0,num+1);
							break;
						case 4:
							strC3=tns.Text;
							num=strC3.IndexOf("��",0);
							strC3=strC3.Remove(0,num+1);
							break;

					}
				}
				dv.RowFilter="���ֺ�='"+strC1+"' AND ͼ������='"+strC2+"' AND �ִκ�='"+strC3+"'";

				sbInfo="ѡ���˼�¼��"+strC1+" "+strC2+" "+strC3;

//				sbInfo=dv.RowFilter;
				dgcaption="������¼��"+tn.Text;

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
			//�����Ϣά��
			frmBookLocationManager frmbookLocation=new frmBookLocationManager ();
			frmbookLocation.ShowDialog ();
		}

		private void miSearch_Click(object sender, System.EventArgs e)
		{	//���Ҵ�ӡ
			ReaderTag RT=new ReaderTag ();
			RT.ShowDialog ();
		}

		private void miReader_Click(object sender, System.EventArgs e)
		{	//�Ķ���
			frmReaderSetting frmRS=new frmReaderSetting ();
			frmRS.ShowDialog ();
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{//ͳ��ͼ��
			BookList booklist=new BookList ();
			booklist.ShowDialog ();
		
		}
	}
}
