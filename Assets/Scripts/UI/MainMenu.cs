using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Slider _masterVolumeSlider, _musicVolumeSlider, _SFXVolumeSlider;
    [SerializeField] private AudioClip _buttonClick, _menuOST;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //SoundManager.Instance.PlaySingleMusic(_menuOST);
        _masterVolumeSlider.value = SoundManager.Instance.GetVolumeFromMixer("master");
        _musicVolumeSlider.value = SoundManager.Instance.GetVolumeFromMixer("music");
        _SFXVolumeSlider.value = SoundManager.Instance.GetVolumeFromMixer("SFX");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AdjustVolume(string type)
    {
        switch (type)
        {
            case "master":
                SoundManager.Instance.ChangeMasterVolume(_masterVolumeSlider.value);
                break;
            case "music":
                SoundManager.Instance.ChangeMusicVolume(_musicVolumeSlider.value);
                break;
            case "SFX":
                SoundManager.Instance.ChangeSFXVolume(_SFXVolumeSlider.value);
                break;
            default:
                //String incompativel
                break;
        }
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void MenuClickSFX()
    {
        SoundManager.Instance.PlaySFX(_buttonClick);
    }
}
