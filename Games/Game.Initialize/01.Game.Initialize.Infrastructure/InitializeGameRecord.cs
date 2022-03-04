using Data.Infrastructure.Data.Game;
using Data.Infrastructure.Data.Game.Player;

namespace _01.Game.Initialize.Infrastructure;

public record InitializeGameRecord
    (
         GameOptions GameOptions,
         string Player1_Name,
         string StartFirst,
         VsComputer VsComputer,
         VsHuman VsHuman
    );