using wolf.hazel.helper;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

/* Author : bhomitb, 12 April 2020
 * Revised on :
 * Searching images from https://pixabay.com and diplaying in unity
 */
namespace wolf.hazel.app
{
    public class ImageSearch : MonoBehaviour
    {
        public TMP_InputField tmp_InputField;
        public Image image;
        public TMP_Text text;
        public TMP_Text logText;
        public string API;

        private DownloadHelper _downloader;
        private DataHandler _dataHandler;
        private string url = "https://pixabay.com/api/?key={0}&q={1}";
        // Start is called before the first frame update
        void Start()
        {
            _downloader = new DownloadHelper();
            _dataHandler = new DataHandler();
            tmp_InputField.onEndEdit.AddListener(Search);
        }

        // On text entered hit the API to get JSON data
        void Search(string searchText)
        {
            logText.text = "Looking for " + searchText;
            StartCoroutine(_dataHandler.FetchData(string.Format(url, API, searchText), ParseData));
        }

        // Parse JSON data and extract image url
        void ParseData(string json)
        {
            Dictionary<string, object> dict = MiniJSON.Json.Deserialize(json) as Dictionary<string, object>;
            List<object> hits = dict["hits"] as List<object>;
            if(hits != null && hits.Count > 0)
            {
                logText.text = "Got response from Pixabay";
                Dictionary<string, object> hit = hits[0] as Dictionary<string, object>;
                if (hit != null)
                {
                    string imageURL = hit["largeImageURL"] as string;
                    if (!string.IsNullOrEmpty(imageURL))
                    {
                        StartCoroutine(_downloader.DownlodSpriteImage(imageURL, UpdateImage));
                    }
                }
            }
            else
            {
                logText.text = "Unable to get response";
                logText.color = Color.red;
                Debug.LogError("Error parsing JSON data from MiniJSON");
            }
        }

        void UpdateImage(Sprite sprite)
        {
            image.sprite = sprite;
            image.SetNativeSize();
        }
    }
}
