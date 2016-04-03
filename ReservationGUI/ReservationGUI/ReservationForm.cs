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

        /*add party to appropriate list for reservations, walkins, and take outs*/
        private void addPartyButton_Click(object sender, EventArgs e)
        {
            int resHour = 0;            //time of reservation
            int resMin = 0;             //time of reservation
            string contactNum = "";     //contact phone number for party
            int check;                  //int to check if phone number is an int            

            //update party type
            if (walkInRadioButton.Checked) //if walk in
            {
                //add walk in party to waitlist
                wait.addWalkIn(guestNumTextBox.Text, nameTextBox.Text, requestsTextBox.Text, pagerNumTextBox.Text);
            }
            else if (reservationRadioButton.Checked) //if reservation
            {
                //get time of reservation
                string hour = reservationHourTextBox.Text; 
                string min = reservationMinTextBox.Text;

                if (hour != "" && min != "" && int.TryParse(hour, out check) && int.TryParse(min, out check)) {
                    resHour = Convert.ToInt32(hour);            //hour of reservation
                    resMin = Convert.ToInt32(min);              //minute of reservation
                    contactNum = contactTextBox.Text;           //contact phone number for party 

                    //check if reservation is in restaurant operating hours and the phone number is a 7 digit number
                    if (resHour < 21 && resHour > 10 && resMin > -1 && resMin < 61 && contactNum.Length == 7 && int.TryParse(contactNum, out check))
                    {
                        //add party to reservation list
                        wait.addReservation(guestNumTextBox.Text, nameTextBox.Text, requestsTextBox.Text, contactNum, resHour, resMin);
                    }
                    else //invalid inputs
                    {
                        MessageBox.Show("The contact number must be 7 digits and the reservation " +
                            "must be between 11:00 and 21:00. This reservation was not made, try again.");
                    }
                }
                else //invalid inputs
                {
                    MessageBox.Show("You must fill in a contact number and reservation time! This reservation was not made, try again.");
                }                        

                //hide time and contact input fields
                hideTime();
                hideContact();
            }
            else if (takeOutRadioButton.Checked) //if take out 
            {
                contactNum = contactTextBox.Text;   //contact phone number for party                
                if (contactNum.Length == 7 && int.TryParse(contactNum, out check))  //check for length of phone number and if a valid number
                {
                    wait.addTakeOut(nameTextBox.Text, contactNum); //add party to take out list
                }
                else
                {
                    MessageBox.Show("The contact number must be 7 digits, try again.");
                }

                //hide contact input field
                hideContact();
            }
        }

        /*hides the reservation time input fields*/
        private void hideTime()
        {
            reservationTimeLabel.Visible = false;
            timeDescriptionLabel.Visible = false;
            reservationHourTextBox.Visible = false;
            reservationMinTextBox.Visible = false;
        }

        /*hides the contact input fields*/
        private void hideContact()
        {
            contactLabel.Visible = false;
            contactTextBox.Visible = false;
        }

        /*estimates wait time based on tables available and party size*/
        private void guestNumTextBox_TextChanged(object sender, EventArgs e)
        {
            string guestNum = guestNumTextBox.Text; //get number of guests in party
            int check; //int to check if string is an int

            //check for integer
            if(int.TryParse(guestNum, out check))
            {
                addPartyButton.Enabled = true;
                //if all tables are full show wait time
                //No wait time for party of 4 or less if all tables are empty
                waitEstimateTextBox.Text = "None";
            }
            else
            {
                addPartyButton.Enabled = false;
                MessageBox.Show("You need to put the number of guests.");
            }

        }

        /*makes contact and time input fields visible when reservation radio button is selected*/
        private void reservationRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //show reservation boxes to get time and contact for reservation
            reservationTimeLabel.Visible = true;
            timeDescriptionLabel.Visible = true;
            reservationHourTextBox.Visible = true;
            reservationMinTextBox.Visible = true;
            showContact();
        }

        /*makes contact input fields visible when takeout radio button is selected*/
        private void takeOutRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            showContact(); //show contact input fields to get input
            hideTime(); //hide time input fields
        }

        /*makes contact input fields visible*/
        private void showContact()
        {
            //show contact box so can get contact phone number for take out order
            contactLabel.Visible = true;
            contactTextBox.Visible = true;            
        }

        /*hide contact and time input fields when walk in*/
        private void walkInRadioButton_CheckedChanged(object sender, EventArgs e)
        {          
            hideContact();
            hideTime();
        }
        
    }
}
