using System.Timers;
using Timer = System.Timers.Timer;

namespace BlazorApp2;

public class PeriodicExecutor : IDisposable
{
    public event EventHandler<JobExecutedEventArgs> JobExecuted;

    void OnJobExecuted()
    {
        JobExecuted?.Invoke(this, new JobExecutedEventArgs());
    }

    Timer _timer;
    bool _running;

    public void StartExecuting()
    {
        if (!_running)
        {
            // Initiate a Timer
            _timer = new Timer();
            _timer.Interval = 1_000; // every 1 seconds
            _timer.Elapsed += HandleTimer;
            _timer.AutoReset = true;
            _timer.Enabled = true;

            _running = true;
        }
    }

    void HandleTimer(object source, ElapsedEventArgs e)
    {
        // Execute required job

        // Notify any subscribers to the event
        OnJobExecuted();
    }

    public void Dispose()
    {
        if (_running)
        {
            // Clear up the timer
        }
    }
}

public class JobExecutedEventArgs : EventArgs
{
}