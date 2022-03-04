using Data.Infrastructure.Data._Entities;
using Data.Infrastructure.Data.Game.Player;
using Data.Infrastructure.Infrastructure.Api.InitializeGame;

namespace _01.Game.Initialize.Infrastructure;
public static class Extensions
{
    public static GameEntity SetGameEntity(this InitializeGameRecord x, Guid gameId)
    {
        return new GameEntity
            (
                _gameId: gameId,
                player1_Name: x.Player1_Name,
                player2_Name: x.VsComputer.IsComputer == false ? x.VsHuman.PlayerName_2 : Computer.Name,
                isComputer: x.VsComputer.IsComputer,
                difficulty: x.VsComputer.Difficulty,
                startFirst: x.StartFirst
            );
    }

    public static InitializeGameRequest SetInitializeGameRequest(this InitializeGameRecord x)
    {
        return new InitializeGameRequest
            (
                getGameOptions: x.GameOptions,
                playerName_1: x.Player1_Name,
                startFirst: x.StartFirst,
                vsComputer: x.VsComputer,
                vsHuman: x.VsHuman
            );
    }
}
