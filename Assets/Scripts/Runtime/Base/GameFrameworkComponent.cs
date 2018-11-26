using UnityEngine;

namespace UnityGameFramework.Runtime
{
    /// <summary>
    /// 游戏框架组件抽象类--所有组件的抽象父类
    /// </summary>
    public abstract class GameFrameworkComponent:MonoBehaviour
    {
        /// <summary>
        /// 游戏框架组件初始化
        /// </summary>
        protected virtual void Awake()
        {
            GameEntry.RegesterComponent(this);
        }
    }
}