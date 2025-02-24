using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public enum Element
    {
        neutral,
        fire,
        water,
        grass,
        electro,
        grape
    };

public class ElementsScript : MonoBehaviour
{



    public Sprite neutralSprite;
    public Sprite fireSprite;
    public Sprite waterSprite;
    public Sprite grassSprite;
    public Sprite electroSprite;
    public Sprite grapeSprite;

    public Dictionary<Element, Sprite> icons;
    //private Element[] values;
    //private UnityEngine.Random random;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake(){
        Debug.Log("ElementsScript Awake start");
        icons = new Dictionary<Element, Sprite>();
        icons.Add(Element.neutral, neutralSprite);
        icons.Add(Element.fire, fireSprite);
        icons.Add(Element.water, waterSprite);
        icons.Add(Element.grass, grassSprite);
        icons.Add(Element.electro, electroSprite);
        icons.Add(Element.grape, grapeSprite);

        //values = Enum.GetValues(typeof(Element));
        //random = new UnityEngine.Random();
        Debug.Log("ElementsScript Awake end");

    }


    void Start()
    {   



    }

    public Sprite get(Element ele){
        return icons[ele];
    }

    public Element RandomElement(){
        return (Element) UnityEngine.Random.Range (0, (int) Element.grape);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override string ToString(){

        return "<ElementsScript: " + icons.ToString() + ">";
    }
}
