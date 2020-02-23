using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class SampleScript : MonoBehaviour
{
	[DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
	private static extern int MessageBox(IntPtr hWnd, string lpText, string lpCaption, uint uType);

	private delegate bool WndEnumProc(IntPtr hWnd, IntPtr lParam);

	private static bool OutputWindow(IntPtr hWnd, IntPtr lParam)
	{
		Debug.Log(hWnd.ToInt64());
		return true;
	}

	[DllImport("user32.dll")]
	private static extern int EnumWindows(WndEnumProc lpEnumFunc, IntPtr lParam);

	private void Start()
	{
		MessageBox(IntPtr.Zero, "Command-line message box", "Attention!", 0);
	}

	private void Update()
	{
		EnumWindows(OutputWindow, IntPtr.Zero);
	}
}
