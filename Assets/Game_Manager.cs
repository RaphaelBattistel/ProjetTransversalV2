using NUnit.Framework.Constraints;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    private DragAndDrop dNg;
    public static Game_Manager instance;
    public float countdown = 15f;
    public bool fin = false;


    void Awake()
    {
        if (instance == null)
            instance = this;

        dNg = GetComponent<DragAndDrop>();
    }

    private void Update()
    {
        Partie();
    }

    public void Partie()
    {
        
        countdown -= Time.deltaTime;
        if (countdown <= 0.0f)
        {
            fin = true;
        }
    }

    public void Milieu()
    {
        
    }

    public void Fin()
    {

    }
}
