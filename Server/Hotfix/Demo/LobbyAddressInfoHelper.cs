using System.Collections.Generic;


namespace ET
{
	public static class LobbyAddressInfoHelper
	{
		public static StartSceneConfig GetInfo(int zone)
		{
			List<StartSceneConfig> zoneLobbys = StartSceneConfigCategory.Instance.Lobbys[zone];
			
			//TODO need dynamic balance
			int n = RandomHelper.RandomNumber(0, zoneLobbys.Count);

			return zoneLobbys[n];
		}
	}
}
