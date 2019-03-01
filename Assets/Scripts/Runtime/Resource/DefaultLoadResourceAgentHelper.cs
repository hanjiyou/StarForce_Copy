using System;
using GameFramework.Resource;
using UnityEngine;
using UnityEngine.Networking;

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
        private string m_ResourceChildName = null;
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
            
        }

        public override void ParseBytes(byte[] bytes)
        {
        }

        public override void LoadAsset(object resource, string resourceChildName, Type assetType, bool isScene)
        {
        }
        
        public override void Reset()
        {
            
        }
        
        public void Dispose()
        {
            
        }
    }
}