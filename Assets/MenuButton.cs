using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    Vector3 baseScale;

    void Start()
    {
        baseScale = transform.localScale;
    }

	// Use this for initialization
	public void Play () {
        SceneManager.LoadScene("Game");
	}
	
	// Update is called once per frame
	public void Quit () {
        Application.Quit();
	}
}
