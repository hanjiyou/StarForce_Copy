using System;
using GameFramework.Download;
using UnityEngine.Networking;

namespace UnityGameFramework.Runtime
{
    /// <summary>
    /// 使用UnityWebRequest实现的下载代理辅助器
    /// </summary>
    public class UnityWebRequestDownloadAgentHelper:DownloadAgentHelperBase,IDisposable
    {
        private UnityWebRequest m_UnityWebRequest = null;
        private int m_LastDownloadedSize = 0;
        private bool m_Disposed = false;

        private EventHandler<DownloadAgentHelperUpdateEventArgs> m_DownloadAgentHelperUpdateEventHandler = null;
        private EventHandler<DownloadAgentHelperCompleteEventArgs> m_DownloadAgentHelperCompleteEventHandler = null;
        private EventHandler<DownloadAgentHelperErrorEventArgs> m_DownloadAgentHelperErrorEventHandler = null;

        public override void Reset()
        {
            throw new NotImplementedException();
        }

        public override event EventHandler<DownloadAgentHelperUpdateEventArgs> DownloadAgentHelperUpdate;
        public override event EventHandler<DownloadAgentHelperCompleteEventArgs> DownloadAgentHelperComplete;
        public override event EventHandler<DownloadAgentHelperErrorEventArgs> DownloadAgentHelperError;
        public override void Download(string downloadUri, object userData)
        {
            throw new NotImplementedException();
        }

        public override void Download(string downloadUri, int fromPosition, object userData)
        {
            throw new NotImplementedException();
        }

        public override void Download(string downloadUri, int fromPosition, int toPosition, object userData)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}