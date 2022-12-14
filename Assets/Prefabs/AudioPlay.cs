using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof(AudioSource))]
public class AudioPlay : MonoBehaviour
{
    public AudioClip [] audioParaReproducir;
    public GameObject miModelo3D;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        //audioSource.clip = audioParaReproducir[0];

        audioSource.playOnAwake = false;
    }


    void iniciarSonido(AnimationEvent animationEvent)
    {
        int index = animationEvent.intParameter;
        audioSource.clip = audioParaReproducir[index];
        //AudioSource.PlayClipAtPoint(miAudio, miCamara.transform.position, 0.5f);

        audioSource.Play();
        if(miModelo3D.activeSelf != true)  audioSource.Stop();
    }
}
