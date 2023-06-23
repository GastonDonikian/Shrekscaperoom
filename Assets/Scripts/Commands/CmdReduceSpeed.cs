using UnityEngine;

namespace Commands
{
    public class CmdReduceSpeed: ICommand
    {
        private IMovable _movable;
        private int _speedChange;
    
        public CmdReduceSpeed(IMovable movable, int speedChange)
        {
            _movable = movable;
            _speedChange = speedChange;
        }

        public void Execute()
        {
            EventManager.instance.OnCharacterSpeedChange(-1*_speedChange);
            _movable.ReduceSpeed(_speedChange);
        }
    }
}