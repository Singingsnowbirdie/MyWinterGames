using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    [SerializeField] Text GameByText;
    [SerializeField] Text GamedevText;
    [SerializeField] Text MyNameText;
    [SerializeField] Text ArtistsText;
    [SerializeField] Text MusicText;
    [SerializeField] Text FontText;

    TextAsset asset;
    XMLSettings UIelement;

    void Start()
    {
        CheckLanguage();
    }

    public void FreepikBttn()
    {
        Application.OpenURL("http://www.freepik.com");
    }
    public void JanGernerBttn()
    {
        Application.OpenURL("http://www.yanone.de");
    }

    public void CheckLanguage()
    {
        asset = Resources.Load<TextAsset>("Localization/" + LocalizationManager.currentLanguage + "/Credits");
        UIelement = XMLSettings.Load(asset);

        GameByText.text = UIelement.UIelements[0].text;
        GamedevText.text = UIelement.UIelements[1].text;
        MyNameText.text = UIelement.UIelements[2].text;
        ArtistsText.text = UIelement.UIelements[3].text;
        MusicText.text = UIelement.UIelements[4].text;
        FontText.text = UIelement.UIelements[5].text;

    }

}
