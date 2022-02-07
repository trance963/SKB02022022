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
}
