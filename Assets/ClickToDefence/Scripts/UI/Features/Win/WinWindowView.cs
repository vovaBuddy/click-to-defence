using ClickToDefence.Scripts.Infrastructure.Services.UI;
using TMPro;
using UnityEngine.UI;

namespace ClickToDefence.Scripts.UI.Features.Win
{
	public class WinWindowView : UIViewWithModel<WinWindowViewModel>
	{
		public TextMeshProUGUI waveNumber;
		public Button next;
		
		public override void Construct(WinWindowViewModel viewModel)
		{
			Subscribe(viewModel.isActive, gameObject.SetActive);
			Subscribe(viewModel.waveNumber, i => waveNumber.SetText($"WAVE NUMBER: {i+1}"));
			Subscribe(next, viewModel.next);
			
			base.Construct(viewModel);
		}
	}
}