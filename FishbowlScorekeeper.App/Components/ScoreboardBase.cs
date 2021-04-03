using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;
using FishbowlScorekeeper.Shared;

namespace FishbowlScorekeeper.App.Components
{
	public class ScoreboardBase : ComponentBase
	{
		[Inject]
		protected IGameActor m_gameActor { get; private set; }
	}
}
