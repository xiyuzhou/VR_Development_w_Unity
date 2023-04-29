using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class UIManager : MonoBehaviour
{

    public Light DirectionalLight;
    public Volume GlobalVolume;

    public Button LightButton;
    public Button VolumeButton;
    private bool LightButtonBool = true;
    private bool VolumeButtonBool = true;

    public Sprite LightOn;
    public Sprite LightOff;

    public Sprite VolumeOn;
    public Sprite VolumeOff;

    public Slider brightness;
    public Slider PostVolume;

    private float cacheLight;
    private float cacheVolume;

    void Start()
    {
        cacheLight = RenderSettings.ambientIntensity;
    }

    public void IntensityChange(float value)
    {
        RenderSettings.ambientIntensity = value;
        cacheLight = value;
        //DirectionalLight.intensity = value;
    }

    public void VolumeChange(float value)
    {
        GlobalVolume.weight = value;
        cacheVolume = value;
    }

    public void lightButtonPressed()
    {
        LightButtonBool = !LightButtonBool;
        if (LightButtonBool)
        {
            LightButton.GetComponent<Image>().sprite = LightOn;
            RenderSettings.ambientIntensity = cacheLight;
        }
        else
        {
            LightButton.GetComponent<Image>().sprite = LightOff;
            RenderSettings.ambientIntensity = 0f;
        }
    }

    public void volumeButtonPressed()
    {
        VolumeButtonBool = !VolumeButtonBool;
        if (VolumeButtonBool)
        {
            VolumeButton.GetComponent<Image>().sprite = VolumeOn;
            GlobalVolume.weight = cacheVolume;
        }
        else
        {
            VolumeButton.GetComponent<Image>().sprite = VolumeOff;
            GlobalVolume.weight = 0;
        }
    }
    public void resetAll()
    {
        if (!LightButtonBool)
        {
            lightButtonPressed();
        }
        if (!VolumeButtonBool)
        {
            volumeButtonPressed();
        }
        brightness.value = 1f;
        PostVolume.value = 0.2f;


    }

}
