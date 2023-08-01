using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPlaceHandler : MonoBehaviour
{
    [SerializeField]
    private Button _nameOfButton;
    [SerializeField]
    private string _buttonText;
    public void SetText(string text)
    {
        Text txt = transform.Find(_buttonText).GetComponent<Text>();
        txt.text = text;
    }
}
