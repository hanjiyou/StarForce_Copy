using System;

namespace UnityGameFramework.Runtime
{
    /// <summary>
    /// 默认数据表辅助器
    /// </summary>
    public class DefaultDataTableHelper:DataTableHelperBase
    {
        private DataTableComponent m_DataTableComponent = null;
//        private ResourceCompon
        /// <summary>
        /// 将要解析的数据表文本分割为数据表行文本
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public override string[] SplitToDataRows(string text)
        {
            return null;
        }

        public override void ReleaseDataTableAsset(object dataTableAsset)
        {
            throw new NotImplementedException();
        }

        protected override bool LoadDataTable(Type dataRowType, string dataTableName, string dataTableNameInType, object dataTableAsset,
            object userData)
        {
            throw new NotImplementedException();
        }
    }
}