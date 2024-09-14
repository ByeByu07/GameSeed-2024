using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public enum GameState 
    {
        WaitingPlayer,
        WaitingCountDownTimer,
        DefensePeriod,
        Winner
    }

    public GameState State;

    public static GameHandler Instance { get; private set; }
    [SerializeField] private float gameTimer;
    [SerializeField] private float gameTimerMax = 300f;
    [SerializeField] private float dayAmount = 5f;
    private int dayCurrent = 0;
    private float gameTimerDivideDayAmount;
    private float gameTimerDivideDayAmountCurrent;
    [SerializeField] private float countDownToPlay = 20f;

    // UI
    [SerializeField] private Transform mainMenuCanvas;
    [SerializeField] private Transform modalTopTutorial;
    [SerializeField] private Button startButton;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private List<Button> quitButtons;
    [SerializeField] private Transform camPlayer;

    // Buildings
    [SerializeField] private Transform buildingsToShow;

    // Enemy
    [SerializeField] private Transform firstEnemy;

    public event Action OnTimerEnd;
    public event Action OnGameOver;
    public event EventHandler<OnDayChangedEventHandler> OnDayChanged;
    public class OnDayChangedEventHandler
    {
        public int day;
    }

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        State = GameState.WaitingPlayer;
        gameTimerDivideDayAmount = gameTimerMax / dayAmount;
        gameTimerDivideDayAmountCurrent = gameTimerDivideDayAmount;

        startButton.onClick.AddListener(() =>
        { 
            ChangeCamera();
            mainMenuCanvas.gameObject.SetActive(false);
            firstEnemy.gameObject.SetActive(true);
            Utility.CountDownWithCallback(this, 3f, () => modalTopTutorial.gameObject.SetActive(true));
            Utility.CountDownWithCallback(this, 10f, () => modalTopTutorial.GetComponent<ModalTopUI>().UpdateTextModal());
        });

        foreach (Button b in quitButtons)
        {
            b.onClick.AddListener(() =>
            {
                Application.Quit();
            });
        }

        restartButton.onClick.AddListener(() => { SceneManager.LoadScene(0); });
        resumeButton.onClick.AddListener(() => {
            mainMenuCanvas.gameObject.SetActive(false);
            Time.timeScale = 1;
        });

        GameInput.Instance.OnPauseAction += Instance_OnPauseAction;
    }

    private void Instance_OnPauseAction(object sender, EventArgs e)
    {
        if(Time.timeScale == 0)
        {
            mainMenuCanvas.gameObject.SetActive(false);
            Time.timeScale = 1;
        } else
        {
            mainMenuCanvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void Update()
    {
        switch (State)
        {
            case GameState.WaitingPlayer:
                break;
            case GameState.WaitingCountDownTimer:
                countDownToPlay -= Time.deltaTime;
                if(countDownToPlay < 0)
                {
                    State = GameState.DefensePeriod;
                }
                buildingsToShow.gameObject.SetActive(true);
                break;
            case GameState.DefensePeriod:

                if(gameTimer > gameTimerDivideDayAmountCurrent)
                {
                    gameTimerDivideDayAmountCurrent += gameTimerDivideDayAmount;
                    OnDayChanged?.Invoke(this, new OnDayChangedEventHandler { day = dayCurrent  });
                    dayCurrent++;
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

    public float GetCurrentRestTimerNormalized()
    {
        return gameTimer / gameTimerMax;
    }

    public void ChangeState(GameState gameState) {
        State = gameState;
    }

    public void ChangeSeed(Transform t)
    {
        GameAssets.Instance.seed = t;
    }

    private void ChangeCamera()
    {
        if (camPlayer.gameObject.activeInHierarchy)
        {
            camPlayer.gameObject.SetActive(false);
        } else
        {
            camPlayer.gameObject.SetActive(true);
        }
    }
}
