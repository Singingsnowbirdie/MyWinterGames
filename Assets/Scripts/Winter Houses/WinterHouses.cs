using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinterHouses : MonoBehaviour
{
    [SerializeField] GameObject bcgroundMusik;
    [SerializeField] GameObject contentPanel;
    [SerializeField] AudioSource bttnClick;
    [SerializeField] AudioSource placeItem;

    AudioSource currentMusik;

    GameObject house1;
    GameObject house2;
    GameObject house3;
    GameObject thisObj;

    Canvas canvas;

    public AudioSource PlaceItem { get => placeItem; set => placeItem = value; }
    public AudioSource BttnClick { get => bttnClick; set => bttnClick = value; }

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>();
    }
    void Start()
    {
        house1 = Resources.Load("Prefabs/Winter Houses/House 1") as GameObject;
        house2 = Resources.Load("Prefabs/Winter Houses/House 2") as GameObject;
        house3 = Resources.Load("Prefabs/Winter Houses/House 3") as GameObject;

        thisObj = contentPanel.transform.GetChild(1).gameObject;

        PlayMusic();
    }

    public void HomeBttn()
    {
        SceneManager.LoadScene(0);
    }

    public void Bttn1()
    {
        BttnClick.Play();
        Destroy(thisObj);
        thisObj = Instantiate(house1);
        thisObj.transform.SetParent(contentPanel.transform, false);
    }

    public void Bttn2()
    {
        BttnClick.Play();
        Destroy(thisObj);
        thisObj = Instantiate(house2);
        thisObj.transform.SetParent(contentPanel.transform, false);
    }

    public void Bttn3()
    {
        BttnClick.Play();
        Destroy(thisObj);
        thisObj = Instantiate(house3);
        thisObj.transform.SetParent(contentPanel.transform, false);
    }

    public void PlayMusic()
    {
        int i = Random.Range(0, 2);
        currentMusik = bcgroundMusik.transform.GetChild(i).GetComponent<AudioSource>();
        currentMusik.Play();
    }

}
