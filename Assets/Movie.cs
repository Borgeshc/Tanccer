using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Movie : MonoBehaviour
{
    public MovieTexture texture;
    RawImage image;
    
    void Start() {

        image = GetComponent<RawImage>();
        image.material.mainTexture = texture;
        texture.Play();
        StartCoroutine(Fade());
    }
    IEnumerator Fade()
    {
        yield return new WaitForSeconds(3);
        GetComponent<Animator>().SetBool("Fade", true);
    }
}
