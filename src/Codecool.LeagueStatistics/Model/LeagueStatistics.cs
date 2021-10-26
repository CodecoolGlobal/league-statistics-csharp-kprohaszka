using System;
using System.Collections.Generic;
using System.Linq;

namespace Codecool.LeagueStatistics.Model
{
    public static class LeagueStatistics
    {
        public static IEnumerable<Team> GetAllTeamsSorted(this IEnumerable<Team> teams)
            => from team in teams
               orderby team.CurrentPoints descending, (team.Players.Sum(player => player.Goals)) descending
               select team;

        public static IEnumerable<Team> GetAllTeamsSortedMethodLikeLINQAlternative(this IEnumerable<Team> teams)
            => teams.OrderByDescending(team => team.CurrentPoints).ThenByDescending(team => (team.Players.Sum(player => player.Goals)));



        public static IEnumerable<Player> GetAllPlayers(this IEnumerable<Team> teams)
            => from team in teams
               from player in team.Players
               select player;

        public static IEnumerable<Player> GetAllPlayersMethodLikeLINQAlternative(this IEnumerable<Team> teams)
            => teams.SelectMany(team => team.Players).ToList();



        public static Team GetTeamWithTheLongestName(this IEnumerable<Team> teams)
            => (from team in teams
                orderby team.Name.Length descending
                select team).First();

        public static Team GetTeamWithTheLongestNameMethodLikeLINQAlternative(this IEnumerable<Team> teams)
            => teams.OrderByDescending(team => team.Name).First();



        public static IEnumerable<Team> GetTopTeamsWithLeastLoses(this IEnumerable<Team> teams, int teamsNumber)
            => (from team in teams
                orderby team.Losts ascending, team.CurrentPoints descending
                select team).Take(teamsNumber);

        public static IEnumerable<Team> GetTopTeamsWithLeastLosesMethodLikeLINQAlternative(this IEnumerable<Team> teams, int teamsNumber)
            => teams.OrderBy(team => team.Losts).ThenByDescending(team => team.CurrentPoints).Take(teamsNumber);



        public static IEnumerable<Player> GetTopPlayersFromEachTeam(this IEnumerable<Team> teams)
            => from team in teams
               select (from player in team.Players
                       orderby player.Goals descending
                       select player).First();

        public static IEnumerable<Player> GetTopPlayersFromEachTeamMethodLikeLINQAlternative(this IEnumerable<Team> teams)
            => teams.Select(team => team.Players.OrderByDescending(player => player.Goals).First());



        public static Division GetStrongestDivision(this IEnumerable<Team> teams)
            => (from team in teams
                orderby team.CurrentPoints descending, team.Wins descending
                select team.Division).First();

        public static Division GetStrongestDivisionMethodLikeLINQAlternative(this IEnumerable<Team> teams)
            => teams.OrderByDescending(team => team.CurrentPoints).ThenByDescending(team => team.Wins).Select(team => team.Division).First();



        public static IEnumerable<Team> GetTeamsWithPlayersWithoutGoals(this IEnumerable<Team> teams)
            => from team in teams
               from player in team.Players
               where player.Goals is 0
               select team;

        public static IEnumerable<Team> GetTeamsWithPlayersWithoutGoalsMethodLikeLINQAlternative(this IEnumerable<Team> teams)
            => teams.Where(team => team.Players.Any(player => player.Goals == 0));



        public static IEnumerable<Player> GetPlayersWithAtLeastXGoals(this IEnumerable<Team> teams, int goals)
            => from team in teams
               from player in team.Players
               where player.Goals >= goals
               select player;

        public static IEnumerable<Player> GetPlayersWithAtLeastXGoalsMethodLikeLINQAlternative(this IEnumerable<Team> teams, int goals)
            => teams.SelectMany(team => team.Players.Where(player => player.Goals >= goals));



        public static Player GetMostTalentedPlayerInDivision(this IEnumerable<Team> teams, Division division)
            => (from player in
               (from team in teams
                from player in team.Players
                where team.Division == division
                select player)
                orderby player.SkillRate descending
                select player).First();

        public static Player GetMostTalentedPlayerInDivisionMethodLikeLINQAlternative(this IEnumerable<Team> teams, Division division)
            => teams.Where(team => team.Division == division).SelectMany(team => team.Players).OrderByDescending(player => player.SkillRate).First();
    }
}
