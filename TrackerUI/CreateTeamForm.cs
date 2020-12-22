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

        private List<PersonModel> availableTeamMembers = GlobalConfig.Connection.GetPerson_All();
        private List<PersonModel> selectedTeamMembers = new List<PersonModel>();
        public CreateTeamForm()
        {
            InitializeComponent();
           // CreateSampleData();
            wireUpLists();  
        }
       
        private void wireUpLists()
        {
            selectTeamMemberDropdown.DataSource = null;

            selectTeamMemberDropdown.DataSource = availableTeamMembers;
            selectTeamMemberDropdown.DisplayMember = "FullName";

            teamMembersListbox.DataSource = null;
            teamMembersListbox.DataSource = selectedTeamMembers;
            teamMembersListbox.DisplayMember = "FullName";
        }

        private void CreateSampleData()
        {
            availableTeamMembers.Add(new PersonModel { FirstName = "Bob", LastName = "Smith" });
            availableTeamMembers.Add(new PersonModel { FirstName = "Mike", LastName = "Richards" });

            selectedTeamMembers.Add(new PersonModel { FirstName = "Sue", LastName = "Williams" });
            selectedTeamMembers.Add(new PersonModel { FirstName = "Bill", LastName = "Jones" });
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

        private void addMemberButton_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel)selectTeamMemberDropdown.SelectedItem;

            availableTeamMembers.Remove(p);
            selectedTeamMembers.Add(p);
           wireUpLists();
        }
    }
}
