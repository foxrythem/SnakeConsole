
using System.Numerics;

namespace SnakeGame
{
    public class GameBoard
    {
        public GameBoard(int boardWidth, int boardHeight)
        {
            this.boardWidth = boardWidth;
            this.boardHeight = boardHeight;

            gameBoard = new String[boardWidth, boardHeight];

            var spotnumber = 0;

            for (int row = 0; row < rowLength; row++)
            {
                for (int column = 0; column < columnLength; column++)
                {
                    // Used to debug the game board
                    // gameBoard[row, column] = "0";
                    
                    // Sets the spots in the board to blank
                    gameBoard[row, column] = " ";
                    spotnumber++;
                }
            }
        }

        public void printGameBoard()
        {

            // Top Wall
            for (int column = 0; column <= columnLength + 1; column++)
            {
                Console.SetCursorPosition(column,0);
                Console.Write("═");
            }

            Console.WriteLine();    

            // Guts of the board
            for (int row = 0; row < rowLength; row++)
            {
                for(int column = 0; column < columnLength; column++)
                {

                    var printout = "";

                    if (column == 0)
                    {
                        printout += "║";
                    }

                    printout += gameBoard[row, column].ToString();

                    if(column + 1 == columnLength)
                    {
                        printout += "║";
                    }
                    //Console.SetCursorPosition(row, column);
                    Console.Write(printout);
                }
                Console.WriteLine();
            }

            // Bottom Wall
            for (int column = 0; column <= columnLength + 1; column++)
            {
                Console.SetCursorPosition(column, rowLength);
                Console.Write("═");
            }

            Console.WriteLine();
        }

        public void updateSnakes()
        {
            foreach (Snake snakeObject in snakes)
            {
                snakeObject.Update();
                if (isGameOver())
                {
                    break;
                }
                else
                {
                    foreach (var snakeItem in snakeObject.getSnakePieces)
                    {
                        var snakePosistion = snakeItem.posistion;
                        var snakePreviousPosistion = snakeItem.prevousPosistion;

                        gameBoard[(int)snakePosistion.X, (int)snakePosistion.Y] = snakeItem.icon;
                        gameBoard[(int)snakePreviousPosistion.X, (int)snakePreviousPosistion.Y] = " ";
                    }
                }
            }
        }

        /// <summary>
        /// Check to see if the snake head went out of bounds
        /// </summary>
        /// <param name="snakeHead"></param>
        /// <returns></returns>
        public bool isGameOver()
        {

            foreach (var snake in snakes)
            {
                var snakeHead = snake.getCurrenctSnakeHead();

                var snakePosistion = snakeHead.posistion;

                if (snakePosistion.X >= 0 && snakePosistion.Y >= 0)
                {
                    if (snakePosistion.X < rowLength && snakePosistion.Y < columnLength)
                    {
                        // Check to See if the snake hit its tail
                        foreach (var snakePiece in snake.getSnakePieces)
                        {
                            if (snakePiece.posistion != snakeHead.posistion) return false;
                        }
                    }
                }


            }
            Console.Clear();
            Console.WriteLine("GAME OVER SNAKE CRASHED");
            return true;
        }

        public void addSnake(Snake snake)
        {
            snakes.Add(snake);
        }

        int rowLength => gameBoard.GetLength(0);
        int columnLength => gameBoard.GetLength(1);

        List<Snake> snakes = new List<Snake>();
        string[,] gameBoard;
        int boardWidth = 0;
        int boardHeight = 0;
    }
}
