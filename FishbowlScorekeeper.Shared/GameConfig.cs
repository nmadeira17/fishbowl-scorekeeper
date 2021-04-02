using System;
using System.Collections.Generic;
using System.Text;

namespace FishbowlScorekeeper.Shared
{
	public interface IGameConfig
	{
		IList<Team> Teams { get; }
		IList<Round> Rounds { get; }

		void Init(IList<Team> teams, IList<Round> rounds);
	}

	public class GameConfig : IGameConfig
	{
		public IList<Team> Teams { get; private set; }
		public IList<Round> Rounds { get; private set; }

		public GameConfig()
		{
			Teams = new List<Team>();
			Rounds = new List<Round>();
		}

		public void Init(IList<Team> teams, IList<Round> rounds)
		{
			Teams = teams;
			Rounds = rounds;
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine("Teams");
			foreach (Team team in Teams)
				sb.AppendLine(team.ToString());

			sb.AppendLine("Rounds");
			foreach (Round round in Rounds)
				sb.AppendLine(round.ToString());

			return sb.ToString();
		}
	}

	public class Team
	{
		/// <summary>
		/// The name of the team.
		/// </summary>
		public string Name { get; set; }

		public Team(string name)
		{
			Name = name;
		}

		public override string ToString()
		{
			return String.Format("Team: {0}", Name);
		}
	}

	public class Round
	{
		/// <summary>
		/// The name of the round
		/// Ex: "Catch Phrase", "Charades", etc...
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// The time limit of the round in seconds
		/// </summary>
		public int TimeLimit { get; set; }

		public Round(string name, int timeLimit)
		{
			Name = name;
			TimeLimit = timeLimit;
		}

		public override string ToString()
		{
			return String.Format("Round: {0}, Time Limit: {1}", Name, TimeLimit);
		}
	}
}
