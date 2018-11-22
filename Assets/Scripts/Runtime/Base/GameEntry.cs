using System;
using System.Collections.Generic;
using System.Linq;

namespace UnityGameFramework.Runtime
{
    /// <summary>
    /// 游戏入口
    /// </summary>
    public static class GameEntry
    {
        /// <summary>
        /// 存储所有游戏框架组件的单链表
        /// </summary>
        private static LinkedList<GameFrameworkComponent> s_GameFrameworkComponents=new LinkedList<GameFrameworkComponent>();

        /// <summary>
        /// 游戏框架所在的场景编号
        /// </summary>
        internal const int GameFrameworkSceneId = 0;

        public static T GetComponent<T>() where T:GameFrameworkComponent
        {
            return (T)GetComponent(typeof (T));
        }

        public static GameFrameworkComponent GetComponent(Type type)
        {
            LinkedListNode<GameFrameworkComponent> current = s_GameFrameworkComponents.First;
            while (current!=null)
            {
                if (current.Value.GetType() == type)
                {
                    return current.Value;
                }

                current = current.Next;
            }
            return null;
        }

        public static GameFrameworkComponent GetComponent(string name)
        {
            LinkedListNode<GameFrameworkComponent> current = s_GameFrameworkComponents.First;
            while (current!=null)
            {
                Type type = current.Value.GetType();
                if (type.FullName == name || type.Name == name)
                {
                    return current.Value;
                }

                current = current.Next;
            }

            return null;
        }
        /// <summary>
        /// 关闭游戏框架
        /// </summary>
        /// <param name="shutdownType">关闭游戏框架类型</param>
        public static void Shutdown(ShutdownType shutdownType)
        {
            Log.Info("Shutdown Game Framework({0})...",shutdownType.ToString());
            BaseComponent baseComponent = GetComponent<BaseComponent>();
            if (baseComponent != null)
            {
//                baseComponent.s
            }
        }
    }
}