using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    [SerializeField] GameObject creditsPanel;
    [SerializeField] GameObject optionsPanel;
    [SerializeField] GameObject gameBttnsPanel;
    [SerializeField] GameObject bcgroundMusik;
    [SerializeField] AudioSource bttnClick;

    AudioSource currentMusik;

    void Start()
    {
        PlayMusic();
    }


    public void PressBttn1()
    {
        SceneManager.LoadScene(1);
    }
    public void PressBttn2()
    {
        SceneManager.LoadScene(2);
    }
    public void PressBttn3()
    {
        SceneManager.LoadScene(3);
    }
    public void PressBttn4()
    {
        SceneManager.LoadScene(4);
    }
    public void PressBttn5()
    {
        SceneManager.LoadScene(5);
    }

    public void CreditsBttn()
    {
        bttnClick.Play();
        creditsPanel.SetActive(true);
        optionsPanel.SetActive(false);
        gameBttnsPanel.SetActive(false);
    }
    public void OptionsBttn()
    {
        bttnClick.Play();
        optionsPanel.SetActive(true);
        gameBttnsPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }

    public void GamesMenuBttn()
    {
        bttnClick.Play();
        gameBttnsPanel.SetActive(true);
        optionsPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }

    public void PlayMusic()
    {
        int i = Random.Range(0, 2);
        currentMusik = bcgroundMusik.transform.GetChild(i).GetComponent<AudioSource>();
        currentMusik.Play();
    }
}
