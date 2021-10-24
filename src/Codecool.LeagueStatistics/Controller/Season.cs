using System;
using System.Collections.Generic;
using Codecool.LeagueStatistics.Factory;
using Codecool.LeagueStatistics.Model;

namespace Codecool.LeagueStatistics.Controllers
{
    /// <summary>
    ///     Provides all necessary methods for season simulation
    /// </summary>
    public class Season
    {
        public List<Team> League { get; set; }
        private readonly int MaxSkill = 100;

        public Season()
        {
            League = new List<Team>();
        }

        /// <summary>
        ///     Fills league with new teams and simulates all games in season.
        /// After all games played calls table to be displayed.
        /// </summary>
        public void Run()
        {
            var league = LeagueFactory.CreateLeague(6);
            foreach (var team in league)
            {
                League.Add(team);
            }
            PlayAllGames();

            // Call Display methods here
        }
        /// <summary>
        ///     Playing one round. Everyone with everyone one time.
        /// </summary>
        public void PlayAllGames()
        {
            foreach (var team in League)
            {
                foreach (var opponent in League)
                {
                    if(team != opponent)
                    {
                        PlayMatch(team, opponent);
                    }
                }
            }
        }
        /// <summary>
        ///     Plays single game between two teams and displays result after.
        /// </summary>
        public void PlayMatch(Team team1, Team team2)
        {
            int whichTeamWon = Utils.Random.Next(3);
            if(whichTeamWon == 1)
            {
            team1.Wins++;
            team2.Losts++;
            } else if (whichTeamWon == 2) {
            team2.Wins++;
            team1.Losts++;
            } else if (whichTeamWon == 3)
            {
            team1.Draws++;
            team2.Draws++;
            }
        }

        /// <summary>
        ///     Checks for each player of given team chanse to score based on skillrate.
        ///     Adds scored golas to player's and team's statistics.
        /// </summary>
        /// <param name="team">team</param>
        /// <returns>All goals scored by the team in current game</returns>
        public int ScoredGoals(Team team)
        {
            int randomGoalChanceByStats = Utils.Random.Next(MaxSkill);
            int goalsScoredInCurrentGame = 0;

            foreach (var player in team.Players)
            {
                if(player.SkillRate > randomGoalChanceByStats)
                {
                    player.Goals++;
                    goalsScoredInCurrentGame++;
                }
            }
            return goalsScoredInCurrentGame;
        }
    }
}
