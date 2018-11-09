using System;
using System.Data ;
using System.Data .SqlClient ;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
namespace BIADBOOK
{
	public class DataBaseBook
	{
		string connStr;//数据库连接字符串
		public  string BookName;//书名
		public string ID="";//book表中内部专用号
		public string WZH;//文种号
		public string TSFLH;//图书分类号
		public string ZCH;//种次号
		public string NDSXH;//年代顺序号
		public string BookLocationId;// 架位编号

		public DataBaseBook()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
	
		//构造时得到数据库连接字符串
		public DataBaseBook(string CnnStr)
		{
			this.connStr =CnnStr.Trim();
		}
	
		
		//根据文种号,图书分类号，种次号查找Book表中的记录
		public int getDataBaseBook(string wzh,string tsflh,string zch)
		{
			this.WZH=wzh.Trim();
			this.TSFLH=tsflh.Trim();
			this.ZCH=zch.Trim();
			SqlConnection conn =new SqlConnection (this.connStr .Trim ());
			SqlCommand cmd=new SqlCommand("select ID,书名,年代顺序号 from book where 文种号=@WZH and 图书分类号=@TSFLH and 种次号=@ZCH",conn);
			SqlDataReader DR;
			SqlParameter paraWZH=new SqlParameter ("@WZH",SqlDbType.NVarChar ,1);
			paraWZH.Value =wzh.Trim ();
			cmd.Parameters.Add(paraWZH);
				
			SqlParameter paraTSFLH=new SqlParameter ("@TSFLH",SqlDbType.NVarChar ,8);
			paraTSFLH.Value =tsflh.Trim ();
			cmd.Parameters .Add (paraTSFLH);

			SqlParameter paraZCH=new SqlParameter ("@ZCH",SqlDbType.NVarChar ,4);
			paraZCH.Value =zch.Trim ();
			cmd.Parameters .Add (paraZCH);

			try
			{
				conn.Open ();
				DR=cmd.ExecuteReader ();
				while (DR.Read ())
				{
					this.BookName=DR["书名"].ToString().Trim ();
					this.ID=DR["ID"].ToString().Trim ();
					this.NDSXH=DR["年代顺序号"].ToString ().Trim ();

				}
				conn.Close ();
				return 1;//1代表成功
			}
			catch
			{
				return 0;//0代表出错
			}

		}
	
	


	}

	/// <summary>
	/// Config.ini文件读写类
	/// </summary>
	public class IniFile
	{

		public string path;    //INI文件名

		[DllImport("kernel32")]

		private static extern long WritePrivateProfileString(string section,string key,string val,string filePath);

		[DllImport("kernel32")]

		private static extern int GetPrivateProfileString(string section,string key,string def,StringBuilder retVal,int size,string filePath);

		//声明读写INI文件的API函数

     

		public IniFile(string INIPath)

		{

			path = INIPath;

		}

		//类的构造函数，传递INI文件名

		public void IniWriteValue(string Section,string Key,string Value)

		{

			WritePrivateProfileString(Section,Key,Value,this.path);

		}

		//写INI文件

         

		public string IniReadValue(string Section,string Key)

		{

			StringBuilder temp = new StringBuilder(255);

			int i = GetPrivateProfileString(Section,Key,"",temp,255,this.path);

			return temp.ToString();

		}

		//读取INI文件指定

	}

	

	public class DataBookList
	{
		public DataBookList()
		{
			try
			{
				string Path;
				Path=Directory.GetCurrentDirectory().ToString()+"\\Config.ini";
				//判断Config.ini文件是否存在
				if(File.Exists(Path))
				{
					//截入Config.ini文件中的各参数
					IniFile ini = new IniFile(Path);
					//[DataBase]ConnectionString
					if(ini.IniReadValue("DataBase","ConnectionString")!="")
					{ 
						this.Conn=ini.IniReadValue("DataBase","ConnectionString").Trim(); 
					}
				}
			}
			catch{}
		}
		private string Conn;
		public string WZH="";//文种号
		public  string TSFLH="";//图书分类号
		public  string ZCH="";//种次号
		public  string BookName="";//书名

		private string BarCode="";//条形码
		
		
		//得到数据库连接字符串
		public DataBookList(string cnn)
		{
			this.Conn =cnn.Trim ();
		}
		
		public void  GetDataBookList(string barcode)
		{
			try
			{
				barcode=this.ReplaceKongGe (barcode);//调用字符串去空格
				SqlConnection connb =new SqlConnection (this.Conn .Trim ());
				SqlCommand cmd=new SqlCommand ("select 书名,文种号,图书分类号,种次号 from 图书明细 where Barcode='"+barcode.Trim ()+"'",connb);
				SqlDataReader dr;
				connb.Open ();
				dr=cmd.ExecuteReader ();
				while(dr.Read ())
				{
					this.BookName=dr["书名"].ToString ();
					this.WZH =dr["文种号"].ToString ();
					this.TSFLH =dr["图书分类号"].ToString ();
					this.ZCH =dr["种次号"].ToString ();
				}
				connb.Close ();

			}
			catch{}
		}
		// 去除字符串中的空格
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



		//修改架号
		public void updateBooklist(string barcode,string booklist)
		{
			try
			{
				SqlConnection connu=new SqlConnection (this.Conn .Trim ());
				SqlCommand cmd=new SqlCommand ("update booklist set booklocation='"+booklist.Trim ()+"' where barcode='"+barcode.Trim ()+"'",connu);
				connu.Open ();
				cmd.ExecuteNonQuery ();
				connu.Close ();

			}
			catch{}
		}

	}

}