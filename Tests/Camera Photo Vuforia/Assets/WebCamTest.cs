using UnityEngine;
using System.Collections;

public class WebCamTest : MonoBehaviour {
	public WebCamTexture mWebCamTexture;
	public bool windowSize = true;
	public bool paused = false;
	private string snapShotPath;
	private Vector3 tempScale = Vector3.zero;
	
	// Use this for initialization
	void Start () {		
		snapShotPath = Application.persistentDataPath;
		
	    mWebCamTexture = new WebCamTexture();
        mWebCamTexture.deviceName = WebCamTexture.devices[0].name;
        //mWebCamTexture.requestedFPS = 30;
		
		if(windowSize){
			tempScale = transform.localScale;
			tempScale.x = Screen.width;
			tempScale.y = Screen.height;
			transform.localScale = tempScale;
			
			mWebCamTexture.requestedWidth = Screen.width;
			mWebCamTexture.requestedHeight = Screen.height;
		}		
		
		renderer.material.mainTexture = mWebCamTexture;
		mWebCamTexture.Play();			
	}
	
	// Update is called once per frame
	void Update () {
		// We could put a button to pause the stream (simulating taking a picture), and work on the resulting image
		if(Input.GetMouseButtonDown(0)) {
			if (!paused) {
				mWebCamTexture.Pause();
				paused = true;
			}
			else {
				mWebCamTexture.Play();	
				paused = false;
			}
		}
		
		/*if(Input.GetKeyDown(KeyCode.Space))
			SaveSnapshot();*/
	}
	
	void SaveSnapshot()
	{
		string finalPath = snapShotPath + "/snapShot.png";
		Debug.Log(finalPath);
		
	    Texture2D snap = new Texture2D(mWebCamTexture.width, mWebCamTexture.height);
	    snap.SetPixels(mWebCamTexture.GetPixels());
	    snap.Apply();
	 
	    System.IO.File.WriteAllBytes(finalPath, snap.EncodeToPNG());
	}
}
