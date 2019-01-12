using Boo.Lang;
using UnityEngine;

namespace Test.Action
{
    public class TestAction:MonoBehaviour
    {
        private MyAction _myAction;

        private void Start()
        {
            this._myAction=new MyAction();
            this._myAction.DownloadStart = OnMyAction;//通过+=来为Action实例化
            this._myAction.MyStart("sdafasdf");
            //测试AddRange()
            List<int> result=new List<int>();
            int[] arr = {1,2,3,4 };
            result.AddRange(arr);
        }

        public void OnMyAction(string str)
        {
            Debug.Log("HHH "+str);
        }
    }
}