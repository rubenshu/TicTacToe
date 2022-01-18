using System;
using System.Windows.Forms;

namespace TicTacToeGUI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new GUI());
        }
    }
}