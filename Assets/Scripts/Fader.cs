using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnFade()
    {
        SceneManager.LoadScene("GameOver");
    }
    
    
}
