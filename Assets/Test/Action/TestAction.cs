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
        }

        public void OnMyAction(string str)
        {
            Debug.Log("HHH "+str);
        }
    }
}