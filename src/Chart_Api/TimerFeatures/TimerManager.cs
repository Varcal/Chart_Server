﻿using System;
using System.Threading;

namespace Chart_Api.TimerFeatures
{
    public class TimerManager
    {
        private Timer _timer;
        private readonly AutoResetEvent _autoResetEvent;
        private Action _action;

        public DateTime TimeStarted { get; }

        public TimerManager(Action action)
        {
            _action = action;
            _autoResetEvent = new AutoResetEvent(false);
            _timer = new Timer(Execute, _autoResetEvent, 1000, 2000);
            TimeStarted = DateTime.Now;
        }

        private void Execute(object stateInfo)
        {
            _action();

            if ((DateTime.Now - TimeStarted).Seconds > 60)
            {
                _timer.Dispose();
            }
        }
    }
}
