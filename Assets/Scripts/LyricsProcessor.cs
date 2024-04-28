using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;

public class LyricsProcessor : MonoBehaviour
{
    public IEnumerator ProcessLyrics(string lyrics)
    {
        string url = "http://127.0.0.1:5000/process_lyrics";
        UnityWebRequest request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes("{\"lyrics\":\"" + lyrics + "\"}");
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.error != null)
        {
            Debug.Log("Error: " + request.error);
        }
        else
        {
            Debug.Log("Response: " + request.downloadHandler.text);
        }
    }
}
