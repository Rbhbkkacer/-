using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Кабельный_журнал
{
    public class Equipment : GroupBox
    {
        public EList myeList;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        public TextBox Equipment_Name;
        public TextBox Equipment_IP;
        public TextBox Equipment_MAC;
        public TextBox House;
        public TextBox Room;
        public TextBox Equipment_EO;
        public ListBox Equipment_Ports;
        public Dictionary<int, string> portids = new Dictionary<int, string>();
        public int roomid;

        public Equipment(EList myList, int PORT_id = 0,int ROOM_id = 0)
        {
            myeList = myList;
            InitializeComponent();
            if (ROOM_id>0)
            {
                DataSet2ReadOnlyTableAdapters.DataTableEquipmentAdapter dataTableEquipmentAdapter = new DataSet2ReadOnlyTableAdapters.DataTableEquipmentAdapter();
                DataSet1TableAdapters.RoomTableAdapter roomTableAdapter = new DataSet1TableAdapters.RoomTableAdapter();
                DataSet1.RoomDataTable roomTable = roomTableAdapter.GetData();
                var roomRow = roomTable.FindByID(ROOM_id);
                Room.Text = roomRow.Шкаф_кабинет;
                roomid = roomRow.ID;
                DataSet1TableAdapters.HomeTableAdapter homeTableAdapter = new DataSet1TableAdapters.HomeTableAdapter();
                DataSet1.HomeDataTable homeTable = homeTableAdapter.GetData();
                var homeRow = homeTable.FindByID(roomRow.ID_Корпуса);
                House.Text = homeRow.___корпуса;
            }

            if (PORT_id>0)
            {
                DataSet1TableAdapters.PortTableAdapter portTableAdapter = new DataSet1TableAdapters.PortTableAdapter();
                var portTable = portTableAdapter.GetDataByID(PORT_id);
                var portRow = portTable.FindByID(PORT_id);
                var EquipmentID = portRow.ID_Оборудования;
                var portCollection = portTableAdapter.GetDataByequipment(EquipmentID).Rows;
                foreach (DataSet1.PortRow item in portCollection)
                {
                    portids.Add(item.ID, item.Порт);
                    
                }
                Equipment_Ports.Items.AddRange(portids.Values.ToArray());
                Equipment_Ports.Sorted = true;
            }
        }

        private void InitializeComponent()
        {
            Equipment_Ports = new ListBox();
            label6 = new Label();
            Equipment_IP = new TextBox();
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
            Equipment_Ports.FormattingEnabled = true;
            Equipment_Ports.Location = new Point(6, 146);
            Equipment_Ports.Name = "Equipment_Ports";
            Equipment_Ports.Size = new Size(195, 212);
            Equipment_Ports.TabIndex = 1;
            Equipment_Ports.MouseDoubleClick += Equipment_Ports_MouseDoubleClick;
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
            Equipment_IP.Size = new Size(172, 20);
            Equipment_IP.TabIndex = 10;
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
            House.Text = "1052";
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
            Room.Text = "ST3-2";
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
        }

        private void Equipment_Ports_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var ID = portids.First(q => q.Value == ((ListBox)sender).SelectedItem.ToString()).Key;
            DataSet1TableAdapters.PortTableAdapter portTableAdapter = new DataSet1TableAdapters.PortTableAdapter();
            var portRow = portTableAdapter.GetDataByID(ID).FindByID(ID);
            DataSet1TableAdapters.EquipmentTableAdapter equipmentTableAdapter = new DataSet1TableAdapters.EquipmentTableAdapter();
            var equipmentTable = equipmentTableAdapter.GetData();
            var equipmentRow = equipmentTable.FindByID(portRow.ID_Оборудования);
            DataSet1TableAdapters.mainTableAdapter mainTableAdapter = new DataSet1TableAdapters.mainTableAdapter();
            var mainTable = mainTableAdapter.GetDataByPortID(ID, equipmentRow.ID_Шкафа_комнаты);
            DataSet1.mainRow root = null;
            try
            {
                root = mainTable.First(q => q.Куда == ID);
            }
            catch (Exception)
            {
            }
            if (!(root is null))
            {
                EList neList = new EList();
                //neList.Ad(this.Parent, root.Откуда, root.Откуда_кабинет_шкаф);
                //neList.Ad(this.Parent, this);
                int i = myeList.FindIndex(q => q == this);
                try
                {
                    myeList.Re(i - 1);
                }
                catch (Exception)
                {
                }
                Equipment newequipment = new Equipment(myeList, root.Откуда, root.Откуда_кабинет_шкаф) {
                    Parent = this.Parent,
                    Visible = true,
                    ContextMenuStrip = Form1.contextMenuStrip1 };
                newequipment.Equipment_Ports.SelectedItem = newequipment.portids[root.Откуда];
                myeList.Insert(i, newequipment);
                myeList.Update_Position();
            }
            else
            {
                try
                {
                    root = mainTable.First(q => q.Откуда == ID);
                }
                catch (Exception)
                {
                }
                while (myeList.Count > myeList.FindIndex(q => q == this) + 1)
                {
                    myeList.Re(myeList.FindIndex(q => q == this) + 1);
                }
                Equipment newequipment = new Equipment(myeList, root.Куда, root.Куда_кабинет_шкаф)
                {
                    Parent = this.Parent,
                    Visible = true,
                    ContextMenuStrip = Form1.contextMenuStrip1
                };
                newequipment.Equipment_Ports.SelectedItem = newequipment.portids[root.Куда];
                myeList.Ad(this.Parent, newequipment);
                
                
            }
        }
    }

    public class EList : List<Equipment>
    {
        public EList()
        {

        }

        public void Update_Position()
        {
            for (int i = 0; i < Count; i++)
            {
                this[i].Location = new Point(3 + 213 * i, 3);
            }
        }

        public void Ad(Control parent, int PORT = 0, int ROOM = 0)
        {
            Equipment e = new Equipment(this, PORT, ROOM) { Parent = parent, Visible = true, ContextMenuStrip = Form1.contextMenuStrip1 };
            Add(e);
            int i = FindIndex((Equipment p) => { return p == e; });
            this[i].Location = new Point(3 + 213 * i, 3);
        }

        public void Ad(Control parent, Equipment equipment)
        {
            equipment.Parent = parent;
            equipment.Visible = true;
            equipment.ContextMenuStrip = Form1.contextMenuStrip1;
            Add(equipment);
            int i = FindIndex((Equipment p) => { return p == equipment; });
            this[i].Location = new Point(3 + 213 * i, 3);
        }

        public void Re(Equipment equipment)
        {
            Remove(equipment);
            equipment.Dispose();
            Update_Position();
        }

        public void Re(int equipmentID)
        {
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
}
