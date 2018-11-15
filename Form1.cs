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

        public EList eList = new EList();
        public Form1()
        {
            InitializeComponent();
            InitializeContextMenuStrip();
            










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
            groupBox1.ContextMenuStrip = contextMenuStrip1;
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Equipment equipmentOriginal = ((ContextMenuStrip)(sender as ToolStripMenuItem).Owner).SourceControl as Equipment;
            TabPage tabPageEdit = new TabPage("Изменить");
            tabControl1.TabPages.Add(tabPageEdit);
            Equipment equipmentEdit1;
            if (equipmentOriginal.portids == null)
            {
                equipmentEdit1 = new Equipment(0, equipmentOriginal.roomid);
            }
            else
            {
                equipmentEdit1 = new Equipment(equipmentOriginal.portids.First(
                    pair => pair.Value == (equipmentOriginal.Equipment_Ports.Text == null ? "" : equipmentOriginal.Equipment_Ports.Text)
                    ).Key, equipmentOriginal.roomid);
            }
            EList eList = new EList();
            eList.Ad(tabPageEdit, equipmentEdit1);
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
            dataGridView1.DataSource = dataTableEquipmentAdapter.GetData(home, room, EO, mac_, equi);
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
            var equipmentTable = equipmentTableAdapter.GetData();
            var equipmentRow = equipmentTable.FindByID(Convert.ToInt32(((DataGridView)sender).SelectedRows[0].Cells[7].Value.ToString()));
            Equipment equipmentCurrent = new Equipment(portRow.ID,equipmentRow.ID_Шкафа_комнаты);
            eList.Clear();
            eList.Ad(tabPage1, equipmentCurrent);
        }
    }
}
