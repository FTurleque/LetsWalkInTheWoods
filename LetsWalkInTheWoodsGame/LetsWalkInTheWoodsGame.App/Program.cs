// See https://aka.ms/new-console-template for more information

using LetsWalkInTheWoodsGame.Class;

Map map = new Map();
Console.WriteLine("Taper sur ESC ou x pour sortir du jeu.\nVeuillez entrer les coordonées de départ du personnage (x,y) separé par un espace :");
Character hero = new Character(3, 0);
CharacterMovement move = new CharacterMovement(hero);
bool gameRun = true;
Console.CursorVisible = false;
ConsoleKeyInfo keyinfo;
do
{
    Console.Clear();
    foreach (string row in Map.Mapping)
    {
        Console.WriteLine(row);
    }
    keyinfo = Console.ReadKey();
    if (keyinfo.Key == ConsoleKey.Escape)
    {
        Environment.Exit(0);
    }
    if (keyinfo.Key == ConsoleKey.UpArrow)
    {
        move.CharacterMoving('N');
    }
    if (keyinfo.Key == ConsoleKey.DownArrow)
    {
        move.CharacterMoving('S');
    }
    if (keyinfo.Key == ConsoleKey.LeftArrow)
    {
        move.CharacterMoving('O');
    }
    if (keyinfo.Key == ConsoleKey.RightArrow)
    {
        move.CharacterMoving('E');
    }
    if (keyinfo.Key == ConsoleKey.X)
    {
        gameRun = false;
    }
}
while (gameRun);

/*Console.SetCursorPosition(0, 0);
Console.Write("################################");
for (int row = 1; row < 10; row++)
{
    Console.SetCursorPosition(0, row);
    Console.Write("#                              #");
}
Console.SetCursorPosition(0, 10);
Console.Write("################################");

int data = 1;
System.Diagnostics.Stopwatch clock = new System.Diagnostics.Stopwatch();
clock.Start();
while (true)
{
    data++;
    Console.SetCursorPosition(1, 2);
    Console.Write("Current Value: " + data.ToString());
    Console.SetCursorPosition(1, 3);
    Console.Write("Running Time: " + clock.Elapsed.TotalSeconds.ToString());
    Thread.Sleep(1000);
}*/