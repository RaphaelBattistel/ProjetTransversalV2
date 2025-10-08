using System;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using static Game_Manager;

public class Question : MonoBehaviour
{
    private Sprite _sprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _sprite = instance.data.Question;
        gameObject.GetComponent<SpriteRenderer>().sprite = _sprite;
        gameObject.transform.position = Vector2.zero;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
