using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReservationGUI
{
    public partial class ReservationsForm : Form
    {
        private Waitlist wait = new Waitlist(16); //creates lists for current and past reservations, walk ins

        public ReservationsForm()
        {
            InitializeComponent();
        }

        private void ReservationsForm_Load(object sender, EventArgs e)
        {
            
        }

        private void seatPartyButton_Click(object sender, EventArgs e)
        {
            SeatingForm seat = new SeatingForm();
            seat.Show();
        }

        private void addPartyButton_Click(object sender, EventArgs e)
        {
            //set constants for party type
            int WALKIN = 0;        
            int RESERVATION = 1;
            int TAKEOUT = 2;

            string resTime = ""; //time of reservation
            string contactNum = ""; //contact phone number
            int partyType = -1; //variable to hold party type

            //update party type
            if (walkInRadioButton.Checked)
            {
                partyType = WALKIN; //party is a walk in 
            }
            else if (reservationRadioButton.Checked)
            {
                partyType = RESERVATION; //party is a reservation
                resTime = reservationTimeTextBox.Text; //time of reservation
                contactNum = contactTextBox.Text; //contact phone number for party
                
                
                Party currentParty = new Party(guestNumTextBox.Text, nameTextBox.Text, requestsTextBox.Text, pagerNumTextBox.Text, partyType);
            }
            else if (takeOutRadioButton.Checked)
            {
                partyType = TAKEOUT;
            }
            
            

           // partyListBox.Items.Add(partyName); //add party to list
        }

        private void guestNumTextBox_TextChanged(object sender, EventArgs e)
        {
            //if all tables are full show wait time
           
            //No wait time for party of 4 or less if all tables are empty
            waitEstimateTextBox.Text = "None"; 
        }

        private void reservationRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //show reservation boxes to get time and contact for reservation
            reservationTimeLabel.Visible = true;
            reservationTimeTextBox.Visible = true;
            contactLabel.Visible = true;
            contactTextBox.Visible = true;
        }
    }
}
