using UnityEngine;

namespace UnityGameFramework.Runtime
{
    /// <summary>
    /// 下载组件
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("Game Framework/Download")]
    public class DownloadComponent:GameFrameworkComponent
    {
        private const int DefaultPriority = 0;
        private EventComponent m_EventComponent = null;
        
        [SerializeField]
        private Transform m_InstanceRoot = null;
        [SerializeField]
        private string m_DownloadAgentHelperTypeName = "UnityGameFramework.Runtime.UnityWebRequestDownloadAgentHelper";
      //  private DownloadAgentHelperBase
    }
}