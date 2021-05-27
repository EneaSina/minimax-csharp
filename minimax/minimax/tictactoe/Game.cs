using System;
using System.Collections.Generic;
using System.Text;
using minimax.core.adversarial;

namespace minimax.tictactoe
{
    class Game : IGame<State, Action, Player>
    {
        public int vincitore;
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
            // CREA UN ARRAY CON UN GIOCATORE CROCE E UNO CERCHIO
            Player[] players = new Player[2] { Player.Cross, Player.Circle };
            return players;
        }

        public State GetResult(State state, Action action)
        {
            //creare un nuovo stato
            //copiare il contenuto dello stato precedente nel nuovo stato
            //invertire il giocatore(se era cross mettere circle, e vicerversa)
            //inserire la mossa nel nuovo stato
            //ritornare il nuovo stato
            State StatoCopia = new State();
            StatoCopia.campo = (int[,])state.campo.Clone();
            StatoCopia.giocatoreCorrente = state.giocatoreCorrente;

            StatoCopia.campo[action.Row, action.Col] = (int)state.giocatoreCorrente;
            if (StatoCopia.giocatoreCorrente == Player.Circle)
            {
                StatoCopia.giocatoreCorrente = Player.Cross;
            }
            else
            {
                StatoCopia.giocatoreCorrente = Player.Circle;
            }
            return StatoCopia;
        }//OK

        public double GetUtility(State state, Player player)
        {
            int vincitore = ControlloCombinazioni(state);
            if (IsTerminal(state) == true)
            {
                if (vincitore == (int)player)
                    return double.PositiveInfinity - 1;
                else if (vincitore == -1)
                    return 0;
                else
                {
                    return double.NegativeInfinity + 1;
                }
            }
            return 0;
        }

        public bool IsTerminal(State state)
        {
            if (ControlloCombinazioni(state) != -1)
            {
                return true;
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (state.campo[i, j] == -1)
                    {
                        return false;
                    }
                }
            }
            return true;


        }//OK
        public static int ControlloCombinazioni(State state)
        {
            //CONTROLLA TUTTE LE CONBINAZIONI DEL TRIS 
            for (int i = 0; i < 3; i++)
            {
                if (state.campo[i, 0] != -1)
                {
                    if ((state.campo[i, 0] == state.campo[i, 1]) && (state.campo[i, 0] == state.campo[i, 2]))
                    {
                        return state.campo[i, 0];
                    }

                }
                if (state.campo[0, i] != -1)
                {
                    if ((state.campo[0, i] == state.campo[1, i]) && (state.campo[0, 1] == state.campo[2, i]))
                    {
                        return state.campo[0, i];
                    }
                }
            }
            if (state.campo[1, 1] != -1)
            {
                if ((state.campo[0, 0] == state.campo[1, 1]) && (state.campo[0, 0] == state.campo[2, 2]))
                {
                    return state.campo[1, 1];
                }
                else if ((state.campo[0, 2] == state.campo[1, 1]) && (state.campo[0, 2] == state.campo[2, 0]))
                {
                    return state.campo[1, 1];
                }
            }
            return -1;
        }//OK
    }

    
}
