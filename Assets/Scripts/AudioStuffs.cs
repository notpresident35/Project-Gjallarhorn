using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioStuffs : MonoBehaviour
{
    // >>>> There must be an audio clip for each scene for this to work
    [SerializeField] List<AudioClip> playlist = new List<AudioClip>();
    private AudioSource currTrack, nextTrack;
    private bool currSongPlaying;
    public float timeToFade = 0.5f;

    // also sets start scene clip
    #region audio singleton
    private static AudioStuffs _instance;

    public static AudioStuffs AudioInstance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        DontDestroyOnLoad(AudioInstance);

        currTrack.clip = playlist[0];
    }
    #endregion

    // swaps to next track based on scene index from SceneStuffs
    public void SwapTrack(int clipSceneIndex)
    {
        StopAllCoroutines();

        StartCoroutine(FadeTrack(playlist[clipSceneIndex]));

        currSongPlaying = !currSongPlaying;
    }

    // fading between clips, idk if this actually works
    private IEnumerator FadeTrack(AudioClip nextClip)
    {
        float timeElapsed = 0;

        if (currSongPlaying)
        {
            nextTrack.clip = nextClip;
            nextTrack.Play();

            while (timeElapsed < timeToFade)
            {
                nextTrack.volume = Mathf.Lerp(0, 1, timeElapsed / timeToFade);
                currTrack.volume = Mathf.Lerp(1, 0, timeElapsed / timeToFade);
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            currTrack.Stop();
        }
        else
        {
            currTrack.clip = nextClip;
            currTrack.Play();

            while (timeElapsed < timeToFade)
            {
                currTrack.volume = Mathf.Lerp(0, 1, timeElapsed / timeToFade);
                nextTrack.volume = Mathf.Lerp(1, 0, timeElapsed / timeToFade);
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            nextTrack.Stop();
        }
    }

    // used to reset audio on scene Reload in SceneStuffs (i think this works?)
    public void ResetAudio()
    {
        currTrack.Stop();
        currTrack.Play();
    }
}
