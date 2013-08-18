using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Sockets;
using System.Net.Mail;
using System.Data.SqlClient;
using System.IO;
using System.Globalization;
using System.Xml;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using StoreManagement;

namespace StoreManagement
{
    // 日志类型
    public enum ELogType
    {
        Info,
        Warning,
        Error,
    }

    public class Utility
    {
        public static IDBProvider DBProvider{get;set;}

        public static Socket SvrSocket { get; set; }

        public static string LastErrorMessage { get; set; }
       
        public const string LOOPBACKIP = "127.0.0.1";
        // 获取运行路径
        static public string RunningPath
        {
            get;
            set;
        }

        // 获取所有本地IP
        private static HashSet<string> m_IPAddrs = null;
        public static string[] GetLocalIPAddress()
        {
            if (m_IPAddrs == null)
            {
                m_IPAddrs = new HashSet<string>();
                IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());
                foreach (IPAddress ip in ips)
                {
                    if (m_IPAddrs.Contains(ip.ToString()) == false)
                        m_IPAddrs.Add(ip.ToString());
                }
                if (m_IPAddrs.Contains(LOOPBACKIP) == false)
                    m_IPAddrs.Add(LOOPBACKIP);
            }
            return m_IPAddrs.ToArray<string>();
        }

        // 校验IP正确性
        public static IPAddress VerifyIPAddress(string ipstring)
        {
            IPAddress ip;
            try
            {
                ip = IPAddress.Parse(ipstring);
            }
            catch (FormatException expFmt)
            {
                LastErrorMessage = expFmt.Message;
                return null;
            }
            catch (ArgumentNullException expArg)
            {
                LastErrorMessage = expArg.Message;
                return null;
            }
            return ip;
        }

        // 检验端口正确性
        public static short VerifyIPPort(string portstring)
        {
            short port = 0;
            if (false == short.TryParse(portstring, out port))
            {
                return 0;
            }
            return port;
        }

        // 读取SQL文件
        public static string[] RetrieveSQLStatement(string sqlFile)
        {
            string fullFile = string.Format("{0}/Config/{1}", System.Environment.CurrentDirectory, sqlFile);
            if (File.Exists(fullFile) == false)
            {
                Utility.LastErrorMessage = "无法找到指定文件： " + sqlFile;
                return null;
            }
            string[] sqls = null;
            StreamReader ins = new StreamReader(fullFile);
            try
            {
                List<string> _sqls = new List<string>();
                string curLine = "", commandText = "";
                while (!ins.EndOfStream)
                {
                    curLine = ins.ReadLine().Trim();
                    if (string.IsNullOrEmpty(curLine) == true || curLine.StartsWith("--") == true)
                        continue;
                    if (string.Compare(curLine, "GO", true) != 0)
                    {
                        commandText += curLine;
                        commandText += "\r\n";
                    }
                    else
                    {
                        _sqls.Add(commandText);
                        commandText = "";
                    }
                }
                sqls = _sqls.ToArray();
            }
            catch (Exception AnyExp)
            {
                Utility.LastErrorMessage = AnyExp.Message;
                sqls = null;
            }
            finally
            {
                ins.Close();
            }
            return sqls;
        }

        // 获取当前系统时间
        public static string GetLongSysDateTimeString()
        {
            return DateTime.Now.ToString("yyyy年MM月dd日 星期ddd HH:mm:ss tt", new CultureInfo("zh-CN"));
        }

        // 获取文件大小
        public static string GetFileSize(string strFilePath)
        {
            try
            {
                double size = new FileInfo(strFilePath).Length;
                if (size < 1000)
                {
                   return string.Format("{0} Byte", size);
                }
                else if (size < 1024 * 1024)
                {
                    size /= 1024.0;
                    return string.Format("{0:F2} KB", size);
                }
                else if (size < 1024 * 1024 * 1024)
                {
                    size /= (1024.0 * 1024);
                    return string.Format("{0:F2} MB", size);
                }
            }
            catch (Exception exp)
            {
                LastErrorMessage = exp.Message;
                return null;
            }
            return null;
        }

        // 获取登录历史
        public static List<string> GetLoginHistory()
        {
            List<string> ret = null;
            try
            {
                string file = string.Format("{0}Config\\{1}", System.AppDomain.CurrentDomain.BaseDirectory,
                                                        Properties.Settings.Default.ApplicationHistory);
                if (File.Exists(file))
                {  
                    XmlDocument xml = new XmlDocument();
                    xml.Load(file);
                    XmlNode root = xml.SelectSingleNode("ApplicationHistory/LoginHistory");
                    if (null != root && root.HasChildNodes == true)
                    {
                        XmlNodeList logins = root.ChildNodes;
                        ret = new List<string>();
                        foreach (XmlNode elem in logins)
                        {
                            if (elem.InnerText != null && string.IsNullOrEmpty(elem.InnerText) == false)
                            {
                                ret.Add(elem.InnerText.Trim());
                            }
                        }
                    }
                }                                   
            } 
            catch (Exception exp)
            {
                return null;
            }
            return ret;
        }

        // 更新登录历史
        public static void UpdateLoginHistory(string user)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                string filepath = string.Format("{0}Config\\{1}", System.AppDomain.CurrentDomain.BaseDirectory,
                                                        Properties.Settings.Default.ApplicationHistory);
                XmlNode node;
                if (File.Exists(filepath))
                {
                    doc.Load(filepath);
                    node = doc.SelectSingleNode("ApplicationHistory/LoginHistory");

                    while (node.ChildNodes.Count >= 10)
                    {
                        node.RemoveChild(node.LastChild);
                    }
                }
                else //new file
                {
                    XmlElement appHis = doc.CreateElement("ApplicationHistory");
                    doc.AppendChild(appHis);
                    doc.InsertBefore(doc.CreateXmlDeclaration("1.0", "utf-8", ""), appHis);
                    node = doc.CreateElement("LoginHistory");
                    appHis.AppendChild(node);
                }

                foreach (XmlNode n in node.ChildNodes)
                {
                    if (n.InnerText.Trim() == user)
                    {
                        node.RemoveChild(n);
                        break;
                    }
                }
                XmlElement userNode = doc.CreateElement("Account");
                userNode.InnerText = user;
                node.InsertAfter(userNode, null);

                doc.Save(filepath);
            }
            catch (Exception)
            {
            }
        }

        // 是否拥有管理员权限
        static public bool IsAdminUser { get; set; }

        // 获取MD5
        static private MD5 _md5 = new MD5CryptoServiceProvider();
        static public string GetMD5(string input)
        {
            return BitConverter.ToString(_md5.ComputeHash(Encoding.Default.GetBytes(input.Trim()))).Replace("-", "");
        }

        // 获取外网IP
        static private string _ip = null;
        static public string InternetIP
        {
            get
            {
                if (_ip == null)
                {
                    try
                    {

                        WebClient client = new WebClient();
                        byte[] byteRec = client.DownloadData("http://www.123cha.com/");
                        string str = Encoding.GetEncoding("gb2312").GetString(byteRec);
                        _ip = Regex.Match(str, @"((?:(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d)))\.){3}(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d))))").ToString();
                    }
                    catch (Exception anyExp)
                    {
                        _ip = null;
                    }

                }
                return _ip;
            }
        }

        // 发送邮件
        static public void SendSMTPEMail(string strSmtpServer, string strFrom, string strFromPass, string strto, string strSubject, string strBody)
        {
            System.Net.Mail.SmtpClient client = new SmtpClient(strSmtpServer);
            client.UseDefaultCredentials = false;
            client.Credentials =
            new System.Net.NetworkCredential(strFrom, strFromPass);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            System.Net.Mail.MailMessage message =
            new MailMessage(strFrom, strto, strSubject, strBody);
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;
            client.Send(message);
        }

        
        // 获取当天日志文件名
        static private string m_LogFileName = null;
        static private string LogFile
        {
            get
            {
                if (null == m_LogFileName)
                {
                    m_LogFileName = string.Format("{0}\\log_{1}.txt", System.Environment.CurrentDirectory, DateTime.Now.ToString("yyyy-MM-dd"));
                }
                return m_LogFileName;
            }
        }
        // 输出日志
        static public void WriteLog(ELogType type, string msg)
        { 
            using (StreamWriter souts = new StreamWriter(LogFile, true, Encoding.Unicode))
            {
                try
                {
                    switch (type)
                    {
                        case ELogType.Info:
                            {
                                souts.WriteLine(string.Format("[Info]: {0}", msg));
                            }
                            break;
                        case ELogType.Warning:
                            {
                                souts.WriteLine(string.Format("[Warning]: {0}", msg));
                            }
                            break;
                        case ELogType.Error:
                            {
                                souts.WriteLine(string.Format("[Info]: {0}", msg));
                            }
                            break;
                    }
                }
                catch (Exception)
                {
                
                }
            }
        }
    }
}
