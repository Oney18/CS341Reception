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
            this.seatPartyButton = new System.Windows.Forms.Button();
            this.seatingQueue.SuspendLayout();
            this.partyTypeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // seatingQueue
            // 
            this.seatingQueue.Controls.Add(this.partyListBox);
            this.seatingQueue.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seatingQueue.Location = new System.Drawing.Point(12, 49);
            this.seatingQueue.Name = "seatingQueue";
            this.seatingQueue.Size = new System.Drawing.Size(129, 256);
            this.seatingQueue.TabIndex = 12;
            this.seatingQueue.TabStop = false;
            this.seatingQueue.Text = "Seating Queue";
            // 
            // partyListBox
            // 
            this.partyListBox.FormattingEnabled = true;
            this.partyListBox.ItemHeight = 22;
            this.partyListBox.Location = new System.Drawing.Point(6, 28);
            this.partyListBox.Name = "partyListBox";
            this.partyListBox.Size = new System.Drawing.Size(117, 224);
            this.partyListBox.TabIndex = 11;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTextBox.Location = new System.Drawing.Point(390, 52);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(131, 25);
            this.nameTextBox.TabIndex = 1;
            // 
            // guestNumTextBox
            // 
            this.guestNumTextBox.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guestNumTextBox.Location = new System.Drawing.Point(390, 87);
            this.guestNumTextBox.Name = "guestNumTextBox";
            this.guestNumTextBox.Size = new System.Drawing.Size(131, 25);
            this.guestNumTextBox.TabIndex = 2;
            // 
            // requestsTextBox
            // 
            this.requestsTextBox.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.requestsTextBox.Location = new System.Drawing.Point(303, 192);
            this.requestsTextBox.Multiline = true;
            this.requestsTextBox.Name = "requestsTextBox";
            this.requestsTextBox.Size = new System.Drawing.Size(218, 56);
            this.requestsTextBox.TabIndex = 5;
            // 
            // pagerNumTextBox
            // 
            this.pagerNumTextBox.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagerNumTextBox.Location = new System.Drawing.Point(390, 122);
            this.pagerNumTextBox.Name = "pagerNumTextBox";
            this.pagerNumTextBox.Size = new System.Drawing.Size(131, 25);
            this.pagerNumTextBox.TabIndex = 3;
            // 
            // waitEstimateTextBox
            // 
            this.waitEstimateTextBox.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waitEstimateTextBox.Location = new System.Drawing.Point(390, 157);
            this.waitEstimateTextBox.Name = "waitEstimateTextBox";
            this.waitEstimateTextBox.Size = new System.Drawing.Size(131, 25);
            this.waitEstimateTextBox.TabIndex = 4;
            // 
            // waitEstimateLabel
            // 
            this.waitEstimateLabel.AutoSize = true;
            this.waitEstimateLabel.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waitEstimateLabel.Location = new System.Drawing.Point(174, 157);
            this.waitEstimateLabel.Name = "waitEstimateLabel";
            this.waitEstimateLabel.Size = new System.Drawing.Size(155, 22);
            this.waitEstimateLabel.TabIndex = 7;
            this.waitEstimateLabel.Text = "Wait Time Estimate:";
            // 
            // requestsLabel
            // 
            this.requestsLabel.AutoSize = true;
            this.requestsLabel.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.requestsLabel.Location = new System.Drawing.Point(174, 192);
            this.requestsLabel.Name = "requestsLabel";
            this.requestsLabel.Size = new System.Drawing.Size(128, 22);
            this.requestsLabel.TabIndex = 8;
            this.requestsLabel.Text = "Special Requests:";
            // 
            // pagerLabel
            // 
            this.pagerLabel.AutoSize = true;
            this.pagerLabel.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagerLabel.Location = new System.Drawing.Point(174, 122);
            this.pagerLabel.Name = "pagerLabel";
            this.pagerLabel.Size = new System.Drawing.Size(113, 22);
            this.pagerLabel.TabIndex = 9;
            this.pagerLabel.Text = "Pager Number:";
            // 
            // guestNumLabel
            // 
            this.guestNumLabel.AutoSize = true;
            this.guestNumLabel.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guestNumLabel.Location = new System.Drawing.Point(174, 87);
            this.guestNumLabel.Name = "guestNumLabel";
            this.guestNumLabel.Size = new System.Drawing.Size(137, 22);
            this.guestNumLabel.TabIndex = 10;
            this.guestNumLabel.Text = "Number of Guests:";
            // 
            // partyNameLabel
            // 
            this.partyNameLabel.AutoSize = true;
            this.partyNameLabel.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partyNameLabel.Location = new System.Drawing.Point(174, 52);
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
            this.partyTypeGroupBox.Location = new System.Drawing.Point(178, 252);
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
            this.takeOutRadioButton.TabStop = true;
            this.takeOutRadioButton.Text = "Take Out";
            this.takeOutRadioButton.UseVisualStyleBackColor = true;
            // 
            // reservationRadioButton
            // 
            this.reservationRadioButton.AutoSize = true;
            this.reservationRadioButton.Location = new System.Drawing.Point(16, 42);
            this.reservationRadioButton.Name = "reservationRadioButton";
            this.reservationRadioButton.Size = new System.Drawing.Size(109, 26);
            this.reservationRadioButton.TabIndex = 2;
            this.reservationRadioButton.TabStop = true;
            this.reservationRadioButton.Text = "Reservation";
            this.reservationRadioButton.UseVisualStyleBackColor = true;
            // 
            // walkInRadioButton
            // 
            this.walkInRadioButton.AutoSize = true;
            this.walkInRadioButton.Location = new System.Drawing.Point(16, 19);
            this.walkInRadioButton.Name = "walkInRadioButton";
            this.walkInRadioButton.Size = new System.Drawing.Size(86, 26);
            this.walkInRadioButton.TabIndex = 1;
            this.walkInRadioButton.TabStop = true;
            this.walkInRadioButton.Text = "Walk In";
            this.walkInRadioButton.UseVisualStyleBackColor = true;
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
            this.addPartyButton.Location = new System.Drawing.Point(356, 288);
            this.addPartyButton.Name = "addPartyButton";
            this.addPartyButton.Size = new System.Drawing.Size(136, 32);
            this.addPartyButton.TabIndex = 7;
            this.addPartyButton.Text = "Add Party";
            this.addPartyButton.UseVisualStyleBackColor = false;
            // 
            // reservationFormTitleLabel
            // 
            this.reservationFormTitleLabel.AutoSize = true;
            this.reservationFormTitleLabel.Font = new System.Drawing.Font("Monotype Corsiva", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reservationFormTitleLabel.Location = new System.Drawing.Point(208, 9);
            this.reservationFormTitleLabel.Name = "reservationFormTitleLabel";
            this.reservationFormTitleLabel.Size = new System.Drawing.Size(175, 28);
            this.reservationFormTitleLabel.TabIndex = 14;
            this.reservationFormTitleLabel.Text = "Waitlist Handler";
            // 
            // seatPartyButton
            // 
            this.seatPartyButton.BackColor = System.Drawing.SystemColors.HighlightText;
            this.seatPartyButton.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.seatPartyButton.FlatAppearance.BorderSize = 2;
            this.seatPartyButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.seatPartyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.seatPartyButton.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seatPartyButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.seatPartyButton.Location = new System.Drawing.Point(10, 313);
            this.seatPartyButton.Name = "seatPartyButton";
            this.seatPartyButton.Size = new System.Drawing.Size(136, 32);
            this.seatPartyButton.TabIndex = 10;
            this.seatPartyButton.Text = "Seat Party";
            this.seatPartyButton.UseVisualStyleBackColor = false;
            this.seatPartyButton.Click += new System.EventHandler(this.seatPartyButton_Click);
            // 
            // ReservationsForm
            // 
            this.AcceptButton = this.addPartyButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(591, 372);
            this.Controls.Add(this.seatPartyButton);
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
        private System.Windows.Forms.Button seatPartyButton;
    }
}

