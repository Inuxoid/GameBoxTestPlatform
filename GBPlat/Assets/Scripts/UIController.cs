using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI HP;
    [SerializeField] private TextMeshProUGUI Score;
    [SerializeField] private CharacterController2D controller;

    public void UIUpdate()
    {
        HP.text = controller.HP.ToString();
        Score.text = controller.Score.ToString();
    }
}
