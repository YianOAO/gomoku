namespace 五子棋
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Controls.Add(new BlackPiece(10, 20));
            this.Controls.Add(new WhitePiece(100, 200));
        }
    }
}