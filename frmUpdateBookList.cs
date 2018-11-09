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
	/// frmUpdateBookList ��ժҪ˵����
	/// </summary>
	public class frmUpdateBookList : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label ylblWZH;
		private System.Windows.Forms.Label ylblSM;
		private System.Windows.Forms.Label ylblBH;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.ComboBox cboBookLocation;
		private System.Windows.Forms.Button button1;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmUpdateBookList()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
		}
		public frmUpdateBookList(string Barcode,string bookname,string booklocation)
		{
			InitializeComponent();
			this.ylblBH .Text =Barcode.Trim ();
			this.ylblSM .Text =bookname.Trim ();
			this.ylblWZH .Text =booklocation.Trim ();
		
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
			this.ylblWZH = new System.Windows.Forms.Label();
			this.ylblSM = new System.Windows.Forms.Label();
			this.ylblBH = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.cboBookLocation = new System.Windows.Forms.ComboBox();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// ylblWZH
			// 
			this.ylblWZH.Font = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.ylblWZH.Location = new System.Drawing.Point(96, 88);
			this.ylblWZH.Name = "ylblWZH";
			this.ylblWZH.Size = new System.Drawing.Size(144, 16);
			this.ylblWZH.TabIndex = 23;
			this.ylblWZH.Text = "ylblWZH";
			// 
			// ylblSM
			// 
			this.ylblSM.Font = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.ylblSM.Location = new System.Drawing.Point(96, 40);
			this.ylblSM.Name = "ylblSM";
			this.ylblSM.Size = new System.Drawing.Size(224, 48);
			this.ylblSM.TabIndex = 22;
			this.ylblSM.Text = "ylblSM";
			// 
			// ylblBH
			// 
			this.ylblBH.Font = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.ylblBH.Location = new System.Drawing.Point(96, 8);
			this.ylblBH.Name = "ylblBH";
			this.ylblBH.Size = new System.Drawing.Size(224, 16);
			this.ylblBH.TabIndex = 21;
			this.ylblBH.Text = "ylblBH";
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label9.Location = new System.Drawing.Point(8, 88);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(80, 16);
			this.label9.TabIndex = 11;
			this.label9.Text = "��λ���:";
			// 
			// label13
			// 
			this.label13.Font = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label13.Location = new System.Drawing.Point(8, 8);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(88, 16);
			this.label13.TabIndex = 15;
			this.label13.Text = "RFID���:";
			// 
			// label12
			// 
			this.label12.Font = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label12.Location = new System.Drawing.Point(8, 32);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(72, 16);
			this.label12.TabIndex = 14;
			this.label12.Text = "����:";
			// 
			// cboBookLocation
			// 
			this.cboBookLocation.Location = new System.Drawing.Point(8, 120);
			this.cboBookLocation.Name = "cboBookLocation";
			this.cboBookLocation.Size = new System.Drawing.Size(112, 20);
			this.cboBookLocation.TabIndex = 19;
			this.cboBookLocation.Text = "��ѡ���λ";
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Location = new System.Drawing.Point(128, 120);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(200, 24);
			this.button1.TabIndex = 24;
			this.button1.Text = "�޸ļ�λ";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// frmUpdateBookList
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(336, 149);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.cboBookLocation);
			this.Controls.Add(this.ylblBH);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.ylblWZH);
			this.Controls.Add(this.ylblSM);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmUpdateBookList";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmUpdateBookList";
			this.Load += new System.EventHandler(this.frmUpdateBookList_Load);
			this.ResumeLayout(false);

		}
		#endregion
			private string  strConn;
		private void frmUpdateBookList_Load(object sender, System.EventArgs e)
		{
			try
			{
				string SPath;
				SPath=Directory.GetCurrentDirectory().ToString()+"\\Config.ini";
				//�ж�Config.ini�ļ��Ƿ����
				if(File.Exists(SPath))
				{
					//����Config.ini�ļ��еĸ�����
					IniFile ini = new IniFile(SPath);
					//[DataBase]ConnectionString
					if(ini.IniReadValue("DataBase","ConnectionString")!="")
					{ 
						this.strConn =ini.IniReadValue("DataBase","ConnectionString").Trim(); 
					}
				}
				/////////////////////////////////////////////////////////////////////////
				Load_cboLocationId();
			}
			catch{}
		}

		private void Load_cboLocationId()
		{
			try
			{
				this.cboBookLocation.Items .Clear ();
				SqlConnection conn =new SqlConnection (this.strConn.Trim ());
				SqlCommand cmd =new SqlCommand ("select * from BookLocation",conn);
				SqlDataReader DR;
			
				conn.Open ();
				DR=cmd.ExecuteReader ();
				while(DR.Read ())
				{
					this.cboBookLocation.Items.Add (DR["BookLocationId"].ToString ().Trim ());					
				}
				conn.Close ();
			}
			catch
			{
					
			}
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(!this.cboBookLocation .Text .Trim ().Equals (""))
				{
			
					if (this.cboBookLocation .Text .Trim ().Equals ("��ѡ���λ") )
					{
						MessageBox.Show ("��ѡ���λ");
					}
					else
					{
						DataBookList dbl=new DataBookList ();
						dbl.updateBooklist (this.ylblBH .Text .Trim (),this.cboBookLocation .Text.Trim ());
						MessageBox.Show ("�޸ļ�λ�ɹ�");
						this.Close ();
					}
				}
				else
				{
					MessageBox.Show ("��ѡ���λ");
				}
			
			}
			catch{}
		}
	}
}
