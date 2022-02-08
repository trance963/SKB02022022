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
    public GameObject ExitMenu;
    public GameObject ExitWin;
    public GameObject ExitLose;
    public GameObject StartGameUI;
    public GameObject ThisLVL;
    public GameObject CurrentSpeed;

    public enum State // игровые состояния
    {
        Playing,
        Won,
        Loss,
    }

    public State CurrentState { get; private set; }

    void Start()
    {
        Button btn = Restart.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClickRestart); // слушатель
        Button btn1 = NextLVL.GetComponent<Button>();
        btn1.onClick.AddListener(NextLevel); //слушатель
        Button btn2 = StartGame.GetComponent<Button>();
        btn2.onClick.AddListener(TaskOnClickStartGame); // слушатель
        Button btn4 = ExitWin.GetComponent<Button>();
        btn4.onClick.AddListener(TaskOnClickExit); //слушатель
        Button btn5 = ExitLose.GetComponent<Button>();
        btn5.onClick.AddListener(TaskOnClickExit); //слушатель
    }

    public void OnCoalDied() // метод смерти
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Loss;
        Controls.enabled = false;
        Debug.Log("GameOver!");
        Controls.rb.constraints = RigidbodyConstraints.FreezeAll;
        LoseScreen.SetActive(true);
    }

    public void OnCoalReachedFinish() // метод финиша
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Won;
        Controls.enabled = false;
        Debug.Log("YouWon!");
        Controls.rb.constraints = RigidbodyConstraints.FreezeAll;
        WinScreen.SetActive(true);
    }

    public void ReloadLevel() // перезагрузка сцены
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel() // новый уровень
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
        ThisLVL.SetActive(true);
        CurrentSpeed.SetActive(true);
        Controls.enabled = true;
        Rigidbody.constraints = RigidbodyConstraints.None;
        Rigidbody.freezeRotation = enabled;
    }

    private void TaskOnClickExit()
    {
        Debug.Log("Exit pressed!");
        Application.Quit();
    }
}


