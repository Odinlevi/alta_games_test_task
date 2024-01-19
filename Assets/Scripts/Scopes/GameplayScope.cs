using Gameplay.Camera;
using Gameplay.Doors;
using Gameplay.Finish;
using Gameplay.Input;
using Gameplay.Obstacle;
using Gameplay.Projectile;
using Gameplay.Shooter;
using Gameplay.StateMachine;
using Gameplay.UI;
using Gameplay.Way;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Scopes
{
    public class GameplayScope : LifetimeScope
    {
        [SerializeField] private ShooterBall _shooterBall;
        [SerializeField] private FinishObject _finishObject;
        [SerializeField] private ProjectileFactory _projectileFactory;
        
        [SerializeField] private GameplayUIController _uiController;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<ShooterBallData>().AsSelf();
            
            builder.RegisterComponent(_finishObject);
            
            builder.RegisterEntryPoint<ShooterShrinkService>().AsSelf();
            builder.RegisterEntryPoint<ShooterMoveService>().AsSelf();
            builder.RegisterEntryPoint<ObstacleDetectorShrinkingService>().AsSelf();
            
            builder.RegisterEntryPoint<WayShrinkService>().AsSelf();

            builder.RegisterComponent(_projectileFactory);
            builder.RegisterEntryPoint<ProjectileResolverService>().AsSelf();
            
            builder.RegisterEntryPoint<ProjectileGrowService>().AsSelf();
            builder.RegisterEntryPoint<ProjectileMoveService>().AsSelf();
            builder.RegisterEntryPoint<ProjectileRegistrationService>().AsSelf();
            builder.RegisterEntryPoint<BlowUpAreaFadeService>().AsSelf();
            
            builder.RegisterEntryPoint<CameraFollowService>().AsSelf();

            builder.RegisterEntryPoint<ObstacleColorService>().AsSelf();
            builder.RegisterEntryPoint<ObstacleEnableService>().AsSelf();
            builder.RegisterEntryPoint<DoorsService>().AsSelf();
            
            builder.RegisterComponent(_uiController);
            builder.RegisterEntryPoint<InputData>().AsSelf();

            builder.Register<GameplayStateMachine>(Lifetime.Singleton);
        }
    }
}