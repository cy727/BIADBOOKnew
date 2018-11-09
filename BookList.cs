using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data .SqlClient ;
using System.IO ;


namespace BIADBOOK
{
	/// <summary>
	/// BookList ��ժҪ˵����
	/// </summary>
	public class BookList : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListView viewProducts;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.GroupBox lblTol;
		private System.Windows.Forms.Label lblTotel;
		private System.Windows.Forms.RadioButton radAll;
		private System.Windows.Forms.RadioButton radYi;
		private System.Windows.Forms.RadioButton radWei;
		private System.Windows.Forms.Button cmdExecute;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.ComboBox cboLocation;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtRFID;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button cmdQueryRFID;
		private System.Windows.Forms.Button cmdQuerySSH;
		private System.Windows.Forms.Label lb;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtWZH;
		private System.Windows.Forms.TextBox txtTSFLH;
		private System.Windows.Forms.TextBox txtZCH;
		private System.ComponentModel.IContainer components;

		public BookList()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
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

		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.viewProducts = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
			this.lblTol = new System.Windows.Forms.GroupBox();
			this.cmdExecute = new System.Windows.Forms.Button();
			this.radWei = new System.Windows.Forms.RadioButton();
			this.radYi = new System.Windows.Forms.RadioButton();
			this.radAll = new System.Windows.Forms.RadioButton();
			this.lblTotel = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cboLocation = new System.Windows.Forms.ComboBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.cmdQueryRFID = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.txtRFID = new System.Windows.Forms.TextBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.txtZCH = new System.Windows.Forms.TextBox();
			this.txtTSFLH = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.lb = new System.Windows.Forms.Label();
			this.txtWZH = new System.Windows.Forms.TextBox();
			this.cmdQuerySSH = new System.Windows.Forms.Button();
			this.lblTol.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// viewProducts
			// 
			this.viewProducts.AllowColumnReorder = true;
			this.viewProducts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.viewProducts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						   this.columnHeader1,
																						   this.columnHeader2,
																						   this.columnHeader3,
																						   this.columnHeader4,
																						   this.columnHeader5,
																						   this.columnHeader6,
																						   this.columnHeader7,
																						   this.columnHeader8,
																						   this.columnHeader9,
																						   this.columnHeader10,
																						   this.columnHeader11});
			this.viewProducts.FullRowSelect = true;
			this.viewProducts.GridLines = true;
			this.viewProducts.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.viewProducts.HideSelection = false;
			this.viewProducts.Location = new System.Drawing.Point(8, 64);
			this.viewProducts.Name = "viewProducts";
			this.viewProducts.Size = new System.Drawing.Size(920, 400);
			this.viewProducts.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.viewProducts.TabIndex = 13;
			this.viewProducts.View = System.Windows.Forms.View.Details;
			this.viewProducts.DoubleClick += new System.EventHandler(this.viewProducts_DoubleClick);
			this.viewProducts.SelectedIndexChanged += new System.EventHandler(this.viewProducts_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "RFID���";
			this.columnHeader1.Width = 119;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "��ܱ��";
			this.columnHeader2.Width = 68;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "���λ��";
			this.columnHeader3.Width = 69;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "������Ϣ";
			this.columnHeader4.Width = 74;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "����";
			this.columnHeader5.Width = 112;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "��������";
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "������";
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "���ֺ�";
			this.columnHeader8.Width = 56;
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "ͼ������";
			this.columnHeader9.Width = 73;
			// 
			// columnHeader10
			// 
			this.columnHeader10.Text = "�ִκ�";
			this.columnHeader10.Width = 115;
			// 
			// columnHeader11
			// 
			this.columnHeader11.Text = "���˳���";
			this.columnHeader11.Width = 120;
			// 
			// lblTol
			// 
			this.lblTol.Controls.Add(this.cmdExecute);
			this.lblTol.Controls.Add(this.radWei);
			this.lblTol.Controls.Add(this.radYi);
			this.lblTol.Controls.Add(this.radAll);
			this.lblTol.Location = new System.Drawing.Point(272, 8);
			this.lblTol.Name = "lblTol";
			this.lblTol.Size = new System.Drawing.Size(288, 48);
			this.lblTol.TabIndex = 14;
			this.lblTol.TabStop = false;
			this.lblTol.Text = "��ѯ����";
			// 
			// cmdExecute
			// 
			this.cmdExecute.Location = new System.Drawing.Point(200, 16);
			this.cmdExecute.Name = "cmdExecute";
			this.cmdExecute.Size = new System.Drawing.Size(80, 24);
			this.cmdExecute.TabIndex = 3;
			this.cmdExecute.Text = "��ѯ";
			this.cmdExecute.Click += new System.EventHandler(this.cmdExecute_Click);
			// 
			// radWei
			// 
			this.radWei.Location = new System.Drawing.Point(136, 24);
			this.radWei.Name = "radWei";
			this.radWei.Size = new System.Drawing.Size(64, 16);
			this.radWei.TabIndex = 2;
			this.radWei.Text = "δ��Ŀ";
			// 
			// radYi
			// 
			this.radYi.Location = new System.Drawing.Point(64, 24);
			this.radYi.Name = "radYi";
			this.radYi.Size = new System.Drawing.Size(72, 16);
			this.radYi.TabIndex = 1;
			this.radYi.Text = "�ѱ�Ŀ";
			// 
			// radAll
			// 
			this.radAll.Checked = true;
			this.radAll.Location = new System.Drawing.Point(8, 24);
			this.radAll.Name = "radAll";
			this.radAll.Size = new System.Drawing.Size(48, 16);
			this.radAll.TabIndex = 0;
			this.radAll.TabStop = true;
			this.radAll.Text = "ȫ��";
			// 
			// lblTotel
			// 
			this.lblTotel.Font = new System.Drawing.Font("����", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblTotel.Location = new System.Drawing.Point(160, 32);
			this.lblTotel.Name = "lblTotel";
			this.lblTotel.Size = new System.Drawing.Size(96, 24);
			this.lblTotel.TabIndex = 15;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("����", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(16, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(144, 24);
			this.label1.TabIndex = 16;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cboLocation);
			this.groupBox1.Location = new System.Drawing.Point(576, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(184, 48);
			this.groupBox1.TabIndex = 17;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "�����ͳ��";
			// 
			// cboLocation
			// 
			this.cboLocation.Location = new System.Drawing.Point(8, 16);
			this.cboLocation.Name = "cboLocation";
			this.cboLocation.Size = new System.Drawing.Size(168, 20);
			this.cboLocation.TabIndex = 0;
			this.cboLocation.Text = "��ѡ���λ";
			this.cboLocation.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.cmdQueryRFID);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.txtRFID);
			this.groupBox2.Location = new System.Drawing.Point(8, 472);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(280, 48);
			this.groupBox2.TabIndex = 18;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "���ӱ�ǩ����";
			// 
			// cmdQueryRFID
			// 
			this.cmdQueryRFID.Location = new System.Drawing.Point(184, 16);
			this.cmdQueryRFID.Name = "cmdQueryRFID";
			this.cmdQueryRFID.Size = new System.Drawing.Size(88, 24);
			this.cmdQueryRFID.TabIndex = 2;
			this.cmdQueryRFID.Text = "���ӱ�ǩ����";
			this.cmdQueryRFID.Click += new System.EventHandler(this.cmdQueryRFID_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "RFID:";
			// 
			// txtRFID
			// 
			this.txtRFID.Location = new System.Drawing.Point(48, 17);
			this.txtRFID.Name = "txtRFID";
			this.txtRFID.Size = new System.Drawing.Size(136, 21);
			this.txtRFID.TabIndex = 0;
			this.txtRFID.Text = "";
			this.txtRFID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRFID_KeyPress);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.txtZCH);
			this.groupBox3.Controls.Add(this.txtTSFLH);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Controls.Add(this.lb);
			this.groupBox3.Controls.Add(this.txtWZH);
			this.groupBox3.Controls.Add(this.cmdQuerySSH);
			this.groupBox3.Location = new System.Drawing.Point(296, 472);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(464, 48);
			this.groupBox3.TabIndex = 19;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "����ż���";
			// 
			// txtZCH
			// 
			this.txtZCH.Location = new System.Drawing.Point(320, 17);
			this.txtZCH.Name = "txtZCH";
			this.txtZCH.Size = new System.Drawing.Size(48, 21);
			this.txtZCH.TabIndex = 6;
			this.txtZCH.Text = "";
			// 
			// txtTSFLH
			// 
			this.txtTSFLH.Location = new System.Drawing.Point(184, 17);
			this.txtTSFLH.Name = "txtTSFLH";
			this.txtTSFLH.Size = new System.Drawing.Size(80, 21);
			this.txtTSFLH.TabIndex = 5;
			this.txtTSFLH.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(272, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 16);
			this.label4.TabIndex = 4;
			this.label4.Text = "�ִκ�";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(112, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 15);
			this.label3.TabIndex = 3;
			this.label3.Text = "ͼ������:";
			// 
			// lb
			// 
			this.lb.Location = new System.Drawing.Point(8, 24);
			this.lb.Name = "lb";
			this.lb.Size = new System.Drawing.Size(48, 15);
			this.lb.TabIndex = 2;
			this.lb.Text = "���ֺ�:";
			// 
			// txtWZH
			// 
			this.txtWZH.Location = new System.Drawing.Point(64, 17);
			this.txtWZH.Name = "txtWZH";
			this.txtWZH.Size = new System.Drawing.Size(40, 21);
			this.txtWZH.TabIndex = 1;
			this.txtWZH.Text = "";
			// 
			// cmdQuerySSH
			// 
			this.cmdQuerySSH.Location = new System.Drawing.Point(368, 16);
			this.cmdQuerySSH.Name = "cmdQuerySSH";
			this.cmdQuerySSH.Size = new System.Drawing.Size(88, 24);
			this.cmdQuerySSH.TabIndex = 0;
			this.cmdQuerySSH.Text = "����Ų���";
			this.cmdQuerySSH.Click += new System.EventHandler(this.cmdQuerySSH_Click);
			// 
			// BookList
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(928, 534);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblTotel);
			this.Controls.Add(this.lblTol);
			this.Controls.Add(this.viewProducts);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "BookList";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "�ݲ�ͼ��ͳ��(RFID)";
			this.Load += new System.EventHandler(this.BookList_Load);
			this.lblTol.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private string ConnStr;
		private void BookList_Load(object sender, System.EventArgs e)
		{
			try
			{
				string SysPath;
				SysPath=Directory.GetCurrentDirectory().ToString()+"\\Config.ini";
				//�ж�Config.ini�ļ��Ƿ����
				if(File.Exists(SysPath))
				{
					//����Config.ini�ļ��еĸ�����
					IniFile ini = new IniFile(SysPath);
					//[DataBase]ConnectionString
					if(ini.IniReadValue("DataBase","ConnectionString")!="")
					{ 
						this.ConnStr=ini.IniReadValue("DataBase","ConnectionString").Trim(); 
					}
				}
				/////////////////////////////////////////////////////////////////////////
				Load_cboLocationId();
			}
			catch{}
		}	
		
		private string select="select BarCode,BookLocationId,BookLocationInfo,BookRoomInfo,BookId,����,��������,������,�����,������,��������,ҳ��,����,����,�۸�, ��ע,���ֺ�,ͼ������,�ִκ�,���˳���, �������,�ݲ���,�������,�������,�ܽ����,�ܽ���,��Ч�淶,ʧЧ�淶, ָ��, ������Ҫ  FROM ͼ����ϸ order by BookLocationId";

		private void RefreshBookList()
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
			
				SqlConnection conn =new SqlConnection (this.ConnStr .Trim ());
				SqlCommand cmd=new SqlCommand (this.select.Trim (),conn);
				SqlDataReader DR;
				ListViewItem lvi;
				int i=0;
				viewProducts.Items .Clear ();
				conn.Open ();
				DR=cmd.ExecuteReader ();
				while(DR.Read ())
				{
					lvi = new ListViewItem(DR["BarCode"].ToString ());
					lvi.Tag =DR["BarCode"].ToString ();
					lvi.SubItems .Add (DR["BookLocationId"].ToString ());
					lvi.SubItems.Add  (DR["BookLocationInfo"].ToString ());
					lvi.SubItems.Add (DR["BookRoomInfo"].ToString ());
					lvi.SubItems .Add (DR["����"].ToString ());
					lvi.SubItems .Add (DR["��������"].ToString ());
					lvi.SubItems .Add (DR["������"].ToString ());
					lvi.SubItems .Add (DR["���ֺ�"].ToString ());

					lvi.SubItems .Add (DR["ͼ������"].ToString ());
					lvi.SubItems .Add (DR["�ִκ�"].ToString ());
					lvi.SubItems .Add (DR["���˳���"].ToString ());

					viewProducts.Items.Add (lvi);

					i=i+1;
				}
				conn.Close ();
				lblTotel.Text =i.ToString ()+"��";
				this.Cursor = Cursors.Default;
			}
			catch{}
			//listViewitem


		}

		private void cmdExecute_Click(object sender, System.EventArgs e)
		{
			if(radWei.Checked ==true)
			{
				this.select="select BarCode,BookLocationId,BookLocationInfo,BookRoomInfo,BookId,����,��������,������,�����,������,��������,ҳ��,����,����,�۸�, ��ע,���ֺ�,ͼ������,�ִκ�,���˳���, �������,�ݲ���,�������,�������,�ܽ����,�ܽ���,��Ч�淶,ʧЧ�淶, ָ��, ������Ҫ  FROM ͼ����ϸ where BookId='0' order by BookLocationId ";
				label1.Text ="δ��ͼ��:";
			}
			if(radYi.Checked ==true)
			{
				this.select="select BarCode,BookLocationId,BookLocationInfo,BookRoomInfo,BookId,����,��������,������,�����,������,��������,ҳ��,����,����,�۸�, ��ע,���ֺ�,ͼ������,�ִκ�,���˳���, �������,�ݲ���,�������,�������,�ܽ����,�ܽ���,��Ч�淶,ʧЧ�淶, ָ��, ������Ҫ  FROM ͼ����ϸ  where BookId<>'0' order by BookLocationId";
				label1.Text ="�ѱ�ͼ��:";
			}
			if(radAll.Checked ==true)
			{
				this.select="select BarCode,BookLocationId,BookLocationInfo,BookRoomInfo,BookId,����,��������,������,�����,������,��������,ҳ��,����,����,�۸�, ��ע,���ֺ�,ͼ������,�ִκ�,���˳���, �������,�ݲ���,�������,�������,�ܽ����,�ܽ���,��Ч�淶,ʧЧ�淶, ָ��, ������Ҫ  FROM ͼ����ϸ order by BookLocationId";
				label1.Text ="����ͼ��:";
			}
			RefreshBookList();
		}

		private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(radWei.Checked ==true)
			{
				this.select="select BarCode,BookLocationId,BookLocationInfo,BookRoomInfo,BookId,����,��������,������,�����,������,��������,ҳ��,����,����,�۸�, ��ע,���ֺ�,ͼ������,�ִκ�,���˳���, �������,�ݲ���,�������,�������,�ܽ����,�ܽ���,��Ч�淶,ʧЧ�淶, ָ��, ������Ҫ  FROM ͼ����ϸ where BookId='0'and BookLocationId='"+cboLocation.Text .Trim ()+"'";
				label1.Text =cboLocation.Text .Trim ()+"��δ��ͼ��:";
			}
			if(radYi.Checked ==true)
			{
				this.select="select BarCode,BookLocationId,BookLocationInfo,BookRoomInfo,BookId,����,��������,������,�����,������,��������,ҳ��,����,����,�۸�, ��ע,���ֺ�,ͼ������,�ִκ�,���˳���, �������,�ݲ���,�������,�������,�ܽ����,�ܽ���,��Ч�淶,ʧЧ�淶, ָ��, ������Ҫ  FROM ͼ����ϸ  where BookId<>'0' and BookLocationId='"+cboLocation.Text .Trim ()+"'";
				label1.Text =cboLocation.Text .Trim ()+"���ѱ�ͼ��:";
			}
			if(radAll.Checked ==true)
			{
				this.select="select BarCode,BookLocationId,BookLocationInfo,BookRoomInfo,BookId,����,��������,������,�����,������,��������,ҳ��,����,����,�۸�, ��ע,���ֺ�,ͼ������,�ִκ�,���˳���, �������,�ݲ���,�������,�������,�ܽ����,�ܽ���,��Ч�淶,ʧЧ�淶, ָ��, ������Ҫ  FROM ͼ����ϸ where BookLocationId='"+cboLocation.Text .Trim ()+"'";
				label1.Text =cboLocation.Text .Trim ()+"������ͼ��:";
			}
			RefreshBookList();
		}
		private void Load_cboLocationId()
		{
			try
			{
				cboLocation.Items .Clear ();
				cboLocation.Text ="��ѡ���λ";
				SqlConnection conn =new SqlConnection (this.ConnStr.Trim ());
				SqlCommand cmd =new SqlCommand ("select * from BookLocation",conn);
				SqlDataReader DR;
			
				conn.Open ();
				DR=cmd.ExecuteReader ();
				while(DR.Read ())
				{
					cboLocation.Items.Add (DR["BookLocationId"].ToString ().Trim ());					
				}
				conn.Close ();
			}
			catch
			{
			
			}
		}

		private void viewProducts_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void viewProducts_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
				ListViewItem lvi = viewProducts.FocusedItem;
				frmUpdateBookList fUBL=new frmUpdateBookList(lvi.Text,lvi.SubItems[5].Text ,lvi.SubItems [2].Text);
				fUBL.Text =lvi.Text ;
				fUBL.ShowDialog ();
				//MessageBox.Show(lvi.Text ,lvi.Tag.ToString () );
			}
			catch{}
		}
	
		 
	/// <summary>
	/// ȥ���ַ����еĿո�
	/// </summary>
	/// <param name="TempStr">�����ַ���</param>
	/// <returns>����û�пո���ַ���</returns>
		public string ReplaceKongGe(string TempStr)
		{
			int lenght;
			int start=0;
			string tt="";

			string Str="";
			TempStr=TempStr.Trim ();
			lenght=TempStr.Length ;
			for(start=0;start<lenght;start++)
			{
				tt=TempStr.Substring (start,1);
				if(tt.Equals(" "))
				{
				}
				else
				{
					Str=Str+tt;
				}
			}
			return Str;

		}

		private void cmdQueryRFID_Click(object sender, System.EventArgs e)
		{
			//�����ӱ�ǩ�Ų���
			try
			{
				string tempRFid="";
				tempRFid=this.ReplaceKongGe(this.txtRFID .Text .Trim ());//�õ�ȥ�ո��RFId
				this.select="select BarCode,BookLocationId,BookLocationInfo,BookRoomInfo,BookId,����,��������,������,�����,������,��������,ҳ��,����,����,�۸�, ��ע,���ֺ�,ͼ������,�ִκ�,���˳���, �������,�ݲ���,�������,�������,�ܽ����,�ܽ���,��Ч�淶,ʧЧ�淶, ָ��, ������Ҫ  FROM ͼ����ϸ where Barcode='"+tempRFid.Trim ()+"'";
				this.RefreshBookList ();
				label1.Text ="�����ӱ�ǩ�ҵ�:";
			}
			catch{}
		}

		private void cmdQuerySSH_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.select="select BarCode,BookLocationId,BookLocationInfo,BookRoomInfo,BookId,����,��������,������,�����,������,��������,ҳ��,����,����,�۸�, ��ע,���ֺ�,ͼ������,�ִκ�,���˳���, �������,�ݲ���,�������,�������,�ܽ����,�ܽ���,��Ч�淶,ʧЧ�淶, ָ��, ������Ҫ  FROM ͼ����ϸ where ���ֺ�='"+this.txtWZH .Text .Trim ()+"' and ͼ������='"+this.txtTSFLH .Text .Trim ()+"' and �ִκ�='"+this.txtZCH .Text .Trim ()+"'";
				this.RefreshBookList ();
				label1.Text ="��������ҵ�:";
			}
			catch{}
		}

		private void txtRFID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
		
		}	
	
	}
}
