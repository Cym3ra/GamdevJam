using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartText : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI startText;


    private void Start()
    {
        startText.text = string.Format("I must find a way out of here. Hopefully the drone can help me");
    }

    IEnumerator ClearStartText()
    {
        yield return new WaitForSeconds(10);
        startText.text = string.Format("");
    }
}
