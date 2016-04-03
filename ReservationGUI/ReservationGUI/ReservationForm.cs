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
            int walkIn = 0;
            int reservation = 1;
            int takeOut = 2;
            int partyType = -1;


            if(walkInRadioButton.Checked)
            {
                partyType = walkIn;
            }
            else if (reservationRadioButton.Checked)
            {
                partyType = reservation;
            }
            else if (takeOutRadioButton.Checked)
            {
                partyType = takeOut;
            }

            Party currentParty = new Party(guestNumTextBox.Text, nameTextBox.Text, requestsTextBox.Text, pagerNumTextBox.Text, partyType);          

            partyListBox.Items.Add(partyName); //add party to list
        }

        private void guestNumTextBox_TextChanged(object sender, EventArgs e)
        {
            //if all tables are full show wait time
           
            //No wait time for party of 4 or less if all tables are empty
            waitEstimateTextBox.Text = "None"; 
        }
    }
}
