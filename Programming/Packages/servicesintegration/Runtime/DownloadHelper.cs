using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

/* Author: bhomitb, 12 April 2020
 * Latest Revision : 8 May 2020
 * Handling downloads from API's using UnityWebRequest & Download handler
 */
namespace wolf.hazel.helper
{
    public class DownloadHelper
    {
        public IEnumerator DownlodImage(string url, Action<Texture2D> callback)
        {
            if (!string.IsNullOrEmpty(url))
            {
                using (UnityWebRequest w = UnityWebRequestTexture.GetTexture(url))
                {
                    yield return w.SendWebRequest();
                    if (w.isNetworkError || w.isHttpError)
                    {
                        Debug.LogError(w.error);
                        callback(null);
                    }
                    else
                    {
                        // Get the texture from download
                        Texture2D texture = DownloadHandlerTexture.GetContent(w);
                        callback(texture);
                    }
                }
            }
            else
            {
                Debug.LogError("Please provide a valid url");
            }
        }
    }
}
