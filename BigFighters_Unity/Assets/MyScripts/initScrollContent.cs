using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class initScrollContent : MonoBehaviour
{
    void Start()
    {
        int childCount = gameObject.transform.childCount;
        Vector2 cellSize = gameObject.GetComponent<GridLayoutGroup>().cellSize;
        Vector2 spacing = gameObject.GetComponent<GridLayoutGroup>().spacing;
        int constCount = gameObject.GetComponent<GridLayoutGroup>().constraintCount;

        float width = (cellSize.x + spacing.x) * constCount;
        float height = ((childCount / constCount) + 1) * (cellSize.y + spacing.y);

        gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
