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
		string connStr;//���ݿ������ַ���
		public  string BookName;//����
		public string ID="";//book�����ڲ�ר�ú�
		public string WZH;//���ֺ�
		public string TSFLH;//ͼ������
		public string ZCH;//�ִκ�
		public string NDSXH;//���˳���
		public string BookLocationId;// ��λ���

		public DataBaseBook()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
	
		//����ʱ�õ����ݿ������ַ���
		public DataBaseBook(string CnnStr)
		{
			this.connStr =CnnStr.Trim();
		}
	
		
		//�������ֺ�,ͼ�����ţ��ִκŲ���Book���еļ�¼
		public int getDataBaseBook(string wzh,string tsflh,string zch)
		{
			this.WZH=wzh.Trim();
			this.TSFLH=tsflh.Trim();
			this.ZCH=zch.Trim();
			SqlConnection conn =new SqlConnection (this.connStr .Trim ());
			SqlCommand cmd=new SqlCommand("select ID,����,���˳��� from book where ���ֺ�=@WZH and ͼ������=@TSFLH and �ִκ�=@ZCH",conn);
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
					this.BookName=DR["����"].ToString().Trim ();
					this.ID=DR["ID"].ToString().Trim ();
					this.NDSXH=DR["���˳���"].ToString ().Trim ();

				}
				conn.Close ();
				return 1;//1����ɹ�
			}
			catch
			{
				return 0;//0�������
			}

		}
	
	


	}

	/// <summary>
	/// Config.ini�ļ���д��
	/// </summary>
	public class IniFile
	{

		public string path;    //INI�ļ���

		[DllImport("kernel32")]

		private static extern long WritePrivateProfileString(string section,string key,string val,string filePath);

		[DllImport("kernel32")]

		private static extern int GetPrivateProfileString(string section,string key,string def,StringBuilder retVal,int size,string filePath);

		//������дINI�ļ���API����

     

		public IniFile(string INIPath)

		{

			path = INIPath;

		}

		//��Ĺ��캯��������INI�ļ���

		public void IniWriteValue(string Section,string Key,string Value)

		{

			WritePrivateProfileString(Section,Key,Value,this.path);

		}

		//дINI�ļ�

         

		public string IniReadValue(string Section,string Key)

		{

			StringBuilder temp = new StringBuilder(255);

			int i = GetPrivateProfileString(Section,Key,"",temp,255,this.path);

			return temp.ToString();

		}

		//��ȡINI�ļ�ָ��

	}

	

	public class DataBookList
	{
		public DataBookList()
		{
			try
			{
				string Path;
				Path=Directory.GetCurrentDirectory().ToString()+"\\Config.ini";
				//�ж�Config.ini�ļ��Ƿ����
				if(File.Exists(Path))
				{
					//����Config.ini�ļ��еĸ�����
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
		public string WZH="";//���ֺ�
		public  string TSFLH="";//ͼ������
		public  string ZCH="";//�ִκ�
		public  string BookName="";//����

		private string BarCode="";//������
		
		
		//�õ����ݿ������ַ���
		public DataBookList(string cnn)
		{
			this.Conn =cnn.Trim ();
		}
		
		public void  GetDataBookList(string barcode)
		{
			try
			{
				barcode=this.ReplaceKongGe (barcode);//�����ַ���ȥ�ո�
				SqlConnection connb =new SqlConnection (this.Conn .Trim ());
				SqlCommand cmd=new SqlCommand ("select ����,���ֺ�,ͼ������,�ִκ� from ͼ����ϸ where Barcode='"+barcode.Trim ()+"'",connb);
				SqlDataReader dr;
				connb.Open ();
				dr=cmd.ExecuteReader ();
				while(dr.Read ())
				{
					this.BookName=dr["����"].ToString ();
					this.WZH =dr["���ֺ�"].ToString ();
					this.TSFLH =dr["ͼ������"].ToString ();
					this.ZCH =dr["�ִκ�"].ToString ();
				}
				connb.Close ();

			}
			catch{}
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



		//�޸ļܺ�
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