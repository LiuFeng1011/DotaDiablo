using UnityEngine;
using System.Collections;
using System.Runtime.Hosting;
using UnityEngine.SceneManagement;

public class InitializeOnLoad : MonoBehaviour {

	[RuntimeInitializeOnLoadMethod]
	static void Initialize()
	{
        if (SceneManager.GetActiveScene().name == "Game" || 
            SceneManager.GetActiveScene().name == "Logo" || 
            SceneManager.GetActiveScene().name == "Menu" 
           )
		{
            SceneManager.LoadScene("Gate");
		}

	}
}
