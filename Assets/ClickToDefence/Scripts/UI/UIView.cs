using ClickToDefence.Scripts.Infrastructure.Services.UI;
using ClickToDefence.Scripts.UI.Features.Win;
using UnityEngine;

namespace ClickToDefence.Scripts.UI
{
	public class UIView : UIViewWithModel<UIViewModel>
	{
		[SerializeField] private WinWindowView winWindow;

		public override void Construct(UIViewModel viewModel)
		{
			winWindow.Construct(viewModel.windowViewModel);
			
			base.Construct(viewModel);
		}
	}
}