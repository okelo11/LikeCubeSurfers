using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    public GameObject CollectorBox;
   
    void Update()
    {

        transform.position = new Vector3(CollectorBox.transform.position.x, 1.5f+CollectorBox.transform.childCount, CollectorBox.transform.position.z);
    }
}
