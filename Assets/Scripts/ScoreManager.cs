using UnityEngine;

public class ScoreManager : MonoBehaviour 
{
    public static ScoreManager instance;
    public int score;
    void Awake()
    {
        if(instance == null)
            instance = this;
    }

    public void UpdateScore(int valeur, bool bonneRep)
    {

        if (!bonneRep)
        {
            score = score;
        }
        else if(score <= 0 && bonneRep)
        {
            score = valeur;
        }
        else if(score > 0 && bonneRep)
        {
            score += valeur;
        }
        else
        {
            return;
        }
    }

    public bool CheckScore(int id1, int id2)
    {
        return id1 == id2;
    }
}
