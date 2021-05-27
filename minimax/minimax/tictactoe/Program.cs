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
                Console.WriteLine("Che livello di difficolta' vuoi affrontare?");
                int lv = Convert.ToInt32(Console.ReadLine());
                AdversarialSearch<State, Action> adversarial;
                adversarial = new MinimaxSearchLimited<State, Action, Player>(game, lv);
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
                }
            }
        }
        public static void Tabella(State stato)
        {
            char[] tris = new char[3] { ' ', 'X', 'O' }; //SPAZIO QUANDO NON C'E' NE X NE O
            int[] fill = new int[9];//VIENE RIEMPITO COL GLI SPAZI, X, O, PER METTERLI NELLA TABELLA,USATO COME INDICE
            int k = 0;
            for (int i = 0; i < 3; i++)
            {

                for (int j = 0; j < 3; j++)
                {
                    if (stato.campo[i, j] == -1)
                        fill[k] = 0;//RIEMPITO CON 0 CHE SARA' " "
                    else if (stato.campo[i, j] == 0)
                        fill[k] = 1;//RIEMPITO CON 1 CHE SARA' X
                    else
                        fill[k] = 2;//RIEMPITO CON 0 CHE SARA' O
                    k++;
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("+---+---+---+");
            Console.WriteLine($"|{tris[fill[0]]}  | {tris[fill[1]]}  | {tris[fill[2]]}|");
            Console.WriteLine("+---+---+---+");
            Console.WriteLine($"|{tris[fill[3]]}  | {tris[fill[4]]}  | {tris[fill[5]]}|");
            Console.WriteLine("+---+---+---+");
            Console.WriteLine($"|{tris[fill[6]]}  | {tris[fill[7]]}  | {tris[fill[8]]}|");
            Console.WriteLine("+---+---+---+");
            Console.ForegroundColor = ConsoleColor.White;

        }
    }
}
