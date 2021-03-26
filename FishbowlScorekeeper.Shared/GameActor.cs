using System;
using System.Collections.Generic;
using System.Text;

namespace FishbowlScorekeeper.Shared
{
	public class GameActor
	{
		private GameConfig m_gameConfig;
		
		private int m_iCurrentRound;
		private int m_iCurrentTeam;

		public GameActor(GameConfig gameConfig)
		{
			m_gameConfig = gameConfig;
		}

		/* Accessors */
		public string GetCurrentRoundName()
		{
			return m_gameConfig.Rounds[m_iCurrentRound].Name;
		}

		public string GetCurrentTeamName()
		{
			return m_gameConfig.Teams[ICurrentTeam()].Name;
		}

		/* Game Management */
		public void OnTurnOver(int score)
		{
			// set score
			m_iCurrentTeam++;
		}

		public void OnRoundOver()
		{
			m_iCurrentRound++;
		}

		private int ICurrentTeam()
		{
			return m_iCurrentTeam % m_gameConfig.Teams.Count;
		}
	}

	public class GameScore
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
