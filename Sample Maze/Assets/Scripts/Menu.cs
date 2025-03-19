using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using System.Text;
//using RestSharp;
//using RestSharp.Authenticators;

public class Menu : MonoBehaviour
{
    string apiurl = "https://csi-mrits.tech/api/v1/user/login";
    public TMP_InputField inputField;
    public TMP_InputField passwordField;
    public TMP_Text messageField;

    public IEnumerator PostData(string data)
    {
        UnityWebRequest request = new(apiurl, "POST");

        request.SetRequestHeader("Content-Type", "application/json");

        byte[] bdata = Encoding.UTF8.GetBytes(data);

        request.uploadHandler = new UploadHandlerRaw(bdata);
        request.downloadHandler = new DownloadHandlerBuffer();

        print(request.ToString());

        yield return request.SendWebRequest();

        switch (request.result)
        {
            case UnityWebRequest.Result.InProgress:
                break;
            case UnityWebRequest.Result.Success:
                string response = request.downloadHandler.text;
                print("Success");
                print(response);

                PlayerInfo f = JsonUtility.FromJson<PlayerInfo>(response);
                PlayerPrefs.SetString("token", f.token);

                PlayerPrefs.SetString("teamNumber", inputField.text);

                int sceneNumber = (int)(Random.value * 3f) + 1;

                Cursor.visible = false;

                SceneManager.LoadScene(string.Format("Maze2", sceneNumber));

                break;
            default:
                messageField.color = Color.red;
                messageField.text = "Please enter a valid team number and password. If errors persist, contact our team.";
                print(request.result);
                print(request.error);
                break;
        }
    }

    public void ButtonPressed()
    {
        string name = inputField.text;
        string password = passwordField.text;

        Regex rg = new Regex("[0-9]+");

        if (name == null && name.Length == 0)
        {
            return;
        }

        if (!rg.IsMatch(name))
        {
            Debug.Log("Not matched");
            messageField.color = Color.red;
            messageField.text = "Please enter a valid team number and password and press start when told to do so.";
            return;
        }

        string datatosend = $"{{\"teamNo\": {name}, \"password\": \"{password}\"}}";

        StartCoroutine(PostData(datatosend));

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        //SceneManager.LoadScene(string.Format("Maze1"));



        //var client = new RestClient("https://csi-mrits.tech/api/v1");

        //Dictionary<string, string> parameters = new Dictionary<string, string>();
        //parameters.Add("teamNo", 287.ToString());
        //parameters.Add("Password", "chef");


        //var request = new RestRequest("user/login").AddJsonBody(parameters);

        //var response = await client.PostAsync(request);

        //Debug.Log(response.Content);





        Debug.Log("Matched");


    }
}

public class PlayerInfo
{
    public string status;
    public string token;
    public bool isLogged;

    public PlayerInfo(string s, string t, bool i)
    {
        status = s;
        token = t;
        isLogged = i;
    }
}
