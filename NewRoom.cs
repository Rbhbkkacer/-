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
    public partial class NewRoom : Form
    {
        DataSet1TableAdapters.RoomTableAdapter roomTableAdapter = new DataSet1TableAdapters.RoomTableAdapter();
        DataSet1TableAdapters.HomeTableAdapter HomeTableAdapter = new DataSet1TableAdapters.HomeTableAdapter();
        DataSet1.RoomDataTable Rows;
        DataSet1.HomeDataTable homeRows;
        List<string> vs = new List<string>();
        Dictionary<int, string> keyValuePairs = new Dictionary<int, string>();
        public int id_Home;
        public string Room = "";

        public NewRoom()
        {
            InitializeComponent();
            homeRows = HomeTableAdapter.GetData();
            foreach (DataSet1.HomeRow item in homeRows.Rows)
            {
                keyValuePairs.Add(item.ID, item.___корпуса);
                comboBox1.Items.Add(item.___корпуса);
            }
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

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            id_Home = keyValuePairs.First(q => q.Value == ((ComboBox)sender).SelectedItem).Key;
            vs.Clear();
            Rows = roomTableAdapter.GetData();
            foreach (DataSet1.RoomRow item in Rows.Rows)
            {
                if (item.ID_Корпуса == id_Home)
                {
                    vs.Add(item.Шкаф_кабинет);
                }
            }
            textBox1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Room = textBox1.Text.Trim();
            Close();
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
