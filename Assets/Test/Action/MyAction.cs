using System;
using UnityEngine;

public class MyAction
{
    public Action<string> DownloadStart;

    public MyAction()
    {
        this.DownloadStart = null;
    }

    public void MyStart(string sendStr)
    {
        if (this.DownloadStart != null)
        {
            this.DownloadStart(sendStr);
        }

        string str = this.DownloadStart.Method.ToString();
        Debug.Log(str);
    }
}
