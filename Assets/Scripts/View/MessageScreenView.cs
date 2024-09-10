using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageScreenView : BaseUIView
{
    [SerializeField]
    private TMP_Text _messageText;

    public void SetMessage(string message)
    {
        _messageText.text = message;
    }
}
