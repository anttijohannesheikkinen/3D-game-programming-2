using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using StateType = GameStateBase.StateType;

public class DevModeCheck : MonoBehaviour {

    public string sceneName;
    public StateType stateType;

	void Awake ()
    {
        Scene scene = SceneManager.GetActiveScene();
        sceneName = scene.name;

        GameObject persistentObjects = GameObject.Find("PersistentObjects");

        if (persistentObjects == null)
        {
            DontDestroyOnLoad(gameObject);
            SceneManager.LoadScene("SplashScreen");
        }
	}
	

}
