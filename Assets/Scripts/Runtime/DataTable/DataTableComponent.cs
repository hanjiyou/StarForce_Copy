using GameFramework;
using GameFramework.DataNode;
using UnityEngine;

namespace UnityGameFramework.Runtime
{
    /// <summary>
    /// 数据表组件
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("Game Framework/Data Table")]
    public class DataTableComponent:GameFrameworkComponent
    {
        private const int DefaultPriority = 0;
        private IDataNodeManager m_DataTableManager = null;
        private EventComponent m_EventComponent = null;
        [SerializeField]
        private bool m_EnableLoadDataTableSuccessEvent = true;

        [SerializeField]
        private bool m_EnableLoadDataTableFailureEvent = true;

        [SerializeField]
        private bool m_EnableLoadDataTableUpdateEvent = false;

        [SerializeField]
        private bool m_EnableLoadDataTableDependencyAssetEvent = false;

        [SerializeField]
        private string m_DataTableHelperTypeName = "UnityGameFramework.Runtime.DefaultDataTableHelper";

//        [SerializeField]
//        private DataTableHelperBase m_CustomDataTableHelper = null; 
        private void Awake()
        {
            base.Awake();
            this.m_DataTableManager = GameFrameworkEntry.GetModule<IDataNodeManager>();
            if (this.m_DataTableManager == null)
            {
                Log.Fatal("Data table manager is invalid.");
                return;
            }
//            this.m_DataTableManagerk
        }
    }
}