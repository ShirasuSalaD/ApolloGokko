using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeMain : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Main");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // スタート画面へ
        if (collision.gameObject.name == "goal")
        {
            SceneManager.LoadScene("Goal");
        }
    }

}
