using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitch : MonoBehaviour
{
	public string sceneToLoad = "Game";


	public void LoadGame ()
	{
		SceneManager.LoadScene(sceneToLoad);
	}
}
