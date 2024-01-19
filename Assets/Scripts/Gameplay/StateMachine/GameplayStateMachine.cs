using System;
using System.Collections.Generic;
using FiniteStateMachine;
using FiniteStateMachine.Interfaces;
using Gameplay.Camera;
using Gameplay.Doors;
using Gameplay.Obstacle;
using Gameplay.Projectile;
using Gameplay.Shooter;
using Gameplay.StateMachine.States;
using Gameplay.UI;
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
            ProjectileRegistrationService projectileRegistrationService,
            BlowUpAreaFadeService blowUpAreaFadeService,
            CameraFollowService cameraFollowService,
            ObstacleColorService obstacleColorService,
            ObstacleEnableService obstacleEnableService,
            DoorsService doorsService,
            GameplayUIController gameplayUIController
        ) : base(new Dictionary<Type, IState>())
        {
            States.Add(typeof(InitState), new InitState(this,
                shooterMoveService,
                shooterShrinkService,
                obstacleDetectorShrinkingService,
                wayShrinkService,
                obstacleEnableService,
                doorsService
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
                obstacleColorService,
                cameraFollowService
                )
            );
            
            States.Add(typeof(EndLoseState), new EndLoseState(gameplayUIController,
                shooterMoveService,
                projectileRegistrationService));
            States.Add(typeof(EndWinState), new EndWinState(gameplayUIController, 
                shooterMoveService,
                projectileRegistrationService));
        }
    }
}