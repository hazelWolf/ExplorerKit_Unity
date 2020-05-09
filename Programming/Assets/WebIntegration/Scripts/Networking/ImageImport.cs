using wolf.hazel.helper;
using UnityEngine;
using UnityEngine.UI;
using wolf.hazel.utility;

/* Author: bhomitb 12 April 2020
 * Revised on:
 * Importing image in unity from web, please ensure server side has cors headers configuered for WebGL use
 */
namespace wolf.hazel.app
{
    public class ImageImport : MonoBehaviour
    {
        public string url = "";
        public Image image;

        void Start()
        {
            DownloadHelper downloader = new DownloadHelper();
            StartCoroutine(downloader.DownlodImage(url, UpdateImage));
        }

        void UpdateImage(Texture2D texture)
        {
            image.sprite = SpriteUtility.textureToSprite(texture);
        }
    }
}
