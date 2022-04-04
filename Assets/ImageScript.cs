using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ImageScript : MonoBehaviour {

    private string URL = "https://random.imagecdn.app/500/500";
    RawImage rawImage;

    private void Start() {

        rawImage = GetComponent<RawImage>();
    }

    public void Test() {
        StartCoroutine(DownloadImage(URL));
    }


    IEnumerator DownloadImage(string MediaUrl) {
        UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return uwr.SendWebRequest();
        if (uwr.result != UnityWebRequest.Result.Success)
            Debug.Log(uwr.error);
        else
            rawImage.texture = ((DownloadHandlerTexture)uwr.downloadHandler).texture;
    }
}
