using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Кабельный_журнал
{
    public partial class Port : Panel
    {
        public ComboBox _duplex;
        public ComboBox _media_type;
        public Label label1;
        public Label label15;
        public Label label2;
        public ComboBox _speed;
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
        public ToggleSwitch _mac_sticky;
        public ToggleSwitch _port_sequrity;
        public Label label17;
        public DataGridView _vlan_allowed;
        public DataGridViewTextBoxColumn Vlan;
        public ComboBox _vlan_native;
        public Label label16;
        public Label label6;

        public Port()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this._duplex = new System.Windows.Forms.ComboBox();
            this._media_type = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._speed = new System.Windows.Forms.ComboBox();
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
            this._mac_sticky = new Кабельный_журнал.ToggleSwitch();
            this._port_sequrity = new Кабельный_журнал.ToggleSwitch();
            this.label17 = new System.Windows.Forms.Label();
            this._vlan_allowed = new System.Windows.Forms.DataGridView();
            this.Vlan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._vlan_native = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._vlan_allowed)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this._duplex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._duplex.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._duplex.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._duplex.FormattingEnabled = true;
            this._duplex.Items.AddRange(new object[] {
            "auto",
            "full",
            "half"});
            this._duplex.Location = new System.Drawing.Point(478, 3);
            this._duplex.Name = "comboBox1";
            this._duplex.Size = new System.Drawing.Size(103, 26);
            this._duplex.TabIndex = 18;
            // 
            // comboBox3
            // 
            this._media_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._media_type.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._media_type.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._media_type.FormattingEnabled = true;
            this._media_type.Items.AddRange(new object[] {
            "auto-select",
            "sfp",
            "rj45"});
            this._media_type.Location = new System.Drawing.Point(478, 67);
            this._media_type.Name = "comboBox3";
            this._media_type.Size = new System.Drawing.Size(103, 26);
            this._media_type.TabIndex = 22;
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
            this._speed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._speed.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._speed.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._speed.FormattingEnabled = true;
            this._speed.Items.AddRange(new object[] {
            "auto",
            "10",
            "100",
            "1000",
            "10000"});
            this._speed.Location = new System.Drawing.Point(478, 35);
            this._speed.Name = "comboBox2";
            this._speed.Size = new System.Drawing.Size(103, 26);
            this._speed.TabIndex = 20;
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
            // _description
            // 
            this._description.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._description.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._description.Location = new System.Drawing.Point(100, 3);
            this._description.Name = "_description";
            this._description.Size = new System.Drawing.Size(200, 19);
            this._description.TabIndex = 8;
            this._description.TextChanged += _description_TextChanged;
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
            // _mac
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
            this._mac.Name = "_mac";
            this._mac.Scrollable = false;
            this._mac.ShowGroups = false;
            this._mac.Size = new System.Drawing.Size(264, 69);
            this._mac.TabIndex = 15;
            this._mac.UseCompatibleStateImageBehavior = false;
            this._mac.View = System.Windows.Forms.View.Details;
            this._mac.Click += _mac_Click;
            this._mac.DoubleClick += _mac_DoubleClick;
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
            // _enable
            // 
            this._enable.AutoSize = true;
            this._enable.Location = new System.Drawing.Point(100, 30);
            this._enable.Name = "_enable";
            this._enable.Padding = new System.Windows.Forms.Padding(5);
            this._enable.Size = new System.Drawing.Size(103, 27);
            this._enable.TabIndex = 9;
            this._enable.Text = "toggleSwitch1";
            this._enable.UseVisualStyleBackColor = true;
            this._enable.CheckedChanged += this._enable_CheckedChanged;
            // 
            // _access
            // 
            this._access.AutoSize = true;
            this._access.Location = new System.Drawing.Point(100, 61);
            this._access.Name = "_access";
            this._access.Padding = new System.Windows.Forms.Padding(5);
            this._access.Size = new System.Drawing.Size(103, 27);
            this._access.TabIndex = 10;
            this._access.Text = "toggleSwitch2";
            this._access.UseVisualStyleBackColor = true;
            this._access.CheckedChanged += this._access_CheckedChanged;
            // 
            // _mac_sticky
            // 
            this._mac_sticky.AutoSize = true;
            this._mac_sticky.Location = new System.Drawing.Point(100, 127);
            this._mac_sticky.Name = "_port_sequrity";
            this._mac_sticky.Padding = new System.Windows.Forms.Padding(5);
            this._mac_sticky.Size = new System.Drawing.Size(103, 27);
            this._mac_sticky.TabIndex = 14;
            this._mac_sticky.Text = "toggleSwitch4";
            this._mac_sticky.UseVisualStyleBackColor = true;
            this._mac_sticky.CheckedChanged += this._mac_sticky_CheckedChanged;
            // 
            // _port_sequrity
            // 
            this._port_sequrity.AutoSize = true;
            this._port_sequrity.Location = new System.Drawing.Point(100, 94);
            this._port_sequrity.Name = "_mac_sticky";
            this._port_sequrity.Padding = new System.Windows.Forms.Padding(5);
            this._port_sequrity.Size = new System.Drawing.Size(103, 27);
            this._port_sequrity.TabIndex = 12;
            this._port_sequrity.Text = "toggleSwitch3";
            this._port_sequrity.UseVisualStyleBackColor = true;
            this._port_sequrity.CheckedChanged += this._port_sequrity_CheckedChanged;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.Location = new System.Drawing.Point(6, 99);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(88, 19);
            this.label17.TabIndex = 45;
            this.label17.Text = "Vlan allowed";
            // 
            // dataGridView2
            // 
            this._vlan_allowed.AllowUserToResizeColumns = false;
            this._vlan_allowed.AllowUserToResizeRows = false;
            this._vlan_allowed.BackgroundColor = System.Drawing.SystemColors.Window;
            this._vlan_allowed.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._vlan_allowed.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this._vlan_allowed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._vlan_allowed.ColumnHeadersVisible = false;
            this._vlan_allowed.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Vlan});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._vlan_allowed.DefaultCellStyle = dataGridViewCellStyle1;
            this._vlan_allowed.EnableHeadersVisualStyles = false;
            this._vlan_allowed.Location = new System.Drawing.Point(103, 97);
            this._vlan_allowed.MultiSelect = false;
            this._vlan_allowed.Name = "dataGridView2";
            this._vlan_allowed.RowHeadersVisible = false;
            this._vlan_allowed.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._vlan_allowed.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._vlan_allowed.ShowCellErrors = false;
            this._vlan_allowed.ShowCellToolTips = false;
            this._vlan_allowed.ShowEditingIcon = false;
            this._vlan_allowed.ShowRowErrors = false;
            this._vlan_allowed.Size = new System.Drawing.Size(103, 150);
            this._vlan_allowed.TabIndex = 44;
            this._vlan_allowed.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this._vlan_allowed_RowLeave);
            this._vlan_allowed.UserDeletingRow += _vlan_allowed_UserDeletingRow;
            // 
            // Vlan
            // 
            this.Vlan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Vlan.HeaderText = "Vlan";
            this.Vlan.Name = "Vlan";
            this.Vlan.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // comboBox4
            // 
            this._vlan_native.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this._vlan_native.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this._vlan_native.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._vlan_native.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._vlan_native.FormatString = "N0";
            this._vlan_native.FormattingEnabled = true;
            this._vlan_native.Location = new System.Drawing.Point(478, 99);
            this._vlan_native.Name = "comboBox4";
            this._vlan_native.Size = new System.Drawing.Size(103, 26);
            this._vlan_native.Sorted = true;
            this._vlan_native.TabIndex = 43;
            this._vlan_native.SelectedValueChanged += new System.EventHandler(this._vlan_native_SelectedValueChanged);
            this._vlan_native.KeyUp += new System.Windows.Forms.KeyEventHandler(this._vlan_native_KeyUp);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(381, 101);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(79, 19);
            this.label16.TabIndex = 42;
            // 
            // Port
            // 
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this._duplex);
            this.Controls.Add(this._media_type);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._speed);
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
            this.Controls.Add(this._mac_sticky);
            this.Controls.Add(this._port_sequrity);
            this.Controls.Add(this.label6);
            this.Controls.Add(this._vlan_native);
            this.Controls.Add(this._vlan_allowed);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Size = new System.Drawing.Size(808, 451);
            this.TabIndex = 24;
            ((System.ComponentModel.ISupportInitialize)(this._vlan_allowed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            if (_access.Checked)
            {
                label5.Hide();
                label6.Hide();
                label12.Hide();
                _mac_sticky.Hide();
                _port_sequrity.Hide();
                _mac.Hide();
                label17.Show();
                _vlan_allowed.Show();
                label16.Text = "Native vlan";
            }
            else
            {
                label5.Show();
                label6.Show();
                label12.Show();
                _mac_sticky.Show();
                _port_sequrity.Show();
                _mac.Show();
                label17.Hide();
                _vlan_allowed.Hide();
                label16.Text = "Vlan";
            }
            _access.Enabled = false;
            _duplex.Enabled = false;
            _speed.Enabled = false;
            _media_type.Enabled = false;
            _vlan_native.Enabled = false;
        }

        private void _description_TextChanged(object sender, EventArgs e)
        {
            if (((List<string>)((TextBox)sender).Parent.Tag).Contains("description " + ((TextBox)sender).Text))
            {
            }
            else
            {
                ((Cmd)((TextBox)sender).Parent.Parent.Parent.Parent.Tag)._description_TextChanged(((TextBox)sender).Text);
            }
                
        }

        private void _port_sequrity_CheckedChanged(object sender, EventArgs e)
        {
            if (((List<string>)((ToggleSwitch)sender).Parent.Tag).Contains("switchport port-security") == _port_sequrity.Checked)
            {
            }
            else
            {
                ((Cmd)((ToggleSwitch)sender).Parent.Parent.Parent.Parent.Tag).sw_po(((ToggleSwitch)sender).Checked);
            }
                
        }

        private void _mac_DoubleClick(object sender, EventArgs e)
        {
            ((Cmd)Parent.Parent.Parent.Tag)._mac_DoubleClick(sender, e);
            Update();
        }

        private void _vlan_allowed_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            ((Cmd)((ToggleSwitch)sender).Parent.Parent.Parent.Parent.Tag).re_vlan(e.Row.Cells[0].Value.ToString());
            //Update();
        }

        public void _enable_CheckedChanged(object sender, EventArgs e)
        {
            if (((List<string>)((ToggleSwitch)sender).Parent.Tag).Contains("shutdoun") != _enable.Checked)
            {
            }
            else
            {
                ((Cmd)((ToggleSwitch)sender).Parent.Parent.Parent.Parent.Tag).sh(((ToggleSwitch)sender).Checked);
                Update();
            }
        }

        private void _vlan_native_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                //((ComboBox)sender).Text;
            }
        }

        internal void _mac_sticky_CheckedChanged(object sender, EventArgs e)
        {
            if (((List<string>)((ToggleSwitch)sender).Parent.Tag).Contains("switchport port-security mac-address sticky") == _mac_sticky.Checked)
            {
            }
            else
            {
                ((Cmd)((ToggleSwitch)sender).Parent.Parent.Parent.Parent.Tag).sw_po_mac_st(((ToggleSwitch)sender).Checked);
                Update();
            }
        }

        public void _vlan_native_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void _vlan_allowed_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {

        }

        private void _vlan_allowed_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            Cmd cmd = (Cmd)((DataGridView)sender).Parent.Parent.Parent.Parent.Tag;
            if (((DataGridView)sender).SelectedCells.Count > 0)
            {
                try
                {
                    if ((string)((DataGridView)sender).SelectedCells[0].EditedFormattedValue == "")
                    {
                        if ((string)((DataGridView)sender).SelectedCells[0].FormattedValue != "")
                        {
                            var qqq = (string)((DataGridView)sender).SelectedCells[0].FormattedValue;
                            ///ААААААА, это ужасно!!!!!!
                            Task.Run(new Action(() => Invoke(new Action(() =>
                            {
                                cmd.re_vlan(qqq);
                                ((DataGridView)sender).Rows.RemoveAt(e.RowIndex);
                            }))));
                        }
                    }
                    if ((string)((DataGridView)sender).SelectedCells[0].FormattedValue == "")
                    {
                        if ((string)((DataGridView)sender).SelectedCells[0].EditedFormattedValue != "")
                        {
                            cmd.add_vlan((string)((DataGridView)sender).SelectedCells[0].EditedFormattedValue);

                        }
                    }
                } catch (Exception){ }
            }
        }

        internal void _mac_Click(object sender, EventArgs e)
        {
            if (((ListView)sender).SelectedItems.Count > 0)
            {
                Clipboard.Clear();
                Clipboard.SetText(((ListView)sender).SelectedItems[0].Text);
                //Update();
            }
        }

        public void _access_CheckedChanged(object sender, EventArgs e)
        {
            if (((ToggleSwitch)sender).Checked)
            {
                label5.Hide();
                label6.Hide();
                label12.Hide();
                _mac_sticky.Hide();
                _port_sequrity.Hide();
                _mac.Hide();
                label17.Show();
                _vlan_allowed.Show();
                label16.Text = "Native vlan";
            }
            else
            {
                label5.Show();
                label6.Show();
                label12.Show();
                _mac_sticky.Show();
                _port_sequrity.Show();
                _mac.Show();
                label17.Hide();
                _vlan_allowed.Hide();
                label16.Text = "Vlan";
            }
        }

        internal new void Update()
        {
            List<string> Tag = new List<string>();
            Tag = ((Cmd)Parent.Parent.Parent.Tag).GetPortConfig(((TabPage)Parent).Text);
            Equipment.Interface @interface = new Equipment.Interface();
            Task.Run(new Action(() =>
            {
                string description;
                /// <summary>
                /// acces: no mdix auto, no cdp enable, switchport port-security, switchport port-security mac-address sticky, mac
                /// trunk: switchport nonegotiate, udld port
                /// </summary>
                string sw_mode = Tag.Find(q => q.Contains("switchport mode ")).Remove(0, "switchport mode ".Length);
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
                    description = Tag.Find(q => q.Contains("description ")).Remove(0, "description ".Length);
                } catch (Exception)
                {
                    description = "";
                }
                try
                {
                    sw_po = Tag.Contains("switchport port-security");
                } catch (Exception)
                {
                    sw_po = false;
                }
                try
                {
                    sw_po_mac_st = Tag.Contains("switchport port-security mac-address sticky");
                } catch (Exception)
                {
                    sw_po_mac_st = false;
                }
                try
                {
                    mac = Tag.FindAll(q => q.Contains(" mac-address "));
                    for (int i = 0; i < mac.Count; i++)
                    {
                        mac[i] = mac[i].Remove(0, mac[i].IndexOf(" mac-address ") + " mac-address ".Length);
                        if (mac[i].Contains("sticky "))
                        {
                            mac[i] = mac[i].Remove(0, mac[i].IndexOf("sticky ") + "sticky ".Length);
                        }
                    }
                    mac.Remove("");
                    mac.Remove("sticky");
                } catch (Exception)
                {
                    mac = new List<string>();
                }
                try
                {
                    sp_bpduguard = Tag.Find(q => q.Contains(" bpduguard ")).Contains(" bpduguard ");
                } catch (Exception)
                {
                    sp_bpduguard = false;
                }
                try
                {
                    udld_port = Tag.Find(q => q.Contains("udld port")).Contains("udld port");
                } catch (Exception)
                {
                    udld_port = false;
                }
                try
                {
                    var ss = Tag.Find(q => q.Contains("duplex "));
                    duplex = ss.Remove(0, ss.IndexOf("duplex ") + "duplex ".Length);
                    duplex = duplex == "" ? "auto" : duplex;
                } catch (Exception)
                {
                    duplex = "auto";
                }
                try
                {
                    var ss = Tag.Find(q => q.Contains("media-type "));
                    media_type = ss.Remove(0, ss.IndexOf("media-type ") + "media-type ".Length);
                } catch (Exception)
                {
                    media_type = "auto-select";
                }
                try
                {
                    sh = true;
                    sh = !Tag.Find(q => q.Contains("shutdown")).Contains("shutdown");
                } catch (Exception)
                {
                    sh = true;
                }
                try
                {
                    var ss = Tag.Find(q => q.Contains(" allowed vlan "));
                    var vlanss = ss.Remove(0, ss.IndexOf(" allowed vlan ") + " allowed vlan ".Length).Split(',');
                    vlans = new int[vlanss.Length];
                    for (int i = 0; i < vlanss.Length; i++)
                    {
                        vlans[i] = Convert.ToInt32(vlanss[i]);
                    }
                } catch (Exception)
                {
                    vlans = new int[0];
                }
                try
                {
                    var ss = Tag.Find(q => q.Contains(" native vlan ") || q.Contains(" access vlan "));
                    native_vlan = Convert.ToInt32(ss.Remove(0, ss.IndexOf(" vlan ") + " vlan ".Length));
                } catch (Exception)
                {
                    native_vlan = 0;
                }
                try
                {
                    var ss = Tag.Find(q => q.Contains("speed "));
                    speed = ss.Remove(0, ss.IndexOf("speed ") + "speed ".Length);
                } catch (Exception)
                {
                    speed = "auto";
                }
                @interface = new Equipment.Interface() { speed = speed, port = Tag[0].Remove(0, "interface ".Length), description = description, duplex = duplex, mac = mac, media_type = media_type, native_vlan = native_vlan, sh = sh, sp_bpduguard = sp_bpduguard, sw_mode = sw_mode, sw_po = sw_po, sw_po_mac_st = sw_po_mac_st, udld_port = udld_port, vlans = vlans };
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
                if (@interface.sw_mode == "access")
                {

                }
                else if (@interface.sw_mode == "trunk")
                {

                }
                Invoke(new Action(() =>
                {
                    this.Tag = Tag;
                    this._description.Text = @interface.description;
                    this._access.Checked = @interface.sw_mode == "trunk";
                    if (this._access.Checked)
                    {
                        this.label5.Hide();
                        this.label6.Hide();
                        this.label12.Hide();
                        this._mac_sticky.Hide();
                        this._port_sequrity.Hide();
                        this._mac.Hide();
                        this.label17.Show();
                        this._vlan_allowed.Show();
                        this.label16.Text = "Native vlan";
                    }
                    else
                    {
                        this.label5.Show();
                        this.label6.Show();
                        this.label12.Show();
                        this._mac_sticky.Show();
                        this._port_sequrity.Show();
                        this._mac.Show();
                        this.label17.Hide();
                        this._vlan_allowed.Hide();
                        this.label16.Text = "Vlan";
                    }
                    this._enable.Checked = @interface.sh;
                    this._vlan_native.Text = @interface.native_vlan.ToString();
                    this._vlan_allowed.Rows.Clear();
                    foreach (var item in @interface.vlans)
                    {
                        this._vlan_allowed.Rows.Add(new object[1] { item });
                    }
                    this._mac_sticky.Checked = @interface.sw_po_mac_st;
                    this._port_sequrity.Checked = @interface.sw_po;
                    this._mac.Items.Clear();
                    foreach (var item in @interface.mac)
                    {
                        ListViewItem listViewItem = new ListViewItem(item.Split(' ')[0].Replace(".", "").ToUpper());
                        listViewItem.SubItems.Add(new ListViewItem.ListViewSubItem(listViewItem, item.Remove(0, item.IndexOf(' ') == -1 ? item.Length : item.IndexOf(' ') + 1)));
                        listViewItem.SubItems.Add(new ListViewItem.ListViewSubItem(listViewItem, "Удалить") { BackColor = Color.LightGray });

                        this._mac.Items.Add(listViewItem);
                    }
                    this._duplex.Text = @interface.duplex;
                    this._media_type.Text = @interface.media_type;
                    this._speed.Text = @interface.speed;
                }));
            }));
        }
    }
}
