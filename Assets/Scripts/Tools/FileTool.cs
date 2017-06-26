﻿using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;

public class FileTool {
	
	public void WriteFile(string path, string name, string info){
		StreamWriter sw;
		FileInfo t = new FileInfo (path + "//" + name);
		sw = t.CreateText ();
		//以行的形式写入信息
		sw.WriteLine (info);
		sw.Close ();
		sw.Dispose ();
	}

	public void WriteFileToAppend(string path, string name, string info){
		StreamWriter sw;
		FileInfo t = new FileInfo (path + "//" + name);
		if (!t.Exists) {
			//如果此文件不存在则创建
			sw = t.CreateText ();
		} else {
			//如果此文件存在则打开
			sw = t.AppendText ();
		}
		//以行的形式写入信息
		sw.WriteLine (info);
		sw.Close ();
		sw.Dispose ();
	}

	/**
   * path：读取文件的路径
   * name：读取文件的名称
   */
	public ArrayList LoadFile(string path, string name) {
		//使用流的形式读取
		StreamReader sr = null;
		try {
			sr = File.OpenText (path + "//" + name);
		} catch (Exception e) {
			//路径与名称未找到文件则直接返回空
			Debug.Log("wjr----LoadFile:"+e);
			return null;
		}
		string line;
		ArrayList arrlist = new ArrayList ();
		while ((line = sr.ReadLine ()) != null) {
			//一行一行的读取
			//将每一行的内容存入数组链表容器中
			arrlist.Add (line);
		}
		//关闭流
		sr.Close ();
		//销毁流
		sr.Dispose ();
		//将数组链表容器返回
		return arrlist;
	} 

	/**
   * path：删除文件的路径
   * name：删除文件的名称
   */
	public void DeleteFile(string path, string name) {
		File.Delete (path + "//" + name);
	}
}