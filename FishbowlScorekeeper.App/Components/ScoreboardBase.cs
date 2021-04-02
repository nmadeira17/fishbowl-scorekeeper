using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;
using FishbowlScorekeeper.Shared;

namespace FishbowlScorekeeper.App.Components
{
	public class ScoreboardBase : ComponentBase
	{
		[Inject]
		protected IGameConfig m_gameConfig { get; private set; }

		protected GameActor m_gameActor;

		protected override Task OnInitializedAsync()
		{
			m_gameActor = new GameActor(m_gameConfig);
			return base.OnInitializedAsync();
		}
	}
}
