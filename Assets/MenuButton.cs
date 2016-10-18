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

    public void MouseOver()
    {
        print("Over");
        transform.localScale = (transform.localScale * 2) * .5f;
    }

    public void MouseExit()
    {
        print("Exit");
        transform.localScale = baseScale;
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
