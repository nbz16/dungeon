using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour
{

    public GameObject floor;
    public GameObject wall;
    public int width;
    public int height;
    public int startX;
    public int startY;

    Layer2D layer;
    Anahori ana;
    int[] values;

    // Start is called before the first frame update
    void Start()
    {
        ana = new Anahori();
        layer = new Layer2D();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            ana.Create(layer, width, height, startX, startY);
            values = layer.Values;

            for(int y=0;y<height;y++){
                for(int x=0;x<width;x++){
                    
                    if(values[y*height+x] == 1){
                        Instantiate(wall, new Vector3(x,0f,y), Quaternion.identity);
                    }
                    else if(values[y*height+x] == 0){
                        Instantiate(floor, new Vector3(x,0f,y), Quaternion.identity);
                    }
                }
            }
        }
    }
}
