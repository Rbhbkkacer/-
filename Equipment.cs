using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Кабельный_журнал
{
    public class Equipment : GroupBox
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(IntPtr ZeroOnly, string lpWindowName);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, SetWindowPosFlags uFlags);

        [Flags()]
        public enum SetWindowPosFlags : uint
        {
            /// <summary>If the calling thread and the thread that owns the window are attached to different input queues,
            /// the system posts the request to the thread that owns the window. This prevents the calling thread from
            /// blocking its execution while other threads process the request.</summary>
            /// <remarks>SWP_ASYNCWINDOWPOS</remarks>
            AsynchronousWindowPosition = 0x4000,
            /// <summary>Prevents generation of the WM_SYNCPAINT message.</summary>
            /// <remarks>SWP_DEFERERASE</remarks>
            DeferErase = 0x2000,
            /// <summary>Draws a frame (defined in the window's class description) around the window.</summary>
            /// <remarks>SWP_DRAWFRAME</remarks>
            DrawFrame = 0x0020,
            /// <summary>Applies new frame styles set using the SetWindowLong function. Sends a WM_NCCALCSIZE message to
            /// the window, even if the window's size is not being changed. If this flag is not specified, WM_NCCALCSIZE
            /// is sent only when the window's size is being changed.</summary>
            /// <remarks>SWP_FRAMECHANGED</remarks>
            FrameChanged = 0x0020,
            /// <summary>Hides the window.</summary>
            /// <remarks>SWP_HIDEWINDOW</remarks>
            HideWindow = 0x0080,
            /// <summary>Does not activate the window. If this flag is not set, the window is activated and moved to the
            /// top of either the topmost or non-topmost group (depending on the setting of the hWndInsertAfter
            /// parameter).</summary>
            /// <remarks>SWP_NOACTIVATE</remarks>
            DoNotActivate = 0x0010,
            /// <summary>Discards the entire contents of the client area. If this flag is not specified, the valid
            /// contents of the client area are saved and copied back into the client area after the window is sized or
            /// repositioned.</summary>
            /// <remarks>SWP_NOCOPYBITS</remarks>
            DoNotCopyBits = 0x0100,
            /// <summary>Retains the current position (ignores X and Y parameters).</summary>
            /// <remarks>SWP_NOMOVE</remarks>
            IgnoreMove = 0x0002,
            /// <summary>Does not change the owner window's position in the Z order.</summary>
            /// <remarks>SWP_NOOWNERZORDER</remarks>
            DoNotChangeOwnerZOrder = 0x0200,
            /// <summary>Does not redraw changes. If this flag is set, no repainting of any kind occurs. This applies to
            /// the client area, the nonclient area (including the title bar and scroll bars), and any part of the parent
            /// window uncovered as a result of the window being moved. When this flag is set, the application must
            /// explicitly invalidate or redraw any parts of the window and parent window that need redrawing.</summary>
            /// <remarks>SWP_NOREDRAW</remarks>
            DoNotRedraw = 0x0008,
            /// <summary>Same as the SWP_NOOWNERZORDER flag.</summary>
            /// <remarks>SWP_NOREPOSITION</remarks>
            DoNotReposition = 0x0200,
            /// <summary>Prevents the window from receiving the WM_WINDOWPOSCHANGING message.</summary>
            /// <remarks>SWP_NOSENDCHANGING</remarks>
            DoNotSendChangingEvent = 0x0400,
            /// <summary>Retains the current size (ignores the cx and cy parameters).</summary>
            /// <remarks>SWP_NOSIZE</remarks>
            IgnoreResize = 0x0001,
            /// <summary>Retains the current Z order (ignores the hWndInsertAfter parameter).</summary>
            /// <remarks>SWP_NOZORDER</remarks>
            IgnoreZOrder = 0x0004,
            /// <summary>Displays the window.</summary>
            /// <remarks>SWP_SHOWWINDOW</remarks>
            ShowWindow = 0x0040,
        }

        public struct Interface{
            public string port;
            public string description;
            /// <summary>
            /// acces: no mdix auto, no cdp enable, switchport port-security, switchport port-security mac-address sticky, mac
            /// trunk: switchport nonegotiate, udld port
            /// </summary>
            public string sw_mode;
            public int native_vlan;
            public int[] vlans;
            public bool sw_po;
            public bool sw_po_mac_st;
            public List<string> mac;
            public bool sh;
            public bool sp_bpduguard;
            public string media_type;
            public bool udld_port;
            public string duplex;
            public string speed;
        }

        public EList myeList;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private LinkLabel linkLabel1;
        public TextBox Equipment_Name;
        public TextBox Equipment_IP;
        public TextBox Equipment_MAC;
        public TextBox House;
        public TextBox Room;
        public TextBox Equipment_EO;
        public ListView Equipment_Ports;
        public Dictionary<int, string> portids = new Dictionary<int, string>();
        public int roomid;
        public int equipmentid;
        public int index;

        public Equipment(EList myList, int index, int PORT_id = 0, int ROOM_id = 0, int equipmentID = 0)
        {
            myeList = myList;
            this.index = index;
            //myeList.Insert(index < 0 ? 0 : index, this);
            /*try
            {
                Control trY = myeList.First(q => q.Parent != null);
                myeList.FindAll(q => { q.Show(); return null == (q.Parent = trY.Parent); });
            }
            catch (Exception)
            {  }*/
            InitializeComponent();
            if (PORT_id>0)
            {
                DataSet1TableAdapters.PortTableAdapter portTableAdapter = new DataSet1TableAdapters.PortTableAdapter();
                var portRow = portTableAdapter.GetDataByID(PORT_id)[0];
                DataSet1TableAdapters.EquipmentTableAdapter equipmentTableAdapter = new DataSet1TableAdapters.EquipmentTableAdapter();
                var equipmentRow = equipmentTableAdapter.GetDataByID(portRow.ID_Оборудования)[0];
                if (equipmentID==0)
                {
                    equipmentID = portRow.ID_Оборудования;
                }
                if (ROOM_id==0)
                {
                    ROOM_id = equipmentRow.ID_Шкафа_комнаты;
                }
            }

            if (ROOM_id>0)
            {
                Task.Run(() => {
                    DataSet2ReadOnlyTableAdapters.DataTableEquipmentAdapter dataTableEquipmentAdapter = new DataSet2ReadOnlyTableAdapters.DataTableEquipmentAdapter();
                    DataSet1TableAdapters.RoomTableAdapter roomTableAdapter = new DataSet1TableAdapters.RoomTableAdapter();
                    var roomTable = roomTableAdapter.GetData();
                    var roomRow = roomTable.FindByID(ROOM_id);
                    roomid = roomRow.ID;
                    DataSet1TableAdapters.HomeTableAdapter homeTableAdapter = new DataSet1TableAdapters.HomeTableAdapter();
                    var homeTable = homeTableAdapter.GetData();
                    var homeRow = homeTable.FindByID(roomRow.ID_Корпуса);
                    Invoke(new Action(() =>
                    {
                        Room.Text = roomRow.Шкаф_кабинет;
                        House.Text = homeRow.___корпуса;
                    }));
                });
            }

            if (equipmentID > 0)
            {
                Task.Run(() => {
                    equipmentid = equipmentID;
                    DataSet1TableAdapters.EquipmentTableAdapter equipmentTableAdapter = new DataSet1TableAdapters.EquipmentTableAdapter();
                    var equipmentRow = equipmentTableAdapter.GetDataByID(equipmentid)[0];
                    DataSet1TableAdapters.PortTableAdapter portTableAdapter = new DataSet1TableAdapters.PortTableAdapter();
                    var portCollection = portTableAdapter.GetDataByequipment(equipmentid).Rows;
                    DataSet2ReadOnlyTableAdapters.portNameTableAdapter portNameTableAdapter = new DataSet2ReadOnlyTableAdapters.portNameTableAdapter();
                    var portNameTable = portNameTableAdapter.GetData(equipmentid);
                    foreach (DataSet1.PortRow item in portCollection)
                    {
                        portids.Add(item.ID, item.Порт);
                        //Invoke(new Action(() =>
                        {
                            Invoke(new Action(() =>
                            {
                                Equipment_Ports.Items.Add(item.Порт);
                            Equipment_Ports.Items[Equipment_Ports.Items.Count - 1].SubItems.Add(portNameTable.First(q => q.Порт == item.Порт).Expr5);
                                Equipment_Ports.Items[Equipment_Ports.Items.Count - 1].BackColor = item.Включен ? Color.LightGreen : Color.LightPink;
                                Equipment_Ports.Items[Equipment_Ports.Items.Count - 1].Tag = Equipment_Ports.Items[Equipment_Ports.Items.Count - 1].BackColor;
                                if (PORT_id == item.ID)
                                {
                                    //Equipment_Ports.FocusedItem = Equipment_Ports.Items[Equipment_Ports.Items.Count - 1];
                                    Equipment_Ports.Items[Equipment_Ports.Items.Count - 1].BackColor = Color.LightSkyBlue;
                                    //myeList.ClickPort(Equipment_Ports);
                                }
                            }));
                            
                        }//));
                    }
                    //Equipment_Ports.Items.AddRange(portids.Values.ToArray());
                    Invoke(new Action(() =>
                    {
                        if (equipmentRow.IP != "")
                        {
                            Controls.Add(linkLabel1);
                            linkLabel1.LinkClicked += LinkLabel1_LinkClicked;
                        }
                        //Equipment_Ports.Sorted = true;
                        Equipment_Name.Text = Text = equipmentRow.Оборудование;
                        Equipment_EO.Text = equipmentRow.EO == 0 ? "" : equipmentRow.EO.ToString();
                        Equipment_MAC.Text = equipmentRow.Mac;
                        Equipment_IP.Text = equipmentRow.IP;
                    }));
                });
            }
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //e.Link.Name = @"-telnet ipatov@" + ((Equipment)((LinkLabel)sender).Parent).Equipment_IP.Text;
            
            using (Cmd dude = new Cmd(((Equipment)((LinkLabel)sender).Parent).Equipment_IP.Text, "ipatov", "RbhbkkBgfnjd"))
            {
                
                TabPage tabPageConsole = new TabPage(((Equipment)((LinkLabel)sender).Parent).Equipment_IP.Text);
                TabControl tabControl = ((TabControl)((TabPage)((Equipment)((LinkLabel)sender).Parent).Parent).Parent);
                tabControl.TabPages.Add(tabPageConsole);
                tabControl.SelectedTab = tabPageConsole;
                var ports = dude.GetPorts();
                TabControl tabControl1 = new TabControl();
                tabControl1.Parent = tabPageConsole;
                tabControl1.Dock = DockStyle.Fill;
                tabControl1.Alignment = TabAlignment.Left;
                tabControl1.SizeMode = TabSizeMode.Fixed;
                tabControl1.ItemSize = new Size(32, 50);
                tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
                tabControl1.DrawItem += TabControl1_DrawItem;
                foreach (var item in ports)
                {
                    TabPage tabPage = new TabPage(item);
                    tabControl1.TabPages.Add(tabPage);
                    tabPage.Enter += TabPage_Enter;

                    
                    tabPage.Tag = dude.GetPortConfig(item);

                    


                    
                }



            }
        }

        private void TabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = ((TabControl)sender).TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = ((TabControl)sender).GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {

                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.Black);
                //g.FillRectangle(Brushes.Gray, e.Bounds);
            }
            else
            {
                _textBrush = new SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            // Use our own font.
            Font _tabFont = new Font("Arial", 10.0f, FontStyle.Bold, GraphicsUnit.Pixel);

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

        private void TabPage_Enter(object sender, EventArgs e)
        {
            Interface @interface = new Interface();
            Task.Run(new Action(() =>
            {
                string description;
                /// <summary>
                /// acces: no mdix auto, no cdp enable, switchport port-security, switchport port-security mac-address sticky, mac
                /// trunk: switchport nonegotiate, udld port
                /// </summary>
                string sw_mode = ((List<string>)((TabPage)sender).Tag).Find(q => q.Contains("switchport mode ")).Remove(0, "switchport mode ".Length);
                int native_vlan;
                int[] vlans;
                bool sw_po;
                bool sw_po_mac_st;
                List<string> mac = new List<string>();
                bool sh;
                bool sp_bpduguard;
                string media_type;
                bool udld_port;
                string duplex;
                string speed;
                try
                {
                    description = ((List<string>)((TabPage)sender).Tag).Find(q => q.Contains("description ")).Remove(0, "description ".Length);
                }
                catch (Exception)
                {
                    description = "";
                }
                try
                {
                    sw_po = ((List<string>)((TabPage)sender).Tag).Find(q => q.Trim() == "switchport port-security").Contains("switchport port-security");
                }
                catch (Exception)
                {
                    sw_po = false;
                }
                try
                {
                    sw_po_mac_st = ((List<string>)((TabPage)sender).Tag).Find(q => q.Trim() == "switchport port-security mac-address sticky").Contains("switchport port-security mac-address sticky");
                }
                catch (Exception)
                {
                    sw_po_mac_st = false;
                }
                try
                {
                    mac = ((List<string>)((TabPage)sender).Tag).FindAll(q => q.Contains(" mac-address "));
                    for (int i = 0; i < mac.Count; i++)
                    {
                        mac[i] = mac[i].Remove(0, mac[i].IndexOf(" mac-address ") + " mac-address ".Length);
                        mac[i] = mac[i].Remove(0, mac[i].IndexOf("sticky ") + "sticky ".Length);
                    }
                    mac.Remove("");
                }
                catch (Exception)
                {
                    mac = new List<string>();
                }
                try
                {
                    sp_bpduguard = ((List<string>)((TabPage)sender).Tag).Find(q => q.Contains(" bpduguard ")).Contains(" bpduguard ");
                }
                catch (Exception)
                {
                    sp_bpduguard = false;
                }
                try
                {
                    udld_port = ((List<string>)((TabPage)sender).Tag).Find(q => q.Contains("udld port")).Contains("udld port");
                }
                catch (Exception)
                {
                    udld_port = false;
                }
                try
                {
                    var ss = ((List<string>)((TabPage)sender).Tag).Find(q => q.Contains("duplex "));
                    duplex = ss.Remove(0, ss.IndexOf("duplex ") + 1);
                    duplex = duplex == "" ? "auto" : duplex;
                }
                catch (Exception)
                {
                    duplex = "auto";
                }
                try
                {
                    var ss = ((List<string>)((TabPage)sender).Tag).Find(q => q.Contains("media-type "));
                    media_type = ss.Remove(0, ss.IndexOf("media-type ") + 1);
                }
                catch (Exception)
                {
                    media_type = "auto";
                }
                try
                {
                    sh = true;
                    sh = !((List<string>)((TabPage)sender).Tag).Find(q => q.Contains("shutdown")).Contains("shutdown");
                }
                catch (Exception)
                {
                    sh = true;
                }
                try
                {
                    var ss = ((List<string>)((TabPage)sender).Tag).Find(q => q.Contains(" allowed vlan ") || q.Contains(" access vlan "));
                    var vlanss = ss.Remove(0, ss.IndexOf(" vlan ") + " vlan ".Length).Split(',');
                    vlans = new int[vlanss.Length];
                    for (int i = 0; i < vlanss.Length; i++)
                    {
                        vlans[i] = Convert.ToInt32(vlanss[i]);
                    }
                }
                catch (Exception)
                {
                    vlans = new int[0];
                }
                try
                {
                    var ss = ((List<string>)((TabPage)sender).Tag).Find(q => q.Contains(" native vlan "));
                    native_vlan = Convert.ToInt32(ss.Remove(0, ss.IndexOf(" native vlan ") + " native vlan ".Length));
                }
                catch (Exception)
                {
                    native_vlan = 0;
                }
                try
                {
                    var ss = ((List<string>)((TabPage)sender).Tag).Find(q => q.Contains("speed "));
                    speed = ss.Remove(0, ss.IndexOf("speed ") + "speed ".Length);
                }
                catch (Exception)
                {
                    speed = "auto";
                }
                @interface = new Interface() { speed = speed, port = ((List<string>)((TabPage)sender).Tag)[0].Remove(0, "interface ".Length), description = description, duplex = duplex, mac = mac, media_type = media_type, native_vlan = native_vlan, sh = sh, sp_bpduguard = sp_bpduguard, sw_mode = sw_mode, sw_po = sw_po, sw_po_mac_st = sw_po_mac_st, udld_port = udld_port, vlans = vlans };
                //streamWriter.WriteLine("sh ru in " + item);
                Label label1 = new Label
                {
                    Text = "Enabled",
                    Location = new Point(6, 12)
                };
                ToggleSwitch enabled = new ToggleSwitch
                {
                    Checked = @interface.sh,
                    Location = new Point(label1.Right + 5, 6)
                };
                if (sw_mode == "access")
                {

                }
                else if (sw_mode == "trunk")
                {

                }
                Invoke(new Action(() =>
                {
                    Port port;
                    if (((TabPage)sender).Controls.Count == 0)
                    {
                        port = new Port();
                        ((TabPage)sender).Controls.Add(port);
                    }
                    else
                    {
                        port = ((TabPage)sender).Controls[0] as Port;
                    }
                    port._description.Text = @interface.description;
                    port._access.Checked = @interface.sw_mode == "trunk";
                    port._enable.Checked = @interface.sh;
                }));
            }));

        }

        private void Dude_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine(e.Data);
            if (e.Data== " --More--         ")
            {
                //((Process)sender).StandardInput.WriteLine(@"\n");
            }
        }

        private void InitializeComponent()
        {
            //Invoke(new Action(() =>
            //{
                Equipment_Ports = new ListView();
                label6 = new Label();
                Equipment_IP = new TextBox();
                linkLabel1 = new LinkLabel();
                label5 = new Label();
                Equipment_MAC = new TextBox();
                label4 = new Label();
                House = new TextBox();
                label3 = new Label();
                Room = new TextBox();
                label2 = new Label();
                Equipment_EO = new TextBox();
                label1 = new Label();
                Equipment_Name = new TextBox();
                SuspendLayout();
                // 
                // This
                // 
                Controls.Add(Equipment_Ports);
                Controls.Add(label6);
                Controls.Add(Equipment_IP);
                Controls.Add(label5);
                Controls.Add(Equipment_MAC);
                Controls.Add(label4);
                Controls.Add(House);
                Controls.Add(label3);
                Controls.Add(Room);
                Controls.Add(label2);
                Controls.Add(Equipment_EO);
                Controls.Add(label1);
                Controls.Add(Equipment_Name);
                Location = new Point(3, 3);
                Margin = new Padding(0);
                Name = "groupBox1";
                Padding = new Padding(0);
                Size = new Size(213, 365);
                TabIndex = 0;
                TabStop = false;
                Text = "Модель оборудования:";
                // 
                // Equipment_Ports
                // 
                //Equipment_Ports.FormattingEnabled = true;
                Equipment_Ports.Location = new Point(6, 146);
                Equipment_Ports.Name = "Equipment_Ports";
                Equipment_Ports.Size = new Size(195, 212);
                Equipment_Ports.TabIndex = 1;
                Equipment_Ports.View = View.Details;
                Equipment_Ports.Columns.Add("col1", "");
                Equipment_Ports.Columns.Add("col1", "");
                Equipment_Ports.Columns[0].Width = 60;
                Equipment_Ports.Columns[1].Width = 110;
                Equipment_Ports.FullRowSelect = true;
                Equipment_Ports.HeaderStyle = ColumnHeaderStyle.None;
                Equipment_Ports.Alignment = ListViewAlignment.Left;
                Equipment_Ports.ListViewItemSorter = new AlphanumComparatorFast();
                //Equipment_Ports.MouseDoubleClick += Equipment_Ports_MouseDoubleClick;
                // 
                // label6
                // 
                label6.AutoSize = true;
                label6.Location = new Point(3, 123);
                label6.Name = "label6";
                label6.Size = new Size(20, 13);
                label6.TabIndex = 11;
                label6.Text = "IP:";
                // 
                // Equipment_IP
                // 
                Equipment_IP.Location = new Point(29, 120);
                Equipment_IP.Name = "Equipment_IP";
                Equipment_IP.Size = new Size(90, 20);
                Equipment_IP.TabIndex = 10;
                // 
                // linkLabel1
                // 
                this.linkLabel1.AutoSize = true;
                this.linkLabel1.Location = new Point(123, 123);
                this.linkLabel1.Name = "linkLabel1";
                this.linkLabel1.Size = new Size(37, 13);
                this.linkLabel1.TabIndex = 3;
                this.linkLabel1.TabStop = true;
                this.linkLabel1.Text = "Telnet";
                // 
                // label5
                // 
                label5.AutoSize = true;
                label5.Location = new Point(3, 97);
                label5.Name = "label5";
                label5.Size = new Size(33, 13);
                label5.TabIndex = 9;
                label5.Text = "MAC:";
                // 
                // Equipment_MAC
                // 
                Equipment_MAC.Location = new Point(42, 94);
                Equipment_MAC.Name = "Equipment_MAC";
                Equipment_MAC.Size = new Size(159, 20);
                Equipment_MAC.TabIndex = 8;
                // 
                // label4
                // 
                label4.AutoSize = true;
                label4.Location = new Point(105, 71);
                label4.Name = "label4";
                label4.Size = new Size(46, 13);
                label4.TabIndex = 7;
                label4.Text = "Корпус:";
                // 
                // House
                // 
                House.Location = new Point(157, 68);
                House.Name = "House";
                House.Size = new Size(44, 20);
                House.TabIndex = 6;
                // 
                // label3
                // 
                label3.AutoSize = true;
                label3.Location = new Point(3, 71);
                label3.Name = "label3";
                label3.Size = new Size(46, 13);
                label3.TabIndex = 5;
                label3.Text = "Кабнет:";
                // 
                // Room
                // 
                Room.Location = new Point(55, 68);
                Room.Name = "Room";
                Room.Size = new Size(44, 20);
                Room.TabIndex = 4;
                // 
                // label2
                // 
                label2.AutoSize = true;
                label2.Location = new Point(3, 45);
                label2.Name = "label2";
                label2.Size = new Size(114, 13);
                label2.TabIndex = 3;
                label2.Text = "Инвентарный номер:";
                // 
                // Equipment_EO
                // 
                Equipment_EO.Location = new Point(123, 42);
                Equipment_EO.Name = "Equipment_EO";
                Equipment_EO.Size = new Size(78, 20);
                Equipment_EO.TabIndex = 2;
                // 
                // label1
                // 
                label1.AutoSize = true;
                label1.Location = new Point(3, 19);
                label1.Name = "label1";
                label1.Size = new Size(60, 13);
                label1.TabIndex = 1;
                label1.Text = "Название:";
                // 
                // Equipment_Name
                // 
                Equipment_Name.Location = new Point(69, 16);
                Equipment_Name.Name = "Equipment_Name";
                Equipment_Name.Size = new Size(132, 20);
                Equipment_Name.TabIndex = 0;
            //}));
        }

        private void Equipment_Ports_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }
    }

    public class EList : List<Equipment>
    {
        Control parent = new Control();
        DataSet2ReadOnly.mainRow mainRow = null;

        public EList(Control Parent)
        {
            parent = Parent;
            //this[0].Equipment_Ports.SelectedIndexChanged += Equipment_Ports_SelectedIndexChanged;
        }

        private void Equipment_Ports_SelectedIndexChanged(object sender, EventArgs e)
        {
            var currentEquipment = ((Equipment)((ListView)sender).Parent);
            DataSet2ReadOnly.mainRow nmainRow = null;
            foreach (var item in currentEquipment.portids)
            {
                for (int i = 0; i < ((ListView)sender).Items.Count; i++)
                {
                    if (((ListView)sender).Items[i].BackColor == Color.LightSkyBlue)
                    {
                        ((ListView)sender).Items[i].BackColor = ((Color)((ListView)sender).Items[i].Tag);
                    }
                }
                if (item.Value == ((ListView)sender).FocusedItem.Text)
                {
                    ((ListView)sender).FocusedItem.BackColor = Color.Blue;
                    DataSet2ReadOnlyTableAdapters.mainTableAdapter mainTableAdapter = new DataSet2ReadOnlyTableAdapters.mainTableAdapter();
                    var mainTable = mainTableAdapter.GetData(item.Key);
                    try
                    {
                        nmainRow = mainTable[0];
                    }
                    catch (Exception)
                    {
                    }
                    //currentPort = item.Key;
                    break;
                }
            }
            if (nmainRow == null)
            {
                return;
            }
            else
            if (mainRow == null)
            {
                mainRow = nmainRow;
                generaitIT(mainRow);
                //ClickPort(equipment.Equipment_Ports);
            }else
            if (mainRow.ItemArray[0].ToString() != nmainRow.ItemArray[0].ToString())
            {
                mainRow = nmainRow;
                generaitIT(mainRow);
                //ClickPort(equipment.Equipment_Ports);
            }
            /*if (!(((ListBox)sender).SelectedItem is null))
            {
                ClickPort((ListBox)sender);
            }*/
        }
        /*
        public void ClickPort(ListBox sender)
        {
            var currentEquipment = (sender.Parent as Equipment);
            var ID = currentEquipment.portids.First(q => q.Value == sender.SelectedItem.ToString().Substring(0, 10).Trim()).Key;
            DataSet1TableAdapters.PortTableAdapter portTableAdapter = new DataSet1TableAdapters.PortTableAdapter();
            var portRow = portTableAdapter.GetDataByID(ID)[0];
            DataSet1TableAdapters.EquipmentTableAdapter equipmentTableAdapter = new DataSet1TableAdapters.EquipmentTableAdapter();
            var equipmentRow = equipmentTableAdapter.GetDataByID(portRow.ID_Оборудования)[0];
            DataSet1TableAdapters.mainTableAdapter mainTableAdapter = new DataSet1TableAdapters.mainTableAdapter();
            var mainTable = mainTableAdapter.GetDataByPortID(ID, equipmentRow.ID_Шкафа_комнаты);
            DataSet1.mainRow root = null;
            bool check = false;
            try
            {
                root = mainTable.First(q => q.Куда == ID);
            }
            catch (Exception)
            {
                root = null;
            }
            if (!(root is null))
            {
                int i = IndexOf(currentEquipment);
                Equipment previousequipment;
                int previousPort = 0;
                if (--i < 0)
                {
                    i = 0;
                }
                else
                {
                    previousequipment = this[i];
                    foreach (var item in this[i].portids)
                    {
                        if (item.Value == this[i].Equipment_Ports.SelectedItem.ToString().Remove(20).Trim())
                        {
                            previousPort = item.Key;
                            break;
                        }
                    }
                    //previousPort = this[i].portids.First(q => q.Value == this[i].Equipment_Ports.SelectedItem.ToString().Remove(20).Trim()).Key;
                }
                int currentPort;
                foreach (var item in currentEquipment.portids)
                {
                    if (item.Value == currentEquipment.Equipment_Ports.SelectedItem.ToString().Remove(20).Trim())
                    {
                        currentPort = item.Key;
                        break;
                    }
                }
                //currentPort = currentEquipment.portids.First(q => q.Value == currentEquipment.Equipment_Ports.SelectedItem.ToString().Remove(20).Trim()).Key;
                if (previousPort != root.Откуда)
                {
                    check = true;
                    //EList neList = new EList();
                    //neList.Ad(this.Parent, root.Откуда, root.Откуда_кабинет_шкаф);
                    //neList.Ad(this.Parent, this);
                    Re(i);
                    Equipment newequipment = new Equipment(myList: this, index:i, PORT_id: root.Откуда, ROOM_id: root.Откуда_кабинет_шкаф, equipmentID: portTableAdapter.GetDataByID(root.Откуда)[0].ID_Оборудования)
                    {
                        Parent = parent,
                        Visible = true,
                        ContextMenuStrip = Form1.contextMenuStrip1
                    };
                    Ad(i, newequipment);
                    //newequipment.Equipment_Ports.SelectedItem = newequipment.portids[root.Откуда];
                    //myeList.Insert(i, newequipment);
                    //myeList[i].myeList = myeList;
                }
            }
            else
            {
                while (IndexOf(currentEquipment) > 0)
                {
                    Re(0);
                    Update_Position();
                }
            }
            if (!check)
            {
                try
                {
                    root = mainTable.First(q => q.Откуда == ID);
                }
                catch (Exception)
                {
                    root = null;
                }
                if (!(root is null))
                {
                    int i = IndexOf(currentEquipment);
                    int nextPort = 0;
                    if (++i < Count)
                    {
                        nextPort = this[i].portids.First(q => q.Value == this[i].Equipment_Ports.SelectedItem.ToString().Remove(20).Trim()).Key;

                    }
                    int currentPort = currentEquipment.portids.First(q => q.Value == currentEquipment.Equipment_Ports.SelectedItem.ToString().Substring(0, 20).Trim()).Key;
                    if (nextPort != root.Куда)
                    {
                        while (Count > i)
                        {
                            Re(i);
                        }
                        Equipment newequipment = new Equipment(myList: this, index:i, PORT_id: root.Куда, ROOM_id: root.Куда_кабинет_шкаф, equipmentID: portTableAdapter.GetDataByID(root.Куда)[0].ID_Оборудования);
                        Ad(i, newequipment);
                        //newequipment.Equipment_Ports.SelectedItem = newequipment.portids[root.Куда];
                        //myeList.Ad(this.Parent, newequipment);
                        //myeList[myeList.FindIndex(q => q == newequipment)].myeList = myeList;
                    }
                }
            }
        }
        */
        private void generaitIT(DataSet2ReadOnly.mainRow mainRow)
        {
            if (mainRow is null)
            {
                return;
            }
            if (Count>0)
            {
                ReAll();
            }
            foreach (var item in mainRow.ItemArray)
            {
                if (item.ToString() != "")
                {
                    Task.Run(() => Ad(index: mainRow.ItemArray.ToList().IndexOf(item), PORT: Convert.ToInt32(item.ToString())));
                }
            }
        }

        public void Update_Position()
        {
            parent.Invoke(new Action(() =>
            {
                this.OrderBy(q => q.index);
                for (int i = 0; i < Count; i++)
                {
                    this[i].Location = new Point(3 + 213 * this[i].index, 3);
                }
            }));
        }

        public void Ad(int index, int PORT = 0, int ROOM = 0, int EQUIPMENT = 0)
        {
            Equipment equipment = new Equipment(myList: this, index: index, PORT_id: PORT, ROOM_id: ROOM, equipmentID: EQUIPMENT);
            Ad(index: index, equipment: equipment);
        }

        public void Ad(int index, Equipment equipment)
        {
            Add(equipment);
            parent.Invoke(new Action(() =>
            {
                equipment.Visible = true;
                equipment.ContextMenuStrip = Form1.contextMenuStrip1;
                equipment.Equipment_Ports.SelectedIndexChanged += Equipment_Ports_SelectedIndexChanged;
                parent.Controls.Add(equipment);
                if (equipment.Equipment_Ports.SelectedIndices.Count > 0)
                {
                    DataSet2ReadOnly.mainRow nmainRow = null;
                    foreach (var item in equipment.portids)
                    {
                        if (item.Value == equipment.Equipment_Ports.SelectedItems[0].ToString().Remove(20).Trim())
                        {
                            DataSet2ReadOnlyTableAdapters.mainTableAdapter mainTableAdapter = new DataSet2ReadOnlyTableAdapters.mainTableAdapter();
                            var mainTable = mainTableAdapter.GetData(item.Key);
                            nmainRow = mainTable[0];
                            //currentPort = item.Key;
                            break;
                        }
                    }
                    if (mainRow.ItemArray[0].ToString() != nmainRow.ItemArray[0].ToString())
                    {
                        mainRow = nmainRow;
                        generaitIT(mainRow);
                        //ClickPort(equipment.Equipment_Ports);
                    }
                }
                //*/
            }));
            Update_Position();
        }
        /*
        public void In(int inn, int PORT = 0, int ROOM = 0, int EQUIPMENT = 0)
        {
            Equipment equipment = new Equipment(myList: this, index:inn, PORT_id: PORT, ROOM_id: ROOM, equipmentID: EQUIPMENT);
            In(inn, equipment);
        }

        public void In(int inn, Equipment equipment)
        {
            equipment.Visible = true;
            equipment.ContextMenuStrip = Form1.contextMenuStrip1;
            Update_Position();
            parent.Invoke(new Action(() =>
            {
                equipment.Equipment_Ports.SelectedIndexChanged += Equipment_Ports_SelectedIndexChanged;
                parent.Controls.Add(equipment);
                Insert(inn-1, equipment);
            }));
            if (equipment.Equipment_Ports.SelectedIndex >= 0)
            {
                DataSet2ReadOnly.mainRow nmainRow = null;
                foreach (var item in equipment.portids)
                {
                    if (item.Value == equipment.Equipment_Ports.SelectedItem.ToString().Remove(20).Trim())
                    {
                        DataSet2ReadOnlyTableAdapters.mainTableAdapter mainTableAdapter = new DataSet2ReadOnlyTableAdapters.mainTableAdapter();
                        var mainTable = mainTableAdapter.GetData(item.Key);
                        nmainRow = mainTable[0];
                        //currentPort = item.Key;
                        break;
                    }
                }
                if (mainRow.ItemArray[0].ToString() != nmainRow.ItemArray[0].ToString())
                {
                    mainRow = nmainRow;
                    generaitIT(mainRow);
                    //ClickPort(equipment.Equipment_Ports);
                }
            }
        }
        */
        public void Re(Equipment equipment)
        {
            int i = FindIndex(q => q == equipment);
            Re(i);
        }

        public void Re(int equipmentID)
        {
            int i = this[equipmentID].index;
            /*while (i < Count)
            {
                try
                {
                    Equipment e = Find(q => q.index == i + 1);
                    e.index = i++;
                }
                catch (Exception)
                {
                }
            }*/
            this[equipmentID].Dispose();
            RemoveAt(equipmentID);
            Update_Position();
        }

        public void ReAll()
        {
            while (this.Count>0)
            {
                Re(Count-1);
            }
        }
    }

    public class AlphanumComparatorFast : IComparer
    {
        public int Compare(object x, object y)
        {
            string s1 = x as string;
            if (s1 == null)
            {
                return 0;
            }
            string s2 = y as string;
            if (s2 == null)
            {
                return 0;
            }

            int len1 = s1.Length;
            int len2 = s2.Length;
            int marker1 = 0;
            int marker2 = 0;

            // Walk through two the strings with two markers.
            while (marker1 < len1 && marker2 < len2)
            {
                char ch1 = s1[marker1];
                char ch2 = s2[marker2];

                // Some buffers we can build up characters in for each chunk.
                char[] space1 = new char[len1];
                int loc1 = 0;
                char[] space2 = new char[len2];
                int loc2 = 0;

                // Walk through all following characters that are digits or
                // characters in BOTH strings starting at the appropriate marker.
                // Collect char arrays.
                do
                {
                    space1[loc1++] = ch1;
                    marker1++;

                    if (marker1 < len1)
                    {
                        ch1 = s1[marker1];
                    }
                    else
                    {
                        break;
                    }
                } while (char.IsDigit(ch1) == char.IsDigit(space1[0]));

                do
                {
                    space2[loc2++] = ch2;
                    marker2++;

                    if (marker2 < len2)
                    {
                        ch2 = s2[marker2];
                    }
                    else
                    {
                        break;
                    }
                } while (char.IsDigit(ch2) == char.IsDigit(space2[0]));

                // If we have collected numbers, compare them numerically.
                // Otherwise, if we have strings, compare them alphabetically.
                string str1 = new string(space1);
                string str2 = new string(space2);

                int result;

                if (char.IsDigit(space1[0]) && char.IsDigit(space2[0]))
                {
                    int thisNumericChunk = int.Parse(str1);
                    int thatNumericChunk = int.Parse(str2);
                    result = thisNumericChunk.CompareTo(thatNumericChunk);
                }
                else
                {
                    result = str1.CompareTo(str2);
                }

                if (result != 0)
                {
                    return result;
                }
            }
            return len1 - len2;
        }
    }

}
