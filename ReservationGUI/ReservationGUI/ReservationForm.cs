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

            int resHour = 0; //time of reservation
            int resMin = 0; //time of reservation
            string contactNum = ""; //contact phone number for party
            int partyType = -1; //variable to hold party type

            //update party type
            if (walkInRadioButton.Checked)
            {
                partyType = WALKIN; //party is a walk in 
            }
            else if (reservationRadioButton.Checked)
            {
                partyType = RESERVATION; //party is a reservation
                resHour = Convert.ToInt32(reservationHourTextBox.Text); //hour of reservation
                resMin = Convert.ToInt32(reservationMinTextBox.Text); //minute of reservation
                contactNum = contactTextBox.Text; //contact phone number for party

                if(resHour < 21 && resHour > 10 && resMin > -1 && resMin < 61 && contactNum.Length == 7)
                {
                    wait.addReservation(guestNumTextBox.Text, nameTextBox.Text, requestsTextBox.Text, contactNum, resHour, resMin);
                }
                else
                {
                    MessageBox.Show("The contact number must be 7 digits and the reservation " +
                        "must be between 11:00 and 21:00. This reservation was not made, try again.");
                }

                
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
            reservationHourTextBox.Visible = true;
            contactLabel.Visible = true;
            contactTextBox.Visible = true;
        }
    }
}
