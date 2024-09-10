using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuizesMockConfig", menuName = "Configs/QuizesMockConfig")]
public class QuizesMockConfig : ScriptableObject
{
    public List<StepData> quizes;
}