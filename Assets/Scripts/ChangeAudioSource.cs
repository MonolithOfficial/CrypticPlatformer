using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAudioSource : MonoBehaviour
{
    [SerializeField] AudioClip gameTheme;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeSound()
    {
        AudioSource audioManagerSrouce = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>();
        audioManagerSrouce.clip = gameTheme;
        audioManagerSrouce.Play();
    }
}
