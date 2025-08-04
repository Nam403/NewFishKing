using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    [SerializeField] Image AudioOn;
    [SerializeField] Image AudioOff;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    bool onMusic;
    void Start()
    {
        onMusic = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeAudioStatus()
    {
        if(onMusic == true)
        {
            onMusic = false;
            AudioListener.pause = true;
            AudioOn.enabled = false;
            AudioOff.enabled = true;
        }
        else
        {
            onMusic = true;
            AudioListener.pause = false;
            AudioOn.enabled = true;
            AudioOff.enabled = false;
        }
    }
}
