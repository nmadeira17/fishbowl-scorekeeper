using System;
using System.Collections.Generic;

namespace FishbowlScorekeeper.Shared
{
	public class GameConfig
	{
		public IList<Team> Teams { get; private set; }
		public IList<Round> Rounds { get; private set; }

		public GameConfig(IList<Team> teams, IList<Round> rounds)
		{
			Teams = teams;
			Rounds = rounds;
		}
	}

	public class Team
	{
		/// <summary>
		/// The name of the team.
		/// </summary>
		public string Name { get; set; }
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
	}
}
