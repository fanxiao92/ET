

using System;

namespace ET
{
    public static class SceneFactory
    {
        public static async ETTask<Scene> Create(Entity parent, string name, SceneType sceneType)
        {
            long id = IdGenerater.GenerateId();
            return await Create(parent, id, parent.DomainZone(), name, sceneType);
        }
        
        public static async ETTask<Scene> Create(Entity parent, long id, int zone, string name, SceneType sceneType, StartSceneConfig startSceneConfig = null)
        {
            Scene scene = EntitySceneFactory.CreateScene(id, zone, sceneType, name);
            scene.Parent = parent;

            scene.AddComponent<MailBoxComponent, MailboxType>(MailboxType.UnOrderMessageDispatcher);

            switch (scene.SceneType)
            {
                case SceneType.Login:
                    scene.AddComponent<NetOuterComponent, string>(startSceneConfig.OuterAddress);
                    break;
                case SceneType.Lobby:
                    scene.AddComponent<NetOuterComponent, string>(startSceneConfig.OuterAddress);
                    scene.AddComponent<PlayerContextComponent>();
                    scene.AddComponent<LobbySessionKeyComponent>();
                    break;
            }

            return scene;
        }
    }
}