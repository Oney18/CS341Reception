using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            }
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

        /*
         * infoFromWaitStaff_updateTakeOutListBox()
         * 
         * reads through each line in recWait.txt in order to find names (not a number)
         * once we find a currently existing legal name, color it green
         */ 
        private void infoFromWaitStaff_updateTakeOutListBox()
        {
            foreach(string line in File.ReadLines(@"C:\ReceptionFiles\recWait.txt"))
            {
                //if the line is not a number corresponding to a table
                if (!(line.Contains("0") ||
                   line.Contains("1") ||
                   line.Contains("2") ||
                   line.Contains("3") ||
                   line.Contains("4") ||
                   line.Contains("5") ||
                   line.Contains("6") ||
                   line.Contains("7") ||
                   line.Contains("8") ||
                   line.Contains("9") ||
                   line.Contains("10") ||
                   line.Contains("11") ||
                   line.Contains("12") ||
                   line.Contains("13") ||
                   line.Contains("14") ||
                   line.Contains("15")))
                {
                    line.Trim(); //removes excess whitespace so that we only have the name
                    //line.ToLower(); //converts to all lowercase
                    if(takeOutListBox.Items.Contains(line)) //check to make sure we are editing a legal name
                    {
                        int index = takeOutListBox.Items.IndexOf(line); //get index
                        //TODO: takeOutListBox.Items[index]
                    }
                }
            }
        }
    }
}
