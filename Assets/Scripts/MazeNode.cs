using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum NodeState
{
    Possible,
    Current,
    Passed
}

public class MazeNode : MonoBehaviour
{
    [SerializeField] GameObject[] walls;
    [SerializeField] GameObject[] corners;
    [SerializeField] MeshRenderer floor;

    bool[] isActive = {true, true, true, true};

    public void RemoveWall(int windex)
    {
        Debug.Log(walls.Length);
        walls[windex].SetActive(false);
        isActive[windex] = false;

        //CornerManage();
    }

    public void CornerManage()
    {
        if(!isActive[0] && !isActive[2])
        {
            corners[0].SetActive(false);
        }
        if (!isActive[0] && !isActive[3])
        {
            corners[1].SetActive(false);
        }
        if (!isActive[1] && !isActive[2])
        {
            corners[2].SetActive(false);
        }
        if (!isActive[1] && !isActive[3])
        {
            corners[3].SetActive(false);
        }
    }

    public void SetState(NodeState state)
    {
        switch(state)
        {
            case NodeState.Possible:
                //floor.sharedMaterial.color = Color.green;
                break;
            case NodeState.Current:
                //floor.sharedMaterial.color = Color.red;
                break;
            case NodeState.Passed:
                //floor.sharedMaterial.color = Color.blue;
                break;
            default:
                break;
        }
    }
    
}
