using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = nameof(GameData))]
public class GameData : ScriptableObject
{
    public int intTest;
    public string stringTest;
    public bool boolTest;

    public int[] arrayIntTest;

    public Test[] arrayTest;
}
