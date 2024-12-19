using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;

namespace hackaton_microsoft_agro.Services
{
    public class SpeechService(string apiKey, string region)
    {
        SpeechConfig config = SpeechConfig.FromSubscription(apiKey, region);

        public string SpeechToText(byte[] audio)
        {
            try
            {
                var tempFilePath = Path.GetTempFileName();
                File.WriteAllBytes(tempFilePath, audio);
                using var audioConfig = AudioConfig.FromWavFileInput(tempFilePath);

                config.SpeechRecognitionLanguage = "en-US";
                using var recognizer = new SpeechRecognizer(config, audioConfig);

                var result = recognizer.RecognizeOnceAsync().Result;
                return result.Text;

            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error processing the audio file -> SpeechToText: " + ex.Message);
            }

        }
    }
}