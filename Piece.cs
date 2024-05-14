using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;//
using System.Drawing;

namespace 五子棋
{
    abstract class Piece : PictureBox 
    {
        public Piece(int x,int y)
        {
            this.BackColor = Color.Transparent;
            this.Location = new Point(x, y);//建立一個點
            this.Size = new Size(50,50);

        }
    }
}
