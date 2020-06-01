using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Wave : MonoBehaviour
{
    public GameObject[] dog;
    public AudioSource jumpSFX,coinSFX;
    public int score = 0;
    public Text ScoreText;
    public float moveSpeed = 10f;
    public float jumpSpeed = 10f;
    public bool grounded;
    public float jumpRate = 2f;
    private float nextPress = 0.0f;
    public bool isGameOver = false;
    public bool isJumpingA,isJumpingS,isJumpingD,isJumpingF = false;
    Rigidbody2D rigidbody2D;

    void Start(){
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A) && !isJumpingA){
            Jump(dog[0]);
            isJumpingA = true;
        }
        if (Input.GetKey (KeyCode.S) && !isJumpingS){
            Jump(dog[1]);
            isJumpingS = true;
        }
        if (Input.GetKey (KeyCode.D) && !isJumpingD){
            Jump(dog[2]);
            isJumpingD = true;
        }
        if (Input.GetKey (KeyCode.F) && !isJumpingF){
            Jump(dog[3]);
            isJumpingF = true;
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
           Application.Quit();
        }
        ScoreText.text = "Score: " +score;
        if(isGameOver){
            PlayerPrefs.SetInt("Score", score);
            //LoadScene("GameOver");
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneObject(sceneName));
    }


    public IEnumerator LoadSceneObject(string sceneName)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        async.allowSceneActivation = false;

        // Loop เพื่อตรวจสอบว่าโหลด Object เสร็จหรือยัง
        while (!async.isDone)
        {
            // ทำการคำนวณ progress
            float progress = Mathf.Clamp01(async.progress / 0.9f);
            Debug.Log("Loading progress: " + (progress * 100).ToString("n0") + "%");

            // Loading completed
            if (progress == 1f)
            {
                async.allowSceneActivation = true;
            }
            yield return null;
        }
    }

    public void getItem(){
        score = score + 1;
        coinSFX.Play();
    }

    public void Jump(GameObject dogJump)
    {
        jumpSFX.Play();
        dogJump.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
    }
}
