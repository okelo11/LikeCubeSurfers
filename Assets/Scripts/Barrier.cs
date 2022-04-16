using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
     public int deleteBoxesNumber;
    // Start is called before the first frame update
    void Start()
    {
        if (transform.childCount == 0)
        {
            deleteBoxesNumber = 1;
        }
        else
        {
            deleteBoxesNumber = transform.childCount + 1;
        }
       
    }

  
}
