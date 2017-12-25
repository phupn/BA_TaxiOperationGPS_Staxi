using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Taxi.Utils
{
    public class SoundUtils
    {
        public static void PlaySoundAlert()
        {
            try
            {

                string path = Application.StartupPath;
                path = Path.Combine(path, "Sound");
                // Create folder if it doesn't already exist
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                path = Path.Combine(path, "notify.wav");

                if (!File.Exists(path))
                {
                    System.Media.SystemSounds.Beep.Play();
                }
                else
                {
                    using (var player = new System.Media.SoundPlayer(path))
                    {
                        player.Play();
                    }
                }
            }
            catch (Exception ex)
            {
                LogErrorUtils.WriteLogError("PlaySoundAlert", ex);
            }
        }
    }
}
