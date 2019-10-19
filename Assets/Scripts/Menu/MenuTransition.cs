using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTransition : MonoBehaviour
{
	private Animator animator;

	private void Awake()
	{
		animator = GetComponent<Animator>();
		DontDestroyOnLoad(gameObject);
		Destroy(gameObject, 10f);
	}

	private void OnEnable()
	{
		SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;
	}

	private void OnDisable()
	{
		SceneManager.activeSceneChanged -= SceneManager_activeSceneChanged;
	}

	private void SceneManager_activeSceneChanged(Scene arg0, Scene arg1)
	{
		animator.Play("TransitionEnd", 0, 0f);
	}
}
