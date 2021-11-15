using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PathSystem : MonoBehaviour
{
    public enum SeedType { RANDOM, CUSTOM}
    [Header("Random Data")]
    public SeedType seedType = SeedType.RANDOM;

    System.Random random;
    public int seed = 0;

    [Space]
    public bool animatedPath;
    public List<GridCell> gridCellList = new List<GridCell>();
    public int pathLength = 10;

    [Range(1.0f, 7.0f)]
    public float cellSize = 1.0f;

    public Transform startLocation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void setSeed()
    {
        if(seedType == SeedType.RANDOM)
        {
            random = new System.Random();
        }
        else if(seedType == SeedType.CUSTOM)
        {
            random = new System.Random(seed);
        }
    }

    // Update is called once per frame
    void createPath()
    {
        gridCellList.Clear();
        //Vector2 currentPosition = startLocation.transform.position;
        // grid gc = new MyGridCell(currentPosition);
        Vector2 currentPosition = new Vector2(-15.0f, -9.0f);
        gridCellList.Add(new GridCell(currentPosition));

        //GameObject go = Instantiate(newGameObject("Block"), currentPosition, Quaternion.identity);
        //BoxCollider2D bc = go.AddComponent<BoxCollider2D>();
       // Instantiate(thingToSpawn, currentSpawn)

        for(int i = 0; i < pathLength; i++)
        {
            int n = random.Next(100);

            if(n > 0 && n < 49)
            {
                currentPosition = new Vector2(currentPosition.x + cellSize, currentPosition.y);
            }
            else
            {
                currentPosition = new Vector2(currentPosition.x, currentPosition.y + cellSize);
            }

            gridCellList.Add(new GridCell(currentPosition));
            //go = Instantiate(newGameObject("Block"), currentPosition, Quaternion.identity);

        }
    }

    IEnumerator CreatePathRoutine()
    {
        gridCellList.Clear();
        Vector2 currentPosition = new Vector2(-15.0f, -9.0f);

        gridCellList.Add(new GridCell(currentPosition));
        
        for(int i = 0; i < pathLength; i++)
        {
            int n = random.Next(100);

            if(n > 0 && n < 49)
            {
                currentPosition = new Vector2(currentPosition.x + cellSize, currentPosition.y);
            }
            else
            {
                currentPosition = new Vector2(currentPosition.x, currentPosition.y + cellSize);
            }

            gridCellList.Add(new GridCell(currentPosition));
            yield return null;
        }
    }

    private void OnDrawGizmos()
    {
        for(int i = 0; i < gridCellList.Count; i++)
        {
            Gizmos.color = Color.white;
            Gizmos.DrawWireCube(gridCellList[i].location, Vector2.one * cellSize);

            Gizmos.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
            Gizmos.DrawCube(gridCellList[i].location, Vector2.one * cellSize);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            setSeed();
            if (animatedPath)
            {
                StartCoroutine(CreatePathRoutine());
            }
            else
            {
                createPath();
            }
        }
    }

}
