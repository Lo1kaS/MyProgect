using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    [SerializeField]
    private GameObject VideoSettings;
    [SerializeField]
    private GameObject ControlSettings;
    [SerializeField]
    private GameObject AudioSettings;
    void Start()
    {
        VideoSettings.SetActive(false);
        ControlSettings.SetActive(false);
        AudioSettings.SetActive(false);
    }
    public void ShowVideoSettings()
    {
        VideoSettings.SetActive(true);
        ControlSettings.SetActive(false);
        AudioSettings.SetActive(false);
    }
    public void ShowControlSettings()
    {
        VideoSettings.SetActive(false);
        ControlSettings.SetActive(true);
        AudioSettings.SetActive(false);
    }
    public void ShowAudioSettings()
    {
        VideoSettings.SetActive(false);
        ControlSettings.SetActive(false);
        AudioSettings.SetActive(true);
    }
}
