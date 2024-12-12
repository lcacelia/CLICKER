using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
public class Fin_Video : MonoBehaviour
{
    public RawImage RawImage; 

    private VideoPlayer videoPlayer;

    void Start()
    {
        // R�cup�re le composant VideoPlayer
        videoPlayer = GetComponent<VideoPlayer>();

        
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // Cache la RawImage en la d�sactivant
        if (RawImage != null)
        {
            RawImage.enabled = false; 
        }
    }
}
