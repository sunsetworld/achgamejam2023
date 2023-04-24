using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mg2 : MonoBehaviour
{
    private items[] _gameItems;

    private float _numberOfItems;

    private GameManager _gm;
    // Start is called before the first frame update
    void Start()
    {
        _gm = FindObjectOfType<GameManager>();
        _gameItems = FindObjectsOfType<items>();
        _numberOfItems = _gameItems.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (_numberOfItems <= 0)
        {
            _gm.SetObjectiveComplete(true);
        }
    }

    public void ModifyNumberOfItems(int numberToModify)
    {
        _numberOfItems += numberToModify;
    }
}
