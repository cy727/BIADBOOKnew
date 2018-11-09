using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.Data.OracleClient;

namespace BIADBOOK
{
	/// <summary>
	/// FormQue 的摘要说明。
	/// </summary>
	public class FormQue : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox wzhTB;
		private System.Windows.Forms.Label tsflhLB;
		private System.Windows.Forms.TextBox tsflhTB;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button bqbtn;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage bookTP1;
		private System.Windows.Forms.TabPage nameTP1;
		private System.Windows.Forms.TextBox isoTB;
		private System.Windows.Forms.Button pqbtn;
		public string strConn,strhrConn;
        //public string strConn, OracleconnString;
		private System.Data.SqlClient.SqlConnection sqlConn;
		private System.Data.SqlClient.SqlCommand sqlComm;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		private System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdap;
		private System.Data.DataSet bookdSet;
		private System.Data.DataView dataView1;
		private System.Windows.Forms.TreeView booktv;
		private System.Windows.Forms.TextBox zchTB;
		private System.Data.SqlClient.SqlDataReader sqldr;
        private System.Data.SqlClient.SqlConnection sqlhrConn;
        private System.Data.SqlClient.SqlCommand sqlhrComm;
		private System.Windows.Forms.Button btnclose;
		private System.Windows.Forms.DataGrid bookDG;
		private DataView dv;
		private System.Windows.Forms.TabPage allTP1;
		private System.Windows.Forms.Button allbtn;
		private System.Windows.Forms.Button maturebtn;
		private System.Windows.Forms.Button pmbtn;
		private System.Windows.Forms.Button bmbtn;
		private System.Windows.Forms.TextBox nmTB;
		private System.Windows.Forms.Label label4;

        private OracleConnection OracleConn = new OracleConnection();
        private OracleCommand OracleComm;
        private OracleDataReader odr;


		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormQue()
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
            this.wzhTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tsflhLB = new System.Windows.Forms.Label();
            this.tsflhTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.zchTB = new System.Windows.Forms.TextBox();
            this.bqbtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.bookTP1 = new System.Windows.Forms.TabPage();
            this.bmbtn = new System.Windows.Forms.Button();
            this.nameTP1 = new System.Windows.Forms.TabPage();
            this.nmTB = new System.Windows.Forms.TextBox();
            this.pmbtn = new System.Windows.Forms.Button();
            this.pqbtn = new System.Windows.Forms.Button();
            this.isoTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.allTP1 = new System.Windows.Forms.TabPage();
            this.maturebtn = new System.Windows.Forms.Button();
            this.allbtn = new System.Windows.Forms.Button();
            this.bookDG = new System.Windows.Forms.DataGrid();
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.sqlComm = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlDataAdap = new System.Data.SqlClient.SqlDataAdapter();
            this.bookdSet = new System.Data.DataSet();
            this.dataView1 = new System.Data.DataView();
            this.booktv = new System.Windows.Forms.TreeView();
            this.sqlhrConn = new System.Data.SqlClient.SqlConnection();
            this.sqlhrComm = new System.Data.SqlClient.SqlCommand();
            this.btnclose = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.bookTP1.SuspendLayout();
            this.nameTP1.SuspendLayout();
            this.allTP1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bookDG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookdSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataView1)).BeginInit();
            this.SuspendLayout();
            // 
            // wzhTB
            // 
            this.wzhTB.Location = new System.Drawing.Point(56, 8);
            this.wzhTB.Name = "wzhTB";
            this.wzhTB.Size = new System.Drawing.Size(40, 21);
            this.wzhTB.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "文种号：";
            // 
            // tsflhLB
            // 
            this.tsflhLB.Location = new System.Drawing.Point(104, 16);
            this.tsflhLB.Name = "tsflhLB";
            this.tsflhLB.Size = new System.Drawing.Size(80, 16);
            this.tsflhLB.TabIndex = 2;
            this.tsflhLB.Text = "图书分类号：";
            // 
            // tsflhTB
            // 
            this.tsflhTB.Location = new System.Drawing.Point(176, 8);
            this.tsflhTB.Name = "tsflhTB";
            this.tsflhTB.Size = new System.Drawing.Size(72, 21);
            this.tsflhTB.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(256, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "种次号：";
            // 
            // zchTB
            // 
            this.zchTB.Location = new System.Drawing.Point(304, 8);
            this.zchTB.Name = "zchTB";
            this.zchTB.Size = new System.Drawing.Size(64, 21);
            this.zchTB.TabIndex = 5;
            // 
            // bqbtn
            // 
            this.bqbtn.Location = new System.Drawing.Point(376, 8);
            this.bqbtn.Name = "bqbtn";
            this.bqbtn.Size = new System.Drawing.Size(56, 23);
            this.bqbtn.TabIndex = 6;
            this.bqbtn.Text = "查 询";
            this.bqbtn.Click += new System.EventHandler(this.bqbtn_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "ISO人员编号：";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.bookTP1);
            this.tabControl1.Controls.Add(this.nameTP1);
            this.tabControl1.Controls.Add(this.allTP1);
            this.tabControl1.Location = new System.Drawing.Point(8, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(636, 64);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // bookTP1
            // 
            this.bookTP1.Controls.Add(this.bmbtn);
            this.bookTP1.Controls.Add(this.wzhTB);
            this.bookTP1.Controls.Add(this.label1);
            this.bookTP1.Controls.Add(this.tsflhTB);
            this.bookTP1.Controls.Add(this.tsflhLB);
            this.bookTP1.Controls.Add(this.zchTB);
            this.bookTP1.Controls.Add(this.label2);
            this.bookTP1.Controls.Add(this.bqbtn);
            this.bookTP1.Location = new System.Drawing.Point(4, 22);
            this.bookTP1.Name = "bookTP1";
            this.bookTP1.Size = new System.Drawing.Size(632, 38);
            this.bookTP1.TabIndex = 0;
            this.bookTP1.Text = "查询未还图书";
            // 
            // bmbtn
            // 
            this.bmbtn.Location = new System.Drawing.Point(448, 8);
            this.bmbtn.Name = "bmbtn";
            this.bmbtn.Size = new System.Drawing.Size(88, 23);
            this.bmbtn.TabIndex = 7;
            this.bmbtn.Text = "查询到期图书";
            this.bmbtn.Click += new System.EventHandler(this.bmbtn_Click);
            // 
            // nameTP1
            // 
            this.nameTP1.Controls.Add(this.nmTB);
            this.nameTP1.Controls.Add(this.pmbtn);
            this.nameTP1.Controls.Add(this.pqbtn);
            this.nameTP1.Controls.Add(this.isoTB);
            this.nameTP1.Controls.Add(this.label3);
            this.nameTP1.Controls.Add(this.label4);
            this.nameTP1.Location = new System.Drawing.Point(4, 22);
            this.nameTP1.Name = "nameTP1";
            this.nameTP1.Size = new System.Drawing.Size(632, 38);
            this.nameTP1.TabIndex = 1;
            this.nameTP1.Text = "查询未还书人员";
            // 
            // nmTB
            // 
            this.nmTB.Location = new System.Drawing.Point(256, 8);
            this.nmTB.Name = "nmTB";
            this.nmTB.Size = new System.Drawing.Size(100, 21);
            this.nmTB.TabIndex = 5;
            // 
            // pmbtn
            // 
            this.pmbtn.Location = new System.Drawing.Point(448, 8);
            this.pmbtn.Name = "pmbtn";
            this.pmbtn.Size = new System.Drawing.Size(88, 23);
            this.pmbtn.TabIndex = 4;
            this.pmbtn.Text = "查询到期图书";
            this.pmbtn.Click += new System.EventHandler(this.pmbtn_Click);
            // 
            // pqbtn
            // 
            this.pqbtn.Location = new System.Drawing.Point(360, 8);
            this.pqbtn.Name = "pqbtn";
            this.pqbtn.Size = new System.Drawing.Size(75, 23);
            this.pqbtn.TabIndex = 3;
            this.pqbtn.Text = "查 询";
            this.pqbtn.Click += new System.EventHandler(this.pqbtn_Click);
            // 
            // isoTB
            // 
            this.isoTB.Location = new System.Drawing.Point(104, 8);
            this.isoTB.Name = "isoTB";
            this.isoTB.Size = new System.Drawing.Size(100, 21);
            this.isoTB.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(216, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "姓名：";
            // 
            // allTP1
            // 
            this.allTP1.Controls.Add(this.maturebtn);
            this.allTP1.Controls.Add(this.allbtn);
            this.allTP1.Location = new System.Drawing.Point(4, 22);
            this.allTP1.Name = "allTP1";
            this.allTP1.Size = new System.Drawing.Size(628, 38);
            this.allTP1.TabIndex = 2;
            this.allTP1.Text = "查询所有图书";
            // 
            // maturebtn
            // 
            this.maturebtn.Location = new System.Drawing.Point(264, 8);
            this.maturebtn.Name = "maturebtn";
            this.maturebtn.Size = new System.Drawing.Size(240, 23);
            this.maturebtn.TabIndex = 1;
            this.maturebtn.Text = "查询所有到期图书";
            this.maturebtn.Click += new System.EventHandler(this.maturebtn_Click_1);
            // 
            // allbtn
            // 
            this.allbtn.Location = new System.Drawing.Point(32, 8);
            this.allbtn.Name = "allbtn";
            this.allbtn.Size = new System.Drawing.Size(200, 23);
            this.allbtn.TabIndex = 0;
            this.allbtn.Text = "查询所有未还图书";
            this.allbtn.Click += new System.EventHandler(this.allbtn_Click);
            // 
            // bookDG
            // 
            this.bookDG.CaptionText = "查询结果";
            this.bookDG.DataMember = "";
            this.bookDG.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.bookDG.Location = new System.Drawing.Point(8, 184);
            this.bookDG.Name = "bookDG";
            this.bookDG.ReadOnly = true;
            this.bookDG.Size = new System.Drawing.Size(636, 304);
            this.bookDG.TabIndex = 3;
            // 
            // sqlConn
            // 
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqlDataAdap
            // 
            this.sqlDataAdap.DeleteCommand = this.sqlDeleteCommand1;
            this.sqlDataAdap.InsertCommand = this.sqlInsertCommand1;
            this.sqlDataAdap.SelectCommand = this.sqlSelectCommand1;
            this.sqlDataAdap.UpdateCommand = this.sqlUpdateCommand1;
            // 
            // bookdSet
            // 
            this.bookdSet.DataSetName = "NewDataSet";
            this.bookdSet.Locale = new System.Globalization.CultureInfo("zh-CN");
            // 
            // booktv
            // 
            this.booktv.Location = new System.Drawing.Point(8, 80);
            this.booktv.Name = "booktv";
            this.booktv.Size = new System.Drawing.Size(636, 96);
            this.booktv.TabIndex = 4;
            // 
            // sqlhrConn
            // 
            this.sqlhrConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(249, 491);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 23);
            this.btnclose.TabIndex = 5;
            this.btnclose.Text = "关  闭";
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // FormQue
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(648, 526);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.booktv);
            this.Controls.Add(this.bookDG);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormQue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图书查询";
            this.Load += new System.EventHandler(this.FormQue_Load);
            this.tabControl1.ResumeLayout(false);
            this.bookTP1.ResumeLayout(false);
            this.bookTP1.PerformLayout();
            this.nameTP1.ResumeLayout(false);
            this.nameTP1.PerformLayout();
            this.allTP1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bookDG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookdSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataView1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void bqbtn_Click(object sender, System.EventArgs e)
		{

			int rowCnt,i;
			DataTable bookTable;
			DataRow row;
			string s1;

			if(wzhTB.Text.Trim()=="" || tsflhTB.Text.Trim()=="" || zchTB.Text.Trim()=="")
			{
				return;
			}

			DataTableCollection tablesCol = bookdSet.Tables;
			if (tablesCol.Contains("book") && tablesCol.CanRemove(tablesCol["book"])) 
				tablesCol.Remove("book");
			

			sqlComm.CommandText="SELECT ID, 书名, 第一责任者, 出版者, 借出书量, 借出次数, 馆藏量 FROM book WHERE (文种号 = N'"+wzhTB.Text.Trim().ToUpper()+"') AND (图书分类号 = N'"+tsflhTB.Text.Trim().ToUpper()+"') AND (种次号 = N'"+zchTB.Text.Trim().ToUpper()+"')";

			sqlConn.Open();
			sqldr=sqlComm.ExecuteReader();

			if(sqldr.Read())
			{

				booktv.BeginUpdate();
				booktv.Nodes.Clear();

				TreeNode rootNode= new TreeNode("图书信息");
				booktv.Nodes.Add(rootNode);

				TreeNode tnBook1 = new TreeNode("书名："+sqldr.GetValue(1).ToString());
				rootNode.Nodes.Add(tnBook1);
				TreeNode tnBook2 = new TreeNode("第一责任者："+sqldr.GetValue(2).ToString());
				rootNode.Nodes.Add(tnBook2);
				TreeNode tnBook3 = new TreeNode("出版者："+sqldr.GetValue(3).ToString());
				rootNode.Nodes.Add(tnBook3);
				TreeNode tnBook4 = new TreeNode("借出书量："+sqldr.GetValue(4).ToString()+"  借出次数："+sqldr.GetValue(5).ToString()+"  馆藏量："+sqldr.GetValue(6).ToString());
				rootNode.Nodes.Add(tnBook4);
				
				booktv.EndUpdate();
				rootNode.Expand();

				sqldr.Close();
				sqlConn.Close();

				sqlComm.CommandText="SELECT 借出时间, 电话, Ecode AS ISO编号,副本,中文姓名 FROM borrow WHERE (文种号 = N'"+wzhTB.Text.Trim().ToUpper()+"') AND (图书分类号 = N'"+tsflhTB.Text.Trim().ToUpper()+"') AND (种次号 = N'"+zchTB.Text.Trim().ToUpper()+"') AND (实际归还时间 IS NULL)";

				sqlDataAdap.SelectCommand=sqlComm;
				sqlDataAdap.Fill(bookdSet,"book");

				bookDG.CaptionText="查询图书：("+wzhTB.Text.Trim().ToUpper()+" "+tsflhTB.Text.Trim().ToUpper()+" "+zchTB.Text.Trim().ToUpper()+")";

				dv.Table=bookdSet.Tables["book"];

				dv.Table.Columns.Add("姓名");
				dv.Table.Columns.Add("部门");
				

				
				for(rowCnt=0;rowCnt<dv.Table.Rows.Count;rowCnt++)
				{
					row=dv.Table.Rows[rowCnt];

					s1=row["ISO编号"].ToString().Trim();

					if(s1!="0")
						  {

                                   //sqlhrComm.CommandText="SELECT employees.ecode, employees.ecname, codeorgs.cdptname FROM employees INNER JOIN codeorgs ON employees.dept = codeorgs.dptno WHERE (employees.ecode = '"+s1+"')";

                                   //sqlhrConn.Open();
                                   //sqldr=sqlhrComm.ExecuteReader();

                                   //sqldr.Read();

					
                                   //row["姓名"]=sqldr.GetValue(1).ToString();
                                   //row["部门"]=sqldr.GetValue(2).ToString();
				
                                   //sqlhrConn.Close();
                                   //sqldr.Close();

                              OracleComm.CommandText = "select v_sys_psn.psncode, v_sys_psn.psnname, v_sys_dept.first_deptname, v_sys_dept.second_deptname, v_sys_dept.third_deptname, v_sys_psn.mobile, v_sys_psn.officephone, v_sys_corp.UNITNAME from v_sys_psn LEFT OUTER JOIN V_SYS_DEPT ON v_sys_psn.pk_deptdoc = v_sys_dept.pk_fourtdept  LEFT OUTER JOIN v_sys_corp ON v_sys_psn.PK_CORP=v_sys_corp.PK_CORP where v_sys_psn.psncode=N'" + s1.PadLeft(5, '0') + "' ";//写好想执行的Sql语句 
                                OracleConn.Open();  
                                odr = OracleComm.ExecuteReader();

                                if (odr.HasRows)
                                {
                                    odr.Read();
                                    row["姓名"]=odr.GetValue(1).ToString();
                                    row["部门"] = odr.GetValue(7).ToString() + "-" + odr.GetValue(2).ToString() + "-" + odr.GetValue(3).ToString() + "-" + odr.GetValue(4).ToString();

                                    
                                }
                                odr.Close();
                                OracleConn.Close();    


						}

				}
				this.bookDG.DataSource=dv;
			}
			else
			{
				MessageBox.Show("没有该图书！");
				sqlConn.Close();

			}

			


		}

		private void FormQue_Load(object sender, System.EventArgs e)
		{
			sqlConn.ConnectionString=strConn;
			sqlComm.Connection=sqlConn;
			//sqlhrConn.ConnectionString=strhrConn;
			//sqlhrComm.Connection=sqlhrConn;
            
            OracleConn.ConnectionString = strhrConn;
            OracleComm = OracleConn.CreateCommand();

			dv= new DataView();
			
		}

		private void btnclose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void selectchange_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			booktv.Nodes.Clear();
			dv.Table=null;
			
		
		}

		private void pqbtn_Click(object sender, System.EventArgs e)
		{
			int rowCnt,i;
			DataTable bookTable;
			DataRow row;
			string s1;

			if(isoTB.Text.Trim()=="")
			{
				return;
			}

			DataTableCollection tablesCol = bookdSet.Tables;
			if (tablesCol.Contains("book") && tablesCol.CanRemove(tablesCol["book"])) 
				tablesCol.Remove("book");

			if(isoTB.Text.Trim()=="0") //无ISO
			{
				//sqlComm.CommandText="SELECT book.ID, book.书名, book.文种号, book.图书分类号, book.种次号, borrow.副本, borrow.借出时间, borrow.归还时间, borrow.续借次数, borrow.电话, borrow.Ecode AS ISO编号, borrow.中文姓名 FROM book INNER JOIN borrow ON book.文种号 = borrow.文种号 AND book.种次号 = borrow.种次号 AND book.图书分类号 = borrow.图书分类号 WHERE (borrow.Ecode = '"+isoTB.Text.Trim()+"') AND (borrow.实际归还时间 IS NULL) AND (borrow.中文姓名 = '"+ nmTB.Text.Trim() +"')";

				sqlComm.CommandText="SELECT book.ID, book.书名, book.文种号, book.图书分类号, book.种次号, borrow.副本, borrow.借出时间, borrow.归还时间, borrow.续借次数, borrow.电话, borrow.Ecode AS ISO编号, borrow.中文姓名 FROM book INNER JOIN borrow ON book.文种号 = borrow.文种号 AND book.种次号 = borrow.种次号 AND book.图书分类号 = borrow.图书分类号 WHERE (borrow.实际归还时间 IS NULL) AND (borrow.中文姓名 = '"+ nmTB.Text.Trim() +"')";

				sqlDataAdap.SelectCommand=sqlComm;
				sqlDataAdap.Fill(bookdSet,"book");

				bookDG.CaptionText="查询人员：("+isoTB.Text.Trim().ToUpper()+")";

				dv.Table=bookdSet.Tables["book"];

				this.bookDG.DataSource=dv;
				return;
			}


            //sqlhrComm.CommandText="SELECT employees.ecode, employees.ecname, codeorgs.cdptname FROM employees INNER JOIN codeorgs ON employees.dept = codeorgs.dptno WHERE (employees.ecode = '"+isoTB.Text.Trim()+"')";

            //sqlhrConn.Open();
            //sqldr=sqlhrComm.ExecuteReader();

            OracleComm.CommandText = "select v_sys_psn.psncode, v_sys_psn.psnname, v_sys_dept.first_deptname, v_sys_dept.second_deptname, v_sys_dept.third_deptname, v_sys_psn.mobile, v_sys_psn.officephone, v_sys_corp.UNITNAME from v_sys_psn LEFT OUTER JOIN V_SYS_DEPT ON v_sys_psn.pk_deptdoc = v_sys_dept.pk_fourtdept  LEFT OUTER JOIN v_sys_corp ON v_sys_psn.PK_CORP=v_sys_corp.PK_CORP where v_sys_psn.psncode=N'" + isoTB.Text.Trim().PadLeft(5, '0') + "' ";//写好想执行的Sql语句 
            OracleConn.Open();
            odr = OracleComm.ExecuteReader();

            if (odr.Read())
			{

				booktv.BeginUpdate();
				booktv.Nodes.Clear();
				
				TreeNode rootNode1= new TreeNode("所借图书",5,5);
				booktv.Nodes.Add(rootNode1);

				TreeNode rootNode= new TreeNode("人员信息");
				booktv.Nodes.Add(rootNode);

                s1 = odr.GetValue(1).ToString();

                TreeNode tnBook1 = new TreeNode("姓名：" + odr.GetValue(1).ToString());
				rootNode.Nodes.Add(tnBook1);
                TreeNode tnBook2 = new TreeNode("部门：" + odr.GetValue(7).ToString() + "-" + odr.GetValue(2).ToString() + "-" + odr.GetValue(3).ToString() + "-" + odr.GetValue(4).ToString());
				rootNode.Nodes.Add(tnBook2);
                TreeNode tnBook3 = new TreeNode("电话：" + odr.GetValue(5).ToString() + "  " + odr.GetValue(6).ToString());
                rootNode.Nodes.Add(tnBook3);
				
				booktv.EndUpdate();
				rootNode.Expand();

				odr.Close();
                OracleConn.Close();

				sqlComm.CommandText="SELECT book.ID, book.书名, book.文种号, book.图书分类号, book.种次号, borrow.副本, borrow.借出时间, borrow.归还时间, borrow.续借次数, borrow.电话, borrow.Ecode AS ISO编号 FROM book INNER JOIN borrow ON book.文种号 = borrow.文种号 AND book.种次号 = borrow.种次号 AND book.图书分类号 = borrow.图书分类号 WHERE (borrow.Ecode = '"+isoTB.Text.Trim()+"') AND (borrow.实际归还时间 IS NULL)";

				sqlDataAdap.SelectCommand=sqlComm;
				sqlDataAdap.Fill(bookdSet,"book");

				bookDG.CaptionText="查询人员：("+isoTB.Text.Trim().ToUpper()+")";

				dv.Table=bookdSet.Tables["book"];

				this.bookDG.DataSource=dv;

			}
			else
			{
				MessageBox.Show("没有该人员！");
				OracleConn.Close();
                odr.Close();

			}

	
		}


		private void maturebtn_Click(object sender, System.EventArgs e)
		{
		
		}

		private void allbtn_Click(object sender, System.EventArgs e)
		{
						
			int rowCnt,i;
			DataTable bookTable;
			DataRow row;
			string s1;

			DataTableCollection tablesCol = bookdSet.Tables;
			if (tablesCol.Contains("book") && tablesCol.CanRemove(tablesCol["book"])) 
				tablesCol.Remove("book");


			booktv.BeginUpdate();
			booktv.Nodes.Clear();
			booktv.EndUpdate();

			sqlComm.CommandText="SELECT book.ID, book.书名, book.文种号, book.图书分类号, book.种次号, borrow.副本, borrow.借出时间,borrow.归还时间,borrow.续借次数 ,borrow.电话, borrow.Ecode AS ISO编号, borrow.中文姓名 FROM book INNER JOIN borrow ON book.文种号 = borrow.文种号 AND book.种次号 = borrow.种次号 AND book.图书分类号 = borrow.图书分类号 WHERE (borrow.实际归还时间 IS NULL) ORDER BY borrow.借出时间";

			sqlDataAdap.SelectCommand=sqlComm;
			sqlDataAdap.Fill(bookdSet,"book");

			bookDG.CaptionText="查询所有未还图书";

			dv.Table=bookdSet.Tables["book"];

			dv.Table.Columns.Add("姓名");
			dv.Table.Columns.Add("部门");

				
			for(rowCnt=0;rowCnt<dv.Table.Rows.Count;rowCnt++)
			{
				row=dv.Table.Rows[rowCnt];

				s1=row["ISO编号"].ToString().Trim();

				if(s1!="0")
				{

					//sqlhrComm.CommandText="SELECT employees.ecode, employees.ecname, codeorgs.cdptname FROM employees INNER JOIN codeorgs ON employees.dept = codeorgs.dptno WHERE (employees.ecode = '"+s1+"')";

                    //sqlhrConn.Open();
                    //sqldr=sqlhrComm.ExecuteReader();

                    //sqldr.Read();

                    //if(sqldr.HasRows)
                    //{

                    //    row["姓名"]=sqldr.GetValue(1).ToString();
                    //    row["部门"]=sqldr.GetValue(2).ToString();
                    //}

                    //sqlhrConn.Close();
                    //sqldr.Close();

                    OracleComm.CommandText = "select v_sys_psn.psncode, v_sys_psn.psnname, v_sys_dept.first_deptname, v_sys_dept.second_deptname, v_sys_dept.third_deptname, v_sys_psn.mobile, v_sys_psn.officephone, v_sys_corp.UNITNAME from v_sys_psn LEFT OUTER JOIN V_SYS_DEPT ON v_sys_psn.pk_deptdoc = v_sys_dept.pk_fourtdept  LEFT OUTER JOIN v_sys_corp ON v_sys_psn.PK_CORP=v_sys_corp.PK_CORP where v_sys_psn.psncode=N'" + s1.PadLeft(5, '0') + "' ";//写好想执行的Sql语句 
                    OracleConn.Open();
                    odr = OracleComm.ExecuteReader();

                    if (odr.HasRows)
                    {
                        odr.Read();
                        row["姓名"] = odr.GetValue(1).ToString();
                        row["部门"] = odr.GetValue(7).ToString() + "-" + odr.GetValue(2).ToString() + "-" + odr.GetValue(3).ToString() + "-" + odr.GetValue(4).ToString();
                    }
                    odr.Close();
                    OracleConn.Close();    
				}

			}
			this.bookDG.DataSource=dv;

			

		}

		private void maturebtn_Click_1(object sender, System.EventArgs e)
		{
			int rowCnt,i;
			DataTable bookTable;
			DataRow row;
			string s1;

			DataTableCollection tablesCol = bookdSet.Tables;
			if (tablesCol.Contains("book") && tablesCol.CanRemove(tablesCol["book"])) 
				tablesCol.Remove("book");


			booktv.BeginUpdate();
			booktv.Nodes.Clear();
			booktv.EndUpdate();

			sqlComm.CommandText="SELECT book.ID, book.书名, book.文种号, book.图书分类号, book.种次号,borrow.副本, borrow.借出时间,borrow.归还时间,borrow.续借次数 ,borrow.电话, borrow.Ecode AS ISO编号, borrow.中文姓名 FROM book INNER JOIN borrow ON book.文种号 = borrow.文种号 AND book.种次号 = borrow.种次号 AND book.图书分类号 = borrow.图书分类号 WHERE (borrow.实际归还时间 IS NULL) AND (borrow.归还时间 < '"+System.DateTime.Now.ToString()+"') ORDER BY borrow.借出时间";

			sqlDataAdap.SelectCommand=sqlComm;
			sqlDataAdap.Fill(bookdSet,"book");

			bookDG.CaptionText="查询所有未还图书";

			dv.Table=bookdSet.Tables["book"];

			dv.Table.Columns.Add("姓名");
			dv.Table.Columns.Add("部门");

				
			for(rowCnt=0;rowCnt<dv.Table.Rows.Count;rowCnt++)
			{
				row=dv.Table.Rows[rowCnt];

				s1=row["ISO编号"].ToString().Trim();

				if(s1!="0")
				{
                    //sqlhrComm.CommandText="SELECT employees.ecode, employees.ecname, codeorgs.cdptname FROM employees INNER JOIN codeorgs ON employees.dept = codeorgs.dptno WHERE (employees.ecode = '"+s1+"')";

                    //sqlhrConn.Open();
                    //sqldr=sqlhrComm.ExecuteReader();

                    //sqldr.Read();
					
                    //if(sqldr.HasRows)
                    //{
					
                    //    row["姓名"]=sqldr.GetValue(1).ToString();
                    //    row["部门"]=sqldr.GetValue(2).ToString();
                    //}

                    //sqlhrConn.Close();
                    //sqldr.Close();

                    OracleComm.CommandText = "select v_sys_psn.psncode, v_sys_psn.psnname, v_sys_dept.first_deptname, v_sys_dept.second_deptname, v_sys_dept.third_deptname, v_sys_psn.mobile, v_sys_psn.officephone, v_sys_corp.UNITNAME from v_sys_psn LEFT OUTER JOIN V_SYS_DEPT ON v_sys_psn.pk_deptdoc = v_sys_dept.pk_fourtdept  LEFT OUTER JOIN v_sys_corp ON v_sys_psn.PK_CORP=v_sys_corp.PK_CORP where v_sys_psn.psncode=N'" + s1.PadLeft(5, '0') + "' ";//写好想执行的Sql语句 
                    OracleConn.Open();
                    odr = OracleComm.ExecuteReader();

                    if (odr.HasRows)
                    {
                        odr.Read();
                        row["姓名"] = odr.GetValue(1).ToString();
                        row["部门"] = odr.GetValue(7).ToString() + "-" + odr.GetValue(2).ToString() + "-" + odr.GetValue(3).ToString() + "-" + odr.GetValue(4).ToString();

                        
                    }
                    odr.Close();
                    OracleConn.Close();    
				}

			}
			this.bookDG.DataSource=dv;

	
		}

		private void bmbtn_Click(object sender, System.EventArgs e)
		{
			
			int rowCnt,i;
			DataTable bookTable;
			DataRow row;
			string s1;

			if(wzhTB.Text.Trim()=="" || tsflhTB.Text.Trim()=="" || zchTB.Text.Trim()=="")
			{
				return;
			}

			DataTableCollection tablesCol = bookdSet.Tables;
			if (tablesCol.Contains("book") && tablesCol.CanRemove(tablesCol["book"])) 
				tablesCol.Remove("book");
			

			sqlComm.CommandText="SELECT ID, 书名, 第一责任者, 出版者, 借出书量, 借出次数, 馆藏量 FROM book WHERE (文种号 = N'"+wzhTB.Text.Trim().ToUpper()+"') AND (图书分类号 = N'"+tsflhTB.Text.Trim().ToUpper()+"') AND (种次号 = N'"+zchTB.Text.Trim().ToUpper()+"')";

			sqlConn.Open();
			sqldr=sqlComm.ExecuteReader();

			if(sqldr.Read())
			{

				booktv.BeginUpdate();
				booktv.Nodes.Clear();

				TreeNode rootNode= new TreeNode("图书信息");
				booktv.Nodes.Add(rootNode);

				TreeNode tnBook1 = new TreeNode("书名："+sqldr.GetValue(1).ToString());
				rootNode.Nodes.Add(tnBook1);
				TreeNode tnBook2 = new TreeNode("第一责任者："+sqldr.GetValue(2).ToString());
				rootNode.Nodes.Add(tnBook2);
				TreeNode tnBook3 = new TreeNode("出版者："+sqldr.GetValue(3).ToString());
				rootNode.Nodes.Add(tnBook3);
				TreeNode tnBook4 = new TreeNode("借出书量："+sqldr.GetValue(4).ToString()+"  借出次数："+sqldr.GetValue(5).ToString()+"  馆藏量："+sqldr.GetValue(6).ToString());
				rootNode.Nodes.Add(tnBook4);
				
				booktv.EndUpdate();
				rootNode.Expand();

				sqldr.Close();
				sqlConn.Close();

				sqlComm.CommandText="SELECT 借出时间, 归还时间,续借次数, 电话, Ecode AS ISO编号,副本,中文姓名 FROM borrow WHERE (文种号 = N'"+wzhTB.Text.Trim().ToUpper()+"') AND (图书分类号 = N'"+tsflhTB.Text.Trim().ToUpper()+"') AND (种次号 = N'"+zchTB.Text.Trim().ToUpper()+"') AND (实际归还时间 IS NULL) AND (归还时间<'"+System.DateTime.Now.ToString()+"')";

				sqlDataAdap.SelectCommand=sqlComm;
				sqlDataAdap.Fill(bookdSet,"book");

				bookDG.CaptionText="查询图书：("+wzhTB.Text.Trim().ToUpper()+" "+tsflhTB.Text.Trim().ToUpper()+" "+zchTB.Text.Trim().ToUpper()+")";

				dv.Table=bookdSet.Tables["book"];

				dv.Table.Columns.Add("姓名");
				dv.Table.Columns.Add("部门");

				
				for(rowCnt=0;rowCnt<dv.Table.Rows.Count;rowCnt++)
				{
					row=dv.Table.Rows[rowCnt];

					s1=row["ISO编号"].ToString().Trim();

					if(s1!="0")
					{

                        //sqlhrComm.CommandText="SELECT employees.ecode, employees.ecname, codeorgs.cdptname FROM employees INNER JOIN codeorgs ON employees.dept = codeorgs.dptno WHERE (employees.ecode = '"+s1+"')";

                        //sqlhrConn.Open();
                        //sqldr=sqlhrComm.ExecuteReader();

                        //sqldr.Read();

					
                        //if(sqldr.HasRows)
                        //{

                        //    row["姓名"]=sqldr.GetValue(1).ToString();
                        //    row["部门"]=sqldr.GetValue(2).ToString();
                        //}


                        //sqlhrConn.Close();
                        //sqldr.Close();

                        OracleComm.CommandText = "select v_sys_psn.psncode, v_sys_psn.psnname, v_sys_dept.first_deptname, v_sys_dept.second_deptname, v_sys_dept.third_deptname, v_sys_psn.mobile, v_sys_psn.officephone, v_sys_corp.UNITNAME from v_sys_psn LEFT OUTER JOIN V_SYS_DEPT ON v_sys_psn.pk_deptdoc = v_sys_dept.pk_fourtdept  LEFT OUTER JOIN v_sys_corp ON v_sys_psn.PK_CORP=v_sys_corp.PK_CORP where v_sys_psn.psncode=N'" + s1.PadLeft(5, '0') + "' ";//写好想执行的Sql语句 
                        OracleConn.Open();
                        odr = OracleComm.ExecuteReader();

                        if (odr.HasRows)
                        {
                            odr.Read();
                            row["姓名"] = odr.GetValue(1).ToString();
                            row["部门"] = odr.GetValue(7).ToString() + "-" + odr.GetValue(2).ToString() + "-" + odr.GetValue(3).ToString() + "-" + odr.GetValue(4).ToString();

                            
                        }
                        odr.Close();
                        OracleConn.Close();    
					}

				}
				this.bookDG.DataSource=dv;
			}
			else
			{
				MessageBox.Show("没有该图书！");
				sqlConn.Close();

			}

			

		}

		private void pmbtn_Click(object sender, System.EventArgs e)
		{
			int rowCnt,i;
			DataTable bookTable;
			DataRow row;
			string s1;

			if(isoTB.Text.Trim()=="")
			{
				return;
			}

			DataTableCollection tablesCol = bookdSet.Tables;
			if (tablesCol.Contains("book") && tablesCol.CanRemove(tablesCol["book"])) 
				tablesCol.Remove("book");

			if(isoTB.Text.Trim()=="0")
			{
				sqlComm.CommandText="SELECT book.ID, book.书名, book.文种号,  book.图书分类号, book.种次号, borrow.副本, borrow.借出时间, borrow.归还时间, borrow.续借次数, borrow.电话, borrow.Ecode AS ISO编号, borrow.中文姓名 FROM book INNER JOIN borrow ON book.文种号 = borrow.文种号 AND book.种次号 = borrow.种次号 AND book.图书分类号 = borrow.图书分类号 WHERE (borrow.Ecode = '"+isoTB.Text.Trim()+"') AND (borrow.实际归还时间 IS NULL) AND (归还时间<'"+System.DateTime.Now.ToString()+"')  AND (borrow.中文姓名 = '"+ nmTB.Text.Trim() +"')";

				sqlDataAdap.SelectCommand=sqlComm;
				sqlDataAdap.Fill(bookdSet,"book");

				bookDG.CaptionText="查询人员：("+isoTB.Text.Trim().ToUpper()+")";

				dv.Table=bookdSet.Tables["book"];

				this.bookDG.DataSource=dv;
				return;
			}

            //sqlhrComm.CommandText="SELECT employees.ecode, employees.ecname, codeorgs.cdptname FROM employees INNER JOIN codeorgs ON employees.dept = codeorgs.dptno WHERE (employees.ecode = '"+isoTB.Text.Trim()+"')";

            //sqlhrConn.Open();
            //sqldr=sqlhrComm.ExecuteReader();

            OracleComm.CommandText = "select v_sys_psn.psncode, v_sys_psn.psnname, v_sys_dept.first_deptname, v_sys_dept.second_deptname, v_sys_dept.third_deptname, v_sys_psn.mobile, v_sys_psn.officephone, v_sys_corp.UNITNAME from v_sys_psn LEFT OUTER JOIN V_SYS_DEPT ON v_sys_psn.pk_deptdoc = v_sys_dept.pk_fourtdept  LEFT OUTER JOIN v_sys_corp ON v_sys_psn.PK_CORP=v_sys_corp.PK_CORP where v_sys_psn.psncode=N'" + isoTB.Text.Trim().PadLeft(5, '0') + "' ";//写好想执行的Sql语句 
            OracleConn.Open();
            odr = OracleComm.ExecuteReader();

			if(odr.Read())
			{

				booktv.BeginUpdate();
				booktv.Nodes.Clear();
				
				TreeNode rootNode1= new TreeNode("所借图书",5,5);
				booktv.Nodes.Add(rootNode1);

				TreeNode rootNode= new TreeNode("人员信息");
				booktv.Nodes.Add(rootNode);

				s1=odr.GetValue(1).ToString();

                TreeNode tnBook1 = new TreeNode("姓名：" + odr.GetValue(1).ToString());
				rootNode.Nodes.Add(tnBook1);
                TreeNode tnBook2 = new TreeNode("部门：" + odr.GetValue(7).ToString() + "-" + odr.GetValue(2).ToString() + "-" + odr.GetValue(3).ToString() + "-" + odr.GetValue(4).ToString());
				rootNode.Nodes.Add(tnBook2);
                TreeNode tnBook3 = new TreeNode("电话：" +odr.GetValue(5).ToString() + "  "+odr.GetValue(6).ToString());
                rootNode.Nodes.Add(tnBook3);
				
				booktv.EndUpdate();
				rootNode.Expand();

                //sqldr.Close();
                //sqlhrConn.Close();
                odr.Close();
                OracleConn.Close();


				sqlComm.CommandText="SELECT book.ID, book.书名, book.文种号,  book.图书分类号, book.种次号, borrow.副本, borrow.借出时间, borrow.归还时间, borrow.续借次数, borrow.电话, borrow.Ecode AS ISO编号 FROM book INNER JOIN borrow ON book.文种号 = borrow.文种号 AND book.种次号 = borrow.种次号 AND book.图书分类号 = borrow.图书分类号 WHERE (borrow.Ecode = '"+isoTB.Text.Trim()+"') AND (borrow.实际归还时间 IS NULL) AND (归还时间<'"+System.DateTime.Now.ToString()+"')";

				sqlDataAdap.SelectCommand=sqlComm;
				sqlDataAdap.Fill(bookdSet,"book");

				bookDG.CaptionText="查询人员：("+isoTB.Text.Trim().ToUpper()+")";

				dv.Table=bookdSet.Tables["book"];

				this.bookDG.DataSource=dv;

			}
			else
			{
				MessageBox.Show("没有该人员！");
                odr.Close();
                OracleConn.Close();

			}

		}
	}
}
