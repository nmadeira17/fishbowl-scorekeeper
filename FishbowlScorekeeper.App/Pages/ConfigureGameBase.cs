using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using FishbowlScorekeeper.App.Components;
using FishbowlScorekeeper.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace FishbowlScorekeeper.App.Pages
{
	public class ConfigureGameBase : ComponentBase
	{
		[Inject]
		private IJSRuntime m_jsRuntime { get; set; }

		[Inject]
		private IGameConfig m_gameConfig { get; set; }

		[Inject]
		private NavigationManager m_navigationManager { get; set; }

		protected override Task OnInitializedAsync()
		{
			for (int i = 0; i < TeamNames.Length; i++)
				TeamNames[i] = "";

			for (int i = 0; i < RoundNames.Length; i++)
			{
				if (i == 0) RoundNames[i] = "Catch Phrase";
				else if (i == 1) RoundNames[i] = "Charades";
				else if (i == 2) RoundNames[i] = "One Word";
				else RoundNames[i] = "";
			}

			for (int i = 0; i < RoundDurations.Length; i++)
				RoundDurations[i] = Common.DEFAULT_ROUND_DURATION;

			return base.OnInitializedAsync();
		}

		// Number of Teams
		public int NumTeams { get; set; } = Common.DEFAULT_NUM_TEAMS;
		protected void OnNumTeamsChangedCallback(ChangeEventArgs e)
		{
			NumTeams = Convert.ToInt32(e.Value);
		}

		// Team Names
		public string[] TeamNames = new string[Common.MAX_TEAMS];
		protected void OnNameChangedCallback(ConfigTeamEntryBase e)
		{
			TeamNames[e.ITeam] = e.Name;
		}

		// Number of Rounds
		public int NumRounds { get; set; } = Common.DEFAULT_NUM_ROUNDS;
		protected void OnNumRoundsChangedCallback(ChangeEventArgs e)
		{
			NumRounds = Convert.ToInt32(e.Value);
		}

		// Name/Duration of Rounds
		public string[] RoundNames = new string[Common.MAX_ROUNDS];
		public int[] RoundDurations = new int[Common.MAX_ROUNDS];
		protected void OnRoundChangedCallback(ConfigRoundEntryBase e)
		{
			RoundNames[e.IRound] = e.Name;
			RoundDurations[e.IRound] = e.Duration;
		}

		// Start Game
		protected void OnStartGameClick(MouseEventArgs e)
		{
			string errorMessage = "";
			if (!IsInputValid(out errorMessage))
			{
				m_jsRuntime.InvokeVoidAsync("alert", "Error!\n" + errorMessage.ToString());
				return;
			}

			IList<Team> teams = new List<Team>();
			for (int i = 0; i < NumTeams; i++)
				teams.Add(new Team(TeamNames[i]));

			IList<Round> rounds = new List<Round>();
			for (int i = 0; i < NumRounds; i++)
				rounds.Add(new Round(RoundNames[i], RoundDurations[i]));

			m_gameConfig.Init(teams, rounds);

			m_navigationManager.NavigateTo("playgame");
		}

		private bool IsInputValid(out string errorMessage)
		{
			// Team Names
			for (int i = 0; i < NumTeams; i++)
			{
				if (TeamNames[i].Length == 0)
				{
					errorMessage = String.Format("Team {0} must have a name.", i + 1);
					return false;
				}

				for (int j = i; j < NumTeams; j++)
				{
					if (TeamNames[i] == TeamNames[j] && i != j)
					{
						errorMessage = String.Format("Team {0} and Team {1} have the same name.", i+1, j+1);
						return false;
					}
				}
			}

			// Rounds
			for (int i = 0; i < NumRounds; i++)
			{
				if (RoundNames[i].Length == 0)
				{
					errorMessage = String.Format("Round {0} must have a name.", i + 1);
					return false;
				}

				if (RoundDurations[i] <= 0)
				{
					errorMessage = String.Format("Round {0} must have a valid time.", i + 1);
					return false;
				}

				for (int j = i; j < NumRounds; j++)
				{
					if (RoundNames[i] == RoundNames[j] && i != j)
					{
						errorMessage = String.Format("Round {0} and Round {1} have the same name.", i + 1, j + 1);
						return false;
					}
				}
			}

			errorMessage = "";
			return true;
		}
	}
}
