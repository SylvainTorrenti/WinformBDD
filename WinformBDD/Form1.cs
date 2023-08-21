namespace WinformBDD
{
    public partial class Form1 : Form
    {
        db _db = new db();
        public Form1()
        {
            InitializeComponent();
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            _db.Connect();
        }

        private void btDisconect_Click(object sender, EventArgs e)
        {
            _db.Disconnect();
        }
    }
}