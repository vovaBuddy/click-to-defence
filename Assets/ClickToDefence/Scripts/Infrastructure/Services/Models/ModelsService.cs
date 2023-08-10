using ClickToDefence.Scripts.Models;

namespace ClickToDefence.Scripts.Infrastructure.Services.Models
{
	public class ModelsService : IService
	{
		public UserModel userModel { get; private set; }

		public ModelsService()
		{
			userModel = new UserModel();
		}
	}
}