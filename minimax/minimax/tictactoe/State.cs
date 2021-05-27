using System;
using System.Collections.Generic;
using System.Text;

namespace minimax.tictactoe
{
    class State
    {
        public static readonly int EMPTY = -1;
        public static readonly int CYRCLE = (int)Player.Circle;
        public static readonly int CROSS = (int)Player.Cross;

        public State()
        {
            campo = new int[3, 3];
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    campo[row, col] = EMPTY;
                }
            }

            giocatoreCorrente = Player.Cross;
        }

        public int[,] campo { get; set; }
        public Player giocatoreCorrente { get; set; }
        public int getBoardState(int row, int col)
        {
            int stato;
            if (campo[row, col] == EMPTY)
            {
                stato = EMPTY;
            }
            else if (campo[row, col] == CYRCLE)
            {
                stato = CYRCLE;
            }
            else
            {

                stato = CROSS;
            }
            return stato;
        }
    }
}
