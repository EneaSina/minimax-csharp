using System;
using System.Collections.Generic;
using System.Text;
using minimax.core.adversarial;


namespace minimax.tictactoe
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Loop-- > until partita finita
            //Chiedere la mossa all'utente
            //Calcolare il nuovo stato
            //Stamapare il nuovo stato
            //Chiedere la mossa al computer
            //Calcolare il nuovo stato
            //Stampare il nuovo stato
            while (true)
            {
              
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("     TRIS    ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("+---+---+---+");
                Console.WriteLine("|   |   |   |");
                Console.WriteLine("+---+---+---+");
                Console.WriteLine("|   |   |   |");
                Console.WriteLine("+---+---+---+");
                Console.WriteLine("|   |   |   |");
                Console.WriteLine("+---+---+---+");
                Console.WriteLine("");
                Game game = new Game();
                List<Action> actions = new List<Action>();
                State state = game.GetInitialState();
                AdversarialSearch<State, Action> adversarial;
                adversarial = new MinimaxSearch<State, Action, Player>(game);
                while (!game.IsTerminal(state))
                {
                    Console.WriteLine("Inserisci le coordinate delle righe");
                        int row = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Inserisci le coordinate delle colonne");
                         int col = Convert.ToInt32(Console.ReadLine());
                    Action action = new Action(row, col);
                    actions = game.GetActions(state);

                    state = game.GetResult(state, action);
                    Tabella(state);

                    if (!game.IsTerminal(state))
                    {
                        Action mossaBot = adversarial.makeDecision(state);
                        state = game.GetResult(state, mossaBot);
                        Tabella(state);
                    }
                    if (game.IsTerminal(state))
                    {
                        if (game.GetUtility(state,state.giocatoreCorrente)==double.PositiveInfinity)
                        {
                            Console.WriteLine("HAI VINTO... BRAVO");
                        }
                        else if (game.GetUtility(state, state.giocatoreCorrente) == double.NegativeInfinity)
                        {
                            Console.WriteLine("HAI PERSO... LA PROSSIMA VOLTA PROVA A PAREGGIARE");
                        }
                        else 
                        {
                            Console.WriteLine("HAI PAREGGIATO..");
                        }
                    }
                }
            }
        }
        public static void Tabella(State stato)
        {
            string[,] fill = new string[3,3];//VIENE RIEMPITO COL GLI SPAZI, X, O, PER METTERLI NELLA TABELLA
            for (int i = 0; i < 3; i++)
            {

                for (int j = 0; j < 3; j++)
                {
                    if (stato.campo[i, j] == -1)
                        fill[i,j] = " ";//RIEMPITO CON 0 CHE SARA' " "
                    else if (stato.campo[i, j] == 0)
                        fill[i,j] = "X";//RIEMPITO CON 1 CHE SARA' X
                    else
                        fill[i,j] = "O";//RIEMPITO CON 0 CHE SARA' O

                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("+---+---+---+");
            Console.WriteLine($"| {fill[0, 0]} | {fill[0, 1]} | {fill[0, 2]} |");
            Console.WriteLine("+---+---+---+");
            Console.WriteLine($"| {fill[1, 0]} | {fill[1, 1]} | {fill[1, 2]} |");
            Console.WriteLine("+---+---+---+");
            Console.WriteLine($"| {fill[2, 0]} | {fill[2, 1]} | {fill[2, 2]} |");
            Console.WriteLine("+---+---+---+");


            Console.ForegroundColor = ConsoleColor.White;

        }
    }
}
