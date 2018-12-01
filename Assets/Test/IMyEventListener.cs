using System;
using System.Collections;
using System.Collections.Generic;
using Test;
using UnityEngine;

interface IMyEventListener
{
	event EventHandler<MyEventArgs> MyStrEvent;
	string Name { get; set; }
}
