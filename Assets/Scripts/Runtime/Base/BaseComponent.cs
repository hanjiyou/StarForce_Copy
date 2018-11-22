using UnityEngine;

namespace UnityGameFramework.Runtime
{
    /// <summary>
    /// 基础组件
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("Game Framework/Base")]
    public sealed class BaseComponent:GameFrameworkComponent
    {
        private const int DefaultDpi = 96;// default windows dpi
        private float m_GameSpeedBeforePause = 1f;
    }
}