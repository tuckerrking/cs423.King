using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace assignment02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }


    class TurtleProgram
    {
        static int[,] floorGrid; // 2D array to represent the floor grid
        static int turtleX, turtleY; // Current position of the turtle
        static bool isPenDown; // Flag to track pen state (up or down)

        static void Main(string[] args)
        {
            InitializeFloorGrid(); // Initialize the floor grid

            while (true)
            {
                Console.WriteLine("Enter command (1-9): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int command))
                {
                    ExecuteCommand(command);
                }
                else
                {
                    Console.WriteLine("Invalid command. Please enter a valid command (1-9).");
                }
            }
        }

        static void InitializeFloorGrid(int gridSize = 50)
        {
            floorGrid = new int[gridSize, gridSize];
            turtleX = 0;
            turtleY = 0;
            isPenDown = false;
        }

        static void ExecuteCommand(int command)
        {
            switch (command)
            {
                case 1:
                    isPenDown = false; // Pen Up
                    break;
                case 2:
                    isPenDown = true; // Pen Down
                    break;
                case 3:
                    // Turn Right (clockwise)
                    // Implement the logic to change the turtle's direction
                    break;
                case 4:
                    // Turn Left (counterclockwise)
                    // Implement the logic to change the turtle's direction
                    break;
                case 5:
                    // Move Forward by x spaces
                    // Implement the logic to move the turtle and update the floor grid
                    break;
                case 6:
                    ClearFloorGrid(); // Clear the grid
                    break;
                case 9:
                    Environment.Exit(0); // Terminate program
                    break;
                default:
                    Console.WriteLine("Invalid command. Please enter a valid command (1-9).");
                    break;
            }
        }

        static void ClearFloorGrid()
        {
            for (int i = 0; i < floorGrid.GetLength(0); i++)
            {
                for (int j = 0; j < floorGrid.GetLength(1); j++)
                {
                    floorGrid[i, j] = 0;
                }
            }
        }

        static void DisplayFloorGrid()
        {
            for (int i = floorGrid.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = 0; j < floorGrid.GetLength(1); j++)
                {
                    char tileChar = floorGrid[i, j] == 1 ? '*' : ' ';
                    Console.Write(tileChar);
                }
                Console.WriteLine();
            }
        }
    }
}
