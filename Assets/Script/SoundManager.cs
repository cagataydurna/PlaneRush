using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager _instance;

    public AudioSource CutSound;
    public AudioSource EndGameSound;
    public AudioSource HitSound;
    public AudioSource ButtonClick;
    

    public AudioClip CutClip;
    public AudioClip EndGameClip;
    public AudioClip HitClip;
    public AudioClip ButtonClip;
    
    public void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
  
    }

    public void CutSoundEffect()
    {
        CutSound.PlayOneShot(CutClip);
    }

    public void HitSoundEffect()
    {
        HitSound.PlayOneShot(HitClip);
    }

    public void EndGameSoundEffect()
    {
        EndGameSound.PlayOneShot(EndGameClip);
    }

    public void ButtonClickSound()
    {
        ButtonClick.PlayOneShot(ButtonClip);
    }

   

}
