using Shooter.Configs;

namespace Shooter.Systems.States
{
    class MenuState : GameStateBase
    {
        public override string SceneName
        {
            get
            {
                return Config.MenuSceneName;
            }
        }

        public MenuState ()
        {
            State = GameStateType.MenuState;
            AddTransition(GameStateTransitionType.MenuToInGame, GameStateType.InGameState);
        }


        //// Kutsutaan oletuskonstruktoria riippumatta kirjoittaako : base () eksplisiittisesti auki!
        //public MenuState() : base ()
        //{
        //    State = GameStateType.MenuState;
        //    AddTransition(GameStateTransitionType.MenuToInGame, GameStateType.InGameState);
        //}
    }
}
