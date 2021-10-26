using Codecool.LeagueStatistics.Model;
using System;
using System.Collections.Generic;

namespace Codecool.LeagueStatistics.Factory
{
    public static class LeagueFactory
    {
        public static IEnumerable<Team> CreateLeague(int teamsInDivision)
        {
            List<Team> league = new List<Team>();
            for (int i = 0; i < teamsInDivision; i++)
            {
                Array enumValues = Enum.GetValues(typeof(Division));
                Division randomDivision = (Division)enumValues.GetValue(Utils.Random.Next(enumValues.Length));

                Team newTeam = new Team(randomDivision, GetPlayers(Utils.TeamSize));

                league.Add(newTeam);
            }
            return league;
        }

        private static IEnumerable<Player> GetPlayers(int amount)
        {
            List<Player> playerList = new List<Player>();
            for (int i = 0; i < amount; i++)
            {
                playerList.Add(new Player(Utils.Random.Next(PlayerSkillRate)));
            }
            return playerList;
        }

        private static int PlayerSkillRate => Utils.Random.Next(5, 21);
    }
}
