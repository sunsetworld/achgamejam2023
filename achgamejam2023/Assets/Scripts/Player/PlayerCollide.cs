using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
           GameManager.Instance.DestroyPlayer();
        }
        else if (col.gameObject.CompareTag("Apple"))
        {
            GameManager.Instance.SetObjectiveComplete(true);
            Destroy(col.gameObject);
        }
    }
}
