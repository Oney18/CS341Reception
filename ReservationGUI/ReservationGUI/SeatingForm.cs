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
    public partial class SeatingForm : Form
    {
        private Party currentParty;  //Keeps track of current party 
        private Waitlist list = new Waitlist(16);

        private Table table1 = new Table(1);
        private Table table2 = new Table(2);
        private Table table3 = new Table(3);
        private Table table4 = new Table(4);
        private Table table5 = new Table(5);
        private Table table6 = new Table(6);
        private Table table7 = new Table(7);
        private Table table8 = new Table(8);
        private Table table9 = new Table(9);
        private Table table10 = new Table(10);
        private Table table11 = new Table(11);
        private Table table12 = new Table(12);
        private Table table13 = new Table(13);
        private Table table14 = new Table(14);
        private Table table15 = new Table(15);
        private Table table16 = new Table(16);

        private bool selcted1Table;  //Bool that helps with seating a big party
        private bool isBigParty;    //Bool that determines if the party is big
        private bool edit;          //True when user clicks edit button
        private bool seat;          //True when user clicks seat button
        private bool tableSelectedForEdit;    //True when user selects a table for edit


        public SeatingForm(ReservationsForm form)
        {
            InitializeComponent();
            list.addWalkIn("4", "Ally", "None", "4443332222");   //Mock Data for now
            list.addWalkIn("5", "Bob", "None", "4443332222");
            list.addWalkIn("2", "Robin", "None", "4443332222");
            list.addWalkIn("7", "Tyler", "None", "4443332222");

        }

        private void SeatingForm_Load(object sender, EventArgs e)
        {

        }

        private void seatParty_Click(object sender, EventArgs e)
        {
            seat = true;
            currentParty = list.getNextParty();   //Gets the top table to be seated

            //Checks for null
            if (currentParty == null)
            {
                System.Windows.Forms.MessageBox.Show("There is no party to seat");
            }

            //Determines if the party needs 2 tables
            else if (currentParty.isBigParty())
            {
                isBigParty = true;
                System.Windows.Forms.MessageBox.Show("Select 2 tables");
            }
             
            //Determines if the party is already seated
            else if (currentParty.getIsSeated() == true)
            {
                System.Windows.Forms.MessageBox.Show("Already seated");
            }

            //Prompts the user to select a table
            else
            {
                System.Windows.Forms.MessageBox.Show("Select a table");
            }
        }

        private void editTable_Click(object sender, EventArgs e)
        {
            edit = true;

            //Prompts the user to select the table they want to edit/change
            System.Windows.Forms.MessageBox.Show("Select the party you want to move");
        }

        private void table1GroupBox_click(object sender, EventArgs e)
        {
            //If the user is editing...
            if (edit == true)
            {
                //If the table that the user wants to change is already selected, the user is then
                //prompted to click the table they want to move the party to. 
                if (tableSelectedForEdit == true)
                {
                    if (table1.getInUse())
                    {
                        System.Windows.Forms.MessageBox.Show("Already in use");
                    }
                    else
                    {
                        table1.seat(currentParty); //seats the party

                        //Updates the textboxes
                        nameTextBox1.Text = currentParty.getName();
                        sizeTextBox1.Text = currentParty.getPartySize().ToString();
                        requestsTextBox1.Text = currentParty.getSpecialReq();

                        currentParty.setIsSeated(true); //Sets the party to be seated
                        currentParty = null; //Clears the field
                        edit = false; //reset bool
                        tableSelectedForEdit = false; //reset bool
                    }
                }

                //The user is to click the table they want to change
                else
                {
                    //Keeps track of the party that was seated at that table
                    currentParty = table1.getParty(); 

                    //Clears the text fields
                    nameTextBox1.Text = null;
                    sizeTextBox1.Text = null;
                    requestsTextBox1.Text = null;

                    table1.leave(); //removes the party from the table
                    tableSelectedForEdit = true; //bool changed to true so user can now select new table

                    //Prompts user to select a new table
                    System.Windows.Forms.MessageBox.Show("Select a table to move this party to");

                }
            }
            else if (seat == true)
            {
                //Checks if the table is in use
                if (table1.getInUse())
                {
                    System.Windows.Forms.MessageBox.Show("Already in use");
                }

                //Checks if the part is already seated
                else if (currentParty.getIsSeated() == true)
                {
                    System.Windows.Forms.MessageBox.Show("Already seated");
                }

                //If the party is a big party, it prompts the user to select another table
                else if (isBigParty == true && selcted1Table == false)
                {
                    table1.seat(currentParty);
                    nameTextBox1.Text = currentParty.getName();
                    sizeTextBox1.Text = currentParty.getPartySize().ToString();
                    requestsTextBox1.Text = currentParty.getSpecialReq();
                    selcted1Table = true;
                    isBigParty = false;  //reset bool
                    System.Windows.Forms.MessageBox.Show("Please choose another adjoining table");
                }

                //Party is seated and text fields are updated accordingly
                else
                {
                    table1.seat(currentParty);
                    nameTextBox1.Text = currentParty.getName();
                    sizeTextBox1.Text = currentParty.getPartySize().ToString();
                    requestsTextBox1.Text = currentParty.getSpecialReq();
                    currentParty.setIsSeated(true);
                    selcted1Table = false;
                    currentParty = null;
                    seat = false;
                }
            }
        }
        private void table2GroupBox_click(object sender, EventArgs e)
        {
            if (edit == true)
            {
                if (tableSelectedForEdit == true)
                {
                    if (table2.getInUse())
                    {
                        System.Windows.Forms.MessageBox.Show("Already in use");
                    }
                    else
                    {
                        table2.seat(currentParty);
                        nameTextBox2.Text = currentParty.getName();
                        sizeTextBox2.Text = currentParty.getPartySize().ToString();
                        requestsTextBox2.Text = currentParty.getSpecialReq();
                        currentParty.setIsSeated(true);
                        currentParty = null;
                        edit = false;
                        tableSelectedForEdit = false;
                    }
                }
                else
                {
                    currentParty = table2.getParty();
                    nameTextBox2.Text = null;
                    sizeTextBox2.Text = null;
                    requestsTextBox2.Text = null;
                    table2.leave();
                    tableSelectedForEdit = true;
                    System.Windows.Forms.MessageBox.Show("Select a table to move this party to");

                }
            }
            if (seat == true)
            {
                if (table2.getInUse())
                {
                    System.Windows.Forms.MessageBox.Show("Already in use");
                }
                else if (currentParty.getIsSeated() == true)
                {
                    System.Windows.Forms.MessageBox.Show("Already seated");
                }
                else if (isBigParty == true && selcted1Table == false)
                {
                    table2.seat(currentParty);
                    nameTextBox2.Text = currentParty.getName();
                    sizeTextBox2.Text = currentParty.getPartySize().ToString();
                    requestsTextBox2.Text = currentParty.getSpecialReq();
                    selcted1Table = true;

                    System.Windows.Forms.MessageBox.Show("Please choose another adjoining table");
                }
                else
                {
                    table2.seat(currentParty);
                    nameTextBox2.Text = currentParty.getName();
                    sizeTextBox2.Text = currentParty.getPartySize().ToString();
                    requestsTextBox2.Text = currentParty.getSpecialReq();
                    currentParty.setIsSeated(true);
                    currentParty = null;
                    selcted1Table = false;
                    seat = false;
                }
            }
        }
        private void table3GroupBox_click(object sender, EventArgs e)
        {
            if (edit == true)
            {
                if (tableSelectedForEdit == true)
                {
                    if (table3.getInUse())
                    {
                        System.Windows.Forms.MessageBox.Show("Already in use");
                    }
                    else
                    {
                        table3.seat(currentParty);
                        nameTextBox3.Text = currentParty.getName();
                        sizeTextBox3.Text = currentParty.getPartySize().ToString();
                        requestsTextBox3.Text = currentParty.getSpecialReq();
                        currentParty.setIsSeated(true);
                        currentParty = null;
                        edit = false;
                        tableSelectedForEdit = false;
                    }
                }
                else
                {
                    currentParty = table3.getParty();
                    nameTextBox3.Text = null;
                    sizeTextBox3.Text = null;
                    requestsTextBox3.Text = null;
                    table3.leave();
                    tableSelectedForEdit = true;
                    System.Windows.Forms.MessageBox.Show("Select a table to move this party to");

                }
            }
            if (seat == true)
            {
                if (table3.getInUse())
                {
                    System.Windows.Forms.MessageBox.Show("Already in use");
                }
                else if (currentParty.getIsSeated() == true)
                {
                    System.Windows.Forms.MessageBox.Show("Already seated");
                }
                else if (isBigParty == true && selcted1Table == false)
                {
                    table3.seat(currentParty);
                    nameTextBox3.Text = currentParty.getName();
                    sizeTextBox3.Text = currentParty.getPartySize().ToString();
                    requestsTextBox3.Text = currentParty.getSpecialReq();
                    selcted1Table = true;
                    isBigParty = false;

                    System.Windows.Forms.MessageBox.Show("Please choose another adjoining table");
                }
                else
                {
                    table3.seat(currentParty);
                    nameTextBox3.Text = currentParty.getName();
                    sizeTextBox3.Text = currentParty.getPartySize().ToString();
                    requestsTextBox3.Text = currentParty.getSpecialReq();
                    currentParty.setIsSeated(true);
                    selcted1Table = false;
                    currentParty = null;
                    seat = false;
                }
            }
        }
        private void table4GroupBox_click(object sender, EventArgs e)
        {
            if (edit == true)
            {
                if (tableSelectedForEdit == true)
                {
                    if (table4.getInUse())
                    {
                        System.Windows.Forms.MessageBox.Show("Already in use");
                    }
                    else
                    {
                        table4.seat(currentParty);
                        nameTextBox4.Text = currentParty.getName();
                        sizeTextBox4.Text = currentParty.getPartySize().ToString();
                        requestsTextBox4.Text = currentParty.getSpecialReq();
                        currentParty.setIsSeated(true);
                        currentParty = null;
                        edit = false;
                        tableSelectedForEdit = false;
                    }
                }
                else
                {
                    currentParty = table4.getParty();
                    nameTextBox4.Text = null;
                    sizeTextBox4.Text = null;
                    requestsTextBox4.Text = null;
                    table4.leave();
                    tableSelectedForEdit = true;
                    System.Windows.Forms.MessageBox.Show("Select a table to move this party to");

                }
            }
            if (seat == true)
            {
                if (table4.getInUse())
                {
                    System.Windows.Forms.MessageBox.Show("Already in use");
                }
                else if (currentParty.getIsSeated() == true)
                {
                    System.Windows.Forms.MessageBox.Show("Already seated");
                }
                else if (isBigParty == true && selcted1Table == false)
                {
                    table4.seat(currentParty);
                    nameTextBox4.Text = currentParty.getName();
                    sizeTextBox4.Text = currentParty.getPartySize().ToString();
                    requestsTextBox4.Text = currentParty.getSpecialReq();
                    selcted1Table = true;
                    isBigParty = false;

                    System.Windows.Forms.MessageBox.Show("Please choose another adjoining table");
                }
                else
                {
                    table4.seat(currentParty);
                    nameTextBox4.Text = currentParty.getName();
                    sizeTextBox4.Text = currentParty.getPartySize().ToString();
                    requestsTextBox4.Text = currentParty.getSpecialReq();
                    selcted1Table = false;
                    currentParty = null;
                    seat = false;

                }
            } 
        }
        private void table5GroupBox_click(object sender, EventArgs e)
        {
            if (edit == true)
            {
                if (tableSelectedForEdit == true)
                {
                    if (table5.getInUse())
                    {
                        System.Windows.Forms.MessageBox.Show("Already in use");
                    }
                    else
                    {
                        table5.seat(currentParty);
                        nameTextBox5.Text = currentParty.getName();
                        sizeTextBox5.Text = currentParty.getPartySize().ToString();
                        requestsTextBox5.Text = currentParty.getSpecialReq();
                        currentParty.setIsSeated(true);
                        currentParty = null;
                        edit = false;
                        tableSelectedForEdit = false;
                    }
                }
                else
                {
                    currentParty = table5.getParty();
                    nameTextBox5.Text = null;
                    sizeTextBox5.Text = null;
                    requestsTextBox5.Text = null;
                    table5.leave();
                    tableSelectedForEdit = true;
                    System.Windows.Forms.MessageBox.Show("Select a table to move this party to");

                }
            }
            if (seat == true)
            {
                if (table5.getInUse())
                {
                    System.Windows.Forms.MessageBox.Show("Already in use");
                }
                else if (currentParty.getIsSeated() == true)
                {
                    System.Windows.Forms.MessageBox.Show("Already seated");
                }
                else if (isBigParty == true && selcted1Table == false)
                {
                    table5.seat(currentParty);
                    nameTextBox5.Text = currentParty.getName();
                    sizeTextBox5.Text = currentParty.getPartySize().ToString();
                    requestsTextBox5.Text = currentParty.getSpecialReq();
                    selcted1Table = true;
                    isBigParty = false;

                    System.Windows.Forms.MessageBox.Show("Please choose another adjoining table");
                }
                else
                {
                    table5.seat(currentParty);
                    nameTextBox5.Text = currentParty.getName();
                    sizeTextBox5.Text = currentParty.getPartySize().ToString();
                    requestsTextBox5.Text = currentParty.getSpecialReq();
                    selcted1Table = false;
                    currentParty = null;
                    seat = false;

                }
            }
        }
        private void table6GroupBox_click(object sender, EventArgs e)
        {
            if (edit == true)
            {
                if (tableSelectedForEdit == true)
                {
                    if (table6.getInUse())
                    {
                        System.Windows.Forms.MessageBox.Show("Already in use");
                    }
                    else
                    {
                        table6.seat(currentParty);
                        nameTextBox6.Text = currentParty.getName();
                        sizeTextBox6.Text = currentParty.getPartySize().ToString();
                        requestsTextBox6.Text = currentParty.getSpecialReq();
                        currentParty.setIsSeated(true);
                        currentParty = null;
                        edit = false;
                        tableSelectedForEdit = false;
                    }
                }
                else
                {
                    currentParty = table6.getParty();
                    nameTextBox6.Text = null;
                    sizeTextBox6.Text = null;
                    requestsTextBox6.Text = null;
                    table6.leave();
                    tableSelectedForEdit = true;
                    System.Windows.Forms.MessageBox.Show("Select a table to move this party to");

                }
            }
            if (seat == true)
            {
                if (table6.getInUse())
                {
                    System.Windows.Forms.MessageBox.Show("Already in use");
                }
                else if (currentParty.getIsSeated() == true)
                {
                    System.Windows.Forms.MessageBox.Show("Already seated");
                }
                else if (isBigParty == true && selcted1Table == false)
                {
                    table6.seat(currentParty);
                    nameTextBox6.Text = currentParty.getName();
                    sizeTextBox6.Text = currentParty.getPartySize().ToString();
                    requestsTextBox6.Text = currentParty.getSpecialReq();
                    selcted1Table = true;
                    isBigParty = false;

                    System.Windows.Forms.MessageBox.Show("Please choose another adjoining table");
                }
                else
                {
                    table6.seat(currentParty);
                    nameTextBox6.Text = currentParty.getName();
                    sizeTextBox6.Text = currentParty.getPartySize().ToString();
                    requestsTextBox6.Text = currentParty.getSpecialReq();
                    selcted1Table = false;
                    currentParty = null;
                    seat = false;

                }
            }
        }
        private void table7GroupBox_click(object sender, EventArgs e)
        {
            if (edit == true)
            {
                if (tableSelectedForEdit == true)
                {
                    if (table7.getInUse())
                    {
                        System.Windows.Forms.MessageBox.Show("Already in use");
                    }
                    else
                    {
                        table7.seat(currentParty);
                        nameTextBox7.Text = currentParty.getName();
                        sizeTextBox7.Text = currentParty.getPartySize().ToString();
                        requestsTextBox7.Text = currentParty.getSpecialReq();
                        currentParty.setIsSeated(true);
                        currentParty = null;
                        edit = false;
                        tableSelectedForEdit = false;
                    }
                }
                else
                {
                    currentParty = table7.getParty();
                    nameTextBox7.Text = null;
                    sizeTextBox7.Text = null;
                    requestsTextBox7.Text = null;
                    table7.leave();
                    tableSelectedForEdit = true;
                    System.Windows.Forms.MessageBox.Show("Select a table to move this party to");

                }
            }
            if (seat == true)
            {
                if (table7.getInUse())
                {
                    System.Windows.Forms.MessageBox.Show("Already in use");
                }
                else if (currentParty.getIsSeated() == true)
                {
                    System.Windows.Forms.MessageBox.Show("Already seated");
                }
                else if (isBigParty == true && selcted1Table == false)
                {
                    table7.seat(currentParty);
                    nameTextBox7.Text = currentParty.getName();
                    sizeTextBox7.Text = currentParty.getPartySize().ToString();
                    requestsTextBox7.Text = currentParty.getSpecialReq();
                    selcted1Table = true;
                    isBigParty = false;

                    System.Windows.Forms.MessageBox.Show("Please choose another adjoining table");
                }
                else
                {
                    table7.seat(currentParty);
                    nameTextBox7.Text = currentParty.getName();
                    sizeTextBox7.Text = currentParty.getPartySize().ToString();
                    requestsTextBox7.Text = currentParty.getSpecialReq();
                    selcted1Table = false;
                    currentParty = null;
                    seat = false;

                }
            }
        }
        private void table8GroupBox_click(object sender, EventArgs e)
        {
            if (edit == true)
            {
                if (tableSelectedForEdit == true)
                {
                    if (table8.getInUse())
                    {
                        System.Windows.Forms.MessageBox.Show("Already in use");
                    }
                    else
                    {
                        table8.seat(currentParty);
                        nameTextBox8.Text = currentParty.getName();
                        sizeTextBox8.Text = currentParty.getPartySize().ToString();
                        requestsTextBox8.Text = currentParty.getSpecialReq();
                        currentParty.setIsSeated(true);
                        currentParty = null;
                        edit = false;
                        tableSelectedForEdit = false;
                    }
                }
                else
                {
                    currentParty = table8.getParty();
                    nameTextBox8.Text = null;
                    sizeTextBox8.Text = null;
                    requestsTextBox8.Text = null;
                    table8.leave();
                    tableSelectedForEdit = true;
                    System.Windows.Forms.MessageBox.Show("Select a table to move this party to");

                }
            }
            if (seat == true)
            {
                if (table8.getInUse())
                {
                    System.Windows.Forms.MessageBox.Show("Already in use");
                }
                else if (currentParty.getIsSeated() == true)
                {
                    System.Windows.Forms.MessageBox.Show("Already seated");
                }
                else if (isBigParty == true && selcted1Table == false)
                {
                    table8.seat(currentParty);
                    nameTextBox8.Text = currentParty.getName();
                    sizeTextBox8.Text = currentParty.getPartySize().ToString();
                    requestsTextBox8.Text = currentParty.getSpecialReq();
                    selcted1Table = true;
                    isBigParty = false;

                    System.Windows.Forms.MessageBox.Show("Please choose another adjoining table");
                }
                else
                {
                    table8.seat(currentParty);
                    nameTextBox8.Text = currentParty.getName();
                    sizeTextBox8.Text = currentParty.getPartySize().ToString();
                    requestsTextBox8.Text = currentParty.getSpecialReq();
                    selcted1Table = false;
                    currentParty = null;
                    seat = false;

                }
            }
        }
        private void table9GroupBox_click(object sender, EventArgs e)
        {
            if (edit == true)
            {
                if (tableSelectedForEdit == true)
                {
                    if (table9.getInUse())
                    {
                        System.Windows.Forms.MessageBox.Show("Already in use");
                    }
                    else
                    {
                        table9.seat(currentParty);
                        nameTextBox9.Text = currentParty.getName();
                        sizeTextBox9.Text = currentParty.getPartySize().ToString();
                        requestsTextBox9.Text = currentParty.getSpecialReq();
                        currentParty.setIsSeated(true);
                        currentParty = null;
                        edit = false;
                        tableSelectedForEdit = false;
                    }
                }
                else
                {
                    currentParty = table9.getParty();
                    nameTextBox9.Text = null;
                    sizeTextBox9.Text = null;
                    requestsTextBox9.Text = null;
                    table9.leave();
                    tableSelectedForEdit = true;
                    System.Windows.Forms.MessageBox.Show("Select a table to move this party to");

                }
            }
            if (seat == true)
            {
                if (table9.getInUse())
                {
                    System.Windows.Forms.MessageBox.Show("Already in use");
                }
                else if (currentParty.getIsSeated() == true)
                {
                    System.Windows.Forms.MessageBox.Show("Already seated");
                }
                else if (isBigParty == true && selcted1Table == false)
                {
                    table9.seat(currentParty);
                    nameTextBox9.Text = currentParty.getName();
                    sizeTextBox9.Text = currentParty.getPartySize().ToString();
                    requestsTextBox9.Text = currentParty.getSpecialReq();
                    selcted1Table = true;
                    isBigParty = false;

                    System.Windows.Forms.MessageBox.Show("Please choose another adjoining table");
                }
                else
                {
                    table9.seat(currentParty);
                    nameTextBox9.Text = currentParty.getName();
                    sizeTextBox9.Text = currentParty.getPartySize().ToString();
                    requestsTextBox9.Text = currentParty.getSpecialReq();
                    selcted1Table = false;
                    currentParty = null;
                    seat = false;

                }
            }
        }
        private void table10GroupBox_click(object sender, EventArgs e)
        {
            if (edit == true)
            {
                if (tableSelectedForEdit == true)
                {
                    if (table10.getInUse())
                    {
                        System.Windows.Forms.MessageBox.Show("Already in use");
                    }
                    else
                    {
                        table1.seat(currentParty);
                        nameTextBox10.Text = currentParty.getName();
                        sizeTextBox10.Text = currentParty.getPartySize().ToString();
                        requestsTextBox10.Text = currentParty.getSpecialReq();
                        currentParty.setIsSeated(true);
                        currentParty = null;
                        edit = false;
                        tableSelectedForEdit = false;
                    }
                }
                else
                {
                    currentParty = table10.getParty();
                    nameTextBox10.Text = null;
                    sizeTextBox10.Text = null;
                    requestsTextBox10.Text = null;
                    table10.leave();
                    tableSelectedForEdit = true;
                    System.Windows.Forms.MessageBox.Show("Select a table to move this party to");

                }
            }
            if (seat == true)
            {
                if (table10.getInUse())
                {
                    System.Windows.Forms.MessageBox.Show("Already in use");
                }
                else if (currentParty.getIsSeated() == true)
                {
                    System.Windows.Forms.MessageBox.Show("Already seated");
                }
                else if (isBigParty == true && selcted1Table == false)
                {
                    table10.seat(currentParty);
                    nameTextBox10.Text = currentParty.getName();
                    sizeTextBox10.Text = currentParty.getPartySize().ToString();
                    requestsTextBox10.Text = currentParty.getSpecialReq();
                    selcted1Table = true;
                    isBigParty = false;

                    System.Windows.Forms.MessageBox.Show("Please choose another adjoining table");
                }
                else
                {
                    table10.seat(currentParty);
                    nameTextBox10.Text = currentParty.getName();
                    sizeTextBox10.Text = currentParty.getPartySize().ToString();
                    requestsTextBox10.Text = currentParty.getSpecialReq();
                    selcted1Table = false;
                    currentParty = null;
                    seat = false;

                }
            }
        }
        private void table11GroupBox_click(object sender, EventArgs e)
        {
            if (edit == true)
            {
                if (tableSelectedForEdit == true)
                {
                    if (table11.getInUse())
                    {
                        System.Windows.Forms.MessageBox.Show("Already in use");
                    }
                    else
                    {
                        table11.seat(currentParty);
                        nameTextBox11.Text = currentParty.getName();
                        sizeTextBox11.Text = currentParty.getPartySize().ToString();
                        requestsTextBox11.Text = currentParty.getSpecialReq();
                        currentParty.setIsSeated(true);
                        currentParty = null;
                        edit = false;
                        tableSelectedForEdit = false;
                    }
                }
                else
                {
                    currentParty = table11.getParty();
                    nameTextBox11.Text = null;
                    sizeTextBox11.Text = null;
                    requestsTextBox11.Text = null;
                    table11.leave();
                    tableSelectedForEdit = true;
                    System.Windows.Forms.MessageBox.Show("Select a table to move this party to");

                }
            }
            if (seat == true)
            {
                if (table11.getInUse())
                {
                    System.Windows.Forms.MessageBox.Show("Already in use");
                }
                else if (currentParty.getIsSeated() == true)
                {
                    System.Windows.Forms.MessageBox.Show("Already seated");
                }
                else if (isBigParty == true && selcted1Table == false)
                {
                    table11.seat(currentParty);
                    nameTextBox11.Text = currentParty.getName();
                    sizeTextBox11.Text = currentParty.getPartySize().ToString();
                    requestsTextBox11.Text = currentParty.getSpecialReq();
                    selcted1Table = true;
                    isBigParty = false;

                    System.Windows.Forms.MessageBox.Show("Please choose another adjoining table");
                }
                else
                {
                    table11.seat(currentParty);
                    nameTextBox11.Text = currentParty.getName();
                    sizeTextBox11.Text = currentParty.getPartySize().ToString();
                    requestsTextBox11.Text = currentParty.getSpecialReq();
                    selcted1Table = false;
                    currentParty = null;
                    seat = false;

                }
            }
        }
        private void table12GroupBox_click(object sender, EventArgs e)
        {
            if (edit == true)
            {
                if (tableSelectedForEdit == true)
                {
                    if (table12.getInUse())
                    {
                        System.Windows.Forms.MessageBox.Show("Already in use");
                    }
                    else
                    {
                        table12.seat(currentParty);
                        nameTextBox12.Text = currentParty.getName();
                        sizeTextBox12.Text = currentParty.getPartySize().ToString();
                        requestsTextBox12.Text = currentParty.getSpecialReq();
                        currentParty.setIsSeated(true);
                        currentParty = null;
                        edit = false;
                        tableSelectedForEdit = false;
                    }
                }
                else
                {
                    currentParty = table12.getParty();
                    nameTextBox12.Text = null;
                    sizeTextBox12.Text = null;
                    requestsTextBox12.Text = null;
                    table12.leave();
                    tableSelectedForEdit = true;
                    System.Windows.Forms.MessageBox.Show("Select a table to move this party to");

                }
            }
            if (seat == true)
            {
                if (table12.getInUse())
                {
                    System.Windows.Forms.MessageBox.Show("Already in use");
                }
                else if (currentParty.getIsSeated() == true)
                {
                    System.Windows.Forms.MessageBox.Show("Already seated");
                }
                else if (isBigParty == true && selcted1Table == false)
                {
                    table12.seat(currentParty);
                    nameTextBox12.Text = currentParty.getName();
                    sizeTextBox12.Text = currentParty.getPartySize().ToString();
                    requestsTextBox12.Text = currentParty.getSpecialReq();
                    selcted1Table = true;
                    isBigParty = false;

                    System.Windows.Forms.MessageBox.Show("Please choose another adjoining table");
                }
                else
                {
                    table12.seat(currentParty);
                    nameTextBox12.Text = currentParty.getName();
                    sizeTextBox12.Text = currentParty.getPartySize().ToString();
                    requestsTextBox12.Text = currentParty.getSpecialReq();
                    selcted1Table = false;
                    currentParty = null;
                    seat = false;

                }
            }
        }
        private void table13GroupBox_click(object sender, EventArgs e)
        {
            if (edit == true)
            {
                if (tableSelectedForEdit == true)
                {
                    if (table13.getInUse())
                    {
                        System.Windows.Forms.MessageBox.Show("Already in use");
                    }
                    else
                    {
                        table13.seat(currentParty);
                        nameTextBox13.Text = currentParty.getName();
                        sizeTextBox13.Text = currentParty.getPartySize().ToString();
                        requestsTextBox13.Text = currentParty.getSpecialReq();
                        currentParty.setIsSeated(true);
                        currentParty = null;
                        edit = false;
                        tableSelectedForEdit = false;
                    }
                }
                else
                {
                    currentParty = table13.getParty();
                    nameTextBox13.Text = null;
                    sizeTextBox13.Text = null;
                    requestsTextBox13.Text = null;
                    table13.leave();
                    tableSelectedForEdit = true;
                    System.Windows.Forms.MessageBox.Show("Select a table to move this party to");

                }
            }
            if (seat == true)
            {
                if (table13.getInUse())
                {
                    System.Windows.Forms.MessageBox.Show("Already in use");
                }
                else if (currentParty.getIsSeated() == true)
                {
                    System.Windows.Forms.MessageBox.Show("Already seated");
                }
                else if (isBigParty == true && selcted1Table == false)
                {
                    table13.seat(currentParty);
                    nameTextBox13.Text = currentParty.getName();
                    sizeTextBox13.Text = currentParty.getPartySize().ToString();
                    requestsTextBox13.Text = currentParty.getSpecialReq();
                    selcted1Table = true;
                    isBigParty = false;

                    System.Windows.Forms.MessageBox.Show("Please choose another adjoining table");
                }
                else
                {
                    table13.seat(currentParty);
                    nameTextBox13.Text = currentParty.getName();
                    sizeTextBox13.Text = currentParty.getPartySize().ToString();
                    requestsTextBox13.Text = currentParty.getSpecialReq();
                    selcted1Table = false;
                    currentParty = null;
                    seat = false;

                }
            }
        }
        private void table14GroupBox_click(object sender, EventArgs e)
        {
            if (edit == true)
            {
                if (tableSelectedForEdit == true)
                {
                    if (table14.getInUse())
                    {
                        System.Windows.Forms.MessageBox.Show("Already in use");
                    }
                    else
                    {
                        table14.seat(currentParty);
                        nameTextBox14.Text = currentParty.getName();
                        sizeTextBox14.Text = currentParty.getPartySize().ToString();
                        requestsTextBox14.Text = currentParty.getSpecialReq();
                        currentParty.setIsSeated(true);
                        currentParty = null;
                        edit = false;
                        tableSelectedForEdit = false;
                    }
                }
                else
                {
                    currentParty = table14.getParty();
                    nameTextBox14.Text = null;
                    sizeTextBox14.Text = null;
                    requestsTextBox14.Text = null;
                    table14.leave();
                    tableSelectedForEdit = true;
                    System.Windows.Forms.MessageBox.Show("Select a table to move this party to");

                }
            }
            if (seat == true)
            {
                if (table14.getInUse())
                {
                    System.Windows.Forms.MessageBox.Show("Already in use");
                }
                else if (currentParty.getIsSeated() == true)
                {
                    System.Windows.Forms.MessageBox.Show("Already seated");
                }
                else if (isBigParty == true && selcted1Table == false)
                {
                    table14.seat(currentParty);
                    nameTextBox14.Text = currentParty.getName();
                    sizeTextBox14.Text = currentParty.getPartySize().ToString();
                    requestsTextBox14.Text = currentParty.getSpecialReq();
                    selcted1Table = true;
                    isBigParty = false;

                    System.Windows.Forms.MessageBox.Show("Please choose another adjoining table");
                }
                else
                {
                    table14.seat(currentParty);
                    nameTextBox14.Text = currentParty.getName();
                    sizeTextBox14.Text = currentParty.getPartySize().ToString();
                    requestsTextBox14.Text = currentParty.getSpecialReq();
                    selcted1Table = false;
                    currentParty = null;
                    seat = false;

                }
            }
        }
        private void table15GroupBox_click(object sender, EventArgs e)
        {
            if (edit == true)
            {
                if (tableSelectedForEdit == true)
                {
                    if (table15.getInUse())
                    {
                        System.Windows.Forms.MessageBox.Show("Already in use");
                    }
                    else
                    {
                        table15.seat(currentParty);
                        nameTextBox15.Text = currentParty.getName();
                        sizeTextBox15.Text = currentParty.getPartySize().ToString();
                        requestsTextBox15.Text = currentParty.getSpecialReq();
                        currentParty.setIsSeated(true);
                        currentParty = null;
                        edit = false;
                        tableSelectedForEdit = false;
                    }
                }
                else
                {
                    currentParty = table15.getParty();
                    nameTextBox15.Text = null;
                    sizeTextBox15.Text = null;
                    requestsTextBox15.Text = null;
                    table15.leave();
                    tableSelectedForEdit = true;
                    System.Windows.Forms.MessageBox.Show("Select a table to move this party to");

                }
            }
            if (seat == true)
            {
                if (table15.getInUse())
                {
                    System.Windows.Forms.MessageBox.Show("Already in use");
                }
                else if (currentParty.getIsSeated() == true)
                {
                    System.Windows.Forms.MessageBox.Show("Already seated");
                }
                else if (isBigParty == true && selcted1Table == false)
                {
                    table15.seat(currentParty);
                    nameTextBox15.Text = currentParty.getName();
                    sizeTextBox15.Text = currentParty.getPartySize().ToString();
                    requestsTextBox15.Text = currentParty.getSpecialReq();
                    selcted1Table = true;
                    isBigParty = false;

                    System.Windows.Forms.MessageBox.Show("Please choose another adjoining table");
                }
                else
                {
                    table15.seat(currentParty);
                    nameTextBox15.Text = currentParty.getName();
                    sizeTextBox15.Text = currentParty.getPartySize().ToString();
                    requestsTextBox15.Text = currentParty.getSpecialReq();
                    selcted1Table = false;
                    currentParty = null;
                    seat = false;

                }
            }
        }
        private void table16GroupBox_click(object sender, EventArgs e)
        {
            if (edit == true)
            {
                if (tableSelectedForEdit == true)
                {
                    if (table16.getInUse())
                    {
                        System.Windows.Forms.MessageBox.Show("Already in use");
                    }
                    else
                    {
                        table16.seat(currentParty);
                        nameTextBox16.Text = currentParty.getName();
                        sizeTextBox16.Text = currentParty.getPartySize().ToString();
                        requestsTextBox16.Text = currentParty.getSpecialReq();
                        currentParty.setIsSeated(true);
                        currentParty = null;
                        edit = false;
                        tableSelectedForEdit = false;
                    }
                }
                else
                {
                    currentParty = table16.getParty();
                    nameTextBox16.Text = null;
                    sizeTextBox16.Text = null;
                    requestsTextBox16.Text = null;
                    table16.leave();
                    tableSelectedForEdit = true;
                    System.Windows.Forms.MessageBox.Show("Select a table to move this party to");

                }
            }
            if (seat == true)
            {
                if (table16.getInUse())
                {
                    System.Windows.Forms.MessageBox.Show("Already in use");
                }
                else if (currentParty.getIsSeated() == true)
                {
                    System.Windows.Forms.MessageBox.Show("Already seated");
                }
                else if (isBigParty == true && selcted1Table == false)
                {
                    table16.seat(currentParty);
                    nameTextBox16.Text = currentParty.getName();
                    sizeTextBox16.Text = currentParty.getPartySize().ToString();
                    requestsTextBox16.Text = currentParty.getSpecialReq();
                    selcted1Table = true;
                    isBigParty = false;

                    System.Windows.Forms.MessageBox.Show("Please choose another adjoining table");
                }
                else
                {
                    table16.seat(currentParty);
                    nameTextBox16.Text = currentParty.getName();
                    sizeTextBox16.Text = currentParty.getPartySize().ToString();
                    requestsTextBox16.Text = currentParty.getSpecialReq();
                    selcted1Table = false;
                    currentParty = null;
                    seat = false;

                }
            }
        }
    }
}
