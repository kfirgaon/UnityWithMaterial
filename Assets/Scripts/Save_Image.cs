using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Save_Image : MonoBehaviour
{
    public JetFlyCsv jet;
    public Camera JetCamera;


    //By pressing the button we will save an image from the plane's view of the ball by frame
    public void OnClick()
    {
        int resWidth = 500;
        int resHeight = 500;
        RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
        JetCamera.targetTexture = rt;
        Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        JetCamera.Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0,0, resWidth, resHeight),0,0);
        screenShot.Apply();
        JetCamera.targetTexture = null;
        RenderTexture.active = null;
        Destroy(rt);
        byte[] bytes = screenShot.EncodeToPNG();
        string filename = string.Format("Frame__{0}.png", jet.getFrameId().ToString());
        System.IO.File.WriteAllBytes(filename, bytes);
        Debug.Log(string.Format("Took screenshot to: {0}", filename));

    }
}
