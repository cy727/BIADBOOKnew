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
	/// QueryRFIDBook ��ժҪ˵����
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
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public QueryRFIDBook()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
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
			this.columnHeader1.Text = "���";
			this.columnHeader1.Width = 110;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "����";
			this.columnHeader2.Width = 129;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "λ�ܱ��";
			this.columnHeader3.Width = 102;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "���";
			this.columnHeader4.Width = 77;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(184, 168);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(152, 32);
			this.button1.TabIndex = 1;
			this.button1.Text = "�˳�";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "������";
			this.columnHeader5.Width = 73;
			// 
			// QueryRFIDBook
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(512, 206);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.listView1);
			this.Name = "QueryRFIDBook";
			this.Text = "���������ϸ";
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
				//�ж�Config.ini�ļ��Ƿ����
				if(File.Exists(QPath))
				{
					//����Config.ini�ļ��еĸ�����
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
		//�������ֺ�,ͼ�����ţ��ִκŲ���<ͼ����ϸ>���еļ�¼
		public void RefreshBookList()
		{
			try
			{
				string select="";
				this.Cursor = Cursors.WaitCursor;
				select="select BarCode,BookLocationId,BookLocationInfo,BookRoomInfo,BookId,����,��������,������,�����,������,��������,ҳ��,����,����,�۸�, ��ע,���ֺ�,ͼ������,�ִκ�,���˳���, �������,�ݲ���,�������,�������,�ܽ����,�ܽ���,��Ч�淶,ʧЧ�淶, ָ��, ������Ҫ  FROM ͼ����ϸ where ���ֺ�='"+wzh.Trim ()+"' and ͼ������='"+tsflh.Trim ()+"' and �ִκ�='"+zch.Trim ()+"'";

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
					lvi.SubItems .Add (DR["����"].ToString ());

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
