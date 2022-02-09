namespace TicTacToe;
public static class MinimaxFuncs
{
    public static void ChangeTurn(HashSet<int> possibleMoves, MinimaxMoves human, MinimaxMoves computer)
    {
        computer.Turn = possibleMoves.Count() % 2 == 0 ? Turn.Player2 : Turn.Player1;
        human.Turn = computer.Turn == Turn.Player1 ? Turn.Player2 : Turn.Player1;
    }
    public static HashSet<int> CopyPossibleMoves(this HashSet<int> possibleMoves)
    {
       return possibleMoves;
    }
    public static (HashSet<int>, HashSet<int>) GetPlayedMoves(IEnumerable<dynamic> list, string computerName)
    {
        HashSet<int> resultHuman = new();
        HashSet<int> resultComputer = new();

        foreach (dynamic item in list)
        {
            if(item.PlayerName != computerName)
            {
                resultHuman.Add(int.Parse(item.MoveTo));
            }
            else
            {
                resultComputer.Add(int.Parse(item.MoveTo));
            }           
        }
        return (
            resultHuman.GetListPlayedMoves(), 
            resultComputer.GetListPlayedMoves());
    }
    public static HashSet<int> GetListPlayedMoves(this HashSet<int> list)
    {
        return list.Select(x => x).Where(x => x > 0).ToHashSet();
    }
}
