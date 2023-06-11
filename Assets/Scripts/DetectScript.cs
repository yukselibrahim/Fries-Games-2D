using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectScript : MonoBehaviour
{
    private Gun gun;
    

    private void Awake()
    {
        gun = GameObject.Find("Gun").GetComponent<Gun>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gun.isClose = true;
            gun.Fire();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gun.isClose = false;
        }
    }
}
