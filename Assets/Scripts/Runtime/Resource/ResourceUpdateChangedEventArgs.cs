using GameFramework.Event;

namespace UnityGameFramework.Runtime
{
    /// <summary>
    /// 资源更新改变事件
    /// </summary>
    public class ResourceUpdateChangedEventArgs:GameEventArgs
    {
        /// <summary>
        /// 资源更新改变事件编号
        /// </summary>
        private static readonly int EventId = typeof (ResourceUpdateChangedEventArgs).GetHashCode();
        
        /// <summary>
        /// 获取资源更新改变事件编号
        /// </summary>
        public override int Id
        {
            get { return EventId; }
        }
        
        /// <summary>
        /// 获取资源名称。
        /// </summary>
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取资源下载后存放路径。
        /// </summary>
        public string DownloadPath
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取下载地址。
        /// </summary>
        public string DownloadUri
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取当前下载大小。
        /// </summary>
        public int CurrentLength
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取压缩包大小。
        /// </summary>
        public int ZipLength
        {
            get;
            private set;
        }

        /// <summary>
        /// 清理资源更新改变事件。
        /// </summary>
        public override void Clear()
        {
            Name = default(string);
            DownloadPath = default(string);
            DownloadUri = default(string);
            CurrentLength = default(int);
            ZipLength = default(int);
        }

        public ResourceUpdateChangedEventArgs Fill(GameFramework.Resource.ResourceUpdateChangedEventArgs e)
        {
            Name = e.Name;
            DownloadPath = e.DownloadPath;
            DownloadUri = e.DownloadUri;
            CurrentLength = e.CurrentLength;
            ZipLength = e.ZipLength;

            return this;
        }

    }
}