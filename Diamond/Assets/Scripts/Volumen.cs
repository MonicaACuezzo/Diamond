using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class Volumen : MonoBehaviour
{

    public AudioMixer audioControl;

    public void VolumenControl(float sliderValue)
    {
        //Debug.Log(sliderValue);
        audioControl.SetFloat("VolumenAudio", Mathf.Log10(sliderValue) * 20);
    }

}

