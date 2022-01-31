namespace TicTacToe;
public class Response
{
    public Game Game { get; set; }
}


public class Game
{
    public Human Player { get; set; }
    public Computer Computer { get; set; }
    public Shift Shift { get; set; }
    public string Winner { get; set; }
}

public abstract class Player
{
    public string Name { get; set; }
    public Shift Shift { get; set; }
}
public class Computer
{
    public bool Easy { get; set; }
    public bool Intermediate { get; set; }
    public bool Hard { get; set; }
}
public class Human
{

}

public enum Shift
{
    X,
    O,
}

public class Board
{
    public int[,] Matrix { get; set; }
    public int[] IndexToPlay { get; set; }
}