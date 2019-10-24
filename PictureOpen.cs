using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class PictureOpen : MonoBehaviour {

    public static string path;

    void Start() {

        path = ScreenshotController.imagePath;

        //確認
        Debug.Log("path:" + path);

if (Application.platform == RuntimePlatform.OSXEditor) {
        // スクリーンショットの読み込み
        byte[] image1 = File.ReadAllBytes("Assets/name.png");

        // Texture2D を作成して読み込み
        Texture2D tex1 = new Texture2D(0, 0);
        tex1.LoadImage(image1);

        Sprite texture_sprite1 = Sprite.Create(tex1, new Rect(0, 0, tex1.width, tex1.height), Vector2.zero);
        this.GetComponent<Image>().sprite = texture_sprite1;

        Debug.Log("Unity Editor_PictureOpen");

    }
    else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            //バックアップ不要ファイルとする
            UnityEngine.iOS.Device.SetNoBackupFlag(path);
            // スクリーンショットの読み込み
            byte[] image2 = File.ReadAllBytes(path);

            // Texture2D を作成して読み込み
            Texture2D tex2 = new Texture2D(0, 0);
            tex2.LoadImage(image2);

            Sprite texture_sprite2 = Sprite.Create(tex2, new Rect(0, 0, tex2.width, tex2.height), Vector2.zero);
            this.GetComponent<Image>().sprite = texture_sprite2;

            Debug.Log("Iphone");

        }

        //前に撮ったスクショを削除
        //File.Delete(ScreenshotController.imagePath);



    }

}