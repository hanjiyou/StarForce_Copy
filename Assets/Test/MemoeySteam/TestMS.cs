using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TestMS : MonoBehaviour {

	byte [] buffer=new byte[600];
	// Use this for initialization
	void Start () {
		for (int i = 0; i < 600; i++)
		{
			this.buffer[i] = (byte)(i % 256);
		}
		this.OnTestMemory();
	}

	private void OnTestMemory()
	{
		//创建内存流  初始分配50字节缓冲区
		MemoryStream memoryStreamy=new MemoryStream(700);
		memoryStreamy.Write(this.buffer,0,this.buffer.GetLength(0));
		Debug.Log("写入数据后内存流长度length="+memoryStreamy.Length);
		Debug.Log("缓冲区大小capacity="+memoryStreamy.Capacity);
		memoryStreamy.SetLength(601);
		Debug.Log("0写入数据后内存流长度length="+memoryStreamy.Length);
		memoryStreamy.Capacity = 620;
		Debug.Log("0缓冲区大小capacity="+memoryStreamy.Capacity);
		memoryStreamy.Seek(-10, SeekOrigin.End);
		Debug.Log("pos="+memoryStreamy.Position);

		byte[] datasInBuffer= memoryStreamy.GetBuffer();
		Debug.Log(datasInBuffer.Length);
		memoryStreamy.Close();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
