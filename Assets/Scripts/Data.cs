using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Data", menuName = "Data", order = 1)]
public class Data : ScriptableObject
{
    public Sprite Question;
    public Sprite Reponse1;
    public Sprite Reponse2;
    public Sprite Reponse3;
    public int idQuestion;
    public int idReponse;

}
