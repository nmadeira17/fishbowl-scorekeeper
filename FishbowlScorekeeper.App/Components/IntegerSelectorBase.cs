using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishbowlScorekeeper.App.Components
{
	public class IntegerSelectorBase : ComponentBase
	{
		[Parameter]
		public int First { get; set; }

		[Parameter]
		public int Last { get; set; }

		[Parameter]
		public int Default { get; set; }

		[Parameter]
		public EventCallback<ChangeEventArgs> FnOnChanged { get; set; }
	}
}
