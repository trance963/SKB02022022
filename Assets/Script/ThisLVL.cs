using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThisLVL : MonoBehaviour
{
    public Text Text;
    public Coal coal;

    private void Start()
    {
        Text.text = "Level " + (coal.LevelIndex + 1).ToString(); //получаем номер уровня
    }
}
