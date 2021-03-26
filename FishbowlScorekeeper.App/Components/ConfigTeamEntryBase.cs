using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishbowlScorekeeper.App.Components
{
	public class ConfigTeamEntryBase : ComponentBase
	{
		[Parameter]
		public int ITeam { get; set; }

		[Parameter]
		public string Name { get; set; }

		[Parameter]
		public EventCallback<ConfigTeamEntryBase> FnOnNameChanged { get; set; }

		protected void OnChange(ChangeEventArgs e)
		{
			Name = Convert.ToString(e.Value);
			FnOnNameChanged.InvokeAsync(this);
		}
	}
}
