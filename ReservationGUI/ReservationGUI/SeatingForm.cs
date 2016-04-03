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
        private Party currentParty;
        private Waitlist waitList;
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

        private bool selcted1Table;
        private bool isDoubleParty;

        public SeatingForm(Waitlist wait)
        {
            InitializeComponent();
            waitList = wait;
        }

        private void SeatingForm_Load(object sender, EventArgs e)
        {

        }

        private void seatParty_Click(object sender, EventArgs e)
        {
            currentParty = waitList.getNextParty();
            //currentParty = new Party("5", "ally", "none", "34", DateTime.Now);  //TEMP
    


            if (Int32.Parse(currentParty.getPartySize()) > 4)
            {
                isDoubleParty = true;
                System.Windows.Forms.MessageBox.Show("Select 2 tables");
            }

            else
            {
                System.Windows.Forms.MessageBox.Show("Select a table");
            }
        }

        private void table1GroupBox_click(object sender, EventArgs e)
        {
            if (table1.getInUse())
            {
                System.Windows.Forms.MessageBox.Show("Already in use");
            }
            else if (isDoubleParty == true && selcted1Table == false){
                table1.seat(currentParty);
                nameTextBox1.Text = currentParty.getName();
                sizeTextBox1.Text = currentParty.getPartySize().ToString();
                requestsTextBox1.Text = currentParty.getSpecialReq();
                selcted1Table = true;

                System.Windows.Forms.MessageBox.Show("Please choose another adjoining table");
            }
             
            else
            {
                table1.seat(currentParty);
                nameTextBox1.Text = currentParty.getName();
                sizeTextBox1.Text = currentParty.getPartySize().ToString();
                requestsTextBox1.Text = currentParty.getSpecialReq();

                currentParty = null;
            }

        }
        private void table2GroupBox_click(object sender, EventArgs e)
        {
            if (table2.getInUse())
            {
                System.Windows.Forms.MessageBox.Show("Already in use");
            }
            else if (currentParty.getIsSeated() == true)
            {
                System.Windows.Forms.MessageBox.Show("Already seated");
            }
            else
            {
                table2.seat(currentParty);
                nameTextBox2.Text = currentParty.getName();
                sizeTextBox2.Text = currentParty.getPartySize().ToString();
                requestsTextBox2.Text = currentParty.getSpecialReq();

                currentParty = waitList.getNextParty();
            }

        }
        private void table3GroupBox_click(object sender, EventArgs e)
        {
            if (table3.getInUse())
            {
                System.Windows.Forms.MessageBox.Show("Already in use");
            }
            else if (currentParty.getIsSeated() == true)
            {
                System.Windows.Forms.MessageBox.Show("Already seated");
            }
            else
            {
                table3.seat(currentParty);
                nameTextBox3.Text = currentParty.getName();
                sizeTextBox3.Text = currentParty.getPartySize().ToString();
                requestsTextBox3.Text = currentParty.getSpecialReq();

                currentParty = waitList.getNextParty();
            }
        }
        private void table4GroupBox_click(object sender, EventArgs e)
        {
            if (table4.getInUse())
            {
                System.Windows.Forms.MessageBox.Show("Already in use");
            }
            else if (currentParty.getIsSeated() == true)
            {
                System.Windows.Forms.MessageBox.Show("Already seated");
            }
            else
            {
                table4.seat(currentParty);
                nameTextBox4.Text = currentParty.getName();
                sizeTextBox4.Text = currentParty.getPartySize().ToString();
                requestsTextBox4.Text = currentParty.getSpecialReq();
            }

        }
        private void table5GroupBox_click(object sender, EventArgs e)
        {
            if (table5.getInUse())
            {
                System.Windows.Forms.MessageBox.Show("Already in use");
            }
            else if (currentParty.getIsSeated() == true)
            {
                System.Windows.Forms.MessageBox.Show("Already seated");
            }
            else
            {
                table1.seat(currentParty);
                nameTextBox5.Text = currentParty.getName();
                sizeTextBox5.Text = currentParty.getPartySize().ToString();
                requestsTextBox5.Text = currentParty.getSpecialReq();
            }
        }
        private void table6GroupBox_click(object sender, EventArgs e)
        {
            if (table6.getInUse())
            {
                System.Windows.Forms.MessageBox.Show("Already in use");
            }
            else if (currentParty.getIsSeated() == true)
            {
                System.Windows.Forms.MessageBox.Show("Already seated");
            }
            else
            {
                table1.seat(currentParty);
                nameTextBox6.Text = currentParty.getName();
                sizeTextBox6.Text = currentParty.getPartySize().ToString();
                requestsTextBox6.Text = currentParty.getSpecialReq();
            }
        }
        private void table7GroupBox_click(object sender, EventArgs e)
        {
            if (table7.getInUse())
            {
                System.Windows.Forms.MessageBox.Show("Already in use");
            }
            else if (currentParty.getIsSeated() == true)
            {
                System.Windows.Forms.MessageBox.Show("Already seated");
            }
            else
            {
                table1.seat(currentParty);
                nameTextBox7.Text = currentParty.getName();
                sizeTextBox7.Text = currentParty.getPartySize().ToString();
                requestsTextBox7.Text = currentParty.getSpecialReq();
            }

        }
        private void table8GroupBox_click(object sender, EventArgs e)
        {
            if (table8.getInUse())
            {
                System.Windows.Forms.MessageBox.Show("Already in use");
            }
            else if (currentParty.getIsSeated() == true)
            {
                System.Windows.Forms.MessageBox.Show("Already seated");
            }
            else
            {
                table1.seat(currentParty);
                nameTextBox8.Text = currentParty.getName();
                sizeTextBox8.Text = currentParty.getPartySize().ToString();
                requestsTextBox8.Text = currentParty.getSpecialReq();
            }

        }
        private void table9GroupBox_click(object sender, EventArgs e)
        {
            if (table9.getInUse())
            {
                System.Windows.Forms.MessageBox.Show("Already in use");
            }
            else if (currentParty.getIsSeated() == true)
            {
                System.Windows.Forms.MessageBox.Show("Already seated");
            }
            else
            {
                table9.seat(currentParty);
                nameTextBox9.Text = currentParty.getName();
                sizeTextBox9.Text = currentParty.getPartySize().ToString();
                requestsTextBox9.Text = currentParty.getSpecialReq();

            }
        }
        private void table10GroupBox_click(object sender, EventArgs e)
        {
            if (table10.getInUse())
            {
                System.Windows.Forms.MessageBox.Show("Already in use");
            }
            else if (currentParty.getIsSeated() == true)
            {
                System.Windows.Forms.MessageBox.Show("Already seated");
            }
            else
            {
                table10.seat(currentParty);
                nameTextBox10.Text = currentParty.getName();
                sizeTextBox10.Text = currentParty.getPartySize().ToString();
                requestsTextBox10.Text = currentParty.getSpecialReq();
            }

        }
        private void table11GroupBox_click(object sender, EventArgs e)
        {
            if (table11.getInUse())
            {
                System.Windows.Forms.MessageBox.Show("Already in use");
            }
            else if (currentParty.getIsSeated() == true)
            {
                System.Windows.Forms.MessageBox.Show("Already seated");
            }
            else
            {
                table1.seat(currentParty);
                nameTextBox11.Text = currentParty.getName();
                sizeTextBox11.Text = currentParty.getPartySize().ToString();
                requestsTextBox11.Text = currentParty.getSpecialReq();
            }

        }
        private void table12GroupBox_click(object sender, EventArgs e)
        {
            if (table12.getInUse())
            {
                System.Windows.Forms.MessageBox.Show("Already in use");
            }
            else if (currentParty.getIsSeated() == true)
            {
                System.Windows.Forms.MessageBox.Show("Already seated");
            }
            else
            {
                table12.seat(currentParty);
                nameTextBox12.Text = currentParty.getName();
                sizeTextBox12.Text = currentParty.getPartySize().ToString();
                requestsTextBox1.Text = currentParty.getSpecialReq();
            }

        }
        private void table13GroupBox_click(object sender, EventArgs e)
        {
            if (table13.getInUse())
            {
                System.Windows.Forms.MessageBox.Show("Already in use");
            }
            else if (currentParty.getIsSeated() == true)
            {
                System.Windows.Forms.MessageBox.Show("Already seated");
            }
            else
            {
                table13.seat(currentParty);
                nameTextBox13.Text = currentParty.getName();
                sizeTextBox13.Text = currentParty.getPartySize().ToString();
                requestsTextBox13.Text = currentParty.getSpecialReq();
            }

        }
        private void table14GroupBox_click(object sender, EventArgs e)
        {
            if (table14.getInUse())
            {
                System.Windows.Forms.MessageBox.Show("Already in use");
            }
            else if (currentParty.getIsSeated() == true)
            {
                System.Windows.Forms.MessageBox.Show("Already seated");
            }
            else
            {
                table1.seat(currentParty);
                nameTextBox14.Text = currentParty.getName();
                sizeTextBox14.Text = currentParty.getPartySize().ToString();
                requestsTextBox14.Text = currentParty.getSpecialReq();
            }

        }
        private void table15GroupBox_click(object sender, EventArgs e)
        {
            if (table15.getInUse())
            {
                System.Windows.Forms.MessageBox.Show("Already in use");
            }
            else if (currentParty.getIsSeated() == true)
            {
                System.Windows.Forms.MessageBox.Show("Already seated");
            }
            else
            {
                table15.seat(currentParty);
                nameTextBox15.Text = currentParty.getName();
                sizeTextBox15.Text = currentParty.getPartySize().ToString();
                requestsTextBox15.Text = currentParty.getSpecialReq();
            }

        }
        private void table16GroupBox_click(object sender, EventArgs e)
        {
            if (table16.getInUse())
            {
                System.Windows.Forms.MessageBox.Show("Already in use");
            }
            else if (currentParty.getIsSeated() == true)
            {
                System.Windows.Forms.MessageBox.Show("Already seated");
            }
            else
            {
                table1.seat(currentParty);
                nameTextBox16.Text = currentParty.getName();
                sizeTextBox16.Text = currentParty.getPartySize().ToString();
                requestsTextBox16.Text = currentParty.getSpecialReq();
            }

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
