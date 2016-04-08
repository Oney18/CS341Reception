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

        //determine type of guest to check input fields
        private int CHECK_WALKIN = 0;
        private int CHECK_RESERVATION = 1;
        private int CHECK_TAKEOUT = 2;

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
            string hour = hourTextBox.Text;              //time of reservation
            string min = minTextBox.Text;                //time of reservation
            string contactNum = contactTextBox.Text;     //contact phone number for party  
            bool fullReset = true;      //after execution, reset all input fields        

            //update party type
            if (walkInRadioButton.Checked) //if walk in
            {
                if (checkInput(CHECK_WALKIN))
                {
                    //add walk in party to waitlist
                    wait.addWalkIn(guestNumTextBox.Text, nameTextBox.Text, requestsTextBox.Text, pagerNumTextBox.Text);
                    partyListBox.Items.Add(nameTextBox.Text); //add name to waitlist on GUI
                }
            }
            else if (reservationRadioButton.Checked) //if reservation
            {
                if (checkInput(CHECK_RESERVATION))
                {                  
                    //add party to reservation list
                    wait.addReservation(guestNumTextBox.Text, nameTextBox.Text, requestsTextBox.Text, contactNum, Convert.ToInt32(hour), Convert.ToInt32(min));
                    reservationsListBox.Items.Add(nameTextBox.Text + " at " + hour + ":" + min); //add name to reservation list                       
                }
            }
            else if (takeOutRadioButton.Checked) //if take out 
            {
                if (checkInput(CHECK_TAKEOUT))
                {
                    takeOutListBox.Items.Add(nameTextBox.Text); //add just the name into the take out ListView **TODO: Might want to change this to add parties instead
                    wait.addTakeOut(nameTextBox.Text, contactNum, Convert.ToInt32(hour), Convert.ToInt32(min)); //add party to take out list                       
                }           
            }
            resetReservationForm(fullReset); //reset input fields             
        }

        /*checks input fields relevant to the type of guest*/      
        private bool checkInput(int guestType)
        {
            bool inputValid = false;        //input is false unless proven otherwise

            if(guestType == CHECK_WALKIN)   //if walk in guest
            {
                if (checkName()) //check valid party name
                {
                    if (checkGuestNum()) //check valid guest number
                    {
                        inputValid = true; //input proven valid
                    }
                }
            }
            else if (guestType == CHECK_RESERVATION) //if reservation guest
            {
                if (checkName()) //check valid party name
                {
                    if (checkGuestNum()) //check valid guest number
                    {
                        //check if time is in proper form
                        if (checkTime(hourTextBox.Text, minTextBox.Text, CHECK_RESERVATION))
                        {
                            //check if the phone number is in proper form
                            if (checkContact(contactTextBox.Text))
                            {
                                inputValid = true; //reservation input has been proven valid
                            }
                        }
                        else //invalid reservation time
                        {
                            MessageBox.Show("You must fill in a valid reservation time " +
                                "between 11:00 and 21:00 and more than an hour prior to dining! This reservation was not made, try again.");
                        }
                    }
                }
            }
            else if (guestType == CHECK_TAKEOUT) //if take out order guest
            {
                if (checkName()) //check valid order name
                {
                    if (checkTime(hourTextBox.Text, minTextBox.Text, CHECK_TAKEOUT))  //check if pick up time is valid
                    {
                        if (checkContact(contactTextBox.Text)) //check phone number is in valid form
                        {
                            inputValid = true; //take out order information is valid
                        }
                    }
                    else //order pick up time is not valid
                    {
                        MessageBox.Show("That isn't a vaild time to pick up the order. The order was not placed. Try again.");
                    }
                }                
            }

            return inputValid; //true if input field for guest type is valid
        }

        /*checks if there is input for a name*/
        private bool checkName()
        {
            bool validInput = false;            //true if there is a name
            string name = nameTextBox.Text;     //gets name from GUI

            name = name.Replace(" ", "");       //get rid of spaces

            if(nameTextBox.Text != "") {
                validInput = true; //true if there is some sort of name
            }
            else //there is no name
            {
                MessageBox.Show("You need to enter a name.");
            }

            return validInput; //true if there is a name
        }

        /*check if contact phone number is 7 digits*/
        private bool checkContact(string contactNum)
        {
            int check;              //counter to check if value is an integer
            bool validForm = false; //valid form is false unless proved correct

            //set validForm to true if phone number is a 7 digit number
            if(contactNum.Length == 7 && int.TryParse(contactNum, out check)) {
                validForm = true;
            }
            else //phone number is not valid
            {
                MessageBox.Show("The contact number must be 7 digits with no special characters. " +
                           "Try again.");
            }

            return validForm; //true if phone number is 7 digits        
        }

        /*check for appropriate time*/
        private bool checkTime(string hour, string min, int guestType)
        {
            int check;                  //counter to check if value is an integer
            bool timeInBounds = false;  //time is not in restaurant operating hours unless proved otherwise
            int intHour = 0;            //hold int value of hour
            int intMin = 0;             //hold int value of min

            //check if a time was given
            if (hour != "" && min != "" && int.TryParse(hour, out check) && int.TryParse(min, out check))
            {
                intHour = Convert.ToInt32(hour);            //hour of reservation
                intMin = Convert.ToInt32(min);              //minute of reservation

                //check if reservation is at an appropriate time 
                if (guestType == CHECK_RESERVATION)
                {
                    if (intHour - DateTime.Now.Hour == 1 && intHour < 21 && intHour > 10 && intMin - DateTime.Now.Minute > -1 && intMin < 61) {
                        timeInBounds = true;
                    }
                    else if(intHour - DateTime.Now.Hour > 1 && intHour < 21 && intHour > 10 && intMin > -1 && intMin < 61)
                    {
                        timeInBounds = true;
                    }
                }

                //check if takeout
                if (guestType == CHECK_TAKEOUT)
                {
                    if (intHour - DateTime.Now.Hour == 0 && intHour < 21 && intHour > 10 && intMin >= DateTime.Now.Minute && intMin < 61)
                    {
                        timeInBounds = true;
                    }
                    else if(intHour - DateTime.Now.Hour > 0 && intHour < 21 && intHour > 10 && intMin > -1 && intMin < 61)
                    {
                        timeInBounds = true;
                    }
                }
            }

            return timeInBounds; //true if time is during restaurant hours of operation
        }

        /*hides and clears the contact and time input fields, clears other input fields*/
        private void resetReservationForm(bool fullReset)
        {
            contactTextBox.Text = "";               //clear contact phone number input field
            contactLabel.Visible = false;           //hide contact label
            contactTextBox.Visible = false;         //hide contact phone number input field
            hourTextBox.Text = "";                  //clear hour input field
            minTextBox.Text = "";                   //clear minute input field
            timeLabel.Visible = false;              //hide time label
            timeDescriptionLabel.Visible = false;   //hide time description label
            hourTextBox.Visible = false;            //hide hour input field
            minTextBox.Visible = false;             //hide minute input field
            
            if (fullReset)
            {
                nameTextBox.Text = "";                  //clear input fields
                guestNumTextBox.Text = "";
                pagerNumTextBox.Text = "";
                waitEstimateTextBox.Text = "";
                requestsTextBox.Text = "";
                walkInRadioButton.Checked = true;       //reset radio button selection to walk in
            }
        }

        /*checks if the number of guests is valid*/
        private bool checkGuestNum()
        {
            string guestNum = guestNumTextBox.Text; //get number of guests in party
            int check;                              //int to check if string is an int
            bool inputValid = false;                //true if guest number is valid  
            int num = 0;                            //hold guest number in integer form

            guestNum = guestNum.Replace(" ", ""); //take out spaces

            //check for integer
            if (int.TryParse(guestNum, out check))
            {
                num = Convert.ToInt32(guestNum); //convert guestnum to an integer
                if ( num < 64 && num > 0)
                {
                    inputValid = true; //valid number of guests
                }
                else //not a valid number of guests, too many people or negative people or no people
                {
                    MessageBox.Show("You need to enter a valid number of guests.");
                }
            }
            else //not a valid number of guests, could be letters
            {
                MessageBox.Show("You need to put the number of guests.");
            }

            return inputValid; //true if valid number of guests
        }

        /*estimates wait time based on tables available and party size*/
        private void guestNumTextBox_TextChanged(object sender, EventArgs e)
        {
            string guestNum = guestNumTextBox.Text; //get number of guests in party
            int check;                              //int to check if string is an int         

            guestNum = guestNum.Replace(" ", ""); //take out spaces

            //check for integer
            if (int.TryParse(guestNum, out check))
            {
                //if all tables are full show wait time
                //No wait time for party of 4 or less if all tables are empty
                waitEstimateTextBox.Text = wait.getWaitTime(Convert.ToInt32(guestNum));
            }
        }

        /*makes contact and time input fields visible when reservation radio button is selected*/
        private void reservationRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //show input fields to get time and contact info for reservation
            timeLabel.Text = "Reservation Time:";
            showTimeFields();
            showContact();
        }

        /*makes contact input fields visible when takeout radio button is selected*/
        private void takeOutRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            timeLabel.Text = "Pick Up Time:";    //change time label
            showTimeFields();                    //show time fields
            showContact();                       //show contact input fields to get input
        }

        /*show the time fields so can get input*/
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
            bool fullReset = false;
            resetReservationForm(fullReset);
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

        private void partyListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get selected name in party wait list
            string selected = partyListBox.GetItemText(partyListBox.SelectedItem);

        }
    }
}
