using Newtonsoft.Json;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;


public class ApiScript : MonoBehaviour {
    TextMeshProUGUI Text;

    private string URL = "https://api.chucknorris.io/jokes/random";


    private void Start() {
        Text = this.GetComponent<TextMeshProUGUI>();

    }

    public void Test() {
        StartCoroutine(getRequest(URL));
    }




    IEnumerator getRequest(string uri) {
        UnityWebRequest uwr = UnityWebRequest.Get(uri);
        yield return uwr.SendWebRequest();

        if (uwr.result != UnityWebRequest.Result.Success) {
            Debug.Log(uwr.error);
        }
        var t = uwr.downloadHandler.text;
        var requesttext = JsonConvert.DeserializeObject<ChuckNorrisResponse>(t);
        Text.text = requesttext.value;
    }




}
