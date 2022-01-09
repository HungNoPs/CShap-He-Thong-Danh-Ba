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
    public partial class PhoneBookModuleForm : Form
    {
        SqlConnection con = new SqlConnection(@"Server=DESKTOP-U6JMPCP\SQLEXPRESS;Database=QLDANHBA;Integrated security=true");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public PhoneBookModuleForm()
        {
            InitializeComponent();
            LoadRelationship();
            comboRe.ValueMember = "RelationID";
        }
        public void Clear()
        {
            txtAddress.Clear();
            txtEmail.Clear();
            txtFName.Clear();
            txtLName.Clear();
            textPhone.Clear();
        }
        public void LoadRelationship()
        {
            comboRe.Items.Clear();
            cm = new SqlCommand("SELECT relationshipName FROM Relationship", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                comboRe.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("Are you sure you want to save this Phone?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    cm = new SqlCommand("INSERT INTO Phone(FirstName,LastName,Email,Address,RelationshipID,Phone)VALUES(@fn, @ln, @email, @address, @reID,@phone)", con);
                    cm.Parameters.AddWithValue("@fn", txtFName.Text);
                    cm.Parameters.AddWithValue("@ln", txtLName.Text);
                    cm.Parameters.AddWithValue("@email", txtEmail.Text);
                    cm.Parameters.AddWithValue("@address", txtAddress.Text);
                    cm.Parameters.AddWithValue("@reID", comboRe.ValueMember);
                    cm.Parameters.AddWithValue("@phone", textPhone.Text);

                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Product has been successfully saved.");
                    Clear();
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
                MessageBox.Show("Record has been:"+ comboRe.ValueMember.ToString());

                if (MessageBox.Show("Are you sure you want to update this Phone?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    cm = new SqlCommand("UPDATE Phone SET FirstName = @fn, LastName=@ln, Email=@email, Address=@address, RelationshipID=@reID ,Phone = @phone WHERE PhoneID LIKE '" + lblPid.Text + "' ", con);
                    cm.Parameters.AddWithValue("@fn", txtFName.Text);
                    cm.Parameters.AddWithValue("@ln", txtLName.Text);
                    cm.Parameters.AddWithValue("@email", txtEmail.Text);
                    cm.Parameters.AddWithValue("@address", txtAddress.Text);
                    cm.Parameters.AddWithValue("@reID", comboRe.Items);
                    cm.Parameters.AddWithValue("@phone", textPhone.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Product has been successfully updated!");
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
