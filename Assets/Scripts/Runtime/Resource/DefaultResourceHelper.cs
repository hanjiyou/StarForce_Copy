using System.Collections;
using GameFramework.Resource;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

namespace UnityGameFramework.Runtime
{
    /// <summary>
    /// 默认资源辅助器
    /// </summary>
    public class DefaultResourceHelper:ResourceHelperBase
    {
        /// <summary>
        /// 直接从指定文件路径读取数据流
        /// </summary>
        /// <param name="fileUri"></param>
        /// <param name="loadBytesCallback"></param>
        public override void LoadBytes(string fileUri, LoadBytesCallback loadBytesCallback)
        {
            StartCoroutine(LoadBytesCo(fileUri, loadBytesCallback));
        }
        
        /// <summary>
        /// 卸载场景。
        /// </summary>
        /// <param name="sceneAssetName">场景资源名称。</param>
        /// <param name="unloadSceneCallbacks">卸载场景回调函数集。</param>
        /// <param name="userData">用户自定义数据。</param>
        public override void UnloadScene(string sceneAssetName, UnloadSceneCallbacks unloadSceneCallbacks, object userData)
        {
#if UNITY_5_5_OR_NEWER
            
            if (gameObject.activeInHierarchy)
            {
                
            }
#else            
#endif
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="objectToRelease">要释放的资源</param>
        public override void Release(object objectToRelease)
        {
            AssetBundle assetBundle=objectToRelease as AssetBundle;
            if (assetBundle != null)
            {
                assetBundle.Unload(true);
                return;
            }
            /* Unity 当前 Resources.UnloadAsset 在 iOS 设备上会导致一些诡异问题，先不用这部分
            SceneAsset sceneAsset = objectToRelease as SceneAsset;
            if (sceneAsset != null)
            {
                return;
            }
            
            Object unityObject = objectToRelease as Object;
            if (unityObject == null)
            {
                Log.Warning("Asset is invalid.");
                return;
            }
            
            if (unityObject is GameObject || unityObject is MonoBehaviour)
            {
                // UnloadAsset may only be used on individual assets and can not be used on GameObject's / Components or AssetBundles.
                return;
            }
            
            Resources.UnloadAsset(unityObject);
            */
        }

        private IEnumerator LoadBytesCo(string fileUri, LoadBytesCallback loadBytesCallback)
        {
            byte[] bytes = null;
            string errorMessage = null;
#if UNITY_5_4_OR_NEWER
            UnityWebRequest unityWebRequest=UnityWebRequest.Get(fileUri);
#if UNITY_2017_2_OR_NEWER
            yield return unityWebRequest.SendWebRequest();
#else
            yield return unityWebRequest.Send();            
#endif
            bool isError = false;
#if UNITY_2017_1_OR_NEWER
            isError = unityWebRequest.isNetworkError;
#else
            isError = unityWebRequest.isError;
#endif
            bytes = unityWebRequest.downloadHandler.data;
            errorMessage = isError ? unityWebRequest.error : null;
            unityWebRequest.Dispose();
#else            
            WWW www=new WWW(fileUri);
            yield return www;
            bytes = www.bytes;
            errorMessage = www.error;
            www.Dispose();
#endif
            if (loadBytesCallback != null)
            {
                loadBytesCallback(fileUri, bytes, errorMessage);
            }
        }
        //TODO
//        private IEnumerator UnloadSceneGo(string sceneAssetName, UnloadSceneCallbacks unloadSceneCallbacks,
//            object userData)
//        {
//            //AsyncOperation asyncOperation=SceneManager.UnloadSceneAsync(Scenecom)
//        }
    }
}