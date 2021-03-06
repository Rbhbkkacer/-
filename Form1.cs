﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Кабельный_журнал
{
    public partial class Form1 : Form
    {
        public static ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem изменитьToolStripMenuItem;
        private ToolStripMenuItem удалитьToolStripMenuItem;
        DataTable table;

        public EList eList;
        public Form1()
        {
            InitializeComponent();
            ((TextBox)toolStripTextBox2.Control).UseSystemPasswordChar = true;
            InitializeContextMenuStrip();
            eList = new EList(tabPage1);
            toolStripTextBox1.Text = Properties.Settings.Default.Login;
            toolStripTextBox2.Text = Properties.Settings.Default.Password;
            tabPage3.Dispose();
            tabPage4.Dispose();









        }

        private void InitializeContextMenuStrip()
        {
            contextMenuStrip1 = new ContextMenuStrip();
            изменитьToolStripMenuItem = new ToolStripMenuItem();
            удалитьToolStripMenuItem = new ToolStripMenuItem();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] {
            изменитьToolStripMenuItem,
            удалитьToolStripMenuItem});
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.RenderMode = ToolStripRenderMode.System;
            contextMenuStrip1.ShowImageMargin = false;
            contextMenuStrip1.Size = new Size(104, 48);
            // 
            // изменитьToolStripMenuItem
            // 
            this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.изменитьToolStripMenuItem.Text = "Изменить";
            this.изменитьToolStripMenuItem.Click += new System.EventHandler(this.изменитьToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Equipment equipmentOriginal;
            var s = ((ContextMenuStrip)(sender as ToolStripMenuItem).Owner).SourceControl;
            equipmentOriginal = s as Equipment;

            TabPage tabPageEdit = new TabPage("Изменить");
            tabControl1.TabPages.Add(tabPageEdit);
            Equipment equipmentEdit1;
            EList eList = new EList(tabPageEdit);

            if (equipmentOriginal.portids == null)
            {
                equipmentEdit1 = new Equipment(myList: eList, index:eList.Count, PORT_id: 0, ROOM_id: equipmentOriginal.roomid, equipmentID: equipmentOriginal.equipmentid);
            }
            else
            {
                equipmentEdit1 = new Equipment(myList: eList, index: eList.Count, PORT_id: equipmentOriginal.portids.First(
                    pair => pair.Value == (equipmentOriginal.Equipment_Ports.Text == null ? "" : equipmentOriginal.Equipment_Ports.Text)
                    ).Key, ROOM_id: equipmentOriginal.roomid, equipmentID: equipmentOriginal.equipmentid);
            }
            
            eList.Ad(eList.Count, equipmentEdit1);
            tabPageEdit.Select();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                eList.Re(((ContextMenuStrip)(sender as ToolStripMenuItem).Owner).SourceControl as Equipment);
            }
            catch (Exception)
            {
                ((ContextMenuStrip)(sender as ToolStripMenuItem).Owner).SourceControl.Dispose();
            }
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string home = textBox2.Text;
            string room = textBox3.Text;
            int EO = textBox4.Text.Trim() == "" ? 0 : Convert.ToInt32(textBox4.Text.Trim());
            string equi = textBox6.Text;
            string mac_ = textBox5.Text;
            DataSet2ReadOnlyTableAdapters.DataTableEquipmentAdapter dataTableEquipmentAdapter = new DataSet2ReadOnlyTableAdapters.DataTableEquipmentAdapter();
            do
            {
                try
                {
                    dataGridView1.DataSource = dataTableEquipmentAdapter.GetData(home, room, EO, mac_, equi);
                }
                catch (Exception)
                {
                    
                }
            } while (dataGridView1.DataSource==null);
            
            

            dataGridView1.Columns[7].Visible = false;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            /* ((DataGridView)sender).SelectedRows[0].Cells[0].Value.ToString()
             * 0 - Корпус
             * 1 - Кабинет
             * 2 - EO
             * 3 - Название
             * 4 - MAC
             * 5 - IP
             * 6 - Примечание
             * 7 - ID
             */
            DataSet1TableAdapters.PortTableAdapter portTableAdapter = new DataSet1TableAdapters.PortTableAdapter();
            var portTable = portTableAdapter.GetData();
            var portRow = portTable.First(q => q.ID_Оборудования == Convert.ToInt32(((DataGridView)sender).SelectedRows[0].Cells[7].Value.ToString()));
            DataSet1TableAdapters.EquipmentTableAdapter equipmentTableAdapter = new DataSet1TableAdapters.EquipmentTableAdapter();
            var equipmentRow = equipmentTableAdapter.GetDataByID(Convert.ToInt32(((DataGridView)sender).SelectedRows[0].Cells[7].Value.ToString()))[0];
            eList.ReAll();
            Equipment equipmentCurrent = new Equipment(myList: eList, index:0, ROOM_id: equipmentRow.ID_Шкафа_комнаты, equipmentID: portRow.ID_Оборудования);
            equipmentCurrent.Parent = tabPage1;
            eList.Ad(0, equipmentCurrent);
            //eList.Ad(tabPage1, equipmentCurrent);
            //eList[eList.FindIndex(q => q == equipmentCurrent)].myeList = eList;
            tabControl1.SelectedTab = tabPage1;

        }

        private void Equipment_Ports_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Equipment_Ports_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toggleSwitch2_CheckedChanged(object sender, EventArgs e)
        {
            if (((ToggleSwitch)sender).Checked)
            {

            }
            else
            {

            }
        }

        private void dataGridView2_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {

        }

        private void comboBox4_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if ((string)((DataGridView)sender).SelectedCells[0].EditedFormattedValue == "")
            {
                if ((string)((DataGridView)sender).SelectedCells[0].FormattedValue != "")
                {
                    ///ААААААА, это ужасно!!!!!!
                    Task.Run(new Action(() =>
                    {
                        Invoke(new Action(() =>
                        {
                            ((DataGridView)sender).Rows.RemoveAt(e.RowIndex);
                        }));
                    }));
                }
            }
        }

        private void comboBox4_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                //((ComboBox)sender).Text;
            }
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Login = toolStripTextBox1.Text;
            Properties.Settings.Default.Save();
        }

        private void toolStripTextBox2_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Password = toolStripTextBox2.Text;
            Properties.Settings.Default.Save();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void корпусToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewHome newHome = new NewHome();
            newHome.ShowDialog();
            if (newHome.Home != "" && !(newHome.Home is null))
            {
                DataSet1TableAdapters.HomeTableAdapter homeTableAdapter = new DataSet1TableAdapters.HomeTableAdapter();
                homeTableAdapter.Insert(newHome.Home);
            }
        }

        private void шкафКабинетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewRoom newRoom = new NewRoom();
            newRoom.ShowDialog();
            if (newRoom.Room != "" && !(newRoom.Room is null))
            {
                DataSet1TableAdapters.RoomTableAdapter roomTableAdapter = new DataSet1TableAdapters.RoomTableAdapter();
                roomTableAdapter.Insert(newRoom.id_Home, newRoom.Room);
            }
        }
    }
}
