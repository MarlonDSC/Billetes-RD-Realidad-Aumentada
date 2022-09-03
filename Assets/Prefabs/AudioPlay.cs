using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    public AudioClip miAudio;
    public Camera miCamara;

    void iniciarSonido()
    {
        AudioSource.PlayClipAtPoint(miAudio, miCamara.transform.position, 0.5f);
    }
}
