using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ConstTest 
{
	private  const int a=2;
	private   readonly int b=3;
	 
	public ConstTest()
	{
		b = 2;
		Debug.Log("b="+b);
	}
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
