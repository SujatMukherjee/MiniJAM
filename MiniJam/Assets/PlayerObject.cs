using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (fileName = "Player",menuName ="Player/playerObject")]


public class PlayerObject : ScriptableObject

{
    public float playermovement;
    public float firerate;
    public bool isfiring;
    public TypeofEvolution typE;
    public bool isdead;

    public int health;
    public int damage;
    


}
public enum TypeofEvolution
{
    DefaultEvelution,
    Stage1Evolution,
    Stage2Evolution,
    Stage3Evolution,
    FinalStageEvolution
}