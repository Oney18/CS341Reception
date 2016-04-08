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
            string hour = "";           //time of reservation
            string min = "";            //time of reservation
            string contactNum = "";     //contact phone number for party            
            bool reservation = reservationRadioButton.Checked;  //if reservation selected then true
            bool takeout = takeOutRadioButton.Checked;          //if takeout order then true

            //update party type
            if (walkInRadioButton.Checked) //if walk in
            {
                //add walk in party to waitlist
                wait.addWalkIn(guestNumTextBox.Text, nameTextBox.Text, requestsTextBox.Text, pagerNumTextBox.Text);
                partyListBox.Items.Add(nameTextBox.Text); //add name to waitlist on GUI
            }
            else if (reservation) //if reservation
            {
                //get time of reservation and contact phone number
                hour = hourTextBox.Text;
                min = minTextBox.Text;
                contactNum = contactTextBox.Text; 

                //check if time is in proper form
                if (checkTime(hour, min, reservation, takeout)) {                    
                                        
                    //check if the phone number is in proper form
                    if (checkContact(contactNum))
                    {
                        //add party to reservation list
                        wait.addReservation(guestNumTextBox.Text, nameTextBox.Text, requestsTextBox.Text, contactNum, Convert.ToInt32(hour), Convert.ToInt32(min));
                        reservationsListBox.Items.Add(nameTextBox.Text + " at " + hour + ":" + min); //add name to reservation list
                    }
                    else //invalid phone number form
                    {
                         MessageBox.Show("The contact number must be 7 digits with no special characters. " +
                            "This reservation was not made, try again.");
                    }
                }
                else //invalid inputs
                {
                    MessageBox.Show("You must fill in a valid reservation time " +
                        "between 11:00 and 21:00 and more than an hour prior to dining! This reservation was not made, try again.");
                }                

                //reset time and contact input fields
                resetTimeField();
                resetContactField();
            }
            else if (takeout) //if take out 
            {
                hour = hourTextBox.Text;            //order pick up hour
                min = minTextBox.Text;              //order pick up minute
                contactNum = contactTextBox.Text;   //contact phone number for party   
                             
                if (checkTime(hour, min, reservation, takeout))  //check if pick up time is valid
                {
                    if (checkContact(contactNum)) //check phone number is in valid form
                    {
                        takeOutListBox.Items.Add(nameTextBox.Text); //add just the name into the take out ListView **TODO: Might want to change this to add parties instead
                        wait.addTakeOut(nameTextBox.Text, contactNum, Convert.ToInt32(hour), Convert.ToInt32(min)); //add party to take out list
                    }
                    else
                    {
                        MessageBox.Show("The contact number must be 7 digits with no special characters. " +
                            "This order was not placed, try again.");
                    }
                }
                else
                {
                    MessageBox.Show("That isn't a vaild time to pick up the order. The order was not placed. Try again.");
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

        /*check for appropriate time*/
        private bool checkTime(string hour, string min, bool reservation, bool takeout)
        {
            int check;                  //counter to check if value is an integer
            bool timeInBounds = false;  //time is not in restaurant operating hours unless proved otherwise
            int intHour = 0;            //hold int value of hour
            int intMin = 0;             //hold int value of min

            //check if there is a time 
            if (hour != "" && min != "" && int.TryParse(hour, out check) && int.TryParse(min, out check))
            {
                intHour = Convert.ToInt32(hour);            //hour of reservation
                intMin = Convert.ToInt32(min);              //minute of reservation

                //check if reservation is at an appropriate time 
                if (reservation && intHour - DateTime.Now.Hour > 0 && intHour < 21 && intHour > 10 && intMin > -1 && intMin < 61)
                {
                    timeInBounds = true;
                }

                //check if takeout
                if (takeout && intHour - DateTime.Now.Hour > -1 && intHour < 21 && intHour > 10 && intMin > -1 && intMin < 61)
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

        /*
         * infoFromWaitStaff_updateTakeOutListBox()
         * 
         * reads through each line in recWait.txt in order to find names (not a number)
         * once we find a currently existing legal name, color it green
         */
        private void infoFromWaitStaff_updateTakeOutListView()
        {
            //color every name red to start off
            foreach(ListViewItem item in takeOutListBox.Items)
            {
                item.BackColor = Color.Red;
            }

            //read through the file given to us by waitstaff
            string line = null;
            using (StreamReader reader = new StreamReader(@"C:\ReceptionFiles\recWait.txt"))
            {
                using (StreamWriter writer = new StreamWriter(@"C:\ReceptionFiles\recWait.txt"))
                {
                    // While not eof
                    while ((line = reader.ReadLine()) != null)
                    {
                        //if the line is not a number corresponding to a table, then it must be a name
                        if (!(line.Contains("1") ||
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
                               line.Contains("15") ||
                               line.Contains("16")))
                        {
                            line.Trim(); //removes excess whitespace so that we only have the name
                            foreach (ListViewItem item in takeOutListBox.Items)  //look through every item
                            {
                                if (item.ToString().Equals(line))   //if the item == line (the name we are looking for)
                                {
                                    //set Item.BackColor = Green
                                    item.BackColor = Color.Green;
                                    continue;   //continue here so that the already handled names are erased
                                }
                            }
                        }
                        writer.WriteLine(line); //write every line that contains a number back into the file,
                                                //thereby erasing already handled names
                    }
                }
            }
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

        //called when reservation list is selected
        //calls an IO function so might cause slowdown/hang **untested TODO**
        //Might want to use the inner function of this when the Take Out Radio button is selected
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            infoFromWaitStaff_updateTakeOutListView();
        }
    }
}
