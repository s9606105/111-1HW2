using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _111_1HW2
{
    public partial class Bomb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // char2D array 10*10
            String[,] ia_Map = new string[10, 10];
            int[,] in_num = new int[10, 10];

            // int array 10
            int[] ia_MIndex = new int[10] { 0, 7, 13, 28, 44,
                                        62, 74, 75, 87, 90 };

            // set num

            // set bomb and num
            for (int i = 0; i < ia_MIndex.Length; i++)
            {
                int x = ia_MIndex[i] / 10;
                int y = ia_MIndex[i] % 10;

                // 目前此方法最快
                if (x != 0 && y != 0)
                {
                    in_num[x - 1, y - 1] += 1; // x != 0 && y!= 0
                }
                if (x != 0 && y != 9)
                {
                    in_num[x - 1, y + 1] += 1; // x != 0 && y != 9
                }
                if (x != 9 && y != 0)
                {
                    in_num[x + 1, y - 1] += 1; // x != 9 && y != 0
                }
                if (x != 9 && y != 9)
                {
                    in_num[x + 1, y + 1] += 1; // x != 9 && y != 9
                }
                if (x != 0)
                {
                    in_num[x - 1, y] += 1; // x != 0
                }
                if (x != 9)
                {
                    in_num[x + 1, y] += 1; // x != 9
                }
                if (y != 0)
                {
                    in_num[x, y - 1] += 1; // y != 0
                }
                if (y != 9)
                {
                    in_num[x, y + 1] += 1; // y != 9
                }
                ia_Map[x, y] = "*";
            }


            // Reseponse
            for (int i_x = 0; i_x < ia_Map.GetLength(0); i_x++)
            {
                for (int i_y = 0; i_y < ia_Map.GetLength(1); i_y++)
                {
                    if (ia_Map[i_x, i_y] != "*")
                    {
                        ia_Map[i_x, i_y] = in_num[i_x, i_y].ToString(); // Convert.ToChar() 轉char
                    }
                    if (ia_Map[i_x, i_y] == "0") // '\0' 為 char預設
                    {
                        ia_Map[i_x, i_y] = "x";
                    }
                    Response.Write(ia_Map[i_x, i_y] + " ");
                }
                Response.Write("<br>");
            }
        }
    }
}