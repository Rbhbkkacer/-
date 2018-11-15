﻿using System;
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
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox Equipment_Name;
        private TextBox Equipment_IP;
        private TextBox Equipment_MAC;
        private TextBox House;
        private TextBox Room;
        private TextBox Equipment_EO;
        private ListBox Equipment_Ports;

        public Equipment(int PORT = 0,int ROOM = 0)
        {
            InitializeComponent();
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
    }

    public class EList : List<Equipment>
    {
        public EList()
        {

        }

        private void Update_Position()
        {
            for (int i = 0; i < Count; i++)
            {
                this[i].Location = new Point(3 + 213 * i, 3);
            }
        }

        public void Ad(Control parent)
        {
            Equipment e = new Equipment() { Parent = parent, Visible = true, ContextMenuStrip = Form1.contextMenuStrip1 };
            Add(e);
            int i = FindIndex((Equipment p) => { return p == e; });
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