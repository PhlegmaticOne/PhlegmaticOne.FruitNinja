﻿using Concrete.Commands.BlockCommands.Base;
using Concrete.Commands.BlockCommands.Models;
using Entities.Base;
using Helpers;

namespace Concrete.Commands.BlockCommands
{
    public class StartTimerCommand : IBlockOnDestroyCommand
    {
        private readonly Timer _timer;
        private readonly int _time;

        public StartTimerCommand(Timer timer, int time)
        {
            _timer = timer;
            _time = time;
        }
        
        public void OnDestroy(Block entity, BlockDestroyContext destroyContext)
        {
            _timer.StartTimer(_time);
        }
    }
}