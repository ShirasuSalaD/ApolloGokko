using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInputManager;

public class EMUScriptbeta : MonoBehaviour
{

    //float Speed = 1f;
    Rigidbody rb;
    public const int MAX_JUMP_COUNT = 2;    // ジャンプできる回数

    private int jumpCount = 0;
    private bool isJump = false;


    // Use this for initialization
    void Start()
    {
        CrossPlatformInputManager.gyro.enabled = true;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //自動で前進＆スペースで減速
        //gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 10f));
        //if (CrossPlatformInputManager.GetMouseButton(0) || CrossPlatformInputManager.GetKey(KeyCode.Space))
        //{
        //    gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -15f));
        //}

        //ジャイロで移動
        //Quaternion gyro = CrossPlatformInputManager.gyro.attitude;
        //Quaternion action_gyro = Quaternion.Euler(90, 0, 0) * (new Quaternion(-gyro.x, -gyro.z, -gyro.y, gyro.w));
        //Vector3 p = new Vector3(-action_gyro.y, 0, 0);//ジャイロ操作部分
        //transform.position += p;

        // クリックでジャンプ
        if (jumpCount < MAX_JUMP_COUNT && CrossPlatformInputManager.GetKey("space"))
        {
            isJump = true;
        }

        //シュミレーター上専用
        if (CrossPlatformInputManager.GetKey("right"))
        {
            rb.AddForce(transform.right * -10);
        }
        if (CrossPlatformInputManager.GetKey("left"))
        {
            rb.AddForce(transform.right * 10);
        }
        if (CrossPlatformInputManager.GetKey("up"))
        {
            rb.AddForce(transform.forward * 10);
        }
        if (CrossPlatformInputManager.GetKey("down"))
        {
            rb.AddForce(transform.forward * -10);
        }
        //if (CrossPlatformInputManager.GetKey("space"))
        //{
        //    rb.AddForce(Vector3.up * 10);
    }

    void FixedUpdate()
    {
        if (isJump)
        {
            // 速度をクリアして2回目のジャンプも1回目と同じ挙動にする
            rb.velocity = Vector3.zero;

            // ジャンプさせる
            rb.AddForce(transform.up * 5, ForceMode.Impulse);

            // ジャンプ回数をカウント
            jumpCount++;

            // ジャンプを許可する
            isJump = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 地面との当たり
        if (collision.gameObject.name == "Terrain")
        {
            jumpCount = 0;
        }
    }
}