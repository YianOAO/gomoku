namespace 五子棋
{
    public partial class Form1 : Form
    {
        private Board board = new Board();//呼叫一個物件，才能使用Board的功能

        private PieceType nextPieceType = PieceType.BLACK;
        public Form1()
        {
            InitializeComponent();
        }
        //黑白棋輪流
        private bool IsBlack = true;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Piece piece = board.PlaceaPiece(e.X, e.Y, nextPieceType);//放黑棋到鼠標點的地方
            if (piece != null)
            {
                this.Controls.Add(piece);

                if (nextPieceType == PieceType.BLACK)
                {
                    nextPieceType = PieceType.WHITE;
                }
                else if (nextPieceType == PieceType.WHITE)
                {
                    nextPieceType = PieceType.BLACK;
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)//滑鼠移動時，需要做甚麼事件(會到這個事件)
        {
            if (board.CanBePlaced(e.X, e.Y))//呼叫方法，知道能不能放
            {
                this.Cursor = Cursors.Hand;//改變游標為手的圖案
            }
            else
            {
                this.Cursor = Cursors.Default;//如果不能，變回預設
            }
        }
        //
    }
}