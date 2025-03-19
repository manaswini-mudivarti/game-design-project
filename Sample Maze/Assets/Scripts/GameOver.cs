using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Text;

public class GameOver : MonoBehaviour
{
    public Animator animator;
    public GameManager manager;
    public GameObject player;
    public bool isHereGameOver = false;
    public GameObject evmg;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            manager.isGameOver = true;
        }
    }

    public IEnumerator SetData()
    {
        var teamNumber = PlayerPrefs.GetString("teamNumber");
        var reqstr = $"https://csi-mrits.tech/api/v1/user/{teamNumber}";
        UnityWebRequest request = new(reqstr, "PATCH");
        request.SetRequestHeader("authorization", $"Bearer {PlayerPrefs.GetString("token")}");
        request.SetRequestHeader("Content-Type", "application/json");

        var z = new PatchCreate
        {
            round2 = (60 * 20f) - PlayerPrefs.GetFloat("finishTime"),
            isLogged = true
        };

        var reqstring = JsonUtility.ToJson(z);

        var s = Encoding.UTF8.GetBytes(reqstring);

        request.uploadHandler = new UploadHandlerRaw(s);
        request.downloadHandler = new DownloadHandlerBuffer();

        print(reqstr);
        print(reqstring);

        yield return request.SendWebRequest();

        switch (request.result)
        {
            case UnityWebRequest.Result.InProgress:
                break;
            case UnityWebRequest.Result.Success:
                string response = request.downloadHandler.text;
                print(response);
                var pr = JsonUtility.FromJson<PatchResponse>(response);
                print(pr.status);
                print(pr.msg);

                break;
            default:
                print("Error");
                print(request.result);
                print(request.error);
                break;
        }

        animator.SetTrigger("IsLevelTime");

        yield return null;
    }

    public void FinishGame()
    {
        player.SetActive(false);
        evmg.SetActive(false);

        isHereGameOver = true;
        PlayerPrefs.SetFloat("finishTime", manager.time);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        StartCoroutine(SetData());  
        animator.SetTrigger("IsLevelTime");
        //manager.isGameOver = true;
    }

    public void LoadNextScene()
    {
        //SceneManager.LoadScene("GameOver");
    }

    private void Update()
    {
        if (manager.isGameOver && !isHereGameOver)
        {
            FinishGame();
        }
    }
}

public class PatchResponse
{
    public string status;
    public string msg;

    public PatchResponse(string s, string m)
    {
        status = s;
        msg = m;
    }
}

public class PatchCreate
{
    public float round2;
    public bool isLogged;
}