using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

/* Author: bhomitb, 12 April 2020
 * Latest Revision : 
 * Handling donwloads from API's using UnityWebRequest & Download handler
 */
namespace wolf.hazel.helper
{
    public class DownloadHelper
    {
        public IEnumerator DownlodSpriteImage(string url, Action<Sprite> callback)
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
                    Rect rect = new Rect(0, 0, texture.width, texture.height);

                    // Generate a sprite from texture
                    callback(Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f), 100));
                }
            }
        }
    }
}
