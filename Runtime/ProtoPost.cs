using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using Newtonsoft.Json.Linq;

namespace ProtoPost
{
  public class ProtoPost
  {
    public static IEnumerator Post(string url, JToken obj, System.Action<JToken> callback)
    {
      var json = JToken.FromObject(obj).ToString();
      var request = new UnityWebRequest(url, "POST");
      byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
      request.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw);
      request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
      request.SetRequestHeader("Content-Type", "application/json");
      yield return request.SendWebRequest();
      if (request.result == UnityWebRequest.Result.ConnectionError) {
        Debug.LogError(request.error);
        callback(null);
        yield break;
      }
      if (request.responseCode != 200) {
        Debug.LogError("Status was not 200");
        callback(null);
        yield break;
      }
      callback(JToken.Parse(request.downloadHandler.text));
    }
  }
}
