using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using nsAlienRFID;
using System.IO ;
using System.Text ;
using System.Data ;
using System.Data .SqlClient;

namespace BIADBOOK
{
	/// <summary>
	/// PrintBarCode 的摘要说明。
	/// </summary>
	public class PrintBarCode : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label lblBarCode;
		private System.Windows.Forms.Label ylblWZH;
		private System.Windows.Forms.Label lblDZBQ;
		private System.Windows.Forms.Button btnReaderTag;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Label lblNDSXH;
		private System.Windows.Forms.GroupBox grpBH;
		private System.Windows.Forms.Label lblSM;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lblTSFLH;
		private System.Windows.Forms.Label lblZCH;
		private System.Windows.Forms.Label lblWZH;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnPrint;
		private System.Windows.Forms.Button btnCanel;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ComboBox cboLocationId;
		private System.Windows.Forms.Label lblRoomInfo;
		private System.Windows.Forms.Label lblLocationInfo;
		private System.ComponentModel.IContainer components;
		//Reader参数声名
		private clsReader mReader;
		private ReaderInfo mReaderInfo;
		private ComInterface meReaderInterface = ComInterface.enumTCPIP;
		
		//Config.ini参数声名
		private string ConnectionString;//数据库连接字符串
		private string readerIP;//RFid读写器的IP地址
		private string readerIPProt;//RFid读写器的IP地址端口号
		private string readerUserName;//RFid读写器用户名;
		private string readerPassWord;
		private string PrintPort;//打印机端口

			
		private short ComPort; //AWID 设备端口 20060602
		private string recData=""; //awid return data 200602
		private StringBuilder  sb=new StringBuilder(20);
		private string str ="";
		private string Data="";
		//构造属性
		private string strWZH;
		private string strTSFLH;
		private string strZCH;
		private string strNDSXH;

		private string strGCL ; //馆藏量设置20060605 add;

		private System.Windows.Forms.PictureBox barCodeIMG;
		private System.Windows.Forms.Button btnPrintNew;
		private System.Windows.Forms.Label lbPrintCount;
//		private NumericTextbox.NumericTextBox txtBoxNum;
		private System.Windows.Forms.ComboBox comBoxNDSXH;
		private System.Windows.Forms.ComboBox comBoxZCH;
		private System.Windows.Forms.TextBox txbBoxCounter;
		private AxMSCommLib.AxMSComm axMSComm1;
	
		//
		private string strBH="";

		public PrintBarCode()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}
		public PrintBarCode(string WZH,string TSFLH,string ZCH,string NDSXH,string GCL)
		{
			this.strWZH =WZH.Trim ();
			this.strTSFLH =TSFLH.Trim ();
			this.strZCH =ZCH.Trim ();
			this.strNDSXH =NDSXH.Trim ();
			this.strGCL = GCL.Trim();
			InitializeComponent();
		}
		public PrintBarCode(string WZH,string TSFLH,string ZCH)
		{
			this.strWZH =WZH.Trim ();
			this.strTSFLH =TSFLH.Trim ();
			this.strZCH =ZCH.Trim ();
			this.strNDSXH ="";
			
			InitializeComponent();
		}
		#region 修改前的代码
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PrintBarCode));
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.lblDZBQ = new System.Windows.Forms.Label();
			this.btnReaderTag = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.barCodeIMG = new System.Windows.Forms.PictureBox();
			this.label18 = new System.Windows.Forms.Label();
			this.ylblWZH = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.lblBarCode = new System.Windows.Forms.Label();
			this.cboLocationId = new System.Windows.Forms.ComboBox();
			this.lblRoomInfo = new System.Windows.Forms.Label();
			this.lblLocationInfo = new System.Windows.Forms.Label();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.lblNDSXH = new System.Windows.Forms.Label();
			this.comBoxNDSXH = new System.Windows.Forms.ComboBox();
			this.grpBH = new System.Windows.Forms.GroupBox();
			this.lblSM = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lblTSFLH = new System.Windows.Forms.Label();
			this.lblZCH = new System.Windows.Forms.Label();
			this.lblWZH = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.comBoxZCH = new System.Windows.Forms.ComboBox();
			this.btnPrint = new System.Windows.Forms.Button();
			this.btnCanel = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnPrintNew = new System.Windows.Forms.Button();
			this.lbPrintCount = new System.Windows.Forms.Label();
			this.txbBoxCounter = new System.Windows.Forms.TextBox();
			this.axMSComm1 = new AxMSCommLib.AxMSComm();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.grpBH.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.axMSComm1)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.lblDZBQ);
			this.groupBox3.Controls.Add(this.btnReaderTag);
			this.groupBox3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.groupBox3.Location = new System.Drawing.Point(32, 168);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(472, 48);
			this.groupBox3.TabIndex = 4;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "电子标签:";
			// 
			// lblDZBQ
			// 
			this.lblDZBQ.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblDZBQ.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.lblDZBQ.Location = new System.Drawing.Point(40, 24);
			this.lblDZBQ.Name = "lblDZBQ";
			this.lblDZBQ.Size = new System.Drawing.Size(264, 16);
			this.lblDZBQ.TabIndex = 0;
			this.lblDZBQ.Text = "123456789012";
			// 
			// btnReaderTag
			// 
			this.btnReaderTag.BackColor = System.Drawing.Color.LightSkyBlue;
			this.btnReaderTag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnReaderTag.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btnReaderTag.Location = new System.Drawing.Point(328, 16);
			this.btnReaderTag.Name = "btnReaderTag";
			this.btnReaderTag.Size = new System.Drawing.Size(128, 24);
			this.btnReaderTag.TabIndex = 7;
			this.btnReaderTag.Text = "读标签";
			this.btnReaderTag.Click += new System.EventHandler(this.btnReaderTag_Click);
			// 
			// groupBox4
			// 
			this.groupBox4.BackColor = System.Drawing.Color.White;
			this.groupBox4.Controls.Add(this.barCodeIMG);
			this.groupBox4.Controls.Add(this.label18);
			this.groupBox4.Controls.Add(this.ylblWZH);
			this.groupBox4.Controls.Add(this.label8);
			this.groupBox4.Controls.Add(this.lblBarCode);
			this.groupBox4.Location = new System.Drawing.Point(32, 224);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(472, 128);
			this.groupBox4.TabIndex = 5;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "预览";
			this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
			// 
			// barCodeIMG
			// 
			this.barCodeIMG.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("barCodeIMG.BackgroundImage")));
			this.barCodeIMG.Location = new System.Drawing.Point(8, 17);
			this.barCodeIMG.Name = "barCodeIMG";
			this.barCodeIMG.Size = new System.Drawing.Size(456, 55);
			this.barCodeIMG.TabIndex = 13;
			this.barCodeIMG.TabStop = false;
			// 
			// label18
			// 
			this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label18.Location = new System.Drawing.Point(88, 96);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(280, 24);
			this.label18.TabIndex = 12;
			this.label18.Text = "北京市建筑设计研究院藏书";
			// 
			// ylblWZH
			// 
			this.ylblWZH.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.ylblWZH.Location = new System.Drawing.Point(80, 72);
			this.ylblWZH.Name = "ylblWZH";
			this.ylblWZH.Size = new System.Drawing.Size(192, 16);
			this.ylblWZH.TabIndex = 5;
			this.ylblWZH.Text = "3";
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label8.Location = new System.Drawing.Point(16, 72);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(64, 16);
			this.label8.TabIndex = 2;
			this.label8.Text = "索书号:";
			// 
			// lblBarCode
			// 
			this.lblBarCode.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblBarCode.Location = new System.Drawing.Point(280, 72);
			this.lblBarCode.Name = "lblBarCode";
			this.lblBarCode.Size = new System.Drawing.Size(176, 16);
			this.lblBarCode.TabIndex = 1;
			this.lblBarCode.Text = "123456789012";
			// 
			// cboLocationId
			// 
			this.cboLocationId.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.cboLocationId.Location = new System.Drawing.Point(8, 16);
			this.cboLocationId.Name = "cboLocationId";
			this.cboLocationId.Size = new System.Drawing.Size(120, 20);
			this.cboLocationId.TabIndex = 9;
			this.cboLocationId.Text = "cboLocationId";
			this.cboLocationId.SelectedIndexChanged += new System.EventHandler(this.cboLocationId_SelectedIndexChanged);
			// 
			// lblRoomInfo
			// 
			this.lblRoomInfo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblRoomInfo.Location = new System.Drawing.Point(8, 72);
			this.lblRoomInfo.Name = "lblRoomInfo";
			this.lblRoomInfo.Size = new System.Drawing.Size(120, 16);
			this.lblRoomInfo.TabIndex = 10;
			// 
			// lblLocationInfo
			// 
			this.lblLocationInfo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblLocationInfo.Location = new System.Drawing.Point(8, 48);
			this.lblLocationInfo.Name = "lblLocationInfo";
			this.lblLocationInfo.Size = new System.Drawing.Size(120, 16);
			this.lblLocationInfo.TabIndex = 11;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.lblNDSXH);
			this.groupBox5.Controls.Add(this.comBoxNDSXH);
			this.groupBox5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.groupBox5.Location = new System.Drawing.Point(8, 120);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(352, 40);
			this.groupBox5.TabIndex = 16;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "年代顺序号";
			// 
			// lblNDSXH
			// 
			this.lblNDSXH.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblNDSXH.Location = new System.Drawing.Point(16, 16);
			this.lblNDSXH.Name = "lblNDSXH";
			this.lblNDSXH.Size = new System.Drawing.Size(136, 16);
			this.lblNDSXH.TabIndex = 9;
			// 
			// comBoxNDSXH
			// 
			this.comBoxNDSXH.Location = new System.Drawing.Point(176, 8);
			this.comBoxNDSXH.Name = "comBoxNDSXH";
			this.comBoxNDSXH.Size = new System.Drawing.Size(128, 20);
			this.comBoxNDSXH.TabIndex = 32;
			this.comBoxNDSXH.SelectedIndexChanged += new System.EventHandler(this.comBoxNDSXH_SelectedIndexChanged);
			// 
			// grpBH
			// 
			this.grpBH.Controls.Add(this.lblSM);
			this.grpBH.Controls.Add(this.label6);
			this.grpBH.Controls.Add(this.label1);
			this.grpBH.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.grpBH.Location = new System.Drawing.Point(392, 112);
			this.grpBH.Name = "grpBH";
			this.grpBH.Size = new System.Drawing.Size(168, 56);
			this.grpBH.TabIndex = 13;
			this.grpBH.TabStop = false;
			this.grpBH.Text = "编号：12345";
			// 
			// lblSM
			// 
			this.lblSM.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblSM.Location = new System.Drawing.Point(48, 16);
			this.lblSM.Name = "lblSM";
			this.lblSM.Size = new System.Drawing.Size(112, 32);
			this.lblSM.TabIndex = 3;
			this.lblSM.Text = "建筑设计建筑设计建筑设计建筑设计建筑设计建筑设计建筑设计";
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label6.Location = new System.Drawing.Point(8, 16);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(56, 16);
			this.label6.TabIndex = 1;
			this.label6.Text = "书名：";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 16);
			this.label1.TabIndex = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lblTSFLH);
			this.groupBox1.Controls.Add(this.lblZCH);
			this.groupBox1.Controls.Add(this.lblWZH);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.comBoxZCH);
			this.groupBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(352, 104);
			this.groupBox1.TabIndex = 12;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "编目";
			// 
			// lblTSFLH
			// 
			this.lblTSFLH.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblTSFLH.Location = new System.Drawing.Point(88, 48);
			this.lblTSFLH.Name = "lblTSFLH";
			this.lblTSFLH.Size = new System.Drawing.Size(72, 16);
			this.lblTSFLH.TabIndex = 7;
			// 
			// lblZCH
			// 
			this.lblZCH.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblZCH.Location = new System.Drawing.Point(88, 72);
			this.lblZCH.Name = "lblZCH";
			this.lblZCH.Size = new System.Drawing.Size(72, 16);
			this.lblZCH.TabIndex = 6;
			// 
			// lblWZH
			// 
			this.lblWZH.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblWZH.Location = new System.Drawing.Point(88, 24);
			this.lblWZH.Name = "lblWZH";
			this.lblWZH.Size = new System.Drawing.Size(72, 16);
			this.lblWZH.TabIndex = 5;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label4.Location = new System.Drawing.Point(24, 72);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 16);
			this.label4.TabIndex = 3;
			this.label4.Text = "种次号：";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label3.Location = new System.Drawing.Point(8, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "图书分类号：";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.Location = new System.Drawing.Point(32, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "文种号：";
			// 
			// comBoxZCH
			// 
			this.comBoxZCH.Location = new System.Drawing.Point(176, 72);
			this.comBoxZCH.Name = "comBoxZCH";
			this.comBoxZCH.Size = new System.Drawing.Size(121, 20);
			this.comBoxZCH.TabIndex = 31;
			this.comBoxZCH.SelectedIndexChanged += new System.EventHandler(this.comBoxZCH_SelectedIndexChanged);
			// 
			// btnPrint
			// 
			this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPrint.Location = new System.Drawing.Point(304, 360);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new System.Drawing.Size(88, 24);
			this.btnPrint.TabIndex = 14;
			this.btnPrint.Text = "条码打印";
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			// 
			// btnCanel
			// 
			this.btnCanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCanel.Location = new System.Drawing.Point(416, 360);
			this.btnCanel.Name = "btnCanel";
			this.btnCanel.Size = new System.Drawing.Size(88, 24);
			this.btnCanel.TabIndex = 15;
			this.btnCanel.Text = "取消";
			this.btnCanel.Click += new System.EventHandler(this.btnCanel_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.cboLocationId);
			this.groupBox2.Controls.Add(this.lblLocationInfo);
			this.groupBox2.Controls.Add(this.lblRoomInfo);
			this.groupBox2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.groupBox2.Location = new System.Drawing.Point(400, 8);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(144, 96);
			this.groupBox2.TabIndex = 17;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "架位信息";
			// 
			// btnPrintNew
			// 
			this.btnPrintNew.Location = new System.Drawing.Point(104, 360);
			this.btnPrintNew.Name = "btnPrintNew";
			this.btnPrintNew.TabIndex = 18;
			this.btnPrintNew.Text = "书标打印";
			this.btnPrintNew.Click += new System.EventHandler(this.btnPrintNew_Click);
			// 
			// lbPrintCount
			// 
			this.lbPrintCount.AutoSize = true;
			this.lbPrintCount.Location = new System.Drawing.Point(264, 360);
			this.lbPrintCount.Name = "lbPrintCount";
			this.lbPrintCount.Size = new System.Drawing.Size(17, 17);
			this.lbPrintCount.TabIndex = 21;
			this.lbPrintCount.Text = "份";
			this.lbPrintCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txbBoxCounter
			// 
			this.txbBoxCounter.Location = new System.Drawing.Point(192, 360);
			this.txbBoxCounter.Name = "txbBoxCounter";
			this.txbBoxCounter.Size = new System.Drawing.Size(40, 21);
			this.txbBoxCounter.TabIndex = 24;
			this.txbBoxCounter.Text = "1";
			// 
			// axMSComm1
			// 
			this.axMSComm1.Enabled = true;
			this.axMSComm1.Location = new System.Drawing.Point(32, 352);
			this.axMSComm1.Name = "axMSComm1";
			this.axMSComm1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMSComm1.OcxState")));
			this.axMSComm1.Size = new System.Drawing.Size(38, 38);
			this.axMSComm1.TabIndex = 25;
			// 
			// PrintBarCode
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(568, 397);
			this.Controls.Add(this.axMSComm1);
			this.Controls.Add(this.txbBoxCounter);
			this.Controls.Add(this.lbPrintCount);
			this.Controls.Add(this.btnPrintNew);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.grpBH);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnPrint);
			this.Controls.Add(this.btnCanel);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox3);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PrintBarCode";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "打印书签";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.PrintBarCode_Closing);
			this.Load += new System.EventHandler(this.PrintBarCode_Load);
			this.groupBox3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.grpBH.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.axMSComm1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
		/// <summary>
		/// 声名打印机驱动函数
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

		private void PrintBarCode_Load(object sender, System.EventArgs e)
		{
			try
			{
			
				this.IniFile();//读取Config.ini中的参数


				//				mReader = new clsReader();
				//				mReaderInfo = mReader.ReaderSettings;

				this.Text = "书签打印";
				//				//连接alien阅读器
				//				this.ConnceiontReader ();

				this.InitComPort(); //初始化Com端口；	20060602
				//	Thread.CurrentThread.Name = "TestTagList";
				
				this.Filllabel();
				this.ShuBiaoSetting();
				ManageGUI(true);
				this.Display ();
				Load_cboLocationId();
			}
			catch{}
		}

		//显示数据
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
				this.grpBH .Text ="编号："+tempDBB.ID ;
				this.strBH =tempDBB.ID;
			}
			catch
			{
			
			}
		}

		
		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			if(this.cboLocationId.Text.Trim ().Equals ("请选择架位"))
			{
				MessageBox.Show ("请您选择架位后重试!","提示");
			}
			else
			{
				if (AddBookList()==0)
				{
					PrintLabel3();ManageGui(true);
					this.Close ();//打印完成，关闭窗体
				}
				else
				{
					MessageBox.Show("数据库执行错误");
				}
			}
			
		}
		private void PrintLabel1()
		{
			//			openport("LPT1");
			//
			//			sendcommand("DIRECTION 0");
			//			//setup("100", "30", "5.0", "12", "1", "0", "0");
			//			sendcommand("SIZE 100 mm,30 mm");
			//			clearbuffer();
			//			barcode("20","20", "128","100", "1", "0", "5", "4",lblDZBQ.Text .Trim ());
			//			windowsfont(20,165,25,0,2,0,0,"黑体","文种号");//-种次号-图书分类号-年代顺序号
			//			windowsfont(120,165,25,0,2,0,0,"黑体","种次号");
			//			windowsfont(220,165,25,0,2,0,0,"黑体","图书分类号");
			//			windowsfont(500,165,25,0,2,0,0,"黑体","年代顺序号");
			//		
			//			windowsfont(50,190,25,0,2,0,0,"黑体",lblWZH.Text.Trim());
			//			windowsfont(120,190,25,0,2,0,0,"黑体",lblZCH.Text.Trim());
			//			windowsfont(220,190,25,0,2,0,0,"黑体",lblTSFLH.Text.Trim ());
			//			windowsfont(500,190,25,0,2,0,0,"黑体",ylblNDSXH.Text.Trim ());
			//			windowsfont(495,125,25,0,2,0,0,"黑体","北京建筑设计研究院");
			//			printlabel("1", "1");
			//			closeport();
		}

		private void PrintLabel2()
		{
			//			openport("LPT1");
			//
			//			sendcommand("DIRECTION 0");
			//			//setup("100", "30", "5.0", "12", "1", "0", "0");
			//			sendcommand("SIZE 100 mm,30 mm");
			//			clearbuffer();
			//			barcode("20","20", "128","100", "1", "0", "3", "4",lblBarCode.Text .Trim ());
			//			windowsfont(375,120,25,0,2,0,0,"黑体","文种号：");//-种次号-图书分类号-年代顺序号
			//			windowsfont(375,145,25,0,2,0,0,"黑体","种次号：");
			//			windowsfont(375,170,25,0,2,0,0,"黑体","图书分类号：");
			//			windowsfont(375,195,25,0,2,0,0,"黑体","年代顺序号：");
			//		
			//			windowsfont(510,120,25,0,2,0,0,"黑体",lblWZH.Text.Trim());
			//			windowsfont(510,145,25,0,2,0,0,"黑体",lblZCH.Text.Trim());
			//			windowsfont(510,170,25,0,2,0,0,"黑体",lblTSFLH.Text.Trim ());
			//			windowsfont(510,195,25,0,2,0,0,"黑体",ylblNDSXH.Text.Trim ());
			//			windowsfont(20,170,45,15,2,0,0,"黑体","北京建筑设计研究院藏书");
			//			
			//			printlabel("1", "1");
			//			closeport();
		}
		
		private void PrintLabel3()
		{
			try
			{

				int x=20;
				openport("LPT1");
				sendcommand("CLS");
				sendcommand("DIRECTION 1");
				sendcommand("REFERENCE 0,8");
				sendcommand("DENSITY 6");
				sendcommand("SIZE 100 mm,30 mm");
				clearbuffer();
				barcode("56","10", "128","130", "0", "0", "3", "4",lblDZBQ.Text.Trim());
			
				windowsfont(56,140,30,0,2,0,0,"黑体","索书号：");
				string FH1="/",FH2="/";
				if (lblWZH.Text .Trim ().Equals ("")){FH1="";}
				if(lblTSFLH.Text .Trim ().Equals ("")){FH2="";}
			
				windowsfont(176,140,30,0,2,2,0,"黑体",lblWZH.Text.Trim()+FH1+lblTSFLH.Text.Trim ()+FH2+lblZCH.Text .Trim ());
				windowsfont(161,180,45,20,2,0,0,"汉仪大宋简",label18.Text .Trim ());
				windowsfont(514,140,30,0,2,0,0,"黑体",lblBarCode.Text .Trim ());
				printlabel("1", "1");
				closeport();
			}
			catch(Exception printE)
			{
				MessageBox.Show (printE.ToString());
			}
		}
//初始化Config中的参数
		private void IniFile()
		{
			try
			{
				//声名读写类对象
				//读取config.ini系统目录位置信息
				string SysPath;
				SysPath=Directory.GetCurrentDirectory().ToString()+"\\Config.ini";
				//判断Config.ini文件是否存在
				if(File.Exists(SysPath))
				{
					//截入Config.ini文件中的各参数
					IniFile ini = new IniFile(SysPath);
					//[DataBase]ConnectionString
					if(ini.IniReadValue("DataBase","ConnectionString")!="")
					{ 
						this.ConnectionString=ini.IniReadValue("DataBase","ConnectionString").Trim(); 
					}
					else
					{
						MessageBox.Show ("没发现数据库连接参数,请您填写正确的ConnectionString参数","Config.ini参数错误!");
					}
	
					//					//[RFidReader]//readerIP=//readerIPPort=//UserName=alien//Password=password
					//					if(ini.IniReadValue ("RFidReader","readerIP")!="" && ini.IniReadValue ("RFidReader","readerIPPort")	!="")
					//					{
					//						this.readerIP =ini.IniReadValue ("RFidReader","readerIP").Trim ();
					//						this.readerIPProt =ini.IniReadValue ("RFidReader","readerIPPort");
					//						this.readerUserName =ini.IniReadValue ("RFidReader","UserName").Trim ();
					//						this.readerPassWord =ini.IniReadValue ("RFidReader","PassWord").Trim ();	
					//					}
					//					else
					//					{
					//						MessageBox.Show("电子标签阅读器参数设置错误!Config.ini中readerIPPort与readerIPPort参数不能为空","Config.ini参数错误!");
					//					}

					//[BarCodePrint]//PrintPort=LPT1
					if(ini.IniReadValue ("BarCodePrint","PrintPort")!="")
					{
						this.PrintPort =ini.IniReadValue("BarCodePrint","PrintPort").Trim ();
					}
					else
					{
						MessageBox.Show("打印机设置错误!Config.ini中PrintPort参数不能为空","Config.ini参数错误!");
					}
					//[AWIDPort]//ComPort=2  20060602 
					if(ini.IniReadValue ("AWIDReader","ReaderComPort")!="")
					{
						this.ComPort = Int16.Parse(ini.IniReadValue("AWIDReader","ReaderComPort").Trim());
					}
					else
					{
						MessageBox.Show("Com设置错误!Config.ini中AWIDReaderPort参数不能为空","Config.ini参数错误!");
					}
				
				
				}
				else
				{
					//没发现Config.ini文件,系统不能运行，自动退出
					MessageBox.Show("没有Config.ini文件，不能正常运行！");
				}
			}
			catch(Exception ReaderiniE)
			{
				MessageBox.Show ("读config.ini出错"+ReaderiniE.ToString ());
			
			
			}
		}
		
		#region 		//连接阅读器
	
		//		private void ConnceiontReader()
		//		{
		//			String result;
		//			//string tempstr;
		//			this.Cursor = Cursors.WaitCursor;
		//			
		//			try		
		//			{
		//				if (meReaderInterface == ComInterface.enumTCPIP)
		//					mReader.InitOnNetwork(this.readerIP, Convert.ToInt32(this.readerIPProt.Trim()));
		//		
		//				this.Cursor = Cursors.WaitCursor;
		//
		//				result = mReader.Connect();
		//				if (!mReader.IsConnected)
		//				{
		//					lblDZBQ.Text ="未发现RFID阅读器";//textReaderTalk.AppendText ("\r\nCan't connect\r\n");
		//					MessageBox.Show ("请您正确设置RFID阅读器后重试!","未发现RFID阅读器");
		//					this.Close ();
		//				}
		//				else
		//				{
		//					if (meReaderInterface == ComInterface.enumTCPIP)
		//					{
		//						this.Cursor = Cursors.WaitCursor;
		//						if (!mReader.Login(this.readerUserName,this.readerPassWord ))		//returns result synchronously
		//						{
		//							mReader.Disconnect();
		//							return;
		//						}
		//						//tempstr=mReader.SendReceive ("set function=programmer",false).Trim ();//设置Reader为编程状态
		//						lblDZBQ.Text ="阅读器正常";
		//					
		//					}
		//				}
		//			}
		//			catch(Exception ex)
		//			{
		//				MessageBox.Show(ex.Message);
		//			}
		//			this.Cursor = Cursors.Default;
		//
		//		}
		#endregion

		private void btnCanel_Click(object sender, System.EventArgs e)
		{
			this.Close ();
		}
	
		
		private void ManageGUI (bool flag)
		{
			cboLocationId.Enabled = !flag;
			btnReaderTag.Enabled = flag;
			btnCanel.Enabled =flag;
			btnPrint.Enabled =!flag;
		
		}
		private void ManageGui(bool  flag)
		{
			cboLocationId.Enabled = !flag;
			btnReaderTag.Enabled = !flag;
			btnCanel.Enabled =flag;
			btnPrint.Enabled =!flag;
		}

		private void groupBox4_Enter(object sender, System.EventArgs e)
		{
		
		}
		private void Load_cboLocationId()
		{
			try
			{
				cboLocationId.Items .Clear ();
				cboLocationId.Text ="请选择架位";
				SqlConnection conn =new SqlConnection (this.ConnectionString .Trim ());
				SqlCommand cmd =new SqlCommand ("select * from BookLocation",conn);
				SqlDataReader DR;
			
				conn.Open ();
				DR=cmd.ExecuteReader ();
				while(DR.Read ())
				{
					cboLocationId.Items.Add (DR["BookLocationId"].ToString ().Trim ());					
				}
				conn.Close ();
			}
			catch
			{
			
			}
		}

		private void cboLocationId_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				//MessageBox.Show (cboLocationId.Text .Trim ());
				SqlConnection Cnn =new SqlConnection (this.ConnectionString .Trim ());
				SqlCommand Cmd =new SqlCommand ("select * from BookLocation where BookLocationId='"+cboLocationId.Text.Trim()+"'",Cnn);
				SqlDataReader dr;
			
				Cnn.Open ();
				dr=Cmd.ExecuteReader ();
				while(dr.Read ())
				{
					this.lblLocationInfo .Text =dr["BookLocationInfo"].ToString ().Trim ();					
					this.lblRoomInfo .Text =dr["BookRoomInfo"].ToString ().Trim ();
				}
				Cnn.Close ();
			}
			catch{}
		}

	
		private int AddBookList()
		{
			MessageBoxButtons buttons = MessageBoxButtons.YesNo;
			DialogResult result;
			int Exe=9;
			try
			{
				string addstr="insert into booklist(BarCode,BookId,WZH,ZCH,TSFLH,NDSXH,BookLocation)values('"+this.lblBarCode.Text.Trim ()
					+"','"+this.strBH .Trim ()+"','"+this.lblWZH .Text .Trim ()+"','"+this.lblZCH .Text .Trim ()+"','"+this.lblTSFLH.Text.Trim ()+"','"+this.lblNDSXH .Text .Trim ()+"','"+this.cboLocationId.Text .Trim ()+"')";
			
				string updatestr="UPDATE booklist SET BookId='"+this.strBH.Trim()+"',WZH='"+this.lblWZH .Text .Trim ()+
					"',ZCH='"+this.lblZCH.Text .Trim ()+"' ,TSFLH ='"+this.lblTSFLH .Text .Trim ()+"',NDSXH='"+this.lblNDSXH .Text .Trim ()+"',BookLocation='"+this.cboLocationId.Text .Trim ()+"'  where BarCode='"+this.lblBarCode.Text .Trim ()+"'";
			
			
				SqlConnection addCnn=new SqlConnection (this.ConnectionString .Trim ());
				SqlCommand addCmd=new SqlCommand ();
			
			
				addCmd.CommandText ="select count(*) from booklist where BarCode='"+this.lblBarCode.Text .Trim ()+"'";
				addCmd.Connection =addCnn;
				addCnn.Open();
				int i=(int)addCmd.ExecuteScalar();
				addCnn.Close();
				if(i>0)//说明数据库中已经有这个BarCode号
				{
					result = MessageBox.Show("此电子标签已用,是否修改数据库中的记录","重要提示",buttons);

					if(result == DialogResult.Yes)
					{//使用更新
						addCmd.CommandText =updatestr.Trim ();
						addCmd.Connection =addCnn;
						try
						{
							addCnn.Open ();
							addCmd.ExecuteNonQuery ();
							addCnn.Close ();
							Exe=0;
						}
						catch
						{
							Exe=1;
							MessageBox.Show ("更新数据失败!");}
					}
					else
					{
						Exe=0;
						this.Close ();
					}
					
				}
				else
				{//创建新记录
					addCmd.CommandText =addstr.Trim ();
					addCmd.Connection =addCnn;
					try
					{
						addCnn.Open ();
						addCmd.ExecuteNonQuery ();
						addCnn.Close ();
						Exe=0;//0代表成功
					}
					catch(Exception ex)
					{
						Exe=1;
						MessageBox.Show("创建记录失败!"+ex.ToString ());
					}
				}
				return Exe;
			}
			catch
			{
				return Exe;
				MessageBox.Show ("查询历史记录失败!");
			}
		}
	
		#endregion
		private void btnReaderTag_Click(object sender, System.EventArgs e)
		{
			try
			{
				lblDZBQ.Text="";
				lblBarCode.Text ="";
				this.axMSComm1.InBufferCount = 0;
				AwidTagID();	
				#region   Alien Reader  
				//				mReader.TagListFormat = "Text";
				//				String result = mReader.TagList;
				//				TagInfo[] aTags;
				//				TagInfo tag;
				//				int cnt;
				//				//	MessageBox.Show (result.Trim ());
				//				if ((result.Length > 0) && (result.IndexOf("No Tags") == -1))
				//				{
				//					cnt = AlienUtils.ParseTagList(result, out aTags);
				//					tag=aTags[0];
				//					//MessageBox.Show(tag.TagID,cnt.ToString () );
				//					
				//					lblBarCode.Text =tag.TagID.Substring(0,4)+tag.TagID .Substring(5,4)+tag.TagID .Substring (10,4)+tag.TagID .Substring (15,4);
				//					lblDZBQ.Text =tag.TagID ;
				//					//barCodeIMG =lblBarCode.Text .Trim ();
				//					ylblWZH.Text =lblWZH.Text.Trim()+","+lblTSFLH.Text.Trim ()+","+lblZCH.Text .Trim ();
				//					ManageGUI(false);//按钮状态
				//				}
				#endregion

//
//				lblDZBQ.Text = recData;
//				barCodeIMG.Text =recData;
//				this.lblBarCode.Text = recData;
//				ylblWZH.Text =lblWZH.Text.Trim()+","+lblTSFLH.Text.Trim ()+","+lblZCH.Text .Trim ();
		
				//ManageGUI(false);//按钮状态
				//this.ManageGUI(false);
				this.ManageGui(false);
		
		
			}
			catch(Exception ReaderE){MessageBox.Show ("读签出错"+ReaderE.ToString ());}
		}

		
		private void PrintBarCode_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//			if (mReader != null)
			//			{
			//				if (mReader.IsConnected)
			//					mReader.Disconnect();
			//			}
			// 检查一下Com2是否被使用了，若被使用了，把Com1关闭并重设.20060602 Add
			this.str =null;
			this.recData =null;
			this.axMSComm1.InBufferCount = 0;
			this.axMSComm1.Output = new byte[] {0x00};
			if (axMSComm1.PortOpen) axMSComm1.PortOpen = false;

		}

		///
		/// 初始化Com 端口
		///2006－06-02 添加 start
		private void InitComPort()
		{
		
			// 设置连接串口为Com2
			axMSComm1.CommPort = this.ComPort;
    
			// 检查一下Com2是否被使用了，若被使用了，把Com1关闭并重设.
			if (axMSComm1.PortOpen) axMSComm1.PortOpen = false;
    
			// 设定当有数据进入缓充区时 不触发Comm事件
			axMSComm1.RThreshold = 14;  
    
			// 设定串口
			axMSComm1.Settings = "9600,n,8,1";

			// DTR线路为高电位
			axMSComm1.DTREnable = true;
    
			// 沒使用交互
			axMSComm1.Handshaking = MSCommLib.HandshakeConstants.comNone;

    
			// 使用字节数组传输模式
			axMSComm1.InputMode = MSCommLib.InputModeConstants.comInputModeBinary;

			// 使用Input时读取全部数据
			axMSComm1.InputLen =14;
			
	
			// 0x00为有用字节
			axMSComm1.NullDiscard = false;
    
		
			//当使用字节数组时注冊OnComm1的事件处理函数
			axMSComm1.OnComm += new System.EventHandler(this.OnComm1);
		
			// 把Com打开
			axMSComm1.PortOpen = true;  
		}


		/// <summary>
		/// 发送读标笺指令
		/// </summary>
		private  void AwidTagID()
		{
			
			try
			{
				this.axMSComm1.Output= new byte[] {0x05,0x16,0x11,0x73,0x56};//read Single Tag Meter;

			
				//ManageGUI(false);//按钮状态

			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

		}
		
		/// <summary>
		/// 接收缓冲区出发的事键
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnComm1(object sender, EventArgs e)
		{		
		
			this.Cursor = Cursors.WaitCursor;
			 str ="";
			
			if (this.axMSComm1.InBufferCount > 0)
			{				
				byte[] result = (byte[])this.axMSComm1.Input;
				if(result.Length >1)
				{
					if(result[0]==0xe && result.Length >11)
					{				
						foreach( byte be in result)
						{
							str +=be.ToString("X2");
						}
						recData = str.Substring(6,16);
					
						this.axMSComm1.RThreshold =0;
					
					}
					else if(result[1]==0xe && result.Length >11)
					{
						foreach(byte be in result)
						{
							str +=be.ToString("X2");
						}
					
						recData=str.Substring(8,16);
						this.axMSComm1.RThreshold =0;	
													
					}
				}
					//this.axMSComm1.Output = new byte[]{0x00};
					//	CleanBuffer();				
				Data = recData.Substring(0,4)+" "+recData.Substring(4,4)+" "+recData.Substring(8,4) + " "+recData.Substring(12,4);
				lblDZBQ.Text = Data;
				//MessageBox.Show(a.Substring(0,4)+ " "+a.Substring(4,4)+ " "+a.Substring(8,4)+" "+ a.Substring(12,4 ));
				barCodeIMG.Text =Data;
				//barCodeIMG.Text = recData+"   ";
				this.lblBarCode.Text = recData;
				ylblWZH.Text =lblWZH.Text.Trim()+","+lblTSFLH.Text.Trim ()+","+lblZCH.Text .Trim ();	
			    CleanBuffer();			
					
			}
			this.Cursor = Cursors.Default;
		
		
	}

		/// <summary>
		/// 打印标签
		/// </summary>
		private void NewPrintLabel()
		{
			int TSFLHP_X =0;
			int ZCHP_X =0;
			int NDSXHP_X =0;
			try
			{
//				for(int t =0;t<this.comBoxZCH.Items.Count;t++)
//				{
				
					this.Cursor = Cursors.WaitCursor;
				//书签打印
					openport("LPT1");
					sendcommand("CLS");
					sendcommand("DIRECTION 1");
					sendcommand("REFERENCE 0,8");
					sendcommand("DENSITY 6");
					sendcommand("SIZE 100mm ,30mm ");
					clearbuffer();
					string FH1="|",FH2="|";
					if (lblZCH.Text .Trim().Equals ("")){FH1="";}
					if(lblTSFLH.Text.Trim ().Equals ("")){FH2="";}

					switch (lblTSFLH.Text.Length)
					{
						case 2:
							TSFLHP_X =516;
							break;
						case 3:
							TSFLHP_X =510;
							break;
						case 4:
							TSFLHP_X =500;
							break;
						case 5:
							TSFLHP_X =490;
							break;
						case 6:
							TSFLHP_X =480;
							break;
						case 7:
							TSFLHP_X =476;
							break;
						case 8:
							TSFLHP_X =464;
							break;
					}
					switch (comBoxZCH.Text.Length)
					{
						case 2:
							ZCHP_X=516;
							break;
						case 3:
							ZCHP_X=510;
							break;
						case 4:
							ZCHP_X=500;
							break;
						case 5:
							ZCHP_X=490;
							break;
						case 6:
							ZCHP_X=480;
							break;
					}
					switch (comBoxNDSXH.Text.Length)
					{
						case 6:
							NDSXHP_X=480;
							break;
						case 7:
							NDSXHP_X=476;
							break;
						case 8:
							NDSXHP_X=464;
							break;
						case 9:
							NDSXHP_X=450;
							break;
						case 10:
							NDSXHP_X=442;
							break;
				
					}
					windowsfont(526,36,32,0,2,2,0,"黑体", lblWZH.Text.Trim());
					windowsfont(TSFLHP_X,81,32,0,2,2,0,"黑体",lblTSFLH.Text.Trim ());
					windowsfont(ZCHP_X,126,32,0,2,2,0,"黑体",this.comBoxZCH.Text);
					windowsfont(NDSXHP_X,176,32,0,2,2,0,"黑体",this.comBoxNDSXH.Text);
					windowsfont(8,102,40,18,2,0,0,"汉仪大宋简","北京市建筑设计研究院藏书");
					sendcommand("PUTPCX 632,34,\"nj.PCX\"");
					printlabel("1",txbBoxCounter.Text);

					closeport();
					this.Cursor = Cursors.Default ;
//				}
			}
			catch(Exception printE)
			{
				MessageBox.Show (printE.ToString());
			}
		}

		private void btnPrintNew_Click(object sender, System.EventArgs e)
		{
			
			NewPrintLabel();
		}
		/// <summary>
		/// 对种次号及年代顺序号进行设置
		/// </summary>
		private void ShuBiaoSetting() 
		{
			int GCLCounter =Int32.Parse(strGCL.Trim());
			if(GCLCounter >1)
			{
				char[] spl = {','};
				string[] result =  this.lblNDSXH.Text.Split(spl); //以","分割年代顺序号；
	
				
				int ipos = this.lblNDSXH.Text.IndexOf("-");  //获取"-"的位置；
				string str = this.lblNDSXH.Text.Substring(0,ipos+1); //取年代顺序号前导；
				comBoxNDSXH.Items.Add(result[0]);  //添加第一个年代顺序号标记；
				for(int s=1;s< result.Length;s++ )
				{
					comBoxNDSXH.Items.Add(str+result[s]);
				}
			
				for(int i =1;i<=GCLCounter;i++)
				{
					comBoxZCH.Items.Add(this.lblZCH.Text+"-"+i.ToString());
				}
				
			}
			else
			{
				comBoxZCH.Items.Add(this.lblZCH.Text);
				comBoxNDSXH.Items.Add(this.lblNDSXH.Text);
			}
			comBoxZCH.SelectedIndex = 0;
			comBoxNDSXH.SelectedIndex = 0;
			
		}
		private void comBoxZCH_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(comBoxNDSXH.Items.Count>1 && comBoxNDSXH.Items.Count ==comBoxZCH.Items.Count )
				comBoxNDSXH.SelectedIndex = comBoxZCH.SelectedIndex;
		}

		private void comBoxNDSXH_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(comBoxZCH.Items.Count>1  && comBoxNDSXH.Items.Count ==comBoxZCH.Items.Count)
			comBoxZCH.SelectedIndex = comBoxNDSXH.SelectedIndex;
		}

		private void Filllabel()
		{
			this.lblWZH.Text = 	this.strWZH;
			this.lblTSFLH.Text = strTSFLH ;
			this.lblZCH.Text = strZCH ;
			this.lblNDSXH.Text = strNDSXH;
			//this.strGCL ;
		}

		private void ReadData()
		{
			if (this.axMSComm1.InBufferCount > 0)
			{

				byte[] result = (byte[])this.axMSComm1.Input;
				if(result.Length > 11)
				{
					if(result[0]==0x00 &&result[1]==0xe)
					{	
						foreach(byte be in result)
						{
							str +=be.ToString("X2");
						}
						this.recData = str.Substring(9,16);
					}
					else if(result[0]==0xe )
					{
						foreach(byte be in result)
						{
							str +=be.ToString("X2");
						}
						this.recData = str.Substring(6,16);
					}
					str ="";
					this.axMSComm1.Output = new byte[]{0x00};
					
					CleanBuffer();
			
				}
			}
 
		}
		
		private void CleanBuffer()
		{
			while(this.axMSComm1.InBufferCount > 0)
			{
				byte[] result1 = (byte[])this.axMSComm1.Input;
				result1=null;
				str=null;
			}
		}

		private void MID(int x,int w, int leng)
		{
			
			int pos = x+(w-x)/2-leng/2;
		
		}

	}
}
