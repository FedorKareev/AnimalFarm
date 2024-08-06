using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;

public class Discription : MonoBehaviour
{
    [SerializeField]
    private Text _discriptionText;
    [SerializeField]
    private Image _discriptionIcon;

    public void ShowDicription(Sprite discriptionIcon, string discriptionText)
    {
        _discriptionIcon.sprite = discriptionIcon;
        _discriptionText.text = discriptionText;
    }
}
