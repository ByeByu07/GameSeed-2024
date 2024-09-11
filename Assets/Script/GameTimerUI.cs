using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimerUI : MonoBehaviour
{
    [SerializeField] private Image imageTimer;

    void Update()
    {
        imageTimer.fillAmount = GameHandler.Instance.GetCurrentRestTimerNormalized();        
    }
}
