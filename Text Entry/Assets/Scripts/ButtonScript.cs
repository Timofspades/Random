using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    [SerializeField]
    private Text gameText;

    [SerializeField]
    private InputField inputText;
    public void ButtonClick()
    {
        if (inputText.text == "") {
            gameText.text = "Hello World!";
        }else{
            gameText.text = "Hello " + inputText.text;
        }
    }
}
