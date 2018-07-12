//Get/Post methods in unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Request : MonoBehaviour {
	public string simplegeturl; 

	public Text responseText;
	// Use this for initialization
	void Start () {
		if(simplegeturl == null){
			Debug.Log("No url specified.");
		}
		else{
			Debug.Log(simplegeturl);
		}
	}
	//1. simple api call without headers
	public void simplerequest(){
		WWW req = new WWW(simplegeturl);
		StartCoroutine(onResponse(req));
	}
	

	private IEnumerator onResponse(WWW req){
		yield return req;
		Debug.Log(req.text);
		responseText.text = req.text;
	}
//-------------------------------------------------------------------------------------//

	// 2.Get request with params

//------------------------------------------------------------------------------------//
	// 3. Post request with headers 

	public void postReq()
    {
        WWWForm form = new WWWForm();

        Dictionary<string, string> headers = new Dictionary<string,string>();
        headers.Add("name", "bhomit");
        WWW req = new WWW("https://b2969990.ngrok.io//post",null,  headers);
        Debug.Log(req);
        StartCoroutine(onResponse(req));
    }

    //-----------------------------------------------------------------------------------//
}