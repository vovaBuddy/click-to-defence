using ClickToDefence.Scripts.Configs;

namespace ClickToDefence.Scripts.Infrastructure.Services.Configs
{
	public class ConfigsService : IService
	{
		public readonly AppConfig appConfig;

		public ConfigsService(AppConfig appConfig)
		{
			this.appConfig = appConfig;
		}
	}
}