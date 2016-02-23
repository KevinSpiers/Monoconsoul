using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Node : IHeapItem<Node>{
    public bool walkable;
    public Vector3 worldPosition;
    public int gridX;
    public int gridY;

    public int gCost;
    public int hCost;
    public Node parent;
    int _heapIndex;
    private List<Node> list;
    private int waypoint;

    public Node(bool _walkable, int _waypoint, Vector3 _worldPos, int _gridX, int _gridY, List<Node> _list)
    {
        walkable = _walkable;
        worldPosition = _worldPos;
        gridX = _gridX;
        gridY = _gridY;
        list = _list;
    }

    public int Waypoint
    {
        get
        {
            return waypoint;
        }
        set
        {
            waypoint = value;
        }
    }

    public List<Node> List
    {
        get
        {
            return list;
        }
        set
        {
            list = value;
        }
    }

    public int fCost
    {
        get
        {
            return gCost + hCost;
        }
    }
    
    public int HeapIndex
    {
        get
        {
            return _heapIndex;
        }
        set
        {
            _heapIndex = value;
        }
    }

    public int CompareTo(Node nodeToCompare)
    {
        int compare = fCost.CompareTo(nodeToCompare.fCost);
        if(compare == 0)
        {
            compare = hCost.CompareTo(nodeToCompare.hCost);
        }
        return -compare;
    }
}
