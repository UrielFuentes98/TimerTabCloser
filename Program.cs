using System;
using System.Diagnostics;
using System.Media;
using System.Threading.Tasks;

namespace TimerTabCloser
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var alarmPlayer = new SoundPlayer("alarm.wav");

                int timerMinutes = int.Parse(args[0]);
                Task.Delay(new TimeSpan(0, timerMinutes, 0)).Wait();
                
                
                PlayAlarm(alarmPlayer);
                Task.Delay(new TimeSpan(0, 5, 0)).Wait();
                CloseChromeTabs();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static private void CloseChromeTabs()
        {
            Process[] chromeInstances = Process.GetProcessesByName("chrome");
            foreach (Process p in chromeInstances)
                p.Kill();
        }

        static private void PlayAlarm (SoundPlayer player)
        {
            player.Play();
            Task.Delay(new TimeSpan(0, 0, 3)).Wait();
            player.Stop();
        }
    }
}
