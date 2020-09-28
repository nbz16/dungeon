using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer2D : MonoBehaviour
{
    int _width; //幅
    int _height; //高さ
    int _outOfRange = -1; //領域外
    int[] _values = null; //マップデータ

    // 幅の取得
    public int Width{
        get{return _width;}
    }
    // 高さの取得
    public int Height{
        get{return _height;}
    }
    // マップデータの取得
    public int[] Values{
        get{return _values;}
    }

    //初期化
    public void Initialize(int width, int height){
        _width = width;
        _height = height;
        _values = new int[Width * Height];
    }

    //座標をインデックスに変換
    public int ToIdx(int x, int y){
        return x + (y * Width);
    }

    //領域外かチェック
    public bool IsOutOfRange(int x, int y){
        if(x < 0 || x >= Width || y < 0 || y >= Height) return true;
        return false;
    }

    /// 指定した座標の値を取得
    /// @param x X座標
    /// @param y Y座標
    /// @return 指定した座標の値(領域外であれば_outOfRange=-1を返す)
    public int GetCellValue(int x, int y){
        if(IsOutOfRange(x, y)) return _outOfRange;
        return _values[y*Width+x];
    }

    /// 指定した座標に値を設定する
    /// @param x X座標
    /// @param y Y座標
    /// @param v 設定する値
    public void SetCellValue(int x, int y, int v){
        if(IsOutOfRange(x, y)) return;
        _values[y*Width+x] = v;
    }

    //全てのセルに指定した値を設定する
    public void FillCellValue(int v){
        for(int y = 0;y<Height;y++){
            for(int x = 0;x<Width;x++){
                SetCellValue(x, y, v);
            }
        }
    }

    //デバッグ出力
    public void Dump(){
        Debug.Log("[Layer2D] (w,h)=(" + Width + "," + Height + ")");
        for(int y=0;y<Height;y++){
            string s = "";
            for(int x=0;x<Width;x++){
                s+=GetCellValue(x,y) + ",";
            }
            Debug.Log(s);
        }
    }
}
