using UnityEngine;
using UnityEngine.UI;







public class TileScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created



   
    public ElementsScript elements;


    public Element element;
    public int x;
    public int y;
    SpriteRenderer spriteRenderer;
    public FieldScript field;
    public bool selected;


    public SpriteRenderer zoneSprite;
    //public Image imageComponent;




    void Start()
    {
        //Debug.Log("TileScript init start" );
        spriteRenderer = GetComponent<SpriteRenderer>();
        zoneSprite.color = new Color(1f,1f,1f,0f);
        //Debug.Log("elements " + elements.ToString());
        //elements = GetComponent<ElementsScript>(); // will set to None
        //Debug.Log("GetComponent<ElementsScript>() : " + (elements != null ));
        selected = false;
        elements = GameObject.FindGameObjectWithTag("ElementsTag").GetComponent<ElementsScript>();

        //or :
        //field = FindObjectOfType<Board>();

        //Debug.Log("GameObject.FindGameObjectWithTag :" + (elements != null ));

        //element = Element.neutral;
        //spriteRenderer.sprite = elements.get(element);
        //Debug.Log("TileScript init end");
        SetRandomElement();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setSelected(bool isSelected){

        selected = isSelected;
        float alfa = isSelected ? 0.25f  : 0f;
        zoneSprite.color = new Color(1f,1f,1f,alfa);

    }


    //[ContextMenu("Set Element")]
    public void SetElement(Element ele)
    {
        element = ele;
        spriteRenderer.sprite = elements.get(element);
        
    }

    public void SetRandomElement(){
        Debug.Log("TileScript.SetRandomElement called ");
        SetElement(elements.RandomElement());

    }

    public void UpdatePosition(){
        transform.position =  new Vector2 (x,y) * field.scale + field.wh0;

    }

    public void SwapCoords(TileScript other){
        (x,other.x) = (other.x,x);
        (y,other.y) = (other.y,y);
        UpdatePosition();
        other.UpdatePosition();

    }

    private void OnMouseDown(){
        //SetRandomElement();
        //for debugging 
        setSelected(true);
        field.touch(x,y);
    }

    


}
