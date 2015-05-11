using UnityEngine;
using System.Collections;

public class Simple : LWFObject {
	
	void Start()
	{
		setLoader();
		// #1 Show popup lwf/textures
		Load("lwf_logo_animation.lwfdata/lwf_logo_animation", "lwf_logo_animation.lwfdata/");
	}
	
	
	void setLoader()
	{
		LWFObject.SetLoader(
			lwfDataLoader:(name) => {
			TextAsset asset = Resources.Load(name) as TextAsset;
			if (asset == null) {
				return null;
			}
			return asset.bytes;
		},
		textureLoader:(name) => {
			Texture2D texture = Resources.Load(name) as Texture2D;
			if (texture == null) {
				return null;
			}
			return texture;
		}
		);
	}
}