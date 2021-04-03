using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;

using FishbowlScorekeeper.Shared;

namespace FishbowlScorekeeper.App.Pages
{
	public class PlayGameBase : ComponentBase
	{
		[Inject]
		private IJSRuntime m_jsRuntime { get; set; }

		[Inject]
		protected IGameActor m_gameActor { get; private set; }

		protected void OnClick()
		{
			m_jsRuntime.InvokeVoidAsync("alert", "Start game!\n" + m_gameActor.ToString());
		}
	}
}
