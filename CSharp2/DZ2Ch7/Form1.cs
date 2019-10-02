using System.Windows.Forms;

namespace DZ2Ch7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tableBindingNavigatorSaveItem_Click(object sender, System.EventArgs e)
        {
            this.Validate();
            this.tableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dZ2Ch7DataSet);

        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            // TODO: This line of code loads data into the 'dZ2Ch7DataSet.Table' table. You can move, or remove it, as needed.
            this.tableTableAdapter.Fill(this.dZ2Ch7DataSet.Table);

        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            string connectionString = Properties.Settings.Default.DZ2Ch7ConnectionString;
            System.Data.SqlClient.SqlConnection connection = new
            System.Data.SqlClient.SqlConnection(connectionString);
            System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(
                                                        "CREATE TABLE[dbo].[Bred]"
                                                        + "("
                                                        + "[Id] INT NOT NULL PRIMARY KEY IDENTITY,"
                                                        + "[Text] NVARCHAR(MAX) NULL"
                                                        + ")", connection);
            connection.Open();
            command.ExecuteReader();
            connection.Close();
        }

        private void btnDel_Click(object sender, System.EventArgs e)
        {
            string connectionString = Properties.Settings.Default.DZ2Ch7ConnectionString;
            System.Data.SqlClient.SqlConnection connection = new
            System.Data.SqlClient.SqlConnection(connectionString);
            System.Data.SqlClient.SqlCommand command = new
            System.Data.SqlClient.SqlCommand("DROP TABLE[dbo].[Bred]", connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
