using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility : MonoBehaviour
{
    public static Vector3 MouseToTerrainPosition()
    {
        Vector3 position = Vector3.zero;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit info, 100, LayerMask.GetMask("Ground")))
            position = info.point;
        return position;
    }

    public static void CountDownWithCallback(MonoBehaviour monoBehaviour, float duration, Action callback)
    {
        monoBehaviour.StartCoroutine(CountDownCoroutine(duration,callback));
    }

    //public static void CountDownWithCallback(MonoBehaviour monoBehaviour, float duration, EventHandler callback)
    //{
    //    monoBehaviour.StartCoroutine(CountDownCoroutine(duration, callback));
    //}

    private static IEnumerator CountDownCoroutine(float duration, Action callback)
    {
        float timeLeft = duration;

        while (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            yield return null;
        }

        callback?.Invoke();
    }

    //private static IEnumerator CountDownCoroutine(float duration, EventHandler callback, EventArgs)
    //{
    //    float timeLeft = duration;

    //    while (timeLeft > 0)
    //    {
    //        timeLeft -= Time.deltaTime;
    //        yield return null;
    //    }

    //    callback?.Invoke();
    //}
}
