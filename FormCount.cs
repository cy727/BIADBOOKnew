using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BIADBOOK
{
	/// <summary>
	/// FormCount ��ժҪ˵����
	/// </summary>
	public class FormCount : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		public string strConn,strhrConn;
		private System.Data.SqlClient.SqlConnection sqlConn;
		private System.Data.SqlClient.SqlCommand sqlComm;
		private System.Data.SqlClient.SqlDataReader sqldr;
		private System.Windows.Forms.TreeView booktv;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.DateTimePicker dTPicker;
		private System.Windows.Forms.Button button6;
		private System.Drawing.Printing.PrintDocument pd;
		public Font printfont; 
		string[] lines;

		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormCount()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCount));
            this.booktv = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.sqlComm = new System.Data.SqlClient.SqlCommand();
            this.dTPicker = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.pd = new System.Drawing.Printing.PrintDocument();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // booktv
            // 
            this.booktv.Location = new System.Drawing.Point(8, 16);
            this.booktv.Name = "booktv";
            this.booktv.Size = new System.Drawing.Size(488, 208);
            this.booktv.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(152, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "���ͳ��";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(232, 288);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(168, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "ͳ��ȫ��ͼ����Ϣ";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(408, 288);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(88, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "�ر�";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // sqlConn
            // 
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // dTPicker
            // 
            this.dTPicker.CustomFormat = "yyyy�� MMMM";
            this.dTPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dTPicker.Location = new System.Drawing.Point(24, 248);
            this.dTPicker.Name = "dTPicker";
            this.dTPicker.Size = new System.Drawing.Size(112, 21);
            this.dTPicker.TabIndex = 5;
            this.dTPicker.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(8, 232);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(488, 48);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "��ȡ��¶�ͳ��";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(256, 16);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 2;
            this.button5.Text = "�¶�ͳ��";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(16, 288);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "�����ӡ";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // pd
            // 
            this.pd.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pd_PrintPage);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(104, 288);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 8;
            this.button6.Text = "��ӡԤ��";
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // FormCount
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(504, 326);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.dTPicker);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.booktv);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCount";
            this.Text = "����ͳ��";
            this.Load += new System.EventHandler(this.FormCount_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void FormCount_Load(object sender, System.EventArgs e)
		{
			sqlConn.ConnectionString=strConn;
			sqlComm.Connection=sqlConn;
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			string strYear;

			strYear=dTPicker.Value.Year.ToString();

			sqlComm.CommandText="SELECT COUNT(*) FROM borrow WHERE (���ʱ�� > '"+ strYear +"-01-01') AND (���ʱ�� < '"+ strYear +"-12-31  23:59:59')";

			sqlConn.Open();
			sqldr=sqlComm.ExecuteReader();
			sqldr.Read();

			booktv.BeginUpdate();
			booktv.Nodes.Clear();

			TreeNode rootNode= new TreeNode(strYear+"���ͼ�������Ϣ��");
			booktv.Nodes.Add(rootNode);

			TreeNode tnBook1 = new TreeNode("�����ͼ�飺"+sqldr.GetValue(0).ToString()+"��");
			rootNode.Nodes.Add(tnBook1);
				
			sqldr.Close();

			sqlComm.CommandText="SELECT COUNT(*) FROM borrow WHERE (ʵ�ʹ黹ʱ�� > '"+ strYear +"-01-01') AND (ʵ�ʹ黹ʱ�� < '"+ strYear +"-12-31  23:59:59') AND (ʵ�ʹ黹ʱ�� IS NOT NULL)";

			sqldr=sqlComm.ExecuteReader();
			sqldr.Read();

			TreeNode tnBook2 = new TreeNode("���黹ͼ�飺"+sqldr.GetValue(0).ToString()+"��");
			rootNode.Nodes.Add(tnBook2);

			sqldr.Close();
			

			//sqlComm.CommandText="SELECT COUNT(*) FROM borrow WHERE (���ʱ�� > '"+ strYear +"-01-01') AND (���ʱ�� < '"+ strYear +"-12-31') AND (ʵ�ʹ黹ʱ�� IS NULL)";
			//sqlComm.CommandText="SELECT COUNT(*) FROM borrow WHERE (ʵ�ʹ黹ʱ�� IS NULL)";
			sqlComm.CommandText="SELECT COUNT(*) FROM borrow WHERE (ʵ�ʹ黹ʱ�� > CONVERT(DATETIME, '"+ strYear +"-12-31 23:59:59', 102) OR ʵ�ʹ黹ʱ�� IS NULL) AND (���ʱ�� < CONVERT(DATETIME, '"+ strYear +"-12-31 23:59:59', 102))";

			sqldr=sqlComm.ExecuteReader();
			sqldr.Read();

			TreeNode tnBook21 = new TreeNode("δ�黹ͼ�飺"+sqldr.GetValue(0).ToString()+"��");
			rootNode.Nodes.Add(tnBook21);

			sqldr.Close();
			
			//sqlComm.CommandText="SELECT COUNT(*) FROM borrow WHERE (ʵ�ʹ黹ʱ�� IS NULL) AND (�黹ʱ��<'"+System.DateTime.Now.ToString()+"')";
			sqlComm.CommandText="SELECT COUNT(*) FROM borrow WHERE (�黹ʱ��<'"+ strYear +"-12-31  23:59:59')";

			sqldr=sqlComm.ExecuteReader();
			sqldr.Read();

			TreeNode tnBook3 = new TreeNode("�ѵ���ͼ�飺"+sqldr.GetValue(0).ToString()+"��");
			rootNode.Nodes.Add(tnBook3);

			sqldr.Close();
			
			sqlComm.CommandText="SELECT COUNT(*) FROM book WHERE (������� > '"+ strYear +"-01-01') AND (������� < '"+ strYear +"-12-31  23:59:59')";

			sqldr=sqlComm.ExecuteReader();
			sqldr.Read();

			TreeNode tnBook4 = new TreeNode("���ͼ�飺"+sqldr.GetValue(0).ToString()+"��");
			rootNode.Nodes.Add(tnBook4);

			sqldr.Close();
			
			sqlConn.Close();


			booktv.EndUpdate();
			rootNode.Expand();

			makebufferprint();

		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			//string strYear;

			//strYear=System.DateTime.Now.Year.ToString();

			sqlComm.CommandText="SELECT COUNT(*) FROM borrow ";

			sqlConn.Open();
			sqldr=sqlComm.ExecuteReader();
			sqldr.Read();

			booktv.BeginUpdate();
			booktv.Nodes.Clear();

			TreeNode rootNode= new TreeNode("ȫ��ͼ�������Ϣ");
			booktv.Nodes.Add(rootNode);

			TreeNode tnBook1 = new TreeNode("�����ͼ�飺"+sqldr.GetValue(0).ToString()+"��");
			rootNode.Nodes.Add(tnBook1);
				
			sqldr.Close();
			
			
			sqlComm.CommandText="SELECT COUNT(*) FROM borrow WHERE (ʵ�ʹ黹ʱ�� IS NULL)";

			sqldr=sqlComm.ExecuteReader();
			sqldr.Read();

			TreeNode tnBook2 = new TreeNode("δ�黹ͼ�飺"+sqldr.GetValue(0).ToString()+"��");
			rootNode.Nodes.Add(tnBook2);

			sqldr.Close();
			
			sqlComm.CommandText="SELECT COUNT(*) FROM borrow WHERE (ʵ�ʹ黹ʱ�� IS NULL) AND (�黹ʱ��<'"+System.DateTime.Now.ToString()+"')";

			sqldr=sqlComm.ExecuteReader();
			sqldr.Read();

			TreeNode tnBook3 = new TreeNode("�ѵ���ͼ�飺"+sqldr.GetValue(0).ToString()+"��");
			rootNode.Nodes.Add(tnBook3);

			sqldr.Close();
			sqlConn.Close();


			booktv.EndUpdate();
			rootNode.Expand();

			makebufferprint();
		
		}

		private void dateTimePicker1_ValueChanged(object sender, System.EventArgs e)
		{
		
		}

		private void button5_Click(object sender, System.EventArgs e)
		{
			string strYear;
			string strMon,strDay;

			strYear=dTPicker.Value.Year.ToString();
			strMon=dTPicker.Value.Month.ToString();
			strDay=System.DateTime.DaysInMonth(dTPicker.Value.Year,dTPicker.Value.Month).ToString();
			

			sqlComm.CommandText="SELECT COUNT(*) FROM borrow ";

			sqlComm.CommandText="SELECT COUNT(*) FROM borrow WHERE (���ʱ�� > '"+ strYear +"-"+strMon+"-01') AND (���ʱ�� < '"+ strYear +"-"+strMon+"-"+strDay+" 23:59:59')";

			sqlConn.Open();
			sqldr=sqlComm.ExecuteReader();
			sqldr.Read();

			booktv.BeginUpdate();
			booktv.Nodes.Clear();

			TreeNode rootNode= new TreeNode(strYear+"��"+strMon+"��ͼ�������Ϣ��");
			booktv.Nodes.Add(rootNode);

			TreeNode tnBook1 = new TreeNode("�����ͼ�飺"+sqldr.GetValue(0).ToString()+"��");
			rootNode.Nodes.Add(tnBook1);
				
			sqldr.Close();

			sqlComm.CommandText="SELECT COUNT(*) FROM borrow WHERE (ʵ�ʹ黹ʱ�� > '"+ strYear +"-"+strMon+"-01') AND (ʵ�ʹ黹ʱ�� < '"+ strYear +"-"+strMon+"-"+strDay+" 23:59:59')";

			sqldr=sqlComm.ExecuteReader();
			sqldr.Read();

			TreeNode tnBook2 = new TreeNode("���黹ͼ�飺"+sqldr.GetValue(0).ToString()+"��");
			rootNode.Nodes.Add(tnBook2);

			sqldr.Close();
			

			sqlComm.CommandText="SELECT COUNT(*) FROM borrow WHERE (ʵ�ʹ黹ʱ�� > CONVERT(DATETIME, '"+ strYear +"-"+strMon+"-"+strDay+" 23:59:59', 102) OR ʵ�ʹ黹ʱ�� IS NULL) AND (���ʱ�� < CONVERT(DATETIME, '"+ strYear +"-"+strMon+"-"+strDay+" 23:59:59', 102))";
			sqldr=sqlComm.ExecuteReader();
			sqldr.Read();

			TreeNode tnBook21 = new TreeNode("δ�黹ͼ�飺"+sqldr.GetValue(0).ToString()+"��");
			rootNode.Nodes.Add(tnBook21);

			sqldr.Close();
			
			//sqlComm.CommandText="SELECT COUNT(*) FROM borrow WHERE (ʵ�ʹ黹ʱ�� IS NULL) AND (�黹ʱ��<'"+System.DateTime.Now.ToString()+"')";
			sqlComm.CommandText="SELECT COUNT(*) FROM borrow WHERE (�黹ʱ��<'"+ strYear +"-"+strMon+"-"+strDay+"  23:59:59')";

			sqldr=sqlComm.ExecuteReader();
			sqldr.Read();

			TreeNode tnBook3 = new TreeNode("�ѵ���ͼ�飺"+sqldr.GetValue(0).ToString()+"��");
			rootNode.Nodes.Add(tnBook3);

			sqldr.Close();


			sqlComm.CommandText="SELECT COUNT(*) FROM book WHERE (������� > '"+ strYear +"-"+strMon+"-01') AND (������� <'"+ strYear +"-"+strMon+"-"+strDay+"  23:59:59')";

			sqldr=sqlComm.ExecuteReader();
			sqldr.Read();

			TreeNode tnBook4 = new TreeNode("���ͼ�飺"+sqldr.GetValue(0).ToString()+"��");
			rootNode.Nodes.Add(tnBook4);

			sqldr.Close();

			//���ڵ�
			sqlComm.CommandText="SELECT ����, ���ֺ�, ͼ������, �ִκ�, ������� FROM book WHERE (������� > '"+ strYear +"-"+strMon+"-01') AND (������� <'"+ strYear +"-"+strMon+"-"+strDay+"  23:59:59') ORDER BY ������� DESC, ����";

			sqldr=sqlComm.ExecuteReader();
			while(sqldr.Read())
			{
				TreeNode tnBook5 = new TreeNode(sqldr.GetValue(0).ToString()+"��"+sqldr.GetValue(1).ToString()+"��"+sqldr.GetValue(2).ToString()+"��"+sqldr.GetValue(3).ToString()+"��"+sqldr.GetValue(4).ToString()+"��");
				tnBook4.Nodes.Add(tnBook5);
			}

			sqldr.Close();
			
			
			sqlConn.Close();
			booktv.EndUpdate();
			rootNode.Expand();

			makebufferprint();
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


		private void button4_Click(object sender, System.EventArgs e)
		{

			pd.DocumentName="ͳ�Ʊ���";
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

			printfont=new Font("����",12F,System.Drawing.FontStyle.Bold);
			
			while(nCount<lines.Length)
			{
				fltYPos=10+(nCount*printfont.GetHeight(e.Graphics));
				e.Graphics.DrawString(lines[nCount],
					printfont,Brushes.Black,100,fltYPos);
				nCount++;
			}

			e.HasMorePages=false;


			
		}

		private void button6_Click(object sender, System.EventArgs e)
		{
			PrintPreviewDialog ppd=new PrintPreviewDialog();


			pd.DocumentName="ͳ�Ʊ���";
			pd.DefaultPageSettings.Margins=new System.Drawing.Printing.Margins(100,100,100,100);
			//PrintPreviewControl
			ppd.Document=pd;
			ppd.ShowDialog();
		}
	}
}
