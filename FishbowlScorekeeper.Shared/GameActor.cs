using System;
using System.Collections.Generic;
using System.Text;

namespace FishbowlScorekeeper.Shared
{
	public interface IGameActor
	{
		void Init(IGameConfig gameConfig);

		IGameConfig Config { get; }
		IGameScore Score { get; }
	}

	public class GameActor : IGameActor
	{
		public IGameConfig Config { get; private set; }
		public IGameScore Score { get; private set; }

		public void Init(IGameConfig gameConfig)
		{
			Config = gameConfig;
			Score = new GameScore(Config.Teams.Count, Config.Rounds.Count);
		}
	}

	public interface IGameScore
	{
		void SetScore(int team, int round, int score);
		int GetScore(int team, int round);
		int GetTeamTotal(int team);
	}

	public class GameScore : IGameScore
	{
		private int[,] m_score;

		public GameScore(int numTeams, int numRounds)
		{
			m_score = new int[numTeams, numRounds];
		}

		public void SetScore(int team, int round, int score)
		{
			m_score[team, round] = score;
		}

		public int GetScore(int team, int round)
		{
			return m_score[team, round];
		}

		public int GetTeamTotal(int team)
		{
			int sum = 0;

			for (int i = 0; i < m_score.GetLength(team); i++)
				sum += m_score[team, i];

			return sum;
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			for (int i = 0; i < m_score.GetLength(0); i++)
			{
				for (int j = 0; j < m_score.GetLength(1); j++)
				{
					sb.Append(m_score[i, j] + " | ");
				}

				sb.AppendLine();
			}

			return sb.ToString();
		}
	}

}
