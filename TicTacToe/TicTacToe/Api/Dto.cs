namespace TicTacToe;
#nullable disable
public static class Dto
{
    public static HumanShared AsDto(this Human x)
    {
        return new HumanShared
        {
            Name = x.Name,
            ListPlayedMoves = x.ListPlayedMoves,
        };
    }

    public static ComputerShared AsDto(this Computer x)
    {
        return new ComputerShared
        {
            Name = x.Name,
            Active = x.Active,
            Difficulty = x.Difficulty,
            ListPlayedMoves = x.ListPlayedMoves,
        };
    }

    public static WinnerShared AsDto(this WinnerShared x)
    {
        return new WinnerShared
        {
            Name = x.Name,
            HaveWinner = x.HaveWinner,
        };
    }

    public static GameShared AsDto(this GameShared x)
    {
        return new GameShared
        {
            Player = x.Player,
            Computer = x.Computer,
            Shift = x.Shift,
            Winner = x.Winner,
        };
    }
}
