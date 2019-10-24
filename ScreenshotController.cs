using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class ScreenshotController : MonoBehaviour {

	private bool isDoubleTapStart;
	private float doubleTapTime; //タップ開始からの累積時間
	public static string imagePath;
    public static string imageName;



    void Start () {

	
	}

	// Update is called once per frame
	void Update () {


		if (isDoubleTapStart){

			doubleTapTime += Time.deltaTime;

			if (doubleTapTime < 0.2f) {

				if (Input.GetMouseButtonDown (0)) {
					//ダブルクリックしたとき
					isDoubleTapStart = false;
					doubleTapTime = 0.0f;
                    KeepPhoto();
                    Capture ();
					

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

	}


	public void Capture()
	{
        if (Application.platform == RuntimePlatform.OSXEditor)
        {
            ScreenCapture.CaptureScreenshot("Assets/name.png");

        }

        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {

            ScreenCapture.CaptureScreenshot("name.png");
        }

    }

    public static void KeepPhoto(){


        if (Application.platform == RuntimePlatform.OSXEditor)
        {
            imageName = "name.png";
            imagePath = "gotouayumi/HennamonHunter/Assets/" + imageName;
            Debug.Log("Unity Editor_Screenshot");
        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            imageName = "name.png";
            imagePath = Application.persistentDataPath + "/" + imageName;
            Debug.Log("Iphone");
            Debug.Log("imagePath:" + imagePath);
        }



    }


}
