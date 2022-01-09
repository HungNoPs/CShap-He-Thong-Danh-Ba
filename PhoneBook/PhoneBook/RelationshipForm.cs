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
    public partial class RelationshipForm : Form
    {
        SqlConnection con = new SqlConnection(@"Server=DESKTOP-U6JMPCP\SQLEXPRESS;Database=QLDANHBA;Integrated security=true");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public RelationshipForm()
        {
            InitializeComponent();
            LoadRelationship();
        }
        public void LoadRelationship()
        {
            int i = 0;
            dgvRelationship.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM Relationship", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvRelationship.Rows.Add(i, dr[0].ToString(), dr[1].ToString());
            }
            dr.Close();
            con.Close();
        }
        private void dgvRelationship_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvRelationship.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                RelationshipModuleForm formModule = new RelationshipModuleForm();
                formModule.lblCatId.Text = dgvRelationship.Rows[e.RowIndex].Cells[1].Value.ToString();
                formModule.txtCatName.Text = dgvRelationship.Rows[e.RowIndex].Cells[2].Value.ToString();

                formModule.btnSave.Enabled = false;
                formModule.btnUpdate.Enabled = true;
                formModule.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this Relationship?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM Relationship WHERE relationshipID LIKE '" + dgvRelationship.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record has been successfully deleted!");
                }
            }
            LoadRelationship();
        }

        private void btnAddRelationship_Click(object sender, EventArgs e)
        {
            RelationshipModuleForm formModule = new RelationshipModuleForm();
            formModule.btnSave.Enabled = true;
            formModule.btnUpdate.Enabled = false;
            formModule.ShowDialog();
            LoadRelationship();
        }
    }
}
