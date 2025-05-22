using Firebase.Database;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour 
{
    public static ScoreManager instance;
    public int score;

    private DatabaseReference dbReference;

    public TextMeshProUGUI Score;


    void Awake()
    {
        if(instance == null)
            instance = this;

        dbReference = FirebaseDatabase.DefaultInstance.RootReference;

    }

    public void UpdateScore(int valeur)
    {

        score += valeur;

        Score.text = "SCORE :" + score;
        Debug.Log("Score Update");
    }

    public bool CheckScore(int id1, int id2)
    {
        return id1 == id2;
    }
}
