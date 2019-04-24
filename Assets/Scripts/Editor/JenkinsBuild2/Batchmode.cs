using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

/// <summary>

/// 命令行批处理工具类

/// </summary>

public class Batchmode {

	static List<string> levels = new List<string>();

	static string keystoreFile = @"E:\UnityWorkSpace\han.keystore";

	public static void BuildAndroid() {

		if(!File.Exists(keystoreFile))

			throw new Exception("Not find keystore file");

//		StreamReader sr = File.OpenText(keystoreFile);
//
//		string password = sr.ReadToEnd().Trim();

		PlayerSettings.Android.keystorePass = "123456";

		PlayerSettings.Android.keyaliasPass = "123456";

		foreach ( EditorBuildSettingsScene scene in EditorBuildSettings.scenes ) {

			if ( !scene.enabled ) continue;

			levels.Add( scene.path );

		}

		EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTarget.Android);
		BuildReport report = BuildPipeline.BuildPlayer( levels.ToArray(), "han.apk", BuildTarget.Android, BuildOptions.None );
		BuildSummary summary = report.summary;
		if (summary.result == BuildResult.Succeeded)
		{
			Debug.Log("hhh summary返回成功");
		}else if (summary.result == BuildResult.Failed)
		{
			throw new Exception("BuildPlayer failure: ");
		}

	}

}