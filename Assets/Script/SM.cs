using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SM : MonoBehaviour
{
    public GameObject ExitMenu;
    public Coal coal;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = ExitMenu.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClickExit); // слушатель
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void TaskOnClickExit()
    {
        Debug.Log("Exit pressed!");
        Application.Quit();
    }
}
