using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseOrPlay : MonoBehaviour
{
    private Button btn_pause;
    private Button btn_audio;
    private Button btn_Return;
    bool isPause = false;

    private void Awake()
    {
        btn_pause = transform.Find("btn_Pause").GetComponent<Button>();
        btn_audio = transform.Find("btn_Audio").GetComponent<Button>();
        btn_Return = transform.Find("btn_Return").GetComponent<Button>();
        btn_pause.onClick.AddListener(PauseGame);
        btn_Return.onClick.AddListener(RetrunGame);
        isPause = false;

        btn_audio.onClick.AddListener(PauseAudio);
        if (AudioListener.pause)
        {
            btn_audio.transform.Find("”–…˘“Ù").gameObject.SetActive(false);
            btn_audio.transform.Find("æ≤“Ù").gameObject.SetActive(true);
        }
        else
        {
            btn_audio.transform.Find("”–…˘“Ù").gameObject.SetActive(true);
            btn_audio.transform.Find("æ≤“Ù").gameObject.SetActive(false);
        }
    }

    private void RetrunGame()
    {
        SceneManager.LoadScene("Menu"); 
    }

    private void Start()
    {

    }
    public void PauseAudio()
    {
        Debug.Log("1111");
        if (AudioListener.pause)
        {
            AudioListener.pause = false;
            btn_audio.transform.Find("”–…˘“Ù").gameObject.SetActive(true);
            btn_audio.transform.Find("æ≤“Ù").gameObject.SetActive(false);
        }
        else
        {
            AudioListener.pause = true;
            btn_audio.transform.Find("”–…˘“Ù").gameObject.SetActive(false);
            btn_audio.transform.Find("æ≤“Ù").gameObject.SetActive(true);
        }
    }

    public void PauseGame()
    {
        Debug.Log("2222");
        isPause = !isPause;
        if (isPause)
        {
            Time.timeScale = 0;
            btn_pause.transform.Find("‘›Õ£÷–").gameObject.SetActive(true);
            btn_pause.transform.Find("≤•∑≈÷–").gameObject.SetActive(false);
        }
        else
        {
            Time.timeScale = 1;
            btn_pause.transform.Find("‘›Õ£÷–").gameObject.SetActive(false);
            btn_pause.transform.Find("≤•∑≈÷–").gameObject.SetActive(true);
        }
    }
}
