using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayAudio : MonoBehaviour
{
    public enum AudioType
    {
        Null,
        buttonPress,
        notification,

    }

    public AudioType audioType;

    public AudioSource audioSource;

    AudioClip audioClip;

    public void playAudio()
    {
        
        switch (audioType)
        {
            case AudioType.Null:
                audioClip = null;
                break;

            case AudioType.buttonPress:
                audioClip = Resources.Load<AudioClip>("Audio/ButtonUnpress");
                break;

            case AudioType.notification:
                audioClip = Resources.Load<AudioClip>("Audio/Notification");
                break;
        }

        audioSource.PlayOneShot(audioClip);
    }

    private void Start()
    {
        Button btn = gameObject.GetComponent<Button>();

        btn.onClick.AddListener(playAudio);
    }

}
