using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;

using System.IO ;
using System.Text ;
using System.Data ;
using System.Data .SqlClient;

namespace BIADBOOK
{
	/// <summary>
	/// PrintRepairCode ��ժҪ˵����
	/// </summary>
	public class PrintRepairCode : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button cmdPrint;
		private System.Windows.Forms.Button cmdCanel;
		private System.Windows.Forms.TextBox txtBarCode;
		private System.Windows.Forms.Label lblWZH;
		private System.Windows.Forms.Label lblTSFLH;
		private System.Windows.Forms.Label lblZCH;
		private System.Windows.Forms.Label lblNDSXH;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox grpBH;
		private System.Windows.Forms.Label lblSM;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btnNotPrint;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PrintRepairCode()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
		}
		
		
		private string strWZH="";
		private string strTSFLH="";
		private string strZCH="";
		private string strNDSXH="";
		private string strBH="";
		private string ConnectionString;//���ݿ������ַ���


		public PrintRepairCode(string WZH,string TSFLH,string ZCH)
		{
			
			this.strWZH =WZH.Trim ();
			this.strTSFLH =TSFLH.Trim ();
			this.strZCH =ZCH.Trim ();
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
			this.txtBarCode = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.cmdPrint = new System.Windows.Forms.Button();
			this.cmdCanel = new System.Windows.Forms.Button();
			this.lblWZH = new System.Windows.Forms.Label();
			this.lblTSFLH = new System.Windows.Forms.Label();
			this.lblZCH = new System.Windows.Forms.Label();
			this.lblNDSXH = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.grpBH = new System.Windows.Forms.GroupBox();
			this.lblSM = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.btnNotPrint = new System.Windows.Forms.Button();
			this.grpBH.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtBarCode
			// 
			this.txtBarCode.Location = new System.Drawing.Point(112, 160);
			this.txtBarCode.Name = "txtBarCode";
			this.txtBarCode.Size = new System.Drawing.Size(392, 26);
			this.txtBarCode.TabIndex = 0;
			this.txtBarCode.Text = "textBox1";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 168);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "������:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "���ֺ�:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(120, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(104, 16);
			this.label3.TabIndex = 3;
			this.label3.Text = "ͼ������:";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(344, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 16);
			this.label4.TabIndex = 4;
			this.label4.Text = "�ִκ�:";
			// 
			// cmdPrint
			// 
			this.cmdPrint.Location = new System.Drawing.Point(312, 192);
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.Size = new System.Drawing.Size(88, 32);
			this.cmdPrint.TabIndex = 5;
			this.cmdPrint.Text = "��ӡ";
			this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
			// 
			// cmdCanel
			// 
			this.cmdCanel.Location = new System.Drawing.Point(408, 192);
			this.cmdCanel.Name = "cmdCanel";
			this.cmdCanel.Size = new System.Drawing.Size(96, 32);
			this.cmdCanel.TabIndex = 6;
			this.cmdCanel.Text = "ȡ��";
			this.cmdCanel.Click += new System.EventHandler(this.cmdCanel_Click);
			// 
			// lblWZH
			// 
			this.lblWZH.Location = new System.Drawing.Point(80, 24);
			this.lblWZH.Name = "lblWZH";
			this.lblWZH.Size = new System.Drawing.Size(32, 16);
			this.lblWZH.TabIndex = 7;
			this.lblWZH.Text = "label5";
			// 
			// lblTSFLH
			// 
			this.lblTSFLH.Location = new System.Drawing.Point(224, 24);
			this.lblTSFLH.Name = "lblTSFLH";
			this.lblTSFLH.Size = new System.Drawing.Size(120, 16);
			this.lblTSFLH.TabIndex = 8;
			this.lblTSFLH.Text = "label5";
			// 
			// lblZCH
			// 
			this.lblZCH.Location = new System.Drawing.Point(408, 24);
			this.lblZCH.Name = "lblZCH";
			this.lblZCH.Size = new System.Drawing.Size(80, 16);
			this.lblZCH.TabIndex = 9;
			this.lblZCH.Text = "label5";
			// 
			// lblNDSXH
			// 
			this.lblNDSXH.Location = new System.Drawing.Point(112, 136);
			this.lblNDSXH.Name = "lblNDSXH";
			this.lblNDSXH.Size = new System.Drawing.Size(392, 16);
			this.lblNDSXH.TabIndex = 10;
			this.lblNDSXH.Text = "label5";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 136);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(96, 16);
			this.label5.TabIndex = 11;
			this.label5.Text = "���˳���:";
			// 
			// grpBH
			// 
			this.grpBH.Controls.Add(this.label2);
			this.grpBH.Controls.Add(this.lblWZH);
			this.grpBH.Controls.Add(this.label3);
			this.grpBH.Controls.Add(this.lblTSFLH);
			this.grpBH.Controls.Add(this.label4);
			this.grpBH.Controls.Add(this.lblZCH);
			this.grpBH.Location = new System.Drawing.Point(8, 8);
			this.grpBH.Name = "grpBH";
			this.grpBH.Size = new System.Drawing.Size(496, 48);
			this.grpBH.TabIndex = 12;
			this.grpBH.TabStop = false;
			this.grpBH.Text = "grpBH ";
			// 
			// lblSM
			// 
			this.lblSM.Location = new System.Drawing.Point(112, 64);
			this.lblSM.Name = "lblSM";
			this.lblSM.Size = new System.Drawing.Size(392, 64);
			this.lblSM.TabIndex = 13;
			this.lblSM.Text = "label6";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(16, 64);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(96, 24);
			this.label6.TabIndex = 14;
			this.label6.Text = "��      ��:";
			// 
			// btnNotPrint
			// 
			this.btnNotPrint.Location = new System.Drawing.Point(104, 192);
			this.btnNotPrint.Name = "btnNotPrint";
			this.btnNotPrint.Size = new System.Drawing.Size(168, 32);
			this.btnNotPrint.TabIndex = 17;
			this.btnNotPrint.Text = "���±�Ŀ��������Ϣ";
			this.btnNotPrint.Click += new System.EventHandler(this.btnNotPrint_Click);
			// 
			// PrintRepairCode
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
			this.ClientSize = new System.Drawing.Size(512, 230);
			this.Controls.Add(this.btnNotPrint);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.lblSM);
			this.Controls.Add(this.grpBH);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.lblNDSXH);
			this.Controls.Add(this.cmdCanel);
			this.Controls.Add(this.cmdPrint);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtBarCode);
			this.Font = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.Name = "PrintRepairCode";
			this.Text = "��ӡ����";
			this.Load += new System.EventHandler(this.PrintRepairCode_Load);
			this.grpBH.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void PrintRepairCode_Load(object sender, System.EventArgs e)
		{
			this.nullContrel ();
			this.IniFile ();
			this.Display ();
		}
		/// <summary>
		/// ������ӡ����������
		/// </summary>
		/// <param name="PrinterName"></param>
		[DllImport("tsclib.dll")]
		public static extern void openport(string PrinterName);
		[DllImport("tsclib.dll")]
		public static extern void closeport();		
		[DllImport("tsclib.dll")]
		public static extern void sendcommand(string command_Renamed);

		[DllImport("tsclib.dll")]
		public static extern void setup(string  LabelWidth,string  LabelHeight,string Speed,string Density,string Sensor,string Vertical,string Offset);
		[DllImport("tsclib.dll")]
		public static extern void barcode(string X, string Y,string CodeType,string Height,string  Readable,string  rotation,string Narrow,string Wide,string Code);
		[DllImport("tsclib.dll")]
		public static extern void windowsfont(int X,int Y,int fontheight,int fontwidth,int rotation,int fontstyle,int fontunderline,string FaceName,string TextContent);
		[DllImport("tsclib.dll")]
		public static extern void clearbuffer();
		[DllImport("tsclib.dll")]
		public static extern void printlabel(string  NumberOfSet,string NumberOfCopy);
		//��ʾ����
		private void Display()
		{
			try
			{
				this.lblWZH.Text  =this.strWZH;
				this.lblTSFLH .Text =this.strTSFLH;
				this.lblZCH .Text=this.strZCH;
				this.lblNDSXH .Text =this.strNDSXH;
				
				DataBaseBook tempDBB=new DataBaseBook (this.ConnectionString .Trim ());
				tempDBB.getDataBaseBook (this.lblWZH.Text  ,this.lblTSFLH.Text  ,this.lblZCH.Text  );
				this.lblNDSXH .Text =tempDBB.NDSXH ;
				this.lblSM .Text =tempDBB.BookName ;
				this.grpBH .Text ="��ţ�"+tempDBB.ID ;
				this.strBH =tempDBB.ID;
			}
			catch
			{
			
			}
		}
		private void PrintLabel()
		{
			try
			{

				int x=20;
				this.Cursor = Cursors.WaitCursor;
				openport("LPT1");
				
				sendcommand("DIRECTION 0");
				//setup("100", "30", "5.0", "12", "1", "0", "0");
				sendcommand("SIZE 100 mm,30 mm");
				clearbuffer();
				barcode("40","0", "128","130", "0", "0", "3", "4",txtBarCode.Text.Trim());
			
				windowsfont(40,130,30,0,2,0,0,"����","����ţ�");//-�ִκ�-ͼ������-���˳���
				//	windowsfont(20,145,25,0,2,0,0,"����","�ִκţ�");
				//	windowsfont(20,170,25,0,2,0,0,"����","ͼ�����ţ�");
				//	windowsfont(20,195,25,0,2,0,0,"����","���˳��ţ�");
				string FH1="/",FH2="/";
				if (lblWZH.Text .Trim ().Equals ("")){FH1="";}
				if(lblTSFLH.Text .Trim ().Equals ("")){FH2="";}
			
				windowsfont(160,130,30,0,2,2,0,"����",lblWZH.Text.Trim()+FH1+lblTSFLH.Text.Trim ()+FH2+lblZCH.Text .Trim ());
				//	windowsfont(155,145,25,0,2,0,0,"����",lblZCH.Text.Trim());
				//	windowsfont(155,170,25,0,2,0,0,"����",lblTSFLH.Text.Trim ());
				//	windowsfont(155,195,25,0,2,0,0,"����",ylblNDSXH.Text.Trim ());

				windowsfont(145,170,45,20,2,0,0,"���Ǵ��μ�","�����н�������о�Ժ����");
				//windowsfont(317,185,35,15,2,0,0,"����",label18.Text .Trim ());
				windowsfont(498,130,30,0,2,0,0,"����",this.ReplaceKongGe (txtBarCode.Text .Trim ()));
				printlabel("1", "1");
				closeport();
				this.Cursor = Cursors.Default ;
			}
			catch(Exception printE)
			{
				MessageBox.Show (printE.ToString());
			}
		}

		private void cmdPrint_Click(object sender, System.EventArgs e)
		{
			if(txtBarCode.Text .Trim ().Equals (""))
			{
				MessageBox.Show("��ɨ������!");
				txtBarCode.Text ="";
			}
			else
			{
				if(this.AddBookList ()==0)
				{
					MessageBox.Show ("����ɹ�!");
				}
				else
				{
					MessageBox.Show ("����ʧ��!");
				}

			}
		}
		private int AddBookList()
		{
			/////////////////////////////////////////////////////////////////////////////////
			string tempStrBarCode=this.ReplaceKongGe(this.txtBarCode.Text .Trim ());//��Ҫ�����������ǿո�

			/////////////////////////////////////////////////////////////////////////////////
		
			int Exe=9;
			try
			{
			//	string addstr="insert into booklist(BarCode,BookId,WZH,ZCH,TSFLH,NDSXH,BookLocation)values('"+this.lblBarCode.Text.Trim ()
			//		+"','"+this.strBH .Trim ()+"','"+this.lblWZH .Text .Trim ()+"','"+this.lblZCH .Text .Trim ()+"','"+this.lblTSFLH.Text.Trim ()+"','"+this.lblNDSXH .Text .Trim ()+"','"+this.cboLocationId.Text .Trim ()+"')";
			
				string updatestr="UPDATE booklist SET BookId='"+this.strBH.Trim()+"',WZH='"+this.lblWZH .Text .Trim ()+
					"',ZCH='"+this.lblZCH.Text .Trim ()+"' ,TSFLH ='"+this.lblTSFLH .Text .Trim ()+"',NDSXH='"+this.lblNDSXH .Text .Trim ()+"' where BarCode='"+tempStrBarCode.Trim ()+"'";
			
			
				SqlConnection addCnn=new SqlConnection (this.ConnectionString .Trim ());
				SqlCommand addCmd=new SqlCommand ();
			
			
				addCmd.CommandText ="select count(*) from booklist where BarCode='"+tempStrBarCode.Trim ()+"'";
				addCmd.Connection =addCnn;
				addCnn.Open();
				int i=(int)addCmd.ExecuteScalar();
				addCnn.Close();
				if(i>0)//˵�����ݿ����Ѿ������BarCode��
				{
					//result = MessageBox.Show("�˵��ӱ�ǩ����,�Ƿ��޸����ݿ��еļ�¼","��Ҫ��ʾ",buttons);

						addCmd.CommandText =updatestr.Trim ();
						addCmd.Connection =addCnn;
						try
						{
							addCnn.Open ();
							addCmd.ExecuteNonQuery ();
							addCnn.Close ();
							this.PrintLabel ();//��ӡ�±�ǩ
							Exe=0;
							this.Close ();
						}
						catch
						{
							Exe=1;
							MessageBox.Show ("��������ʧ��!");
						}
					
				}
				else
				{	//��ʾ:���ܴ�ӡ����
					Exe=2;
					 MessageBox.Show("���ݿ���û�б����¼,���ܴ�ӡ�����ǩ","��Ҫ��ʾ");
				}
				return Exe;
			}
			catch
			{
				return Exe;
				MessageBox.Show ("��ѯ��ʷ��¼ʧ��!");
			}
		}
	

		private int AddBookListNotPrint()
		{
			/////////////////////////////////////////////////////////////////////////////////
			string tempStrBarCode=this.ReplaceKongGe(this.txtBarCode.Text .Trim ());//��Ҫ�����������ǿո�

			/////////////////////////////////////////////////////////////////////////////////
		
			int Exe=9;
			try
			{
				//	string addstr="insert into booklist(BarCode,BookId,WZH,ZCH,TSFLH,NDSXH,BookLocation)values('"+this.lblBarCode.Text.Trim ()
				//		+"','"+this.strBH .Trim ()+"','"+this.lblWZH .Text .Trim ()+"','"+this.lblZCH .Text .Trim ()+"','"+this.lblTSFLH.Text.Trim ()+"','"+this.lblNDSXH .Text .Trim ()+"','"+this.cboLocationId.Text .Trim ()+"')";
			
				string updatestr="UPDATE booklist SET BookId='"+this.strBH.Trim()+"',WZH='"+this.lblWZH .Text .Trim ()+
					"',ZCH='"+this.lblZCH.Text .Trim ()+"' ,TSFLH ='"+this.lblTSFLH .Text .Trim ()+"',NDSXH='"+this.lblNDSXH .Text .Trim ()+"' where BarCode='"+tempStrBarCode.Trim ()+"'";
			
			
				SqlConnection addCnn=new SqlConnection (this.ConnectionString .Trim ());
				SqlCommand addCmd=new SqlCommand ();
			
			
				addCmd.CommandText ="select count(*) from booklist where BarCode='"+tempStrBarCode.Trim ()+"'";
				addCmd.Connection =addCnn;
				addCnn.Open();
				int i=(int)addCmd.ExecuteScalar();
				addCnn.Close();
				if(i>0)//˵�����ݿ����Ѿ������BarCode��
				{
					//result = MessageBox.Show("�˵��ӱ�ǩ����,�Ƿ��޸����ݿ��еļ�¼","��Ҫ��ʾ",buttons);

					addCmd.CommandText =updatestr.Trim ();
					addCmd.Connection =addCnn;
					try
					{
						addCnn.Open ();
						addCmd.ExecuteNonQuery ();
						addCnn.Close ();
						//this.PrintLabel ();//��ӡ�±�ǩ
						Exe=0;
						this.Close ();
					}
					catch
					{
						Exe=1;
						MessageBox.Show ("��������ʧ��!");
					}
					
				}
				else
				{	//��ʾ:���ܴ�ӡ����
					Exe=2;
					MessageBox.Show("���ݿ���û�б����¼,���ܴ�ӡ�����ǩ","��Ҫ��ʾ");
				}
				return Exe;
			}
			catch
			{
				return Exe;
				MessageBox.Show ("��ѯ��ʷ��¼ʧ��!");
			}
		}
	
		// ȥ���ַ����еĿո�
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

		
		
		
		private void IniFile()
		{
			try
			{
				//������д�����
				//��ȡconfig.iniϵͳĿ¼λ����Ϣ
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
						this.ConnectionString=ini.IniReadValue("DataBase","ConnectionString").Trim(); 
					}
					else
					{
						MessageBox.Show ("û�������ݿ����Ӳ���,������д��ȷ��ConnectionString����","Config.ini��������!");
					}
				
				}
				else
				{
					//û����Config.ini�ļ�,ϵͳ�������У��Զ��˳�
					MessageBox.Show("û��Config.ini�ļ��������������У�");
				}
			}
			catch(Exception ReaderiniE)
			{
				MessageBox.Show ("��config.ini����"+ReaderiniE.ToString ());
			
			
			}
		}


		private void nullContrel()
		{
			this.lblWZH .Text ="";
			this.lblTSFLH .Text ="";
			this.lblZCH .Text ="";
			this.lblNDSXH .Text ="";
			this.lblSM .Text ="";
			this.grpBH.Text  ="";
			this.txtBarCode.Text  ="";
		}

		private void cmdCanel_Click(object sender, System.EventArgs e)
		{
			this.Close ();
		}

		private void btnNotPrint_Click(object sender, System.EventArgs e)
		{
			
			if(txtBarCode.Text .Trim ().Equals (""))
			{
				MessageBox.Show("��ɨ������!");
				txtBarCode.Text ="";
			}
			else
			{
				if(this.AddBookListNotPrint()==0)
				{
					MessageBox.Show ("����ɹ�!");
				}
				else
				{
					MessageBox.Show ("����ʧ��!");
				}

			}
		}

	}
}
