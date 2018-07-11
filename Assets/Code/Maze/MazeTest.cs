using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MazeTest : MonoBehaviour {
    const float mapscale = 1;
    const int row = 50, col = 30;
    MazeCreate mazeCreate;
    int Accumulation = 95;//障碍堆积系数
    int Erosion = 30;//障碍侵蚀系数
	// Use this for initialization
    void Start () {
        //mazeCreate = MazeCreate.GetMaze(row, col);

        List<List<int>> mapList = new List<List<int>>();

        for (int i = 0; i < row; i++)
        {
            mapList.Add(new List<int>());
            for (int j = 0; j < col; j++)
            {
                //if (i < 4 || i >= row - 4 || 
                //    j < 4 || j >= col - 4){
                //    mapList[i].Add((int)MazeCreate.PointType.nullpoint);
                //}else{
                //    mapList[i].Add((int)MazeCreate.PointType.wall);
                //}
                mapList[i].Add((int)MazeCreate.PointType.wall);
            }
        }

        mazeCreate = MazeCreate.GetMaze(mapList);



        CreateMap(mazeCreate.tree);

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {

                if (mazeCreate.mapList[i][j] == (int)MazeCreate.PointType.startpoint ||
                    mazeCreate.mapList[i][j] == (int)MazeCreate.PointType.way)
                {
                    GameObject ground = CreateGround(new Vector3(i, j, 0));

                    int x = i, y = 0,xcount = 0,ycount = 0;
                    //for(int )

                }else if (mazeCreate.mapList[i][j] == (int)MazeCreate.PointType.nullpoint)
                {
                    //CreateRocks(new Vector3(i, j, 0));
                }else{
                    //CreateObstacle(new Vector3(i, j, 0));

                }


            }
        }
	}

    void CreateMap(MapTree tree){
        for (int i = tree.children.Count - 1; i >= 0 ; i--)
        {
            CreateMap(tree.children[i]);
        }

        if (tree.children.Count < 1 )
        {
            int rate = Random.Range(0, 100);
            if( rate < Accumulation){
                
                mazeCreate.mapList[(int)tree.position.x][(int)tree.position.y] = (int)MazeCreate.PointType.nullpoint;

                tree.parent.children.Remove(tree);
                return;
            }
        }
        //CreateGround(tree.position + new Vector3(0,33));

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
            //CreateGround(new Vector3(x, y + 33));
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

    GameObject CreateGround(Vector3 v){
        GameObject column = (GameObject)Resources.Load("Prefabs/MapObj/MapGround_1_" + Random.Range(0,3));
        column = MonoBehaviour.Instantiate(column);

        column.transform.position = GameCommon.GetWorldPos(v) * mapscale;
        column.transform.position += new Vector3(0,0,v.y + 100);
        column.transform.localScale = new Vector3(mapscale, mapscale, mapscale);
        return column;
    }

    void CreateObstacle(Vector3 v){
        GameObject column = (GameObject)Resources.Load("Prefabs/MapObj/obstacle_" + Random.Range(0, 4));
        column = MonoBehaviour.Instantiate(column);

        column.transform.position = GameCommon.GetWorldPos(v) * mapscale;
        column.transform.position += new Vector3(0, 0, v.y);
        column.transform.localScale = new Vector3(mapscale, mapscale, mapscale);
    }

    void CreateRocks(Vector3 v)
    {
        GameObject column = (GameObject)Resources.Load("Prefabs/MapObj/rocks_" + Random.Range(0, 8));
        column = MonoBehaviour.Instantiate(column);

        column.transform.position = GameCommon.GetWorldPos(v) * mapscale;
        column.transform.position += new Vector3(0, 0, v.y);
        column.transform.localScale = new Vector3(mapscale, mapscale, mapscale);
    }
}
