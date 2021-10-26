using Codecool.LeagueStatistics.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Codecool.LeagueStatistics.View
{
    /// <summary>
    /// Provides console view for league table, results and all League statistics
    /// </summary>
    public static class Display
    {

        public static void displayResultsAfterSingleMatch(Team team1, Team team2)
        {
            Console.WriteLine(String.Format("|{0,5}|{1,5}|{2,5}|{3,5}|{4,5}|{5,5}", "Team Name", "Points", "Goals", "Wins", "Draws", "Losses"));

            Console.WriteLine(String.Format("|{0,5}|{1,5}|{2,5}|{3,5}|{4,5}|{5,5}", team1.Name,
                    team1.CurrentPoints, team1.Players.Sum(player => player.Goals), team1.Wins, team1.Draws, team1.Losts));

            Console.WriteLine(String.Format("|{0,5}|{1,5}|{2,5}|{3,5}|{4,5}|{5,5}", team2.Name,
                    team2.CurrentPoints, team2.Players.Sum(player => player.Goals), team2.Wins, team2.Draws, team2.Losts));
        }

        public static void DisplayLeagueResults(List<Team> league)
        {
            Console.WriteLine(String.Format("|{0,5}|{1,5}|{2,5}|{3,5}|{4,5}|{5,5}", "Team Name", "Points", "Goals", "Wins", "Draws", "Losses"));
            foreach (var team in league)
            {

                Console.WriteLine(String.Format("|{0,5}|{1,5}|{2,5}|{3,5}|{4,5}|{5,5}", team.Name,
                    team.CurrentPoints, team.Players.Sum(player => player.Goals), team.Wins, team.Draws, team.Losts));
            }
        }
    }
}
