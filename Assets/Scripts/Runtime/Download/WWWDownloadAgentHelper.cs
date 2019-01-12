using System;
using GameFramework.Download;

namespace UnityGameFramework.Runtime
{
    public class WWWDownloadAgentHelper:DownloadAgentHelperBase,IDisposable
    {
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