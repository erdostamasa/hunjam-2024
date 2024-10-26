using System;

public static class EventManager
{
    public static event Action onPlayerDeath;
    public static void PlayerDeath()
    {
        onPlayerDeath?.Invoke();
    }
}
