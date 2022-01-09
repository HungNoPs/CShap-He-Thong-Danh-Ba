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
    public partial class PhoneBookForm : Form
    {
        SqlConnection con = new SqlConnection(@"Server=DESKTOP-U6JMPCP\SQLEXPRESS;Database=QLDANHBA;Integrated security=true");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public PhoneBookForm()
        {
            InitializeComponent();
            LoadPhone();
        }
        public void LoadRelationship()
        {
            cmReship.Items.Clear();
            cm = new SqlCommand("SELECT relationshipName FROM Relationship", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                cmReship.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        public void LoadPhone()
        {
            LoadRelationship();
            int i = 0;
            dgvProduct.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM Phone WHERE CONCAT(FirstName, LastName, Email, Phone) LIKE '%" + txtSearch.Text + "%'", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvProduct.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
            }
            dr.Close();
            con.Close();
        }
        private void btnAddPhone_Click(object sender, EventArgs e)
        {
            PhoneBookModuleForm formModule = new PhoneBookModuleForm();
            formModule.btnSave.Enabled = true;
            formModule.btnUpdate.Enabled = false;
            formModule.ShowDialog();
            LoadPhone();
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvProduct.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                PhoneBookModuleForm phoneModule = new PhoneBookModuleForm();
                phoneModule.lblPid.Text = dgvProduct.Rows[e.RowIndex].Cells[0].Value.ToString();
                phoneModule.txtFName.Text = dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
                phoneModule.txtLName.Text = dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
                phoneModule.txtEmail.Text = dgvProduct.Rows[e.RowIndex].Cells[3].Value.ToString();
                phoneModule.txtAddress.Text = dgvProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
                phoneModule.comboRe.Text = dgvProduct.Rows[e.RowIndex].Cells[5].Value.ToString();
                phoneModule.textPhone.Text = dgvProduct.Rows[e.RowIndex].Cells[6].Value.ToString();

                phoneModule.btnSave.Enabled = false;
                phoneModule.btnUpdate.Enabled = true;
                phoneModule.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this Phone?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM Phone WHERE PhoneID LIKE '" + dgvProduct.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record has been successfully deleted!");
                }
            }
            LoadPhone();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadPhone();
        }
    }
}
