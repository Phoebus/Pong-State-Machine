using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InstructionText : MonoBehaviour
{
    TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        StartCoroutine(blink());
    }

    IEnumerator blink()
    {
        bool on = false;

        while(true)
        {
            if(on)
            {
                text.alpha = 0f;
                on = false;
            } else {
                text.alpha = 1f;
                on = true;
            }
            yield return new WaitForSeconds(0.7f);
        }
    }
}
