using SnakeGame;
using System.Numerics;

var startPos = Vector2.One;
GameBoard gameBoard = new GameBoard(25,25);

var snake1 = new Snake(startPos,10, Direction.DOWN);
gameBoard.addSnake(snake1);

var tickRate = TimeSpan.FromMilliseconds(100);

//await Task.Delay(2000);

Console.WriteLine("Press ESC to stop");
await GameLoop();


async Task UpdateLoop()
{
    gameBoard.updateSnakes();
    gameBoard.printGameBoard();
    await Task.Delay(tickRate);
}

async Task GameLoop()
{
    do
    {
        while (!Console.KeyAvailable)
        {
            if (gameBoard.isGameOver()) { break; }
            await UpdateLoop();
            if (Console.KeyAvailable)
            {
                snake1.moveSnake(Console.ReadKey().Key);
            }
        }
    } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
}