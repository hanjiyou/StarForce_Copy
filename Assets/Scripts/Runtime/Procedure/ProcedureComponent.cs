using System;
using System.Collections;
using System.Collections.Generic;
using GameFramework;
using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityEngine;

namespace UnityGameFramework.Runtime.Procedure
{
    /// <summary>
    /// 流程组件
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("Game Framework/Procedure")]
    public sealed class ProcedureComponent:GameFrameworkComponent
    {
        private IProcedureManager m_ProcedureManager = null;
        private ProcedureBase m_EntranceProcedure = null;
        /// <summary>
        /// 序列化数组
        /// </summary>
        [SerializeField]
        private string[] m_AvailableProcedureTypeNames = null;
        [SerializeField]
        private string m_EntranceProcedureTypeName = null;

        protected override void Awake()
        {
            base.Awake();
            this.m_ProcedureManager = GameFrameworkEntry.GetModule<IProcedureManager>();
            if (this.m_ProcedureManager == null)
            {
                Log.Fatal("Procedure manager is invalid.");
                return;
            }
        }
        /// <summary>
        /// 加载所有流程 并初始化流程管理器 以及启动入口流程
        /// </summary>
        /// <returns></returns>
        private IEnumerator Start()
        {
            //存储所有的流程类型
            ProcedureBase[] procedures=new ProcedureBase[this.m_AvailableProcedureTypeNames.Length];
            for (int i = 0; i < this.m_AvailableProcedureTypeNames.Length; i++)
            {
                Type procedureType = Utility.Assembly.GetType(this.m_AvailableProcedureTypeNames[i]);
                if (procedureType == null)
                {
                    Log.Error("Can not find procedure type '{0}.'",this.m_AvailableProcedureTypeNames[i]);
                    yield break;
                }
                procedures[i]=(ProcedureBase)Activator.CreateInstance(procedureType);
                if (procedures[i] == null)
                {
                    Log.Error("Can not create procedure instance '{0}.'",this.m_AvailableProcedureTypeNames[i]);
                    yield break;
                }

                if (this.m_EntranceProcedureTypeName == this.m_AvailableProcedureTypeNames[i])
                {
                    this.m_EntranceProcedure = procedures[i];
                }
            }

            if (this.m_EntranceProcedure == null)
            {
                Log.Error("Entrance procedure in invalid.");
                yield break;
            }
            this.m_ProcedureManager.Initialize(GameFrameworkEntry.GetModule<IFsmManager>(),procedures);
            yield return new WaitForEndOfFrame();
            this.m_ProcedureManager.StartProcedure(this.m_EntranceProcedure.GetType());
        }
        /// <summary>
        /// 获取当前流程
        /// </summary>
        public ProcedureBase CurrentProcedure
        {
            get { return this.m_ProcedureManager.CurrentProcedure; }
        }
        /// <summary>
        /// 是否存在流程。
        /// </summary>
        /// <typeparam name="T">流程类型。</typeparam>
        /// <returns>是否存在流程。</returns>
        public bool HasProcedure<T>() where T : ProcedureBase
        {
            return m_ProcedureManager.HasProcedure<T>();
        }

        /// <summary>
        /// 获取流程。
        /// </summary>
        /// <returns>要获取的流程。</returns>
        /// <typeparam name="T">流程类型。</typeparam>
        public ProcedureBase GetProcedure<T>() where T : ProcedureBase
        {
            return m_ProcedureManager.GetProcedure<T>();
        }
    }
}