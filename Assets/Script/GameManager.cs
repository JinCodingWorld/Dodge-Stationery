using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;
    public Text timeText;
    public Text recordText;
    public Text yourRecord;
    public AudioClip schoolbell;
    public AudioClip gameover;
    public AudioSource audio;
    public GameObject backgroundMusic;
    //public BookSpawner bookSpawner;

    float surviveTime;
    bool isGameover;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        surviveTime = 0;
        isGameover = false;
        audio.PlayOneShot(schoolbell);
    }

    public void EndGame()
    {
        isGameover = true;
        audio.PlayOneShot(gameover);
        // ��� ���� stop
        backgroundMusic.SetActive(false);
        gameoverText.SetActive(true);

        // ���� ������ �ð� ���
        yourRecord.text = "Your Record : " + (int)surviveTime;

        // ���� �� �ı��ϱ�
        //bookSpawner.bookprefab.SetActive(false);
        //bookSpawner.Unitybookprefab.SetActive(false);
        //bookSpawner.Unrealbookprefab.SetActive(false);


        float b = PlayerPrefs.GetFloat("BestTime");
        if(surviveTime > b)
        {
            b = surviveTime;
            PlayerPrefs.SetFloat("BestTime", b);
        }
        recordText.text = "Best Time: " + (int)b;
    }

    public void Retry()
    {
        SceneManager.LoadScene(2);  // Retry ��ư ����� ���� ����
    }

    public void GoBack()
    {
        SceneManager.LoadScene(0);  // Retry ��ư ����� ���� ����
    }
    void Update()
    {   
        if(!isGameover)
        {
            surviveTime += Time.deltaTime;
            timeText.text = "Time: " + (int)surviveTime; // �̰� �����ΰ�??
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
