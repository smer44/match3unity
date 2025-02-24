using UnityEngine;
using System.Collections.Generic;

public class FieldScript : MonoBehaviour
{

    public int w;
    public int h;
    public int w0;//will get from unity 
    public int h0;
    public float scale;

    public GameObject tilePrefab;
    //private TileScript[,] gridScript;
    private GameObject[,] grid;
    public Vector2 wh0 ;
    private Vector2Int lastTouched;
    private bool touchedOnce;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
      w = 9;
      h = 9 ;    
      wh0 = new Vector2 (w0,h0);
      touchedOnce = false;
      var nbrs = ((0,1), (0,-1), (1,0) , (-1,0));
      

      Reset();
        
    }

    void Reset(){
        //gridScript   = new TileScript[w,h]; 
        grid      = new GameObject[w,h]; 
        //grid = new TileScript[w,h];
        for (int i =0; i < w; i++){
            for (int j =0; j < h; j++){
                Vector2 tempPosition = new Vector2 (i,j) * scale ;
                GameObject tile = Instantiate(tilePrefab, tempPosition + wh0 , Quaternion.identity) as GameObject;
                tile.transform.parent = this.transform;
                
                //tile.x = i;
                //tile.y = j;
                grid[i,j] = tile;
                TileScript tileScript = tile.GetComponent<TileScript>();
                //gridScript[i,j] = tileScript;
                tileScript.x = i;
                tileScript.y = j;
                tileScript.field = this; 

                tile.name = "Tile(" + i + ", " + j +  ")" + (tileScript != null) ;

                //tilescript.field = this
                //grid[i,j] = 

            }
        
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void Swap(int x, int y){
        Debug.Log("FieldScript.Swap");
        GameObject temp = grid[x, y];
        GameObject temp2 = grid[lastTouched.x, lastTouched.y];

        temp.GetComponent<TileScript>().SwapCoords(temp2.GetComponent<TileScript>());

        grid[x, y] = temp2;
        grid[lastTouched.x, lastTouched.y] = temp;

        

    }


    public void touch(int x, int y){
        if (! touchedOnce){            
            SetSelect(x,y,true);
            //touchedOnce = true;
            Debug.Log("FieldScript.touch once");
        }
        else{
            SetSelect(x,y,false);
            if (IsNbrOfLastTouch(x,y)) {

                Swap(x,y);               

            }

        }
    }


    public int CellValue(int x, int y){

        return (int) grid[x,y].GetComponent<TileScript>().element;
    }

    public void SetSelect(int x, int y, bool flag){
        grid[x,y].GetComponent<TileScript>().setSelected( flag);
        if (flag)
            lastTouched = new Vector2Int(x,y);
        touchedOnce = flag;
    }

    public (int,int) StraightHorizontalLine(int x, int y){
        var value = CellValue(x,y);
        var xleft = x-1;
        while( 0 <= xleft && value == CellValue(xleft,y)){
            xleft -=1;
        }
        xleft +=1;

        var xright = x+1;
        while( xright <= w && value == CellValue(xright,y)){
            xright+=1;
        }
        xright -=1 ; 
        return (xleft, xright);
    }


    public (int,int) StraightVerticalLine(int x, int y){
        var value = CellValue(x,y);
        var yleft = y-1;
        while( 0 <= yleft && value == CellValue(x,yleft)){
            yleft -=1;
        }
        yleft +=1;

        var yright = y+1;
        while( yright <= h && value == CellValue(x,yright)){
            yright+=1;
        }
        yright -=1 ; 
        return (yleft, yright);
    }


    public bool match(int x, int y, List<(int,int)> ret){
        //List<(int,int)> ret = new List<(int,int)>();
        bool isMatched = false;
        var (xleft, xright) = StraightHorizontalLine (x, y);
        if (xright - xleft >=2 ) {
            isMatched = true;
            for (int xx = xleft; xx <= xright; xx++){
                ret.Add((xx,y));
            }
        }
        var (yleft, yright) = StraightVerticalLine (x, y);
        if (yright - yleft >=2 ) {
            isMatched = true;
            for (int yy = yleft; yy <= yright; yy++){
                ret.Add((x,yy));
            }            

        }
        return isMatched;
    }









    public int Absi(int x){
        if (x < 0){
            return -x ;
        }
        else{
            return x ;
        }

    }

    public bool IsNbrOfLastTouch(int x, int y){
        int d = Absi(x - lastTouched.x) + Absi(y - lastTouched.y);
        return d == 1;
        
    }


}
