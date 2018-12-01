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
        }
        private void OnNetworkConnected(object sender, GameFramework.Network.NetworkConnectedEventArgs e)
        {
            m_EventComponent.Fire(this, ReferencePool.Acquire<NetworkConnectedEventArgs>().Fill(e));
        }
    }
}