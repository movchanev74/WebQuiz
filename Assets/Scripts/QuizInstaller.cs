using Zenject;
using UnityEngine;
using System.Net;

public class QuizInstaller : MonoInstaller
{
    public MainScreenView MainScreenViewPrefab;
    public QuizView QuizViewPrefab;
    public QuizStepOneView quizStepOneView;

    [SerializeField] private WebConfig _webConfig;

    public Canvas ParentCanvas;

    public override void InstallBindings()
    {
        Container.Bind<WebConfig>().FromInstance(_webConfig).AsSingle();

        Container.Bind<ViewManager>().AsSingle().NonLazy();


        Container.Bind<QuizStepOneView>()
            .FromComponentInNewPrefab(quizStepOneView)
            .UnderTransform(ParentCanvas.transform)
            .AsSingle();
        Container.Bind<QuizStepOnePresenter>().AsSingle().NonLazy();

        Container.Bind<MainScreenView>()
            .FromComponentInNewPrefab(MainScreenViewPrefab)
            .UnderTransform(ParentCanvas.transform)
            .AsSingle();
        Container.Bind<MainScreenPresenter>().AsSingle().NonLazy();


        Container.BindInterfacesAndSelfTo<WebSocketService>().AsSingle();
        Container.Bind<WebRequestService>().AsSingle();
        


        Container.Bind<QuizModel>().AsSingle();
        //Container.Bind<QuizView>()
        //    .FromComponentInNewPrefab(QuizViewPrefab)
        //    .UnderTransform(ParentCanvas.transform)
        //    .AsSingle();
        //Container.Bind<QuizPresenter>().AsSingle().NonLazy();
        //Container.Bind<ApiService>().AsSingle();

        Container.Bind<Boot>().AsSingle().NonLazy();
    }
}
