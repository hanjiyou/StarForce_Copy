using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Profiling;
using Debug = UnityEngine.Debug;

/// <summary>
/// 1.枚举类型即值类型作为dic的key  一般情况会产生GC 因为插入时 会进行key比较 然后比较器EqualityComparer GetHashCode()和Equal()
/// 会进行装箱成为object(16字节)
/// 2.解决办法:自定义一个指定枚举类型的比较器(也可以是结构体)，如下面的MyEnumComparer，然后在创建Dic实例的时候在构造中传入
/// 
///
/// 二:结构体类型:
/// 结构体类型作为key  ①如果是第三方的无法修改，只能同样以第一种创建IEqualityComparer的方式来优化
/// ②如果是自定义的，建议实现IEquatable<MyStruct>接口 否则也会装箱产生GC
/// </summary>
public class MyEnumComparer : IEqualityComparer<TimeOfDay>//自定义一个枚举比较器 
{
	public bool Equals(TimeOfDay x, TimeOfDay y)
	{
		return (int) x == (int) y;
	}

	public int GetHashCode(TimeOfDay obj)
	{
		return (int) obj;
	}
}
public enum TimeOfDay
{
	One,
	Two
}

public struct MyStruct
{
	public int x;
	public MyStruct(int _x)
	{
		this.x = _x;
	}

	public override int GetHashCode()
	{
		return this.x;
	}
}
public struct MyStruct2:IEquatable<MyStruct2>
{
	public int x;
	public MyStruct2(int _x)
	{
		this.x = _x;
	}

	public bool Equals(MyStruct2 other)
	{
		return x == other.x;
	}

	public override int GetHashCode()
	{
		return this.x;
	}
}
public class TestEnum : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		this.TestEnumSpeed();
		//this.TestDicSpeed();
	}

	public void TestDicWithSample()
	{
		Profiler.BeginSample("TestDic");
		//字典枚举做key时，传入自定义的枚举比较器 避免了原来的拆装箱过程 节省了GC 默认Dic的containskey和add 如果key是值类型 都会进行拆装箱 从而发送GC
		Dictionary<TimeOfDay,int> dicData=new Dictionary<TimeOfDay, int>(new MyEnumComparer());
		Profiler.BeginSample("Dic.ContainsKey");
		if (!dicData.ContainsKey(TimeOfDay.One))
		{
			Profiler.BeginSample("Dic.add");
			dicData.Add(TimeOfDay.One,1);
			Profiler.EndSample();
		}
		Profiler.EndSample();

		Profiler.EndSample();
	}

	public void TestDicSpeed()
	{
		int timer = 10000;
		Stopwatch stopwatch=new Stopwatch();
		stopwatch.Start();
		for (int i = 0; i < timer; i++)
		{
			Dictionary<TimeOfDay,int> dic1=new Dictionary<TimeOfDay, int>();
			dic1.Add(TimeOfDay.One,1);
		}
		stopwatch.Stop();
		Debug.Log("hhh 普通情况，执行"+timer+"次，时间为="+stopwatch.ElapsedMilliseconds);
		
		Stopwatch stopwatch2=new Stopwatch();
		stopwatch2.Start();
		for (int i = 0; i < timer; i++)
		{
			Dictionary<TimeOfDay,int> dic1=new Dictionary<TimeOfDay, int>(new MyEnumComparer());
			dic1.Add(TimeOfDay.One,1);
		}
		stopwatch2.Stop();
		Debug.Log("hhh 使用比较器，执行"+timer+"次，时间为="+stopwatch2.ElapsedMilliseconds);
	}

	public void TestEnumSpeed()
	{
		Profiler.BeginSample("TestEnumSpeed0");
		int timer = 10000;
		Stopwatch stopwatch=new Stopwatch();
		stopwatch.Start();
		for (int i = 0; i < timer; i++)
		{
			Dictionary<MyStruct,int> dic1=new Dictionary<MyStruct, int>();
			dic1.Add(new MyStruct(1), 1);
		}
		stopwatch.Stop();
		Debug.Log("hhh 普通情况，执行"+timer+"次，时间为="+stopwatch.ElapsedMilliseconds);
		Profiler.EndSample();
		
		Profiler.BeginSample("TestEnumSpeed1");
		Stopwatch stopwatch2=new Stopwatch();
		stopwatch2.Start();
		for (int i = 0; i < timer; i++)
		{
			Dictionary<MyStruct2,int> dic1=new Dictionary<MyStruct2, int>();
			dic1.Add(new MyStruct2(1), 1);
		}
		stopwatch2.Stop();
		Debug.Log("hhh 使用IEquatable，执行"+timer+"次，时间为="+stopwatch2.ElapsedMilliseconds);
		Profiler.EndSample();

	}
	// Update is called once per frame
	void Update ()
	{
//		Profiler.BeginSample("MyUpdate");
//		this.TestDicWithSample();
//		Profiler.EndSample();
	}
}
