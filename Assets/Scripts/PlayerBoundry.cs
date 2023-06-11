using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundry : MonoBehaviour
{
    [SerializeField] float horizontalBoundry;
    float xMove;

    
    void Update()
    {
        xMove = Mathf.Clamp(transform.position.x, -horizontalBoundry, horizontalBoundry);
        transform.position = new Vector2(xMove, transform.position.y);

        //if (transform.position.x<-horizontalBoundry)
        //{
        //    transform.position = new Vector3(-horizontalBoundry, transform.position.y, transform.position.z);
        //}

        //if (transform.position.x > horizontalBoundry)
        //{
        //    transform.position = new Vector3(horizontalBoundry, transform.position.y, transform.position.z);
        //}


    }
}
