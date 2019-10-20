using UnityEngine;

/// <summary>
/// Locks the cursor and hides it.
/// </summary>
public class CursorLock : MonoBehaviour
{
	private void OnEnable()
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	private void OnDisable()
	{
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}
}
