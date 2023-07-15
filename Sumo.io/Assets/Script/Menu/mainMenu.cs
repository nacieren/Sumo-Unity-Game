using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class mainMenu : MonoBehaviour
{
    public Animator animator;
    public GameObject startButton;
    public GameObject baþlangýç;
    public GameObject playerSayý;
    public float timeRemaining = 0;
    public GameObject karakter;
    public GameObject oyunÝçi;
    public GameObject süreBitti;
    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI playerScoreTextFinal;
    public TextMeshProUGUI timer;
    public TextMeshProUGUI player;
    private float time = 60;
    void Start()
    {
        startButton.SetActive(true);
        animator.SetBool("baþladý", false);
        baþlangýç.SetActive(false);
        Time.timeScale = 0;
        oyunÝçi.SetActive(false);
        süreBitti.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //UI Ekraný,bitiþler
        if (timeRemaining > 5)
        {
            baþlangýç.SetActive(false);
            timer.text = time.ToString();
            oyunÝçi.SetActive(true);
        }
        else timeRemaining += Time.deltaTime;
        time -= Time.deltaTime;
        playerScoreText.text = (karakter.GetComponent<karakterKontrolMobil>().puan-150).ToString();
        if (time<=0)
        {
            time = 0f;
            Time.timeScale = 0;
            playerScoreTextFinal.text= "Puanýnýz = "+(karakter.GetComponent<karakterKontrolMobil>().puan - 150).ToString();
            süreBitti.SetActive(true);
        }
    }
    //Oyunu baþlatan fonksiyon
    public void startGame()
    {
        animator.SetBool("baþladý", true);
        Time.timeScale = 1;
        startButton.SetActive(false);
        baþlangýç.SetActive(true);
    }
    public void yenidenOyna()
    {
        SceneManager.LoadScene(0);
    }
}
