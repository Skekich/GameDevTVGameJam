using System;

public static class EventHandler
{
   internal static event Action OnInvokeDeath;
   internal static event Action<int> OnInvokeScore;
   internal static event Action OnTimeZero;

   public static void InvokeDeathEvent()
   {
      OnInvokeDeath?.Invoke();
   }

   public static void InvokeOnScorePass(int score)
   {
      OnInvokeScore?.Invoke(score);
   }

   public static void InvokeOnTimeZero()
   {
      OnTimeZero?.Invoke();
   }
}
