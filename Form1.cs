using System;
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
            eList.Ad(tabPage1);
            eList.Ad(tabPage1);
            eList.Ad(tabPage1);
            eList.Ad(tabPage1);
            










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
    }
}
