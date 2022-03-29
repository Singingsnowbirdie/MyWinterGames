using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] Text selectLanguageText;
    [SerializeField] Text musikVolumeText;
    [SerializeField] Text soundsVolumeText;
    [SerializeField] Text musikToggleText;
    [SerializeField] Text soundsToggleText;

    [Header("Toggles")]
    [SerializeField] Toggle musicToggle;
    [SerializeField] Toggle soundsToggle;

    [Header("Sliders")]
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider soundsSlider;

    [Header("Audio")]
    [SerializeField] AudioMixerGroup mixer;
    [SerializeField] AudioSource bttnClick;

    TextAsset asset;
    XMLSettings UIelement;

    Credits credits;

    private void Awake()
    {
        credits = FindObjectOfType<Credits>();
    }

    void Start()
    {
        if (!PlayerPrefs.HasKey("MusikEnabled"))
        {
            PlayerPrefs.SetInt("MusikEnabled", 1);
        }
        if (!PlayerPrefs.HasKey("SoundsEnabled"))
        {
            PlayerPrefs.SetInt("SoundsEnabled", 1);
        }
        if (!PlayerPrefs.HasKey("MusikVolume"))
        {
            PlayerPrefs.SetFloat("MusikVolume", 1);
        }
        if (!PlayerPrefs.HasKey("SoundsVolume"))
        {
            PlayerPrefs.SetFloat("SoundsVolume", 1);
        }

        if (PlayerPrefs.GetInt("MusikEnabled") == 1)
        {
            musicSlider.value = PlayerPrefs.GetFloat("MusikVolume");
            musicToggle.isOn = true;
            mixer.audioMixer.SetFloat("MusikVol", Mathf.Log10(PlayerPrefs.GetFloat("MusikVolume")) * 20);
        }
        else if (PlayerPrefs.GetInt("MusikEnabled") == 0)
        {
            musicSlider.value = PlayerPrefs.GetFloat("MusikVolume");
            musicToggle.isOn = false;
            mixer.audioMixer.SetFloat("MusikVol", -80);
        }

        if (PlayerPrefs.GetInt("SoundsEnabled") == 1)
        {
            soundsSlider.value = PlayerPrefs.GetFloat("SoundsVolume");
            soundsToggle.isOn = true;
            mixer.audioMixer.SetFloat("SoundsVol", Mathf.Log10(PlayerPrefs.GetFloat("SoundsVolume")) * 20);
        }
        else if (PlayerPrefs.GetInt("SoundsEnabled") == 0)
        {
            soundsSlider.value = PlayerPrefs.GetFloat("SoundsVolume");
            soundsToggle.isOn = false;
            mixer.audioMixer.SetFloat("SoundsVol", -80);
        }
        CheckLanguage();
    }
    public void SetRusBttn()
    {
        bttnClick.Play();
        LocalizationManager.currentLanguage = "ru_RU";
        PlayerPrefs.SetString("Language", "ru_RU");
        CheckLanguage();
        credits.CheckLanguage();
    }
    public void SetEngBttn()
    {
        bttnClick.Play();
        LocalizationManager.currentLanguage = "en_US";
        PlayerPrefs.SetString("Language", "en_US");
        CheckLanguage();
        credits.CheckLanguage();
    }
    void CheckLanguage()
    {
        asset = Resources.Load<TextAsset>("Localization/" + LocalizationManager.currentLanguage + "/Options");
        UIelement = XMLSettings.Load(asset);

        selectLanguageText.text = UIelement.UIelements[0].text;
        musikVolumeText.text = UIelement.UIelements[1].text;
        soundsVolumeText.text = UIelement.UIelements[2].text;
        musikToggleText.text = UIelement.UIelements[3].text;
        soundsToggleText.text = UIelement.UIelements[4].text;
    }
    public void MusikToggle(bool enabled)
    {
        bttnClick.Play();
        if (enabled)
        {
            mixer.audioMixer.SetFloat("MusikVol", PlayerPrefs.GetFloat("MusikVolume"));
        }
        else
        {
            mixer.audioMixer.SetFloat("MusikVol", -80);
        }

        PlayerPrefs.SetInt("MusikEnabled", enabled ? 1 : 0);
        PlayerPrefs.Save();
    }
    public void SoundsToggle(bool enabled)
    {
        bttnClick.Play();
        if (enabled)
        {
            mixer.audioMixer.SetFloat("SoundsVol", PlayerPrefs.GetFloat("SoundsVolume"));
        }
        else
        {
            mixer.audioMixer.SetFloat("SoundsVol", -80);
        }

        PlayerPrefs.SetInt("SoundsEnabled", enabled ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void ChangeMusicVolume(float volume)
    {
        if (PlayerPrefs.GetInt("MusikEnabled") == 0)
        {
            PlayerPrefs.SetInt("MusikEnabled", 1);
            musicToggle.isOn = true;
        }
        mixer.audioMixer.SetFloat("MusikVol", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MusikVolume", volume);
        PlayerPrefs.Save();
    }

    public void ChangeSoundsVolume(float volume)
    {
        if (PlayerPrefs.GetInt("SoundsEnabled") == 0)
        {
            PlayerPrefs.SetInt("SoundsEnabled", 1);
            soundsToggle.isOn = true;
        }
        mixer.audioMixer.SetFloat("SoundsVol", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SoundsVolume", volume);
        PlayerPrefs.Save();
    }
}
