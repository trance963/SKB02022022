using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Coal : MonoBehaviour

{
    public Rigidbody Rigidbody;
    public Movement Controls;
    public GameObject LoseScreen;
    public GameObject WinScreen;
    public GameObject Restart;
    public GameObject NextLVL;
    public GameObject StartGame;
    public GameObject StartGameUI;
    public GameObject ThisLVL;
    public GameObject CurrentSpeed;
    public GameObject ExitBut;

    public enum State // ������� ���������
    {
        Playing,
        Won,
        Loss,
    }

    public State CurrentState { get; private set; }

    void Start()
    {
        Button btn = Restart.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClickRestart); // ���������
        Button btn1 = NextLVL.GetComponent<Button>();
        btn1.onClick.AddListener(NextLevel); //���������
        Button btn2 = StartGame.GetComponent<Button>();
        btn2.onClick.AddListener(TaskOnClickStartGame); // ���������
        Button btn3 = StartGame.GetComponent<Button>();
        btn3.onClick.AddListener(TaskOnClickStartGame); // ���������
        Button btn4 = ExitBut.GetComponent<Button>();
        btn4.onClick.AddListener(TaskOnClickExitGame); // ���������

    }

    private void TaskOnClickExitGame()
    {
        Debug.Log("Exit pressed!");
        Application.Quit();
    }

    public void OnCoalDied() // ����� ������
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Loss;
        Controls.enabled = false;
        Debug.Log("GameOver!");
        Controls.rb.constraints = RigidbodyConstraints.FreezeAll;
        LoseScreen.SetActive(true);
        ExitBut.SetActive(true);
    }

    public void OnCoalReachedFinish() // ����� ������
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Won;
        Controls.enabled = false;
        Debug.Log("YouWon!");
        Controls.rb.constraints = RigidbodyConstraints.FreezeAll;
        WinScreen.SetActive(true);
        ExitBut.SetActive(true);
    }

    public void ReloadLevel() // ������������ �����
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel() // ����� �������
    {
        LevelIndex++;
        ReloadLevel();
    }

    public void TaskOnClickRestart()
    {
        ReloadLevel(); 
    }

    public int LevelIndex
    {
        get => PlayerPrefs.GetInt(LevelIndexKey, 0);

        private set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }
    }
    private const string LevelIndexKey = "LevelIndex";

    public void TaskOnClickStartGame()
    {
        StartGameUI.SetActive(false);
        CurrentSpeed.SetActive(true);
        Controls.enabled = true;
        ExitBut.SetActive(false);
        Rigidbody.constraints = RigidbodyConstraints.None;
        Rigidbody.freezeRotation = enabled;
    }
}


