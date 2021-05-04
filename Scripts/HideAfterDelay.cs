﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideAfterDelay : MonoBehaviour
{
    public float delayInSeconds = 5f;
    public float fadeRate = .25f;

    private CanvasGroup canvasGroup;
    private float startTimer;
    private float fadeoutTimer;

    private void OnEnable()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1f;

        startTimer = Time.time + delayInSeconds;
        fadeoutTimer = fadeRate;
    }

    // Update is called once per frame
    void Update()
    {
        // time to fade out?
        if (Time.time >= startTimer)
        {
            fadeoutTimer -= Time.deltaTime;

            // fade out complete?
            if (fadeoutTimer <= 0)
            {
                gameObject.SetActive(false);
            }
            else
            {
                // reduce the alpha value
                canvasGroup.alpha = fadeoutTimer / fadeRate;
            }
        }
    }
}
