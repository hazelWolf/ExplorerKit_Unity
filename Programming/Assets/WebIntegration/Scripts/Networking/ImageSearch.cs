using wolf.hazel.helper;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
        public string API;

        private DownloadHelper _downloader;
        private string url = "https://pixabay.com/api/?key={0}&q={1}";
        // Start is called before the first frame update
        void Start()
        {
            _downloader = new DownloadHelper();
            tmp_InputField.onEndEdit.AddListener(Search);
        }

        // Function when search is done 
        void Search(string searchText)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                StartCoroutine(_downloader.DownlodSpriteImage(string.Format(url, API, text.text), UpdateImage));
            }
            else
                StartCoroutine(_downloader.DownlodSpriteImage(string.Format(url, API, searchText), UpdateImage));
        }

        void UpdateImage(Sprite sprite)
        {
            image.sprite = sprite;
        }
    }
}
