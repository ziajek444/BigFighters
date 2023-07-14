using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotater : MonoBehaviour
{
    public float spinForce = 10f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(rot(spinForce));
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(0, spinForce * Time.deltaTime, 0);
    }

    IEnumerator rot(float spinSpeed)
    {
        yield return new WaitForSeconds(0.1f);
        while(true)
        {
            transform.Rotate(0, spinForce, 0);
            yield return new WaitForSeconds(0.1f);
            yield return null;
        }
    }
}
