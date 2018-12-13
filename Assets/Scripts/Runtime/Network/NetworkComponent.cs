using System.Collections.Generic;
using GameFramework;
using GameFramework.Network;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace UnityGameFramework.Runtime
{
    /// <summary>
    /// 网络组件
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("Game Framework/Network")]
    public class NetworkComponent:GameFrameworkComponent
    {
        private INetworkManager m_NetworkManager = null;
        private EventComponent m_EventComponent = null;
        /// <summary>
        /// 获取网络频道的数量
        /// </summary>
        public int NetworkChannelCount
        {
            get { return this.m_NetworkManager.NetworkChannelCount; }
        }
        /// <summary>
        /// 游戏框架组件初始化
        /// </summary>
        protected void Awake()
        {
            base.Awake();
            this.m_NetworkManager = GameFrameworkEntry.GetModule<INetworkManager>();
            if (this.m_NetworkManager == null)
            {
                Log.Fatal("Network manager is invalid.");
                return;
            }

            this.m_NetworkManager.NetworkConnected += this.OnNetworkConnected;
            this.m_NetworkManager.NetworkClosed += this.OnNetworkClosed;
            this.m_NetworkManager.NetworkMissHeartBeat += this.OnNetworkMissHeartBeat;
            this.m_NetworkManager.NetworkError += this.OnNetworkError;
            this.m_NetworkManager.NetworkCustomError += this.OnNetworkCustomError;
        }

        private void Start()
        {
            this.m_EventComponent = GameEntry.GetComponent<EventComponent>();
            if (this.m_EventComponent == null)
            {
                Log.Fatal("Event component is invalid.");
                return;
            }
        }
        /// <summary>
        /// 检查是否存在网络频道
        /// </summary>
        /// <param name="name">网络频道名称</param>
        /// <returns>是否存在网络频道</returns>
        public bool HasNetworkChannel(string name)
        {
            return this.m_NetworkManager.HasNetworkChannel(name);
        }
        /// <summary>
        /// 获取网络频道
        /// </summary>
        /// <param name="name">网络频道名称</param>
        /// <returns>要获取的网络频道</returns>
        public INetworkChannel GetNetworkChannel(string name)
        {
            return this.m_NetworkManager.GetNetworkChannel(name);
        }
        /// <summary>
        /// 获取所有网络频道
        /// </summary>
        /// <returns></returns>
        public INetworkChannel[] GetAllNetworkChannels()
        {
            return this.m_NetworkManager.GetAllNetworkChannels();
        }
        /// <summary>
        /// 获取所有网络频道
        /// </summary>
        /// <param name="results"></param>
        public void GetAllChannels(List<INetworkChannel> results)
        {
            this.m_NetworkManager.GetAllNetworkChannels(results);
        }
        /// <summary>
        /// 创建网络频道
        /// </summary>
        /// <param name="name"></param>
        /// <param name="networkChannelHelper"></param>
        /// <returns></returns>
        public INetworkChannel CreateNetworkChannel(string name, INetworkChannelHelper networkChannelHelper)
        {
            return this.m_NetworkManager.CreateNetworkChannel(name, networkChannelHelper);
        }
        /// <summary>
        /// 销毁网络频道
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool DestroyNetworkChannel(string name)
        {
            return this.m_NetworkManager.DestroyNetworkChannel(name);
        }
        
        private void OnNetworkConnected(object sender, GameFramework.Network.NetworkConnectedEventArgs e)
        {
            m_EventComponent.Fire(this, ReferencePool.Acquire<NetworkConnectedEventArgs>().Fill(e));
        }

        private void OnNetworkClosed(object sender, GameFramework.Network.NetworkClosedEventArgs e)
        {
            this.m_EventComponent.Fire(this,ReferencePool.Acquire<NetworkClosedEventArgs>().Fill(e));
        }
        private void OnNetworkMissHeartBeat(object sender, GameFramework.Network.NetworkMissHeartBeatEventArgs e)
        {
            this.m_EventComponent.Fire(this,ReferencePool.Acquire<NetworkMissHeartBeatEventArgs>().Fill(e));
        }
     
        private void OnNetworkError(object sender, GameFramework.Network.NetworkErrorEventArgs e)
        {
            this.m_EventComponent.Fire(this,ReferencePool.Acquire<NetworkErrorEventArgs>().Fill(e));
        }
        private void OnNetworkCustomError(object sender, GameFramework.Network.NetworkCustomErrorEventArgs e)
        {
            this.m_EventComponent.Fire(this,ReferencePool.Acquire<NetworkCustomErrorEventArgs>().Fill(e));
        }
    }
}