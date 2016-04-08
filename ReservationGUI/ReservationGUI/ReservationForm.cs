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
        private Waitlist wait = new Waitlist(16);                     //lists for current and past reservations, walk ins
        private SeatingForm seat = new SeatingForm();                 //creates seating form
        private LinkedList<Party> walkIns = new LinkedList<Party>();  //used to access the walkin list from wait

        public ReservationsForm()
        {
            InitializeComponent();
        }

        private void ReservationsForm_Load(object sender, EventArgs e)
        {
            
        }        

        /*add party to appropriate list for reservations, walkins, and take outs*/
        private void addPartyButton_Click(object sender, EventArgs e)
        {
            string hour = "";          //time of reservation
            string min = "";          //time of reservation
            string contactNum = "";     //contact phone number for party
            int check;                  //int to check if phone number is an int            

            //update party type
            if (walkInRadioButton.Checked) //if walk in
            {
                //add walk in party to waitlist
                wait.addWalkIn(guestNumTextBox.Text, nameTextBox.Text, requestsTextBox.Text, pagerNumTextBox.Text);
                partyListBox.Items.Add(nameTextBox.Text); //add name to waitlist on GUI
            }
            else if (reservationRadioButton.Checked) //if reservation
            {
                //get time of reservation
                hour = hourTextBox.Text;
                min = minTextBox.Text;

                if (hour != "" && min != "" && int.TryParse(hour, out check) && int.TryParse(min, out check)) {                    
                    contactNum = contactTextBox.Text;           //contact phone number for party 
                    
                    //check if reservation is at an appropriate time and the phone number is a 7 digit number
                    if ( checkTime(hour, min) && checkContact(contactNum))
                    {
                        //add party to reservation list
                        wait.addReservation(guestNumTextBox.Text, nameTextBox.Text, requestsTextBox.Text, contactNum, Convert.ToInt32(hour), Convert.ToInt32(min));
                        reservationsListBox.Items.Add(nameTextBox.Text + " at " + hour + ":" + min); //add name to reservation list
                    }
                    else //invalid inputs
                    {
                         MessageBox.Show("The contact number must be 7 digits and the reservation " +
                            "must be between 11:00 and 21:00 and more than an hour prior to dining. This reservation was not made, try again.");
                    }
                }
                else //invalid inputs
                {
                    MessageBox.Show("You must fill in a contact number and reservation time! This reservation was not made, try again.");
                }                

                //reset time and contact input fields
                resetTimeField();
                resetContactField();
            }
            else if (takeOutRadioButton.Checked) //if take out 
            {
                hour = hourTextBox.Text;
                min = minTextBox.Text;    
                contactNum = contactTextBox.Text;   //contact phone number for party                
                if (checkTime(hour, min) && checkContact(contactNum))  //check for length of phone number and if a valid number
                {
                    wait.addTakeOut(nameTextBox.Text, contactNum, Convert.ToInt32(hour), Convert.ToInt32(min)); //add party to take out list
                }
                else
                {
                    MessageBox.Show("The contact number must be 7 digits, try again.");
                }                

                //hide contact and time input fields
                resetContactField();
                resetTimeField(); 
            }
        }

        private bool checkContact(string contactNum)
        {
            int check; //counter to check if value is an integer
            bool validForm = false; //valid form is false unless proved correct

            if(contactNum.Length == 7 && int.TryParse(contactNum, out check)) { validForm = true; }
            return validForm;                    
        }

        private bool checkTime(string hour, string min)
        {
            int check; //counter to check if value is an integer
            bool timeInBounds = false; //time is not in restaurant operating hours unless proved otherwise

            if (hour != "" && min != "" && int.TryParse(hour, out check) && int.TryParse(min, out check))
            {
                int resHour = Convert.ToInt32(hour);            //hour of reservation
                int resMin = Convert.ToInt32(min);              //minute of reservation

                //check if reservation is at an appropriate time and the phone number is a 7 digit number
                if (resHour - DateTime.Now.Hour > 0 && resHour < 21 && resHour > 10 && resMin > -1 && resMin < 61)
                {
                    timeInBounds = true;
                }
            }

            return timeInBounds; //true if time is during restaurant hours of operation
        }

        /*hides the reservation time input fields*/
        private void resetTimeField()
        {
            hourTextBox.Text = "";
            minTextBox.Text = "";
            timeLabel.Visible = false;
            timeDescriptionLabel.Visible = false;
            hourTextBox.Visible = false;
            minTextBox.Visible = false;
        }

        /*hides and clears the contact input fields*/
        private void resetContactField()
        {
            contactTextBox.Text = ""; 
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
            waitEstimateTextBox.Text = wait.getWaitTime(); 
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
            timeDescriptionLabel.Text = "Reservation Time:";
            showTimeFields();
            showContact();
        }

        /*makes contact input fields visible when takeout radio button is selected*/
        private void takeOutRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            timeDescriptionLabel.Text = "Pick Up Time:";    //change time label
            showTimeFields();                               //show time fields
            showContact();                                  //show contact input fields to get input
        }

        private void showTimeFields()
        {
            timeLabel.Visible = true;
            timeDescriptionLabel.Visible = true;
            hourTextBox.Visible = true;
            minTextBox.Visible = true;
        }

        /*makes contact input fields visible*/
        private void showContact()
        {
            //show contact box so can get contact phone number for take out order
            contactLabel.Visible = true;
            contactTextBox.Visible = true;
        }

        /*hide and clear contact and time input fields when walk in*/
        private void walkInRadioButton_CheckedChanged(object sender, EventArgs e)
        {          
            resetContactField();
            resetTimeField();

        }

        /*Display the seat form GUI*/
        private void seeTablesButton_Click(object sender, EventArgs e)
        {
            seat.Show();
        }
    }
}
