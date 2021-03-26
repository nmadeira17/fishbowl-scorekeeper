using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishbowlScorekeeper.App.Components
{
	public class ConfigRoundEntryBase : ComponentBase
	{
		[Parameter]
		public int IRound { get; set; }

		[Parameter]
		public string Name { get; set; }

		[Parameter]
		public int Duration { get; set; }

		[Parameter]
		public EventCallback<ConfigRoundEntryBase> FnOnRoundChanged { get; set; }

		protected void OnNameChange(ChangeEventArgs e)
		{
			Name = Convert.ToString(e.Value);
			FnOnRoundChanged.InvokeAsync(this);
		}

		protected void OnDurationChange(ChangeEventArgs e)
		{
			Duration = Convert.ToInt32(e.Value);
			FnOnRoundChanged.InvokeAsync(this);
		}
	}
}
