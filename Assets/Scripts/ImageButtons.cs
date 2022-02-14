using UnityEngine;
using UnityEngine.UI;

public class ImageButtons : MonoBehaviour
{
    [SerializeField] GameObject imageButtonPrefab;
    [SerializeField] ImagesData imagesData;
    [SerializeField] SelectImageMode selectImage;

    void Start()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
           //GameObject.Destroy(transform.GetChild(i).gameObject);
        }
        Debug.Log("BUG 31: " + imagesData.images.Length);
        foreach (ImageInfo image in imagesData.images)
        {
            Debug.Log("BUG32: Height Image = " + image.height);
            GameObject obj = Instantiate(imageButtonPrefab, transform);
            RawImage rawimage = obj.GetComponent<RawImage>();
            rawimage.texture = image.texture;
            Button button = obj.GetComponent<Button>();
            button.onClick.AddListener(() => OnClick(image));
        }
    }

    void OnClick(ImageInfo image)
    {
        Debug.Log($"BUG 12: Image clicked {image.texture.name}");
        selectImage.ImageSelected(image);
    }
}
