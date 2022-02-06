using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    public Movement movement;
    public GameObject WinScreen;
    public GameObject Button;
    public Coal coal;

    void Start()
    {
        Button btn = Button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        coal.NextLevel();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Coal coal))
        {
            coal.OnCoalReachedFinish();
            WinScreen.SetActive(true);
        }
    }
}
