using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;

    private float timer = 0;

    private void Update()
    {
        timer += Time.deltaTime;
        timerText.text = ((int)timer).ToString();
    }
}
