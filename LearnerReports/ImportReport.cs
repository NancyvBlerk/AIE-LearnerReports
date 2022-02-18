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
    public partial class ImportReport : Form
    {
        SqlConnection connect = new SqlConnection
            (@"Data Source=DESKTOP-CD26AIV\SQLEXPRESS;Initial Catalog=learnerReports;Integrated Security=True");
        public ImportReport()
        {
            InitializeComponent();
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            connect.Open();

            SqlCommand cmd = connect.CreateCommand();

            cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "select * from StudentInformation";
            cmd.CommandText = "Select * from StudentInformation " +
                                 "left join studentMark " +
                                 "on StudentInformation.id = studentMark.id";

            DataTable dT = new DataTable();
            SqlDataAdapter dAdap = new SqlDataAdapter(cmd);
            dAdap.Fill(dT);

            dataGridView1.DataSource = dT;

            connect.Close();

        }
    }
}
