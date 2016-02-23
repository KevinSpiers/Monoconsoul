using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid : MonoBehaviour {

    public bool displayGridGizmos; 
    public LayerMask unwalkableMask;
    public Vector3 gridWorldSize;
    public float nodeRadius;
    Node[,] grid;
    List<Vector2[]> lines = new List<Vector2[]>();

    float nodeDiameter;
    int gridSizeX, gridSizeY;

    void Awake()
    {
        nodeDiameter = nodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);
        CreateGrid();
    }

    public Node[,] getGridCoordinate
    {
        get
        {
            return grid;
        }
    }

    public int MaxSize
    {
        get
        {
            return gridSizeX * gridSizeY;
        }
    }
    public int XLength
    {
        get
        {
            return gridSizeX;
        }
    }
    public int YLength
    {
        get
        {
            return gridSizeY;
        }
    }

    
    void CreateGrid()
    {
        grid = new Node[gridSizeX, gridSizeY];
        Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.up * gridWorldSize.y / 2;
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.up * (y * nodeDiameter + nodeRadius);
                bool walkable;
                if (Physics2D.OverlapCircle(worldPoint, nodeRadius, unwalkableMask) != null) {
                    walkable = false;
                } else {
                    walkable = true;
                }
                grid[x, y] = new Node(walkable, 0, worldPoint, x, y, null);
            }
        }
        /*
        Obsticles.getInstance().MakeObsticles(this);
        Obsticles.getInstance().SetWaypoints(this);
        List<Node> waypoints = Obsticles.getInstance().GetWaypoints(this);
        for (int i = 0; i < waypoints.Count; i++)
        {
            Node point = waypoints[i];
            for (int j = i + 1; j < waypoints.Count; j++)
            {
                Node point2 = waypoints[j];
                if (!Physics2D.Linecast(point.worldPosition, point2.worldPosition))
                {
                    Node[] line = new Node[2];
                    line[0] = point;
                    line[1] = point2;
                    lines.Add(line);
                }
            }
        }
        */
        GameObject[] walls = GameObject.FindGameObjectsWithTag("wall");
        List<Vector2> corners = new List<Vector2>();
        List<Vector2> originalMin = new List<Vector2>();
        List<Vector2> originalMax = new List<Vector2>();
        Vector2 enemySize = new Vector2(20f,20f);
        float sizeModifier = .001f;
        foreach (GameObject wall in GameObject.FindGameObjectsWithTag("wall"))
        {
            BoxCollider2D wallCollider = wall.GetComponent<BoxCollider2D>();
            wallCollider.size = wallCollider.size + enemySize;

            Vector2 topRight = new Vector2(wallCollider.size.x / 2 + sizeModifier, wallCollider.size.y / 2 + sizeModifier);
            Vector2 bottomLeft =new Vector2(-(wallCollider.size.x / 2 + sizeModifier), -(wallCollider.size.y / 2 + sizeModifier));
            Vector2 topLeft = new Vector2(-(wallCollider.size.x / 2 + sizeModifier), wallCollider.size.y / 2 + sizeModifier);
            Vector2 bottomRight = new Vector2(wallCollider.size.x / 2 + sizeModifier, -(wallCollider.size.y / 2 + sizeModifier));

            topRight = Quaternion.Euler(wall.transform.rotation.eulerAngles) * topRight;
            bottomLeft = Quaternion.Euler(wall.transform.rotation.eulerAngles) * bottomLeft;
            topLeft = Quaternion.Euler(wall.transform.rotation.eulerAngles) * topLeft;
            bottomRight = Quaternion.Euler(wall.transform.rotation.eulerAngles) * bottomRight;

            topRight = (Vector2)wallCollider.bounds.center + topRight;
            bottomLeft = (Vector2)wallCollider.bounds.center + bottomLeft;
            topLeft = (Vector2)wallCollider.bounds.center + topLeft;
            bottomRight = (Vector2)wallCollider.bounds.center + bottomRight;

            corners.Add(topRight);
            corners.Add(bottomLeft);
            corners.Add(topLeft);
            corners.Add(bottomRight);
        }
        
        for (int i = 0; i < corners.Count; i++)
        {
            Vector2 point = corners[i];
            for (int j = i + 1; j < corners.Count; j++)
            {
                Vector2 point2 = corners[j];
                if (!Physics2D.Linecast(point, point2,unwalkableMask))
                {
                    Vector2[] line = new Vector2[2];
                    line[0] = point;
                    line[1] = point2;
                    lines.Add(line);
                }
            }
        }
        for (int i = 0; i < walls.Length; i++)
        {
            GameObject wall = walls[i];
            BoxCollider2D wallCollider = wall.GetComponent<BoxCollider2D>();
            wallCollider.size = wallCollider.size - enemySize;
        }


    }

    public List<Node> GetNeighbors(Node node)
    {
        List<Node> neighbors = new List<Node>();

        for(int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0)
                    continue;
                int checkX = node.gridX + x;
                int checkY = node.gridY + y;

                if(checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
                {
                    neighbors.Add(grid[checkX, checkY]);
                }
            }
        }
        return neighbors;
    }

    public List<Node> GetDiagonalNeighbors(Node node)
    {
        List<Node> neighbors = new List<Node>();

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0)
                    continue;
                if (Mathf.Abs(x) == Mathf.Abs(y))
                {
                    int checkX = node.gridX + x;
                    int checkY = node.gridY + y;

                    if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
                    {
                        neighbors.Add(grid[checkX, checkY]);
                    }
                }
            }
        }
        return neighbors;
    }

    public List<Node> GetFourDirectionNeighbors(Node node)
    {
        List<Node> neighbors = new List<Node>();

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0)
                    continue;
                if (Mathf.Abs(x) != Mathf.Abs(y))
                {
                    int checkX = node.gridX + x;
                    int checkY = node.gridY + y;

                    if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
                    {
                        neighbors.Add(grid[checkX, checkY]);
                    }
                }
            }
        }
        return neighbors;
    }

    public Node NodeFromWorldPoint(Vector3 worldPosition)
    {
        float percentX = (worldPosition.x / gridWorldSize.x) + .5f;
        float percentY = (worldPosition.y / gridWorldSize.y) + .5f;
        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
        int y = Mathf.RoundToInt((gridSizeY - 1) * percentY);

        return grid[x, y];
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, gridWorldSize.y, 1));
        if (grid != null && displayGridGizmos)
        {
            foreach (Node n in grid)
            {
                Gizmos.color = (n.walkable) ? Color.white : Color.red;
                Gizmos.DrawCube(n.worldPosition, Vector3.one * (nodeDiameter * .80f));
            }
        }
        foreach (Vector2[] line in lines)
        {
            Gizmos.DrawLine(line[0], line[1]);
        }
    }
}
