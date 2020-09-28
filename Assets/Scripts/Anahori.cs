using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anahori : MonoBehaviour
{

    //チップ定数
    const int CHIP_NONE = 0;
    const int CHIP_WALL = 1;

    int xStart;
    int yStart;

    // Start is called before the first frame update
    void Start()
    {        
        //開始地点
        xStart = 2;
        yStart = 4;
    }

    public void Create(Layer2D _layer, int width, int height, int x, int y){
        _layer.Initialize(width + 1, height + 1);
        _layer.FillCellValue(CHIP_WALL);

        //穴掘り開始
        _Dig(_layer, x, y);

        //結果
        _layer.Dump();
    }

    void _Dig(Layer2D layer, int x, int y){
        //開始地点を掘る
        layer.SetCellValue(x, y, CHIP_NONE);

        Vector2[] dirList = {
            new Vector2(-1,0), //左
            new Vector2(0,-1), //下
            new Vector2(1,0), //右
            new Vector2(0,1) //上
        };

        //シャッフル
        for(int i=0; i<dirList.Length;i++){
            var tmp = dirList[i];
            var idx = Random.Range(0, dirList.Length - 1);
            dirList[i] = dirList[idx];
            dirList[idx] = tmp;
        }

        foreach(var dir in dirList){
            int dx = (int)dir.x;
            int dy = (int)dir.y;
            if(layer.GetCellValue(x+dx*2, y+dy*2) == 1){
                layer.SetCellValue(x+dx, y+dy, CHIP_NONE);
                _Dig(layer, x+dx*2, y+dy*2);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
