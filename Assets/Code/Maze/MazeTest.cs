using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeTest : MonoBehaviour {
    const float mapscale = 10;
    const int row = 6, col = 10;
    MazeCreate mazeCreate;
	// Use this for initialization
    void Start () {
        mazeCreate = MazeCreate.GetMaze(row, col);

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {

                if (mazeCreate.mapList[i][j] == (int)MazeCreate.PointType.startpoint ||
                    mazeCreate.mapList[i][j] == (int)MazeCreate.PointType.way)
                {
                    CreateMap(new Vector3(i, 0, j));
                }

            }
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
        GameObject column = (GameObject)Resources.Load("Prefabs/Map/mapcube");
        column = MonoBehaviour.Instantiate(column);

        column.transform.position = v * mapscale;
        column.transform.localScale = new Vector3(mapscale, mapscale, mapscale);
    }
}
