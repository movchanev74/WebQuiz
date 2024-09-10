using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using Zenject;

public abstract class BaseUIPresenter<T> : IPresenter where T : class, IUIView
{
    [Inject]
    protected readonly T view;

    public virtual UniTask Hide()
    {
        view.Hide();
        return UniTask.CompletedTask;
    }

    public virtual UniTask Show()
    {
        view.Show();
        return UniTask.CompletedTask;
    }
}
