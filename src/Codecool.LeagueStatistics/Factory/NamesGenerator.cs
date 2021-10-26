using System.IO;

namespace Codecool.LeagueStatistics.Facotry
{
    /// <summary>
    ///     Provides random names for Players and Teams
    /// </summary>
    public static class NamesGenerator
    {

        public static string pathPlayerNames = @"C:\My User Files\Codecool\Projects\Advanced Module\Week 2\league-statistics-csharp-kprohaszka\data\PlayerNames.txt";
        public static string pathTeamNames = @"C:\My User Files\Codecool\Projects\Advanced Module\Week 2\league-statistics-csharp-kprohaszka\data\TeamNames.txt";
        public static string pathCityNames = @"C:\My User Files\Codecool\Projects\Advanced Module\Week 2\league-statistics-csharp-kprohaszka\data\CityNames.txt";
        public static string GetPlayerName()
        {
            return File.ReadAllLines(pathPlayerNames).GetRandomValue();
        }

        public static string GetTeamName()
        {
            var cities = File.ReadAllLines(pathCityNames);
            var names = File.ReadAllLines(pathTeamNames);

            return cities.GetRandomValue() + " " + names.GetRandomValue();
        }
    }
}
