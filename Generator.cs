using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    public GameObject BulletPrefab;

    private float span;   
    private float delta;

    void Start()
    {
        SetRandomSpan();
        delta = 0f;
    }

    void Update()
    {
        delta += Time.deltaTime;

        if (delta > span)
        {
            delta = 0f;
            GameObject go = Instantiate(BulletPrefab);
            go.transform.position = new Vector3(8, 0, 0); 
            SetRandomSpan();
        }
    }

    void SetRandomSpan()
    {
        span = Random.Range(0.4f, 2.0f);
    }
}