using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ImageImport : MonoBehaviour
{
    public string url = "";
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DownlodSpriteImage());
    }

    IEnumerator DownlodSpriteImage()
    {
        using (UnityWebRequest w = UnityWebRequestTexture.GetTexture(url))
        {
            yield return w.SendWebRequest();
            if (w.isNetworkError || w.isHttpError)
            {
                Debug.LogError(w.error);
            }
            else
            {
                // Get the texture from download
                Texture2D texture = DownloadHandlerTexture.GetContent(w);
                Rect rect = new Rect(0,0,texture.width,texture.height);

                // Generate a sprite from texture
                image.sprite = Sprite.Create(texture, rect, new Vector2(0.5f,0.5f), 100);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
