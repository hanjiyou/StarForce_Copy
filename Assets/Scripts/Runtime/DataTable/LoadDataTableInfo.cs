using System;

namespace UnityGameFramework.Runtime
{
    /// <summary>
    /// 加载数据表信息类
    /// </summary>
    internal sealed class LoadDataTableInfo
    {
        private readonly Type m_DataRowType;
        private readonly string m_DataTableName;
        private readonly string m_DataTableNameInType;
        private readonly object m_UserData;

        public LoadDataTableInfo(Type dataRowType, string dataTableName, string dataTableNameInType, object userData)
        {
            this.m_DataRowType = dataRowType;
            this.m_DataTableName = dataTableName;
            m_DataTableNameInType = dataTableNameInType;
            m_UserData = userData;
        }
        public Type DataRowType
        {
            get
            {
                return m_DataRowType;
            }
        }

        public string DataTableName
        {
            get
            {
                return m_DataTableName;
            }
        }

        public string DataTableNameInType
        {
            get
            {
                return m_DataTableNameInType;
            }
        }

        public object UserData
        {
            get
            {
                return m_UserData;
            }
        }
    }
}