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
            int resHour = 0;            //time of reservation
            int resMin = 0;             //time of reservation
            string contactNum = "";     //contact phone number for party
            int check;                  //int to check if phone number is an int            

            //update party type
            if (walkInRadioButton.Checked)
            {
                //add walk in party to waitlist
                wait.addWalkIn(guestNumTextBox.Text, nameTextBox.Text, requestsTextBox.Text, pagerNumTextBox.Text);
            }
            else if (reservationRadioButton.Checked)
            {
                resHour = Convert.ToInt32(reservationHourTextBox.Text); //hour of reservation
                resMin = Convert.ToInt32(reservationMinTextBox.Text);   //minute of reservation
                contactNum = contactTextBox.Text;                       //contact phone number for party                

                //check if reservation is in restaurant operating hours and the phone number is a 7 digit number
                if(resHour < 21 && resHour > 10 && resMin > -1 && resMin < 61 && contactNum.Length == 7 && int.TryParse(contactNum, out check))
                {
                    wait.addReservation(guestNumTextBox.Text, nameTextBox.Text, requestsTextBox.Text, contactNum, resHour, resMin);                   
                }
                else
                {
                    MessageBox.Show("The contact number must be 7 digits and the reservation " +
                        "must be between 11:00 and 21:00. This reservation was not made, try again.");
                }

                //hide time and contact input fields
                hideTime();
                hideContact();
            }
            else if (takeOutRadioButton.Checked)
            {
                contactNum = contactTextBox.Text;   //contact phone number for party                
                if (contactNum.Length == 7 && int.TryParse(contactNum, out check))  //check for length of phone number and if a valid number
                {
                    wait.addTakeOut(nameTextBox.Text, contactNum);
                }
                else
                {
                    MessageBox.Show("The contact number must be 7 digits, try again.");
                }

                //hide contact input field
                hideContact();
            }
        }

        private void hideTime()
        {
            reservationTimeLabel.Visible = false;
            timeDescriptionLabel.Visible = false;
            reservationHourTextBox.Visible = false;
            reservationMinTextBox.Visible = false;
        }

        private void hideContact()
        {
            contactLabel.Visible = false;
            contactTextBox.Visible = false;
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
            timeDescriptionLabel.Visible = true;
            reservationHourTextBox.Visible = true;
            reservationMinTextBox.Visible = true;
            contactLabel.Visible = true;
            contactTextBox.Visible = true;
        }

        private void takeOutRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //show contact box so can get contact phone number for take out order
            contactLabel.Visible = true;
            contactTextBox.Visible = true;
        }
    }
}
