using Gameplay.Camera;
using Gameplay.Finish;
using Gameplay.Projectile;
using Gameplay.Shooter;
using Gameplay.StateMachine;
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
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(_shooterBall);
            builder.RegisterComponent(_finishObject);
            
            builder.RegisterEntryPoint<ShooterShrinkService>().AsSelf();
            builder.RegisterEntryPoint<ShooterMoveService>().AsSelf();
            builder.RegisterEntryPoint<ObstacleDetectorShrinkingService>().AsSelf();
            
            builder.RegisterEntryPoint<WayShrinkService>().AsSelf();

            builder.RegisterComponent(_projectileFactory);
            builder.RegisterEntryPoint<ProjectileResolverService>().AsSelf();
            
            builder.RegisterEntryPoint<ProjectileGrowService>().AsSelf();
            builder.RegisterEntryPoint<ProjectileMoveService>().AsSelf();
            builder.RegisterEntryPoint<BlowUpAreaFadeService>().AsSelf();
            
            builder.RegisterEntryPoint<CameraFollowService>().AsSelf();
            

            builder.Register<GameplayStateMachine>(Lifetime.Singleton);
        }
    }
}