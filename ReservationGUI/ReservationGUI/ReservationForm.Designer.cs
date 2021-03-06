﻿namespace ReservationGUI
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
            this.seatTablesButton = new System.Windows.Forms.Button();
            this.timeLabel = new System.Windows.Forms.Label();
            this.hourTextBox = new System.Windows.Forms.TextBox();
            this.contactLabel = new System.Windows.Forms.Label();
            this.contactTextBox = new System.Windows.Forms.TextBox();
            this.minTextBox = new System.Windows.Forms.TextBox();
            this.timeDescriptionLabel = new System.Windows.Forms.Label();
            this.takeOutGroupBox = new System.Windows.Forms.GroupBox();
            this.takeOutListBox = new System.Windows.Forms.ListBox();
            this.reservationsGroupBox = new System.Windows.Forms.GroupBox();
            this.reservationsListBox = new System.Windows.Forms.ListBox();
            this.seatResCheckBox = new System.Windows.Forms.CheckBox();
            this.newPartyButton = new System.Windows.Forms.Button();
            this.tablesComboBox = new System.Windows.Forms.ComboBox();
            this.tablesLabel = new System.Windows.Forms.Label();
            this.resetTakeoutOrders = new System.Windows.Forms.Button();
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
            this.seatingQueue.Location = new System.Drawing.Point(15, 6);
            this.seatingQueue.Name = "seatingQueue";
            this.seatingQueue.Size = new System.Drawing.Size(156, 188);
            this.seatingQueue.TabIndex = 12;
            this.seatingQueue.TabStop = false;
            this.seatingQueue.Text = "Walk In Queue";
            // 
            // partyListBox
            // 
            this.partyListBox.FormattingEnabled = true;
            this.partyListBox.ItemHeight = 22;
            this.partyListBox.Location = new System.Drawing.Point(6, 22);
            this.partyListBox.Name = "partyListBox";
            this.partyListBox.Size = new System.Drawing.Size(144, 158);
            this.partyListBox.TabIndex = 11;
            this.partyListBox.SelectedIndexChanged += new System.EventHandler(this.partyListBox_SelectedIndexChanged);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTextBox.Location = new System.Drawing.Point(439, 63);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(131, 25);
            this.nameTextBox.TabIndex = 1;
            // 
            // guestNumTextBox
            // 
            this.guestNumTextBox.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guestNumTextBox.Location = new System.Drawing.Point(439, 98);
            this.guestNumTextBox.Name = "guestNumTextBox";
            this.guestNumTextBox.Size = new System.Drawing.Size(131, 25);
            this.guestNumTextBox.TabIndex = 2;
            this.guestNumTextBox.TextChanged += new System.EventHandler(this.guestNumTextBox_TextChanged);
            // 
            // requestsTextBox
            // 
            this.requestsTextBox.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.requestsTextBox.Location = new System.Drawing.Point(352, 203);
            this.requestsTextBox.Multiline = true;
            this.requestsTextBox.Name = "requestsTextBox";
            this.requestsTextBox.Size = new System.Drawing.Size(218, 56);
            this.requestsTextBox.TabIndex = 4;
            // 
            // pagerNumTextBox
            // 
            this.pagerNumTextBox.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagerNumTextBox.Location = new System.Drawing.Point(439, 133);
            this.pagerNumTextBox.Name = "pagerNumTextBox";
            this.pagerNumTextBox.Size = new System.Drawing.Size(131, 25);
            this.pagerNumTextBox.TabIndex = 3;
            // 
            // waitEstimateTextBox
            // 
            this.waitEstimateTextBox.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waitEstimateTextBox.Location = new System.Drawing.Point(439, 168);
            this.waitEstimateTextBox.Name = "waitEstimateTextBox";
            this.waitEstimateTextBox.ReadOnly = true;
            this.waitEstimateTextBox.Size = new System.Drawing.Size(131, 25);
            this.waitEstimateTextBox.TabIndex = 40;
            // 
            // waitEstimateLabel
            // 
            this.waitEstimateLabel.AutoSize = true;
            this.waitEstimateLabel.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waitEstimateLabel.Location = new System.Drawing.Point(186, 168);
            this.waitEstimateLabel.Name = "waitEstimateLabel";
            this.waitEstimateLabel.Size = new System.Drawing.Size(155, 22);
            this.waitEstimateLabel.TabIndex = 7;
            this.waitEstimateLabel.Text = "Wait Time Estimate:";
            // 
            // requestsLabel
            // 
            this.requestsLabel.AutoSize = true;
            this.requestsLabel.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.requestsLabel.Location = new System.Drawing.Point(186, 203);
            this.requestsLabel.Name = "requestsLabel";
            this.requestsLabel.Size = new System.Drawing.Size(128, 22);
            this.requestsLabel.TabIndex = 8;
            this.requestsLabel.Text = "Special Requests:";
            // 
            // pagerLabel
            // 
            this.pagerLabel.AutoSize = true;
            this.pagerLabel.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagerLabel.Location = new System.Drawing.Point(186, 133);
            this.pagerLabel.Name = "pagerLabel";
            this.pagerLabel.Size = new System.Drawing.Size(113, 22);
            this.pagerLabel.TabIndex = 9;
            this.pagerLabel.Text = "Pager Number:";
            // 
            // guestNumLabel
            // 
            this.guestNumLabel.AutoSize = true;
            this.guestNumLabel.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guestNumLabel.Location = new System.Drawing.Point(186, 98);
            this.guestNumLabel.Name = "guestNumLabel";
            this.guestNumLabel.Size = new System.Drawing.Size(137, 22);
            this.guestNumLabel.TabIndex = 10;
            this.guestNumLabel.Text = "Number of Guests:";
            // 
            // partyNameLabel
            // 
            this.partyNameLabel.AutoSize = true;
            this.partyNameLabel.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partyNameLabel.Location = new System.Drawing.Point(186, 63);
            this.partyNameLabel.Name = "partyNameLabel";
            this.partyNameLabel.Size = new System.Drawing.Size(97, 22);
            this.partyNameLabel.TabIndex = 11;
            this.partyNameLabel.Text = "Party Name:";
            // 
            // partyTypeGroupBox
            // 
            this.partyTypeGroupBox.Controls.Add(this.takeOutRadioButton);
            this.partyTypeGroupBox.Controls.Add(this.reservationRadioButton);
            this.partyTypeGroupBox.Controls.Add(this.walkInRadioButton);
            this.partyTypeGroupBox.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partyTypeGroupBox.Location = new System.Drawing.Point(174, 267);
            this.partyTypeGroupBox.Name = "partyTypeGroupBox";
            this.partyTypeGroupBox.Size = new System.Drawing.Size(124, 93);
            this.partyTypeGroupBox.TabIndex = 6;
            this.partyTypeGroupBox.TabStop = false;
            this.partyTypeGroupBox.Text = "Party Type";
            // 
            // takeOutRadioButton
            // 
            this.takeOutRadioButton.AutoSize = true;
            this.takeOutRadioButton.Location = new System.Drawing.Point(16, 65);
            this.takeOutRadioButton.Name = "takeOutRadioButton";
            this.takeOutRadioButton.Size = new System.Drawing.Size(91, 26);
            this.takeOutRadioButton.TabIndex = 3;
            this.takeOutRadioButton.Text = "Take Out";
            this.takeOutRadioButton.UseVisualStyleBackColor = true;
            this.takeOutRadioButton.CheckedChanged += new System.EventHandler(this.takeOutRadioButton_CheckedChanged);
            // 
            // reservationRadioButton
            // 
            this.reservationRadioButton.AutoSize = true;
            this.reservationRadioButton.Location = new System.Drawing.Point(16, 42);
            this.reservationRadioButton.Name = "reservationRadioButton";
            this.reservationRadioButton.Size = new System.Drawing.Size(109, 26);
            this.reservationRadioButton.TabIndex = 2;
            this.reservationRadioButton.Text = "Reservation";
            this.reservationRadioButton.UseVisualStyleBackColor = true;
            this.reservationRadioButton.CheckedChanged += new System.EventHandler(this.reservationRadioButton_CheckedChanged);
            // 
            // walkInRadioButton
            // 
            this.walkInRadioButton.AutoSize = true;
            this.walkInRadioButton.Checked = true;
            this.walkInRadioButton.Location = new System.Drawing.Point(16, 19);
            this.walkInRadioButton.Name = "walkInRadioButton";
            this.walkInRadioButton.Size = new System.Drawing.Size(86, 26);
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
            this.addPartyButton.Location = new System.Drawing.Point(445, 395);
            this.addPartyButton.Name = "addPartyButton";
            this.addPartyButton.Size = new System.Drawing.Size(125, 32);
            this.addPartyButton.TabIndex = 7;
            this.addPartyButton.Text = "Add Party";
            this.addPartyButton.UseVisualStyleBackColor = false;
            this.addPartyButton.Click += new System.EventHandler(this.addPartyButton_Click);
            // 
            // reservationFormTitleLabel
            // 
            this.reservationFormTitleLabel.AutoSize = true;
            this.reservationFormTitleLabel.Font = new System.Drawing.Font("Monotype Corsiva", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reservationFormTitleLabel.Location = new System.Drawing.Point(217, 9);
            this.reservationFormTitleLabel.Name = "reservationFormTitleLabel";
            this.reservationFormTitleLabel.Size = new System.Drawing.Size(175, 28);
            this.reservationFormTitleLabel.TabIndex = 14;
            this.reservationFormTitleLabel.Text = "Waitlist Handler";
            // 
            // seatTablesButton
            // 
            this.seatTablesButton.BackColor = System.Drawing.SystemColors.HighlightText;
            this.seatTablesButton.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.seatTablesButton.FlatAppearance.BorderSize = 2;
            this.seatTablesButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.seatTablesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.seatTablesButton.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seatTablesButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.seatTablesButton.Location = new System.Drawing.Point(314, 395);
            this.seatTablesButton.Name = "seatTablesButton";
            this.seatTablesButton.Size = new System.Drawing.Size(125, 32);
            this.seatTablesButton.TabIndex = 10;
            this.seatTablesButton.Text = "Seat Tables";
            this.seatTablesButton.UseVisualStyleBackColor = false;
            this.seatTablesButton.Click += new System.EventHandler(this.seeTablesButton_Click);
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.Location = new System.Drawing.Point(299, 323);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(134, 22);
            this.timeLabel.TabIndex = 16;
            this.timeLabel.Text = "Reservation Time:";
            this.timeLabel.Visible = false;
            // 
            // hourTextBox
            // 
            this.hourTextBox.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hourTextBox.Location = new System.Drawing.Point(439, 320);
            this.hourTextBox.Name = "hourTextBox";
            this.hourTextBox.Size = new System.Drawing.Size(58, 25);
            this.hourTextBox.TabIndex = 6;
            this.hourTextBox.Visible = false;
            // 
            // contactLabel
            // 
            this.contactLabel.AutoSize = true;
            this.contactLabel.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contactLabel.Location = new System.Drawing.Point(318, 281);
            this.contactLabel.Name = "contactLabel";
            this.contactLabel.Size = new System.Drawing.Size(115, 22);
            this.contactLabel.TabIndex = 18;
            this.contactLabel.Text = "Contact Phone:";
            this.contactLabel.Visible = false;
            // 
            // contactTextBox
            // 
            this.contactTextBox.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contactTextBox.Location = new System.Drawing.Point(439, 276);
            this.contactTextBox.Name = "contactTextBox";
            this.contactTextBox.Size = new System.Drawing.Size(131, 25);
            this.contactTextBox.TabIndex = 5;
            this.contactTextBox.Visible = false;
            // 
            // minTextBox
            // 
            this.minTextBox.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minTextBox.Location = new System.Drawing.Point(512, 319);
            this.minTextBox.Name = "minTextBox";
            this.minTextBox.Size = new System.Drawing.Size(58, 25);
            this.minTextBox.TabIndex = 7;
            this.minTextBox.Visible = false;
            // 
            // timeDescriptionLabel
            // 
            this.timeDescriptionLabel.AutoSize = true;
            this.timeDescriptionLabel.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeDescriptionLabel.Location = new System.Drawing.Point(435, 357);
            this.timeDescriptionLabel.Name = "timeDescriptionLabel";
            this.timeDescriptionLabel.Size = new System.Drawing.Size(144, 22);
            this.timeDescriptionLabel.TabIndex = 21;
            this.timeDescriptionLabel.Text = "Ex: 18 30 is 6:30pm";
            this.timeDescriptionLabel.Visible = false;
            // 
            // takeOutGroupBox
            // 
            this.takeOutGroupBox.Controls.Add(this.takeOutListBox);
            this.takeOutGroupBox.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.takeOutGroupBox.Location = new System.Drawing.Point(15, 316);
            this.takeOutGroupBox.Name = "takeOutGroupBox";
            this.takeOutGroupBox.Size = new System.Drawing.Size(156, 122);
            this.takeOutGroupBox.TabIndex = 13;
            this.takeOutGroupBox.TabStop = false;
            this.takeOutGroupBox.Text = "Take Out Orders";
            // 
            // takeOutListBox
            // 
            this.takeOutListBox.ItemHeight = 22;
            this.takeOutListBox.Location = new System.Drawing.Point(6, 24);
            this.takeOutListBox.Name = "takeOutListBox";
            this.takeOutListBox.Size = new System.Drawing.Size(144, 92);
            this.takeOutListBox.TabIndex = 0;
            this.takeOutListBox.SelectedIndexChanged += new System.EventHandler(this.takeOutListBox_SelectedIndexChanged);
            // 
            // reservationsGroupBox
            // 
            this.reservationsGroupBox.Controls.Add(this.reservationsListBox);
            this.reservationsGroupBox.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reservationsGroupBox.Location = new System.Drawing.Point(15, 194);
            this.reservationsGroupBox.Name = "reservationsGroupBox";
            this.reservationsGroupBox.Size = new System.Drawing.Size(156, 122);
            this.reservationsGroupBox.TabIndex = 13;
            this.reservationsGroupBox.TabStop = false;
            this.reservationsGroupBox.Text = "Reservations";
            // 
            // reservationsListBox
            // 
            this.reservationsListBox.FormattingEnabled = true;
            this.reservationsListBox.ItemHeight = 22;
            this.reservationsListBox.Location = new System.Drawing.Point(6, 22);
            this.reservationsListBox.Name = "reservationsListBox";
            this.reservationsListBox.Size = new System.Drawing.Size(144, 92);
            this.reservationsListBox.TabIndex = 11;
            this.reservationsListBox.SelectedIndexChanged += new System.EventHandler(this.reservationsListBox_SelectedIndexChanged);
            // 
            // seatResCheckBox
            // 
            this.seatResCheckBox.AutoSize = true;
            this.seatResCheckBox.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seatResCheckBox.Location = new System.Drawing.Point(177, 235);
            this.seatResCheckBox.Name = "seatResCheckBox";
            this.seatResCheckBox.Size = new System.Drawing.Size(164, 26);
            this.seatResCheckBox.TabIndex = 22;
            this.seatResCheckBox.Text = "reservation check in";
            this.seatResCheckBox.UseVisualStyleBackColor = true;
            this.seatResCheckBox.Visible = false;
            this.seatResCheckBox.CheckedChanged += new System.EventHandler(this.seatResCheckBox_CheckedChanged);
            // 
            // newPartyButton
            // 
            this.newPartyButton.BackColor = System.Drawing.SystemColors.HighlightText;
            this.newPartyButton.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.newPartyButton.FlatAppearance.BorderSize = 2;
            this.newPartyButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.newPartyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newPartyButton.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPartyButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.newPartyButton.Location = new System.Drawing.Point(439, 12);
            this.newPartyButton.Name = "newPartyButton";
            this.newPartyButton.Size = new System.Drawing.Size(136, 32);
            this.newPartyButton.TabIndex = 41;
            this.newPartyButton.Text = "New Party";
            this.newPartyButton.UseVisualStyleBackColor = false;
            this.newPartyButton.Visible = false;
            this.newPartyButton.Click += new System.EventHandler(this.newPartyButton_Click);
            // 
            // tablesComboBox
            // 
            this.tablesComboBox.FormattingEnabled = true;
            this.tablesComboBox.Location = new System.Drawing.Point(352, 289);
            this.tablesComboBox.Name = "tablesComboBox";
            this.tablesComboBox.Size = new System.Drawing.Size(121, 21);
            this.tablesComboBox.TabIndex = 42;
            this.tablesComboBox.Visible = false;
            this.tablesComboBox.SelectedIndexChanged += new System.EventHandler(this.tablesComboBox_SelectedIndexChanged);
            // 
            // tablesLabel
            // 
            this.tablesLabel.AutoSize = true;
            this.tablesLabel.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tablesLabel.Location = new System.Drawing.Point(318, 264);
            this.tablesLabel.Name = "tablesLabel";
            this.tablesLabel.Size = new System.Drawing.Size(121, 22);
            this.tablesLabel.TabIndex = 43;
            this.tablesLabel.Text = "Avalible Tables:";
            this.tablesLabel.Visible = false;
            // 
            // resetTakeoutOrders
            // 
            this.resetTakeoutOrders.BackColor = System.Drawing.SystemColors.HighlightText;
            this.resetTakeoutOrders.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.resetTakeoutOrders.FlatAppearance.BorderSize = 2;
            this.resetTakeoutOrders.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.resetTakeoutOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetTakeoutOrders.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetTakeoutOrders.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.resetTakeoutOrders.Location = new System.Drawing.Point(183, 366);
            this.resetTakeoutOrders.Name = "resetTakeoutOrders";
            this.resetTakeoutOrders.Size = new System.Drawing.Size(125, 61);
            this.resetTakeoutOrders.TabIndex = 44;
            this.resetTakeoutOrders.Text = "Reset Take Out List";
            this.resetTakeoutOrders.UseVisualStyleBackColor = false;
            this.resetTakeoutOrders.Click += new System.EventHandler(this.button1_Click);
            // 
            // ReservationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(608, 439);
            this.Controls.Add(this.resetTakeoutOrders);
            this.Controls.Add(this.tablesLabel);
            this.Controls.Add(this.tablesComboBox);
            this.Controls.Add(this.newPartyButton);
            this.Controls.Add(this.seatResCheckBox);
            this.Controls.Add(this.reservationsGroupBox);
            this.Controls.Add(this.takeOutGroupBox);
            this.Controls.Add(this.timeDescriptionLabel);
            this.Controls.Add(this.minTextBox);
            this.Controls.Add(this.contactTextBox);
            this.Controls.Add(this.contactLabel);
            this.Controls.Add(this.hourTextBox);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.seatTablesButton);
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
        private System.Windows.Forms.Button seatTablesButton;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.TextBox hourTextBox;
        private System.Windows.Forms.Label contactLabel;
        private System.Windows.Forms.TextBox contactTextBox;
        private System.Windows.Forms.TextBox minTextBox;
        private System.Windows.Forms.Label timeDescriptionLabel;
        private System.Windows.Forms.GroupBox takeOutGroupBox;
        private System.Windows.Forms.GroupBox reservationsGroupBox;
        private System.Windows.Forms.ListBox reservationsListBox;
        private System.Windows.Forms.CheckBox seatResCheckBox;
        private System.Windows.Forms.Button newPartyButton;
        private System.Windows.Forms.ComboBox tablesComboBox;
        private System.Windows.Forms.Label tablesLabel;
        private System.Windows.Forms.ListBox takeOutListBox;
        private System.Windows.Forms.Button resetTakeoutOrders;
    }
}

