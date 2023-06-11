using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownn : MonoBehaviour
{
    [SerializeField] float duration;
    [SerializeField] Image cooldownImage;

    
    void Start()
    {
        cooldownImage.fillAmount = 0;
    }

    
    void Update()
    {
        Timer();
    }

    void Timer()
    {
        if (Movement.dashed)
        {
            duration -= Time.deltaTime;

            cooldownImage.fillAmount = Mathf.InverseLerp(2.5f, 0, duration);
        }

        else
        {
            cooldownImage.fillAmount = 0f;
            duration = 2.5f;
        }
    }
}
