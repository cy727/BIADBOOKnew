using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BIADBOOK
{
	/// <summary>
	/// frmBookListInfo 的摘要说明。
	/// </summary>
	public class frmBookListInfo : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtBookLocation;
		private System.Windows.Forms.TextBox txtBookRoom;
		private System.Windows.Forms.TextBox txtID;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private string State;
		public frmBookListInfo()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}
		frmBookLocationManager frmtemp;
		public frmBookListInfo(string Id ,string location,string room,string state, frmBookLocationManager frm)
		{
			InitializeComponent();
			this.txtID .Text =Id.Trim ();
			this.txtBookLocation .Text =location.Trim ();
			this.txtBookRoom .Text =room.Trim ();
			this.State =state.Trim ();
			frmtemp=frm;
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
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.label10 = new System.Windows.Forms.Label();
			this.txtBookLocation = new System.Windows.Forms.TextBox();
			this.txtBookRoom = new System.Windows.Forms.TextBox();
			this.txtID = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(184, 248);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 23;
			this.btnCancel.Text = "取消";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(80, 248);
			this.btnOk.Name = "btnOk";
			this.btnOk.TabIndex = 22;
			this.btnOk.Text = "保存";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// label10
			// 
			this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label10.Location = new System.Drawing.Point(24, 232);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(312, 3);
			this.label10.TabIndex = 21;
			// 
			// txtBookLocation
			// 
			this.txtBookLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtBookLocation.Location = new System.Drawing.Point(16, 104);
			this.txtBookLocation.Multiline = true;
			this.txtBookLocation.Name = "txtBookLocation";
			this.txtBookLocation.Size = new System.Drawing.Size(320, 32);
			this.txtBookLocation.TabIndex = 25;
			this.txtBookLocation.Text = "textBox3";
			this.txtBookLocation.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
			// 
			// txtBookRoom
			// 
			this.txtBookRoom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtBookRoom.Location = new System.Drawing.Point(16, 168);
			this.txtBookRoom.Multiline = true;
			this.txtBookRoom.Name = "txtBookRoom";
			this.txtBookRoom.Size = new System.Drawing.Size(320, 48);
			this.txtBookRoom.TabIndex = 26;
			this.txtBookRoom.Text = "textBox2";
			// 
			// txtID
			// 
			this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtID.Location = new System.Drawing.Point(16, 56);
			this.txtID.Name = "txtID";
			this.txtID.Size = new System.Drawing.Size(320, 21);
			this.txtID.TabIndex = 24;
			this.txtID.Text = "textBox1";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 144);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 29;
			this.label3.Text = "房间信息:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 88);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 28;
			this.label2.Text = "书架位置:";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 27;
			this.label1.Text = "架位编号:";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(120, 8);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(88, 20);
			this.label4.TabIndex = 30;
			this.label4.Text = "书架信息";
			// 
			// frmBookListInfo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(352, 282);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtBookLocation);
			this.Controls.Add(this.txtBookRoom);
			this.Controls.Add(this.txtID);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.label10);
			this.Name = "frmBookListInfo";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "书架信息";
			this.Load += new System.EventHandler(this.frmBookListInfo_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void textBox3_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void frmBookListInfo_Load(object sender, System.EventArgs e)
		{
		
		}

		private void btnOk_Click(object sender, System.EventArgs e)
		{
		
			if(this.txtID .Text.Trim ().Equals (""))
			{
				MessageBox.Show ("架位编号不能为空！");
			}else
			{
				try
				{
					if(this.State .Equals ("update"))
					{
						string sql ="update BookLocation set BookLocationInfo='"+this.txtBookLocation .Text .Trim ()+"',BookRoomInfo='"+this.txtBookRoom .Text .Trim ()+"' where BookLocationId='"+this.txtID .Text .Trim ()+"'";
						frmtemp.ExeSql (sql);
					}
					else
					{
						string sql2="insert into BookLocation (BookLocationId,BookLocationInfo,BookRoomInfo) values('"+this.txtID .Text .Trim ()+"','"+this.txtBookLocation .Text .Trim ()+"','"+this.txtBookRoom .Text .Trim ()+"')";
						frmtemp.ExeSql (sql2);
					}
				this.Close ();
				}
				catch{}
			}
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close ();
		}
	}
}
