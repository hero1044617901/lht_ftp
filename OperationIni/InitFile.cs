using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Specialized;

namespace OperationIni
{
    /// <summary>
    /// ini文件件操作
    /// </summary>
    public class InitFile
    {
        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileInt(string lpApplicationName, string lpKeyName, int nDefault, string lpFileName);
        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileSectionNames(byte[] buffer, int iLen, string lpFileName);
        [DllImport("kernel32.dll")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32.DLL", EntryPoint = "GetPrivateProfileSection")]
        private static extern int GetPrivateProfileSection(string lpAppName, byte[] lpReturnedString, int nSize, string lpFileName);


        /// <summary>
        /// 获取节点选项名称(section)
        /// </summary>
        /// <param name="FileName">文件名称</param>
        /// <returns></returns>
        public static ArrayList ReadSections(string FileName)
        {
            byte[] buffer = new byte[65535];
            int rel = GetPrivateProfileSectionNames(buffer, buffer.GetUpperBound(0), FileName);
            return Conver2ArrayList(rel, buffer);
        }
        private static ArrayList Conver2ArrayList(int rel, byte[] buffer)
        {
            ArrayList arrayList = new ArrayList();
            if (rel > 0)
            {
                int iCnt, iPos;
                string tmp;
                iCnt = 0; iPos = 0;
                for (iCnt = 0; iCnt < rel; iCnt++)
                {
                    if (buffer[iCnt] == 0x00)
                    {
                        tmp = System.Text.ASCIIEncoding.Default.GetString(buffer, iPos, iCnt - iPos).Trim();
                        iPos = iCnt + 1;
                        if (tmp != "")
                            arrayList.Add(tmp);
                    }
                }
            }
            return arrayList;
        }
        /// <summary>
        /// 返回键值(整型)
        /// </summary>
        /// <param name="lpApplicationName">节点选项名称(section)</param>
        /// <param name="lpKeyName">键名(key)</param>
        /// <param name="nDefault">默认值</param>
        /// <param name="lpFileName">文件名</param>
        /// <returns>键值(整型)</returns>
        public static int ReadInt(string lpApplicationName, string lpKeyName, int nDefault, string lpFileName)
        {
            return GetPrivateProfileInt(lpApplicationName, lpKeyName, nDefault, lpFileName);
        }
        /// <summary>
        /// 写入文件(int)
        /// </summary>
        /// <param name="section">节点选项名称(section)</param>
        /// <param name="key">键名(key)</param>
        /// <param name="val">写入的数字</param>
        /// <param name="filePath">文件名</param>
        public static void WriteInt(string section, string key, int val, string filePath)
        {
            WritePrivateProfileString(section, key, val.ToString(), filePath);
        }
        /// <summary>
        /// 读取文件(string)
        /// </summary>
        /// <param name="section">节点选项名称(section)</param>
        /// <param name="key">键名(key)</param>
        /// <param name="def">默认值</param>
        /// <param name="retVal">实际读取值</param>
        /// <param name="size">读取长度</param>
        /// <param name="filePath">文件名</param>
        /// <returns>实际读取的长度</returns>
        public static int ReadString(string section, string key, string def, StringBuilder retVal, int size, string filePath)
        {
            return GetPrivateProfileString(section, key, def, retVal, size, filePath);
        }
        /// <summary>
        /// 写入文件(string)
        /// </summary>
        /// <param name="section">节点选项名称(section)</param>
        /// <param name="key">键名(key)</param>
        /// <param name="val">写入的内容</param>
        /// <param name="filePath">文件名</param>
        /// <returns>实际写入的个数</returns>
        public static long WriteString(string section, string key, string val, string filePath)
        {
            return WritePrivateProfileString(section, key, val, filePath);
        }
        /// <summary>
        /// 读取指定section下的所有内容，以key=value存入StringCollection中
        /// </summary>
        /// <param name="section">节点选项名称(section)</param>
        /// <param name="filename">文件名</param>
        /// <returns>返回StringCollection</returns>
        public static StringCollection ReadKeyEValue(String section, String filename)
        {
            StringCollection items = new StringCollection();
            byte[] buffer = new byte[32768];
            int bufLen = 0;
            bufLen = GetPrivateProfileSection(section, buffer, buffer.GetUpperBound(0), filename);
            if (bufLen > 0)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < bufLen; i++)
                {
                    if (buffer[i] != 0)
                    {
                        sb.Append((char)buffer[i]);
                    }
                    else
                    {
                        if (sb.Length > 0 && !sb.ToString().StartsWith("//"))
                        {
                            items.Add(sb.ToString());
                            sb = new StringBuilder();
                        }
                    }
                }
            }
            return items;
        }
        /// <summary>
        /// 获取所有的Key名称
        /// </summary>
        /// <param name="section">节点名称</param>
        /// <param name="filename">文件名</param>
        /// <returns>返回含有所有的key名称的ArrayList</returns>
        public static ArrayList ReadKeys(String section, String filename)
        {
            ArrayList hash = new ArrayList();
            StringCollection all = ReadKeyEValue(section, filename);
            foreach (string str in all)
            {
                if (str.Contains("=") && !str.StartsWith("//"))
                {
                    var temp = str.Split('=');
                    if (!string.IsNullOrEmpty(temp[0]))
                    {
                        hash.Add(temp[0].Trim());
                    }
                }
            }
            return hash;
        }
        /// <summary>
        ///  读取指定section下的所有内容，存入哈希表中
        /// </summary>
        /// <param name="section">节点选项名称(section)</param>
        /// <param name="filename">文件名</param>
        /// <returns>返回一个哈希表，存放key和值</returns>
        public static Hashtable ReadKeyValue(String section, String filename)
        {
            Hashtable hash = new Hashtable();
            StringCollection all = ReadKeyEValue(section, filename);
            foreach (string str in all)
            {
                if (str.Contains("=") && !str.StartsWith("//"))
                {
                    var temp = str.Split('=');
                    if (!string.IsNullOrEmpty(temp[0]) && !string.IsNullOrEmpty(temp[1]))
                    {
                        hash.Add(temp[0].Trim(), temp[1].Trim());
                    }
                }
            }
            return hash;
        }
        /// <summary>
        /// 删除节点选项
        /// </summary>
        /// <param name="section">目标节点</param>
        /// <param name="filename">文件名</param>
        public static void DelSection(String section, String filename)
        {
            WritePrivateProfileString(section, null, null, filename);
        }
        /// <summary>
        /// 删除key
        /// </summary>
        /// <param name="section">目标节点</param>
        /// <param name="key">目标key</param>
        /// <param name="filename">文件名</param>
        public static void DelKey(String section, String key, String filename)
        {
            WritePrivateProfileString(section, key, null, filename);
        }
        /// <summary>
        /// 获得一个double数值
        /// </summary>
        /// <param name="section">节点</param>
        /// <param name="key">关键字</param>
        /// <param name="def">默认值</param>
        /// <param name="filePath">文件名</param>
        /// <returns>返回一个double数值</returns>
        public static double ReadDouble(string section, string key, double def, string filePath)
        {
            StringBuilder sb = new StringBuilder();
            ReadString(section, key, def.ToString(), sb, 255, filePath);
            double d = 0;

            if (!double.TryParse(sb.ToString(), out d))
                d = def;
            return d;
        }
        /// <summary>
        /// 写入文件(string)
        /// </summary>
        /// <param name="section">节点选项名称(section)</param>
        /// <param name="key">键名(key)</param>
        /// <param name="val">写入的数值</param>
        /// <param name="filePath">文件名</param>
        /// <returns>实际写入的个数</returns>
        public static long WriteDouble(string section, string key, double def, string filePath)
        {
            return WriteString(section,  key,  def.ToString(), filePath);
        }
    }
}
