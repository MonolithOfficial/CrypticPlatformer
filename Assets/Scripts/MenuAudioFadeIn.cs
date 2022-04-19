using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuAudioFadeIn : MonoBehaviour
{
    private AudioSource audioSrc;
    [SerializeField] private Slider slider = null;
    // Start is called before the first frame update

    private void Awake()
    {
        Time.timeScale = 1;
        audioSrc = GetComponent<AudioSource>();
        slider.value = 0.5f;
        //StartCoroutine(StartFade(audioSrc, 2f, 0.7f));
        DontDestroyOnLoad(gameObject);
    }

    public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }

    public void volumeSlider()
    {
        audioSrc.volume = slider.value;
    }
}
