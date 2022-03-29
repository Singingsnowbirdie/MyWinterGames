using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DressUpSanta : MonoBehaviour
{
    [SerializeField] GameObject hatsPanel;
    [SerializeField] GameObject nosesPanel;
    [SerializeField] GameObject mouthsPanel;
    [SerializeField] GameObject beardsPanel;
    [SerializeField] GameObject bcgrdPanel;
    [SerializeField] GameObject bcgroundMusik;
    [SerializeField] AudioSource bttnClick;

    AudioSource currentMusik;

    void Start()
    {
        PlayMusic();
    }

    public void LeftBttn1()
    {
        bttnClick.Play();
        hatsPanel.transform.GetChild(4).transform.SetAsFirstSibling();
    }
    public void LeftBttn2()
    {
        bttnClick.Play();
        nosesPanel.transform.GetChild(3).transform.SetAsFirstSibling();
    }
    public void LeftBttn3()
    {
        bttnClick.Play();
        mouthsPanel.transform.GetChild(3).transform.SetAsFirstSibling();
    }
    public void LeftBttn4()
    {
        bttnClick.Play();
        beardsPanel.transform.GetChild(3).transform.SetAsFirstSibling();
    }

    public void LeftBttn5()
    {
        bttnClick.Play();
        bcgrdPanel.transform.GetChild(2).transform.SetAsFirstSibling();
    }

    public void RightBttn1()
    {
        bttnClick.Play();
        hatsPanel.transform.GetChild(0).transform.SetAsLastSibling();
    }
    public void RightBttn2()
    {
        bttnClick.Play();
        nosesPanel.transform.GetChild(0).transform.SetAsLastSibling();
    }
    public void RightBttn3()
    {
        bttnClick.Play();
        mouthsPanel.transform.GetChild(0).transform.SetAsLastSibling();
    }
    public void RightBttn4()
    {
        bttnClick.Play();
        beardsPanel.transform.GetChild(0).transform.SetAsLastSibling();
    }
    public void RightBttn5()
    {
        bttnClick.Play();
        bcgrdPanel.transform.GetChild(0).transform.SetAsLastSibling();
    }

    public void HomeBttn()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayMusic()
    {
        int i = Random.Range(0, 2);
        currentMusik = bcgroundMusik.transform.GetChild(i).GetComponent<AudioSource>();
        currentMusik.Play();
    }


}
