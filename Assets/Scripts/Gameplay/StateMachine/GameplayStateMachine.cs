using System;
using System.Collections.Generic;
using FiniteStateMachine;
using FiniteStateMachine.Interfaces;
using Gameplay.Camera;
using Gameplay.Projectile;
using Gameplay.Shooter;
using Gameplay.StateMachine.States;
using Gameplay.Way;

namespace Gameplay.StateMachine
{
    public class GameplayStateMachine : BaseStateMachine
    {
        public GameplayStateMachine(
            ShooterShrinkService shooterShrinkService,
            ShooterMoveService shooterMoveService,
            ObstacleDetectorShrinkingService obstacleDetectorShrinkingService,
            WayShrinkService wayShrinkService,
            ProjectileResolverService projectileResolverService,
            ProjectileGrowService projectileGrowService,
            ProjectileMoveService projectileMoveService,
            BlowUpAreaFadeService blowUpAreaFadeService,
            CameraFollowService cameraFollowService
        ) : base(new Dictionary<Type, IState>())
        {
            States.Add(typeof(InitState), new InitState(this,
                shooterShrinkService,
                obstacleDetectorShrinkingService,
                wayShrinkService
                )
            );
            
            States.Add(typeof(GameloopState), new GameloopState(
                shooterShrinkService,
                shooterMoveService,
                obstacleDetectorShrinkingService,
                wayShrinkService,
                projectileResolverService,
                projectileGrowService,
                projectileMoveService,
                blowUpAreaFadeService,
                cameraFollowService
                )
            );
            
            States.Add(typeof(EndState), new EndState());
        }
    }
}