using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    Vector3 scale;
    public float objectSize = 3.0f;

    void Start()
    {
        scale = transform.localScale;
    }

    void ScaleOnOff()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (scale.x != objectSize)
            {
                scale = transform.localScale;
                scale.x = objectSize;
                transform.localScale = scale;

                Debug.Log("condition1");
            }
            else
            {
                scale = transform.localScale;
                scale.x = 1;
                transform.localScale = scale;

                Debug.Log("condition2");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        ScaleOnOff();
    }
}