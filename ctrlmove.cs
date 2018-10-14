using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ctrlmove : MonoBehaviour {

    // Use this for initialization
    public controller2d ctrl;
    public float movespeed = 40f;
    float horizontalmove = 0f;
    bool jump = false;
    int count = 0;
    int jumpScore = 0;
    public Text countText;
    public Text jumpText;

    void Start()
    {
    
    }
    void Update()
    {
        horizontalmove = Input.GetAxisRaw("Horizontal") * movespeed;
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position);

        if (screenPos.x < 0 || screenPos.y < 0 || screenPos.x > Screen.width /*|| screenPos.y > Screen.height*/)
        {
            ctrl.GameOver();
        }
    }
    void FixedUpdate()
    {
        ctrl.Move(horizontalmove * Time.fixedDeltaTime, jump);
        jump = false;
    }
    void SetJumpScore()
    {
        jumpText.text = "  " + jumpScore.ToString();
    }
    void SetCountText()
    {
         countText.text = "X " + count.ToString();
    }
   
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("New Pick"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        } else if (other.gameObject.CompareTag("Platform")) {
            jumpScore++;
            SetJumpScore();
        }
    }
}
