using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneBook
{
    public partial class RelationshipModuleForm : Form
    {
        SqlConnection con = new SqlConnection(@"Server=DESKTOP-U6JMPCP\SQLEXPRESS;Database=QLDANHBA;Integrated security=true");
        SqlCommand cm = new SqlCommand();
        public RelationshipModuleForm()
        {
            InitializeComponent();
        }
        public void Clear()
        {
            txtCatName.Clear();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this Relationship?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    cm = new SqlCommand("INSERT INTO Relationship(relationshipName)VALUES(@catname)", con);
                    cm.Parameters.AddWithValue("@catname", txtCatName.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Relationship has been successfully saved.");
                    this.Dispose();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to update this Relationship?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    cm = new SqlCommand("UPDATE Relationship SET relationshipName = @catname WHERE relationshipID LIKE '" + lblCatId.Text + "' ", con);
                    cm.Parameters.AddWithValue("@catname", txtCatName.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Relationship has been successfully updated!");
                    this.Dispose();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }
    }
}
