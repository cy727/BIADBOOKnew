using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BIADBOOK
{
	/// <summary>
	/// FormBook ��ժҪ˵����
	/// </summary>
	public class FormBook : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox wzhText;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tsflhText;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.TextBox zchText;
		private System.Windows.Forms.TextBox smText;
		private System.Windows.Forms.TextBox bltmText;
		private System.Windows.Forms.TextBox ftmText;
		private System.Windows.Forms.TextBox blftmText;
		private System.Windows.Forms.TextBox ysText;
		private System.Windows.Forms.TextBox kbText;
		private System.Windows.Forms.TextBox ftText;
		private System.Windows.Forms.TextBox jgText;
		private System.Windows.Forms.TextBox gbText;
		private System.Windows.Forms.TextBox dyzrzText;
		private System.Windows.Forms.TextBox qtzrzText;
		private System.Windows.Forms.TextBox bbText;
		private System.Windows.Forms.TextBox ygzrzText;
		private System.Windows.Forms.TextBox cbrqText;
		private System.Windows.Forms.TextBox cbdText;
		private System.Windows.Forms.TextBox cbzText;
		private System.Windows.Forms.TextBox ndsxhText;
		private System.Windows.Forms.TextBox ckrqText;
		private System.Windows.Forms.TextBox gclText;
		private System.Windows.Forms.TextBox jcslText;
		private System.Windows.Forms.TextBox jccsText;
		private System.Windows.Forms.TextBox jjcsText;
		private System.Windows.Forms.CheckBox jjbjcBox;
		private System.Windows.Forms.CheckBox yxgfcBox;
		private System.Windows.Forms.CheckBox sxgfcBox;
		private System.Windows.Forms.TextBox zzText;
		private System.Windows.Forms.TextBox nrjjText;
		private System.Windows.Forms.TextBox fjText;
		public System.Data.SqlClient.SqlConnection sqlConn;
		private System.Data.SqlClient.SqlDataAdapter sdaBook;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		private System.Data.DataSet dsformBook1;
		private System.Windows.Forms.TextBox fzText;
		private System.Windows.Forms.CurrencyManager cm;
		public string sc1="",sc2="",sc3="",bookID;
		private string selectC="";
		private System.Windows.Forms.Button btnEdit;
		private System.Data.SqlClient.SqlCommand sqlc1=new System.Data.SqlClient.SqlCommand("SELECT * FROM book WHERE  ���ֺ�='@���ֺ�' AND ͼ������='@ͼ������' AND �ִκ�='@�ִκ�'");
		private System.Data.SqlClient.SqlDataReader sqlReader1;
		private System.Windows.Forms.Button btnQue;
		public string strConn;
		private System.Data.SqlClient.SqlCommand booksqlComm;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnDel;
		private System.Windows.Forms.Button btnClose;
		public bool isChange;
		private System.Windows.Forms.Button butnow1;
		private System.Windows.Forms.Button butPrn;


	
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormBook()
		{
			//
			// Windows ���������֧���������
			//
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.zchText = new System.Windows.Forms.TextBox();
            this.tsflhText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.wzhText = new System.Windows.Forms.TextBox();
            this.smText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bltmText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ftmText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.blftmText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ysText = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.kbText = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ftText = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.jgText = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.gbText = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dyzrzText = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.qtzrzText = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.bbText = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.ygzrzText = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cbrqText = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cbdText = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cbzText = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.ndsxhText = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.ckrqText = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.gclText = new System.Windows.Forms.TextBox();
            this.jcslText = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.jccsText = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.jjcsText = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.jjbjcBox = new System.Windows.Forms.CheckBox();
            this.yxgfcBox = new System.Windows.Forms.CheckBox();
            this.sxgfcBox = new System.Windows.Forms.CheckBox();
            this.zzText = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.nrjjText = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.fzText = new System.Windows.Forms.TextBox();
            this.fjText = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.butnow1 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnQue = new System.Windows.Forms.Button();
            this.booksqlComm = new System.Data.SqlClient.SqlCommand();
            this.butPrn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.zchText);
            this.groupBox1.Controls.Add(this.tsflhText);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.wzhText);
            this.groupBox1.Location = new System.Drawing.Point(8, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 112);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ͼ�������Ϣ";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(40, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "�ִκţ�";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "ͼ�����ţ�";
            // 
            // zchText
            // 
            this.zchText.Location = new System.Drawing.Point(96, 80);
            this.zchText.Name = "zchText";
            this.zchText.Size = new System.Drawing.Size(96, 21);
            this.zchText.TabIndex = 3;
            // 
            // tsflhText
            // 
            this.tsflhText.Location = new System.Drawing.Point(96, 48);
            this.tsflhText.Name = "tsflhText";
            this.tsflhText.Size = new System.Drawing.Size(96, 21);
            this.tsflhText.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(40, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "���ֺţ�";
            // 
            // wzhText
            // 
            this.wzhText.Location = new System.Drawing.Point(96, 16);
            this.wzhText.Name = "wzhText";
            this.wzhText.Size = new System.Drawing.Size(96, 21);
            this.wzhText.TabIndex = 0;
            // 
            // smText
            // 
            this.smText.Location = new System.Drawing.Point(288, 24);
            this.smText.Name = "smText";
            this.smText.Size = new System.Drawing.Size(280, 21);
            this.smText.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(216, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "������������";
            // 
            // bltmText
            // 
            this.bltmText.Location = new System.Drawing.Point(288, 48);
            this.bltmText.Name = "bltmText";
            this.bltmText.Size = new System.Drawing.Size(280, 21);
            this.bltmText.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(216, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "������������";
            // 
            // ftmText
            // 
            this.ftmText.Location = new System.Drawing.Point(288, 72);
            this.ftmText.Name = "ftmText";
            this.ftmText.Size = new System.Drawing.Size(280, 21);
            this.ftmText.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(216, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 24);
            this.label6.TabIndex = 6;
            this.label6.Text = "������������";
            // 
            // blftmText
            // 
            this.blftmText.Location = new System.Drawing.Point(288, 96);
            this.blftmText.Name = "blftmText";
            this.blftmText.Size = new System.Drawing.Size(280, 21);
            this.blftmText.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(216, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 23);
            this.label7.TabIndex = 8;
            this.label7.Text = "���и�������";
            // 
            // ysText
            // 
            this.ysText.Location = new System.Drawing.Point(640, 32);
            this.ysText.Name = "ysText";
            this.ysText.Size = new System.Drawing.Size(88, 21);
            this.ysText.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(592, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "ҳ����";
            // 
            // kbText
            // 
            this.kbText.Location = new System.Drawing.Point(640, 59);
            this.kbText.Name = "kbText";
            this.kbText.Size = new System.Drawing.Size(88, 21);
            this.kbText.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(592, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 16);
            this.label9.TabIndex = 12;
            this.label9.Text = "������";
            // 
            // ftText
            // 
            this.ftText.Location = new System.Drawing.Point(64, 72);
            this.ftText.Name = "ftText";
            this.ftText.Size = new System.Drawing.Size(88, 21);
            this.ftText.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(592, 96);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 16);
            this.label10.TabIndex = 14;
            this.label10.Text = "��ͼ��";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(16, 112);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 23);
            this.label11.TabIndex = 16;
            this.label11.Text = "������";
            // 
            // jgText
            // 
            this.jgText.Location = new System.Drawing.Point(64, 136);
            this.jgText.Name = "jgText";
            this.jgText.Size = new System.Drawing.Size(88, 21);
            this.jgText.TabIndex = 17;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(592, 160);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 16);
            this.label12.TabIndex = 18;
            this.label12.Text = "�۸�";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(16, 176);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 16);
            this.label13.TabIndex = 20;
            this.label13.Text = "��ע��";
            // 
            // gbText
            // 
            this.gbText.Location = new System.Drawing.Point(56, 136);
            this.gbText.Name = "gbText";
            this.gbText.Size = new System.Drawing.Size(100, 21);
            this.gbText.TabIndex = 21;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(16, 144);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 23);
            this.label14.TabIndex = 22;
            this.label14.Text = "����";
            // 
            // dyzrzText
            // 
            this.dyzrzText.Location = new System.Drawing.Point(232, 136);
            this.dyzrzText.Name = "dyzrzText";
            this.dyzrzText.Size = new System.Drawing.Size(336, 21);
            this.dyzrzText.TabIndex = 23;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(160, 144);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 23);
            this.label15.TabIndex = 24;
            this.label15.Text = "��һ�����ߣ�";
            // 
            // qtzrzText
            // 
            this.qtzrzText.Location = new System.Drawing.Point(368, 160);
            this.qtzrzText.Name = "qtzrzText";
            this.qtzrzText.Size = new System.Drawing.Size(200, 21);
            this.qtzrzText.TabIndex = 25;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(296, 168);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(80, 23);
            this.label16.TabIndex = 26;
            this.label16.Text = "���������ߣ�";
            // 
            // bbText
            // 
            this.bbText.Location = new System.Drawing.Point(56, 160);
            this.bbText.Name = "bbText";
            this.bbText.Size = new System.Drawing.Size(48, 21);
            this.bbText.TabIndex = 27;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(16, 168);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(48, 23);
            this.label17.TabIndex = 28;
            this.label17.Text = "�汾��";
            // 
            // ygzrzText
            // 
            this.ygzrzText.Location = new System.Drawing.Point(184, 160);
            this.ygzrzText.Name = "ygzrzText";
            this.ygzrzText.Size = new System.Drawing.Size(104, 21);
            this.ygzrzText.TabIndex = 29;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(112, 168);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(80, 16);
            this.label18.TabIndex = 30;
            this.label18.Text = "�й������ߣ�";
            // 
            // cbrqText
            // 
            this.cbrqText.Location = new System.Drawing.Point(80, 184);
            this.cbrqText.Name = "cbrqText";
            this.cbrqText.Size = new System.Drawing.Size(100, 21);
            this.cbrqText.TabIndex = 31;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(16, 192);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(72, 23);
            this.label19.TabIndex = 32;
            this.label19.Text = "�������ڣ�";
            // 
            // cbdText
            // 
            this.cbdText.Location = new System.Drawing.Point(232, 184);
            this.cbdText.Name = "cbdText";
            this.cbdText.Size = new System.Drawing.Size(88, 21);
            this.cbdText.TabIndex = 33;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(184, 192);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(56, 23);
            this.label20.TabIndex = 34;
            this.label20.Text = "����أ�";
            // 
            // cbzText
            // 
            this.cbzText.Location = new System.Drawing.Point(368, 184);
            this.cbzText.Name = "cbzText";
            this.cbzText.Size = new System.Drawing.Size(200, 21);
            this.cbzText.TabIndex = 35;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(320, 192);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(72, 23);
            this.label21.TabIndex = 36;
            this.label21.Text = "�����ߣ�";
            // 
            // ndsxhText
            // 
            this.ndsxhText.Location = new System.Drawing.Point(88, 232);
            this.ndsxhText.Name = "ndsxhText";
            this.ndsxhText.Size = new System.Drawing.Size(152, 21);
            this.ndsxhText.TabIndex = 37;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(16, 240);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(80, 23);
            this.label22.TabIndex = 38;
            this.label22.Text = "���˳��ţ�";
            // 
            // ckrqText
            // 
            this.ckrqText.Location = new System.Drawing.Point(88, 264);
            this.ckrqText.Name = "ckrqText";
            this.ckrqText.Size = new System.Drawing.Size(120, 21);
            this.ckrqText.TabIndex = 39;
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(16, 272);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(80, 23);
            this.label23.TabIndex = 40;
            this.label23.Text = "��������ڣ�";
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(40, 304);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(56, 23);
            this.label24.TabIndex = 41;
            this.label24.Text = "�ݲ�����";
            // 
            // gclText
            // 
            this.gclText.Location = new System.Drawing.Point(88, 296);
            this.gclText.Name = "gclText";
            this.gclText.Size = new System.Drawing.Size(48, 21);
            this.gclText.TabIndex = 42;
            // 
            // jcslText
            // 
            this.jcslText.Location = new System.Drawing.Point(312, 232);
            this.jcslText.Name = "jcslText";
            this.jcslText.Size = new System.Drawing.Size(72, 21);
            this.jcslText.TabIndex = 43;
            this.jcslText.Text = "0";
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(248, 240);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(72, 23);
            this.label25.TabIndex = 44;
            this.label25.Text = "���������";
            // 
            // jccsText
            // 
            this.jccsText.Location = new System.Drawing.Point(312, 264);
            this.jccsText.Name = "jccsText";
            this.jccsText.Size = new System.Drawing.Size(72, 21);
            this.jccsText.TabIndex = 45;
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(248, 272);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(72, 23);
            this.label26.TabIndex = 46;
            this.label26.Text = "���������";
            // 
            // jjcsText
            // 
            this.jjcsText.Location = new System.Drawing.Point(312, 296);
            this.jjcsText.Name = "jjcsText";
            this.jjcsText.Size = new System.Drawing.Size(72, 21);
            this.jjcsText.TabIndex = 47;
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(248, 304);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(80, 23);
            this.label27.TabIndex = 48;
            this.label27.Text = "�ܽ������";
            // 
            // jjbjcBox
            // 
            this.jjbjcBox.Location = new System.Drawing.Point(392, 16);
            this.jjbjcBox.Name = "jjbjcBox";
            this.jjbjcBox.Size = new System.Drawing.Size(80, 24);
            this.jjbjcBox.TabIndex = 49;
            this.jjbjcBox.Text = "�ܽ���";
            // 
            // yxgfcBox
            // 
            this.yxgfcBox.Location = new System.Drawing.Point(400, 264);
            this.yxgfcBox.Name = "yxgfcBox";
            this.yxgfcBox.Size = new System.Drawing.Size(80, 24);
            this.yxgfcBox.TabIndex = 50;
            this.yxgfcBox.Text = "��Ч�淶";
            // 
            // sxgfcBox
            // 
            this.sxgfcBox.Location = new System.Drawing.Point(392, 80);
            this.sxgfcBox.Name = "sxgfcBox";
            this.sxgfcBox.Size = new System.Drawing.Size(80, 24);
            this.sxgfcBox.TabIndex = 51;
            this.sxgfcBox.Text = "ʧЧ�淶";
            // 
            // zzText
            // 
            this.zzText.Location = new System.Drawing.Point(184, 296);
            this.zzText.Name = "zzText";
            this.zzText.Size = new System.Drawing.Size(56, 21);
            this.zzText.TabIndex = 52;
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(144, 304);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(48, 23);
            this.label28.TabIndex = 53;
            this.label28.Text = "ָ�룺";
            // 
            // nrjjText
            // 
            this.nrjjText.Location = new System.Drawing.Point(504, 232);
            this.nrjjText.Multiline = true;
            this.nrjjText.Name = "nrjjText";
            this.nrjjText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.nrjjText.Size = new System.Drawing.Size(232, 96);
            this.nrjjText.TabIndex = 55;
            this.nrjjText.TextChanged += new System.EventHandler(this.nrjjText_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.fzText);
            this.groupBox2.Controls.Add(this.ftText);
            this.groupBox2.Controls.Add(this.jgText);
            this.groupBox2.Controls.Add(this.fjText);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(576, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(168, 200);
            this.groupBox2.TabIndex = 56;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ͼ����Ϣ";
            // 
            // fzText
            // 
            this.fzText.Location = new System.Drawing.Point(64, 168);
            this.fzText.Name = "fzText";
            this.fzText.Size = new System.Drawing.Size(88, 21);
            this.fzText.TabIndex = 21;
            // 
            // fjText
            // 
            this.fjText.Location = new System.Drawing.Point(64, 104);
            this.fjText.Name = "fjText";
            this.fjText.Size = new System.Drawing.Size(88, 21);
            this.fjText.TabIndex = 15;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.butnow1);
            this.groupBox3.Controls.Add(this.sxgfcBox);
            this.groupBox3.Controls.Add(this.jjbjcBox);
            this.groupBox3.Location = new System.Drawing.Point(8, 216);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(480, 120);
            this.groupBox3.TabIndex = 57;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ͼ�����Ϣ";
            // 
            // butnow1
            // 
            this.butnow1.Location = new System.Drawing.Point(200, 56);
            this.butnow1.Name = "butnow1";
            this.butnow1.Size = new System.Drawing.Size(32, 16);
            this.butnow1.TabIndex = 52;
            this.butnow1.Text = "Now";
            this.butnow1.Click += new System.EventHandler(this.butnow1_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(496, 216);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(248, 120);
            this.groupBox4.TabIndex = 58;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "���ݼ��";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(72, 344);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 59;
            this.btnAdd.Text = "���Ӽ�¼";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(173, 344);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 60;
            this.btnEdit.Text = "�޸ļ�¼";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(274, 344);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 61;
            this.btnDel.Text = "ɾ����¼";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(568, 344);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 23);
            this.btnClose.TabIndex = 62;
            this.btnClose.Text = "��  ��";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnQue
            // 
            this.btnQue.Location = new System.Drawing.Point(375, 344);
            this.btnQue.Name = "btnQue";
            this.btnQue.Size = new System.Drawing.Size(75, 23);
            this.btnQue.TabIndex = 63;
            this.btnQue.Text = "��ѯ��¼";
            this.btnQue.Click += new System.EventHandler(this.btnQue_Click);
            // 
            // butPrn
            // 
            this.butPrn.Location = new System.Drawing.Point(472, 344);
            this.butPrn.Name = "butPrn";
            this.butPrn.Size = new System.Drawing.Size(72, 23);
            this.butPrn.TabIndex = 64;
            this.butPrn.Text = "��ӡ";
            this.butPrn.Click += new System.EventHandler(this.butPrn_Click);
            // 
            // FormBook
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(752, 374);
            this.Controls.Add(this.butPrn);
            this.Controls.Add(this.btnQue);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.jjcsText);
            this.Controls.Add(this.zzText);
            this.Controls.Add(this.jccsText);
            this.Controls.Add(this.ckrqText);
            this.Controls.Add(this.jcslText);
            this.Controls.Add(this.ndsxhText);
            this.Controls.Add(this.cbzText);
            this.Controls.Add(this.cbdText);
            this.Controls.Add(this.qtzrzText);
            this.Controls.Add(this.ygzrzText);
            this.Controls.Add(this.bbText);
            this.Controls.Add(this.gbText);
            this.Controls.Add(this.ysText);
            this.Controls.Add(this.ftmText);
            this.Controls.Add(this.blftmText);
            this.Controls.Add(this.bltmText);
            this.Controls.Add(this.smText);
            this.Controls.Add(this.nrjjText);
            this.Controls.Add(this.gclText);
            this.Controls.Add(this.cbrqText);
            this.Controls.Add(this.dyzrzText);
            this.Controls.Add(this.kbText);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.yxgfcBox);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Name = "FormBook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ͼ����ϸ��Ϣ";
            this.Load += new System.EventHandler(this.FormBook_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

	
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			string t1,t2,t3;
			int i1,i2,i3,i4;
			float f1;

			if(bookID=="0") return;
			
			if(nrjjText.Text.Length>=1800)
			{
				MessageBox.Show("���ݼ���������࣡");
				return;
			}



			//MessageBox.Show(selectC);
			booksqlComm.CommandText="SELECT ID FROM book WHERE (ID <> "+ bookID +") AND (���ֺ� = N'"+ wzhText.Text +"') AND (ͼ������ = N'"+ tsflhText.Text +"') AND (�ִκ� = N'"+ zchText.Text +"')";

			booksqlComm.Connection=sqlConn;
			booksqlComm.Connection.Open();

			sqlReader1=booksqlComm.ExecuteReader();




			if(sqlReader1.HasRows)
			{
				MessageBox.Show("���ֺš�ͼ�����š��ִκ����ظ��ĺ��룬���������ã�")
;
				sqlReader1.Close();
				return;
			}

			sqlReader1.Close();

			if ( jjbjcBox.Checked) t1="1";
			else t1="0";

			if ( yxgfcBox.Checked) t2="1";
			else t2="0";

			if ( sxgfcBox.Checked) t3="1";
			else t3="0";

			if(gclText.Text=="") i1=0;
			else i1=int.Parse(gclText.Text);

			if(jcslText.Text=="") i2=0;
			else i2=int.Parse(jcslText.Text);

			if(jccsText.Text=="") i3=0;
			else i3=int.Parse(jccsText.Text);

			if(jjcsText.Text=="") i4=0;
			else i4=int.Parse(jjcsText.Text);

			if(zzText.Text=="") f1=0;
			else f1=float.Parse(zzText.Text);

			
			booksqlComm.CommandText="UPDATE book SET ���� = N'"+smText.Text+"', �������� = N'"+bltmText.Text+"', ������ = N'"+ftmText.Text+"', ���и����� = N'"+blftmText.Text+"', ���� = N'"+gbText.Text+"', ��һ������ = N'"+dyzrzText.Text+"', ���������� = N'"+qtzrzText.Text+"', �汾 = N'"+bbText.Text+"', �й������� = N'"+ygzrzText.Text+"', ����� = N'"+cbdText.Text+"', ������ = N'"+cbzText.Text+"', �������� = N'"+cbrqText.Text+"', ҳ�� = N'"+ysText.Text+"', ���� = N'"+kbText.Text+"', ��ͼ = N'"+ftText.Text+"', �۸� = N'"+jgText.Text+"', ���� = N'"+fjText.Text+"', ��ע = N'"+fzText.Text+"', ���ֺ� = N'"+wzhText.Text.ToUpper().Trim()+"', ͼ������ = N'"+tsflhText.Text.ToUpper().Trim()+"', �ִκ� = N'"+zchText.Text.ToUpper().Trim()+"', ���˳��� = N'"+ndsxhText.Text.ToUpper().Trim()+"', ������� = '"+ckrqText.Text+"', �ݲ��� = "+ i1.ToString() +", ������� = "+ i2.ToString() +", ������� = "+i3.ToString()+", �ܽ���� = "+i4.ToString()+", �ܽ��� = "+t1+", ��Ч�淶 = "+t2+", ʧЧ�淶 = "+t3+", ָ�� = "+f1.ToString()+", ������Ҫ = N'"+nrjjText.Text+"' WHERE (ID = "+ bookID+")";
			

			booksqlComm.ExecuteNonQuery();

			sc1=wzhText.Text.ToUpper().Trim();
			sc2=tsflhText.Text.ToUpper().ToString();
			sc3=zchText.Text.ToUpper().Trim();

			fillDataSet();
		
			MessageBox.Show("��¼�޸ĳɹ���");
			booksqlComm.Connection.Close();

			isChange=true;

		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			string t1,t2,t3;
			int i1,i2,i3,i4;
			float f1;

			if(wzhText.Text=="" || tsflhText.Text=="" || zchText.Text=="") return;

			if(nrjjText.Text.Length>=1800)
			{
				MessageBox.Show("���ݼ���������࣡");
				return;
			}

			
			booksqlComm.CommandText="SELECT ID FROM book WHERE (���ֺ� = N'"+ wzhText.Text +"') AND (ͼ������ = N'"+ tsflhText.Text +"') AND (�ִκ� = N'"+ zchText.Text +"')";

			booksqlComm.Connection=sqlConn;
			booksqlComm.Connection.Open();

			sqlReader1=booksqlComm.ExecuteReader();

			if(sqlReader1.HasRows)
			{
				MessageBox.Show("���ֺš�ͼ�����š��ִκ����ظ��ĺ��룬���������ã�");
				sqlReader1.Close();
				booksqlComm.Connection.Close();
				return;
			}

			sqlReader1.Close();

			if ( jjbjcBox.Checked) t1="1";
			else t1="0";

			if ( yxgfcBox.Checked) t2="1";
			else t2="0";

			if ( sxgfcBox.Checked) t3="1";
			else t3="0";

			if(gclText.Text=="") i1=0;
			else i1=int.Parse(gclText.Text);

			if(jcslText.Text=="") i2=0;
			else i2=int.Parse(jcslText.Text);

			if(jccsText.Text=="") i3=0;
			else i3=int.Parse(jccsText.Text);

			if(jjcsText.Text=="") i4=0;
			else i4=int.Parse(jjcsText.Text);

			if(zzText.Text=="") f1=0;
			else f1=float.Parse(zzText.Text);

			
			booksqlComm.CommandText="INSERT INTO book (����, ��������, ������, ���и�����, ����, ��һ������, ����������, �汾, �й�������, �����, ������, ��������, ҳ��, ����, ��ͼ, ����, �۸�, ��ע, ���ֺ�, ͼ������, �ִκ�, ���˳���, �������, �ݲ���, �������, �������, �ܽ����, �ܽ���, ��Ч�淶, ʧЧ�淶, ָ��, ������Ҫ) VALUES (N'"+ smText.Text +"', N'"+ bltmText.Text +"', N'"+ ftmText.Text +"', N'"+ blftmText.Text +"', N'"+gbText.Text+ "', N'"+ dyzrzText.Text +"', N'"+qtzrzText.Text +"', N'"+bbText.Text +"', N'"+ ygzrzText.Text +"', N'"+ cbdText.Text+ "', N'"+ cbzText.Text +"', N'"+cbrqText.Text +"', N'"+ ysText.Text +"', N'"+ kbText.Text +"',N'"+ ftText.Text +"', N'"+ fjText.Text +"', N'"+ jgText.Text +"', N'"+ fzText.Text +"', N'"+ wzhText.Text.ToUpper().Trim() +"', N'"+ tsflhText.Text.ToUpper().Trim() +"', N'"+ zchText.Text.ToUpper().Trim() +"', N'"+ ndsxhText.Text +"', '"+ ckrqText.Text +"', "+i1.ToString()  +", "+ i2.ToString() +", "+ i3.ToString()+", "+ i4.ToString()+", "+ t1 +", "+ t2 +", "+t3+", "+ f1.ToString() +", N'"+ nrjjText.Text +"')";


			booksqlComm.ExecuteNonQuery();

			sc1=wzhText.Text.ToUpper().Trim();
			sc2=tsflhText.Text.ToUpper().ToString();
			sc3=zchText.Text.ToUpper().Trim();

			fillDataSet();
		
			MessageBox.Show("��¼��ӳɹ���");
			booksqlComm.Connection.Close();

			isChange=true;
			
		}

		private void btnDel_Click(object sender, System.EventArgs e)
		{
			if(bookID=="0") return;
			
			booksqlComm.CommandText="SELECT ID, ���� FROM book WHERE (���ֺ� = N'"+ wzhText.Text +"') AND (ͼ������ = N'"+ tsflhText.Text +"') AND (�ִκ� = N'"+ zchText.Text +"')";

			booksqlComm.Connection=sqlConn;
			booksqlComm.Connection.Open();

			sqlReader1=booksqlComm.ExecuteReader();

			if(!sqlReader1.HasRows)
			{
				MessageBox.Show("���ݿ���û�иü�¼��");
				sqlReader1.Close();
				booksqlComm.Connection.Close();
				return;
			}

			sqlReader1.Read();
			if(MessageBox.Show("�Ƿ����ɾ��ͼ��:"+sqlReader1.GetValue(1)+"?","ɾ��ͼ��",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)==DialogResult.Cancel)
			{
				return;
			}

			booksqlComm.CommandText="DELETE FROM book WHERE (ID = "+sqlReader1.GetValue(0)+")";
			sqlReader1.Close();


			booksqlComm.ExecuteNonQuery();

			sc1="";
			sc2="";
			sc3="";

			bookID="0";

			MessageBox.Show("��¼ɾ���ɹ���");
			sqlReader1.Close();
			booksqlComm.Connection.Close();

			isChange=true;

		}



		private void CreateDataAdapter()
		{
			this.sdaBook = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlConn = new System.Data.SqlClient.SqlConnection();		
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();	

			// 
			// sqlConn
			// 
			this.sqlConn.ConnectionString = strConn;
			// 
			// sdaBook
			// 
			this.sdaBook.InsertCommand = this.sqlInsertCommand1;
			this.sdaBook.SelectCommand = this.sqlSelectCommand1;
			this.sdaBook.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																							  new System.Data.Common.DataTableMapping("Table", "book", new System.Data.Common.DataColumnMapping[] {
																																																	  new System.Data.Common.DataColumnMapping("����", "����"),
																																																	  new System.Data.Common.DataColumnMapping("��������", "��������"),
																																																	  new System.Data.Common.DataColumnMapping("������", "������"),
																																																	  new System.Data.Common.DataColumnMapping("���и�����", "���и�����"),
																																																	  new System.Data.Common.DataColumnMapping("����", "����"),
																																																	  new System.Data.Common.DataColumnMapping("��һ������", "��һ������"),
																																																	  new System.Data.Common.DataColumnMapping("����������", "����������"),
																																																	  new System.Data.Common.DataColumnMapping("�汾", "�汾"),
																																																	  new System.Data.Common.DataColumnMapping("�й�������", "�й�������"),
																																																	  new System.Data.Common.DataColumnMapping("�����", "�����"),
																																																	  new System.Data.Common.DataColumnMapping("������", "������"),
																																																	  new System.Data.Common.DataColumnMapping("��������", "��������"),
																																																	  new System.Data.Common.DataColumnMapping("ҳ��", "ҳ��"),
																																																	  new System.Data.Common.DataColumnMapping("����", "����"),
																																																	  new System.Data.Common.DataColumnMapping("��ͼ", "��ͼ"),
																																																	  new System.Data.Common.DataColumnMapping("����", "����"),
																																																	  new System.Data.Common.DataColumnMapping("�۸�", "�۸�"),
																																																	  new System.Data.Common.DataColumnMapping("��ע", "��ע"),
																																																	  new System.Data.Common.DataColumnMapping("���ֺ�", "���ֺ�"),
																																																	  new System.Data.Common.DataColumnMapping("ͼ������", "ͼ������"),
																																																	  new System.Data.Common.DataColumnMapping("�ִκ�", "�ִκ�"),
																																																	  new System.Data.Common.DataColumnMapping("���˳���", "���˳���"),
																																																	  new System.Data.Common.DataColumnMapping("�������", "�������"),
																																																	  new System.Data.Common.DataColumnMapping("�ݲ���", "�ݲ���"),
																																																	  new System.Data.Common.DataColumnMapping("�������", "�������"),
																																																	  new System.Data.Common.DataColumnMapping("�������", "�������"),
																																																	  new System.Data.Common.DataColumnMapping("�ܽ����", "�ܽ����"),
																																																	  new System.Data.Common.DataColumnMapping("�ܽ���", "�ܽ���"),
																																																	  new System.Data.Common.DataColumnMapping("��Ч�淶", "��Ч�淶"),
																																																	  new System.Data.Common.DataColumnMapping("ʧЧ�淶", "ʧЧ�淶"),
																																																	  new System.Data.Common.DataColumnMapping("ָ��", "ָ��"),
																																																	  new System.Data.Common.DataColumnMapping("������Ҫ", "������Ҫ")})});
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = @"INSERT INTO book(����, ��������, ������, ���и�����, ����, ��һ������, ����������, �汾, �й�������, �����, ������, ��������, ҳ��, ����, ��ͼ, ����, �۸�, ��ע, ���ֺ�, ͼ������, �ִκ�, ���˳���, �������, �ݲ���, �������, �������, �ܽ����, �ܽ���, ��Ч�淶, ʧЧ�淶, ָ��, ������Ҫ) VALUES (@����, @��������, @������, @���и�����, @����, @��һ������, @����������, @�汾, @�й�������, @�����, @������, @��������, @ҳ��, @����, @��ͼ, @����, @�۸�, @��ע, @���ֺ�, @ͼ������, @�ִκ�, @���˳���, @�������, @�ݲ���, @�������, @�������, @�ܽ����, @�ܽ���, @��Ч�淶, @ʧЧ�淶, @ָ��, @������Ҫ); SELECT ����, ��������, ������, ���и�����, ����, ��һ������, ����������, �汾, �й�������, �����, ������, ��������, ҳ��, ����, ��ͼ, ����, �۸�, ��ע, ���ֺ�, ͼ������, �ִκ�, ���˳���, �������, �ݲ���, �������, �������, �ܽ����, �ܽ���, ��Ч�淶, ʧЧ�淶, ָ��, ������Ҫ FROM book";
			this.sqlInsertCommand1.Connection = this.sqlConn;
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@����", System.Data.SqlDbType.NVarChar, 60, "����"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@��������", System.Data.SqlDbType.NVarChar, 60, "��������"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@������", System.Data.SqlDbType.NVarChar, 60, "������"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@���и�����", System.Data.SqlDbType.NVarChar, 60, "���и�����"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@����", System.Data.SqlDbType.NVarChar, 8, "����"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@��һ������", System.Data.SqlDbType.NVarChar, 50, "��һ������"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@����������", System.Data.SqlDbType.NVarChar, 30, "����������"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@�汾", System.Data.SqlDbType.NVarChar, 4, "�汾"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@�й�������", System.Data.SqlDbType.NVarChar, 12, "�й�������"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@�����", System.Data.SqlDbType.NVarChar, 12, "�����"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@������", System.Data.SqlDbType.NVarChar, 30, "������"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@��������", System.Data.SqlDbType.NVarChar, 7, "��������"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ҳ��", System.Data.SqlDbType.NVarChar, 10, "ҳ��"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@����", System.Data.SqlDbType.NVarChar, 4, "����"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@��ͼ", System.Data.SqlDbType.NVarChar, 3, "��ͼ"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@����", System.Data.SqlDbType.NVarChar, 18, "����"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@�۸�", System.Data.SqlDbType.NVarChar, 9, "�۸�"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@��ע", System.Data.SqlDbType.NVarChar, 10, "��ע"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@���ֺ�", System.Data.SqlDbType.NVarChar, 1, "���ֺ�"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ͼ������", System.Data.SqlDbType.NVarChar, 8, "ͼ������"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@�ִκ�", System.Data.SqlDbType.NVarChar, 4, "�ִκ�"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@���˳���", System.Data.SqlDbType.NVarChar, 20, "���˳���"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@�������", System.Data.SqlDbType.DateTime, 4, "�������"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@�ݲ���", System.Data.SqlDbType.Float, 8, "�ݲ���"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@�������", System.Data.SqlDbType.Float, 8, "�������"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@�������", System.Data.SqlDbType.Float, 8, "�������"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@�ܽ����", System.Data.SqlDbType.Float, 8, "�ܽ����"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@�ܽ���", System.Data.SqlDbType.Bit, 1, "�ܽ���"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@��Ч�淶", System.Data.SqlDbType.Bit, 1, "��Ч�淶"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ʧЧ�淶", System.Data.SqlDbType.Bit, 1, "ʧЧ�淶"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ָ��", System.Data.SqlDbType.Float, 8, "ָ��"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@������Ҫ", System.Data.SqlDbType.NVarChar, 1200, "������Ҫ"));
			// 
			// sqlSelectCommand1
			// 
			selectC="SELECT ID, ����, ��������, ������, ���и�����, ����, ��һ������, ����������, �汾, �й�������, �����, ������, ��������, ҳ��, ����," +
				" ��ͼ, ����, �۸�, ��ע, ���ֺ�, ͼ������, �ִκ�, ���˳���, �������, �ݲ���, �������, �������, �ܽ����, �ܽ���, ��Ч�淶" +
				", ʧЧ�淶, ָ��, ������Ҫ FROM book";
			
			if (sc1!="")
			{
				selectC=selectC+" WHERE ���ֺ�='"+sc1+"' AND ͼ������='"+sc2+"' AND �ִκ�='"+sc3+"'";
			}


			this.sqlSelectCommand1.CommandText = selectC;

			


			this.sqlSelectCommand1.Connection = this.sqlConn;
		}


		private void CreateDataSet()
		{
			System.Data.DataRow row;

			this.dsformBook1 = new System.Data.DataSet("dsformBook1");
			
			this.dsformBook1.DataSetName = "dsfBook";
			this.dsformBook1.Locale = new System.Globalization.CultureInfo("zh-CN");
			sdaBook.Fill(dsformBook1,"book");

			row=dsformBook1.Tables["book"].Rows[0];

			bookID=row["ID"].ToString();

			//MessageBox.Show("bookid="+bookID);

			
		}

		private void BindControls()
		{
			
			zchText.DataBindings.Add("Text",dsformBook1.Tables["book"],"�ִκ�");
			tsflhText.DataBindings.Add("Text",dsformBook1.Tables["book"],"ͼ������");
			wzhText.DataBindings.Add("Text",dsformBook1.Tables["book"],"���ֺ�");
			smText.DataBindings.Add("Text",dsformBook1.Tables["book"],"����");
			bltmText.DataBindings.Add("Text",dsformBook1.Tables["book"],"��������");
			
			ftmText.DataBindings.Add("Text",dsformBook1.Tables["book"],"������");
			blftmText.DataBindings.Add("Text",dsformBook1.Tables["book"],"���и�����");
			ysText.DataBindings.Add("Text",dsformBook1.Tables["book"],"ҳ��");
			kbText.DataBindings.Add("Text",dsformBook1.Tables["book"],"����");
			ftText.DataBindings.Add("Text",dsformBook1.Tables["book"],"��ͼ");
			jgText.DataBindings.Add("Text",dsformBook1.Tables["book"],"�۸�");
			gbText.DataBindings.Add("Text",dsformBook1.Tables["book"],"����");
			dyzrzText.DataBindings.Add("Text",dsformBook1.Tables["book"],"��һ������");
			qtzrzText.DataBindings.Add("Text",dsformBook1.Tables["book"],"����������");
			bbText.DataBindings.Add("Text",dsformBook1.Tables["book"],"�汾");
			ygzrzText.DataBindings.Add("Text",dsformBook1.Tables["book"],"�й�������");
			cbrqText.DataBindings.Add("Text",dsformBook1.Tables["book"],"��������");
			cbdText.DataBindings.Add("Text",dsformBook1.Tables["book"],"�����");
			cbzText.DataBindings.Add("Text",dsformBook1.Tables["book"],"������");
			ndsxhText.DataBindings.Add("Text",dsformBook1.Tables["book"],"���˳���");
			ckrqText.DataBindings.Add("Text",dsformBook1.Tables["book"],"�������");
			gclText.DataBindings.Add("Text",dsformBook1.Tables["book"],"�ݲ���");
			jcslText.DataBindings.Add("Text",dsformBook1.Tables["book"],"�������");
			jccsText.DataBindings.Add("Text",dsformBook1.Tables["book"],"�������");
			jjcsText.DataBindings.Add("Text",dsformBook1.Tables["book"],"�ܽ����");
			jjbjcBox.DataBindings.Add("Checked",dsformBook1.Tables["book"],"�ܽ���");
			yxgfcBox.DataBindings.Add("Checked",dsformBook1.Tables["book"],"��Ч�淶");
			sxgfcBox.DataBindings.Add("Checked",dsformBook1.Tables["book"],"ʧЧ�淶");
			zzText.DataBindings.Add("Text",dsformBook1.Tables["book"],"ָ��");
			nrjjText.DataBindings.Add("Text",dsformBook1.Tables["book"],"������Ҫ");
			fzText.DataBindings.Add("Text",dsformBook1.Tables["book"],"��ע");
			fjText.DataBindings.Add("Text",dsformBook1.Tables["book"],"����");

			cm=(CurrencyManager)this.BindingContext[dsformBook1.Tables["book"]];
			cm.Position=2;
		}

		private void FormBook_Load(object sender, System.EventArgs e)
		{
			if(sc1!="")
			{
				CreateDataAdapter();
				CreateDataSet();
				BindControls();
			}
			else
			{
				CreateDataAdapter();
				CreateDataSet();
				BindControls();
				bookID="0";

				this.wzhText.Text  ="";
				this.bbText.Text="";
				this.blftmText.Text="";
				this.bltmText.Text="";
				this.cbdText.Text="";
				this.cbrqText.Text="";
				this.cbzText.Text="";
				this.ckrqText.Text="";
				this.dyzrzText.Text="";
				this.fjText.Text="";
				this.ftmText.Text="";
				this.ftText.Text="";
				this.fzText.Text="";
				this.gbText.Text="";
				this.gclText.Text="";
				this.jccsText.Text="";
				this.jcslText.Text="";
				this.jgText.Text="";
				//this.jjbjcBox.Text="";
				this.jjcsText.Text="";
				this.kbText.Text="";
				this.ndsxhText.Text="";
				this.nrjjText.Text="";
				this.qtzrzText.Text="";
				this.smText.Text="";
				this.tsflhText.Text="";
				this.ygzrzText.Text="";
				this.ysText.Text="";
				//this.yxgfcBox.Text="";
				this.zchText.Text="";
				this.zzText.Text="";
				

			}
			isChange=false;
			
		}

		private void btnQue_Click(object sender, System.EventArgs e)
		{
			bookquery bookq=new bookquery();
			bookq.strConn =strConn;

            bookq.wzhtb.Text = wzhText.Text;
            bookq.zchtb.Text = zchText.Text;
            bookq.tsflhtb.Text = tsflhText.Text;

			bookq.ShowDialog(this);
			if (bookq.formload==1)
			{
				sc1=bookq.s1;sc2=bookq.s2;sc3=bookq.s3;

				fillDataSet();
			}

		}


		private void fillDataSet()
		{

			selectC="SELECT ID, ����, ��������, ������, ���и�����, ����, ��һ������, ����������, �汾, �й�������, �����, ������, ��������, ҳ��, ����," +
				" ��ͼ, ����, �۸�, ��ע, ���ֺ�, ͼ������, �ִκ�, ���˳���, �������, �ݲ���, �������, �������, �ܽ����, �ܽ���, ��Ч�淶" +
				", ʧЧ�淶, ָ��, ������Ҫ FROM book";
			
			if (sc1!="")
			{
				selectC=selectC+" WHERE ���ֺ�='"+sc1+"' AND ͼ������='"+sc2+"' AND �ִκ�='"+sc3+"'";
			}


			this.sqlSelectCommand1.CommandText = selectC;
			this.sqlSelectCommand1.Connection = this.sqlConn;
			dsformBook1.Clear();
			sdaBook.Fill(dsformBook1,"book");
				
			System.Data.DataRow row;
			row=dsformBook1.Tables["book"].Rows[0];
			bookID=row["ID"].ToString();

		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void butnow1_Click(object sender, System.EventArgs e)
		{
			ckrqText.Text=System.DateTime.Now.ToString();
		}

		private void butPrn_Click(object sender, System.EventArgs e)
		{
			MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel ;
			DialogResult result;
			if(wzhText.Text.Trim().Equals ("") || tsflhText.Text.Trim().Equals ("") || zchText.Text.Trim().Equals ("")) 
			{
				MessageBox.Show("���ֺţ�ͼ�����ţ��ִκ���Ϣ��ȫ�����ܴ�ӡ��");

			}
			else
			{
				result = MessageBox.Show("��ӡ�����밴<��>,�������Ӵ�ӡ�밴<��>","��ӡ��ʾ",buttons);

				if(result == DialogResult.Yes)
				{
					PrintRepairCode PRC=new PrintRepairCode(wzhText.Text .Trim (),tsflhText.Text .Trim (),zchText.Text .Trim ());
					PRC.ShowDialog ();

				}
				if(result==DialogResult.No )
				{
					PrintBarCode temp=new PrintBarCode(wzhText.Text.Trim(),tsflhText.Text.Trim(),zchText.Text.Trim(),ndsxhText.Text.Trim(),gclText.Text.Trim());//(���ֺ�(1),ͼ������(8),�ִκ�(4),���ݲ��� 20060605 ��ӹݲ�����
					temp.ShowDialog ();
				}
			}

		}

		private void nrjjText_TextChanged(object sender, System.EventArgs e)
		{
		
		}




	}
}
