using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventCallback;

public class SoundManager : MonoBehaviour
{
    public AudioSource efxSource;                   //Drag a reference to the audio source which will play the sound effects.
    public AudioSource musicSource;                 //Drag a reference to the audio source which will play the music.            
    public float lowPitchRange = .95f;              //The lowest a sound effect will be randomly pitched.
    public float highPitchRange = 1.05f;            //The highest a sound effect will be randomly pitched.

    private void Start()
    {

        //Get the attack listener to inject the play sound function into
        GetComponent<AttackListener>().PlaySound += PlaySound;
        //Get the death listener to inject the play sound funtion into
        GetComponent<DeathListener>().PlaySound += PlaySound;

    }
    
    public void PlaySound(GameObject obj)
    {
        if (obj.tag == "Player")
        {
            Debug.Log("Swoosh swoosh goes the players sword");
            //NOTE: FIX
            //RandomizeSfx(Get the musix file to play from the objeect??????)
        }
        else if (obj.tag == "Creature")
        {

        }
        else if (obj.tag == "Crystal")
        {

        }
    }

    //Used to play single sound clips.
    public void PlaySingle(AudioClip clip)
    {
        //Set the clip of our efxSource audio source to the clip passed in as a parameter.
        efxSource.clip = clip;

        //Play the clip.
        efxSource.Play();
    }

    public void PlayMusic(AudioClip clip)
    {
        //Set the clip of our efxSource audio source to the clip passed in as a parameter.
        musicSource.clip = clip;

        //Play the clip.
        musicSource.Play();
    }


    //RandomizeSfx chooses randomly between various audio clips and slightly changes their pitch.
    public void RandomizeSfx(params AudioClip[] clips)
    {
        //Generate a random number between 0 and the length of our array of clips passed in.
        int randomIndex = Random.Range(0, clips.Length);

        //Choose a random pitch to play back our clip at between our high and low pitch ranges.
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        //Set the pitch of the audio source to the randomly chosen pitch.
        efxSource.pitch = randomPitch;

        //Set the clip to the clip at our randomly chosen index.
        efxSource.clip = clips[randomIndex];

        //Play the clip.
        efxSource.Play();
    }
}
