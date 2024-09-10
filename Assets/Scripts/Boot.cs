using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Boot
{
    public Boot(ViewManager viewManager)
    {
        viewManager.Show<StartScreenPresenter>();
    }
}
