using System;
using UnityEngine;

namespace Test
{
    public class MyEvent:IMyEventListener
    {
        private EventHandler<MyEventArgs> myStrEvent;
        private string eventName;
        public MyEvent()
        {
            this.myStrEvent = (EventHandler<MyEventArgs>) null;
            this.eventName = null;
        }
        public event EventHandler<MyEventArgs> MyStrEvent
        {
            add { myStrEvent += value;}
            remove { this.myStrEvent -= value; }
        }

        public string Name
        {
            get { return eventName;}
            set { this.eventName = value; }
        }

        public void ExecuteMyEvent()
        {
            if (this.myStrEvent == null)
            {
                Debug.LogError("HHH Event为空");
                return;
            }

            this.myStrEvent(this,new MyEventArgs("我的事件名字"));
        }
    }
}