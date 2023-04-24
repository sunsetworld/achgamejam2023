using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class items : MonoBehaviour
{
    private mg2 _minigame2Obj;
    // Start is called before the first frame update
    void Start()
    {
        _minigame2Obj = FindObjectOfType<mg2>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        _minigame2Obj.ModifyNumberOfItems(-1);
        Destroy(this.gameObject);
    }
}
