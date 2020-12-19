using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class CreateTeamForm : Form
    {
        public CreateTeamForm()
        {
            InitializeComponent();
        }

        private void createMemberButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PersonModel p = new PersonModel();

                p.FirstName = firstNameValue.Text;
                p.LastName = lastNameValue.Text;
                p.CellPhoneNumber = cellPhoneValue.Text;
                p.EmailAddress = emailValue.Text;

                GlobalConfig.Connection.CreatePerson(p);

                firstNameValue.Text = "";
                lastNameValue.Text = "";
                emailValue.Text = "";
                cellPhoneValue.Text = "";

            }
            else
            {
                // TODO elaborate validation errors for create team
                MessageBox.Show("invalid form");
            }
            
        }

        public bool ValidateForm()
        {
            //TODO : do validation for form

            bool output = true;

            if (firstNameValue.Text.Length == 0)
            {
                output = false;
            }

            if (lastNameValue.Text.Length == 0)
            {
                output = false;
            }

            if (cellPhoneValue.Text.Length == 0)
            {
                output = false;
            }
            if (emailValue.Text.Length == 0)
            {
                output = false;
            }

            return output;
        }
    }
}
