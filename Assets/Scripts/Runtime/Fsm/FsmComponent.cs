using GameFramework.Fsm;
using UnityEngine;

namespace UnityGameFramework.Runtime
{
    /// <summary>
    /// 有限状态机组件
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("Game Framework/FSM")]
    public class FsmComponent:GameFrameworkComponent
    {
        private IFsmManager m_FsmManager = null;

        protected override void Awake()
        {
            base.Awake();
        }
    }
}