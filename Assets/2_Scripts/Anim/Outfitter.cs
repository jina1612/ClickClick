using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class Outfitter : MonoBehaviour
{
    private List<SpriteResolver> resolvers;
    private CharacterType charType;


    private enum CharacterType
    {
        Ork,
        Bandit
    }


    private void Awake()
    {
        resolvers = GetComponentsInChildren<SpriteResolver>().ToList();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            charType = charType == CharacterType.Ork ? CharacterType.Bandit : CharacterType.Ork;
            Debug.Log("charType : " + charType);
            ChangeOutfit();
        }
    }

    private void ChangeOutfit()
    {
        foreach (SpriteResolver resolver in resolvers)
        {
            resolver.SetCategoryAndLabel(resolver.GetCategory(), charType.ToString());
            Debug.Log($"set cate : {resolver.GetCategory()}");
        }
    }
}
