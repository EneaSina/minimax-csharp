using System;
using System.Collections.Generic;
using System.Text;
using minimax.core.adversarial;

namespace minimax.tictactoe
{
    class Game : IGame<State, Action, Player>
    {
        public List<Action> GetActions(State state)
        {
            List<Action> action = new List<Action>();
            Action tmp;
            int[,] campo = state.campo;
            Player giocatoreCorrente = state.giocatoreCorrente;
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (campo[row, col] == -1)
                    {
                        tmp = new Action(row, col);
                        action.Add(tmp);
                    }
                }
            }
            return action;
        }   //OK

        public State GetInitialState()
        {
            // E' UN METODO CHE CREA IL CAMPO INZIALE, E RITORNA UNO STATO INIZIALE 

            int[,] campo = new int[3, 3];
            State statoIniziale = new State();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    campo[i, j] = -1;

                }
            }
            Player giocatoreCorr = Player.Cross;
            return statoIniziale;
        } //OK

        public Player GetPlayer(State state)
        {
            // E' UN METODO CHE PRENDE IL GIOCATORE CORRENTE, QUELLO CHE STA PER GIOCARE
            Player giocatore = state.giocatoreCorrente;
            return giocatore;
        } //OK

        public Player[] GetPlayers()
        {
            throw new NotImplementedException();
        }

        public State GetResult(State state, Action action)
        {
            throw new NotImplementedException();
        }

        public double GetUtility(State state, Player player)
        {
            throw new NotImplementedException();
        }

        public bool IsTerminal(State state)
        {
            throw new NotImplementedException();
        }
    }

    class Game
    {

    }
}
