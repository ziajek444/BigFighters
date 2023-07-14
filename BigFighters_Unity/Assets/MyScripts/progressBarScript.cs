using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class progressBarScript : MonoBehaviour
{

    private Image progressBarImg;
    private int progressStartOffset;
    private float mul = 10f;

    void Start()
    {
        progressBarImg = gameObject.GetComponent<Image>();
        progressStartOffset = 66;
    }

    public void SetPercent(float newPercent)
    {
        progressBarImg.rectTransform.sizeDelta = new Vector2((progressStartOffset + newPercent) * mul, progressBarImg.rectTransform.sizeDelta.y);
    }
}
