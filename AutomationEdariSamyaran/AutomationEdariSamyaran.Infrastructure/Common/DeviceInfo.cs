using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;

/////////////


namespace AutomationEdariSamyaran.Infrastructure.Common
{
    public class DeviceInfo
    {
        public static string ServerName;
        public static string ServerId;
        public static string ServerPass;
        public static string DatabaseName;
        public DeviceInfo(string _ServerName, string _ServerId, string _ServerPass, string _DatabaseName)
        {
            ServerName = _ServerName;
            ServerId = _ServerId;
            ServerPass = _ServerPass;
            DatabaseName = _DatabaseName;
        }

        //public static DataTable ReadExcel(string fileName, string fileExt)
        //{

        //    SqlConnection cnn = new SqlConnection();
        //    SqlCommand cmd = new SqlCommand();
        //    SqlDataAdapter da = new SqlDataAdapter();
        //    DataTable dt = new DataTable();
        //    /////////////////////

        //    if (fileExt.CompareTo(".xls") == 0)
        //    {
        //        cmd.CommandText = @"provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ServerName + ";Initial Catalog=" + DatabaseName + ";User ID=" + ServerId + ";Password=" + DeviceInfo.Decrypt(ServerPass) + "; Extended Properties='Excel 8.0;HRD=Yes;IMEX=1';"; //for below excel 2007
        //        cnn.Open();
        //        cmd.Connection = cnn;
        //    }

        //    else
        //    {
        //        cmd.CommandText = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ServerName + ";Initial Catalog=" + DatabaseName + ";User ID=" + ServerId + ";Password=" + DeviceInfo.Decrypt(ServerPass) + ";Extended Properties='Excel 12.0;HDR=NO';"; //for above excel 2007 
        //        cnn.Open();
        //        cmd.Connection = cnn;
        //    }
        //    return dt;

        //}

        /*public static  String getCPUID()
         {
         String cpuid = "";
         try
          {
             ManagementObjectSearcher mbs = new ManagementObjectSearcher("Select ProcessorID From Win32_processor");
             ManagementObjectCollection mbsList = mbs.Get();
 
                foreach (ManagementObject mo in mbsList)
               {
                 cpuid = mo["ProcessorID"].ToString();
               }
               return cpuid;
             }
              catch (Exception) { return cpuid; }
            }   

             //public static string GetHDDSerialNumber()
             {
                 ManagementObjectSearcher searcher;
                 string query1 = "SELECT * FROM Win32_DiskDrive";
                 searcher = new ManagementObjectSearcher(query1);
                 foreach (ManagementObject wmi_HD in searcher.Get())
                     if (wmi_HD["signature"] != null)
                         return wmi_HD["signature"].ToString();
                 return "no";
             }*/

        //public static bool check(string DBName, string Noe_Conect)
        //{
        //    bool re = false;
        //    try
        //    {
        //        if (Noe_Conect == "false")
        //        {
        //            SqlConnection sq = new SqlConnection("server=" + ServerName + ";trusted_connection=yes;");
        //            SqlDataAdapter adapt = new SqlDataAdapter("Exec sp_helpdb", sq);
        //            DataSet set = new DataSet();
        //            adapt.Fill(set);
        //            DataView view = new DataView(set.Tables[0]);
        //            view.Sort = "name";
        //            int res = view.Find(DBName);
        //            sq.Close();
        //            if (res >= 0)
        //                re = true;
        //            else if (res == -1)
        //                re = false;
        //        }
        //        else
        //        {


        //            SqlConnection sq = new SqlConnection(@"Data Source=" + ServerName + ";Initial Catalog=" + DatabaseName + ";User ID=" + ServerId + ";Password=" + DeviceInfo.Decrypt(ServerPass) + "");
        //            SqlDataAdapter adapt = new SqlDataAdapter("Exec sp_helpdb", sq);
        //            DataSet set = new DataSet();
        //            adapt.Fill(set);
        //            DataView view = new DataView(set.Tables[0]);
        //            view.Sort = "name";
        //            int res = view.Find(DBName);
        //            sq.Close();
        //            if (res >= 0)
        //                re = true;
        //            else if (res == -1)
        //                re = false;
        //        }

        //    }
        //    catch
        //    {
        //        re = false;
        //    }
        //    return re;
        //}
        public static string Encrypt(string ToEncrypt)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(ToEncrypt);
            string Key = "testValue";
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Key));
            hashmd5.Clear();
            TripleDESCryptoServiceProvider tDes = new TripleDESCryptoServiceProvider();
            tDes.Key = keyArray;
            tDes.Mode = CipherMode.ECB;
            tDes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tDes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tDes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        public static string Decrypt(string cypherString)
        {

            byte[] keyArray;
            
            byte[] toDecryptArray = Convert.FromBase64String(cypherString);
            string key = "testValue";
            MD5CryptoServiceProvider hashmd = new MD5CryptoServiceProvider();
            keyArray = hashmd.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            hashmd.Clear();
            TripleDESCryptoServiceProvider tDes = new TripleDESCryptoServiceProvider();
            tDes.Key = keyArray;
            tDes.Mode = CipherMode.ECB;
            tDes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tDes.CreateDecryptor();
            try
            {
                byte[] resultArray = cTransform.TransformFinalBlock(toDecryptArray, 0, toDecryptArray.Length);
                tDes.Clear();
                return UTF8Encoding.UTF8.GetString(resultArray, 0, resultArray.Length);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        //public static void CreateDatabase(string drive)
        //{
        //    Directory.CreateDirectory(drive + "folderName");
        //    SqlConnection sq = new SqlConnection("data source=.\\SQLEXPRESS;integrated security=true;Initial Catalog=master");
        //    SqlCommand com = new SqlCommand(@"create database [DBName] ON  PRIMARY ( NAME = N'DBName', FILENAME = N'" + drive + @"MoharerHesab\DBName.mdf' , SIZE = 3072KB , FILEGROWTH = 1024KB ) LOG ON ( NAME = N'DBName_log', FILENAME = N'" + drive + @"MoharerHesab\DBName_log.ldf' , SIZE = 1024KB , FILEGROWTH = 10%) collate Arabic_CI_AS_KS_WS", sq);
        //    sq.Open();
        //    com.Connection = sq;
        //    com.ExecuteNonQuery();
        //    com.CommandText = "use [DBName] CREATE TABLE [dbo].[users]([username] [nvarchar](50) NULL,[password] [nvarchar](50) NULL) ON [PRIMARY]";
        //    com.ExecuteNonQuery();
        //    com.CommandText = "use [DBName] CREATE TABLE [dbo].[customers]([id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,[name] [nvarchar](50) NULL,[family] [nvarchar](50) NULL,[melicode] [nvarchar](50) NULL,[address] [nvarchar](250) NULL,[tel] [nvarchar](50) NULL,	[cid] [nvarchar](50) NOT NULL,[mojodi] [numeric](18, 0) NULL,[mobile] [nvarchar](50) NULL,[pid] [numeric](18, 0) NULL, CONSTRAINT [PK_customers] PRIMARY KEY CLUSTERED ([cid] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY];";
        //    com.ExecuteNonQuery();
        //    sq.Close();
        //    com.Dispose();
        //}
        //public static void DropDataBase()
        //{
        //    SqlConnection sq = new SqlConnection("data source=.;integrated security=true;Initial Catalog=master");
        //    SqlCommand com = new SqlCommand("drop database " + DatabaseName + "", sq);
        //    sq.Open();
        //    com.Connection = sq;
        //    com.Dispose();
        //    com.ExecuteNonQuery();
        //    sq.Close();

        //}
        public static void deleteDirectory(string target_dir)
        {
            string[] files = Directory.GetFiles(target_dir);
            string[] dirs = Directory.GetDirectories(target_dir);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }


            foreach (string dir in dirs)
            {
                deleteDirectory(dir);
            }
            Directory.Delete(target_dir, false);
        }
        //public static Boolean CheckDataBase(string DataBasePathMDF, string DataBasePat_Logldf, string Noe_Conect)
        //{
        //    try
        //    {

        //        if (Noe_Conect != "true")
        //        {


        //            SqlConnection cnn = new SqlConnection();
        //            SqlCommand cmd = new SqlCommand();
        //            SqlDataAdapter da = new SqlDataAdapter();
        //            DataTable dt = new DataTable();
        //            cnn.ConnectionString = "data source=" + ServerName + ";integrated security=true;Initial Catalog=master";
        //            cnn.Open();
        //            cmd.Connection = cnn;
        //            cmd.CommandText = "SELECT * FROM master.dbo.sysdatabases where name = " + DatabaseName + "";
        //            da.SelectCommand = cmd;
        //            da.Fill(dt);
        //            cnn.Close();
        //            if (dt.Rows.Count == 0)
        //                return (false);
        //            else
        //                return (true);
        //        }
        //        else
        //        {

        //            /////////////////////

        //            SqlConnection cnn = new SqlConnection();
        //            SqlCommand cmd = new SqlCommand();
        //            SqlDataAdapter da = new SqlDataAdapter();
        //            DataTable dt = new DataTable();
        //            cnn.ConnectionString = @"Data Source=" + ServerName + ";Initial Catalog=master;User ID=" + ServerId + ";Password=" + DeviceInfo.Decrypt(ServerPass) + "";
        //            cnn.Open();
        //            cmd.Connection = cnn;
        //            cmd.CommandText = "SELECT * FROM master.dbo.sysdatabases where name = " + DatabaseName + "";
        //            da.SelectCommand = cmd;
        //            da.Fill(dt);
        //            cnn.Close();
        //            if (dt.Rows.Count == 0)
        //                return (false);
        //            else
        //                return (true);
        //        }
        //    }
        //    catch
        //    {
        //        return false;
        //    }

        //}
        //public  Boolean BacKUp(string fileName, string DataBasePath, string Noe_Conect)
        //{
        //    try
        //    {
        //        if (Noe_Conect == "false")
        //        {

        //            ///////////////
        //            SqlConnection cnn = new SqlConnection();
        //            SqlCommand cmd = new SqlCommand();
        //            cnn.ConnectionString = "data source=" + ServerName + ";integrated security=true;Initial Catalog=master";
        //            cnn.Open();
        //            cmd.Connection = cnn;
        //            cmd.CommandText = @"BACKUP DATABASE " + DatabaseName + " TO DISK ='" + DataBasePath + @"\" + DatabaseName + ".Bak' WITH FORMAT,MEDIANAME = '" + DatabaseName + "', NAME = 'Full Backup of  " + DatabaseName + "'";
        //            cmd.ExecuteNonQuery();
        //            cnn.Close();
        //            return true;
        //        }
        //        else
        //        {

        //            SqlConnection cnn = new SqlConnection();
        //            SqlCommand cmd = new SqlCommand();
        //            cnn.ConnectionString = @"Data Source=" + ServerName + ";Initial Catalog= " + DatabaseName + ";User ID=" + ServerId + ";Password=" + ServerPass + "";
        //            cnn.Open();
        //            cmd.Connection = cnn;
        //            cmd.CommandText = @"BACKUP DATABASE " + DatabaseName + " TO DISK ='" + DataBasePath + @"\" + fileName + ".Bak' WITH FORMAT,MEDIANAME = '" + DatabaseName + "', NAME = 'Full Backup of  " + DatabaseName + "'";
        //            cmd.ExecuteNonQuery();
        //            cnn.Close();
        //            return true;
        //        }
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //public static string AtachDatabase(string DataBasePathMDF, string DataBasePat_Logldf, string Noe_Conect)
        //{

        //    if (Noe_Conect != "true")
        //    {
        //        // connection.ConnectionString = ("Data Source=sajedi;AttachDbFilename=|DataDirectory|\DataBase.mdf;Integrated Security=True;User Instance=True")

        //        SqlConnection cnn = new SqlConnection();
        //        SqlCommand cmd = new SqlCommand();
        //        cnn.ConnectionString = "data source=" + ServerName + ";integrated security=true";
        //        cnn.Open();
        //        cmd.Connection = cnn;
        //        cmd.CommandText = @" CREATE DATABASE " + DatabaseName + "  ON (FILENAME = '" + DataBasePathMDF + "'),(FILENAME ='" + DataBasePat_Logldf + "')  FOR ATTACH";
        //        cmd.ExecuteNonQuery();
        //        cnn.Close();
        //        return ("عملیات ساخت دیتابیس موفقیت انجام شد");
        //    }
        //    else
        //    {
        //        // connection.ConnectionString = ("Data Source=sajedi;AttachDbFilename=|DataDirectory|\DataBase.mdf;Integrated Security=True;User Instance=True")
        //        /////////////////////
        //        SqlConnection cnn = new SqlConnection();
        //        SqlCommand cmd = new SqlCommand();
        //        cnn.ConnectionString = @"Data Source=" + ServerName + ";Initial Catalog=master;User ID=" + ServerId + ";Password=" + DeviceInfo.Decrypt(ServerPass) + "";
        //        cnn.Open();
        //        cmd.Connection = cnn;
        //        cmd.CommandText = @" CREATE DATABASE " + DatabaseName + "  ON (FILENAME = '" + DataBasePathMDF + "'),(FILENAME ='" + DataBasePat_Logldf + "')  FOR ATTACH";
        //        cmd.ExecuteNonQuery();
        //        cnn.Close();
        //        return ("عملیات ساخت دیتابیس موفقیت انجام شد");
        //    }

        //}
        //public static string Restor(string DataBaseName, string Noe_Conect)
        //{
        //    try
        //    {

        //        if (Noe_Conect == "false")
        //        {

        //            SqlConnection cnn = new SqlConnection();
        //            SqlCommand cmd = new SqlCommand();
        //            cnn.ConnectionString = "data source=" + ServerName + ";integrated security=true;Initial Catalog=master";
        //            cnn.Open();
        //            cmd.Connection = cnn;
        //            cmd.CommandText = "USE MASTER RESTORE DATABASE " + DatabaseName + " FROM DISK = '" + DataBaseName + "'";
        //            cmd.ExecuteNonQuery();
        //            cnn.Close();
        //            return ("عملیات بازیابی اطلاعات با موفقیت انجام شد");
        //        }
        //        else
        //        {


        //            SqlConnection cnn = new SqlConnection();
        //            SqlCommand cmd = new SqlCommand();
        //            //cnn.ConnectionString = "data source=" + StrText + ";integrated security=true;Initial Catalog=master";
        //            //cnn.ConnectionString = "Data Source = " + ServerNameText + "; Initial Catalog = " + DataBaseName + "; User Id =" + ServerIdrText + " Password = " + ServerPassText + "";                   
        //            cnn.ConnectionString = "Server=" + ServerPass + ";user id=" + ServerId + ";password=" + ServerPass + ";initial catalog=master";
        //            cnn.Open();
        //            cmd.Connection = cnn;
        //            cmd.CommandText = "USE MASTER RESTORE DATABASE " + DatabaseName + " FROM DISK = '" + DataBaseName + "'";
        //            cmd.ExecuteNonQuery();
        //            cnn.Close();
        //            return ("عملیات بازیابی اطلاعات با موفقیت انجام شد");
        //        }
        //    }
        //    catch
        //    {
        //        return "عملیات بازیابی با خطا مواجه شده است با پشتیبانی تماس بگیرید";
        //    }
        //}
        //public static Boolean DropMyDatabase()
        //{
        //    try
        //    {
        //        StreamReader sr = new StreamReader("Application.StartupPath" + @"\" + ServerName + "");
        //        string StrText = sr.ReadLine().ToString();
        //        sr.Close();
        //        SqlConnection cnn = new SqlConnection();
        //        SqlCommand cmd = new SqlCommand();
        //        cnn.ConnectionString = "data source=" + StrText + ";integrated security=true;Initial Catalog=master";
        //        cnn.Open();
        //        cmd.Connection = cnn;
        //        cmd.CommandText = "Drop database " + DatabaseName + "";
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }

        //}
        public static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }
  
        public static string File_Type(string FilePath, string Type)
        {

            for (int j = FilePath.Length - 1; j > 0; j--)
            {
                if (FilePath.Substring(j, 1).ToString() == @".")
                {
                    Type = FilePath.Substring(j, (FilePath.Length - j));
                    break;
                }
            }
            return (Type);
        }
        public static string File_Name(string FilePath, string Type)
        {

            for (int j = FilePath.Length - 1; j > 0; j--)
            {
                if (FilePath.Substring(j, 1).ToString() == @"\")
                {
                    Type = FilePath.Substring(j, (FilePath.Length - j));
                    break;
                }
            }
            return (Type);
        }
        //public static string DropDataBase2()
        //{

        //    try
        //    {

        //        SqlConnection.ClearAllPools();
        //        SqlConnection scon = new SqlConnection();
        //        scon.ConnectionString = "data source=" + ServerName + ";integrated security=true;Initial Catalog=master";
        //        SqlCommand cmd = new SqlCommand("ALTER DATABASE " + DatabaseName + "  SET SINGLE_USER  WITH ROLLBACK IMMEDIATE", scon);
        //        cmd.CommandType = CommandType.Text;
        //        scon.Open();
        //        cmd.ExecuteNonQuery();
        //        scon.Close();
        //        SqlCommand cmddrpdb = new SqlCommand("drop database " + DatabaseName + "", scon);
        //        cmddrpdb.CommandType = CommandType.Text;
        //        scon.Open();
        //        cmddrpdb.ExecuteNonQuery();
        //        scon.Close();

        //        return "اطلاعات با موفقیت حذف شد";
        //    }
        //    catch
        //    {
        //        return "خطا رخ داده است";
        //    }
        //}

        //public bool Restore111(string FileName, string Noe_Conect)
        //{
        //    try
        //    {

        //        if (Noe_Conect == "false")
        //        {

        //            string strSQL = "ALTER DATABASE " + DatabaseName + " SET SINGLE_USER with ROLLBACK IMMEDIATE " + " USE master " + " RESTORE DATABASE " + DatabaseName + " FROM DISK= N'" + FileName + "'WITH REPLACE";
        //            SqlConnection con = new SqlConnection();
        //            SqlCommand com = new SqlCommand();
        //            con.ConnectionString = "data source=" + ServerName + ";integrated security=true;Initial Catalog=master";
        //            com.CommandText = strSQL;
        //            com.Connection = con;
        //            con.Open();
        //            com.ExecuteNonQuery();
        //            con.Close();
        //            return true;
        //        }
        //        else
        //        {

        //            //////////////////
        //            SqlConnection cnn = new SqlConnection();
        //            SqlCommand cmd = new SqlCommand();
        //            cnn.ConnectionString = @"Data Source=" + ServerName + ";Initial Catalog=" + DatabaseName + ";User ID=" + ServerId + ";Password=" + ServerPass + "";
        //            cnn.Open();
        //            cmd.Connection = cnn;
        //            cmd.CommandText = @"ALTER DATABASE " + DatabaseName + " SET SINGLE_USER with ROLLBACK IMMEDIATE " + " USE master " + " RESTORE DATABASE " + DatabaseName + " FROM DISK= N'" + FileName + "'WITH REPLACE";
        //            cmd.ExecuteNonQuery();
        //            cnn.Close();
        //            return true;
        //            /////////////////
        //        }
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        public static string tarikh_baraks(string tarikh_vorodi)
        {
            string t = tarikh_vorodi.Substring(8, 2) + "/" + tarikh_vorodi.Substring(5, 2) + "/" + tarikh_vorodi.Substring(0, 4);
            return t;
        }
        public static string Sqlcommand { get; set; }

    }
}


