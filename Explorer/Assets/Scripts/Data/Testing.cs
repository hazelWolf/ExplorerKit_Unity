using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour {

	private XML2JSON test;
	private string sample = "<guestbook><guest><fname>Terje</fname><lname>Beck</lname></guest><guest><fname>Jan</fname><lname>Refsnes</lname></guest><guest><fname>Torleif</fname><lname>Rasmussen</lname></guest><guest><fname>anton</fname><lname>chek</lname></guest><guest><fname>stale</fname><lname>refsnes</lname></guest><guest><fname>hari</fname><lname>prawin</lname></guest><guest><fname>Hege</fname><lname>Refsnes</lname></guest></guestbook>";

	// Use this for initialization
	void Start () {
		test = new XML2JSON();
		Debug.Log(test.JsonToXml((test.ParseXMLData(sample))));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
