using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapturePicture_Sample
{
    public partial class TicTacToe : Form
    {
        int[] region = new int[9]; //紀錄九宮格狀態
        public TicTacToe()
        {
            InitializeComponent();
            this.Width = 561;
            this.Height = 561;
            this.Click += new EventHandler(TicTacToe_Click); // 綁定點擊事件
            this.MouseMove += new MouseEventHandler(TicTacToe_MouseMove); // 綁定滑鼠移動事件
        }

        #region 計算
        float column; //計算每一個欄的寬度

        float row; //計算每一個列的高度

        bool O_X = true; //O先

        int mouse_location_x;  //滑鼠X

        int mouse_location_y; //滑鼠y

        int[] bingo = new int[8]; //是否有勝利連線

        bool finish = false; //已結束
        #endregion

        #region 繪圖
        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics g = pe.Graphics; //取得Graphics  

            Pen p = new Pen(Color.Black); //取得Pen  

            float width = this.Width - 20; //取得畫面大小  
            float height = this.Height - 20; //取得畫面大小  

            column = width / 3; //計算出要畫的範圍  
            row = height / 3; //計算出要畫的範圍  

            g.DrawLine(p, 0, row, width, row); //畫橫線 
            g.DrawLine(p, 0, row * 2, width, row * 2); //畫橫線 

            g.DrawLine(p, column, 0, column, height); //畫直線  
            g.DrawLine(p, column * 2, 0, column * 2, height); //畫直線

            for (int i = 0; i < region.Length; i++) //判斷是否需要畫OX
            {
                if (region[i] == 1)
                {
                    g.DrawEllipse(p, (i % 3) * (column) + 30, (i / 3) * (row) + 30, column - 60, row - 60);
                }
                if (region[i] == 2)
                {
                    g.DrawLine(p, (i % 3) * column + 20, (i / 3) * row + 20, ((i % 3) + 1) * column - 20, (i / 3 + 1) * row - 20);
                    g.DrawLine(p, ((i % 3) + 1) * column - 20, (i / 3) * row + 20, (i % 3) * column + 20, ((i / 3) + 1) * row - 20);
                }
            }

            for (int i = 0; i < bingo.Length; i++) //畫出勝利直線
            {
                if (bingo[0] == 1) //0,1,2 
                {
                    g.DrawLine(p, 0, row / 2, width, row / 2);
                    finish = true;
                }

                if (bingo[1] == 1) //3,4,5 
                {
                    g.DrawLine(p, 0, row * 2 - row / 2, width, row * 2 - row / 2);
                    finish = true;
                }

                if (bingo[2] == 1) //6,7,8 
                {
                    g.DrawLine(p, 0, row * 3 - row / 2, width, row * 3 - row / 2);
                    finish = true;
                }

                if (bingo[3] == 1) //0,3,6 
                {
                    g.DrawLine(p, column - (column / 2), 0, column - (column / 2), height);
                    finish = true;
                }

                if (bingo[4] == 1) //1,4,7  
                {
                    g.DrawLine(p, column * 2 - (column / 2), 0, column * 2 - (column / 2), height);
                    finish = true;
                }

                if (bingo[5] == 1) //2,5,8  
                {
                    g.DrawLine(p, column * 3 - (column / 2), 0, column * 3 - (column / 2), height);
                    finish = true;
                }

                if (bingo[6] == 1) //0,4,8
                {
                    g.DrawLine(p, 0, 0, width, height);
                    finish = true;
                }

                if (bingo[7] == 1) //2,4,6
                {
                    g.DrawLine(p, width, 0, 0, height);
                    finish = true;
                }
            }
        }
        #endregion

        #region 滑鼠點下去後要做的事
        private void TicTacToe_Click(object sender, EventArgs e)
        {
            //取得滑鼠座標  
            int x = mouse_location_x;
            int y = mouse_location_y;

            if (!finish)
            {
                //判斷點下的區域是那一個  
                //左邊第一排
                if (x < column)
                {
                    if (y > 0 && y < row) //0 
                    {
                        if (region[0] == 0)
                        {
                            region[0] = O_X == true ? 1 : 2;
                            O_X = !O_X;
                        }
                    }

                    if (y > row && y < row * 2) //3
                    {
                        if (region[3] == 0)
                        {
                            region[3] = O_X == true ? 1 : 2;
                            O_X = !O_X;
                        }
                    }

                    if (y > row * 2 && y < row * 3) //6
                    {
                        if (region[6] == 0)
                        {
                            region[6] = O_X == true ? 1 : 2;
                            O_X = !O_X;
                        }
                    }
                }

                if (x > column && x < column * 2) //中間那一排  
                {
                    if (y > 0 && y < row) //1
                    {
                        if (region[1] == 0)
                        {
                            region[1] = O_X == true ? 1 : 2;
                            O_X = !O_X;
                        }
                    }

                    if (y > row && y < row * 2) //4
                    {
                        if (region[4] == 0)
                        {
                            region[4] = O_X == true ? 1 : 2;
                            O_X = !O_X;
                        }
                    }

                    if (y > row * 2 && y < row * 3) //7
                    {
                        if (region[7] == 0)
                        {
                            region[7] = O_X == true ? 1 : 2;
                            O_X = !O_X;
                        }
                    }
                }

                if (x > column * 2 && x < column * 3) //右邊那一排
                {
                    if (y > 0 && y < row) //2
                    {
                        if (region[2] == 0)
                        {
                            region[2] = O_X == true ? 1 : 2;
                            O_X = !O_X;
                        }
                    }

                    if (y > row && y < row * 2) //5
                    {
                        if (region[5] == 0)
                        {
                            region[5] = O_X == true ? 1 : 2;
                            O_X = !O_X;
                        }
                    }

                    if (y > row * 2 && y < row * 3) //8
                    {
                        if (region[8] == 0)
                        {
                            region[8] = O_X == true ? 1 : 2;
                            O_X = !O_X;
                        }
                    }
                }
            }

            // 檢查是否有連線
            //CheckForWinner();
            //檢查是否有連線(8種組合)
            //第一列
            if (region[0] == region[1] && region[1] == region[2] && region[0] != 0)
            {
                bingo[0] = 1;
            }
            else if (region[3] == region[4] && region[4] == region[5] && region[3] != 0) //第二列
            {
                bingo[1] = 1;
            }
            //第三列  
            else if (region[6] == region[7] && region[7] == region[8] && region[6] != 0)
            {
                bingo[2] = 1;
            }
            //第一行  
            else if (region[0] == region[3] && region[3] == region[6] && region[0] != 0)
            {
                bingo[3] = 1;
            }
            //第二行  
            else if (region[1] == region[4] && region[4] == region[7] && region[1] != 0)
            {
                bingo[4] = 1;
            }
            //第三行  
            else if (region[2] == region[5] && region[5] == region[8] && region[2] != 0)
            {
                bingo[5] = 1;
            }
            // \連線  
            else if (region[0] == region[4] && region[4] == region[8] && region[0] != 0)
            {
                bingo[6] = 1;
            }
            // /連線  
            else if (region[2] == region[4] && region[4] == region[6] && region[2] != 0)
            {
                bingo[7] = 1;
            }
            this.Refresh();

            //檢查和局  
            int check = 0;
            for (int i = 0; i < region.Length; i++)
            {
                if (region[i] > 0)
                    check++;
            }
            if (check == 9)
            {
                for (int i = 0; i < bingo.Length; i++)
                {
                    if (bingo[i] > 0)
                    {
                        check--;
                    }
                }
            }
            if (check == 9)
            {
                DialogResult dialogResult = MessageBox.Show("平手，要不要再來一局?", "分出勝負", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    for (int i = 0; i < region.Length; i++)
                    {
                        region[i] = 0;
                    }
                    for (int i = 0; i < bingo.Length; i++)
                    {
                        bingo[i] = 0;
                    }
                    O_X = true;
                    finish = false;
                    this.Refresh();
                }
                else if (dialogResult == DialogResult.No)
                {
                    this.Close();
                }
            }

            if (finish) //已分出勝負 
            {
                DialogResult dialogResult = MessageBox.Show(O_X ? "X獲勝，要不要再來一局?" : "O獲勝，要不要再來一局?", "分出勝負", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ResetGame();
                }
                else if (dialogResult == DialogResult.No)
                {
                    this.Close();
                }
            }
            //this.Refresh();
        }
        #endregion

        #region 取得滑鼠位置 
        private void TicTacToe_MouseMove(object sender, MouseEventArgs e)
        {
            mouse_location_x = e.Location.X;
            mouse_location_y = e.Location.Y;
        }
        #endregion

        #region 8種可能的勝利組合
        private void CheckForWinner()
        {
            int[][] winningCombinations = new int[][]
            {
                new int[] {0, 1, 2},
                new int[] {3, 4, 5},
                new int[] {6, 7, 8},
                new int[] {0, 3, 6},
                new int[] {1, 4, 7},
                new int[] {2, 5, 8},
                new int[] {0, 4, 8},
                new int[] {2, 4, 6}
            };

            for (int i = 0; i < winningCombinations.Length; i++)
            {
                int[] combination = winningCombinations[i];
                if (region[combination[0]] == region[combination[1]] && region[combination[1]] == region[combination[2]] && region[combination[0]] != 0)
                {
                    bingo[i] = 1;
                    finish = true;
                }
            }
        }
        #endregion

        #region 重置遊戲
        private void ResetGame()
        {
            for (int i = 0; i < region.Length; i++)
            {
                region[i] = 0;
            }
            for (int i = 0; i < bingo.Length; i++)
            {
                bingo[i] = 0;
            }
            O_X = true;
            finish = false;
            this.Refresh();
        }
        #endregion
    }
}