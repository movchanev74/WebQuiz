using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScreenPresenter : BaseUIPresenter<MessageScreenView>
{
    private const string FINAL_TEXT = "Ты прошел обучение, да прибудет с тобой сила";

    public override UniTask Show()
    {
        view.SetMessage(FINAL_TEXT);

        return base.Show();
    }
}
