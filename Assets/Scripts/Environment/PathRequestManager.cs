using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
public class PathRequestManager {

    Queue<PathRequest> PathRequestQueue = new Queue<PathRequest>();
    PathRequest currentPathRequest;
    Pathfinding pathfinding;
    bool isProcessingPath;


    private static PathRequestManager instance = null;
    private PathRequestManager(Pathfinding _pathfinding)
    {
        pathfinding = _pathfinding;
    }

    public static PathRequestManager getInstance(Pathfinding _pathfinding)
    {
        if (instance == null)
        {
            instance = new PathRequestManager(_pathfinding);
        }

        return instance;
    }

	public static void RequestPath(Vector2 pathStart, Vector2 pathEnd, Action<Vector2[],bool> callback)
    {
        PathRequest newRequest = new PathRequest(pathStart, pathEnd, callback);
        instance.PathRequestQueue.Enqueue(newRequest);
        instance.TryProcessNext();
    }

    void TryProcessNext()
    {
        if (!isProcessingPath && PathRequestQueue.Count > 0)
        {
            currentPathRequest = PathRequestQueue.Dequeue();
            isProcessingPath = true;
            pathfinding.StartFindPath(currentPathRequest.pathStart, currentPathRequest.pathEnd);
        }
    }

    public void FinishedProcessingPath(Vector2[] path, bool success)
    {
        currentPathRequest.callback(path, success);
        isProcessingPath = false;
        TryProcessNext();
    }
    
    struct PathRequest
    {
        public Vector2 pathStart;
        public Vector2 pathEnd;
        public Action<Vector2[], bool> callback;

        public PathRequest(Vector2 _start, Vector2 _end, Action<Vector2[], bool> _callback)
        {
            pathStart = _start;
            pathEnd = _end;
            callback = _callback;
        }
    }
}
