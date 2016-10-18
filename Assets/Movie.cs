using UnityEngine;
using UnityEngine.UI;

public class Movie : MonoBehaviour
{
    MovieTexture mt;

    void Awake()
    {
        RawImage rim = GetComponent<RawImage>();
        mt = (MovieTexture)rim.mainTexture;
        mt.Play();
    }
}
