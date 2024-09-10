using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WebConfig", menuName = "Configs/WebConfig")]
public class WebConfig : ScriptableObject
{
    public string webSocketUrl;
    public string webRequestUrl;
}
