using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public enum GameState 
    {
        WaitingCountDownTimer,
        DefensePeriod,
        Winner
    }

    public GameState State;

    public static GameHandler Instance { get; private set; }
    [SerializeField] private float gameTimer;
    [SerializeField] private float gameTimerMax = 300f;
    [SerializeField] private float dayAmount = 5f;
    private float gameTimerDivideDayAmount;
    private float gameTimerDivideDayAmountCurrent;
    [SerializeField] private float countDownToPlay = 20f;

    public event Action OnTimerEnd;
    public event Action OnGameOver;
    public event EventHandler<OnDayChangedEventHandler> OnDayChanged;
    public class OnDayChangedEventHandler
    {
        public float day;
    }

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        State = GameState.WaitingCountDownTimer;
        gameTimerDivideDayAmount = gameTimerMax / dayAmount;
        gameTimerDivideDayAmountCurrent = gameTimerDivideDayAmount;
    }

    private void Update()
    {
        switch (State)
        {
            case GameState.WaitingCountDownTimer:
                countDownToPlay -= Time.deltaTime;
                if(countDownToPlay < 0)
                {
                    State = GameState.DefensePeriod;
                }
                break;
            case GameState.DefensePeriod:

                if(gameTimer > gameTimerDivideDayAmountCurrent)
                {
                    gameTimerDivideDayAmountCurrent += gameTimerDivideDayAmount;
                    OnDayChanged?.Invoke(this, new OnDayChangedEventHandler { day = gameTimer / gameTimerDivideDayAmount  });
                }

                gameTimer += Time.deltaTime;
                if(gameTimer > gameTimerMax)
                {
                    State = GameState.Winner;
                }
                break; 
            case GameState.Winner:
                OnTimerEnd?.Invoke();
                break;
        }
    }
}
