using TicTacToe;

namespace TicTacToeClass;
public static class Extensions
{
    public static Human PlayerAsHuman(this PlayerRequest registerPlayers)
    {
        return new Human()
        {
            StartFirst = registerPlayers.StartFirst,
            Name = registerPlayers.Name,
            Email = registerPlayers.Email,
            Difficulty = registerPlayers.Difficulty.ToUpper(),
            IsComputer = registerPlayers.IsComputer,
        };
    }

    public static Computer PlayerAsComputer(this PlayerRequest computerRequest)
    {
        Computer computer = new()
        {
            Name = computerRequest.Name,
            StartFirst = computerRequest.StartFirst,
            IsComputer = computerRequest.IsComputer,
            Difficulty = computerRequest.Difficulty.ToUpper(),
        };
        if (computer.Difficulty == Difficulty.Easy.ToString().ToUpper())
        {
            computer.Easy = true;
        }
        if (computer.Difficulty == Difficulty.Intermediate.ToString().ToUpper())
        {
            computer.Intermediate = true;
        }
        if (computer.Difficulty == Difficulty.Hard.ToString().ToUpper())
        {
            computer.Hard = true;
        }
        return computer;
    }
}

