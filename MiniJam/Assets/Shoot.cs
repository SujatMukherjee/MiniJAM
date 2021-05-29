using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    

    [SerializeField]
    int amount = 80;


    // Update is called once per frame
    void Update()
    {
        transform.Translate( Vector3.up*amount*Time.deltaTime);

    if(transform.position.y>450)
        {
            Destroy(gameObject);
        }
        
    }
}
