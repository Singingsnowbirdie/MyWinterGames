using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MakingSnow : MonoBehaviour
{
    [SerializeField] GameObject bcgrdPanel;
    [SerializeField] GameObject bcgroundMusik;
    [SerializeField] AudioSource bttnClick;
    [SerializeField] AudioSource snowSound;

    AudioSource currentMusik;
    Vector3 mousePos;
    Canvas canvas;

    void Awake()
    {
        canvas = FindObjectOfType<Canvas>();
    }

    void Start()
    {
        PlayMusic();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            if (mousePos.x < -8)
            {
                if (mousePos.y < -3 || mousePos.y > 3)
                {
                    Debug.Log(mousePos);
                }
                else
                {
                    MakeSnowflake();
                }
            }
            else
            {
                MakeSnowflake();
            }
        }
    }

    public void MakeSnowflake()
    {
        int i = Random.Range(1, 10);
        GameObject snowflake = Resources.Load<GameObject>("Prefabs/Snowflakes/Snowflake " + i);
        GameObject newSnowFlake = Instantiate(snowflake) as GameObject;
        newSnowFlake.transform.SetParent(canvas.transform.GetChild(1), false);
        newSnowFlake.transform.position = mousePos;
        snowSound.Play();
    }


    public void HomeBttn()
    {
        SceneManager.LoadScene(0);
    }

    public void ChangeBcgrdBttn()
    {
        bttnClick.Play();
        bcgrdPanel.transform.GetChild(0).transform.SetAsLastSibling();
    }

    public void PlayMusic()
    {
        int i = Random.Range(0, 2);
        currentMusik = bcgroundMusik.transform.GetChild(i).GetComponent<AudioSource>();
        currentMusik.Play();
    }
}
