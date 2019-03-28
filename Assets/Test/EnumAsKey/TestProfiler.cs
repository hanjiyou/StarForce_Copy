using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
/// <summary>
/// 1.在插入性能采样代码时，特别留意函数中是否存在多个return的现象。这些return如果没有处理好，就有可能导致性能采样的Begin和End不匹配，
/// 导致Profiler显示的结果有误。
/// 2.对于协程函数，BeginSample、EndSample之间注意不能存在yeild return null，否则可能导致Unity客户端卡死、手机卡死等现象。个人分析：
/// Begin和End配对分析的是单帧结果，出现yeild return null代表该区间将会分两帧甚至多帧完成。
/// </summary>
public class TestProfiler : MonoBehaviour
{
	private int t = 10000;
	// Update is called once per frame
	void Update () {
		Check(t);
		this.Run();
	}

	void Check(int n)
	{
		Profiler.BeginSample("Check");
		this.CheckA();
		Profiler.BeginSample("Calculate b");
		int b = n - 100;
		if (b < 10)
			b = 10;
		Profiler.EndSample();
		
		CheckB(b);
		Profiler.EndSample();
	}

	void CheckA()
	{
		Profiler.BeginSample("CheckA Function");
		Debug.Log("校验模块A");
		Profiler.EndSample();
	}

	void CheckB(int loopCount)
	{
		Profiler.BeginSample("CheckB(loopObject={0})",this);
		Debug.Log("校验模块B");
		
		Profiler.BeginSample("new List<string>");
		List<string> strList=new List<string>();
		Profiler.EndSample();

		for (int i = 0; i < loopCount; i++)
		{
			Profiler.BeginSample("Add str to list");
			string str = string.Format("Check:{0}", i);
			strList.Add(str);
			Profiler.EndSample();
		}
		Debug.Log(string.Format("list count:{0}",strList.Count));
		Profiler.EndSample();
	}

	void Run()
	{
		Profiler.BeginSample("Run");
		Debug.Log("开始运行");
		DoSomething();
		Profiler.EndSample();
	}

	void DoSomething()
	{
		
	}

	void OnGUI()
	{
		GUILayout.BeginVertical();
		if (GUILayout.Button("Enable/Disable Profiler Sample."))
		{
			Profiler.enabled = !Profiler.enabled;
		}
	}
}
