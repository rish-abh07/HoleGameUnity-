using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class PlayerSize : MonoBehaviour
{
    [Header(" Setings ")]
    [SerializeField] private Image fillImage; 
    private float scaleValue;
    [SerializeField]private float scaleIncreaseThreshold;
    [SerializeField] private float scaleStep;
  ///  internal static Action<float> onIncrease;

    [Header(" Events ")]
   public static Action<float> onIncrease;

    // Start is called before the first frame update
    void Start()
    {
        fillImage.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void IncreaseScale()
    {
        float tragetScale = transform.localScale.x + scaleStep;
        LeanTween.scale(transform.gameObject, tragetScale * Vector3.one, .2f * Time.deltaTime * 60).setEase(LeanTweenType.easeInOutBack);//we can use animation curve just by ka word private AnimationCurve curve then set it in the unity editor
        //   transform.localScale += scaleStep * Vector3.one;
        onIncrease?.Invoke(tragetScale);
    }
    public void Collectibles(float objectSize)
    {
        scaleValue += objectSize;
        if (scaleValue >= scaleIncreaseThreshold)
        {
            IncreaseScale();
            scaleValue = scaleValue % scaleIncreaseThreshold;
      //Threshold = 8
        }
        updateFillDisplay();
    }
    private void updateFillDisplay()
    {
        float targetFillAmount = scaleValue / scaleIncreaseThreshold;
        LeanTween.value(fillImage.fillAmount, targetFillAmount, .2f * Time.deltaTime * 60).setOnUpdate((value) => fillImage.fillAmount = value);
      
       
    }
   
}
