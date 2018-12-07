using System;
using GameFramework;
using GameFramework.Event;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace UnityGameFramework.Runtime
{
    /// <summary>
    /// 事件组件
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("Game Framework/Event")]
    public class EventComponent:GameFrameworkComponent
    {
        private IEventManager m_EventManager = null;
        /// <summary>
        /// 获取事件处理函数的数量
        /// </summary>
        public int EventHandlerCount
        {
            get { return this.m_EventManager.EventHandlerCount; }
        }

        /// <summary>
        /// 获取事件数量
        /// </summary>
        public int EventCount
        {
            get { return this.m_EventManager.EventCount; }
        }
        /// <summary>
        /// 游戏框架组件初始化
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            this.m_EventManager = GameFrameworkEntry.GetModule<IEventManager>();
            if (this.m_EventManager == null)
            {
                Log.Fatal("Event manager is invalid.");
                return;
            }
        }

        private void Start()
        {
            
        }
        /// <summary>
        /// 获取事件处理函数的数量
        /// </summary>
        /// <param name="id">事件类型编号</param>
        /// <returns></returns>
        public int Count(int id)
        {
            return this.m_EventManager.Count(id);
        }
        
        /// <summary>
        /// 检查是否存在事件处理函数。
        /// </summary>
        /// <param name="id">事件类型编号。</param>
        /// <param name="handler">要检查的事件处理函数。</param>
        /// <returns>是否存在事件处理函数。</returns>
        public bool Check(int id, EventHandler<GameEventArgs> handler)
        {
            return m_EventManager.Check(id, handler);
        }
        /// <summary>
        /// 订阅事件处理回调函数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="handler"></param>
        public void Subscribe(int id, EventHandler<GameEventArgs> handler)
        {
            this.m_EventManager.Subscribe(id,handler);
        }
        /// <summary>
        /// 取消订阅事件处理回调函数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="handler"></param>
        public void Unsubscribe(int id,EventHandler<GameEventArgs> handler)
        {
            this.m_EventManager.Unsubscribe(id,handler);
        }
        /// <summary>
        /// 设置默认事件处理函数
        /// </summary>
        /// <param name="handler"></param>
        public void SetDefaultHandler(EventHandler<GameEventArgs> handler)
        {
            m_EventManager.SetDefaultHandler(handler);
        }
        /// <summary>
        /// 抛出事件，这个操作是线程安全的，即使不在主线程中抛出，也可保证在主线程中回调事件处理函数，但事件会在抛出后的下一帧分发。
        /// </summary>
        /// <param name="sender">事件发送者。</param>
        /// <param name="e">事件内容。</param>
        public void Fire(object sender, GameEventArgs e)
        {
            m_EventManager.Fire(sender, e);
        }

        /// <summary>
        /// 抛出事件立即模式，这个操作不是线程安全的，事件会立刻分发。
        /// </summary>
        /// <param name="sender">事件发送者。</param>
        /// <param name="e">事件内容。</param>
        public void FireNow(object sender, GameEventArgs e)
        {
            m_EventManager.FireNow(sender, e);
        }
    }
}