using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    public GameObject settingUI;
    public CameraBobbing CameraBobbing;

    public Slider camBobSlider;

    // Start is called before the first frame update
    void Start()
    {
        settingUI.SetActive(false);
        CameraBobbing.BobbingSpeed = camBobSlider.value;
        camBobSlider.onValueChanged.AddListener(OnCamBobSliderChange);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (settingUI.activeSelf == false)
            {
                ShowSettings();
            }
            else
            {
                HideSettings();
            }
        }

        if (settingUI.activeSelf == true)
        {
            Time.timeScale = 0f;
            if (CameraBobbing != null)
            {
                CameraBobbing.doBob = false;
            }
        }
        else
        {
            Time.timeScale = 1f;
            if (CameraBobbing != null)
            {
                CameraBobbing.doBob = true;
            }
        }
    }

    public void ShowSettings()
    {
        settingUI.SetActive(true);
    }

    public void HideSettings()
    {
        settingUI.SetActive(false);
    }

    void OnCamBobSliderChange(float value)
    {
        CameraBobbing.BobbingSpeed = value;
        Debug.Log(value);
    }
}
