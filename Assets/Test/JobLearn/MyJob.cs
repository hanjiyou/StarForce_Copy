using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;

public struct MyJob : IJob {//IJob执行一次简单的作业
    [ReadOnly]
    public float ElapsedTime;
    
    [DeallocateOnJobCompletion]
    public NativeArray<Vector3> Positions;//原生容器
    
    [ReadOnly]
    [DeallocateOnJobCompletion]//通过特性来控制原生容器的释放(自动释放)
    public NativeArray<Vector3> Velocities;
    public void Execute()//只会执行一次
    {
        for (int i = 0; i < Positions.Length; ++i)
        {
            Positions[i] += Velocities [i] * ElapsedTime;
            Debug.Log("HHH"+this.Positions[i]);
        }
    }
}

public struct MyParallelJob : IJobParallelFor//本机容器的每个元素或固定数量的迭代执行相同的独立操作
{
    [ReadOnly]
    public float ElapsedTime;
    
    [DeallocateOnJobCompletion]
    public NativeArray<Vector3> Positions;//原生容器
    
    [ReadOnly]
    [DeallocateOnJobCompletion]//通过特性来控制原生容器的释放(自动释放)
    public NativeArray<Vector3> Velocities;
    public void Execute(int index)//对每个元素运行一次Execute() 而不是整个数组运行一次
    {
        Positions[index] += Velocities[index] * ElapsedTime;
        Debug.Log(Positions[index]);
    }
    public void Update()
    {
        Debug.Log("HHH update");
    }
}

public struct MyParallelForTransform:IJobParallelForTransform
{
    [ReadOnly]
    public float ElapsedTime;
 
    [DeallocateOnJobCompletion]
    public NativeArray<Vector3> Positions;//原生容器
    
    [ReadOnly]
    [DeallocateOnJobCompletion]
    public NativeArray<Vector3> Velocities;
 
    public void Execute(int index, TransformAccess transform)
    {
        transform.localPosition += Velocities[index] * ElapsedTime;
        Debug.Log(transform.position);
    }
}