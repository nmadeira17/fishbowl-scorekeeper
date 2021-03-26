using System;
using System.Threading.Tasks;

using FishbowlScorekeeper.App.Components;
using FishbowlScorekeeper.Shared;
using Microsoft.AspNetCore.Components;


namespace FishbowlScorekeeper.App.Pages
{
	public class ConfigureGameBase : ComponentBase
	{
		protected override Task OnInitializedAsync()
		{
			for (int i = 0; i < TeamNames.Length; i++)
				TeamNames[i] = "";

			for (int i = 0; i < RoundNames.Length; i++)
				RoundNames[i] = "";

			for (int i = 0; i < RoundDurations.Length; i++)
				RoundDurations[i] = 0;

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
	}
}
