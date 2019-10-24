using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MashGameManager : MonoBehaviour
{
    //Get a public reference to the game objects that have the scripts
    public GameObject travis;
    public GameObject dessy;

    //and also start a public reference to our scripts too
    public TravisBar travisBarScript;
    public DessyBar dessyBarScript;
    
    
    void Start()
    {
        //use both to get the script from the game objects;
        travisBarScript = travis.GetComponent<TravisBar>();
        dessyBarScript = dessy.GetComponent<DessyBar>();
    }

    
    void Update()
    {
        if (travisBarScript.travisWins)
        {
            dessyBarScript.enabled = false;
            Debug.Log("Disable Dessy Script");
            //SceneManager.LoadScene("CHAPTER 1.2");
        }
        
        if (dessyBarScript.dessyWins)
        {
            travisBarScript.enabled = false;
            Debug.Log("Disable Travis Script");
        }
    }
}
