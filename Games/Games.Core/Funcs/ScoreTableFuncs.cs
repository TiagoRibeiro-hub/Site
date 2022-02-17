namespace Games.Core.Funcs;
internal class ScoreTableFuncs
{
    private readonly IReadRepository _readRepository;
    private readonly IRepository _repository;
    public ScoreTableFuncs(IReadRepository readRepository, IRepository repository)
    {
        _readRepository = readRepository;
        _repository = repository;
    }
    internal async Task UpdateScoreTableTotalGamesAsync(GameEntity game, int scoreTableId, string playerName)
    {
        if (game.IsComputer)
        {
            if (game.Difficulty.ToLower() == Difficulty.Easy.ToString().ToLower())
            {
                var vsComputerEasy = await _readRepository.FindAsync<TotalGamesEasyEntity>(scoreTableId);
                _ = game.StartFirst == playerName ? vsComputerEasy.StartFirst += 1 : vsComputerEasy.StartSecond += 1;
                vsComputerEasy.TotalGames += 1;
                await _repository.UpdateAsync(vsComputerEasy);
            }
            if (game.Difficulty.ToLower() == Difficulty.Intermediate.ToString().ToLower())
            {
                var vsComputerIntermediate = await _readRepository.FindAsync<TotalGamesIntermediateEntity>(scoreTableId);
                _ = game.StartFirst == playerName ? vsComputerIntermediate.StartFirst += 1 : vsComputerIntermediate.StartSecond += 1;
                vsComputerIntermediate.TotalGames += 1;
                await _repository.UpdateAsync(vsComputerIntermediate);
            }
            if (game.Difficulty.ToLower() == Difficulty.Hard.ToString().ToLower())
            {
                var vsComputerHard = await _readRepository.FindAsync<TotalGamesHardEntity>(scoreTableId);
                _ = game.StartFirst == playerName ? vsComputerHard.StartFirst += 1 : vsComputerHard.StartSecond += 1;
                vsComputerHard.TotalGames += 1;
                await _repository.UpdateAsync(vsComputerHard);
            }
        }
        else
        {
            var vsHumanModel = await _readRepository.FindAsync<TotalGamesVsHumanEntity>(scoreTableId);
            _ = game.StartFirst == playerName ? vsHumanModel.StartFirst += 1 : vsHumanModel.StartSecond += 1;
            await _repository.UpdateAsync(vsHumanModel);
        }
    }
}
