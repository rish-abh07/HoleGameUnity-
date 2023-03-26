using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayerTimer : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private int timerDuration;
    private int timer;
    private bool timerIsOn;

    [Header(" Events ")]
    public static Action OntimerOver;
    // Start is called before the first frame update
    void Start()
    {
        Initiliazed();

        GameManager.onStateChanged += GameStateChangedCallBack;
    }
    private void OnDestroy()
    {
        GameManager.onStateChanged -= GameStateChangedCallBack;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void GameStateChangedCallBack(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.GAME:
                StartTimer();
                break;
        }
    }
    public void Initiliazed()
    {
        timer = timerDuration;
        timerText.text = FormatSeconds(timer);
    }
    public void StartTimer()
    {
        if(timerIsOn)
        {
          //  Debug.LogWarning("A timer is Already on ");
            return;
        }
        Initiliazed();
        timerIsOn = true;
        StartCoroutine(TimerCoroutine());
    }
    IEnumerator TimerCoroutine()
    {

        while(timerIsOn)
        {
            yield return new WaitForSeconds(1);

            timer--;
            timerText.text = FormatSeconds(timer);

            if(timer == 0)
            {
                timerIsOn = false;
                StopTimer();
            }
        }
    }

    public void StopTimer()
    {
      //  Debug.Log(" Timer is Over ");
        OntimerOver?.Invoke();
    }
    private string FormatSeconds(int seconds)
    {
        int minutes = seconds / 60;
        int second = seconds % 60;

        return minutes.ToString("D2") + ":" + second.ToString("D2");
    }
}
