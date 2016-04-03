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

            //variable to hold party type
            int partyType = -1;

            //update party type
            if(walkInRadioButton.Checked)
            {
                partyType = WALKIN;
            }
            else if (reservationRadioButton.Checked)
            {
                partyType = RESERVATION;
            }
            else if (takeOutRadioButton.Checked)
            {
                partyType = TAKEOUT;
            }

            //create party
            Party currentParty = new Party(guestNumTextBox.Text, nameTextBox.Text, requestsTextBox.Text, pagerNumTextBox.Text, partyType);          

           // partyListBox.Items.Add(partyName); //add party to list
        }

        private void guestNumTextBox_TextChanged(object sender, EventArgs e)
        {
            //if all tables are full show wait time
           
            //No wait time for party of 4 or less if all tables are empty
            waitEstimateTextBox.Text = "None"; 
        }
    }
}
