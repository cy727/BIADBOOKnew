using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;
using System.Runtime.InteropServices;
using System.Net;
using System.Net.Sockets;

using System.Data.OracleClient;

namespace BIADBOOK
{
	/// <summary>
	/// FormBor 的摘要说明。
	/// </summary>
	public class FormBor : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox nameTB;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox depTB;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox telTB;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox isoTB;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button isobtn;
		private System.Windows.Forms.Button icbtn;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TreeView booktv;
		private System.Windows.Forms.TextBox wzhTB;
		private System.Windows.Forms.Label wzhl;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tsflhTB;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox zchTB;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox smTB;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox gclTB;
		private System.Windows.Forms.TextBox jcslTB;
		private System.Windows.Forms.CheckBox jjbjCB;
		private System.Windows.Forms.Button bookqbtn;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Button bobtn;
		private System.Windows.Forms.Button rebtn;
		private System.Windows.Forms.Button closebtn;
		public string strConn,strhrConn;
		private string s1,s2,s3,icno;
		private System.Data.SqlClient.SqlConnection sqlConn;
		private System.Data.SqlClient.SqlCommand sqlComm;
        private System.Data.SqlClient.SqlConnection sqlhrConn;
        private System.Data.SqlClient.SqlCommand sqlhrComm;



		private System.Windows.Forms.ImageList imageList1;
		private System.Data.SqlClient.SqlDataReader sqldr;
		private System.Windows.Forms.Button rbbtn;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox xjTB;
		private System.Windows.Forms.TextBox jcsjTB;
		private System.Windows.Forms.TextBox fbTB;
		private System.Windows.Forms.Label label12;
		private string dt;


        private OracleConnection OracleConn=new OracleConnection();
        private OracleCommand OracleComm;
        private OracleDataReader odr;
        //[DllImport("kernel32")] 
        //public static extern bool Beep(int frequency, int duration); 
        //[DllImport("fc32")] 
        //public static extern int COM_OPEN(string comport, uint baudrate); 
        //[DllImport("fc32")] 
        //public static extern int rderVersion(int hComDev, byte waitime, System.Text.StringBuilder Version); 
        //[DllImport("fc32")] 
        //public static extern int COM_CLOSE(int hcomdev); 
        //[DllImport("fc32")] 
        //public static extern int rderBeeper(int hComDev, byte waitime, byte OnOff);
        //[DllImport("fc32")] 
        //public static extern void dllVersion(System.Text.StringBuilder Version);
        //[DllImport("fc32")] 
        //public static extern int isoReadInfo(int hComDev, byte waitime, byte WithUID, System.Text.StringBuilder UID,System.Text.StringBuilder Blocks, System.Text.StringBuilder BockSize, System.Text.StringBuilder DSFID, System.Text.StringBuilder AFI, System.Text.StringBuilder ICRef);

        //[DllImport("fc32")] 
        //public static extern int  isoReadBlock(int hComDev, byte waitime, byte WithUID, string UID, byte Block,System.Text.StringBuilder bcdData, System.Text.StringBuilder ascData, System.Text.StringBuilder hexData);

        //[DllImport("fc32")] 
        //public static extern int isoWriteBlock(int hComDev, byte waitime, byte WithUID, string UID,byte Block, byte BlockSize, byte DataType, string Data);

		private System.ComponentModel.IContainer components;
        
        int port = 5001;
        private TextBox textBoxRead;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabelWarn;
        string host = "172.16.0.11";


		public FormBor()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		private void fillPeopleInfobyIC(string ICno)
		{
			//string ICcode;

			if(ICno.Length<97) return;


            byte[] str_b = strToToHexByte(ICno.Substring(24, 12));
            nameTB.Text=System.Text.Encoding.GetEncoding("gb2312").GetString(str_b).Trim();

             byte[] str_b1 = strToToHexByte(ICno.Substring(56, 40));
            depTB.Text = System.Text.Encoding.GetEncoding("gb2312").GetString(str_b1).Trim();

            string sss = ICno.Substring(36, 10);
            int iTemp=0;
            try
            {
                iTemp=int.Parse(sss);
            }
            catch
            {
                iTemp=0;
            }
            isoTB.Text = iTemp.ToString();


            /*

			ICcode=ICno.Substring(ICno.Length-8,8);

			sqlhrComm.CommandText = "SELECT employees.ecode, employees.ecname, codeorgs.cdptname FROM employees INNER JOIN codeorgs ON employees.dept = codeorgs.dptno WHERE (employees.icserial = '"+ICcode+"')";

			sqlhrConn.Open();
			sqldr=sqlhrComm.ExecuteReader();

			if(!sqldr.HasRows)
			{
				sqldr.Close();
				sqlhrComm.Connection.Close();
				isoTB.Text=icno.ToUpper();
				return;
			}


			try
			{
				sqldr.Read();
				isoTB.Text=sqldr.GetValue(0).ToString();
				nameTB.Text=sqldr.GetValue(1).ToString();
				depTB.Text=sqldr.GetValue(2).ToString();
			}
			finally
			{
				sqldr.Close();
				sqlhrComm.Connection.Close();
			}
            */

			icno=isoTB.Text.Trim();
		}


		private string readICcard()
		{
			string strtemp="";
            string sendStr = "11331108606831";
            int i,iT=0;

            if (textBoxRead.Text.Trim().Length != 10)
                return strtemp;

            try
            {
                for (i = 0; i < 10; i++)
                    iT += int.Parse(textBoxRead.Text.Substring(i,1));
                iT += 5; //113
                sendStr = "113" + textBoxRead.Text + iT.ToString().Substring(iT.ToString().Length-1,1);
            }
            catch
            {
                return strtemp;
            }

            try
            {
                IPAddress IPAddressip = IPAddress.Parse(host);
                IPEndPoint ipe = new IPEndPoint(IPAddressip, port);//把ip和端口转化为IPEndPoint实例
                Socket c = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//创建一个Socket
                c.Connect(ipe);//连接到服务器

                byte[] bs = Encoding.ASCII.GetBytes(sendStr);
                c.Send(bs, bs.Length, 0);//发送测试信息
                //string recvStr = "";
                byte[] recvBytes = new byte[1024];
                int bytes;
                bytes = c.Receive(recvBytes, recvBytes.Length, 0);//从服务器端接受返回信息
                c.Close();

                if (bytes >= 97)
                {
                    strtemp += Encoding.ASCII.GetString(recvBytes, 0, bytes);
                    toolStripStatusLabelWarn.ForeColor = Color.Black;
                    toolStripStatusLabelWarn.Text = "有效卡";
                }
                else
                {
                    toolStripStatusLabelWarn.ForeColor = Color.Red;
                    toolStripStatusLabelWarn.Text = "非有效卡";
                }

            }
            catch (ArgumentNullException e)
            {
                //Console.WriteLine("ArgumentNullException:{0}", e);
            }

            /*

            //System.Text.StringBuilder ss = new System.Text.StringBuilder(80);
            //System.Text.StringBuilder ss1 = new System.Text.StringBuilder(80);
            //System.Text.StringBuilder ss2 = new System.Text.StringBuilder(80);
            //System.Text.StringBuilder ss3 = new System.Text.StringBuilder(80);
            //System.Text.StringBuilder ss4 = new System.Text.StringBuilder(80);
            //System.Text.StringBuilder ss5 = new System.Text.StringBuilder(80);

            //i=COM_OPEN("COM2:",9600);
            //j=rderBeeper(i,10,1);
            //j=isoReadInfo(i,2,0,ss,ss1,ss2,ss3,ss4,ss5);
		
            //if(j!=0) strtemp="";
            //else strtemp=ss.ToString();
            //j=COM_CLOSE(i);

            try
            {
                IPAddress IPAddressip = IPAddress.Parse(host);
                IPEndPoint ipe = new IPEndPoint(IPAddressip, port);//把ip和端口转化为IPEndPoint实例
                Socket c = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//创建一个Socket
                c.Connect(ipe);//连接到服务器
                //string sendStr = "11331106677714";
                string sendStr = "11331108606831";
                //string sendStr = "11300004536609";
                byte[] bs = Encoding.ASCII.GetBytes(sendStr);
                //Console.WriteLine("SendMessage");
                c.Send(bs, bs.Length, 0);//发送测试信息
                string recvStr = "";
                byte[] recvBytes = new byte[1024];
                int bytes;
                bytes = c.Receive(recvBytes, recvBytes.Length, 0);//从服务器端接受返回信息
                recvStr += Encoding.ASCII.GetString(recvBytes, 0, bytes);
                byte[] str_b = strToToHexByte(recvStr.Substring(24,12));
                //byte[] str_b = strToToHexByte("4481740630373937");
                //byte[] str_b = new byte[]{0x08,0x04,0x00,0x99,0x44,0x30,0x52,0x36,0x36,0x32,0x0D};


                MessageBox.Show(string.Format("ASCII: {0}\nUnicode: {1}\nUTF32: {2}\nUTF7: {3}\nUTF8: {4}\nBigEndianUnicode: {5}\nDefault: {6}\nGBK: {7}\nGB2312: {8}",
    System.Text.Encoding.ASCII.GetString(str_b),
    System.Text.Encoding.Unicode.GetString(str_b),
    System.Text.Encoding.UTF32.GetString(str_b),
    System.Text.Encoding.UTF7.GetString(str_b),
    System.Text.Encoding.UTF8.GetString(str_b),
    System.Text.Encoding.BigEndianUnicode.GetString(str_b),
    System.Text.Encoding.Default.GetString(str_b),
    System.Text.Encoding.GetEncoding("gbk").GetString(str_b),
    System.Text.Encoding.GetEncoding("gb2312").GetString(str_b)));

                string sss = recvStr.Substring(36, 10);
                byte[] str_b1 = strToToHexByte(sss);
                MessageBox.Show(string.Format("ASCII: {0}\nUnicode: {1}\nUTF32: {2}\nUTF7: {3}\nUTF8: {4}\nBigEndianUnicode: {5}\nDefault: {6}\nGBK: {7}\nGB2312: {8}",
System.Text.Encoding.ASCII.GetString(str_b1),
System.Text.Encoding.Unicode.GetString(str_b1),
System.Text.Encoding.UTF32.GetString(str_b1),
System.Text.Encoding.UTF7.GetString(str_b1),
System.Text.Encoding.UTF8.GetString(str_b1),
System.Text.Encoding.BigEndianUnicode.GetString(str_b1),
System.Text.Encoding.Default.GetString(str_b1),
System.Text.Encoding.GetEncoding("gbk").GetString(str_b1),
System.Text.Encoding.GetEncoding("gb2312").GetString(str_b1)));

                string sss1 = recvStr.Substring(56, 40);
                byte[] str_b2 = strToToHexByte(sss1);
                MessageBox.Show(string.Format("ASCII: {0}\nUnicode: {1}\nUTF32: {2}\nUTF7: {3}\nUTF8: {4}\nBigEndianUnicode: {5}\nDefault: {6}\nGBK: {7}\nGB2312: {8}",
System.Text.Encoding.ASCII.GetString(str_b2),
System.Text.Encoding.Unicode.GetString(str_b2),
System.Text.Encoding.UTF32.GetString(str_b2),
System.Text.Encoding.UTF7.GetString(str_b2),
System.Text.Encoding.UTF8.GetString(str_b2),
System.Text.Encoding.BigEndianUnicode.GetString(str_b2),
System.Text.Encoding.Default.GetString(str_b2),
System.Text.Encoding.GetEncoding("gbk").GetString(str_b2),
System.Text.Encoding.GetEncoding("gb2312").GetString(str_b2)));

                byte []bbb=System.Text.Encoding.GetEncoding("gbk").GetBytes("信息部");

                byte[] bbb1 = System.Text.Encoding.GetEncoding("gbk").GetBytes("917");

                MessageBox.Show(recvStr);
                //Console.WriteLine("ClientGetMessage:{0}", recvStr);//显示服务器返回信息
                c.Close();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException:{0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException:{0}", e);
            }
            */


			return strtemp;
		}


		/// <summary>
		/// 清理所有正在使用的资源。
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

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBor));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxRead = new System.Windows.Forms.TextBox();
            this.icbtn = new System.Windows.Forms.Button();
            this.isobtn = new System.Windows.Forms.Button();
            this.isoTB = new System.Windows.Forms.TextBox();
            this.telTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.depTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nameTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.booktv = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.fbTB = new System.Windows.Forms.TextBox();
            this.xjTB = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.jcsjTB = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.bookqbtn = new System.Windows.Forms.Button();
            this.jcslTB = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.gclTB = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.smTB = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.zchTB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tsflhTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.wzhTB = new System.Windows.Forms.TextBox();
            this.wzhl = new System.Windows.Forms.Label();
            this.jjbjCB = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.bobtn = new System.Windows.Forms.Button();
            this.rebtn = new System.Windows.Forms.Button();
            this.closebtn = new System.Windows.Forms.Button();
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.sqlComm = new System.Data.SqlClient.SqlCommand();
            this.sqlhrConn = new System.Data.SqlClient.SqlConnection();
            this.sqlhrComm = new System.Data.SqlClient.SqlCommand();
            this.rbbtn = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelWarn = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxRead);
            this.groupBox1.Controls.Add(this.icbtn);
            this.groupBox1.Controls.Add(this.isobtn);
            this.groupBox1.Controls.Add(this.isoTB);
            this.groupBox1.Controls.Add(this.telTB);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.depTB);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nameTB);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(16, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(608, 128);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "人员信息";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // textBoxRead
            // 
            this.textBoxRead.Location = new System.Drawing.Point(344, 26);
            this.textBoxRead.Name = "textBoxRead";
            this.textBoxRead.Size = new System.Drawing.Size(100, 21);
            this.textBoxRead.TabIndex = 10;
            this.textBoxRead.TextChanged += new System.EventHandler(this.textBoxRead_TextChanged);
            // 
            // icbtn
            // 
            this.icbtn.Location = new System.Drawing.Point(262, 24);
            this.icbtn.Name = "icbtn";
            this.icbtn.Size = new System.Drawing.Size(64, 23);
            this.icbtn.TabIndex = 9;
            this.icbtn.Text = "IC卡查询";
            this.icbtn.Click += new System.EventHandler(this.icbtn_Click);
            // 
            // isobtn
            // 
            this.isobtn.Location = new System.Drawing.Point(192, 24);
            this.isobtn.Name = "isobtn";
            this.isobtn.Size = new System.Drawing.Size(64, 23);
            this.isobtn.TabIndex = 8;
            this.isobtn.Text = "ISO查询";
            this.isobtn.Click += new System.EventHandler(this.isobtn_Click);
            // 
            // isoTB
            // 
            this.isoTB.Location = new System.Drawing.Point(64, 24);
            this.isoTB.Name = "isoTB";
            this.isoTB.Size = new System.Drawing.Size(120, 21);
            this.isoTB.TabIndex = 6;
            // 
            // telTB
            // 
            this.telTB.Location = new System.Drawing.Point(216, 58);
            this.telTB.Name = "telTB";
            this.telTB.Size = new System.Drawing.Size(376, 21);
            this.telTB.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(172, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "电话：";
            // 
            // depTB
            // 
            this.depTB.Enabled = false;
            this.depTB.Location = new System.Drawing.Point(64, 88);
            this.depTB.Name = "depTB";
            this.depTB.Size = new System.Drawing.Size(528, 21);
            this.depTB.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(24, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "部门：";
            // 
            // nameTB
            // 
            this.nameTB.Location = new System.Drawing.Point(64, 56);
            this.nameTB.Name = "nameTB";
            this.nameTB.Size = new System.Drawing.Size(80, 21);
            this.nameTB.TabIndex = 0;
            this.nameTB.TextChanged += new System.EventHandler(this.nameTB_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(24, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "姓名：";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(17, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "ISO号：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.booktv);
            this.groupBox2.Location = new System.Drawing.Point(16, 142);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(192, 184);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "图书列表";
            // 
            // booktv
            // 
            this.booktv.ImageIndex = 0;
            this.booktv.ImageList = this.imageList1;
            this.booktv.Location = new System.Drawing.Point(8, 24);
            this.booktv.Name = "booktv";
            this.booktv.SelectedImageIndex = 0;
            this.booktv.Size = new System.Drawing.Size(176, 144);
            this.booktv.TabIndex = 0;
            this.booktv.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.booktv_AfterSelect);
            this.booktv.DoubleClick += new System.EventHandler(this.booktv_DoubleClick);
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
            this.imageList1.Images.SetKeyName(6, "");
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.fbTB);
            this.groupBox3.Controls.Add(this.xjTB);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.jcsjTB);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.bookqbtn);
            this.groupBox3.Controls.Add(this.jcslTB);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.gclTB);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.smTB);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.zchTB);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.tsflhTB);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.wzhTB);
            this.groupBox3.Controls.Add(this.wzhl);
            this.groupBox3.Controls.Add(this.jjbjCB);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(216, 142);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(408, 152);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "图书信息";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // fbTB
            // 
            this.fbTB.Location = new System.Drawing.Point(360, 24);
            this.fbTB.Name = "fbTB";
            this.fbTB.Size = new System.Drawing.Size(40, 21);
            this.fbTB.TabIndex = 19;
            // 
            // xjTB
            // 
            this.xjTB.Enabled = false;
            this.xjTB.Location = new System.Drawing.Point(192, 120);
            this.xjTB.Name = "xjTB";
            this.xjTB.Size = new System.Drawing.Size(40, 21);
            this.xjTB.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(152, 128);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 16);
            this.label11.TabIndex = 17;
            this.label11.Text = "续借：";
            // 
            // jcsjTB
            // 
            this.jcsjTB.Location = new System.Drawing.Point(72, 120);
            this.jcsjTB.Name = "jcsjTB";
            this.jcsjTB.Size = new System.Drawing.Size(72, 21);
            this.jcsjTB.TabIndex = 15;
            this.jcsjTB.TextChanged += new System.EventHandler(this.jcsjTB_TextChanged);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(8, 128);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 16);
            this.label10.TabIndex = 16;
            this.label10.Text = "借阅时间：";
            // 
            // bookqbtn
            // 
            this.bookqbtn.Location = new System.Drawing.Point(240, 120);
            this.bookqbtn.Name = "bookqbtn";
            this.bookqbtn.Size = new System.Drawing.Size(75, 23);
            this.bookqbtn.TabIndex = 14;
            this.bookqbtn.Text = "图书查询";
            this.bookqbtn.Click += new System.EventHandler(this.bookqbtn_Click);
            // 
            // jcslTB
            // 
            this.jcslTB.Enabled = false;
            this.jcslTB.Location = new System.Drawing.Point(168, 88);
            this.jcslTB.Name = "jcslTB";
            this.jcslTB.Size = new System.Drawing.Size(56, 21);
            this.jcslTB.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(104, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 23);
            this.label9.TabIndex = 12;
            this.label9.Text = "借出数量：";
            // 
            // gclTB
            // 
            this.gclTB.Enabled = false;
            this.gclTB.Location = new System.Drawing.Point(56, 88);
            this.gclTB.Name = "gclTB";
            this.gclTB.Size = new System.Drawing.Size(48, 21);
            this.gclTB.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(8, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 23);
            this.label8.TabIndex = 10;
            this.label8.Text = "馆藏量：";
            // 
            // smTB
            // 
            this.smTB.Enabled = false;
            this.smTB.Location = new System.Drawing.Point(56, 56);
            this.smTB.Name = "smTB";
            this.smTB.Size = new System.Drawing.Size(344, 21);
            this.smTB.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 23);
            this.label7.TabIndex = 7;
            this.label7.Text = "书　名：";
            // 
            // zchTB
            // 
            this.zchTB.Location = new System.Drawing.Point(272, 24);
            this.zchTB.Name = "zchTB";
            this.zchTB.Size = new System.Drawing.Size(40, 21);
            this.zchTB.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(224, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 23);
            this.label6.TabIndex = 5;
            this.label6.Text = "种次号：";
            // 
            // tsflhTB
            // 
            this.tsflhTB.Location = new System.Drawing.Point(168, 24);
            this.tsflhTB.Name = "tsflhTB";
            this.tsflhTB.Size = new System.Drawing.Size(48, 21);
            this.tsflhTB.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(96, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 3;
            this.label5.Text = "图书分类号：";
            // 
            // wzhTB
            // 
            this.wzhTB.Location = new System.Drawing.Point(56, 24);
            this.wzhTB.Name = "wzhTB";
            this.wzhTB.Size = new System.Drawing.Size(32, 21);
            this.wzhTB.TabIndex = 1;
            this.wzhTB.TextChanged += new System.EventHandler(this.wzhTB_TextChanged);
            // 
            // wzhl
            // 
            this.wzhl.Location = new System.Drawing.Point(8, 32);
            this.wzhl.Name = "wzhl";
            this.wzhl.Size = new System.Drawing.Size(64, 23);
            this.wzhl.TabIndex = 2;
            this.wzhl.Text = "文种号：";
            // 
            // jjbjCB
            // 
            this.jjbjCB.Enabled = false;
            this.jjbjCB.Location = new System.Drawing.Point(232, 88);
            this.jjbjCB.Name = "jjbjCB";
            this.jjbjCB.Size = new System.Drawing.Size(80, 24);
            this.jjbjCB.TabIndex = 13;
            this.jjbjCB.Text = "据借标记";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(320, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 23);
            this.label12.TabIndex = 20;
            this.label12.Text = "副本：";
            // 
            // bobtn
            // 
            this.bobtn.Location = new System.Drawing.Point(216, 302);
            this.bobtn.Name = "bobtn";
            this.bobtn.Size = new System.Drawing.Size(64, 23);
            this.bobtn.TabIndex = 3;
            this.bobtn.Text = "借  阅";
            this.bobtn.Click += new System.EventHandler(this.bobtn_Click);
            // 
            // rebtn
            // 
            this.rebtn.Enabled = false;
            this.rebtn.Location = new System.Drawing.Point(360, 302);
            this.rebtn.Name = "rebtn";
            this.rebtn.Size = new System.Drawing.Size(64, 23);
            this.rebtn.TabIndex = 4;
            this.rebtn.Text = "归  还";
            this.rebtn.Click += new System.EventHandler(this.rebtn_Click);
            // 
            // closebtn
            // 
            this.closebtn.Location = new System.Drawing.Point(520, 302);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(96, 23);
            this.closebtn.TabIndex = 5;
            this.closebtn.Text = "关  闭";
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // sqlConn
            // 
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqlhrConn
            // 
            this.sqlhrConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // rbbtn
            // 
            this.rbbtn.Enabled = false;
            this.rbbtn.Location = new System.Drawing.Point(288, 302);
            this.rbbtn.Name = "rbbtn";
            this.rbbtn.Size = new System.Drawing.Size(64, 23);
            this.rbbtn.TabIndex = 6;
            this.rbbtn.Text = "续  借";
            this.rbbtn.Click += new System.EventHandler(this.rbbtn_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelWarn});
            this.statusStrip1.Location = new System.Drawing.Point(0, 334);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(632, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelWarn
            // 
            this.toolStripStatusLabelWarn.Name = "toolStripStatusLabelWarn";
            this.toolStripStatusLabelWarn.Size = new System.Drawing.Size(0, 17);
            // 
            // FormBor
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(632, 356);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.rbbtn);
            this.Controls.Add(this.closebtn);
            this.Controls.Add(this.rebtn);
            this.Controls.Add(this.bobtn);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormBor";
            this.Text = "图书借阅管理";
            this.Load += new System.EventHandler(this.FormBor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void wzhTB_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void groupBox3_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void closebtn_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void groupBox1_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void FormBor_Load(object sender, System.EventArgs e)
		{
			string strIC;

			s1="";s2="";s3="";icno="";
            //this.sqlhrConn.ConnectionString = strhrConn;
            this.sqlConn.ConnectionString=strConn;

            //this.sqlhrComm.Connection = this.sqlhrConn ;
            this.sqlComm.Connection = this.sqlConn;

            OracleConn.ConnectionString = strhrConn;
            OracleComm = OracleConn.CreateCommand();

			strIC=readICcard();

			if(strIC!="")
			{
				fillPeopleInfobyIC(strIC);
			}

			InitTreeView();

		}

		private void isobtn_Click(object sender, System.EventArgs e)
		{

			string IDcode;
			int intt;


			icno=isoTB.Text.ToUpper();
			if(icno=="0")
			{
				InitTreeView();
				return ;
			}




            icno = icno.TrimStart('0');
			IDcode=isoTB.Text.Trim().ToUpper().TrimStart('0');
			//if(IDcode=="") return;
			//intt=int.Parse(IDcode);
			//IDcode=intt.ToString();

			if(IDcode=="0")
			{
				InitTreeView();
				return;
			}

            //sqlhrComm.CommandText = "SELECT employees.ecode, employees.ecname, codeorgs.cdptname FROM employees INNER JOIN codeorgs ON employees.dept = codeorgs.dptno WHERE (employees.ecode = '"+IDcode+"')";

            //sqlhrConn.Open();
            //sqldr=sqlhrComm.ExecuteReader();

            //if(!sqldr.HasRows)
            //{
            //    sqldr.Close();
            //    sqlhrComm.Connection.Close();
            //    isoTB.Text=icno.ToUpper();
            //    MessageBox.Show("未查询到此ISO号员工信息");
            //    return;
            //}


            //try
            //{
            //    sqldr.Read();
            //    isoTB.Text=sqldr.GetValue(0).ToString();
            //    nameTB.Text=sqldr.GetValue(1).ToString();
            //    depTB.Text=sqldr.GetValue(2).ToString();
            //}
            //finally
            //{
            //    sqldr.Close();
            //    sqlhrComm.Connection.Close();
            //}

            try
            {
                OracleConn.Open();//打开指定的连接                  
                OracleComm.CommandText = "select v_sys_psn.psncode, v_sys_psn.psnname, v_sys_dept.first_deptname, v_sys_dept.second_deptname, v_sys_dept.third_deptname, v_sys_psn.mobile, v_sys_psn.officephone, v_sys_corp.UNITNAME from v_sys_psn LEFT OUTER JOIN V_SYS_DEPT ON v_sys_psn.pk_deptdoc = v_sys_dept.pk_fourtdept  LEFT OUTER JOIN v_sys_corp ON v_sys_psn.PK_CORP=v_sys_corp.PK_CORP where v_sys_psn.psncode=N'" + IDcode.PadLeft(5, '0') + "' ";//写好想执行的Sql语句                  
                odr = OracleComm.ExecuteReader();

                if (!odr.HasRows)
                {
                    odr.Close();
                    isoTB.Text = icno.ToUpper();
                    MessageBox.Show("未查询到此ISO号员工信息");
                    return;
                }
                else
                {
                    while (odr.Read())//读取数据，如果返回为false的话，就说明到记录集的尾部了                   
                    {
                        isoTB.Text = odr.GetValue(0).ToString();
                        nameTB.Text = odr.GetValue(1).ToString();
                        depTB.Text =  odr.GetValue(7).ToString()+"-"+odr.GetValue(2).ToString() +"-"+ odr.GetValue(3).ToString() +"-"+ odr.GetValue(4).ToString();
                        telTB.Text = odr.GetValue(5).ToString() + "  "+odr.GetValue(6).ToString();

                        break;
                    }
                    odr.Close();//关闭reader.这是一定要写的 
                }
            }
            catch
            {
                MessageBox.Show("数据库读取错误");//如果发生异常，则提示出错             
            }
            finally
            {
                OracleConn.Close();//关闭打开的连接             
            }

			//icno=isoTB.Text.ToUpper();

			InitTreeView();
		
		}

		private void icbtn_Click(object sender, System.EventArgs e)
		{
			string strIC="";

            textBoxRead.Text = "";
            textBoxRead.Focus();

            //readICcard();

		}
        private static byte[] strToToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

		private void bookqbtn_Click(object sender, System.EventArgs e)
		{
			string si;
			
			sqlComm.CommandText = "SELECT ID, 书名, 馆藏量, 借出书量, 拒借标记, 年代顺序号 FROM book WHERE (文种号 = N'"+wzhTB.Text.Trim().ToUpper()+"') AND (种次号 = N'"+zchTB.Text.Trim().ToUpper() +"') AND (图书分类号 = N'"+tsflhTB.Text.Trim().ToUpper()+"')";

			sqlConn.Open();
			sqldr=sqlComm.ExecuteReader();

			if(!sqldr.HasRows)
			{
				sqldr.Close();
				sqlComm.Connection.Close();
				
				wzhTB.Text=s1.ToUpper();
				zchTB.Text=s2.ToUpper();
				tsflhTB.Text=s3.ToUpper();
				
				MessageBox.Show("没有发现相应的图书！");
				return;
			}


			try
			{
				sqldr.Read();
				smTB.Text=sqldr.GetValue(1).ToString();
				gclTB.Text =sqldr.GetValue(2).ToString();
				jcslTB.Text =sqldr.GetValue(3).ToString();
				//ndsxhTB.Text = sqldr.GetValue(5).ToString();
				jcsjTB.Text="";
				xjTB.Text="0";

				si=sqldr.GetValue(4).ToString();
				
				if(si=="0" || si=="True") jjbjCB.Checked=true;
				else jjbjCB.Checked=false;

			}
			finally
			{
				sqldr.Close();
				sqlComm.Connection.Close();
			}

			wzhTB.Text=wzhTB.Text.ToUpper();
			zchTB.Text=zchTB.Text.ToUpper();
			tsflhTB.Text=tsflhTB.Text.ToUpper();

			s1=wzhTB.Text.ToUpper();
			s2=zchTB.Text.ToUpper();
			s3=tsflhTB.Text.ToUpper();

			rebtn.Enabled=false;
			rbbtn.Enabled=false;
		
		}

		private void InitTreeView()
		{
			booktv.BeginUpdate();
			booktv.Nodes.Clear();

			TreeNode rootNode= new TreeNode("所借图书",5,5);
			booktv.Nodes.Add(rootNode);

			if(icno=="")
			{
				booktv.EndUpdate();
				return;
			}

			if(icno=="0")
			{
				sqlComm.CommandText = "SELECT book.书名, borrow.文种号, borrow.种次号, borrow.图书分类号, borrow.借出时间,borrow.ID,borrow.归还时间,borrow.续借次数,borrow.副本 FROM borrow INNER JOIN book ON borrow.文种号 = book.文种号 AND borrow.种次号 = book.种次号 AND borrow.图书分类号 = book.图书分类号 WHERE (borrow.Ecode = '"+icno+"') AND (borrow.实际归还时间 IS NULL) AND (中文姓名 = '"+ nameTB.Text.Trim() +"')";
			}
			else
			{
				sqlComm.CommandText = "SELECT book.书名, borrow.文种号, borrow.种次号, borrow.图书分类号, borrow.借出时间,borrow.ID,borrow.归还时间,borrow.续借次数,borrow.副本 FROM borrow INNER JOIN book ON borrow.文种号 = book.文种号 AND borrow.种次号 = book.种次号 AND borrow.图书分类号 = book.图书分类号 WHERE (borrow.Ecode = '"+icno+"') AND (borrow.实际归还时间 IS NULL)";
			}


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
					TreeNode tnBook = new TreeNode(sqldr.GetValue(0).ToString(),0,1);
					booktv.Nodes[0].Nodes.Add(tnBook);

					TreeNode tnwzh = new TreeNode("文种号："+sqldr.GetValue(1).ToString(),2,2);
					tnBook.Nodes.Add(tnwzh);
					TreeNode tntsflh = new TreeNode("图书分类号："+sqldr.GetValue(3).ToString(),3,3);
					tnBook.Nodes.Add(tntsflh);
					TreeNode tnzch = new TreeNode("种次号："+sqldr.GetValue(2).ToString(),4,4);
					tnBook.Nodes.Add(tnzch);

					TreeNode tntime = new TreeNode("借出时间："+sqldr.GetValue(4).ToString(),5,5);
					tnBook.Nodes.Add(tntime);

					//TreeNode tnghsj = new TreeNode("归还时间："+System.DateTime.Now.AddDays(31).ToString(),5,5);
					TreeNode tnghsj = new TreeNode("归还时间："+sqldr.GetValue(6).ToString(),5,5);
					tnBook.Nodes.Add(tnghsj);
					
					TreeNode tnxj = new TreeNode("续借次数："+sqldr.GetValue(7).ToString(),5,5);
					tnBook.Nodes.Add(tnxj);

					TreeNode tnfb = new TreeNode("副本："+sqldr.GetValue(8).ToString(),6,6);
					tnBook.Nodes.Add(tnfb);

					TreeNode tnid = new TreeNode("借阅序号："+sqldr.GetValue(5).ToString());
					tnBook.Nodes.Add(tnid);


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

		private void bobtn_Click(object sender, System.EventArgs e)
		{
			int itt;
			string sid;
			DateTime dtime;


			if(isoTB.Text.Trim()=="0")
			{
				icno="0";
			}

			if(jcsjTB.Text.Trim()=="")
			{
				jcsjTB.Text=System.DateTime.Now.ToString();
			}


			if(icno=="")
			{
				MessageBox.Show("没有借阅人！");
				return;
			}

            icno = icno.TrimStart('0');

			if(s1==""||s2==""||s3=="")
			{
				MessageBox.Show("没有要借阅的图书！");
				return;

			}

			if(int.Parse(gclTB.Text.Trim())<=int.Parse(jcslTB.Text.Trim()))
			{
				MessageBox.Show("图书馆内已经没有该书了！");
				return;
			}

			if( jjbjCB.Checked)
			{
				if(MessageBox.Show("该书有据借标志，是否真的借出？","据借",MessageBoxButtons.YesNo )==DialogResult.No)
				{
					return;
				}

			}

			dtime=System.DateTime.Parse(jcsjTB.Text.Trim());
//			sqlComm.CommandText = "INSERT INTO borrow (Ecode, 文种号, 种次号, 图书分类号, 借出时间, 归还时间,电话,中文姓名, 副本) VALUES ('"+ icno +"', N'"+s1+"', N'"+s2+"', N'"+s3+"', '"+System.DateTime.Now.ToString()+"', '"+System.DateTime.Now.AddDays(31).ToString()+"', '"+telTB.Text.Trim()+"','"+nameTB.Text.Trim()+"','"+fbTB.Text.Trim()+"')";

			sqlComm.CommandText = "INSERT INTO borrow (Ecode, 文种号, 种次号, 图书分类号, 借出时间, 归还时间,电话,中文姓名, 副本) VALUES ('"+ icno +"', N'"+s1+"', N'"+s2+"', N'"+s3+"', '"+dtime.ToString()+"', '"+dtime.AddDays(31).ToString()+"', '"+telTB.Text.Trim()+"','"+nameTB.Text.Trim()+"','"+fbTB.Text.Trim()+"')";

			sqlConn.Open();
			sqlComm.ExecuteNonQuery();

			sqlComm.CommandText = "SELECT @@IDENTITY as id";
			sqldr=sqlComm.ExecuteReader();

			sqldr.Read();

			sid=sqldr.GetValue(0).ToString();

			sqlConn.Close();

			sqlComm.CommandText = "UPDATE book SET 借出书量 = 借出书量 + 1, 借出次数 = 借出次数 + 1 WHERE (文种号 = N'"+ s1 +"') AND (图书分类号 = N'"+ s3 +"') AND (种次号 = N'"+s2+"')";

			sqlConn.Open();
			sqlComm.ExecuteNonQuery();
			sqlConn.Close();




			itt=int.Parse(jcslTB.Text)+1;
			jcslTB.Text=itt.ToString();

			//增加TreeView
			booktv.BeginUpdate();
			
			TreeNode tnBook = new TreeNode(smTB.Text,0,1);
			booktv.Nodes[0].Nodes.Add(tnBook);

			TreeNode tnwzh = new TreeNode("文种号："+s1,2,2);
			tnBook.Nodes.Add(tnwzh);
			TreeNode tntsflh = new TreeNode("图书分类号："+s3,3,3);
			tnBook.Nodes.Add(tntsflh);
			TreeNode tnzch = new TreeNode("种次号："+s2,4,4);
			tnBook.Nodes.Add(tnzch);
//			TreeNode tnjcsj = new TreeNode("借出时间："+System.DateTime.Now.ToString(),5,5);
			TreeNode tnjcsj = new TreeNode("借出时间："+dtime.ToString(),5,5);

			tnBook.Nodes.Add(tnjcsj);
//			TreeNode tnghsj = new TreeNode("归还时间："+System.DateTime.Now.AddDays(31).ToString(),5,5);
			TreeNode tnghsj = new TreeNode("归还时间："+dtime.AddDays(31).ToString(),5,5);
			tnBook.Nodes.Add(tnghsj);
			TreeNode tnxj = new TreeNode("续借次数：0",5,5);
			tnBook.Nodes.Add(tnxj);


			TreeNode tnfb = new TreeNode("副本："+fbTB.Text.Trim(),6,6);
			tnBook.Nodes.Add(tnfb);
			TreeNode tnid = new TreeNode("借阅序号："+sid);
			tnBook.Nodes.Add(tnid);

			booktv.EndUpdate();

			booktv.Nodes[0].Expand();

		
		}

		private void booktv_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			
		}

		private void booktv_DoubleClick(object sender, System.EventArgs e)
		{
			int num;
			string si,stt;

			TreeNode tn=booktv.SelectedNode;

			if (tn.ImageIndex!=0 && tn.ImageIndex!=1)
			{ //root
				return;
			}

			foreach(TreeNode tns in tn.Nodes)
            {
				switch(tns.ImageIndex)
				{
					case 2:
						s1=tns.Text;
						num=s1.IndexOf("：",0);
						s1=s1.Remove(0,num+1);
						break;
					case 3:
						s3=tns.Text;
						num=s3.IndexOf("：",0);
						s3=s3.Remove(0,num+1);
						break;
					case 4:
						s2=tns.Text;
						num=s2.IndexOf("：",0);
						s2=s2.Remove(0,num+1);
						break;
					case 5:
						si=tns.Text;
						num=si.IndexOf("：",0);
						stt=si.Remove(0,num+1);

						if(si.StartsWith("借出时间"))//
						{
							jcsjTB.Text=stt.Trim();
						}
						if(si.StartsWith("续借次数"))//
						{
							xjTB.Text=stt.Trim();
						}
						break;

					case 6:
						stt=tns.Text;
						num=stt.IndexOf("：",0);
						stt=stt.Remove(0,num+1);
						this.fbTB.Text =stt;
						break;
					default:
						dt=tns.Text;
						num=dt.IndexOf("：",0);
						dt=dt.Remove(0,num+1);
						break;

				}
			}

			wzhTB.Text=s1;
			zchTB.Text=s2;
			tsflhTB.Text=s3;

			sqlComm.CommandText = "SELECT ID, 书名, 馆藏量, 借出书量, 拒借标记, 年代顺序号 FROM book WHERE (文种号 = N'"+wzhTB.Text.Trim().ToUpper()+"') AND (种次号 = N'"+zchTB.Text.Trim().ToUpper() +"') AND (图书分类号 = N'"+tsflhTB.Text.Trim().ToUpper()+"')";

			sqlConn.Open();
			sqldr=sqlComm.ExecuteReader();

			if(!sqldr.HasRows)
			{
				sqldr.Close();
				sqlComm.Connection.Close();
				
				wzhTB.Text=s1.ToUpper();
				zchTB.Text=s2.ToUpper();
				tsflhTB.Text=s3.ToUpper();
				
				MessageBox.Show("没有发现相应的图书！");
				return;
			}


			try
			{
				sqldr.Read();
				smTB.Text=sqldr.GetValue(1).ToString();
				gclTB.Text =sqldr.GetValue(2).ToString();
				jcslTB.Text =sqldr.GetValue(3).ToString();
				//jcsjTB.Text=System.DateTime.Now.ToString();
				//xjTB.Text="0";
				//ndsxhTB.Text = sqldr.GetValue(5).ToString();

				si=sqldr.GetValue(4).ToString();
				
				if(si=="0") jjbjCB.Checked=true;
				else jjbjCB.Checked=false;

			}
			finally
			{
				sqldr.Close();
				sqlComm.Connection.Close();
			}

			rebtn.Enabled=true;
			rbbtn.Enabled=true;

		}

		private void rebtn_Click(object sender, System.EventArgs e)
		{
			string ss1,ss2,ss3,sdt;
			int num;

			ss1="";ss2="";ss3="";sdt="";
			sqlComm.CommandText = "UPDATE borrow SET 实际归还时间 = '"+System.DateTime.Now.ToString() +"'WHERE (Ecode = '"+icno+"') AND (文种号 = N'"+s1+"') AND (种次号 = N'"+s2+"') AND (图书分类号 = N'"+s3+"') AND (ID = "+ dt +")";

			sqlConn.Open();
			sqlComm.ExecuteNonQuery();
			sqlConn.Close();

			sqlComm.CommandText = "UPDATE book SET 借出书量 = 借出书量 - 1 WHERE (文种号 = N'"+ s1 +"') AND (图书分类号 = N'"+ s3 +"') AND (种次号 = N'"+s2+"')";

			sqlConn.Open();
			sqlComm.ExecuteNonQuery();
			sqlConn.Close();

			TreeNode tnroot=booktv.Nodes[0];

			foreach(TreeNode tn in tnroot.Nodes)
			{
				foreach(TreeNode tns in tn.Nodes)
				{
					switch(tns.ImageIndex)
					{
						case 2:
							ss1=tns.Text;
							num=ss1.IndexOf("：",0);
							ss1=ss1.Remove(0,num+1);
							break;
						case 3:
							ss3=tns.Text;
							num=ss3.IndexOf("：",0);
							ss3=ss3.Remove(0,num+1);
							break;
						case 4:
							ss2=tns.Text;
							num=ss2.IndexOf("：",0);
							ss2=ss2.Remove(0,num+1);
							break;
						default:
							sdt=tns.Text;
							num=sdt.IndexOf("：",0);
							sdt=sdt.Remove(0,num+1);
							break;
					}
				}

				if (ss1==s1 && ss2==s2 && ss3==s3 && sdt==dt)
				{
					booktv.BeginUpdate();
					tn.Remove();
					booktv.EndUpdate();

					booktv.Nodes[0].Expand();
					break;

				}

			}

			num=int.Parse(jcslTB.Text.Trim())-1;
			jcslTB.Text=num.ToString();

			rebtn.Enabled=false;

		}

		private void rbbtn_Click(object sender, System.EventArgs e)
		{
			int i;

			i=int.Parse(xjTB.Text)+1;
			

			sqlComm.CommandText = "UPDATE borrow SET 续借次数 = 续借次数 + 1, 归还时间 = '"+System.DateTime.Now.AddDays(30).ToString()+"' WHERE (ID = "+dt+")";
			sqlConn.Open();
			sqlComm.ExecuteNonQuery();
			sqlConn.Close();

			xjTB.Text=i.ToString();
			MessageBox.Show("续借成功！归还日期延长到"+System.DateTime.Now.AddDays(30).ToString()+"，请注意，这是您第"+xjTB.Text+"次续借该书！");

			return;

		
		}

		private void jcsjTB_TextChanged(object sender, System.EventArgs e)
		{
 

		
		}

		private void nameTB_TextChanged(object sender, System.EventArgs e)
		{
		
		}

        private void textBoxRead_TextChanged(object sender, EventArgs e)
        {
            if (textBoxRead.Text.Trim() == "")
                return;

            if (textBoxRead.Text.Trim().Length != 10)
                return;

            string strIC = "";
            strIC = readICcard();

            if (strIC != "")
            {
                fillPeopleInfobyIC(strIC);
            }

            InitTreeView();
            textBoxRead.SelectAll();
        }
		
		

	}
}
