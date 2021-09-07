using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMov : MonoBehaviour
{
    public GameObject target;
    private float xoff, yoff = 4, zoff =-4;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
        transform.position = target.transform.position + new Vector3(xoff, yoff, zoff);
       
        transform.LookAt(target.transform.position);
      
    }
}
