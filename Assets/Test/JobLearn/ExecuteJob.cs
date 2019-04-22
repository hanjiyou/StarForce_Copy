using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;

public class ExecuteJob : MonoBehaviour {

	// Use this for initialization
	public NativeArray<Vector3> positions;
	public NativeArray<Vector3> volicity;

	void Start ()
	{
		positions = new NativeArray<Vector3>(3,Allocator.TempJob, NativeArrayOptions.ClearMemory);
		volicity=new NativeArray<Vector3>(3,Allocator.TempJob, NativeArrayOptions.ClearMemory);
		this.volicity[0] = new Vector3(1, 1, 1);
		this.volicity[1] = new Vector3(2, 1, 1);
		this.volicity[1] = new Vector3(3, 1, 1);
//第一种job
//		MyJob job = new MyJob()
//		{
//			ElapsedTime =3,
//			Positions = this.positions,
//			Velocities = this.volicity,
//		};
		//JobHandle jobHandle = job.Schedule();
		//JobHandle.ScheduleBatchedJobs();
//第二种job
//		MyParallelJob parallelJob = new MyParallelJob()
//		{
//			ElapsedTime =22,
//			Positions = this.positions,
//			Velocities = this.volicity,
//		};
//		JobHandle jobHandle = parallelJob.Schedule(this.volicity.Length,32);//Schedule(迭代执行次数,批量大小) 工作量很少时，第二个参数有意义
//第3种job
		MyParallelForTransform transformJob=new MyParallelForTransform()
		{
			ElapsedTime = 12,
			Velocities = volicity,
			Positions = this.positions,
		};
		Transform[] transforms = new[] {transform};
		TransformAccessArray accessArray=new TransformAccessArray(transforms);
		JobHandle jobHandle3 = transformJob.Schedule(accessArray);
		JobHandle.ScheduleBatchedJobs();
		jobHandle3.Complete();
		accessArray.Dispose();
	}
}
