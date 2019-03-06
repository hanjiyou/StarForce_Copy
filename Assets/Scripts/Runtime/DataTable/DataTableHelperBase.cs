using System;
using System.Collections.Generic;
using System.IO;
using GameFramework;
using GameFramework.DataTable;
using UnityEngine;

namespace UnityGameFramework.Runtime
{
    /// <summary>
    /// 数据表辅助器基类
    /// </summary>
    public abstract class DataTableHelperBase:MonoBehaviour,IDataTableHelper
    {
        /// <summary>
        /// 加载数据表
        /// </summary>
        /// <param name="dataTableAsset">数据表资源</param>
        /// <param name="userData">用户自定义数据</param>
        /// <returns>是否加载成功</returns>
        public bool LoadDataTable(object dataTableAsset, object userData)
        {
            LoadDataTableInfo loadDataTableInfo = (LoadDataTableInfo) userData;
            return LoadDataTable(loadDataTableInfo.DataRowType, loadDataTableInfo.DataTableName,
                loadDataTableInfo.DataTableNameInType, dataTableAsset, userData);
        }

        /// <summary>
        /// 将要解析的数据表文本分割为数据表行文本。
        /// </summary>
        /// <param name="text">要解析的数据表文本。</param>
        /// <returns>数据表行文本。</returns>
        public abstract string[] SplitToDataRows(string text);

        public bool LoadDataTable(object dataTableAsset, LoadType loadType, object userData)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GameFrameworkSegment<string>> GetDataRowSegments(string text)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GameFrameworkSegment<byte[]>> GetDataRowSegments(byte[] bytes)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GameFrameworkSegment<Stream>> GetDataRowSegments(Stream stream)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 释放数据表资源。
        /// </summary>
        /// <param name="dataTableAsset">要释放的数据表资源。</param>
        public abstract void ReleaseDataTableAsset(object dataTableAsset);

        /// <summary>
        /// 加载数据表。
        /// </summary>
        /// <param name="dataRowType">数据表行的类型。</param>
        /// <param name="dataTableName">数据表名称。</param>
        /// <param name="dataTableNameInType">数据表类型下的名称。</param>
        /// <param name="dataTableAsset">数据表资源。</param>
        /// <param name="userData">用户自定义数据。</param>
        /// <returns>加载是否成功。</returns>
        protected abstract bool LoadDataTable(Type dataRowType, string dataTableName, string dataTableNameInType, object dataTableAsset, object userData);

    }
}