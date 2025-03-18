using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField] public MazeNode mazeNode;
    [SerializeField] public Vector2Int mazeSize;
    [SerializeField] public float nodeSize = 1f;
    [SerializeField] public bool autoUpdate = true;

    private void Start()
    {
        //GenerateMaze(mazeSize);
        //StartCoroutine(IGenerateMaze(mazeSize));
    }

    public void ClearMaze()
    {

    }

    public void GenerateMaze(Vector2Int size)
    {
        List<MazeNode> nodes = new List<MazeNode>();

        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                Vector3 pos = new Vector3(x - (size.x) / 2f, 0, y - (size.y) / 2f) * nodeSize;
                MazeNode node = Instantiate(mazeNode, pos, Quaternion.identity, transform);
                nodes.Add(node);
            }
        }

        List<MazeNode> currentPath = new();
        List<MazeNode> completedNodes = new();

        currentPath.Add(nodes[Random.Range(0, nodes.Count)]);
        currentPath[0].SetState(NodeState.Current);

        while (completedNodes.Count < nodes.Count)
        {

            List<int> possibleNodes = new();
            List<int> possibleDirections = new();

            int cnindex = nodes.IndexOf(currentPath[^1]);
            Vector2Int cnpos = new(cnindex / size.y, cnindex % size.y);

            if (cnpos.x < size.x - 1)
            {
                if (!completedNodes.Contains(nodes[cnindex + size.y]) && !currentPath.Contains(nodes[cnindex + size.y]))
                {
                    possibleDirections.Add(1);
                    possibleNodes.Add(cnindex + size.y);
                }
            }

            if (cnpos.x > 0)
            {
                if ((!completedNodes.Contains(nodes[cnindex - size.y]) && !currentPath.Contains(nodes[cnindex - size.y])))
                {
                    possibleDirections.Add(2);
                    possibleNodes.Add(cnindex - size.y);
                }
            }

            if (cnpos.y < size.y - 1)
            {
                if (!completedNodes.Contains(nodes[cnindex + 1]) && !currentPath.Contains(nodes[cnindex + 1]))
                {
                    possibleDirections.Add(3);
                    possibleNodes.Add(cnindex + 1);
                }
            }

            if (cnpos.y > 0)
            {
                if ((!completedNodes.Contains(nodes[cnindex - 1]) && !currentPath.Contains(nodes[cnindex - 1])))
                {
                    possibleDirections.Add(4);
                    possibleNodes.Add(cnindex - 1);
                }
            }


            if (possibleDirections.Count > 0)
            {
                int cDirection = Random.Range(0, possibleDirections.Count);
                MazeNode cNode = nodes[possibleNodes[cDirection]];

                switch (possibleDirections[cDirection])
                {
                    case 1:
                        cNode.RemoveWall(1);
                        currentPath[^1].RemoveWall(0);
                        break;
                    case 2:
                        cNode.RemoveWall(0);
                        currentPath[^1].RemoveWall(1);
                        break;
                    case 3:
                        cNode.RemoveWall(3);
                        currentPath[^1].RemoveWall(2);
                        break;
                    case 4:
                        cNode.RemoveWall(2);
                        currentPath[^1].RemoveWall(3);
                        break;
                }

                currentPath.Add(cNode);
                cNode.SetState(NodeState.Current);
            }

            else
            {
                completedNodes.Add(currentPath[^1]);
                currentPath[^1].SetState(NodeState.Passed);
                currentPath.RemoveAt(currentPath.Count - 1);
            }

        }
    }

    public void DestroyCurrentMaze()
    {
        foreach(Transform child in transform)
        {
            DestroyImmediate(child.gameObject);
        }
    }

    IEnumerator IGenerateMaze(Vector2Int size)
    {
        List<MazeNode> nodes = new List<MazeNode>();

        for(int x = 0; x < size.x; x++)
        {
            for(int y = 0; y < size.y; y++)
            {
                Vector3 pos = new Vector3(x - (size.x) / 2f, 0, y - (size.y) / 2f);
                MazeNode node = Instantiate(mazeNode, pos, Quaternion.identity, transform);
                nodes.Add(node);

                yield return null;
            }
        }

        List<MazeNode> currentPath = new();
        List<MazeNode> completedNodes = new();

        currentPath.Add(nodes[Random.Range(0, nodes.Count)]);
        //currentPath[0].SetState(NodeState.Current);

        while (completedNodes.Count < nodes.Count)
        {

            List<int> possibleNodes = new();
            List<int> possibleDirections = new();

            int cnindex = nodes.IndexOf(currentPath[^1]);
            Vector2Int cnpos = new(cnindex / size.y, cnindex % size.y);

            if (cnpos.x < size.x - 1)
            {
                if (!completedNodes.Contains(nodes[cnindex + size.y]) && !currentPath.Contains(nodes[cnindex + size.y]))
                {
                    possibleDirections.Add(1);
                    possibleNodes.Add(cnindex + size.y);
                }
            }

            if (cnpos.x > 0)
            {
                if ((!completedNodes.Contains(nodes[cnindex - size.y]) && !currentPath.Contains(nodes[cnindex - size.y])))
                {
                    possibleDirections.Add(2);
                    possibleNodes.Add(cnindex - size.y);
                }
            }

            if (cnpos.y < size.y - 1)
            {
                if (!completedNodes.Contains(nodes[cnindex + 1]) && !currentPath.Contains(nodes[cnindex + 1]))
                {
                    possibleDirections.Add(3);
                    possibleNodes.Add(cnindex + 1);
                }
            }

            if (cnpos.y > 0)
            {
                if ((!completedNodes.Contains(nodes[cnindex - 1]) && !currentPath.Contains(nodes[cnindex - 1])))
                {
                    possibleDirections.Add(4);
                    possibleNodes.Add(cnindex - 1);
                }
            }


            if (possibleDirections.Count > 0)
            {
                int cDirection = Random.Range(0, possibleDirections.Count);
                MazeNode cNode = nodes[possibleNodes[cDirection]];

                switch (possibleDirections[cDirection])
                {
                    case 1:
                        cNode.RemoveWall(1);
                        currentPath[^1].RemoveWall(0);
                        break;
                    case 2:
                        cNode.RemoveWall(0);
                        currentPath[^1].RemoveWall(1);
                        break;
                    case 3:
                        cNode.RemoveWall(3);
                        currentPath[^1].RemoveWall(2);
                        break;
                    case 4:
                        cNode.RemoveWall(2);
                        currentPath[^1].RemoveWall(3);
                        break;
                }

                currentPath.Add(cNode);
                //cNode.SetState(NodeState.Current);
            }

            else
            {
                completedNodes.Add(currentPath[^1]);
                //currentPath[^1].SetState(NodeState.Passed);
                currentPath.RemoveAt(currentPath.Count - 1);
            }

            yield return new WaitForSeconds(0.05f);
        } 
    }
}
