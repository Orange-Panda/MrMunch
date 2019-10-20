using System;
using UnityEngine;

/// <summary>
/// Locks the cursor and hides it.
/// </summary>
public class CursorLock : MonoBehaviour
{
	private void OnEnable()
	{
		LockCursor(true);
	}

	private void OnDisable()
	{
		LockCursor(false);
	}

	internal static void LockCursor(bool value)
	{
		Cursor.visible = !value;
		Cursor.lockState = value ? CursorLockMode.Locked : CursorLockMode.None;
	}
}
