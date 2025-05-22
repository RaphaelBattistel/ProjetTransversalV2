using System.Collections;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager instance;
    public int countdownExtrait;
    public int countdownRep;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Update()
    {
        Debug.Log(Countdown());
    }

    public IEnumerator Countdown()
    {
        yield return new WaitForSeconds(countdownExtrait);
        if(countdownExtrait <= 0)
        {
            yield return new WaitForSeconds(countdownRep);
        }
    }
}
