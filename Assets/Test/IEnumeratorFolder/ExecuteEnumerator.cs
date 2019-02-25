using System.Collections;
using System.Collections.Generic;
using Test.IEnumeratorFolder;
using UnityEngine;

public class ExecuteEnumerator : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		string[] datas = {"111", "2222", "33333"};
		MyIEnumerable myIEnumerable=new MyIEnumerable(datas);
		//方法1
		foreach (var item in datas)
		{
			Debug.Log(item);
		}
		//方法2
//		MyIEnumerator myIEnumerator = myIEnumerable.GetEnumerator();
//		while (myIEnumerator.MoveNext())
//		{
//			Debug.Log("while....."+myIEnumerator.Current);
//		}
	}

	IEnumerator Test()
	{
		yield return null;
	}

}
