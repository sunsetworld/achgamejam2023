using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollide : MonoBehaviour
{
    [SerializeField] private GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            gm.DestroyPlayer();
        }
        else if (col.gameObject.CompareTag("Apple"))
        {
            gm.SetObjectiveComplete(true);
            Destroy(col.gameObject);
        }
    }
}
