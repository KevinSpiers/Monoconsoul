using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Obsticles {

    private static Obsticles instance = null;
    private Obsticles() { }
    public List<List<Node>> obsticles = new List<List<Node>>();
    public static Obsticles getInstance()
    {
        if (instance == null)
        {
            instance = new Obsticles();
        }

        return instance;
    }

    public void AddNodeToObsticles(Grid grid, Node point)
    {
        if (!point.walkable)
        {
            if (point.List == null)
            {
                List<Node> neighbors = grid.GetFourDirectionNeighbors(point);
                List<Node> nodeList = null;
                foreach(Node node in neighbors)
                {
                    if (!node.walkable)
                    {
                        if (node.List != null)
                        {
                            nodeList = node.List;
                        }
                    }
                }
                if(nodeList == null)
                {
                    nodeList = new List<Node>();
                    obsticles.Add(nodeList);
                    foreach(Node node in neighbors)
                    {
                        if (!node.walkable)
                        {
                            nodeList.Add(node);
                            node.List = nodeList;
                        }
                    }
                }
                nodeList.Add(point);
                point.List = nodeList;
            }
        }
    }

    public void MakeObsticles(Grid grid)
    {
        for(int x = 0; x < grid.XLength; x++)
        {
            for(int y = 0; y < grid.YLength; y++)
            {
                AddNodeToObsticles(grid, grid.getGridCoordinate[x,y]);
            }
        }
    }

    //Waypoint = 1 -> corner 
    //Waypoint = -1 -> Not possible to be a corner 
    //Waypoint = 0 -> unassigned
    public void SetWaypoints(Grid grid)
    {
        foreach(List<Node> obsticle in obsticles)
        {
            foreach(Node point in obsticle)
            {
                foreach(Node node in grid.GetFourDirectionNeighbors(point))
                {
                    if(node.Waypoint != 1)
                    {
                        if (node.walkable)
                        {
                            node.Waypoint = -1;
                        }
                    }
                }
            }
            foreach (Node point in obsticle)
            {
                foreach (Node node in grid.GetDiagonalNeighbors(point))
                {
                    if (node.Waypoint != -1)
                    {
                        if (node.walkable)
                        {
                            node.Waypoint = 1;
                        }
                    }
                }
            }
            foreach (Node point in obsticle)
            {
                foreach (Node node in grid.GetFourDirectionNeighbors(point))
                {
                    if (node.Waypoint != 1)
                    {
                        if (node.walkable)
                        {
                            node.Waypoint = 0;
                        }
                    }
                }
            }
        }
    }
    public List<Node> GetWaypoints(Grid grid)
    {
        List<Node> waypoints = new List<Node>();
        for(int x = 0; x < grid.XLength; x++)
        {
            for(int y = 0; y < grid.YLength; y++)
            {
                if(grid.getGridCoordinate[x,y].Waypoint == 1)
                {
                    waypoints.Add(grid.getGridCoordinate[x, y]);
                }
            }
        }
        return waypoints;
    }
}
