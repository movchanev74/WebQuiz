using Zenject;
using UnityEngine;
using System.Net;
using System.Collections.Generic;

public class QuizInstaller : MonoInstaller
{
    public MessageScreenView messageScreenView;
    public QuizStepButtonsView quizStepButtonsView;
    public QuizStepSliderView quizStepSliderView;

    [SerializeField] private WebConfig _webConfig;
    [SerializeField] private QuizesMockConfig _quizesMockConfig;

    public Canvas ParentCanvas;

    public override void InstallBindings()
    {
        //Configs
        Container.Bind<WebConfig>().FromInstance(_webConfig).AsSingle();
        if (_quizesMockConfig != null)
        {
            Container.Bind<QuizesMockConfig>().FromInstance(_quizesMockConfig).AsSingle();
        }

        //Views
        Container.Bind<ViewManager>().AsSingle().NonLazy();
        Container.Bind<MessageScreenView>()
            .FromComponentInNewPrefab(messageScreenView)
            .UnderTransform(ParentCanvas.transform)
            .AsSingle();
        Container.Bind<QuizStepButtonsView>()
            .FromComponentInNewPrefab(quizStepButtonsView)
            .UnderTransform(ParentCanvas.transform)
            .AsSingle();
        Container.Bind<QuizStepSliderView>()
            .FromComponentInNewPrefab(quizStepSliderView)
            .UnderTransform(ParentCanvas.transform)
            .AsSingle();

        //Presenters
        Container.Bind<StartScreenPresenter>().AsSingle();
        Container.Bind<QuizStepOnePresenter>().AsSingle();
        Container.Bind<QuizStepTwoPresenter>().AsSingle();
        Container.Bind<QuizStepThreePresenter>().AsSingle();
        Container.Bind<FinalScreenPresenter>().AsSingle();

        //Services
        Container.BindInterfacesAndSelfTo<WebSocketService>().AsSingle();
        Container.Bind<WebRequestService>().AsSingle();
        
        //Model
        Container.Bind<QuizModel>().AsSingle();

        Container.Bind<Boot>().AsSingle().NonLazy();
    }
}
