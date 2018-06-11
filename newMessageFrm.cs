using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using System.Diagnostics;
using Microsoft.Win32;
using System.Threading;
using System.IO;

using S22.Xmpp.Im;
using System.Activities.Expressions;
using xmppserver;
using S22.Xmpp.Client;

namespace OpenMessage
{
    public partial class newMessageFrm : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();
       [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowThreadProcessId(IntPtr handle, out int processId);
        // To support flashing.
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FlashWindowEx(ref FLASHWINFO pwfi);

        //Flash both the window caption and taskbar button.
        //This is equivalent to setting the FLASHW_CAPTION | FLASHW_TRAY flags. 
        public const UInt32 FLASHW_ALL = 3;
  
        // Flash continuously until the window comes to the foreground. 
        public const UInt32 FLASHW_TIMERNOFG = 12;

        [StructLayout(LayoutKind.Sequential)]
        public struct FLASHWINFO
        {
            public UInt32 cbSize;
            public IntPtr hwnd;
            public UInt32 dwFlags;
            public UInt32 uCount;
            public UInt32 dwTimeout;
        }
        public static bool FlashWindowEx(newMessageFrm form)
        {
            IntPtr hWnd = form.Handle;
            FLASHWINFO fInfo = new FLASHWINFO();

            fInfo.cbSize = Convert.ToUInt32(Marshal.SizeOf(fInfo));
            fInfo.hwnd = hWnd;
            fInfo.dwFlags = FLASHW_ALL | FLASHW_TIMERNOFG;
            fInfo.uCount = UInt32.MaxValue;
            fInfo.dwTimeout = 0;

            return FlashWindowEx(ref fInfo);
        }
        public string serverName;
       public String frmId {get; set; }
        public String jidFrom;
        public string remoteUID = null;
   

        public Roster rosFrm;
        public string password;
        public string domain;
        public string username;
        public bool useTLS;
        public string hfg;
        public string simlPackage;

        public void fdc()
        {
           hfg = Console.ReadLine();
          
        }
        public newMessageFrm(string jid, string domain)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            jidFrom = jid;
            newMessageWindow.Text = "Chat with: " + jid;
            serverName = domain;
            this.Text = "Chat with: " + jid;

            this.Visible = false;

            sendBtn_Click(null, null);


        }

      
        private void pxj()
        {
            if (File.Exists(xmppserver.Properties.Settings.Default.stk + ".txt"))
            {


                string[] pkn = File.ReadAllLines(xmppserver.Properties.Settings.Default.stk + ".txt");
                foreach (string ft in pkn)
                {
                   
                    
                }
            }
            else
            {
                File.WriteAllText(xmppserver.Properties.Settings.Default.stk + ".txt", "my name is yan" + Environment.NewLine);
            }

        }

        public void sendBtn_Click(object sender, EventArgs e)
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
                        xmppserver.Properties.Settings.Default.srv = domain;
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
                    if (Program.client.Connected == true)
                    {
                        Console.WriteLine(" close conected");
                        Program.client.Close();
                    }
                    Program.client = new XmppClient(serverName, 5222, true, null);
                    Program.client.Error += Program.OnError;
                    Program.client.Message += Program.OnNewMessage;
                    Program.client.RosterUpdated += Program.OnRosterUpdate;
                    Program.client.Connect();
                    Console.WriteLine("conected");

                }
                else
                {
                    if (Program.client.Connected == true)
                    {
                        Console.WriteLine(" close conected");

                        Program.client.Close();
                    }
                    Program.client = new XmppClient(serverName, 5222, false, null);
                    Program.client.Error += Program.OnError;
                    Program.client.Message += Program.OnNewMessage;
                    Program.client.RosterUpdated += Program.OnRosterUpdate;
                    Program.client.SubscriptionRequest += Program.OnSubRequest;
                    Program.client.Connect();
                    Console.WriteLine("conected");
                }


            }
            catch (Exception ex)
            {

                Console.WriteLine("error form2");
            }

            if (Program.client.Connected == true)
            {
                try
                {
                    Console.WriteLine("authenticate");
                    Program.client.Authenticate(username, password);
                }
                catch (System.Security.Authentication.AuthenticationException ex)
                {
                    //This shouldn't happen but just to text...
                    Console.WriteLine("error authenticate");

                }

                if (Program.client.Authenticated == true)
                {
                    //Set Username label to show we are logged in...

                    //Grab roster...
                    foreach (var item in Program.client.GetRoster())
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
                    Program.client.SetStatus(online);
                    Console.WriteLine("");
                    Console.WriteLine("status=" + Availability.Online);
                }
            }

            do
            {
                Console.WriteLine("enter message or - main - to back nickname");
 
                 fdc();

                if (hfg == "main")
                {
                    Console.WriteLine("enter nickname");

                    try
                    {
                        Program.frm.Close();
                    }
                    catch { }

                   Program.sgd();
                    Program.shd = Program.gdf;

                    Program.frm = new newMessageFrm(Program.shd, Program.gdf);
                    Program.frm._msgText(Program.shd, Program.gdf);
                    Program.frm.ShowDialog();
                }
                else
                {try
                    {
                        textBox1.Text = hfg.ToString();
                        File.AppendAllText(xmppserver.Properties.Settings.Default.stk + ".txt", hfg.ToString());

                        Console.WriteLine(jidFrom + "@" + domain + hfg.ToString());
                        Program.client.SendMessage(jidFrom + "@" + domain, hfg.ToString());
                        appendMsg("You", hfg.ToString());
                    }
                    catch { Program.client.SendMessage(jidFrom + "@" + domain, "null or empty message ERROR"); }
                }
            } while (true);
        }
     
   

        static void msg(String title, String Error)
        {
           Console.WriteLine(title, Error);
          
        }
   
        public void appendMsg(String jid, String Message)
        {

            if (Message.Contains("/*/*OTR_REQUEST*"))
            {
                //OTR does not work yet, working to get a random session ID first.
                String[] otrMsg = Message.Split('*');
                remoteUID = otrMsg[3];
                //Process the OTR request:
               otr newOtrSess = new otr();
                String SessionID = newOtrSess.generateSessionID();
                //newOtrSess.createSession(SessionID);
             Console.WriteLine("Status - Conversation - New OTR ID"+ SessionID);
                return; //Do NOT process the rest of this function!!!!
            }
          
            String timeNow = DateTime.Now.ToString("hh:mm:ss tt");
            if (jid == "You")
            {
                richTextBox1.SelectionColor = Color.Cyan;
                richTextBox1.AppendText("["+timeNow + "]" + jid + ": ");
                richTextBox1.SelectionColor = Color.White;
                Console.WriteLine(Message + Environment.NewLine);
                
            } else
            {
                richTextBox1.SelectionColor = Color.LightGreen;
                richTextBox1.AppendText("[" + timeNow + "]" + jid + ": ");
                richTextBox1.SelectionColor = Color.White;
               Console.WriteLine(Message + Environment.NewLine);
                
               
                

            }
            richTextBox1.SelectionStart = richTextBox1.TextLength;
            richTextBox1.ScrollToCaret();

        }
        public static bool ApplicationIsActivated()
        {
            var activatedHandle = GetForegroundWindow();
            if (activatedHandle == IntPtr.Zero)
            {
                return false;       // No window is currently activated
            }

            var procId = Process.GetCurrentProcess().Id;
            int activeProcId;
            GetWindowThreadProcessId(activatedHandle, out activeProcId);

            return activeProcId == procId;
        }

        public void _msgText(String jid, String Message)
        {
           Console.WriteLine(jid, Message);
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
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
                    if (Program.client.Connected == true)
                    {
                        Console.WriteLine(" close conected");
                        Program.client.Close();
                    }
                    Program.client = new XmppClient(serverName, 5222, true, null);
                    Program.client.Error += Program.OnError;
                    Program.client.Message += Program.OnNewMessage;
                    Program.client.RosterUpdated += Program.OnRosterUpdate;
                    Program.client.Connect();
                    Console.WriteLine("conected");

                }
                else
                {
                    if (Program.client.Connected == true)
                    {
                        Console.WriteLine(" close conected");

                        Program.client.Close();
                    }
                    Program.client = new XmppClient(serverName, 5222, false, null);
                    Program.client.Error += Program.OnError;
                    Program.client.Message += Program.OnNewMessage;
                    Program.client.RosterUpdated += Program.OnRosterUpdate;
                    Program.client.SubscriptionRequest += Program.OnSubRequest;
                    Program.client.Connect();
                    Console.WriteLine("conected");
                }




                if (xmppserver.Program.client.Connected == true)
                {
                    try
                    {
                        Console.WriteLine("authenticate");
                        xmppserver.Program.client.Authenticate(username, password);
                    }
                    catch (System.Security.Authentication.AuthenticationException ex)
                    {
                        //This shouldn't happen but just to text...
                        Console.WriteLine("error authenticate");

                    }

                    if (xmppserver.Program.client.Authenticated == true)
                    {
                        //Set Username label to show we are logged in...

                        //Grab roster...
                        foreach (var item in xmppserver.Program.client.GetRoster())
                        {
                            String resID = item.Jid.Resource;
                            String domain2 = item.Jid.Domain;
                            String jid = item.Jid.ToString();
                            if (resID != null) { jid.Replace(resID, ""); jid = jid.Replace("@/", ""); }
                            if (jid.Contains("@")) { jid = jid.Replace("@", ""); }
                            jid = jid.Replace(domain2, "");
                            try
                            {
                                try
                                {
                                    xmppserver.Program.friendView.Items.Add(jid, 0);
                                }
                                catch
                                {
                                    //Do Nothing, Move on.
                                }
                                Console.Write(jid + "---", 0);
                            }
                            catch
                            {
                                //Do Nothing, Move on.
                            }

                        }
                    }

                    fdc();
                    textBox1.Text = hfg.ToString();

                    xmppserver.Program.client.SendMessage(jidFrom + "@" + serverName, textBox1.Text);
                    appendMsg("You", textBox1.Text);
     
                    textBox1.Text = "";
                    textBox1.Select();
                }
            }
        }

        private void newMessageWindow_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {


                Program.friendView.Items.Clear();


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
                        xmppserver.Properties.Settings.Default.srv = domain;
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
                    if (Program.client.Connected == true)
                    {
                        Console.WriteLine(" close conected");
                        Program.client.Close();
                    }
                    Program.client = new XmppClient(serverName, 5222, true, null);
                    Program.client.Error += Program.OnError;
                    Program.client.Message += Program.OnNewMessage;
                    Program.client.RosterUpdated += Program.OnRosterUpdate;
                    Program.client.Connect();
                    Console.WriteLine("conected");

                }
                else
                {
                    if (Program.client.Connected == true)
                    {
                        Console.WriteLine(" close conected");

                        Program.client.Close();
                    }
                    Program.client = new XmppClient(serverName, 5222, false, null);
                    Program.client.Error += Program.OnError;
                    Program.client.Message += Program.OnNewMessage;
                    Program.client.RosterUpdated += Program.OnRosterUpdate;
                    Program.client.SubscriptionRequest += Program.OnSubRequest;
                    Program.client.Connect();
                    Console.WriteLine("conected");
                }


            }
            catch (Exception ex)
            {

                Console.WriteLine("error form2");
            }

            if (Program.client.Connected == true)
            {
                try
                {
                    Console.WriteLine("authenticate");
                    Program.client.Authenticate(username, password);
                }
                catch (System.Security.Authentication.AuthenticationException ex)
                {
                    //This shouldn't happen but just to text...
                    Console.WriteLine("error authenticate");

                }

                if (Program.client.Authenticated == true)
                {
                    //Set Username label to show we are logged in...

                    //Grab roster...
                    foreach (var item in Program.client.GetRoster())
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
                    Program.client.SetStatus(online);
                    Console.WriteLine("");
                    Console.WriteLine("status=" + Availability.Online);
                }
            }


            //Set Avatar...
            string cn = File.ReadAllText("avt.tx");
            xmppserver.Properties.Settings.Default.avt = cn;
            Program.friendView.Columns.Add("Avatar", 100);
            Program.friendView.Columns.Add("Username", 100);
            Image Imagee = Image.FromFile(xmppserver.Properties.Settings.Default.avt);

            Program.avatarList.Images.Add(Imagee);
            Program.friendView.SmallImageList = Program.avatarList;
            Program.friendView.LargeImageList = Program.avatarList;
            //Set Avatar...

        }
    }
}
