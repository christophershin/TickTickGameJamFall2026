using UnityEngine;
using UnityEngine.UI;

public class LevelBar : MonoBehaviour
{
    private Image fillBarImage;
    private float fill = 0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fillBarImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        float max = LevelManager.Instance.maxExp;
        float ratio = max > 0f ? Mathf.Clamp01(LevelManager.Instance.currentExp / max) : 0f;
        fillBarImage.rectTransform.localScale = new Vector3(ratio, 1f, 1f);
    }
}
