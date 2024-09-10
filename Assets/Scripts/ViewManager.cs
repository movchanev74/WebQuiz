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

public interface IUIInfo
{
    void SetStepInfo(string stepInfo);
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

    public void Show<T>() where T : class, IPresenter
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

        presenter.Show().Forget();
    }

    public void Show(Type type)
    {
        var presenter = (IPresenter)_di.TryResolve(type);
        if (presenter == null)
        {
            Debug.LogError($"[UI] Presenter {type.Name}: Unable to resolve");
            return;
        }

        if (!screenPresenters.Contains(presenter))
        {
            screenPresenters.Add(presenter);
        }
        HideAll();

        presenter.Show().Forget();
    }

    public void Hide<T>() where T : class, IPresenter
    {
        var presenter = _di.TryResolve<T>();
        if (presenter == null)
        {
            Debug.LogError($"[UI] Presenter {typeof(T).Name}: Unable to resolve");
            return;
        }

        presenter.Hide().Forget();
    }

    private void HideAll()
    {
        screenPresenters.ForEach(x => x.Hide());
    }
}
