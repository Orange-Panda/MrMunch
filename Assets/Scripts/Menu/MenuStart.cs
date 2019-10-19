using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStart : MonoBehaviour
{
	public string sceneToLoad;
	private bool transitioning = false;

	void Update()
	{
		if (Input.anyKeyDown && Time.timeSinceLevelLoad > 2f && transitioning == false)
		{
			transitioning = true;
			StartCoroutine(ChangeScene());
		}
	}

	private IEnumerator ChangeScene()
	{
		Instantiate(Resources.Load<GameObject>("Scene Transition"));
		yield return new WaitForSeconds(1.25f);
		SceneManager.LoadScene(sceneToLoad);
	}
}