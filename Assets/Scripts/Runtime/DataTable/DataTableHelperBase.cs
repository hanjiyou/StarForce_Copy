using GameFramework.DataTable;
using UnityEngine;

namespace UnityGameFramework.Runtime
{
    /// <summary>
    /// 数据表辅助器基类
    /// </summary>
    public class DataTableHelperBase:MonoBehaviour,IDataTableHelper
    {
        public bool LoadDataTable(object dataTableAsset, object userData)
        {
            throw new System.NotImplementedException();
        }

        public string[] SplitToDataRows(string text)
        {
            throw new System.NotImplementedException();
        }

        public void ReleaseDataTableAsset(object dataTableAsset)
        {
            
        }
    }
}