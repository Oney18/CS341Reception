using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Dropbox.Api;

namespace ReservationGUI
{
    public partial class ReservationsForm : Form
    {
        private Waitlist wait = new Waitlist(16);                     //lists for current and past reservations, walk ins
        private SeatingForm seat = new SeatingForm();                 //creates seating form
        private LinkedList<Party> walkIns = new LinkedList<Party>();  //used to access the walkin list from wait
        private ArrayList reservations = new ArrayList();

        //determine type of guest to check input fields
        private int CHECK_WALKIN = 0;
        private int CHECK_RESERVATION = 1;
        private int CHECK_TAKEOUT = 2;

        private DropboxClient dropbox = new DropboxClient("y6msKo4rz3AAAAAAAAAACGNSf5KM4CZh-mw4McAEU-3dStDkeEeTHWvELs2br12K"); //dropbox client

        private Thread waitNumCheck;  //runs the task of looking for waitstaff's reports for numbers
        private Thread waitNameCheck; //runs the task of looking for waitstaff's reports for togo names

        public ReservationsForm()
        {
            InitializeComponent();

            //start the thread to check for 
            waitNumCheck = new Thread(waitCheckNumThread);
            waitNumCheck.Start();

            waitNameCheck = new Thread(waitCheckNameThread);
            waitNameCheck.Start();
        }

        private void ReservationsForm_Load(object sender, EventArgs e)
        {
            
        }

        /**
         * This thread will house the task to check the waitstaff input
         **/
        private void waitCheckNumThread()
        {
            while (true)
            {
                try
                {
                    var task = Task.Run(waitstaffNumCheck);
                    task.Wait();
                    task.Dispose();
                }
                catch (AggregateException)
                {

                    //who cares, try again 
                }
                Thread.Sleep(10000); //sleep for 10 seconds
            }

        }

        /**
         * Tgus tgread will house the task to check the waitstaff input for togo names
         **/
         private void waitCheckNameThread()
        {
            try
            {
                var task = Task.Run(waitstaffNameCheck);
                task.Wait();
                task.Dispose();
            }
            catch (AggregateException)
            {

                //who cares, try again 
            }
            Thread.Sleep(10000); //sleep for 10 seconds
        }


        /**
         *  Downloads the report from waitstaff, if DNE then throws exception on the task
         **/
        public async Task waitstaffNumCheck()
        {
            using (var response = await dropbox.Files.DownloadAsync("/CS 341/Reception/waitRecNumber.txt"))
            {
                wait.resetTable(Convert.ToInt32(await response.GetContentAsStringAsync()));
            }

            await dropbox.Files.DeleteAsync("/CS 341/Reception/waitRecNumber.txt");
        }


        /** 
         *  Downloads report from waitstaff, if DNE throws exception on the task
         **/
         public async Task waitstaffNameCheck()
        {
            using (var response = await dropbox.Files.DownloadAsync("/CS 341/Reception/waitRecName.txt"))
            {

                //DO THE GET TAKEOUT READY STUFF
                wait.removeTakeOut(await response.GetContentAsStringAsync());
            }

            await dropbox.Files.DeleteAsync("/CS 341/Reception/waitRecName.txt");
        }


        /*add party to appropriate list for reservations, walkins, and take outs*/
        private void addPartyButton_Click(object sender, EventArgs e)
        {
            string hour = hourTextBox.Text;              //time of reservation
            string min = minTextBox.Text;                //time of reservation
            string contactNum = contactTextBox.Text;     //contact phone number for party  
            bool fullReset = true;      //after execution, reset all input fields        

            //update party lists by guest type
            if(walkInRadioButton.Checked && seatResCheckBox.Checked) //if reservation party is checking in
            {
                wait.checkIn(reservationsListBox.GetItemText(reservationsListBox.SelectedItem)); //check in reservation guest

                //reset reservation check in check box option
                seatResCheckBox.Checked = false;
                seatResCheckBox.Visible = false;

                resetFromSelected(); //reset form so new party can be selected or entered in
            }
            else if (walkInRadioButton.Checked) //if walk in
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
                    wait.addTakeOut(nameTextBox.Text, contactNum, Convert.ToInt32(hour), Convert.ToInt32(min)); //add party to take out list    
                    takeOutListBox.Items.Add(nameTextBox.Text); //add just the name into the take out ListView **TODO: Might want to change this to add parties instead                   
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
                waitEstimateLabel.Text = "Wait Time Estimate: ";
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
        //private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    infoFromWaitStaff_updateTakeOutListView();
        //}

        private void partyListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool fullReset = true; //indicates full form reset

            //get selected name in party wait list
            string selected = partyListBox.GetItemText(partyListBox.SelectedItem);

            walkIns = wait.getWalkIns(); //get walk in party list

            newPartyButton.Visible = true; //if user wants to add a new new party

            resetReservationForm(fullReset); //reset form

            foreach (Party p in walkIns)
            {
                if(p.getName().Equals(selected))
                {                                           

                    readOnlyFields(); //make input fields ready only and do not add to list

                    showPartyInfo(p, selected, CHECK_WALKIN); //show party info
                }
            }

        }

        private void showPartyInfo(Party p, string name, int guestType)
        {
            //fill in party info
            nameTextBox.Text = name;
            guestNumTextBox.Text = p.getPartySize() + "";
            pagerNumTextBox.Text = p.getPagerNum() + "";            
            requestsTextBox.Text = p.getSpecialReq();

            if (guestType == CHECK_WALKIN)
            {
                waitEstimateLabel.Text = "Party Arrived At: ";
                waitEstimateTextBox.Text = p.getArrivalTime() + "";
            }
            else
            {
                waitEstimateLabel.Visible = false;   //hide wait label
                waitEstimateTextBox.Visible = false; //hide wait time
            }
        }

        private void reservationsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get selected name in resevation waitlist
            string selected = reservationsListBox.GetItemText(reservationsListBox.SelectedItem);

            selected = selected.Remove(selected.IndexOf(" ")); //crops string so only has name

            seatResCheckBox.Visible = true; //allow user to select the reservation party 

            newPartyButton.Visible = true; //if user wants to add a new new party

            reservations = wait.getReservations(); //get parties that made reservations

            foreach (Party p in reservations) //check the parties in the reservation list
            {
                if (p.getName().Equals(selected)) //find selected party to get correct information
                {

                    readOnlyFields(); //make input fields read only and do not readd to list
                    seatResCheckBox.Visible = true;
                    showPartyInfo(p, selected, CHECK_RESERVATION); //show party info
                    showTimeFields(); //show time input fields
                    showContact(); //show contact fields
                    contactTextBox.ReadOnly = true;
                    contactTextBox.Text = p.getPhoneNum();
                    hourTextBox.ReadOnly = true;
                    hourTextBox.ReadOnly = true;
                    hourTextBox.Text = p.getResTime().Hour + "";
                    minTextBox.Text = p.getResTime().Minute + "";
                }
            }
        }

        private void readOnlyFields()
        {
            //make input fields readonly
            nameTextBox.ReadOnly = true;
            guestNumTextBox.ReadOnly = true;
            pagerNumTextBox.ReadOnly = true;
            requestsTextBox.ReadOnly = true;

            addPartyButton.Enabled = false; //do not allow party to be added if already added 
        }

        private void newPartyButton_Click(object sender, EventArgs e)
        {
            resetFromSelected();
        }

        /*resets form after having selected a name from the waitlist or reservation listboxes*/
        private void resetFromSelected()
        {
            resetReservationForm(true);    //reset reservation form to add new party
            addPartyButton.Enabled = true; //allow new party to be added

            //make input fields editable
            nameTextBox.ReadOnly = false;
            guestNumTextBox.ReadOnly = false;
            pagerNumTextBox.ReadOnly = false;
            requestsTextBox.ReadOnly = false;
            contactTextBox.ReadOnly = false;
            hourTextBox.ReadOnly = false;
            hourTextBox.ReadOnly = false;

            newPartyButton.Visible = false; //hide new party button
            waitEstimateLabel.Visible = true; //show wait time
            waitEstimateTextBox.Visible = true; //show wait time
        }

        private void seatResCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            pagerNumTextBox.ReadOnly = false; //allow pager number to be entered 
            addPartyButton.Enabled = true; //allow party to be added
        }
    }
}
