using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleFamilyBudgetApp_v_1._0._0
{
    public partial class BankAccount : Form
    {
        public BankAccount()
        {
            InitializeComponent();
            UserEditorRepo.PrepareUserEditorData();
            PrepareComboBoxes();
        }

        private void PrepareComboBoxes()
        {
            foreach (UserEditorModel user in UserEditorRepo.users.Values) {
                comboBoxUser.Items.Add($"{user.LastName}, {user.FirstName} {user.MiddleInitial} : {user.userName}.");
            }
        }

        private void buttonAddBankName_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddAccountType_Click(object sender, EventArgs e)
        {

        }

        private void buttonSubmitNewAccount_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxUser_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
