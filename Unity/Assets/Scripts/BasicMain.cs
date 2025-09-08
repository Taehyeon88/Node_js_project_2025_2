using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class BasicMain : MonoBehaviour
{
    public Button Hello;
    public string host;                 //IP 주소 (로컬에서 127.0.0.1)
    public int port;                    //포트 주소 (3000번으로 express 동작)
    public string route;                 //about 주소

    private void Start()
    {
        this.Hello.onClick.AddListener(() =>
        {
            var url = string.Format("{0}:{1}/{2}", host, port, route);
            Debug.Log(url);

            StartCoroutine(this.GetBasic(url, (raw) =>
            {
                Debug.LogFormat("{0}", raw);
            }));
        });
    }
    private IEnumerator GetBasic(string url, System.Action<string> callback)
    {
        var webRequest = UnityWebRequest.Get(url);
        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.ConnectionError     //결과 값이 접속 오류일때
            || webRequest.result == UnityWebRequest.Result.ProtocolError)   //프로토콜 오류 일때
        {
            Debug.Log("네트워크 환경이 좋지 않아서 통신이 불가");                //통신 안됨 예외 처리 한다
        }
        else
        {
            callback(webRequest.downloadHandler.text);                      //통신 완료 되고 해당 텍스트를 가죠온다
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
