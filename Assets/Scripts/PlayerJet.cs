using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJet : MonoBehaviour
{

    public GameObject[] upJetsObj;
    List<ParticleSystem> upJets = new List<ParticleSystem>();
    // Use this for initialization
    void Start()
    {
        //ジェット噴射システム
        foreach (var obj in upJetsObj)
        {
            upJets.Add(obj.GetComponent<ParticleSystem>());
        }

    }

    // Update is called once per frame
    void Update()
    {
        //アクション時にジェット噴射
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            foreach (var ps in upJets)
            {
                ps.Play();
            }
        }
        else
        {
            foreach (var ps in upJets)
            {
                ps.Stop();
            }
        }
    }
}
