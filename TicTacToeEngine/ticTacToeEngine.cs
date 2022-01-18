using System;
using System.Collections;

namespace TicTacToeEngine
{

    public enum GameState { PlayerOPlays, PlayerXPlays, Equal, PlayerOWins, PlayerXWins }
    public class TicTacToeEngine
    {
        public GameState Gamestate { get; private set; } = GameState.PlayerOPlays;
        public ArrayList BoardState { get; set; } = new ArrayList() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        private int turn = 0;

        public String Board()
        {
            String consoleBoard = @"                Gamestate = " + Gamestate.ToString() + @"
                |" + BoardState[0] + @"|" + BoardState[1] + @"|" + BoardState[2] + @"|
                |" + BoardState[3] + @"|" + BoardState[4] + @"|" + BoardState[5] + @"|
                |" + BoardState[6] + @"|" + BoardState[7] + @"|" + BoardState[8] + @"|
                - Type a number between 1-9 to pick a Cell
                - reset = Reset game
                - quit = exit program";
            return consoleBoard;
        }

        public void ChangePlayer()
        {
            if (Gamestate == GameState.PlayerOPlays)
            {
                Gamestate = GameState.PlayerXPlays;
            }
            else if (Gamestate == GameState.PlayerXPlays)
            {
                Gamestate = GameState.PlayerOPlays;
            }
        }

        public bool ChooseCell(int cell)
        {
            return BoardState.Contains(cell);
        }

        public string AssignCell(int cell)
        {
            string player = null;
            if (Gamestate == GameState.PlayerOPlays)
            {
                player = "O";
                BoardState[BoardState.IndexOf(cell)] = player;
            }
            else if (Gamestate == GameState.PlayerXPlays)
            {
                player = "X";
                BoardState[BoardState.IndexOf(cell)] = player;
            }
            return player;
        }

        public bool CheckWinner()
        {
            turn++;
            if (DecideWinner(0, 1, 2) || DecideWinner(3, 4, 5) || DecideWinner(6, 7, 8) || DecideWinner(0, 4, 8) ||
                DecideWinner(2, 4, 6) || DecideWinner(0, 3, 6) || DecideWinner(1, 4, 7) || DecideWinner(2, 5, 8))
            {
                SetWinner();
                return true;
            }
            else if (turn == 9)
            {
                Gamestate = GameState.Equal;
                return true;
            }
            else
            {
                ChangePlayer();
                return false;
            }
        }

        public bool DecideWinner(int a, int b, int c)
        {
            return BoardState[a] == BoardState[b] && BoardState[a] == BoardState[c];
        }

        public void SetWinner()
        {
            if (Gamestate == GameState.PlayerOPlays)
            {
                Gamestate = GameState.PlayerOWins;
            }
            else if (Gamestate == GameState.PlayerXPlays)
            {
                Gamestate = GameState.PlayerXWins;
            }
        }

        public void Reset()
        {
            turn = 0;
            BoardState = new ArrayList() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Gamestate = GameState.PlayerOPlays;
        }

    }
}
