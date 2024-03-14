using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TincoffHelper : MonoBehaviour
{
    //[Header("Settings")]
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "water")
        {
            gameObject.SetActive(false);
        }
    }
}
