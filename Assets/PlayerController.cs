using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isJump;

    public GameObject gameClearPanel;
    public GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //プレイヤーの移動
        float x=Input.GetAxisRaw("Horizontal");
        rb.velocity+=new Vector2(x,0)*8f*Time.deltaTime;
        //ジャンプの処理
        if(Input.GetKeyDown(KeyCode.Space)&&!isJump)
        {
            isJump=true;
            rb.AddForce(new Vector2(0,7),ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Graund"))
        {
            isJump=false;
        }
         if(collision.gameObject.CompareTag("Goal"))
        {
            gameClearPanel.SetActive(true);
        }
         if(collision.gameObject.CompareTag("Enemy"))
        {
            gameOverPanel.SetActive(true);
            Destroy(this.gameObject);
    }
}
}