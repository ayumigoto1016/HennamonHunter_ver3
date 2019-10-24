using UnityEngine;  
using System.IO;  
using System.Collections;  
using SocialConnector; 

public class TwitterController : MonoBehaviour{ 


	public void Share(){

        if (Application.platform == RuntimePlatform.OSXEditor)
        {

            Debug.Log("Unity Editor_Share");

        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {

            _Share();

        }



    }  

	public void _Share(){

		// 撮影画像の保存が完了するまで待機
		/*while (true)
		{
			if (File.Exists(Path)) break;
			yield return null;
		}*/

		// 投稿
		string tweetText = "○○匹捕まえたよ！目指せ100匹！";
		string tweetURL = "HENNAMON HUNTER のダウンロードリンク";

		SocialConnector.SocialConnector.Share(tweetText, tweetURL, ScreenshotController.imagePath);


		// 前回のデータの削除
		//File.Delete(Path);
	}
}