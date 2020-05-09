using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

/* Author: bhomitb, 12 April 2020
 * Latest Revision : 
 * Handling data from API's and posting data to API using UnityWebRequest
 */
namespace wolf.hazel.helper
{
    public class DataHandler
    {
        public IEnumerator FetchData(string url, Action<string> callback)
        {
            if (!string.IsNullOrEmpty(url))
            {
                using (UnityWebRequest www = UnityWebRequest.Get(url))
                {
                    yield return www.SendWebRequest();
                    if (www.isNetworkError || www.isHttpError)
                    {
                        Debug.LogError("Error fetch data from : " + url + "got response : " + www.error);
                        callback(null);
                    }
                    else callback(www.downloadHandler.text);
                }
            }
            else
            {
                Debug.LogError("Please provide a valid url");
            }
        }

        public IEnumerator PostData(string url, WWWForm data, Action<string> callback)
        {
            if (!string.IsNullOrEmpty(url))
            {
                using (UnityWebRequest www = UnityWebRequest.Post(url, data))
                {
                    yield return www.SendWebRequest();
                    if (www.isNetworkError || www.isHttpError)
                    {
                        Debug.LogError("Error fetch data from : " + url + "got response : " + www.error);
                        callback(null);
                    }
                    else callback(www.downloadHandler.text);
                }
            }
            else
            {
                Debug.LogError("Please provide a valid url");
            }
        }
    }
}
