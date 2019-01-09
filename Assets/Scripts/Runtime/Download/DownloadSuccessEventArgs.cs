using GameFramework.Event;

namespace UnityGameFramework.Runtime
{
    public class DownloadSuccessEventArgs:GameEventArgs
    {
        private int m_Id;

        public override void Clear()
        {
            throw new System.NotImplementedException();
        }

        public override int Id
        {
            get { return m_Id; }
        }
    }
}