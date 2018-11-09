using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BIADBOOK
{
	/// <summary>
	/// bookquery ��ժҪ˵����
	/// </summary>
	public class bookquery : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button butquery;
        private System.Windows.Forms.Button butquit;
        public TextBox wzhtb;
        public TextBox tsflhtb;
        public TextBox zchtb;
		public System.Data.SqlClient.SqlConnection sqlc1;
		private System.Data.SqlClient.SqlDataReader sqldr1;
		private System.Data.SqlClient.SqlDataReader sqldr;


		public int formload=0;
		public string s1="",s2="",s3="";
		private System.Windows.Forms.TextBox txtbname;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button butbname;
		public string strConn;
		private System.Data.SqlClient.SqlConnection sqlConn;
		private System.Data.SqlClient.SqlCommand sqlComm;
		private System.Windows.Forms.TreeView booktv;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.TextBox BarCode;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button cmdRFidquery;
		private System.Windows.Forms.Button cmdQuery;
        private Button buttonDetail;


        /// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public bookquery()
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.zchtb = new System.Windows.Forms.TextBox();
            this.tsflhtb = new System.Windows.Forms.TextBox();
            this.wzhtb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.butquery = new System.Windows.Forms.Button();
            this.butquit = new System.Windows.Forms.Button();
            this.txtbname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.butbname = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.booktv = new System.Windows.Forms.TreeView();
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.sqlComm = new System.Data.SqlClient.SqlCommand();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmdQuery = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdRFidquery = new System.Windows.Forms.Button();
            this.BarCode = new System.Windows.Forms.TextBox();
            this.buttonDetail = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.zchtb);
            this.groupBox1.Controls.Add(this.tsflhtb);
            this.groupBox1.Controls.Add(this.wzhtb);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 121);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ͼ���ѯ����";
            // 
            // zchtb
            // 
            this.zchtb.Location = new System.Drawing.Point(96, 88);
            this.zchtb.Name = "zchtb";
            this.zchtb.Size = new System.Drawing.Size(203, 21);
            this.zchtb.TabIndex = 2;
            // 
            // tsflhtb
            // 
            this.tsflhtb.Location = new System.Drawing.Point(96, 56);
            this.tsflhtb.Name = "tsflhtb";
            this.tsflhtb.Size = new System.Drawing.Size(203, 21);
            this.tsflhtb.TabIndex = 1;
            // 
            // wzhtb
            // 
            this.wzhtb.Location = new System.Drawing.Point(96, 24);
            this.wzhtb.Name = "wzhtb";
            this.wzhtb.Size = new System.Drawing.Size(203, 21);
            this.wzhtb.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(40, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "�ִκţ�";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "ͼ�����ţ�";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(40, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "���ֺţ�";
            // 
            // butquery
            // 
            this.butquery.Location = new System.Drawing.Point(18, 301);
            this.butquery.Name = "butquery";
            this.butquery.Size = new System.Drawing.Size(94, 54);
            this.butquery.TabIndex = 1;
            this.butquery.Text = "��ѯ";
            this.butquery.Click += new System.EventHandler(this.butquery_Click);
            // 
            // butquit
            // 
            this.butquit.Location = new System.Drawing.Point(226, 301);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(75, 54);
            this.butquit.TabIndex = 2;
            this.butquit.Text = "�˳�";
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // txtbname
            // 
            this.txtbname.Location = new System.Drawing.Point(64, 152);
            this.txtbname.Name = "txtbname";
            this.txtbname.Size = new System.Drawing.Size(243, 21);
            this.txtbname.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "������";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.butbname);
            this.groupBox2.Location = new System.Drawing.Point(8, 128);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(305, 80);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "������ѯ";
            // 
            // butbname
            // 
            this.butbname.Location = new System.Drawing.Point(118, 51);
            this.butbname.Name = "butbname";
            this.butbname.Size = new System.Drawing.Size(75, 23);
            this.butbname.TabIndex = 0;
            this.butbname.Text = "������ѯ";
            this.butbname.Click += new System.EventHandler(this.butbname_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.booktv);
            this.groupBox3.Location = new System.Drawing.Point(319, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(432, 403);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "������ѯ���";
            // 
            // booktv
            // 
            this.booktv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.booktv.Location = new System.Drawing.Point(3, 17);
            this.booktv.Name = "booktv";
            this.booktv.Size = new System.Drawing.Size(426, 383);
            this.booktv.TabIndex = 0;
            this.booktv.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.booktv_AfterSelect);
            this.booktv.DoubleClick += new System.EventHandler(this.booktv_DoubleClick);
            // 
            // sqlConn
            // 
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cmdQuery);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.cmdRFidquery);
            this.groupBox4.Controls.Add(this.BarCode);
            this.groupBox4.Location = new System.Drawing.Point(8, 208);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(299, 72);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "RFID��ѯ";
            // 
            // cmdQuery
            // 
            this.cmdQuery.Location = new System.Drawing.Point(136, 42);
            this.cmdQuery.Name = "cmdQuery";
            this.cmdQuery.Size = new System.Drawing.Size(72, 24);
            this.cmdQuery.TabIndex = 3;
            this.cmdQuery.Text = "�鿴";
            this.cmdQuery.Click += new System.EventHandler(this.cmdQuery_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "���:";
            // 
            // cmdRFidquery
            // 
            this.cmdRFidquery.Location = new System.Drawing.Point(213, 42);
            this.cmdRFidquery.Name = "cmdRFidquery";
            this.cmdRFidquery.Size = new System.Drawing.Size(80, 24);
            this.cmdRFidquery.TabIndex = 1;
            this.cmdRFidquery.Text = "��Ų�ѯ";
            this.cmdRFidquery.Click += new System.EventHandler(this.cmdRFidquery_Click);
            // 
            // BarCode
            // 
            this.BarCode.Location = new System.Drawing.Point(48, 16);
            this.BarCode.Name = "BarCode";
            this.BarCode.Size = new System.Drawing.Size(245, 21);
            this.BarCode.TabIndex = 0;
            // 
            // buttonDetail
            // 
            this.buttonDetail.Location = new System.Drawing.Point(118, 301);
            this.buttonDetail.Name = "buttonDetail";
            this.buttonDetail.Size = new System.Drawing.Size(94, 54);
            this.buttonDetail.TabIndex = 8;
            this.buttonDetail.Text = "��ѯϸ��";
            this.buttonDetail.Click += new System.EventHandler(this.buttonDetail_Click);
            // 
            // bookquery
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(763, 422);
            this.Controls.Add(this.buttonDetail);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtbname);
            this.Controls.Add(this.butquit);
            this.Controls.Add(this.butquery);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "bookquery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ͼ���ѯ";
            this.Load += new System.EventHandler(this.bookquery_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void butquit_Click(object sender, System.EventArgs e)
		{
			formload=0;
			this.Close();
		}

		private void butquery_Click(object sender, System.EventArgs e)
		{
			
			if(wzhtb.Text=="")
			{
				MessageBox.Show("���������ֺ�");
				return ;
			}
			if(tsflhtb.Text=="")
			{
				MessageBox.Show("������ͼ������");
				return ;
			}
			if(zchtb.Text=="")
			 {
				 MessageBox.Show("�������ִκ�");
				 return ;
			 }
			s1=wzhtb.Text.Trim().ToUpper();
			s2=tsflhtb.Text.Trim().ToUpper();
			s3=zchtb.Text.Trim().ToUpper();

			
			this.sqlc1 = new System.Data.SqlClient.SqlConnection();
			this.sqlc1.ConnectionString = strConn;

			//this.sqldr1=new System.Data.SqlClient.SqlDataReader();
			string sqls="SELECT * FROM book WHERE ���ֺ�='"+s1+"' AND ͼ������='"+s2+"' AND �ִκ�='"+s3+"'";

			System.Data.SqlClient.SqlCommand sqlcomm1=new System.Data.SqlClient.SqlCommand(sqls,sqlc1);
			sqlc1.Open();

			sqldr1=sqlcomm1.ExecuteReader();

			if (sqldr1.HasRows)
			{
				formload=1;
				sqldr1.Close();
				sqlc1.Close();
				this.Close();
			}
			else
			{
				MessageBox.Show("û�������ѯ�ļ�¼");
			}

		}

		private void bookquery_Load(object sender, System.EventArgs e)
		{
			formload=0;

			this.sqlConn.ConnectionString=strConn;
			this.sqlComm.Connection = this.sqlConn;

		}

		private void butbname_Click(object sender, System.EventArgs e)
		{
			if( this.txtbname.Text.Trim()=="")
			{
				return;
			}

			InitTreeView();
		}

		private void InitTreeView()
		{
			booktv.BeginUpdate();
			booktv.Nodes.Clear();

			TreeNode rootNode= new TreeNode("ͼ��");
			booktv.Nodes.Add(rootNode);

			sqlComm.CommandText = "SELECT ����, ���ֺ�, ͼ������, �ִκ�, ��������, ������, ҳ��, ����, ������, �����, ��һ������ FROM book WHERE (���� LIKE N'%"+ this.txtbname.Text +"%')";

			sqlConn.Open();
			sqldr=sqlComm.ExecuteReader();

			if(!sqldr.HasRows)
			{
				sqldr.Close();
				sqlComm.Connection.Close();

				booktv.EndUpdate();

				booktv.Nodes[0].Expand();
				
				return;
			}

			try
			{
				while(sqldr.Read())
				{
					TreeNode tnBook = new TreeNode("������"+sqldr.GetValue(0).ToString());
					booktv.Nodes[0].Nodes.Add(tnBook);

					TreeNode tnwzh = new TreeNode("���ֺţ�"+sqldr.GetValue(1).ToString());
					tnBook.Nodes.Add(tnwzh);
					TreeNode tntsflh = new TreeNode("ͼ�����ţ�"+sqldr.GetValue(2).ToString());
					tnBook.Nodes.Add(tntsflh);
					TreeNode tnzch = new TreeNode("�ִκţ�"+sqldr.GetValue(3).ToString());
					tnBook.Nodes.Add(tnzch);

					TreeNode tnbltm = new TreeNode("����������"+sqldr.GetValue(4).ToString());
					tnBook.Nodes.Add(tnbltm);

					TreeNode tnftm = new TreeNode("��������"+sqldr.GetValue(5).ToString());
					tnBook.Nodes.Add(tnftm);

					
					TreeNode tn06 = new TreeNode("ҳ����"+sqldr.GetValue(6).ToString());
					tnBook.Nodes.Add(tn06);

					TreeNode tn07 = new TreeNode("������"+sqldr.GetValue(7).ToString());
					tnBook.Nodes.Add(tn07);
					
					TreeNode tn08 = new TreeNode("�����ߣ�"+sqldr.GetValue(8).ToString());
					tnBook.Nodes.Add(tn08);
					
					TreeNode tn09 = new TreeNode("����أ�"+sqldr.GetValue(9).ToString());
					tnBook.Nodes.Add(tn09);
					
					TreeNode tn10 = new TreeNode("��һ�����ߣ�"+sqldr.GetValue(10).ToString());
					tnBook.Nodes.Add(tn10);



				}
			}
			finally
			{
				sqldr.Close();
				sqlComm.Connection.Close();
			}

			booktv.EndUpdate();

			booktv.Nodes[0].Expand();

		}

		private void booktv_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{

		
		}

		private void booktv_DoubleClick(object sender, System.EventArgs e)
		{
			int no,num;
			string strC1;

            if (booktv.SelectedNode == null)
            {
                MessageBox.Show("��ѡ���б�");
                return;
            }
			
            TreeNode tn=booktv.SelectedNode;


			if (tn.Text.IndexOf("������")==-1)
			{ //root
				return;
			}

			no=0;
			foreach(TreeNode tns in tn.Nodes)
			{
				
				if(no==3) break;

				if (tns.Text.IndexOf("���ֺţ�")==0)
				{
					strC1=tns.Text.ToUpper();
					num=strC1.IndexOf("��",0);
					strC1=strC1.Remove(0,num+1);
					this.wzhtb.Text=strC1;
					
					no=no+1;
				}

				if (tns.Text.IndexOf("ͼ�����ţ�")==0)
				{
					strC1=tns.Text.ToUpper();
					num=strC1.IndexOf("��",0);
					strC1=strC1.Remove(0,num+1);
					this.tsflhtb.Text=strC1;
					no=no+1;
				}

				if (tns.Text.IndexOf("�ִκţ�")==0)
				{
					strC1=tns.Text.ToUpper();
					num=strC1.IndexOf("��",0);
					strC1=strC1.Remove(0,num+1);
					
					this.zchtb.Text=strC1;
					no=no+1;
				}


			}

            butquery_Click(null, null);

		}

		private void cmdRFidquery_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(BarCode.Text .Trim ().Equals (""))
				{
					MessageBox.Show ("��Ų���Ϊ��");
				}
				else
				{
					DataBookList DBL=new DataBookList();
					DBL.GetDataBookList (BarCode.Text .Trim ());
					wzhtb.Text =DBL.WZH .Trim ();
					tsflhtb.Text =DBL.TSFLH .Trim ();
					zchtb.Text =DBL.ZCH .Trim ();
					txtbname.Text =DBL.BookName .Trim ();
				}
			}
			catch(Exception exx){MessageBox.Show (exx.ToString ());}
		}

		private void cmdQuery_Click(object sender, System.EventArgs e)
		{
			if(wzhtb.Text=="")
			{
				MessageBox.Show("���������ֺ�");
				return ;
			}
			if(tsflhtb.Text=="")
			{
				MessageBox.Show("������ͼ������");
				return ;
			}
			if(zchtb.Text=="")
			{
				MessageBox.Show("�������ִκ�");
				return ;
			}
			try
			{
				QueryRFIDBook qrb=new QueryRFIDBook (wzhtb.Text .Trim (),tsflhtb.Text .Trim (),zchtb.Text .Trim ());
				qrb.ShowDialog ();
	//			qrb.RefreshBookList(wzhtb.Text .Trim (),tsflhtb.Text .Trim (),zchtb.Text .Trim ());
				
			}
			catch{}
		}

        private void buttonDetail_Click(object sender, EventArgs e)
        {
            booktv_DoubleClick(null,null);
        }


	}
}
