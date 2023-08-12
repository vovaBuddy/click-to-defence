using ClickToDefence.Scripts.Configs;
using ClickToDefence.Scripts.CoreGameplay.Configs;
using ClickToDefence.Scripts.CoreGameplay.Features.Locations.Configs;

namespace ClickToDefence.Scripts.Infrastructure.Services.Configs
{
	public class ConfigsService : IService
	{
		public readonly AppConfig appConfig;
		
		public CoreGameplayConfig coreGameplayConfig => appConfig.coreGameplayConfig;
		public LocationsConfig locationsConfig => appConfig.locationsConfig;

		public ConfigsService(AppConfig appConfig)
		{
			this.appConfig = appConfig;
		}
	}
}