using System;
using System.IO;
using System.Media;

namespace Void.Systems.Audio
{
    public static class AudioManager
    {
        private static SoundPlayer _player;

        public static void PlayBackgroundMusic(string fileName)
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Audio", fileName);

                if (!File.Exists(path))
                {
                    System.Diagnostics.Debug.WriteLine($"[AUDIO] Arquivo não encontrado: {path}");
                    return;
                }

                _player = new SoundPlayer(path);
                _player.PlayLooping();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[AUDIO] Erro: {ex.Message}");
            }
        }

        public static void StopMusic()
        {
            if (_player != null)
            {
                _player.Stop();
            }
        }
    }
}