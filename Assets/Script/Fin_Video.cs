using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
public class Fin_Video : MonoBehaviour
{
    public RawImage RawImage; 

    private VideoPlayer videoPlayer;

    void Start()
    {
        // Récupère le composant VideoPlayer
        videoPlayer = GetComponent<VideoPlayer>();

        
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // Cache la RawImage en la désactivant
        if (RawImage != null)
        {
            RawImage.enabled = false; 
        }
    }
}
