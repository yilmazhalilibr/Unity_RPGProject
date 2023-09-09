using Unity_RPGProject.Concrete;
using Unity_RPGProject.Managers;
using Zenject;

public class ZenjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<GameManager>().AsSingle();
        //Container.BindInterfacesAndSelfTo<SceneLoader>().AsSingle().NonLazy();
    }
}