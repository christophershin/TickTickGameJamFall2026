using UnityEngine;
using UnityEngine.UI;

public class LevelBar : MonoBehaviour
{
    private Image fillBarImage;
    private float fill;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fillBarImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        fill = LevelManager.Instance.currentExp / LevelManager.Instance.maxExp;
        fillBarImage.rectTransform.localScale = new Vector3(fill, 1f, 1f);
    }
}
