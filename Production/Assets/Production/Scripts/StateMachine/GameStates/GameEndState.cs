using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Avramov.Production
{
    public class GameEndState : BaseState
    {
        private VictoryScreenPresenter _victoryScreenPresenter;

        public GameEndState(VictoryScreenPresenter victoryScreenPresenter)
        {
            _victoryScreenPresenter = victoryScreenPresenter;
        }

        public override void Start()
        {
            _victoryScreenPresenter.Activate();
        }

        public override void Update()
        {

        }

        public override void End()
        {
            _victoryScreenPresenter?.Deactivate();
        }
    }
}
