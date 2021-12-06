using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public AudioSource levelAudioIntro;
	public AudioSource levelAudioLoop;

	public AudioSource menuMusic;


	public static AudioManager mainInstance;

	void Awake()
    {

    }

	// Start is called before the first frame update
	void Start()
    {
		if (SceneController.getCurrentSceneIndex() == 0)
			StartCoroutine(PlayTitleScreenMusic());
		else if (SceneController.getCurrentSceneIndex() == 1)
			StartCoroutine(PlayGameMusic());

	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime, float targetVolume)
	{
		float startVolume = audioSource.volume;
		while (audioSource.volume > targetVolume)
		{
			audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
			yield return null;
		}
		audioSource.volume = targetVolume;
		audioSource.Stop();
	}

	public static IEnumerator FadeIn(AudioSource audioSource, float FadeTime, float targetVolume)
	{
		audioSource.Play();
		audioSource.volume = 0f;
		while (audioSource.volume < targetVolume)
		{
			audioSource.volume += Time.deltaTime / FadeTime;
			yield return null;
		}
		audioSource.volume = targetVolume;
	}

	public IEnumerator PlayGameMusic()
    {
		levelAudioIntro.volume = 0.0f;
		levelAudioLoop.clip.LoadAudioData();
		levelAudioIntro.clip.LoadAudioData();
		levelAudioIntro.PlayDelayed(2.0f);
		yield return new WaitForSeconds(2.0f);
		IEnumerator fadeInRoutine = FadeIn(levelAudioIntro, 7f, 0.5f);
		StartCoroutine(fadeInRoutine);
		yield return new WaitForSeconds(levelAudioIntro.clip.length - 0.1f);
		levelAudioLoop.volume = 0.5f;
		levelAudioLoop.Play();

	}

	public IEnumerator PlayTitleScreenMusic()
    {
		menuMusic.volume = 0.0f;
		menuMusic.clip.LoadAudioData();
		menuMusic.PlayDelayed(2.0f);
		yield return new WaitForSeconds(1.0f);
		IEnumerator fadeInRoutine = FadeIn(menuMusic, 3f, 0.5f);
		StartCoroutine(fadeInRoutine);
	}
}
