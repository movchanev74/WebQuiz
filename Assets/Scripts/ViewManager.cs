using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public interface IUIView
{
    UniTask Show();
    UniTask Hide();
}

public interface IPresenter
{
    UniTask Show();
    UniTask Hide();
}

public class ViewManager 
{
    [Inject] private DiContainer _di;

    List<IPresenter> screenPresenters = new List<IPresenter>();

    public void Show<T>(Action<T> afterShowCallback = null) where T : class, IPresenter
    {
        var presenter = _di.TryResolve<T>();
        
        if (presenter == null)
        {
            return;
        }

        if (!screenPresenters.Contains(presenter))
        {
            screenPresenters.Add(presenter);
        }
        HideAll();

        if (afterShowCallback == null)
            presenter.Show().Forget();
        else
            presenter.Show().ContinueWith(() => afterShowCallback(presenter)).Forget();
    }

    public void Hide<T>(Action<T> afterHideCallback = null) where T : class, IPresenter
    {
        var presenter = _di.TryResolve<T>();
        if (presenter == null)
        {
            Debug.LogError($"[UI] Presenter {typeof(T).Name}: Unable to resolve");
            return;
        }

        if (afterHideCallback == null)
            presenter.Show().Forget();
        else
            presenter.Show().ContinueWith(() => afterHideCallback(presenter)).Forget();
    }

    private void HideAll()
    {
        screenPresenters.ForEach(x => x.Hide());
    }
}
