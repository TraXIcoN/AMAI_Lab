using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spoawn : MonoBehaviour
{

    public GameObject[] objectsToAdd;
    public Transform spownPosition;
    public float maxSeperationTime;
    public float mixSeperationTime;
    int randomInt;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpoawnObjects());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpoawnObjects()
    {
        while (true)
        {
            randomInt = Random.Range(0, objectsToAdd.Length);
            yield return new WaitForSeconds(Random.Range(mixSeperationTime, maxSeperationTime));
            Instantiate(objectsToAdd[randomInt], spownPosition.position, Quaternion.identity);

        }
        
    }
}
