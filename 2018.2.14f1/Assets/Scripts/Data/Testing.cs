using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
public class Testing : MonoBehaviour {

	private XML2JSON test;
	private string sample = "<guestbook><guest><fname>Terje</fname><lname>Beck</lname></guest><guest><fname>Jan</fname><lname>Refsnes</lname></guest><guest><fname>Torleif</fname><lname>Rasmussen</lname></guest><guest><fname>anton</fname><lname>chek</lname></guest><guest><fname>stale</fname><lname>refsnes</lname></guest><guest><fname>hari</fname><lname>prawin</lname></guest><guest><fname>Hege</fname><lname>Refsnes</lname></guest></guestbook>";

	// Use this for initialization
	void Start () {
		test = new XML2JSON();
		Debug.Log(test.JsonToXml((test.ParseXMLData(sample))));
		convert(test.JsonToXml((test.ParseXMLData(sample))));
	}

	/*//todo
	1. Genric type parsing and excetion handling.
	2. Complex json structures
	*/ 

	/// <summary>
	/// deserialze json
	/// </summary>
	/// <param name="guestbook"></param>
	void convert(string guestbook){
		RootObject book = new RootObject();
		book = JsonConvert.DeserializeObject<RootObject>(guestbook);
		Debug.Log(book.guestbook.guest[0].fname +" "+ book.guestbook.guest[0].lname);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
