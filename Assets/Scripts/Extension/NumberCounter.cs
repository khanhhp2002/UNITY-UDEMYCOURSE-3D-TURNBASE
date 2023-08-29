using System.Collections;
using TMPro;
using UnityEngine;

public class NumberCounter : Singleton<NumberCounter>
{
    public float CountFps = 30;
    public float Duration =2f;
    public string NumberFormat = "N0";
    private Coroutine CountingCorountine;

    private void Awake()
    {
        CountFps = 1/ Time.deltaTime;
    }

    private IEnumerator CountText(TMP_Text displayText, int oldValue, int newValue, string suffix)
    {
        Debug.Log(Duration);
        WaitForSeconds wait = new WaitForSeconds(1 / CountFps);
        int previousValue = oldValue;
        int stepAmount;
        if(newValue - previousValue < 0)
        {
            stepAmount = Mathf.FloorToInt((newValue - previousValue) / (CountFps * Duration));
        }
        else
        {
            stepAmount = Mathf.CeilToInt((newValue - previousValue) / (CountFps * Duration));
        }
        if(previousValue < newValue)
        {
            while(previousValue < newValue)
            {
                previousValue += stepAmount;
                if(previousValue > newValue)
                {
                    previousValue = newValue;
                }
                displayText.text = previousValue.ToString(NumberFormat).Replace(',', '.') + (suffix is null?"":suffix);
                yield return wait;
            }
        }
        else
        {
            while (previousValue > newValue)
            {
                previousValue += stepAmount;
                if (previousValue < newValue)
                {
                    previousValue = newValue;
                }
                displayText.text = previousValue.ToString(NumberFormat).Replace(',','.') + (suffix is null ? "" : suffix);
                yield return wait;
            }
        }
    }

    public void CountAnimation(TMP_Text input, int from, int to, string suffix = null)
    {
        if (CountingCorountine != null)
        {
            StopCoroutine(CountingCorountine);
        }
        StartCoroutine(CountText(input, from, to, suffix));
    }
}
