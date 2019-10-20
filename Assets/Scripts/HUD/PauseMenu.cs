using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	private Canvas canvas;
	private bool pauseState;
	private bool transitioning = false;

	private void Awake()
	{
		canvas = GetComponent<Canvas>();
		canvas.enabled = false;
		pauseState = false;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			TogglePause();
		}
	}

	public void TogglePause()
	{
		if (transitioning) return;
		pauseState = !pauseState;
		Time.timeScale = pauseState ? 0f : 1f;
		canvas.enabled = pauseState;
		CursorLock.LockCursor(!pauseState);
	}

	public void ReturnToMenu()
	{
		if (!transitioning)
		{
			transitioning = true;
			StartCoroutine(ChangeScene());
		}
	}

	public void QuitGame()
	{
		if (!transitioning)
		{
			transitioning = true;
			StartCoroutine(CloseGame());
		}
	}

	private IEnumerator CloseGame()
	{
		Instantiate(Resources.Load<GameObject>("Scene Transition"));
		yield return new WaitForSeconds(1.25f);
		Application.Quit();
		transitioning = false;
	}

	private IEnumerator ChangeScene()
	{
		Instantiate(Resources.Load<GameObject>("Scene Transition"));
		yield return new WaitForSeconds(1.25f);
		SceneManager.LoadScene("Menu");
		transitioning = false;
	}
}
