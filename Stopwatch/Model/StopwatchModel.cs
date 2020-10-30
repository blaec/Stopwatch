using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stopwatch.Model
{
    class StopwatchModel
    {
        private DateTime? _started;

        private TimeSpan? _previousElapsedTime;

        public bool Running
        {
            get { return _started.HasValue; }
        }

        public TimeSpan? Elapsed
        {
            get
            {
                return (Running)
                    ? (_previousElapsedTime.HasValue)
                        ? CalculateTimeElapsedSinceStarted() + _previousElapsedTime
                        : CalculateTimeElapsedSinceStarted()
                    : _previousElapsedTime;
            }
        }

        private TimeSpan CalculateTimeElapsedSinceStarted()
        {
            return DateTime.Now - _started.Value;
        }

        public void Start()
        {
            _started = DateTime.Now;
            if (!_previousElapsedTime.HasValue)
            {
                _previousElapsedTime = new TimeSpan(0);
            }
        }

        public void Stop()
        {
            if (_started.HasValue)
            {
                _previousElapsedTime += DateTime.Now - _started.Value;
            }
            _started = null;
        }

        public void Reset()
        {
            _previousElapsedTime = null;
            _started = null;
            LapTime = null;
        }

        public TimeSpan? LapTime { get; private set; }

        public void Lap()
        {
            LapTime = Elapsed;
            OnLapTimeUpdated(LapTime);
        }

        public event EventHandler<LapEventArgs> LapTimeUpdated;

        private void OnLapTimeUpdated(TimeSpan? lapTime)
        {
            LapTimeUpdated?.Invoke(this, new LapEventArgs(lapTime));
        }

        public StopwatchModel()
        {
            Reset();
        }
    }
}