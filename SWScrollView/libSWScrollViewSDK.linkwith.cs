using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libSWScrollViewSDK.a", LinkTarget.Simulator | LinkTarget.ArmV7, "-framework QuartzCore", ForceLoad = true)]
