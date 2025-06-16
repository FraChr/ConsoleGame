namespace PuzzleConsoleGame.Entities.Weapon;
using NAudio;
using NAudio.Wave;
public static class Sound
{

    public static void Music()
    {
        PlaySound("Assets/Music/audio.mp3", true);
    }
    public static void Gunshot()
    {
        PlaySound("Assets/Effects/gunshot.mp3", volume: 0.3f);
    }

    private static void PlaySound(string path, bool loop = false, float volume = 1f)
    {
        IWavePlayer waveOutDevice = new WaveOutEvent();
        
        var filePath = Path.Combine(Environment.CurrentDirectory, path);
        var audioFileReader = new AudioFileReader(filePath)
        {
            Volume = volume
        };

        waveOutDevice.Init(audioFileReader);

        waveOutDevice.PlaybackStopped += (sender, args) =>
        {
            if (loop)
            {
                audioFileReader.Position = 0;
                waveOutDevice.Play();
            }
            else
            {
                waveOutDevice.Dispose();
                audioFileReader.Dispose();    
            }
        };
        waveOutDevice.Play();
    }
}