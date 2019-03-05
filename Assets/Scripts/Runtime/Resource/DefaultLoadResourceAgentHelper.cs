using System;
using GameFramework.Resource;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_5_4_OR_NEWER
using UnityEngine.Networking;
#endif
using Utility=GameFramework.Utility;
namespace UnityGameFramework.Runtime
{
    /// <summary>
    /// 默认加载资源代理辅助器
    /// </summary>
    public class DefaultLoadResourceAgentHelper:LoadResourceAgentHelperBase,IDisposable
    {
        private string m_FileFullPath = null;
        private string m_BytesFullPath = null;
        private int m_LoadType = 0;
        private string m_AssetName = null;
        private float m_LastProgress = 0f;
        private bool m_Disposed = false;
#if UNITY_5_4_OR_NEWER
        private UnityWebRequest m_UnityWebRequest = null;
#else
        private WWW m_WWW = null;
#endif
        private AssetBundleCreateRequest m_FileAssetBundleCreateRequest = null;
        private AssetBundleCreateRequest m_BytesAssetBundleCreateRequest = null;
        private AssetBundleRequest m_AssetBundleRequest = null;
        private AsyncOperation m_AsyncOperation = null;

        private EventHandler<LoadResourceAgentHelperUpdateEventArgs> m_LoadResourceAgentHelperUpdateEventHandler = null;
        private EventHandler<LoadResourceAgentHelperReadFileCompleteEventArgs> m_LoadResourceAgentHelperReadFileCompleteEventHandler = null;
        private EventHandler<LoadResourceAgentHelperReadBytesCompleteEventArgs> m_LoadResourceAgentHelperReadBytesCompleteEventHandler = null;
        private EventHandler<LoadResourceAgentHelperParseBytesCompleteEventArgs> m_LoadResourceAgentHelperParseBytesCompleteEventHandler = null;
        private EventHandler<LoadResourceAgentHelperLoadCompleteEventArgs> m_LoadResourceAgentHelperLoadCompleteEventHandler = null;
        private EventHandler<LoadResourceAgentHelperErrorEventArgs> m_LoadResourceAgentHelperErrorEventHandler = null;

        /// <summary>
        /// 加载资源代理辅助器异步加载资源更新事件。
        /// </summary>
        public override event EventHandler<LoadResourceAgentHelperUpdateEventArgs> LoadResourceAgentHelperUpdate
        {
            add
            {
                m_LoadResourceAgentHelperUpdateEventHandler += value;
            }
            remove
            {
                m_LoadResourceAgentHelperUpdateEventHandler -= value;
            }
        }

        /// <summary>
        /// 加载资源代理辅助器异步读取资源文件完成事件。
        /// </summary>
        public override event EventHandler<LoadResourceAgentHelperReadFileCompleteEventArgs> LoadResourceAgentHelperReadFileComplete
        {
            add
            {
                m_LoadResourceAgentHelperReadFileCompleteEventHandler += value;
            }
            remove
            {
                m_LoadResourceAgentHelperReadFileCompleteEventHandler -= value;
            }
        }

        /// <summary>
        /// 加载资源代理辅助器异步读取资源二进制流完成事件。
        /// </summary>
        public override event EventHandler<LoadResourceAgentHelperReadBytesCompleteEventArgs> LoadResourceAgentHelperReadBytesComplete
        {
            add
            {
                m_LoadResourceAgentHelperReadBytesCompleteEventHandler += value;
            }
            remove
            {
                m_LoadResourceAgentHelperReadBytesCompleteEventHandler -= value;
            }
        }

        /// <summary>
        /// 加载资源代理辅助器异步将资源二进制流转换为加载对象完成事件。
        /// </summary>
        public override event EventHandler<LoadResourceAgentHelperParseBytesCompleteEventArgs> LoadResourceAgentHelperParseBytesComplete
        {
            add
            {
                m_LoadResourceAgentHelperParseBytesCompleteEventHandler += value;
            }
            remove
            {
                m_LoadResourceAgentHelperParseBytesCompleteEventHandler -= value;
            }
        }

        /// <summary>
        /// 加载资源代理辅助器异步加载资源完成事件。
        /// </summary>
        public override event EventHandler<LoadResourceAgentHelperLoadCompleteEventArgs> LoadResourceAgentHelperLoadComplete
        {
            add
            {
                m_LoadResourceAgentHelperLoadCompleteEventHandler += value;
            }
            remove
            {
                m_LoadResourceAgentHelperLoadCompleteEventHandler -= value;
            }
        }

        /// <summary>
        /// 加载资源代理辅助器错误事件。
        /// </summary>
        public override event EventHandler<LoadResourceAgentHelperErrorEventArgs> LoadResourceAgentHelperError
        {
            add
            {
                m_LoadResourceAgentHelperErrorEventHandler += value;
            }
            remove
            {
                m_LoadResourceAgentHelperErrorEventHandler -= value;
            }
        }
        /// <summary>
        /// 通过加载资源代理辅助器开始异步读取资源文件。
        /// </summary>
        /// <param name="fullPath">要加载资源的完整路径名。</param>
        public override void ReadFile(string fullPath)
        {
            if (m_LoadResourceAgentHelperReadFileCompleteEventHandler == null || m_LoadResourceAgentHelperUpdateEventHandler == null || m_LoadResourceAgentHelperErrorEventHandler == null)
            {
                Log.Fatal("Load resource agent helper handler is invalid.");
                return;
            }

            m_FileFullPath = fullPath;
            m_FileAssetBundleCreateRequest = AssetBundle.LoadFromFileAsync(m_FileFullPath);//异步读取资源
        }
        
        /// <summary>
        /// 通过加载资源代理辅助器开始异步读取资源二进制流。
        /// </summary>
        /// <param name="fullPath">要加载资源的完整路径名。</param>
        /// <param name="loadType">资源加载方式。</param>
        public override void ReadBytes(string fullPath, int loadType)
        {
            if (m_LoadResourceAgentHelperReadBytesCompleteEventHandler == null || m_LoadResourceAgentHelperUpdateEventHandler == null || m_LoadResourceAgentHelperErrorEventHandler == null)
            {
                Log.Fatal("Load resource agent helper handler is invalid.");
                return;
            }

            this.m_BytesFullPath = fullPath;
#if UNITY_5_4_OR_NEWER
            this.m_UnityWebRequest=UnityWebRequest.Get(Utility.Path.GetRemotePath(fullPath));
#if UNITY_2017_2_OR_NEWER
            this.m_UnityWebRequest.SendWebRequest();
#else
            this.m_UnityWebRequest.Send();
#endif
#else    
            m_WWW=new WWW(Utility.Path.GetRemotePath(fullPath));
#endif
        }
        
        /// <summary>
        /// 通过加载资源代理辅助器开始异步将资源二进制流转换为加载对象。
        /// </summary>
        /// <param name="bytes">要加载资源的二进制流。</param>
        public override void ParseBytes(byte[] bytes)
        {
            if (m_LoadResourceAgentHelperParseBytesCompleteEventHandler == null || m_LoadResourceAgentHelperUpdateEventHandler == null || m_LoadResourceAgentHelperErrorEventHandler == null)
            {
                Log.Fatal("Load resource agent helper handler is invalid.");
                return;
            }

            this.m_BytesAssetBundleCreateRequest = AssetBundle.LoadFromMemoryAsync(bytes);//从内存中异步加载二进制流(解析流)
        }
        
        /// <summary>
        /// 通过加载资源代理辅助器开始异步加载资源。
        /// </summary>
        /// <param name="resource">资源。</param>
        /// <param name="assetName">要加载的资源名称。</param>
        /// <param name="assetType">要加载资源的类型。</param>
        /// <param name="isScene">要加载的资源是否是场景。</param>
        public override void LoadAsset(object resource, string assetName, Type assetType, bool isScene)
        {
            if (m_LoadResourceAgentHelperLoadCompleteEventHandler == null || m_LoadResourceAgentHelperUpdateEventHandler == null || m_LoadResourceAgentHelperErrorEventHandler == null)
            {
                Log.Fatal("Load resource agent helper handler is invalid.");
                return;
            }
            AssetBundle assetBundle=resource as AssetBundle;
            if (assetBundle == null)
            {
                m_LoadResourceAgentHelperErrorEventHandler(this, new LoadResourceAgentHelperErrorEventArgs(LoadResourceStatus.TypeError, "Can not load asset bundle from loaded resource which is not an asset bundle."));
                return;
            }

            if (string.IsNullOrEmpty(assetName))
            {
                this.m_LoadResourceAgentHelperErrorEventHandler(this,new LoadResourceAgentHelperErrorEventArgs(LoadResourceStatus.AssetError,"Can not load asset from asset bundle which child name is invalid."));
                return;;
            }

            m_AssetName = assetName;
            if (isScene)
            {
                int sceneNamePositionStart = assetName.LastIndexOf('/');
                int sceneNamePositionEnd = assetName.LastIndexOf('.');
                if (sceneNamePositionStart <= 0 || sceneNamePositionEnd <= 0 || sceneNamePositionStart > sceneNamePositionEnd)
                {
                    m_LoadResourceAgentHelperErrorEventHandler(this, new LoadResourceAgentHelperErrorEventArgs(LoadResourceStatus.AssetError, Utility.Text.Format("Scene name '{0}' is invalid.", assetName)));
                    return;
                }
                
                string sceneName=assetName.Substring(sceneNamePositionStart + 1, sceneNamePositionEnd - sceneNamePositionStart - 1);
                this.m_AsyncOperation = SceneManager.LoadSceneAsync(sceneName);
            }
            else
            {
                if (assetType != null)
                {
                    m_AssetBundleRequest = assetBundle.LoadAssetAsync(assetName, assetType);
                }
                else
                {
                    m_AssetBundleRequest = assetBundle.LoadAssetAsync(assetName);
                }
            }

        }
        
        /// <summary>
        /// 重置加载资源代理辅助器
        /// </summary>
        public override void Reset()
        {
            m_FileFullPath = null;
            m_BytesFullPath = null;
            m_LoadType = 0;
            m_AssetName = null;
            m_LastProgress = 0f;

#if UNITY_5_4_OR_NEWER
            if (m_UnityWebRequest != null)
            {
                m_UnityWebRequest.Dispose();
                m_UnityWebRequest = null;
            }
#else
            if (m_WWW != null)
            {
                m_WWW.Dispose();
                m_WWW = null;
            }
#endif

            m_FileAssetBundleCreateRequest = null;
            m_BytesAssetBundleCreateRequest = null;
            m_AssetBundleRequest = null;
            m_AsyncOperation = null;
        }
        
        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (this.m_Disposed)
            {
                return;
            }

            if (disposing)
            {
#if UNITY_5_4_OR_NEWER
                if (this.m_UnityWebRequest != null)
                {
                    this.m_UnityWebRequest.Dispose();
                    this.m_UnityWebRequest = null;
                }
#else
                if(m_WWW!=null){
                    m_WWW.Dispose();
                    m_WWW=null;
                }
#endif
            }

            this.m_Disposed = true;
        }
        /// <summary>
        /// Mono的Update轮询
        /// </summary>
        private void Update()
        {
            
        }
#if UNITY_5_4_OR_NEWER
        private void UpdateUnityWebRequest()
        {
            if (this.m_UnityWebRequest != null)
            {
                if (this.m_UnityWebRequest.isDone)
                {
                    if (string.IsNullOrEmpty(this.m_UnityWebRequest.error))
                    {
                        this.m_LoadResourceAgentHelperReadBytesCompleteEventHandler(this,new LoadResourceAgentHelperReadBytesCompleteEventArgs(this.m_UnityWebRequest.downloadHandler.data,this.m_LoadType));
                        this.m_UnityWebRequest.Dispose();
                        this.m_UnityWebRequest = null;
                        this.m_BytesFullPath = null;
                        this.m_LoadType = 0;
                        this.m_LastProgress = 0f;
                    }
                    else
                    {
                        bool isError = false;
#if UNITY_2017_1_OR_NEWER
                        isError = this.m_UnityWebRequest.isNetworkError;
#else
                        isError=this.m_UnityWebRequest.isError; 
#endif
                        this.m_LoadResourceAgentHelperErrorEventHandler(this,new LoadResourceAgentHelperErrorEventArgs(LoadResourceStatus.NotExist, 
                            Utility.Text.Format("Can not load asset bundle '{0}' with error message '{1}'.", m_BytesFullPath, isError ? m_UnityWebRequest.error : null)));
                    }
                }
                else if(this.m_UnityWebRequest.downloadProgress!=this.m_LastProgress)//如果下载进度不等 即有新下载 则调用更新事件
                {
                    this.m_LastProgress = this.m_UnityWebRequest.downloadProgress;
                    this.m_LoadResourceAgentHelperUpdateEventHandler(this,new LoadResourceAgentHelperUpdateEventArgs(LoadResourceProgress.ReadResource,this.m_UnityWebRequest.downloadProgress));
                }
            }
        }
#endif
        
    }
}