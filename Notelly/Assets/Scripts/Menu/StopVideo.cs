using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Sprites;
using UnityEngine.UI;

public class StopVideo : MonoBehaviour
{
    private VideoPlayer player;
    public Button button;
    public Sprite startSprite;
    public Sprite stopSprite;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<VideoPlayer>();    
    }

    public void ChangeState()
    {
        if(player.isPlaying == false)
        {
            player.Play();
            button.image.sprite = stopSprite;
        }
        else
        {
            player.Pause();
            button.image.sprite = startSprite;
        }
    }

    public void EndVideo()
    {
        player.Pause();
    }
}
