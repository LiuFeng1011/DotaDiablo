using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MazeTest : MonoBehaviour {
    const float mapscale = 1;
    const int row = 30, col = 30;
    MazeCreate mazeCreate;
    int Accumulation = 70;//障碍堆积系数
    int Erosion = 30;//障碍侵蚀系数
	// Use this for initialization
    void Start () {
        mazeCreate = MazeCreate.GetMaze(row, col);

        string s = "";
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                if (mazeCreate.mapList[i][j] == (int)MazeCreate.PointType.startpoint ||
                    mazeCreate.mapList[i][j] == (int)MazeCreate.PointType.way)
                {
                    CreateMap(new Vector3(i+33, j, 0));
                }
                s += mazeCreate.mapList[i][j];
            }
            s += "\n";
        }
        Debug.Log(s);

        CreateMap(mazeCreate.tree);

        s = "";
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {

                if (mazeCreate.mapList[i][j] == (int)MazeCreate.PointType.startpoint ||
                    mazeCreate.mapList[i][j] == (int)MazeCreate.PointType.way)
                {
                    CreateMap(new Vector3(i, j, 0));
                }
                s += mazeCreate.mapList[i][j];

            }
            s += "\n";
        }
        Debug.Log(s);
	}

    void CreateMap(MapTree tree){
        for (int i = 0; i < tree.children.Count; i++)
        {
            CreateMap(tree.children[i]);
        }

        if (tree.children.Count < 1 )
        {
            int rate = Random.Range(0, 100);
            if( rate < Accumulation){
                
                mazeCreate.mapList[(int)tree.position.x][(int)tree.position.y] = (int)MazeCreate.PointType.wall;

                tree.parent.children.Remove(tree);

                return;
            }
        }
        CreateMap(tree.position + new Vector3(0,33));

        int x = (int)tree.position.x;
        int y = (int)tree.position.y;
        if(x > 0 && mazeCreate.mapList[x-1][y] == (int)MazeCreate.PointType.wall){
            SetMapWay(x - 1, y);
        }
        if (x < mazeCreate.mapList.Count - 1 && mazeCreate.mapList[x + 1][y] == (int)MazeCreate.PointType.wall)
        {
            SetMapWay(x + 1, y);
        }
        if (y > 0 && mazeCreate.mapList[x][y-1] == (int)MazeCreate.PointType.wall)
        {
            SetMapWay(x, y-1);
        }
        if (y < mazeCreate.mapList[x].Count - 1 && mazeCreate.mapList[x][y + 1] == (int)MazeCreate.PointType.wall)
        {
            SetMapWay(x, y + 1);
        }
    }

    void SetMapWay(int x,int y){
        if (Random.Range(0, 100) < Erosion)
        {
            mazeCreate.mapList[x][y] = (int)MazeCreate.PointType.way;
            CreateMap(new Vector3(x, y + 33));
        }
    }

    float addTime = 0;
    int addindex = 0;
	// Update is called once per frame
	void Update () {
        //if (addindex >= mazeCreate.findList.Count)
        //{
        //    return;
        //}

        //addTime += Time.deltaTime;

        //if (addTime > 0.01)
        //{
        //    addTime = 0;
        //    int index = mazeCreate.findList[addindex];

        //    int _row = index / col;
        //    int _col = index % col;

        //    CreateMap(new Vector3(_row, 0, _col));

        //    addindex++;
        //}
	}

    void CreateMap(Vector3 v){
        GameObject column = (GameObject)Resources.Load("Prefabs/MapObj/grassland_1111_" + Random.Range(1,8));
        column = MonoBehaviour.Instantiate(column);

        column.transform.position = GameCommon.GetWorldPos(v) * mapscale;
        column.transform.localScale = new Vector3(mapscale, mapscale, mapscale);
    }
}
