using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Diagnostics;
using System.Threading;

using nsAlienRFID;

namespace BIADBOOK
{
	public delegate void displayMessageDlgt(string msg);
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class frmReaderSetting : System.Windows.Forms.Form
	{
		private clsReader mReader;
		private ReaderInfo mReaderInfo;
		private ComInterface meReaderInterface = ComInterface.enumTCPIP;
		private ArrayList malTags;
		private String msTags;
		private string UserName;
		private string Password;
       
		#region Auto generated code

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.NumericUpDown PortUD;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button btnConnect;
		private System.Windows.Forms.Button btnDisconnect;
		private System.Windows.Forms.Button btnSent;
		private System.Windows.Forms.TextBox txtSyncResponse;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnTagList;
		private System.Windows.Forms.TextBox textReaderTalk;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button btnParse;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtCommand;
		private System.Windows.Forms.TrackBar trackBar1;
		private System.Windows.Forms.Label label3;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmReaderSetting()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmReaderSetting));
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.txtCommand = new System.Windows.Forms.TextBox();
			this.btnTagList = new System.Windows.Forms.Button();
			this.textReaderTalk = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtSyncResponse = new System.Windows.Forms.TextBox();
			this.btnSent = new System.Windows.Forms.Button();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.btnParse = new System.Windows.Forms.Button();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.label3 = new System.Windows.Forms.Label();
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.PortUD = new System.Windows.Forms.NumericUpDown();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.btnConnect = new System.Windows.Forms.Button();
			this.btnDisconnect = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PortUD)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(0, 8);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(328, 344);
			this.tabControl1.TabIndex = 41;
			// 
			// tabPage1
			// 
			this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tabPage1.Controls.Add(this.txtCommand);
			this.tabPage1.Controls.Add(this.btnTagList);
			this.tabPage1.Controls.Add(this.textReaderTalk);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.txtSyncResponse);
			this.tabPage1.Controls.Add(this.btnSent);
			this.tabPage1.Location = new System.Drawing.Point(4, 21);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(320, 319);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "读写操作";
			// 
			// txtCommand
			// 
			this.txtCommand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtCommand.Location = new System.Drawing.Point(104, 16);
			this.txtCommand.Name = "txtCommand";
			this.txtCommand.Size = new System.Drawing.Size(200, 21);
			this.txtCommand.TabIndex = 46;
			this.txtCommand.Text = "";
			this.txtCommand.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCommand_KeyPress);
			this.txtCommand.TextChanged += new System.EventHandler(this.txtCommand_TextChanged);
			this.txtCommand.Enter += new System.EventHandler(this.txtCommand_Enter);
			// 
			// btnTagList
			// 
			this.btnTagList.BackColor = System.Drawing.Color.PaleTurquoise;
			this.btnTagList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnTagList.Location = new System.Drawing.Point(8, 160);
			this.btnTagList.Name = "btnTagList";
			this.btnTagList.Size = new System.Drawing.Size(80, 24);
			this.btnTagList.TabIndex = 45;
			this.btnTagList.Text = "读取标签";
			this.btnTagList.Click += new System.EventHandler(this.btnTagList_Click);
			// 
			// textReaderTalk
			// 
			this.textReaderTalk.BackColor = System.Drawing.SystemColors.Window;
			this.textReaderTalk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textReaderTalk.ForeColor = System.Drawing.SystemColors.InfoText;
			this.textReaderTalk.Location = new System.Drawing.Point(8, 184);
			this.textReaderTalk.Multiline = true;
			this.textReaderTalk.Name = "textReaderTalk";
			this.textReaderTalk.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textReaderTalk.Size = new System.Drawing.Size(304, 120);
			this.textReaderTalk.TabIndex = 44;
			this.textReaderTalk.Text = "断开";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(8, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 16);
			this.label1.TabIndex = 43;
			this.label1.Text = "状态信息";
			// 
			// txtSyncResponse
			// 
			this.txtSyncResponse.BackColor = System.Drawing.SystemColors.Window;
			this.txtSyncResponse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtSyncResponse.ForeColor = System.Drawing.SystemColors.ControlText;
			this.txtSyncResponse.Location = new System.Drawing.Point(8, 80);
			this.txtSyncResponse.Multiline = true;
			this.txtSyncResponse.Name = "txtSyncResponse";
			this.txtSyncResponse.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtSyncResponse.Size = new System.Drawing.Size(304, 72);
			this.txtSyncResponse.TabIndex = 42;
			this.txtSyncResponse.Text = "";
			// 
			// btnSent
			// 
			this.btnSent.BackColor = System.Drawing.Color.PaleTurquoise;
			this.btnSent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSent.Location = new System.Drawing.Point(8, 16);
			this.btnSent.Name = "btnSent";
			this.btnSent.Size = new System.Drawing.Size(88, 24);
			this.btnSent.TabIndex = 40;
			this.btnSent.Text = " 写电子标签";
			this.btnSent.Click += new System.EventHandler(this.btnSent_Click);
			// 
			// tabPage3
			// 
			this.tabPage3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tabPage3.Controls.Add(this.dataGrid1);
			this.tabPage3.Controls.Add(this.btnParse);
			this.tabPage3.Location = new System.Drawing.Point(4, 21);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(320, 319);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "分析";
			// 
			// dataGrid1
			// 
			this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Info;
			this.dataGrid1.CaptionVisible = false;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.ForeColor = System.Drawing.SystemColors.MenuText;
			this.dataGrid1.HeaderBackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(8, 32);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.RowHeadersVisible = false;
			this.dataGrid1.Size = new System.Drawing.Size(304, 280);
			this.dataGrid1.TabIndex = 36;
			// 
			// btnParse
			// 
			this.btnParse.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.btnParse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnParse.Location = new System.Drawing.Point(8, 8);
			this.btnParse.Name = "btnParse";
			this.btnParse.Size = new System.Drawing.Size(88, 24);
			this.btnParse.TabIndex = 35;
			this.btnParse.Text = "分析";
			this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
			// 
			// tabPage2
			// 
			this.tabPage2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPage2.BackgroundImage")));
			this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tabPage2.Controls.Add(this.label3);
			this.tabPage2.Controls.Add(this.trackBar1);
			this.tabPage2.Controls.Add(this.label2);
			this.tabPage2.Controls.Add(this.groupBox1);
			this.tabPage2.Location = new System.Drawing.Point(4, 21);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(320, 319);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "设置";
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label3.Font = new System.Drawing.Font("楷体_GB2312", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label3.Location = new System.Drawing.Point(56, 232);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(144, 32);
			this.label3.TabIndex = 40;
			this.label3.Text = "0";
			// 
			// trackBar1
			// 
			this.trackBar1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.trackBar1.Location = new System.Drawing.Point(8, 64);
			this.trackBar1.Maximum = 16;
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.trackBar1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.trackBar1.Size = new System.Drawing.Size(42, 216);
			this.trackBar1.TabIndex = 39;
			this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
			this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.label2.Font = new System.Drawing.Font("楷体_GB2312", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.Location = new System.Drawing.Point(200, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(112, 72);
			this.label2.TabIndex = 38;
			// 
			// groupBox1
			// 
			this.groupBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox1.BackgroundImage")));
			this.groupBox1.Controls.Add(this.PortUD);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Controls.Add(this.btnConnect);
			this.groupBox1.Controls.Add(this.btnDisconnect);
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(304, 48);
			this.groupBox1.TabIndex = 37;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Alien Reader";
			// 
			// PortUD
			// 
			this.PortUD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.PortUD.Location = new System.Drawing.Point(120, 16);
			this.PortUD.Name = "PortUD";
			this.PortUD.Size = new System.Drawing.Size(40, 21);
			this.PortUD.TabIndex = 9;
			this.PortUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.PortUD.Value = new System.Decimal(new int[] {
																 10,
																 0,
																 0,
																 0});
			// 
			// textBox1
			// 
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox1.Location = new System.Drawing.Point(8, 16);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(112, 21);
			this.textBox1.TabIndex = 10;
			this.textBox1.Text = "";
			// 
			// btnConnect
			// 
			this.btnConnect.BackColor = System.Drawing.Color.PaleTurquoise;
			this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnConnect.ForeColor = System.Drawing.SystemColors.InfoText;
			this.btnConnect.Location = new System.Drawing.Point(160, 16);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(72, 24);
			this.btnConnect.TabIndex = 31;
			this.btnConnect.Text = "连接";
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// btnDisconnect
			// 
			this.btnDisconnect.BackColor = System.Drawing.Color.Turquoise;
			this.btnDisconnect.Enabled = false;
			this.btnDisconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDisconnect.ForeColor = System.Drawing.SystemColors.WindowText;
			this.btnDisconnect.Location = new System.Drawing.Point(232, 16);
			this.btnDisconnect.Name = "btnDisconnect";
			this.btnDisconnect.Size = new System.Drawing.Size(64, 24);
			this.btnDisconnect.TabIndex = 35;
			this.btnDisconnect.Text = "断开";
			this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
			// 
			// frmReaderSetting
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(336, 357);
			this.Controls.Add(this.tabControl1);
			this.Name = "frmReaderSetting";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "电子标签阅读器设置";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.PortUD)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

	
	#endregion

		private void Form1_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.getIniFile ();
				mReader = new clsReader();
				mReaderInfo = mReader.ReaderSettings;

				this.Text = "Alien阅读器";
				Thread.CurrentThread.Name = "TestTagList";
				btnTagList.Enabled = false;
				btnParse.Enabled = false;
				btnSent.Enabled =false;
			}
			catch{}

		}

		private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (mReader != null)
			{
				if (mReader.IsConnected)
					mReader.Disconnect();
			}
		}

		private void btnConnect_Click(object sender, System.EventArgs e)
		{
			String result;
			string tempstr;
			this.Cursor = Cursors.WaitCursor;
			
			try		
			{
				if (meReaderInterface == ComInterface.enumTCPIP)
					mReader.InitOnNetwork(textBox1.Text, Convert.ToInt32(PortUD.Value));
			
				DisplayText("\r\nConnecting to the reader...\r\n");
				label2.Text ="正在连接......";
				this.Cursor = Cursors.WaitCursor;

				result = mReader.Connect();
				if (!mReader.IsConnected)
				{
					textReaderTalk.AppendText ("\r\nCan't connect\r\n");
				}
				else
				{
					if (meReaderInterface == ComInterface.enumTCPIP)
					{
						DisplayText("\r\nLogging in...\r\n");
						this.Cursor = Cursors.WaitCursor;
						if (!mReader.Login(this.UserName .Trim (), this.Password .Trim ()))		//returns result synchronously
						{
							DisplayText ("\r\nLogin failed! Calling Disconnect()...\r\n");
							mReader.Disconnect();
							label2.Text ="连接失败!";
							return;
						}
						DisplayText("\r\nLogged in - OK!\r\n");
						tempstr=mReader.SendReceive ("set function=programmer",false).Trim ();//设置Reader为编程状态
					
						label2.Text ="登陆成功!编程状态" ; 
					
					}
					DisplayText (result);
					ManageGUI(true);
					textReaderTalk.Visible = true;
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			this.Cursor = Cursors.Default;


		}
	
	
		private void DisplayText(String data)
		{
			try
			{
				if (this.InvokeRequired)
				{
					object[] temp = {data};
					IAsyncResult ars = this.BeginInvoke(new displayMessageDlgt(DisplayText),temp);
					this.EndInvoke(ars);
					return;
				}
				else
				{	
					if (data.IndexOf("Username>") != -1)
						data = data.Substring(0, data.Length - 10);
					String stemp = "";
					if (!data.StartsWith("\r\n"))
					{
						stemp = "\r\n" + data;
						data = stemp;
					}
					if (!data.EndsWith("\r\n"))
					{
						stemp = data + "\r\n";
						data = stemp;
					}
					if (textReaderTalk.TextLength > 32767)
						textReaderTalk.Text = "... Text removed\r\n";
					textReaderTalk.Text += data;
					this.Cursor = Cursors.Default;
					textReaderTalk.Focus();
					textReaderTalk.SelectAll();
					textReaderTalk.ScrollToCaret();
					return;
				}
			}
			catch(Exception ex)
			{
				Debug.WriteLine("Exception in the DiscplayText: " + ex.Message);
			}
		}

	
		private void ManageGUI (bool flag)
		{
			btnDisconnect.Enabled = flag;
			btnConnect.Enabled = !flag;
			btnSent.Enabled =flag;
			btnTagList.Enabled = flag;
			btnParse.Enabled = flag;
		
		}

		private void btnDisconnect_Click(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;		
			mReader.Disconnect();
			ManageGUI(false);
			this.Cursor = Cursors.Default;		
			label2.Text ="";
		}

		private void btnTagList_Click(object sender, System.EventArgs e)
		{
			try
			{
				textReaderTalk.Text="";
				this.Cursor = Cursors.WaitCursor;

				mReader.TagListFormat = "Text";
				String result = mReader.TagList;
				MessageBox.Show (result.Trim ());
				if ((result.Length > 0) && (result.IndexOf("No Tags") == -1))
					msTags = result;

				DisplayText(result);
	
				this.Cursor = Cursors.Default;
				btnParse.Enabled = true;
			}
			catch{MessageBox.Show ("读签出错");}
		}

		private void btnParse_Click(object sender, System.EventArgs e)
		{
			try
			{
				if ((msTags != null) && (msTags.Length > 0))
				{
					this.Cursor = Cursors.WaitCursor;
					TagInfo[] aTags;
					TagInfo   tag;
					try
					{
						int cnt = AlienUtils.ParseTagList(msTags, out aTags);
						tag=aTags[0];
						if (cnt > 0)
						{
							//MessageBox.Show (tag.TagID.ToString ());
							malTags = new ArrayList(aTags);
						
							
						
						
							dataGrid1.DataSource = malTags;
						}
						else
						{
							textReaderTalk.AppendText(msTags + "\r\n");
						}
						this.Cursor = Cursors.Default;
					}
					catch (Exception ex)
					{
						textReaderTalk.AppendText(ex.Message + "\r\n");
					}
				}
			}
			catch{
			MessageBox.Show ("分析出错");
			}
		}

		private void btnSent_Click(object sender, System.EventArgs e)
		{
			if(btnSent.Enabled ==true)
			{
				//txtSyncResponse.Text =mReader.SendReceive ("set function=programmer",false);//设置Reader为编程状态

				string CommandSTR;
				string Message;

				CommandSTR="program tag="+ WriteFormatStr(txtCommand.Text.Trim())+" 01";
				Message=mReader.SendReceive(CommandSTR, false);
				txtSyncResponse.Text=Message.Trim ();
				
				///////////////////////////////////////
				this.Cursor = Cursors.WaitCursor;

				mReader.TagListFormat = "Text";
				String result = mReader.TagList;
				//MessageBox.Show (result.Trim ());
				if ((result.Length > 0) && (result.IndexOf("No Tags") == -1))
					msTags = result;

				DisplayText(result);
	
				this.Cursor = Cursors.Default;
				btnParse.Enabled = true;
			}
		}
		private string WriteFormatStr(string str)
		{//此方法整写入的字符格式
			
			string rStr="";
			if (str.Length>=14)
			{
				//MessageBox.Show ("您正在写入的字符如果大于12个，系统将截取前12个");
				
				rStr=str.Substring (0,2)+" ";
				rStr=rStr+str.Substring(2,2)+" ";
				rStr=rStr+str.Substring(4,2)+" ";
				rStr=rStr+str.Substring (6,2)+" ";
				rStr=rStr+str.Substring (8,2)+" ";
				rStr=rStr+str.Substring (10,2)+" ";
				rStr=rStr+str.Substring (12,2);
			}
			else
			{
				//MessageBox.Show ("您输入的字符不足12位,请您补足12位");
			//	MessageBox.Show (str);
				txtSyncResponse.Text ="您输入的字符不足14位,请您补足14位"+rStr;
			    rStr="A0 00 00 00 00 00 00";
				
			}
			return rStr;
		}

		private void txtCommand_TextChanged(object sender, System.EventArgs e)
		{
				
		
		}

		private void txtCommand_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			try
			{
				if(e.KeyChar == (char)13)
				{
					//MessageBox.Show (txtCommand.Text);//测试
					if(btnSent.Enabled ==true)
					{
						//txtSyncResponse.Text =mReader.SendReceive ("set function=programmer",false);//设置Reader为编程状态

						string CommandSTR;
						string Message;

						CommandSTR="program tag="+ WriteFormatStr(txtCommand.Text.Trim())+" 01";
						Message=mReader.SendReceive(CommandSTR, false);
						txtSyncResponse.Text=Message.Trim ();
				
						///////////////////////////////////////
						this.Cursor = Cursors.WaitCursor;

						mReader.TagListFormat = "Text";
						String result = mReader.TagList;
						//MessageBox.Show (result.Trim ());
						if ((result.Length > 0) && (result.IndexOf("No Tags") == -1))
							msTags = result;

						DisplayText(result);
	
						this.Cursor = Cursors.Default;
						btnParse.Enabled = true;
						txtCommand.Focus ();
						txtCommand.Text ="";
					}
			
				}

			}
			catch{MessageBox.Show ("写入框keypress出错"); }
		}

		private void txtCommand_Enter(object sender, System.EventArgs e)
		{
		}

		private void trackBar1_Scroll(object sender, System.EventArgs e)
		{
			try
			{
				//string Msg;
				string Commandstr;
				int antInt=(int)trackBar1.Value;
				antInt=antInt*10;
				Commandstr="set RFAttenuation="+antInt.ToString ();

				label3.Text =mReader.SendReceive(Commandstr,false);
			
				//MessageBox.Show(Commandstr);
			}
			catch{MessageBox.Show ("调功率出错");}
		}

	//设置READER设备参数
		private void getIniFile()
		{
			try
			{
				//声名读写类对象
				//读取config.ini系统目录位置信息
				string SysPath;
				string  portUD;


				SysPath=Directory.GetCurrentDirectory().ToString()+"\\Config.ini";
				//判断Config.ini文件是否存在
				if(File.Exists(SysPath))
				{
					//截入Config.ini文件中的各参数
					IniFile ini = new IniFile(SysPath);
					//[DataBase]ConnectionString
					//[RFidReader]//readerIP=//readerIPPort=//UserName=alien//Password=password
					if(ini.IniReadValue ("RFidReader","readerIP")!="" && ini.IniReadValue ("RFidReader","readerIPPort")	!="")
					{
						textBox1.Text  =ini.IniReadValue ("RFidReader","readerIP").Trim ();
						
						portUD=ini.IniReadValue("RFidReader","readerIPPort").Trim();
						this.PortUD.Value=Convert.ToDecimal (portUD.Trim ());
						this.UserName=ini.IniReadValue ("RFidReader","UserName").Trim ();
						this.Password  =ini.IniReadValue ("RFidReader","PassWord").Trim ();	
					}
					else
					{
						MessageBox.Show("电子标签阅读器参数设置错误!Config.ini中readerIPPort与readerIPPort参数不能为空","Config.ini参数错误!");
					}

				
				}
				else
				{
					//没发现Config.ini文件,系统不能运行，自动退出
					MessageBox.Show("没有Config.ini文件，不能正常运行！");
				}
			}
			catch(Exception iniE){
								MessageBox.Show("Reader阅读器参数读取出错了"+iniE.ToString ());
			}
		
		}
		

		

		

	
		

	
	
	}
}
