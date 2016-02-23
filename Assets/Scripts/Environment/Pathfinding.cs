using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Pathfinding : MonoBehaviour {

    PathRequestManager requestManager;
    Grid grid;

    void Awake()
    {
        requestManager = PathRequestManager.getInstance(this);
        grid = GetComponent<Grid>();
    }
    public void StartFindPath(Vector2 startPos, Vector2 targetPos)
    {
        StartCoroutine(FindPath(startPos, targetPos));
    }

	IEnumerator FindPath(Vector2 _startPos, Vector2 _targetPos)
    {
        Vector2[] waypoints = new Vector2[0];
        bool pathSuccess = false;

        Node startNode = grid.NodeFromWorldPoint(_startPos);
        Node targetNode = grid.NodeFromWorldPoint(_targetPos);

        if (startNode.walkable && targetNode.walkable)
        {
            Heap<Node> openSet = new Heap<Node>(grid.MaxSize);
            HashSet<Node> closedSet = new HashSet<Node>();
            openSet.Add(startNode);

            while (openSet.Count > 0)
            {
                Node currentNode = openSet.RemoveFirst();
                closedSet.Add(currentNode);

                if (currentNode == targetNode)
                {
                    pathSuccess = true;
                    break;
                }

                //Prevent enemy from going diagonally over unwalkable nodes
                List<Node> potentialUnwalkableNodes = new List<Node>();
                List<Node> diagonalNodesFromEnemy = grid.GetDiagonalNeighbors(currentNode);
                foreach (Node neighbor in grid.GetNeighbors(currentNode))
                {
                    if (!neighbor.walkable)
                    {
                        foreach (Node unwalkableNodes in grid.GetFourDirectionNeighbors(neighbor))
                        {
                            if (!neighbor.walkable)
                            {
                                potentialUnwalkableNodes.Add(unwalkableNodes);
                            }
                        }
                    }
                }

                foreach (Node neighbor in grid.GetNeighbors(currentNode))
                {
                    if (!neighbor.walkable || closedSet.Contains(neighbor))
                    {
                        continue;
                    }
                    bool mustContinue = false;
                    foreach(Node unwalkableNode in potentialUnwalkableNodes)
                    {
                        foreach(Node diagonalNode in diagonalNodesFromEnemy)
                        {
                            if (unwalkableNode.Equals(neighbor) && unwalkableNode.Equals(diagonalNode))
                            {
                                mustContinue = true;
                                break;
                            }
                        }
                        if (mustContinue)
                        {
                            break;
                        }
                    }
                    if (mustContinue)
                    {
                        continue;
                    }

                    int newMovementCostToNeighbor = currentNode.gCost + GetDistance(currentNode, neighbor);
                    if (newMovementCostToNeighbor < neighbor.gCost || !openSet.Contains(neighbor))
                    {
                        neighbor.gCost = newMovementCostToNeighbor;
                        neighbor.hCost = GetDistance(neighbor, targetNode);
                        neighbor.parent = currentNode;

                        if (!openSet.Contains(neighbor))
                        {
                            openSet.Add(neighbor);
                        }
                        else
                        {
                            openSet.UpdateItem(neighbor);
                        }
                    }
                }
            }
        }
        yield return null;
        if (pathSuccess)
        {
            waypoints = RetracePath(startNode, targetNode);
        }
        requestManager.FinishedProcessingPath(waypoints, pathSuccess);
    }
    Vector2[] RetracePath(Node startNode, Node endNode)
    {
        List<Node> path = new List<Node>();
        Node currentNode = endNode;
        
        while(currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }

        Vector2[] waypoints = ComplexPath(path);
        //Vector2[] smoothWaypoints = MakeSmoothCurve(waypoints, 2f);
        //List<Vector2> smooth = new List<Vector2>(waypoints);
        //Vector2[] smoothWaypoints = SmoothPath(smooth);
        Array.Reverse(waypoints);
        return waypoints;
    }
    Vector2[] SimplifyPath(List<Node> path)
    {
        List<Vector2> waypoints = new List<Vector2>();
        Vector2 directionOld = Vector2.zero;

        for(int i = 1; i < path.Count; i++)
        {
            Vector2 directionNew = new Vector2(path[i - 1].gridX - path[i].gridX, path[i - 1].gridY - path[i].gridY);
            if(directionNew != directionOld)
            {
                waypoints.Add(path[i].worldPosition);
            }
            directionOld = directionNew;
        }
        return waypoints.ToArray();
    }
    Vector2[] ComplexPath(List<Node> path)
    {
        List<Vector2> waypoints = new List<Vector2>();
        for (int i = 1; i < path.Count; i++)
        {
            waypoints.Add(path[i].worldPosition);
        }

        return waypoints.ToArray();
    }
    public static Vector2[] MakeSmoothCurve(Vector2[] arrayToCurve, float smoothness)
    {
        List<Vector2> points;
        List<Vector2> curvedPoints;
        int pointsLength = 0;
        int curvedLength = 0;

        if (smoothness < 1.0f)
        {
            smoothness = 1.0f;
        }

        pointsLength = arrayToCurve.Length;

        curvedLength = (pointsLength * Mathf.RoundToInt(smoothness)) - 1;
        curvedPoints = new List<Vector2>(curvedLength);

        float t = 0.0f;
        for (int pointInTimeOnCurve = 0; pointInTimeOnCurve < curvedLength + 1; pointInTimeOnCurve++)
        {
            t = Mathf.InverseLerp(0, curvedLength, pointInTimeOnCurve);

            points = new List<Vector2>(arrayToCurve);

            for (int j = pointsLength - 1; j > 0; j--)
            {
                for (int i = 0; i < j; i++)
                {
                    points[i] = (1 - t) * points[i] + t * points[i + 1];
                }
            }

            curvedPoints.Add(points[0]);
        }

        return (curvedPoints.ToArray());
    }
    public static Vector2[] SmoothPath(List<Vector2> path)
    {
        var output = new List<Vector2>();

        if (path.Count > 0)
        {
            output.Add(path[0]);
        }

        for (var i = 0; i < path.Count - 1; i++)
        {
            var p0 = path[i];
            var p1 = path[i + 1];
            var p0x = p0.x;
            var p0y = p0.y;
            var p1x = p1.x;
            var p1y = p1.y;

            var qx = 0.75f * p0x + 0.25f * p1x;
            var qy = 0.75f * p0y + 0.25f * p1y;
            var Q = new Vector2(qx, qy);

            var rx = 0.25f * p0x + 0.75f * p1x;
            var ry = 0.25f * p0y + 0.75f * p1y;
            var R = new Vector2(rx, ry);

            output.Add(Q);
            output.Add(R);
        }

        if (path.Count > 1)
        {
            output.Add(path[path.Count - 1]);
        }

        return output.ToArray();
    }
    int GetDistance(Node _nodeA, Node _nodeB)
    {
        int distX = Mathf.Abs(_nodeA.gridX - _nodeB.gridX);
        int distY = Mathf.Abs(_nodeA.gridY - _nodeB.gridY);

        if (distX > distY)
        {
            return 14 * distY + 10 * (distX - distY);
        }
        return 14 * distX + 10 * (distY - distX);
    }
}
