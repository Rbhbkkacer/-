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
    public partial class NewHome : Form
    {
        public string Home = "";
        DataSet1TableAdapters.HomeTableAdapter HomeTableAdapter = new DataSet1TableAdapters.HomeTableAdapter();
        List<string> vs = new List<string>();

        public NewHome()
        {
            InitializeComponent();
            foreach (DataSet1.HomeRow item in HomeTableAdapter.GetData().Rows)
            {
                vs.Add(item.___корпуса);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home = textBox1.Text.Trim();
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (vs.Contains(((TextBox)sender).Text) || ((TextBox)sender).Text.Trim() == "")
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && button1.Enabled)
            {
                button1_Click(button1, null);
            }
        }
    }
}
