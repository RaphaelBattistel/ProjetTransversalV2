using UnityEngine;
using TMPro;
using System;

public class Game_Manager : MonoBehaviour
{
    private DragAndDrop dNg;
    public static Game_Manager instance;

    [Header("QUESTIONS")]
    public Data question1;
    public Data question2;
    public Data question3;
    public Data question4;
    public Data question5;

    public Data data;
    public Data[] _listQuest;
    public int index = 0;

    [Header ("COUNTDOWN")]
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
        data = _listQuest[0];
        Ecoute();
    }


    private void Update()
    {
        data = _listQuest[index];
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
                NouvelleQuestion();
                Ecoute();
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
        countdown = dureeFin;
        phaseReponse = false;
    }

    public void NouvelleQuestion()
    {
        data = _listQuest[index];
        index++;
        // Logique Changement des cartes
        // Reset positions des cartes
        // Nouvelle question
        //
    }
}
