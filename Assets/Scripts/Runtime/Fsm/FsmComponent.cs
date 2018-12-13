using System;
using System.Collections.Generic;
using GameFramework;
using GameFramework.Fsm;
using UnityEngine;

namespace UnityGameFramework.Runtime
{
    /// <summary>
    /// 有限状态机组件
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("Game Framework/FSM")]
    public sealed class FsmComponent:GameFrameworkComponent
    {
        private IFsmManager m_FsmManager = null;
        /// <summary>
        /// 游戏框架组件初始化
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            this.m_FsmManager = GameFrameworkEntry.GetModule<IFsmManager>();
            if (this.m_FsmManager == null)
            {
                Log.Fatal("FSM manager is invalid.");
                return;
            }
        }

        private void Start()
        {
            
        }
        /// <summary>
        /// 获取有限状态机数量
        /// </summary>
        public int Count
        {
            get { return this.m_FsmManager.Count; }
        }
        /// <summary>
        /// 检查是否存在有限状态机
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public bool HasFsm<T>() where T : class
        {
            return this.m_FsmManager.HasFsm<T>();
        }
        /// <summary>
        /// 检查是否存在有限状态机。
        /// </summary>
        /// <param name="ownerType">有限状态机持有者类型。</param>
        /// <returns>是否存在有限状态机。</returns>
        public bool HasFsm(Type ownerType)
        {
            return m_FsmManager.HasFsm(ownerType);
        }

        /// <summary>
        /// 检查是否存在有限状态机。
        /// </summary>
        /// <typeparam name="T">有限状态机持有者类型。</typeparam>
        /// <param name="name">有限状态机名称。</param>
        /// <returns>是否存在有限状态机。</returns>
        public bool HasFsm<T>(string name) where T : class
        {
            return m_FsmManager.HasFsm<T>(name);
        }

        /// <summary>
        /// 检查是否存在有限状态机。
        /// </summary>
        /// <param name="ownerType">有限状态机持有者类型。</param>
        /// <param name="name">有限状态机名称。</param>
        /// <returns>是否存在有限状态机。</returns>
        public bool HasFsm(Type ownerType, string name)
        {
            return m_FsmManager.HasFsm(ownerType, name);
        }
        /// <summary>
        /// 获取有限状态机。
        /// </summary>
        /// <typeparam name="T">有限状态机持有者类型。</typeparam>
        /// <returns>要获取的有限状态机。</returns>
        public IFsm<T> GetFsm<T>() where T : class
        {
            return m_FsmManager.GetFsm<T>();
        }

        /// <summary>
        /// 获取有限状态机。
        /// </summary>
        /// <param name="ownerType">有限状态机持有者类型。</param>
        /// <returns>要获取的有限状态机。</returns>
        public FsmBase GetFsm(Type ownerType)
        {
            return m_FsmManager.GetFsm(ownerType);
        }

        /// <summary>
        /// 获取有限状态机。
        /// </summary>
        /// <typeparam name="T">有限状态机持有者类型。</typeparam>
        /// <param name="name">有限状态机名称。</param>
        /// <returns>要获取的有限状态机。</returns>
        public IFsm<T> GetFsm<T>(string name) where T : class
        {
            return m_FsmManager.GetFsm<T>(name);
        }

        /// <summary>
        /// 获取有限状态机。
        /// </summary>
        /// <param name="ownerType">有限状态机持有者类型。</param>
        /// <param name="name">有限状态机名称。</param>
        /// <returns>要获取的有限状态机。</returns>
        public FsmBase GetFsm(Type ownerType, string name)
        {
            return m_FsmManager.GetFsm(ownerType, name);
        }
        /// <summary>
        /// 获取所有有限状态机
        /// </summary>
        /// <returns></returns>
        public FsmBase[] GetAllFsms()
        {
            return this.m_FsmManager.GetAllFsms();
        }
        /// <summary>
        /// 获取所有有限状态机
        /// </summary>
        /// <param name="results"></param>
        public void GetAllFsms(List<FsmBase> results)
        {
            this.m_FsmManager.GetAllFsms(results);
        }
        /// <summary>
        /// 创建有限状态机
        /// </summary>
        /// <param name="owner">有限状态机持有者</param>
        /// <param name="states">有限状态机状态集合</param>
        /// <typeparam name="T">有限状态机持有者类型</typeparam>
        /// <returns></returns>
        public IFsm<T> CreateFsm<T>(T owner, params FsmState<T>[] states) where T : class
        {
            return this.m_FsmManager.CreateFsm(owner, states);
        }
        /// <summary>
        /// 创建有限状态机
        /// </summary>
        /// <param name="name">有限状态机名称</param>
        /// <param name="owner">有限状态机持有者</param>
        /// <param name="states">有限状态机状态集合</param>
        /// <typeparam name="T">持有者类型</typeparam>
        /// <returns></returns>
        public IFsm<T> CreateFsm<T>(string name, T owner, params FsmState<T>[] states) where T : class
        {
            return this.m_FsmManager.CreateFsm(name, owner, states);
        }
        /// <summary>
        /// 销毁有限状态机
        /// </summary>
        /// <typeparam name="T">有限状态机持有者类型</typeparam>
        /// <returns>是否销毁有限状态机成功</returns>
        public bool DestoryFsm<T>() where T : class
        {
            return this.m_FsmManager.DestroyFsm<T>();
        }
        /// <summary>
        /// 销毁有限状态机
        /// </summary>
        /// <param name="ownerType">有限状态机持有者类型</param>
        /// <returns></returns>
        public bool DestroyFsm(Type ownerType)
        {
            return this.m_FsmManager.DestroyFsm(ownerType);
        }
        
        /// <summary>
        /// 销毁有限状态机。
        /// </summary>
        /// <typeparam name="T">有限状态机持有者类型。</typeparam>
        /// <param name="name">要销毁的有限状态机名称。</param>
        /// <returns>是否销毁有限状态机成功。</returns>
        public bool DestroyFsm<T>(string name) where T : class
        {
            return m_FsmManager.DestroyFsm<T>(name);
        }

        /// <summary>
        /// 销毁有限状态机。
        /// </summary>
        /// <param name="ownerType">有限状态机持有者类型。</param>
        /// <param name="name">要销毁的有限状态机名称。</param>
        /// <returns>是否销毁有限状态机成功。</returns>
        public bool DestroyFsm(Type ownerType, string name)
        {
            return m_FsmManager.DestroyFsm(ownerType, name);
        }

        /// <summary>
        /// 销毁有限状态机。
        /// </summary>
        /// <typeparam name="T">有限状态机持有者类型。</typeparam>
        /// <param name="fsm">要销毁的有限状态机。</param>
        /// <returns>是否销毁有限状态机成功。</returns>
        public bool DestroyFsm<T>(IFsm<T> fsm) where T : class
        {
            return m_FsmManager.DestroyFsm(fsm);
        }
        /// <summary>
        /// 销毁有限状态机。
        /// </summary>
        /// <param name="fsm">要销毁的有限状态机。</param>
        /// <returns>是否销毁有限状态机成功。</returns>
        public bool DestroyFsm(FsmBase fsm)
        {
            return m_FsmManager.DestroyFsm(fsm);
        }
    }
}