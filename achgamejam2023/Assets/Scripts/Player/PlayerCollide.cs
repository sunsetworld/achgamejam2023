using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollide : MonoBehaviour
{
    [SerializeField] private AudioClip speedUpClip;

    private AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
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
            // _audioSource.PlayOneShot(speedUpClip, 1.5f);
            Destroy(col.gameObject);
        }
    }
}
