using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class OptionsScreen : MonoBehaviour
{

    public Toggle fullscreenTog, vsyncTog;

    public List<ResItem> resolutions = new List<ResItem>();
    private int selectedResolution;

    public TMP_Text resolutionLabel;

    public AudioMixer theMixer;

    public TMP_Text masterLabel, musicLabel, sfxLabel;
    public Slider masterSlider, musicSlider, sfxSlider;

    // Start is called before the first frame update
    void Start()
    {
        fullscreenTog.isOn = Screen.fullScreen;

        if (QualitySettings.vSyncCount == 0) {
            vsyncTog.isOn = false;
        } else {
            vsyncTog.isOn = true;
        }

        bool foundResolution = false;
        for (int i = 0; i < resolutions.Count; i++){
            if (Screen.width == resolutions[i].horizontal && Screen.height == resolutions[i].vertical) {
                foundResolution = true;

                selectedResolution = i;

                UpdateResLabel();
            }
        }

        if (!foundResolution) {
            ResItem newRes = new ResItem();
            newRes.horizontal = Screen.width;
            newRes.vertical = Screen.height;

            resolutions.Add(newRes);
            selectedResolution = resolutions.Count - 1;

            UpdateResLabel();
        }

        float vol = 0f;
        theMixer.GetFloat("MasterVol", out vol);
        masterSlider.value = vol;
        masterLabel.text = Mathf.RoundToInt(masterSlider.value + 80).ToString();
        
        theMixer.GetFloat("MusicVol", out vol);
        musicSlider.value = vol;
        musicLabel.text = Mathf.RoundToInt(musicSlider.value + 80).ToString();
        
        theMixer.GetFloat("SFXVol", out vol);
        sfxSlider.value = vol;
        sfxLabel.text = Mathf.RoundToInt(sfxSlider.value + 80).ToString();

    }

    public void ResLeft() {
        selectedResolution--;
        if (selectedResolution < 0) {
            selectedResolution = 0;
        }

        UpdateResLabel();
    }

    public void ResRight() {
        selectedResolution++;
        if (selectedResolution > resolutions.Count - 1) {
            selectedResolution = resolutions.Count - 1;
        }

        UpdateResLabel();
    }

    public void UpdateResLabel() {
        resolutionLabel.text = resolutions[selectedResolution].horizontal.ToString() + " x " + resolutions[selectedResolution].vertical.ToString();
    }

    public void ApplyGraphics() {
        //Screen.fullScreen = fullscreenTog.isOn;
        if (vsyncTog.isOn) {
            QualitySettings.vSyncCount = 1;
        } else {
            QualitySettings.vSyncCount = 0;
        }

        Screen.SetResolution(resolutions[selectedResolution].horizontal, resolutions[selectedResolution].vertical, fullscreenTog.isOn);
    }

    public void SetMasterVolume() {
        masterLabel.text = Mathf.RoundToInt(masterSlider.value + 80).ToString();

        theMixer.SetFloat("MasterVol", masterSlider.value);
        PlayerPrefs.SetFloat("MasterVol", masterSlider.value);
    }
    public void SetMusicVolume() {
        musicLabel.text = Mathf.RoundToInt(musicSlider.value + 80).ToString();

        theMixer.SetFloat("MusicVol", musicSlider.value);
        PlayerPrefs.SetFloat("MusicVol", musicSlider.value);
    }
    public void SetSFXVolume() {
        sfxLabel.text = Mathf.RoundToInt(sfxSlider.value + 80).ToString();

        theMixer.SetFloat("SFXVol", sfxSlider.value);
        PlayerPrefs.SetFloat("SFXVol", sfxSlider.value);
    }
}

[System.Serializable]
public class ResItem {
    public int horizontal;
    public int vertical;
}