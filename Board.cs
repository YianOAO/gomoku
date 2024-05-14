using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace 五子棋
{
    class Board
    {
        private static readonly int Node_count = 9;//在棋盤的一個方向上有幾個交叉點(9個)

        private static readonly Point No_Match_Node= new Point(-1,-1);//用一個Point資料代表不存在的點(要使用不會用到的點)
        
        private static readonly int Offset = 75;//最左線到邊框的距離
        private static readonly int Node_Radius = 10;//交點的碰撞箱
        private static readonly int Node_Distance = 75;//點跟點之間的距離

        //使用二維陣列紀錄棋子
        private Piece[,] pieces = new Piece[Node_count, Node_count];//存放棋子的資料結構(有9*9個交點)

        //判斷這個位置可不可以放棋子
        public bool CanBePlaced(int x, int y)
        {
            //TODO: 找出最近的節點(Node)
            Point nodeId = FindTheClosetNode(x, y);//(nodeId)一個節點的座標位置
            //TODO: 如果沒有的話，回傳false
            if(nodeId == No_Match_Node)
            {
                return false;
            }
            //TODO: 如果有的話，檢查是否已經有棋子存在
            if (pieces[nodeId.X, nodeId.Y] != null)//預設每一個都是=null
            {
                return false;//回傳已經有棋子存在
            }
            return true;
        }
        //
        public Piece PlaceaPiece(int x,int y,PieceType type)
        {
            //TODO: 找出最近的節點(Node)
            Point nodeId = FindTheClosetNode(x, y);//(nodeId)一個節點的座標位置。//nodeId是第幾個交叉點
            //TODO: 如果沒有的話，回傳false
            if (nodeId == No_Match_Node)
            {
                return null;//return Piece的值，Piece是一個class，要指向 沒有任何一個物件
            }
            //TODO: 如果有的話，檢查是否已經有棋子存在
            if (pieces[nodeId.X, nodeId.Y] != null)//預設每一個都是=null
            {
                return null;//回傳已經有棋子存在
            }
            //TODO: 根據 type 產生對應的棋子
            Point formPos = convertToFormPosition(nodeId);
            if (type == PieceType.BLACK)
            {
                pieces[nodeId.X, nodeId.Y]=new BlackPiece(formPos.X,formPos.Y);
            }
            else if (type == PieceType.WHITE)
            {
                pieces[nodeId.X, nodeId.Y] = new WhitePiece(formPos.X, formPos.Y);
            }
            return pieces[nodeId.X, nodeId.Y];//產生出來的結果
        }
        private Point convertToFormPosition(Point nodeId)//nodeId轉換成實際座標位置
        {
            Point formPoisition = new Point();//先開個空白的
            formPoisition.X = nodeId.X*Node_Distance+Offset;
            formPoisition.Y = nodeId.Y*Node_Distance+Offset;
            return formPoisition;
        }

        //判斷是靠近哪個點(寫一個method)
        private Point FindTheClosetNode(int x,int y)//Point 一個點的位置(座標)
        {

            int nodeIdX = FindTheClosetNode(x);//X方向有沒有符合的點
            if (nodeIdX == -1||nodeIdX>= Node_count)//沒有//希望nodeId是在0~8之間，要消除>=9的狀況
            {
                return No_Match_Node;
            }
            int nodeIdY = FindTheClosetNode(y);//Y方向有沒有符合的點
            if(nodeIdY == -1||nodeIdY>= Node_count)//沒有
            {
                return No_Match_Node;
            }
            return new Point(nodeIdX, nodeIdY);//有的話Return一個Point
        }
        //
        private int FindTheClosetNode(int pos)//對一條線上的座標點判斷
        {
            if(pos < Offset - Node_Radius)//讓邊邊不要有手的效果
            {
                return -1;
            }
            pos-=Offset;
            int quotient = pos / Node_Distance;//商數:判斷 點的位置 左邊的點是誰
            int remainder = pos % Node_Distance;//餘數:判斷點的位置範圍是否界在碰撞箱(R)裡面
            if (remainder <= Node_Radius)//屬於左邊點的範圍
            {
                return quotient;
            }
            else if(remainder >= Node_Distance - Node_Radius)//屬於右邊的範圍 若大於等於(全部-右邊碰撞箱)
            {
                return quotient+1;
            }
            else
            {
                return -1;//沒有點符合
            }
            

        }
    }
}
