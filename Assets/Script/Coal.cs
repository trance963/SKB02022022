using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Coal : MonoBehaviour

{
    public Rigidbody Rigidbody;
    public Movement Controls;

    public enum State
    {
        Playing,
        Won,
        Loss,
    }

    public State CurrentState { get; private set; }

    public void OnCoalDied()
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Loss;
        Controls.enabled = false;
        Debug.Log("GameOver!");
        Controls.rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    public void OnCoalReachedFinish()
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Won;
        Controls.enabled = false;
        Debug.Log("YouWon!");
        Controls.rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 2) SceneManager.LoadScene(0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
