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

namespace LearnerReports
{
    public partial class Form1 : Form
    {
        SqlConnection connect = new SqlConnection
            (@"Data Source=DESKTOP-CD26AIV\SQLEXPRESS;Initial Catalog=learnerReports;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                connect.Open();
                var query = "select * from StudentInformation where Name = @StudentName " +
                        "and Surname = @StudentSurname";
                var command = new SqlCommand(query, connect);
                command.Parameters.AddWithValue("@StudentName", txtName.Text);
                command.Parameters.AddWithValue("@StudentSurname", txtSurname.Text);

                SqlDataAdapter dataAdap = new SqlDataAdapter(command);
                DataTable dTable = new DataTable();
                dataAdap.Fill(dTable);

                if (dTable.Rows.Count == 1)
                {
                    ImportReport iRep = new ImportReport();
                    iRep.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Student name or surname is invalid");
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connect.Close();
            }
        }
    }
}
