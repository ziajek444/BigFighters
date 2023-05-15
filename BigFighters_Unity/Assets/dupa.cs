using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dupa : MonoBehaviour
{
    [SerializeField] GameObject ball;


    void Start()
    {
        Vector3 myVector = new Vector3();
        for (int idx = 0; idx < 40; idx++)
        {
            MyRandom(ref myVector, -55f, 55f);
            GameObject newObj = Instantiate(ball, transform.position, transform.rotation);
            newObj.transform.position += myVector;
        }
    }

    public void MyRandom(ref Vector3 myVector, float min, float max)
    {
        myVector = new Vector3(UnityEngine.Random.Range(min, max), UnityEngine.Random.Range(min, max), UnityEngine.Random.Range(min, max));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
