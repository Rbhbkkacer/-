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
    public partial class Port : Panel
    {
        public ComboBox comboBox1;
        public ComboBox comboBox3;
        public Label label1;
        public Label label15;
        public Label label2;
        public ComboBox comboBox2;
        public Label label3;
        public Label label14;
        public Label label4;
        public TextBox _description;
        public Label label13;
        public ToggleSwitch _enable;
        public Label label12;
        public ToggleSwitch _access;
        public ListView _mac;
        public ColumnHeader columnHeader1;
        public ColumnHeader columnHeader2;
        public ColumnHeader columnHeader3;
        public Label label5;
        public ToggleSwitch _port_sequrity;
        public ToggleSwitch _mac_sticky;
        public Label label6;

        public Port()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._description = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this._mac = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this._enable = new Кабельный_журнал.ToggleSwitch();
            this._access = new Кабельный_журнал.ToggleSwitch();
            this._port_sequrity = new Кабельный_журнал.ToggleSwitch();
            this._mac_sticky = new Кабельный_журнал.ToggleSwitch();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "auto",
            "full",
            "half"});
            this.comboBox1.Location = new System.Drawing.Point(478, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(103, 26);
            this.comboBox1.TabIndex = 18;
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox3.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "auto-select",
            "sfp",
            "rj45"});
            this.comboBox3.Location = new System.Drawing.Point(478, 67);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(103, 26);
            this.comboBox3.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enabled";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(381, 69);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(79, 19);
            this.label15.TabIndex = 21;
            this.label15.Text = "Media type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(3, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Access";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox2.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "auto",
            "10",
            "100",
            "1000",
            "10000"});
            this.comboBox2.Location = new System.Drawing.Point(478, 35);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(103, 26);
            this.comboBox2.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(225, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Trunk";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(381, 37);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 19);
            this.label14.TabIndex = 19;
            this.label14.Text = "Speed";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(3, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "Description";
            // 
            // textBox7
            // 
            this._description.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._description.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._description.Location = new System.Drawing.Point(100, 3);
            this._description.Name = "textBox7";
            this._description.Size = new System.Drawing.Size(103, 19);
            this._description.TabIndex = 8;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(381, 5);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 19);
            this.label13.TabIndex = 17;
            this.label13.Text = "Duplex";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(3, 162);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 19);
            this.label12.TabIndex = 16;
            this.label12.Text = "MAC address";
            // 
            // listView1
            // 
            this._mac.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._mac.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this._mac.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._mac.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this._mac.LabelEdit = true;
            this._mac.Location = new System.Drawing.Point(100, 162);
            this._mac.MultiSelect = false;
            this._mac.Name = "listView1";
            this._mac.Scrollable = false;
            this._mac.ShowGroups = false;
            this._mac.Size = new System.Drawing.Size(264, 69);
            this._mac.TabIndex = 15;
            this._mac.UseCompatibleStateImageBehavior = false;
            this._mac.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "MAC";
            this.columnHeader1.Width = 118;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "access";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "del";
            this.columnHeader3.Width = 70;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(3, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 19);
            this.label5.TabIndex = 11;
            this.label5.Text = "Port security";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(3, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 19);
            this.label6.TabIndex = 13;
            this.label6.Text = "MAC sticky";
            // 
            // toggleSwitch1
            // 
            this._enable.AutoSize = true;
            this._enable.Location = new System.Drawing.Point(100, 30);
            this._enable.Name = "toggleSwitch1";
            this._enable.Padding = new System.Windows.Forms.Padding(5);
            this._enable.Size = new System.Drawing.Size(103, 27);
            this._enable.TabIndex = 9;
            this._enable.Text = "toggleSwitch1";
            this._enable.UseVisualStyleBackColor = true;
            // 
            // toggleSwitch2
            // 
            this._access.AutoSize = true;
            this._access.Location = new System.Drawing.Point(100, 61);
            this._access.Name = "toggleSwitch2";
            this._access.Padding = new System.Windows.Forms.Padding(5);
            this._access.Size = new System.Drawing.Size(103, 27);
            this._access.TabIndex = 10;
            this._access.Text = "toggleSwitch2";
            this._access.UseVisualStyleBackColor = true;
            // 
            // toggleSwitch4
            // 
            this._port_sequrity.AutoSize = true;
            this._port_sequrity.Location = new System.Drawing.Point(100, 127);
            this._port_sequrity.Name = "toggleSwitch4";
            this._port_sequrity.Padding = new System.Windows.Forms.Padding(5);
            this._port_sequrity.Size = new System.Drawing.Size(103, 27);
            this._port_sequrity.TabIndex = 14;
            this._port_sequrity.Text = "toggleSwitch4";
            this._port_sequrity.UseVisualStyleBackColor = true;
            // 
            // toggleSwitch3
            // 
            this._mac_sticky.AutoSize = true;
            this._mac_sticky.Location = new System.Drawing.Point(100, 94);
            this._mac_sticky.Name = "toggleSwitch3";
            this._mac_sticky.Padding = new System.Windows.Forms.Padding(5);
            this._mac_sticky.Size = new System.Drawing.Size(103, 27);
            this._mac_sticky.TabIndex = 12;
            this._mac_sticky.Text = "toggleSwitch3";
            this._mac_sticky.UseVisualStyleBackColor = true;
            // 
            // Port
            // 
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._description);
            this.Controls.Add(this.label13);
            this.Controls.Add(this._enable);
            this.Controls.Add(this.label12);
            this.Controls.Add(this._access);
            this.Controls.Add(this._mac);
            this.Controls.Add(this.label5);
            this.Controls.Add(this._port_sequrity);
            this.Controls.Add(this._mac_sticky);
            this.Controls.Add(this.label6);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Size = new System.Drawing.Size(808, 451);
            this.BackColor = System.Drawing.Color.White;
            this.TabIndex = 24;
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
