using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class StreamDemo1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		byte[] buffer = null;
		string testString = "Stream!Hello world";
		char[] readCharArray = null;
		byte[] readBuffer = null;
		string readString = string.Empty;
		using (MemoryStream memoryStream=new MemoryStream())
		{
			Debug.Log("初始化字符串:"+testString);
			if (memoryStream.CanWrite)
			{
				buffer = Encoding.Default.GetBytes(testString);
				memoryStream.Write(buffer,0,3);
				Debug.Log("现在Stream.Postion在第{0}位置"+(memoryStream.Position+1));

				//从刚才结束的位置（当前位置）往后移3位，到第7位
				long newPositionInStream =memoryStream.CanSeek? memoryStream.Seek(3, SeekOrigin.Current):0;

				Debug.Log("重新定位后Stream.Postion在第{0}位置"+ (newPositionInStream+1));
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
