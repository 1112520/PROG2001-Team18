using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Control_Slider : MonoBehaviour
{
    private Slider loadingSlider;
    private Sequence seq;
    private void Awake()
    {
        loadingSlider = GetComponent<Slider>();
        
    }
    void Start()
    {
        loadingSlider.value = 0;
        seq = DOTween.Sequence();
        seq.Append(loadingSlider.DOValue(1f, 5f).SetEase(Ease.Linear));
        seq.OnComplete(()=>
        {
            transform.gameObject.SetActive(false);
            Debug.Log("≤‚ ‘");
        });
        //seq.Append(loadingSlider.DOValue(0.5f, 10f).SetEase(Ease.Linear));
       // seq.Append(loadingSlider.DOValue(0.9f, 60f).SetEase(Ease.OutCubic));
        //seq.Append(loadingSlider.DOValue(1f, 30f).SetEase(Ease.Linear));

    }

    // Update is called once per frame


 
}
