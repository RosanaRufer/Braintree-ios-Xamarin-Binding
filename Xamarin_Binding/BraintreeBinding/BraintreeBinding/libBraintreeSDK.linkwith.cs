using System;
using ObjCRuntime;

[assembly: LinkWith ("libBraintreeSDK.a", LinkTarget.Simulator | LinkTarget.ArmV7, SmartLink = true, ForceLoad = true)]
