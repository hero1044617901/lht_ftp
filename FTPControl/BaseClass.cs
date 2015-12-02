using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Collections;

using System.IO.Compression;

using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Runtime.Serialization;
using Microsoft.Win32;
using System.Globalization;
using System.Text.RegularExpressions;

namespace FTPControl
{
    class BaseClass
    {
        public class Win32
        {
            public const uint SHGFI_ICON = 0x100;
            public const uint SHGFI_LARGEICON = 0x0; // 'Large icon
            public const uint SHGFI_SMALLICON = 0x1; // 'Small icon
            [DllImport("shell32.dll", EntryPoint = "ExtractIcon")]
            public static extern int ExtractIcon(IntPtr hInst, string lpFileName, int nIndex);
            [DllImport("shell32.dll", EntryPoint = "SHGetFileInfo")]
            public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttribute, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint Flags);
            [DllImport("User32.dll", EntryPoint = "DestroyIcon")]
            public static extern int DestroyIcon(IntPtr hIcon);
            [DllImport("shell32.dll")]
            public static extern uint ExtractIconEx(string lpszFile, int nIconIndex, int[] phiconLarge, int[] phiconSmall, uint nIcons);
            [StructLayout(LayoutKind.Sequential)]
            public struct SHFILEINFO
            {
                public IntPtr hIcon;
                public IntPtr iIcon;
                public uint dwAttributes;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
                public string szDisplayName;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
                public string szTypeName;
            }
        }

        #region  ��ȡ������ͼ��
        /// �����ļ���չ����.*����������Ӧͼ��
        /// ������"."��ͷ�򷵻��ļ��е�ͼ�ꡣ
        public Icon GetIconByFileType(string fileType,bool isLarge)
        {
            if(fileType == null || fileType.Equals(string.Empty)) return null;
            RegistryKey regVersion = null;
            string regFileType = null;
            string regIconString = null;
            string systemDirectory = Environment.SystemDirectory + "\\";
            if(fileType[0] == '.')
            {
                //��ϵͳע������ļ�������Ϣ
                regVersion = Registry.ClassesRoot.OpenSubKey(fileType, true);
                if(regVersion != null)
                {
                    regFileType = regVersion.GetValue("") as string;
                    regVersion.Close();
                    regVersion = Registry.ClassesRoot.OpenSubKey(regFileType + @"\DefaultIcon" , true);
                    if(regVersion != null)
                    {
                        regIconString = regVersion.GetValue("") as string;
                        regVersion.Close();
                    }
                }
                if(regIconString == null)
                {
                    //û�ж�ȡ���ļ�����ע����Ϣ��ָ��Ϊδ֪�ļ����͵�ͼ��
                    regIconString = systemDirectory +"shell32.dll,0";
                }
            }
            else if (fileType[0] == '@')
            {
                regIconString = systemDirectory + "shell32.dll,0";
            }
            else
            {
                //ֱ��ָ��Ϊ�ļ���ͼ��
                regIconString = systemDirectory +"shell32.dll,3";
            }
            string[] fileIcon = regIconString.Split(new char[]{','});
            if(fileIcon.Length != 2)
            {
                //ϵͳע�����ע��ı�ͼ����ֱ����ȡ���򷵻ؿ�ִ���ļ���ͨ��ͼ��
                fileIcon = new string[]{systemDirectory +"shell32.dll","2"};
            }
            Icon resultIcon = null;
            try
            {
                //����API������ȡͼ��
                int[] phiconLarge = new int[1];
                int[] phiconSmall = new int[1];
                uint count = Win32.ExtractIconEx(fileIcon[0],Int32.Parse(fileIcon[1]),phiconLarge,phiconSmall,1);
                IntPtr IconHnd = new IntPtr(isLarge?phiconLarge[0]:phiconSmall[0]);
                resultIcon = Icon.FromHandle(IconHnd);
            }

            catch
            {
                fileIcon = new string[] { systemDirectory + "shell32.dll", "2" };
                                //����API������ȡͼ��
                int[] phiconLarge = new int[1];
                int[] phiconSmall = new int[1];
                uint count = Win32.ExtractIconEx(fileIcon[0],Int32.Parse(fileIcon[1]),phiconLarge,phiconSmall,1);
                IntPtr IconHnd = new IntPtr(isLarge?phiconLarge[0]:phiconSmall[0]);
                resultIcon = Icon.FromHandle(IconHnd);
            }
            return resultIcon;
        }
        #endregion

        #region  �ļ��еĸ���
        /// <summary>
        /// �ļ��еĸ���
        /// </summary>
        /// <param Ddir="string">Ҫ���Ƶ�Ŀ��·��</param>
        /// <param Sdir="string">Ҫ���Ƶ�ԭ·��</param>
        public void Files_Copy(string Ddir, string Sdir)
        {
            DirectoryInfo dir = new DirectoryInfo(Sdir);
            string SbuDir = Ddir;
            try
            {
                if (!dir.Exists)//�ж���ָ���ļ����ļ����Ƿ����
                {
                    return;
                }
                DirectoryInfo dirD = dir as DirectoryInfo;//����������������ļ������˳�
                string UpDir = UpAndDown_Dir(Ddir);
                if (dirD == null)//�ж��ļ����Ƿ�Ϊ��
                {
                    Directory.CreateDirectory(UpDir + "\\" + dirD.Name);//���Ϊ�գ������ļ��в��˳�
                    return;
                }
                else
                {
                    Directory.CreateDirectory(UpDir + "\\" + dirD.Name);
                }
                SbuDir = UpDir + "\\" + dirD.Name + "\\";
                FileSystemInfo[] files = dirD.GetFileSystemInfos();//��ȡ�ļ����������ļ����ļ���
                //�Ե���FileSystemInfo�����ж�,������ļ�������еݹ����
                foreach (FileSystemInfo FSys in files)
                {
                    FileInfo file = FSys as FileInfo;
                    if (file != null)//������ļ��Ļ��������ļ��ĸ��Ʋ���
                    {
                        FileInfo SFInfo = new FileInfo(file.DirectoryName + "\\" + file.Name);//��ȡ�ļ����ڵ�ԭʼ·��
                        SFInfo.CopyTo(SbuDir + "\\" + file.Name, true);//���ļ����Ƶ�ָ����·����
                    }
                    else
                    {
                        string pp = FSys.Name;//��ȡ��ǰ���������ļ�������
                        Files_Copy(SbuDir + FSys.ToString(), Sdir + "\\" + FSys.ToString());//������ļ�������еݹ����
                    }
                }
            }
            catch
            {
                MessageBox.Show("�ļ��Ƹ�ʧ�ܡ�");
                return;
            }
        }
        #endregion

        #region  ������һ��Ŀ¼
        /// <summary>
        /// ������һ��Ŀ¼
        /// </summary>
        /// <param dir="string">Ŀ¼</param>
        /// <returns>����String����</returns>
        public string UpAndDown_Dir(string dir)
        {
            string Change_dir = "";
            Change_dir = Directory.GetParent(dir).FullName;
            return Change_dir;
        }
        #endregion


        public void getFTPServerICO(ImageList il,string ftpip,string  user,string  pwd,ListView lv,string path)//��ȡ��������ͼ��
        {
            try
            {
                string[] a;
                lv.Items.Clear();
                il.Images.Clear();
                if(path.Length==0)
                    a = GetFileList(ftpip, user, pwd);
                else
                    a= GetFileList(ftpip + "/" + path.Remove(path.LastIndexOf("/")), user, pwd);
                if (a != null)
                {
                    var fileInfoList = GetList(a);
                    for (int i = 0; i < fileInfoList.Length; i++)
                    {
                        FileStruct f = fileInfoList[i];
                        string filetype = "";
                        if (f.IsDirectory)
                        {
                            filetype = f.Name;
                        }
                        else
                        {
                            if (f.Name.IndexOf('.') != -1)
                                filetype = f.Name.Substring(f.Name.LastIndexOf("."), f.Name.Length - f.Name.LastIndexOf("."));
                            else
                                filetype = "@";
                        }
                        il.Images.Add(GetIconByFileType(filetype, true));
                        string[] info = new string[4];
                        FileInfo fi = new FileInfo(f.Name);
                        info[0] = fi.Name;
                        info[1] = GetFileSize(f.Name, ftpip, user, pwd, path).ToString();
                        if (f.IsDirectory)
                        {
                            info[2] = "";
                            info[1] = "�ļ���";
                        }
                        else
                        {
                            info[2] = (GetFileSize(f.Name, ftpip, user, pwd, path)/1024+1).ToString()+" KB";
                            info[1] = fi.Extension.ToString();
                        }
                        ListViewItem item = new ListViewItem(info, i);
                        lv.Items.Add(item);
                    }
                    #region Mark
                    //for (int i = 0; i < a.Length; i++)
                    //{
                    //    string[] b = a[i].ToString().Split(' ');
                    //    string filename = b[b.Length-1];
                    //    string filetype="";
                    //    if (a[i].IndexOf("DIR") != -1 || b[4] == "2")
                    //    {
                    //        filetype = filename;
                    //    }
                    //    else
                    //    {
                    //        filetype = filename.Substring(filename.LastIndexOf("."), filename.Length - filename.LastIndexOf("."));
                    //    }
                    //    il.Images.Add(GetIconByFileType(filetype, true));
                    //    string[] info = new string[4];
                    //    FileInfo fi = new FileInfo(filename);
                    //    info[0] = fi.Name;
                    //    info[1] = GetFileSize(filename, ftpip, user, pwd, path).ToString();
                    //    if (a[i].IndexOf("DIR") != -1 || b[4] == "2")
                    //    {
                    //        info[2] = "";
                    //        info[1] = "�ļ���";
                    //    }
                    //    else
                    //    {
                    //        info[2] = GetFileSize(filename, ftpip, user, pwd, path).ToString();
                    //        info[1] = fi.Extension.ToString();
                    //    }
                    //    ListViewItem item = new ListViewItem(info, i);
                    //    lv.Items.Add(item);
                    //}
                    #endregion
                }
            }
            catch{}
        }

        public void listFolders(ToolStripComboBox tscb)//��ȡ���ش���Ŀ¼
        {
            string[] logicdrives = System.IO.Directory.GetLogicalDrives();
            for (int i = 0; i < logicdrives.Length; i++)
            {
                tscb.Items.Add(logicdrives[i]);
                tscb.SelectedIndex = 0;
            }
        }

        int k = 0;
        public void GOBack(ListView lv,ImageList il,string path)
        {

            if (AllPath.Length != 3)
            {
                string NewPath = AllPath.Remove(AllPath.LastIndexOf("\\")).Remove(AllPath.Remove(AllPath.LastIndexOf("\\")).LastIndexOf("\\")) + "\\";
                lv.Items.Clear();
                GetListViewItem(NewPath, il, lv);
                AllPath = NewPath;
            }
            else
            {
                if (k == 0)
                {
                    lv.Items.Clear();
                    GetListViewItem(path, il, lv);
                    k++;
                }
            }
        }
        public string Mpath()
        {
            string path=AllPath;
            return path;
        }

        public static string AllPath = "";//---------
        public void GetPath(string path, ImageList imglist, ListView lv,int ppath)//-------
        {
                string pp = "";
                string uu = "";
                if (ppath == 0)
                {
                    if (AllPath != path)
                    {
                        lv.Items.Clear();
                        AllPath = path;
                        GetListViewItem(AllPath, imglist, lv);
                    }
                }
                else
                {
                    uu = AllPath + path;
                    if (Directory.Exists(uu))
                    {
                        AllPath = AllPath + path + "\\";
                        pp = AllPath.Substring(0, AllPath.Length - 1);
                        lv.Items.Clear();
                        GetListViewItem(pp, imglist, lv);
                    }
                    else
                    {
                        uu = AllPath + path;
                        System.Diagnostics.Process.Start(uu);
                    }
                }
        }

        public void GetListViewItem(string path, ImageList imglist, ListView lv)//��ȡָ��·���������ļ�����ͼ��
        {
            lv.Items.Clear();
            Win32.SHFILEINFO shfi = new Win32.SHFILEINFO();
            try
            {
                string[] dirs = Directory.GetDirectories(path);
                string[] files = Directory.GetFiles(path);
                for (int i = 0; i < dirs.Length; i++)
                {
                    string[] info = new string[4];
                    DirectoryInfo dir = new DirectoryInfo(dirs[i]);
                    if (dir.Name == "RECYCLER" || dir.Name == "RECYCLED" || dir.Name == "Recycled" || dir.Name == "System Volume Information")
                    { }
                    else
                    {
                        //���ͼ��
                        Win32.SHGetFileInfo(dirs[i],
                                            (uint)0x80,
                                            ref shfi,
                                            (uint)System.Runtime.InteropServices.Marshal.SizeOf(shfi),
                                            (uint)(0x100 | 0x400)); //ȡ��Icon��TypeName
                        //���ͼ��
                        imglist.Images.Add(dir.Name, (Icon)Icon.FromHandle(shfi.hIcon).Clone());
                        info[0] = dir.Name;
                        info[1] = "";
                        info[2] = "�ļ���";
                        info[3] = dir.LastWriteTime.ToString();
                        ListViewItem item = new ListViewItem(info, dir.Name);
                        lv.Items.Add(item);
                        //����ͼ��
                        Win32.DestroyIcon(shfi.hIcon);
                    }
                }
                for (int i = 0; i < files.Length; i++)
                {
                    string[] info = new string[4];
                    FileInfo fi = new FileInfo(files[i]);
                    string Filetype = fi.Name.Substring(fi.Name.LastIndexOf(".")+1,fi.Name.Length- fi.Name.LastIndexOf(".") -1);
                    string newtype=Filetype.ToLower();
                    if (newtype == "sys" || newtype == "ini" || newtype == "bin" || newtype == "log" || newtype == "com" || newtype == "bat" || newtype == "db")
                    { }
                    else
                    {


                        //���ͼ��
                        Win32.SHGetFileInfo(files[i],
                                            (uint)0x80,
                                            ref shfi,
                                            (uint)System.Runtime.InteropServices.Marshal.SizeOf(shfi),
                                            (uint)(0x100 | 0x400)); //ȡ��Icon��TypeName
                        //���ͼ��
                        imglist.Images.Add(fi.Name, (Icon)Icon.FromHandle(shfi.hIcon).Clone());
                        info[0] = fi.Name;
                        info[1] = (fi.Length/1024+1).ToString()+" KB";
                        info[2] = fi.Extension.ToString();
                        info[3] = fi.LastWriteTime.ToString();
                        ListViewItem item = new ListViewItem(info, fi.Name);
                        lv.Items.Add(item);
                        //����ͼ��
                        Win32.DestroyIcon(shfi.hIcon);
                    }
                }
            }
            catch
            {
            }
        }

        FtpWebRequest reqFTP;
        public bool CheckFtp(string DomainName, string FtpUserName, string FtpUserPwd)//��֤��¼�û��Ƿ�Ϸ�
        {
            bool ResultValue = true;
            try
            {
                FtpWebRequest ftprequest = (FtpWebRequest)WebRequest.Create("ftp://" + DomainName);//����FtpWebRequest����
                ftprequest.Credentials = new NetworkCredential(FtpUserName, FtpUserPwd);//����FTP��½��Ϣ
                ftprequest.Method = WebRequestMethods.Ftp.ListDirectory;//����һ����������
                FtpWebResponse ftpResponse = (FtpWebResponse)ftprequest.GetResponse();//��Ӧһ������
                ftpResponse.Close();//�ر�����
            }
            catch
            {
                ResultValue = false;
            }
            return ResultValue;
        }

        public long GetFileSize(string filename, string ftpserver,string ftpUserID, string ftpPassword,string path)
        {
            long filesize = 0;
            try
            {
                FileInfo fi = new FileInfo(filename);
                string uri;
                if(path.Length==0)
                    uri = "ftp://" + ftpserver + "/" + fi.Name;
                else
                    uri = "ftp://" + ftpserver + "/" +path+ fi.Name;
                Connect(uri, ftpUserID, ftpPassword);
                reqFTP.Method = WebRequestMethods.Ftp.GetFileSize;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                filesize = response.ContentLength;
                return filesize;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// ��ȡFTP�ļ��б�
        /// </summary>
        /// <param name="ftpServerIP"></param>
        /// <param name="ftpUserID"></param>
        /// <param name="ftpPassword"></param>
        /// <returns></returns>
        public string[] GetFileList(string ftpServerIP, string ftpUserID, string ftpPassword)
        {
            string[] downloadFiles;
            StringBuilder result = new StringBuilder();
            FtpWebRequest reqFTP;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP));
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                WebResponse response = reqFTP.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string line = reader.ReadLine();
                while (line != null)
                {
                    result.Append(line);
                    result.Append("\n");
                    line = reader.ReadLine();
                    
                }
                result.Remove(result.ToString().LastIndexOf('\n'), 1);
                reader.Close();
                response.Close();
                return result.ToString().Split('\n');
            }
            catch
            {
                downloadFiles = null;
                return downloadFiles;
            }
        }

        /// <summary>
        /// ��ȡFTPָ���ļ��е��ļ��б�
        /// </summary>
        /// <param name="ftpServerIP"></param>
        /// <param name="ftpUserID"></param>
        /// <param name="ftpPassword"></param>
        /// <param name="filename"></param>
        /// <param name="path"></param>
        /// <returns>�ļ���Ϣ�б�</returns>
        public string[] GetFileListAll(string ftpServerIP, string ftpUserID, string ftpPassword,string filename,string path)
        {
            if (path == null)
                path = "";
            if (path.Length == 0)
            {
                string[] downloadFiles;
                StringBuilder result = new StringBuilder();
                FtpWebRequest reqFTP;
                try
                {
                    reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" + filename));
                    reqFTP.UseBinary = true;
                    reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                    reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
                    WebResponse response = reqFTP.GetResponse();
                    //StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("GB2312"));
                    StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        result.Append(line);
                        result.Append("\n");
                        line = reader.ReadLine();
                    }
                    result.Remove(result.ToString().LastIndexOf('\n'), 1);
                    reader.Close();
                    response.Close();
                    return result.ToString().Split('\n');
                }
                catch
                {
                    downloadFiles = null;
                    return downloadFiles;
                }
            }
            else
            {
                string[] downloadFiles;
                StringBuilder result = new StringBuilder();
                FtpWebRequest reqFTP;
                try
                {
                    reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" +path+ filename));
                    reqFTP.UseBinary = true;
                    reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                    reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
                    WebResponse response = reqFTP.GetResponse();
                    //StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("GB2312"));
                    StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        result.Append(line);
                        result.Append("\n");
                        line = reader.ReadLine();
                    }
                    result.Remove(result.ToString().LastIndexOf('\n'), 1);
                    reader.Close();
                    response.Close();
                    return result.ToString().Split('\n');
                }
                catch
                {
                    downloadFiles = null;
                    return downloadFiles;
                }
            }
        }

        /// <ȥ�ո�>
        /// ȥ���ַ����еĿո�
        /// </ȥ�ո�>
        /// <param name="str">Դ�ַ���</param>
        /// <returns>�µ��ַ���</returns>
        private string QCKG(string str)
        {
            string a = "";
            CharEnumerator CEnumerator = str.GetEnumerator();
            while (CEnumerator.MoveNext())
            {
                byte[] array = new byte[1];
                array = System.Text.Encoding.ASCII.GetBytes(CEnumerator.Current.ToString());
                int asciicode = (short)(array[0]);
                if (asciicode != 32)
                {
                    a += CEnumerator.Current.ToString();
                }
            }
            return a;
        }

        /// <�ϴ�>
        /// �ϴ�
        /// </�ϴ�>
        /// <param name="filename">�ϴ����ļ�</param>
        /// <param name="ftpServerIP"></param>
        /// <param name="ftpUserID"></param>
        /// <param name="ftpPassword"></param>
        /// <param name="pb"></param>
        /// <param name="path"></param>
        /// <returns>�ϴ��ɹ�����True</returns>
        public bool Upload(string filename, string ftpServerIP, string ftpUserID, string ftpPassword, ToolStripProgressBar pb,string path)
        {
            if (path == null)
                path = "";
            bool success = true;
            FileInfo fileInf = new FileInfo(filename);
            int allbye = (int)(fileInf.Length/1024 + 1);
            long startbye = 0;
            pb.Maximum = allbye;
            pb.Minimum = 0;
            string newFileName;
            if (fileInf.Name.IndexOf("#") == -1)
            {
                newFileName =QCKG(fileInf.Name);
            }
            else
            {
                newFileName = fileInf.Name.Replace("#", "��");
                newFileName = QCKG(newFileName);
            }
            string uri;
            if (path.Length == 0)
                uri = "ftp://" + ftpServerIP + "/" + newFileName;
            else
                uri = "ftp://" + ftpServerIP + "/" + path + newFileName;
            FtpWebRequest reqFTP;
            // ����uri����FtpWebRequest���� 
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
            // ftp�û��������� 
            reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
            // Ĭ��Ϊtrue�����Ӳ��ᱻ�ر� 
            // ��һ������֮��ִ�� 
            reqFTP.KeepAlive = false;
            // ָ��ִ��ʲô���� 
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
            // ָ�����ݴ������� 
            reqFTP.UseBinary = true;
            // �ϴ��ļ�ʱ֪ͨ�������ļ��Ĵ�С 
            reqFTP.ContentLength = fileInf.Length;
            int buffLength = 2048;// �����С����Ϊ2kb 
            byte[] buff = new byte[buffLength];
            // ��һ���ļ��� (System.IO.FileStream) ȥ���ϴ����ļ� 
            FileStream fs= fileInf.OpenRead();
            try
            {
                // ���ϴ����ļ�д���� 
                Stream strm = reqFTP.GetRequestStream();
                // ÿ�ζ��ļ�����2kb 
                int contentLen = fs.Read(buff, 0, buffLength);
                // ������û�н��� 
                while (contentLen != 0)
                {
                    // �����ݴ�file stream д�� upload stream 
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                    startbye += contentLen;
                    pb.Value = (int)(startbye/1024 + 1);
                }
                // �ر������� 
                strm.Close();
                fs.Close();
             }
             catch
             {
                 success = false;
             }
             return success;
        }

        /// <����FTP>
        /// ����FTP
        /// </����FTP>
        /// <param name="path">ftp uri</param>
        /// <param name="ftpUserID">�û�</param>
        /// <param name="ftpPassword">����</param>
        public void Connect(String path, string ftpUserID, string ftpPassword)
        {
            try
            {
                // ����uri����FtpWebRequest����
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(path));
                // ָ�����ݴ�������
                reqFTP.UseBinary = true;
                // ftp�û���������
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
            }
            catch (System.NotSupportedException notSupportedException)
            {
                throw notSupportedException;
            }
            catch (System.ArgumentNullException argumentNullException)
            {
                throw argumentNullException;
            }
            catch (System.Security.SecurityException securityException)
            {
                throw securityException;
            }
        }

        /// <ɾ���ļ�>
        /// ɾ���ļ�
        /// </ɾ���ļ�>
        /// <param name="fileName">�ļ���</param>
        /// <param name="ftpServerIP">����</param>
        /// <param name="ftpUserID">�û�</param>
        /// <param name="ftpPassword">����</param>
        /// <param name="path">FTPԴĿ¼</param>
        public void DeleteFileName(string fileName, string ftpServerIP, string ftpUserID, string ftpPassword,string path)
        {
           try
           {
               string uri;
               if(path.Length==0)
                   uri="ftp://" + ftpServerIP + "/" + fileName;
               else
                   uri = "ftp://" + ftpServerIP + "/" + path + fileName;
               // ����uri����FtpWebRequest����
               reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
               // ָ�����ݴ�������
               reqFTP.UseBinary = true;
               // ftp�û���������
               reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
               // Ĭ��Ϊtrue�����Ӳ��ᱻ�ر�
               // ��һ������֮��ִ��
               reqFTP.KeepAlive = false;
               // ָ��ִ��ʲô����
               reqFTP.Method = WebRequestMethods.Ftp.DeleteFile;
               FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
               response.Close();
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message, "ɾ������");
           }
        }

        /// <�ļ�����>
        /// �ļ�����
        /// </�ļ�����>
        /// <param name="filePath">����Ŀ��Ŀ¼</param>
        /// <param name="fileName">���ص��ļ���</param>
        /// <param name="ftpServerIP">����</param>
        /// <param name="ftpUserID">�û�</param>
        /// <param name="ftpPassword">����</param>
        /// <param name="pb">������</param>
        /// <param name="path">FTPԴ·��</param>
        /// <returns>�ɹ�����True</returns>
        public bool Download(string filePath, string fileName, string ftpServerIP, string ftpUserID, string ftpPassword,ToolStripProgressBar pb,string path)
        {
            bool bDownCheck = true;
            FtpWebRequest reqFTP;
            
            string uri;
            if (path.Length == 0)
                uri = "ftp://" + ftpServerIP + "/" + fileName;
            else
                uri = "ftp://" + ftpServerIP + "/" + path + fileName;
            try
            {
                int allbye = (int)(GetFileSize(fileName, ftpServerIP, ftpUserID, ftpPassword, path) / 1024 + 1);
                long startbye = 0;
                pb.Maximum = allbye;
                pb.Minimum = 0;

                FileStream outputStream = new FileStream(filePath + "\\" + fileName, FileMode.Create);
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];
                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                    startbye += readCount;
                    pb.Value = (int)(startbye/1024+1);
                }
                ftpStream.Close();
                outputStream.Close();
                response.Close();
            }
            catch(System.NotSupportedException se)
            {
                bDownCheck = false;
                throw se;
            }
            return bDownCheck;
        }
       
        /// <����Ŀ¼>
        /// ����Ŀ¼
        /// </����Ŀ¼>
       /// <param name="dirName">Ŀ¼��</param>
       /// <param name="ftpServerIP">����</param>
       /// <param name="ftpUserID">�û�</param>
       /// <param name="ftpPassword">����</param>
        public void MakeDir(string dirName, string ftpServerIP,string ftpUserID, string ftpPassword)
        {
            try
            {
                string uri = "ftp://" + ftpServerIP +"/"+ dirName;
                Connect(uri, ftpUserID, ftpPassword);//����       
                reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                response.Close();
            }
            catch{}
        }

        /// <ɾ��Ŀ¼>
        /// ɾ��Ŀ¼
        /// </ɾ��Ŀ¼>
        /// <param name="dirName">��Ҫɾ����Ŀ¼</param>
        /// <param name="ftpServerIP">Host</param>
        /// <param name="ftpUserID">�û���</param>
        /// <param name="ftpPassword">����</param>
        public void delDir(string dirName, string ftpServerIP, string ftpUserID, string ftpPassword)
        {
             try
             {
                 string uri = "ftp://" + ftpServerIP + "/" + dirName;
                 Connect(uri, ftpUserID, ftpPassword);//����      
                 reqFTP.Method = WebRequestMethods.Ftp.RemoveDirectory;//�����������ɾ���ļ��е�����
                 FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                 response.Close();
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
        }

        /// <��ȡFTP�ļ��б�>
        /// ��ȡFTP�ļ��б�
        /// </��ȡFTP�ļ��б�>
        /// <param name="ftpServerIP">ftp host</param>
        /// <param name="ftpUserID">��¼�û���</param>
        /// <param name="ftpPassword">��½����</param>
        /// <param name="path">ftp �ļ���</param>
        /// <returns>ָ���ļ����µ��ļ��б�</returns>
        public string[] GetFTPList(string ftpServerIP, string ftpUserID, string ftpPassword, string path)//ָ��·�����ļ��б�
        {
            if (path == null)
            path = "";
            string[] downloadFiles;
            StringBuilder result = new StringBuilder();
            FtpWebRequest reqFTP;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" + path.Remove(path.LastIndexOf("/"))));
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                WebResponse response = reqFTP.GetResponse();
                //StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("GB2312"));
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string line = reader.ReadLine();
                while (line != null)
                {
                    result.Append(line);
                    result.Append("\n");
                    line = reader.ReadLine();
                }
                result.Remove(result.ToString().LastIndexOf('\n'), 1);
                reader.Close();
                response.Close();
                return result.ToString().Split('\n');
            }
            catch
            {
                downloadFiles = null;
                return downloadFiles;
            }
        }

        /// <windows�����ļ��ṹ>
        /// ��Windows��ʽ�з����ļ���Ϣ
        /// </windows�����ļ��ṹ>
        /// <param name="Record">�ļ���Ϣ</param>
        private FileStruct ParseFileStructFromWindowsStyleRecord(string Record)
        {
            FileStruct f = new FileStruct();
            string processstr = Record.Trim();
            string dateStr = processstr.Substring(0, 8);
            processstr = (processstr.Substring(8, processstr.Length - 8)).Trim();
            string timeStr = processstr.Substring(0, 7);
            processstr = (processstr.Substring(7, processstr.Length - 7)).Trim();
            DateTimeFormatInfo myDTFI = new CultureInfo("en-US", false).DateTimeFormat;
            myDTFI.ShortTimePattern = "t";
            f.CreateTime = DateTime.Parse(dateStr + " " + timeStr, myDTFI);
            if (processstr.Substring(0, 5) == "<DIR>")
            {
                f.IsDirectory = true;
                processstr = (processstr.Substring(5, processstr.Length - 5)).Trim();
            }
            else
            {
                string[] strs = processstr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);   // true);
                processstr = strs[1];
                f.IsDirectory = false;
            }
            f.Name = processstr;
            return f;
        }

        /// <Unix�����ļ��ṹ>
        /// ��Unix��ʽ�з����ļ���Ϣ
        /// </Unix�����ļ��ṹ>
        /// <param name="Record">�ļ���Ϣ</param>
        private FileStruct ParseFileStructFromUnixStyleRecord(string Record)
        {
            FileStruct f = new FileStruct();
            string processstr = Record.Trim();
            f.Flags = processstr.Substring(0, 10);
            f.IsDirectory = (f.Flags[0] == 'd');
            processstr = (processstr.Substring(11)).Trim();
            _cutSubstringFromStringWithTrim(ref processstr, ' ', 0);   //����һ����
            f.Owner = _cutSubstringFromStringWithTrim(ref processstr, ' ', 0);
            f.Group = _cutSubstringFromStringWithTrim(ref processstr, ' ', 0);
            _cutSubstringFromStringWithTrim(ref processstr, ' ', 0);   //����һ����
            string yearOrTime = processstr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[2];
            if (yearOrTime.IndexOf(":") >= 0)  //time
            {
                processstr = processstr.Replace(yearOrTime, DateTime.Now.Year.ToString());
            }
            f.CreateTime = DateTime.Parse(_cutSubstringFromStringWithTrim(ref processstr, ' ', 8));
            f.Name = processstr;   //����������
            return f;
        }

        /// <��ȡ�ַ���>
        /// ����һ���Ĺ�������ַ�����ȡ
        /// </��ȡ�ַ���>
        /// <param name="s">��ȡ���ַ���</param>
        /// <param name="c">���ҵ��ַ�</param>
        /// <param name="startIndex">���ҵ�λ��</param>
        private string _cutSubstringFromStringWithTrim(ref string s, char c, int startIndex)
        {
            int pos1 = s.IndexOf(c, startIndex);
            string retString = s.Substring(0, pos1);
            s = (s.Substring(pos1)).Trim();
            return retString;
        }

        /// <�ж��ļ��б�ķ�ʽ>
        /// �ж��ļ��б�ķ�ʽWindow��ʽ����Unix��ʽ
        /// </�ж��ļ��б�ķ�ʽ>
        /// <param name="recordList">�ļ���Ϣ�б�</param>
        private FileListStyle GuessFileListStyle(string[] recordList)
        {
            foreach (string s in recordList)
            {
                if (s.Length > 10
                 && Regex.IsMatch(s.Substring(0, 10), "(-|d)(-|r)(-|w)(-|x)(-|r)(-|w)(-|x)(-|r)(-|w)(-|x)"))
                {
                    return FileListStyle.UnixStyle;
                }
                else if (s.Length > 8
                 && Regex.IsMatch(s.Substring(0, 8), "[0-9][0-9]-[0-9][0-9]-[0-9][0-9]"))
                {
                    return FileListStyle.WindowsStyle;
                }
            }
            return FileListStyle.Unknown;
        }

        /// <summary>
        /// ����ļ���Ŀ¼�б�
        /// </summary>
        /// <param name="datastring">FTP���ص��б��ַ���Ϣ</param>
        private FileStruct[] GetList(string[] dataRecords)
        {
            List<FileStruct> myListArray = new List<FileStruct>();
            FileListStyle _directoryListStyle = GuessFileListStyle(dataRecords);
            foreach (string s in dataRecords)
            {
                if (_directoryListStyle != FileListStyle.Unknown && s != "")
                {
                    FileStruct f = new FileStruct();
                    f.Name = "..";
                    switch (_directoryListStyle)
                    {
                        case FileListStyle.UnixStyle:
                            f = ParseFileStructFromUnixStyleRecord(s);
                            break;
                        case FileListStyle.WindowsStyle:
                            f = ParseFileStructFromWindowsStyleRecord(s);
                            break;
                    }
                    if (!(f.Name == "." || f.Name == ".."))
                    {
                        myListArray.Add(f);
                    }
                }
            }
            return myListArray.ToArray();
        }
    }
}
