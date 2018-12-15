using GameFramework.Resource;

namespace UnityGameFramework.Runtime
{
    public class ResourceHelperBase:IResourceHelper
    {
        public void LoadBytes(string fileUri, LoadBytesCallback loadBytesCallback)
        {
            throw new System.NotImplementedException();
        }

        public void UnloadScene(string sceneAssetName, UnloadSceneCallbacks unloadSceneCallbacks, object userData)
        {
            throw new System.NotImplementedException();
        }

        public void Release(object objectToRelease)
        {
            throw new System.NotImplementedException();
        }
    }
}