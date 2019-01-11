using System.Collections;
using System.Collections.Generic;
using Test;
using UnityEngine;

public class TestMyEvent : MonoBehaviour
{
	private MyEvent _event;
	// Use this for initialization
	void Start ()
	{
		this._event =new MyEvent();
		//this._event.MyStrEvent += OnTestMethod;
		this._event.ExecuteMyEvent();
	}

	private void OnTestMethod(object sender,MyEventArgs args)
	{
		Debug.Log("hhh OnTestMethod "+sender.GetType().FullName+" | argsname="+args.name);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
