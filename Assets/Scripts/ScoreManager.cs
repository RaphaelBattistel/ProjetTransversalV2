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

    public void UpdateScore(int valeur)
    {

        score += valeur;
    }

    public bool CheckScore(int id1, int id2)
    {
        return id1 == id2;
    }
}
