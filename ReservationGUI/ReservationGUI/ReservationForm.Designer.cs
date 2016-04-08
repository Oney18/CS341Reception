namespace ReservationGUI
{
    partial class ReservationsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>ghjf
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("TakeOutOrders");
            this.seatingQueue = new System.Windows.Forms.GroupBox();
            this.partyListBox = new System.Windows.Forms.ListBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.guestNumTextBox = new System.Windows.Forms.TextBox();
            this.requestsTextBox = new System.Windows.Forms.TextBox();
            this.pagerNumTextBox = new System.Windows.Forms.TextBox();
            this.waitEstimateTextBox = new System.Windows.Forms.TextBox();
            this.waitEstimateLabel = new System.Windows.Forms.Label();
            this.requestsLabel = new System.Windows.Forms.Label();
            this.pagerLabel = new System.Windows.Forms.Label();
            this.guestNumLabel = new System.Windows.Forms.Label();
            this.partyNameLabel = new System.Windows.Forms.Label();
            this.partyTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.takeOutRadioButton = new System.Windows.Forms.RadioButton();
            this.reservationRadioButton = new System.Windows.Forms.RadioButton();
            this.walkInRadioButton = new System.Windows.Forms.RadioButton();
            this.addPartyButton = new System.Windows.Forms.Button();
            this.reservationFormTitleLabel = new System.Windows.Forms.Label();
            this.seeTablesButton = new System.Windows.Forms.Button();
            this.reservationTimeLabel = new System.Windows.Forms.Label();
            this.reservationHourTextBox = new System.Windows.Forms.TextBox();
            this.contactLabel = new System.Windows.Forms.Label();
            this.contactTextBox = new System.Windows.Forms.TextBox();
            this.reservationMinTextBox = new System.Windows.Forms.TextBox();
            this.timeDescriptionLabel = new System.Windows.Forms.Label();
            this.takeOutGroupBox = new System.Windows.Forms.GroupBox();
            this.reservationsGroupBox = new System.Windows.Forms.GroupBox();
            this.reservationsListBox = new System.Windows.Forms.ListBox();
            this.seatResCheckBox = new System.Windows.Forms.CheckBox();
            this.takeOutListBox = new System.Windows.Forms.ListView();
            this.seatingQueue.SuspendLayout();
            this.partyTypeGroupBox.SuspendLayout();
            this.takeOutGroupBox.SuspendLayout();
            this.reservationsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // seatingQueue
            // 
            this.seatingQueue.Controls.Add(this.partyListBox);
            this.seatingQueue.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seatingQueue.Location = new System.Drawing.Point(20, 7);
            this.seatingQueue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.seatingQueue.Name = "seatingQueue";
            this.seatingQueue.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.seatingQueue.Size = new System.Drawing.Size(208, 231);
            this.seatingQueue.TabIndex = 12;
            this.seatingQueue.TabStop = false;
            this.seatingQueue.Text = "Walk In Queue";
            // 
            // partyListBox
            // 
            this.partyListBox.FormattingEnabled = true;
            this.partyListBox.ItemHeight = 28;
            this.partyListBox.Location = new System.Drawing.Point(8, 27);
            this.partyListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.partyListBox.Name = "partyListBox";
            this.partyListBox.Size = new System.Drawing.Size(191, 172);
            this.partyListBox.TabIndex = 11;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTextBox.Location = new System.Drawing.Point(585, 78);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(173, 30);
            this.nameTextBox.TabIndex = 1;
            // 
            // guestNumTextBox
            // 
            this.guestNumTextBox.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guestNumTextBox.Location = new System.Drawing.Point(585, 121);
            this.guestNumTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guestNumTextBox.Name = "guestNumTextBox";
            this.guestNumTextBox.Size = new System.Drawing.Size(173, 30);
            this.guestNumTextBox.TabIndex = 2;
            this.guestNumTextBox.TextChanged += new System.EventHandler(this.guestNumTextBox_TextChanged);
            // 
            // requestsTextBox
            // 
            this.requestsTextBox.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.requestsTextBox.Location = new System.Drawing.Point(469, 250);
            this.requestsTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.requestsTextBox.Multiline = true;
            this.requestsTextBox.Name = "requestsTextBox";
            this.requestsTextBox.Size = new System.Drawing.Size(289, 68);
            this.requestsTextBox.TabIndex = 5;
            // 
            // pagerNumTextBox
            // 
            this.pagerNumTextBox.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagerNumTextBox.Location = new System.Drawing.Point(585, 164);
            this.pagerNumTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pagerNumTextBox.Name = "pagerNumTextBox";
            this.pagerNumTextBox.Size = new System.Drawing.Size(173, 30);
            this.pagerNumTextBox.TabIndex = 3;
            // 
            // waitEstimateTextBox
            // 
            this.waitEstimateTextBox.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waitEstimateTextBox.Location = new System.Drawing.Point(585, 207);
            this.waitEstimateTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.waitEstimateTextBox.Name = "waitEstimateTextBox";
            this.waitEstimateTextBox.ReadOnly = true;
            this.waitEstimateTextBox.Size = new System.Drawing.Size(173, 30);
            this.waitEstimateTextBox.TabIndex = 4;
            // 
            // waitEstimateLabel
            // 
            this.waitEstimateLabel.AutoSize = true;
            this.waitEstimateLabel.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waitEstimateLabel.Location = new System.Drawing.Point(248, 207);
            this.waitEstimateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.waitEstimateLabel.Name = "waitEstimateLabel";
            this.waitEstimateLabel.Size = new System.Drawing.Size(192, 28);
            this.waitEstimateLabel.TabIndex = 7;
            this.waitEstimateLabel.Text = "Wait Time Estimate:";
            // 
            // requestsLabel
            // 
            this.requestsLabel.AutoSize = true;
            this.requestsLabel.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.requestsLabel.Location = new System.Drawing.Point(248, 250);
            this.requestsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.requestsLabel.Name = "requestsLabel";
            this.requestsLabel.Size = new System.Drawing.Size(158, 28);
            this.requestsLabel.TabIndex = 8;
            this.requestsLabel.Text = "Special Requests:";
            // 
            // pagerLabel
            // 
            this.pagerLabel.AutoSize = true;
            this.pagerLabel.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagerLabel.Location = new System.Drawing.Point(248, 164);
            this.pagerLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pagerLabel.Name = "pagerLabel";
            this.pagerLabel.Size = new System.Drawing.Size(139, 28);
            this.pagerLabel.TabIndex = 9;
            this.pagerLabel.Text = "Pager Number:";
            // 
            // guestNumLabel
            // 
            this.guestNumLabel.AutoSize = true;
            this.guestNumLabel.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guestNumLabel.Location = new System.Drawing.Point(248, 121);
            this.guestNumLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.guestNumLabel.Name = "guestNumLabel";
            this.guestNumLabel.Size = new System.Drawing.Size(172, 28);
            this.guestNumLabel.TabIndex = 10;
            this.guestNumLabel.Text = "Number of Guests:";
            // 
            // partyNameLabel
            // 
            this.partyNameLabel.AutoSize = true;
            this.partyNameLabel.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partyNameLabel.Location = new System.Drawing.Point(248, 78);
            this.partyNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.partyNameLabel.Name = "partyNameLabel";
            this.partyNameLabel.Size = new System.Drawing.Size(121, 28);
            this.partyNameLabel.TabIndex = 11;
            this.partyNameLabel.Text = "Party Name:";
            // 
            // partyTypeGroupBox
            // 
            this.partyTypeGroupBox.Controls.Add(this.takeOutRadioButton);
            this.partyTypeGroupBox.Controls.Add(this.reservationRadioButton);
            this.partyTypeGroupBox.Controls.Add(this.walkInRadioButton);
            this.partyTypeGroupBox.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partyTypeGroupBox.Location = new System.Drawing.Point(232, 329);
            this.partyTypeGroupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.partyTypeGroupBox.Name = "partyTypeGroupBox";
            this.partyTypeGroupBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.partyTypeGroupBox.Size = new System.Drawing.Size(165, 114);
            this.partyTypeGroupBox.TabIndex = 6;
            this.partyTypeGroupBox.TabStop = false;
            this.partyTypeGroupBox.Text = "Party Type";
            // 
            // takeOutRadioButton
            // 
            this.takeOutRadioButton.AutoSize = true;
            this.takeOutRadioButton.Location = new System.Drawing.Point(21, 80);
            this.takeOutRadioButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.takeOutRadioButton.Name = "takeOutRadioButton";
            this.takeOutRadioButton.Size = new System.Drawing.Size(112, 32);
            this.takeOutRadioButton.TabIndex = 3;
            this.takeOutRadioButton.Text = "Take Out";
            this.takeOutRadioButton.UseVisualStyleBackColor = true;
            this.takeOutRadioButton.CheckedChanged += new System.EventHandler(this.takeOutRadioButton_CheckedChanged);
            // 
            // reservationRadioButton
            // 
            this.reservationRadioButton.AutoSize = true;
            this.reservationRadioButton.Location = new System.Drawing.Point(21, 52);
            this.reservationRadioButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.reservationRadioButton.Name = "reservationRadioButton";
            this.reservationRadioButton.Size = new System.Drawing.Size(134, 32);
            this.reservationRadioButton.TabIndex = 2;
            this.reservationRadioButton.Text = "Reservation";
            this.reservationRadioButton.UseVisualStyleBackColor = true;
            this.reservationRadioButton.CheckedChanged += new System.EventHandler(this.reservationRadioButton_CheckedChanged);
            // 
            // walkInRadioButton
            // 
            this.walkInRadioButton.AutoSize = true;
            this.walkInRadioButton.Checked = true;
            this.walkInRadioButton.Location = new System.Drawing.Point(21, 23);
            this.walkInRadioButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.walkInRadioButton.Name = "walkInRadioButton";
            this.walkInRadioButton.Size = new System.Drawing.Size(106, 32);
            this.walkInRadioButton.TabIndex = 1;
            this.walkInRadioButton.TabStop = true;
            this.walkInRadioButton.Text = "Walk In";
            this.walkInRadioButton.UseVisualStyleBackColor = true;
            this.walkInRadioButton.CheckedChanged += new System.EventHandler(this.walkInRadioButton_CheckedChanged);
            // 
            // addPartyButton
            // 
            this.addPartyButton.BackColor = System.Drawing.SystemColors.HighlightText;
            this.addPartyButton.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.addPartyButton.FlatAppearance.BorderSize = 2;
            this.addPartyButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.addPartyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addPartyButton.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addPartyButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.addPartyButton.Location = new System.Drawing.Point(579, 486);
            this.addPartyButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addPartyButton.Name = "addPartyButton";
            this.addPartyButton.Size = new System.Drawing.Size(181, 39);
            this.addPartyButton.TabIndex = 7;
            this.addPartyButton.Text = "Add Party";
            this.addPartyButton.UseVisualStyleBackColor = false;
            this.addPartyButton.Click += new System.EventHandler(this.addPartyButton_Click);
            // 
            // reservationFormTitleLabel
            // 
            this.reservationFormTitleLabel.AutoSize = true;
            this.reservationFormTitleLabel.Font = new System.Drawing.Font("Monotype Corsiva", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reservationFormTitleLabel.Location = new System.Drawing.Point(289, 11);
            this.reservationFormTitleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.reservationFormTitleLabel.Name = "reservationFormTitleLabel";
            this.reservationFormTitleLabel.Size = new System.Drawing.Size(216, 37);
            this.reservationFormTitleLabel.TabIndex = 14;
            this.reservationFormTitleLabel.Text = "Waitlist Handler";
            // 
            // seeTablesButton
            // 
            this.seeTablesButton.BackColor = System.Drawing.SystemColors.HighlightText;
            this.seeTablesButton.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.seeTablesButton.FlatAppearance.BorderSize = 2;
            this.seeTablesButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.seeTablesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.seeTablesButton.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seeTablesButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.seeTablesButton.Location = new System.Drawing.Point(323, 486);
            this.seeTablesButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.seeTablesButton.Name = "seeTablesButton";
            this.seeTablesButton.Size = new System.Drawing.Size(181, 39);
            this.seeTablesButton.TabIndex = 10;
            this.seeTablesButton.Text = "See Tables";
            this.seeTablesButton.UseVisualStyleBackColor = false;
            this.seeTablesButton.Click += new System.EventHandler(this.seatPartyButton_Click);
            // 
            // reservationTimeLabel
            // 
            this.reservationTimeLabel.AutoSize = true;
            this.reservationTimeLabel.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reservationTimeLabel.Location = new System.Drawing.Point(399, 398);
            this.reservationTimeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.reservationTimeLabel.Name = "reservationTimeLabel";
            this.reservationTimeLabel.Size = new System.Drawing.Size(165, 28);
            this.reservationTimeLabel.TabIndex = 16;
            this.reservationTimeLabel.Text = "Reservation Time:";
            this.reservationTimeLabel.Visible = false;
            // 
            // reservationHourTextBox
            // 
            this.reservationHourTextBox.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reservationHourTextBox.Location = new System.Drawing.Point(585, 394);
            this.reservationHourTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.reservationHourTextBox.Name = "reservationHourTextBox";
            this.reservationHourTextBox.Size = new System.Drawing.Size(76, 30);
            this.reservationHourTextBox.TabIndex = 17;
            this.reservationHourTextBox.Visible = false;
            // 
            // contactLabel
            // 
            this.contactLabel.AutoSize = true;
            this.contactLabel.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contactLabel.Location = new System.Drawing.Point(424, 346);
            this.contactLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.contactLabel.Name = "contactLabel";
            this.contactLabel.Size = new System.Drawing.Size(143, 28);
            this.contactLabel.TabIndex = 18;
            this.contactLabel.Text = "Contact Phone:";
            this.contactLabel.Visible = false;
            // 
            // contactTextBox
            // 
            this.contactTextBox.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contactTextBox.Location = new System.Drawing.Point(585, 340);
            this.contactTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.contactTextBox.Name = "contactTextBox";
            this.contactTextBox.Size = new System.Drawing.Size(173, 30);
            this.contactTextBox.TabIndex = 19;
            this.contactTextBox.Visible = false;
            // 
            // reservationMinTextBox
            // 
            this.reservationMinTextBox.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reservationMinTextBox.Location = new System.Drawing.Point(683, 393);
            this.reservationMinTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.reservationMinTextBox.Name = "reservationMinTextBox";
            this.reservationMinTextBox.Size = new System.Drawing.Size(76, 30);
            this.reservationMinTextBox.TabIndex = 20;
            this.reservationMinTextBox.Visible = false;
            // 
            // timeDescriptionLabel
            // 
            this.timeDescriptionLabel.AutoSize = true;
            this.timeDescriptionLabel.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeDescriptionLabel.Location = new System.Drawing.Point(580, 439);
            this.timeDescriptionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.timeDescriptionLabel.Name = "timeDescriptionLabel";
            this.timeDescriptionLabel.Size = new System.Drawing.Size(185, 28);
            this.timeDescriptionLabel.TabIndex = 21;
            this.timeDescriptionLabel.Text = "Ex: 18 30 is 6:30pm";
            this.timeDescriptionLabel.Visible = false;
            // 
            // takeOutGroupBox
            // 
            this.takeOutGroupBox.Controls.Add(this.takeOutListBox);
            this.takeOutGroupBox.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.takeOutGroupBox.Location = new System.Drawing.Point(20, 389);
            this.takeOutGroupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.takeOutGroupBox.Name = "takeOutGroupBox";
            this.takeOutGroupBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.takeOutGroupBox.Size = new System.Drawing.Size(208, 150);
            this.takeOutGroupBox.TabIndex = 13;
            this.takeOutGroupBox.TabStop = false;
            this.takeOutGroupBox.Text = "Take Out Orders";
            // 
            // reservationsGroupBox
            // 
            this.reservationsGroupBox.Controls.Add(this.reservationsListBox);
            this.reservationsGroupBox.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reservationsGroupBox.Location = new System.Drawing.Point(20, 239);
            this.reservationsGroupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.reservationsGroupBox.Name = "reservationsGroupBox";
            this.reservationsGroupBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.reservationsGroupBox.Size = new System.Drawing.Size(208, 150);
            this.reservationsGroupBox.TabIndex = 13;
            this.reservationsGroupBox.TabStop = false;
            this.reservationsGroupBox.Text = "Reservations";
            // 
            // reservationsListBox
            // 
            this.reservationsListBox.FormattingEnabled = true;
            this.reservationsListBox.ItemHeight = 28;
            this.reservationsListBox.Location = new System.Drawing.Point(8, 27);
            this.reservationsListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.reservationsListBox.Name = "reservationsListBox";
            this.reservationsListBox.Size = new System.Drawing.Size(191, 88);
            this.reservationsListBox.TabIndex = 11;
            // 
            // seatResCheckBox
            // 
            this.seatResCheckBox.AutoSize = true;
            this.seatResCheckBox.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seatResCheckBox.Location = new System.Drawing.Point(236, 289);
            this.seatResCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.seatResCheckBox.Name = "seatResCheckBox";
            this.seatResCheckBox.Size = new System.Drawing.Size(208, 32);
            this.seatResCheckBox.TabIndex = 22;
            this.seatResCheckBox.Text = "seat reservation next";
            this.seatResCheckBox.UseVisualStyleBackColor = true;
            this.seatResCheckBox.Visible = false;
            // 
            // takeOutListBox
            // 
            this.takeOutListBox.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.takeOutListBox.LabelWrap = false;
            this.takeOutListBox.Location = new System.Drawing.Point(1, 27);
            this.takeOutListBox.Margin = new System.Windows.Forms.Padding(4);
            this.takeOutListBox.Name = "takeOutListBox";
            this.takeOutListBox.Size = new System.Drawing.Size(199, 115);
            this.takeOutListBox.TabIndex = 11;
            this.takeOutListBox.UseCompatibleStateImageBehavior = false;
            this.takeOutListBox.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // ReservationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(811, 540);
            this.Controls.Add(this.seatResCheckBox);
            this.Controls.Add(this.reservationsGroupBox);
            this.Controls.Add(this.takeOutGroupBox);
            this.Controls.Add(this.timeDescriptionLabel);
            this.Controls.Add(this.reservationMinTextBox);
            this.Controls.Add(this.contactTextBox);
            this.Controls.Add(this.contactLabel);
            this.Controls.Add(this.reservationHourTextBox);
            this.Controls.Add(this.reservationTimeLabel);
            this.Controls.Add(this.seeTablesButton);
            this.Controls.Add(this.reservationFormTitleLabel);
            this.Controls.Add(this.addPartyButton);
            this.Controls.Add(this.partyTypeGroupBox);
            this.Controls.Add(this.partyNameLabel);
            this.Controls.Add(this.guestNumLabel);
            this.Controls.Add(this.pagerLabel);
            this.Controls.Add(this.requestsLabel);
            this.Controls.Add(this.waitEstimateLabel);
            this.Controls.Add(this.waitEstimateTextBox);
            this.Controls.Add(this.pagerNumTextBox);
            this.Controls.Add(this.requestsTextBox);
            this.Controls.Add(this.guestNumTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.seatingQueue);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ReservationsForm";
            this.ShowIcon = false;
            this.Text = "Reservations";
            this.Load += new System.EventHandler(this.ReservationsForm_Load);
            this.seatingQueue.ResumeLayout(false);
            this.partyTypeGroupBox.ResumeLayout(false);
            this.partyTypeGroupBox.PerformLayout();
            this.takeOutGroupBox.ResumeLayout(false);
            this.reservationsGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox seatingQueue;
        private System.Windows.Forms.ListBox partyListBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox guestNumTextBox;
        private System.Windows.Forms.TextBox requestsTextBox;
        private System.Windows.Forms.TextBox pagerNumTextBox;
        private System.Windows.Forms.TextBox waitEstimateTextBox;
        private System.Windows.Forms.Label waitEstimateLabel;
        private System.Windows.Forms.Label requestsLabel;
        private System.Windows.Forms.Label pagerLabel;
        private System.Windows.Forms.Label guestNumLabel;
        private System.Windows.Forms.Label partyNameLabel;
        private System.Windows.Forms.GroupBox partyTypeGroupBox;
        private System.Windows.Forms.RadioButton takeOutRadioButton;
        private System.Windows.Forms.RadioButton reservationRadioButton;
        private System.Windows.Forms.RadioButton walkInRadioButton;
        private System.Windows.Forms.Button addPartyButton;
        private System.Windows.Forms.Label reservationFormTitleLabel;
        private System.Windows.Forms.Button seeTablesButton;
        private System.Windows.Forms.Label reservationTimeLabel;
        private System.Windows.Forms.TextBox reservationHourTextBox;
        private System.Windows.Forms.Label contactLabel;
        private System.Windows.Forms.TextBox contactTextBox;
        private System.Windows.Forms.TextBox reservationMinTextBox;
        private System.Windows.Forms.Label timeDescriptionLabel;
        private System.Windows.Forms.GroupBox takeOutGroupBox;
        private System.Windows.Forms.GroupBox reservationsGroupBox;
        private System.Windows.Forms.ListBox reservationsListBox;
        private System.Windows.Forms.CheckBox seatResCheckBox;
        private System.Windows.Forms.ListView takeOutListBox;
    }
}

