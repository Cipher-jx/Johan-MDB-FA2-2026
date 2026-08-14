namespace KhayelitshaLibraryApp
{
    public partial class FrmDashboard : Form
    {
        public FrmDashboard()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnMembers_Click(object sender, EventArgs e)
        {
            FrmMembers membersForm = new FrmMembers();
            membersForm.Show();
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            FrmBooks booksForm = new FrmBooks();
            booksForm.Show();
        }

        private void btnLoans_Click(object sender, EventArgs e)
        {
            FrmLoans loansForm = new FrmLoans();
            loansForm.Show();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            FrmReports reportsForm = new FrmReports();
            reportsForm.Show();
        }
    }
}
