using NUnit.Framework.Constraints;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Game_Manager : MonoBehaviour
{
    private DragAndDrop dNg;
    public static Game_Manager instance;
    public float dureeEcoute = 15f;
    public float dureeReponse = 10f;
    public float dureeFin = 5f;
    private float countdown;
    public bool fin = false;


    public bool phaseEcoute;
    public bool phaseReponse;


    //Ref Timer
    public TextMeshProUGUI Timer;

    private enum phases
    {
        ecoute,
        reponse,
        fin
    }

    private phases phase;



    void Awake()
    {
        if (instance == null)
            instance = this;

        dNg = GetComponent<DragAndDrop>();
    }

    private void Start()
    {
        Ecoute();
    }


    private void Update()
    {
        Partie();
    }

    public void Partie()
    {
        Timer.text = "TIMER : " + (int)countdown;


        countdown -= Time.deltaTime;
        if (countdown <= 0.0f)
        {
            countdown = 0.0f;

            if (phaseEcoute)
            {
                Repondre();
            }
            else if (phaseReponse)
            {
                fin = true;
                Fin();
            }
            else
            {

            }
        }
    }

    public void Milieu()
    {
        
    }

    void Ecoute()
    {
        phaseEcoute = true;
        countdown = dureeEcoute;
        phase = phases.ecoute;

    }

    void Repondre()
    {
        phaseEcoute = false;
        phaseReponse = true;
        countdown = dureeReponse;
    }

    public void Fin()
    {

    }
}
