using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BIADBOOK
{
	/// <summary>
	/// FormCountL ��ժҪ˵����
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
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;


		public FormCountL()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
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

			sqlComm.CommandText="SELECT COUNT(*),sum(�ݲ���) FROM book";

			sqlConn.Open();
			sqldr=sqlComm.ExecuteReader();
			sqldr.Read();
			st1=sqldr.GetValue(0).ToString();
			stt1=sqldr.GetValue(1).ToString();
			sqldr.Close();


			sqlComm.CommandText="SELECT COUNT(*),sum(�ݲ���) FROM book WHERE ͼ������<>'��' and ͼ������<>'��' and ͼ������<>'ů' and ͼ������<>'��' and ͼ������<>'��' and ͼ������<>'ʩ' and ͼ������<>'��' and ͼ������<>'��' and ͼ������<>'��' and ͼ������<>'��1' and ͼ������<>'��2' and ͼ������<>'��3' and ͼ������<>'��4' and ͼ������<>'��5' and ͼ������<>'��1' and ͼ������<>'��' and ͼ������<>'��' and ͼ������<>'��' and ͼ������<>'��'  ";
			sqldr=sqlComm.ExecuteReader();
			sqldr.Read();
			st2=sqldr.GetValue(0).ToString();
			stt2=sqldr.GetValue(1).ToString();
			sqldr.Close();

			sqlComm.CommandText="SELECT COUNT(*),sum(�ݲ���) FROM book WHERE ͼ������='��' or ͼ������='��' or ͼ������='ů' or ͼ������='��' or ͼ������='��' or ͼ������='ʩ' or ͼ������='��' or ͼ������='��' or ͼ������='��' or ͼ������='��1' or ͼ������='��2' or ͼ������='��3' or ͼ������='��4' or ͼ������='��5' or ͼ������='��1' or ͼ������='��' or ͼ������='��' or ͼ������='��' or ͼ������='��'";
			sqldr=sqlComm.ExecuteReader();
			sqldr.Read();
			st3=sqldr.GetValue(0).ToString();
			stt3=sqldr.GetValue(1).ToString();
			sqldr.Close();

			booktv.BeginUpdate();
			booktv.Nodes.Clear();

			TreeNode rootNode= new TreeNode(System.DateTime.Now.Year.ToString() +"��"+System.DateTime.Now.Month.ToString()+"��"+System.DateTime.Now.Day.ToString()+"�գ�ͼ��ݹݲ���Ϣ��");
			booktv.Nodes.Add(rootNode);

			TreeNode tnBook1 = new TreeNode("����ͼ�飺"+st1+"�֣�"+stt1+"����������ͼ��"+st2+"�֣�"+stt2+"��������"+st3+"�֣�"+stt3+"����");
			rootNode.Nodes.Add(tnBook1);
				
			TreeNode tnBook01 = new TreeNode("");
			rootNode.Nodes.Add(tnBook01);

			sqlComm.CommandText="SELECT COUNT(*),sum(�ݲ���) FROM book WHERE ���ֺ�='1' and ͼ������<>'��' and ͼ������<>'��' and ͼ������<>'ů' and ͼ������<>'��' and ͼ������<>'��' and ͼ������<>'ʩ' and ͼ������<>'��' and ͼ������<>'��' and ͼ������<>'��' and ͼ������<>'��1' and ͼ������<>'��2' and ͼ������<>'��3' and ͼ������<>'��4' and ͼ������<>'��5' and ͼ������<>'��1' and ͼ������<>'��'  and ͼ������<>'��' and ͼ������<>'��' and ͼ������<>'��' ";
			sqldr=sqlComm.ExecuteReader();
			sqldr.Read();

			TreeNode tnBook2 = new TreeNode("����ͼ�飺"+sqldr.GetValue(0).ToString()+"�֣�"+sqldr.GetValue(1).ToString()+"��");
			rootNode.Nodes.Add(tnBook2);
			sqldr.Close();

			sqlComm.CommandText="SELECT COUNT(*),sum(�ݲ���) FROM book WHERE (���ֺ� = N'2') AND (ͼ������ NOT LIKE N'��%') AND (ͼ������ NOT LIKE N'��%') AND (ͼ������ NOT LIKE N'ů%') AND (ͼ������ NOT LIKE N'��%') AND (ͼ������ NOT LIKE N'��%') AND (ͼ������ NOT LIKE N'ʩ%') AND (ͼ������ NOT LIKE N'��%') AND (ͼ������ NOT LIKE N'��%') AND (ͼ������ NOT LIKE N'��%') AND (ͼ������ NOT LIKE N'��%') AND (ͼ������ NOT LIKE N'��%') AND (ͼ������ NOT LIKE N'��%') AND (ͼ������ NOT LIKE N'��%')";
			sqldr=sqlComm.ExecuteReader();
			sqldr.Read();

			TreeNode tnBook3 = new TreeNode("����ͼ�飺"+sqldr.GetValue(0).ToString()+"�֣�"+sqldr.GetValue(1).ToString()+"��");
			rootNode.Nodes.Add(tnBook3);
			sqldr.Close();

			sqlComm.CommandText="SELECT COUNT(*),sum(�ݲ���) FROM book WHERE ���ֺ�='4' and ͼ������<>'��' and ͼ������<>'��' and ͼ������<>'ů' and ͼ������<>'��' and ͼ������<>'��' and ͼ������<>'ʩ' and ͼ������<>'��' and ͼ������<>'��' and ͼ������<>'��' and ͼ������<>'��1' and ͼ������<>'��2' and ͼ������<>'��3' and ͼ������<>'��4' and ͼ������<>'��5' and ͼ������<>'��1' and ͼ������<>'��' and ͼ������<>'��' and ͼ������<>'��' and ͼ������<>'��'  ";
			sqldr=sqlComm.ExecuteReader();
			sqldr.Read();

			TreeNode tnBook4 = new TreeNode("����ͼ�飺"+sqldr.GetValue(0).ToString()+"�֣�"+sqldr.GetValue(1).ToString()+"��");
			rootNode.Nodes.Add(tnBook4);
			sqldr.Close();

			sqlComm.CommandText="SELECT COUNT(*),sum(�ݲ���) FROM book WHERE ͼ������='��' or ͼ������='��' or ͼ������='ů' or ͼ������='��' or ͼ������='��' or ͼ������='ʩ' or ͼ������='��' or ͼ������='��' or ͼ������='��' or ͼ������='��1' or ͼ������='��2' or ͼ������='��3' or ͼ������='��4' or ͼ������='��5' or ͼ������='��1' or ͼ������='��' or ͼ������='��' or ͼ������='��' and ͼ������<>'��'";;
			sqldr=sqlComm.ExecuteReader();
			sqldr.Read();

			TreeNode tnBook02 = new TreeNode("");
			rootNode.Nodes.Add(tnBook02);

			TreeNode tnBook5 = new TreeNode("�������ϣ�"+sqldr.GetValue(0).ToString()+"�֣�"+sqldr.GetValue(1).ToString()+"��");
			rootNode.Nodes.Add(tnBook5);
			sqldr.Close();

			sqlComm.CommandText="SELECT COUNT(*),sum(�ݲ���) FROM book WHERE (���ֺ� = N'2') AND (ͼ������ LIKE N'��%')";
			sqldr=sqlComm.ExecuteReader();
			sqldr.Read();

			TreeNode tnBook6 = new TreeNode("�������ϣ�"+sqldr.GetValue(0).ToString()+"�֣�"+sqldr.GetValue(1).ToString()+"��");
			rootNode.Nodes.Add(tnBook6);
			sqldr.Close();

			sqlComm.CommandText="SELECT COUNT(*),sum(�ݲ���) FROM book WHERE (���ֺ� = N'4') AND (ͼ������ LIKE N'��%')";
			sqldr=sqlComm.ExecuteReader();
			sqldr.Read();

			TreeNode tnBook7 = new TreeNode("�������ϣ�"+sqldr.GetValue(0).ToString()+"�֣�"+sqldr.GetValue(1).ToString()+"��");
			rootNode.Nodes.Add(tnBook7);
			sqldr.Close();



			sqlConn.Close();
			booktv.EndUpdate();
			rootNode.Expand();

			makebufferprint();

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
			this.button1.Text = "��ӡ";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(216, 256);
			this.button2.Name = "button2";
			this.button2.TabIndex = 2;
			this.button2.Text = "��ӡԤ��";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(400, 256);
			this.button3.Name = "button3";
			this.button3.TabIndex = 3;
			this.button3.Text = "�� ��";
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

		private void button2_Click(object sender, System.EventArgs e)
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
