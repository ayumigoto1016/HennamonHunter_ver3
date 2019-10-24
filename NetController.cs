using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class NetController : MonoBehaviour {
    public Animation ami;
    public GameObject amiobject;

    private Vector3 playerPos;
	private Vector3 mousePos;

    private bool isAnimationPlay;
	private bool isDoubleTapStart;
	private bool isCaught; //捕まってるかどうかのフラグ
	private float doubleTapTime; //タップ開始からの累積時間
    public static int number;

    SpriteRenderer spriteRenderer;
    SpriteRenderer amispriteRenderer;

    public AudioSource SE;

    void Start() {
        
        this.transform.position = new Vector2(1,-4);
        this.spriteRenderer = GetComponent<SpriteRenderer>();

        amiobject = GameObject.Find("ami");
        ami = amiobject.GetComponent<Animation>();

        
        amispriteRenderer = amiobject.GetComponent<SpriteRenderer>();
        amispriteRenderer.color = new Color(1, 1, 1, 0);

        SE = amiobject.GetComponent<AudioSource>();
    }



	void Update()
	{
		this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, -2, 2),Mathf.Clamp(this.transform.position.y, -5, 5), this.transform.position.z);
		//的の動ける範囲を制限
		playerControl ();
		//指で操作
	
		if (isDoubleTapStart){
			
			doubleTapTime += Time.deltaTime;
			if (doubleTapTime < 0.2f) {

				if (Input.GetMouseButtonDown (0)) {
					//ダブルクリックしたとき
					isDoubleTapStart = false;
					doubleTapTime = 0.0f;
                    ChangeTransparency(0); // 照準は完全に透明、網は表示にする
                    Debug.Log("アニメ");
                    isAnimationPlay = true;
                  

                    if (isCaught) {
                        
                        StartCoroutine ("WaitAndLoadWin");
                        number += 1;

                        // スコアを保存
                        PlayerPrefs.SetInt("SCORE", number);
                        PlayerPrefs.Save();

                        //Hennamonと的が接触してたとき

                    } else {

						StartCoroutine ("WaitAndLoadLose");

					}   //Hennamonと的が接触してなかったとき




				}

			} else {
				//２回クリックしたけど、遅すぎてダブルクリックと判定されなかった
				isDoubleTapStart = false;
				doubleTapTime = 0.0f;
			}


		} else {
			if (Input.GetMouseButtonDown (0)) {
				//１回目のクリック
				isDoubleTapStart = true; 


			}
		}

        if (isAnimationPlay)
        {
            ami.Play();
            SE.Play();
        }
        else
        {
            isAnimationPlay = false;
        }

	}

	void OnTriggerEnter2D(Collider2D ob){

		if (ob.gameObject.tag == "Hennamon") {
			isCaught = true;

		}

	}
	void OnTriggerExit2D(Collider2D ob){
		
		if (ob.gameObject.tag == "Hennamon") {
			isCaught = false;

		}

	}


	IEnumerator WaitAndLoadWin(){
		yield return new WaitForSeconds(1);
		SceneManager.LoadScene("ResultSceneWin");
	}
	IEnumerator WaitAndLoadLose(){
		yield return new WaitForSeconds(1);
		SceneManager.LoadScene("ResultSceneLose");
	}


	private void playerControl()
	{
		if (Input.GetMouseButtonDown(0))
		{
			playerPos = this.transform.position;
			mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}
		if (Input.GetMouseButton(0))
		{
			Vector3 prePos = this.transform.position;
			Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - mousePos;
			//タッチ対応デバイス使用時、1本目の指にのみ反応
			if (Input.touchSupported)
			{
				diff = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position) - mousePos;
			}
			diff.z = 0.0f;
			this.transform.position = playerPos + diff;
		}
		if (Input.GetMouseButtonUp(0))
		{
			playerPos = Vector3.zero;
			mousePos = Vector3.zero;
		}
	}

    void ChangeTransparency(float alpha)
    {
        this.spriteRenderer.color = new Color(1, 1, 1, alpha);
        amispriteRenderer.color = new Color(1, 1, 1, 1-alpha);

    }
}
