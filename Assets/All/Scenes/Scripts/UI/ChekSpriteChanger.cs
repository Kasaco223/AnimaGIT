using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class ChekSpriteChanger : MonoBehaviour
{
    [SerializeField] public List<Sprite> checkSpritesT;
    [SerializeField] public List<Sprite> checkSpritesF;

    private List<Image> images = new List<Image>();
    private bool[] states = new bool[8];

    private void Start()
    {
        for (int i = 1; i <= 8; i++)
        {
            Transform child = transform.Find(i.ToString());
            if (child != null)
            {
                Image image = child.GetComponent<Image>();
                if (image != null)
                {
                    images.Add(image);
                }
            }
        }
    }

    private void Update()
    {
        for (int i = 0; i < 8; i++)
        {
            states[i] = GetLevelState(i + 1);
            UpdateSprite(images[i], states[i], i);
        }
    }

    private bool GetLevelState(int level)
    {
        switch (level)
        {
            case 1: return LevelMaster2.lvl1;
            case 2: return LevelMaster2.lvl2;
            case 3: return LevelMaster2.lvl3;
            case 4: return LevelMaster2.lvl4;
            case 5: return LevelMaster2.lvl5;
            case 6: return LevelMaster2.lvl6;
            case 7: return LevelMaster2.lvl7;
            case 8: return LevelMaster2.lvl8;
            default: return false;
        }
    }

    private void UpdateSprite(Image image, bool levelState, int index)
    {
        if (image != null)
        {
            image.sprite = levelState ? checkSpritesT[index] : checkSpritesF[index];
        }
    }
}
