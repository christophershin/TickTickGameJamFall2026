using UnityEngine;
using UnityEngine.UI;

public class CardPicker : MonoBehaviour
{
    public void PickCard(int i)
    {
        print("CLICKEDDDDD");
        LevelManager.Instance.PickCard(i);
    }
}
