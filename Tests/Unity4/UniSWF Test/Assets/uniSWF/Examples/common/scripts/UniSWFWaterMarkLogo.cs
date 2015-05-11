using System;
using System.IO;
using UnityEngine;
using pumpkin.swf;
using pumpkin.geom;
using pumpkin.events;
using pumpkin.display;
using pumpkin.displayInternal;
#if UNISWF_FREE
using System.Text;
#endif

public class UniSWFWaterMarkLogo : MonoBehaviour {
	public Texture m_SplashLogo;
	public float padding = 10;
	protected float m_LastLogoClick;
	
	void OnGUI() {

		Rect logoRect = new Rect( (Screen.width)-(m_SplashLogo.width)-padding, (Screen.height)-(m_SplashLogo.height)-padding, m_SplashLogo.width, m_SplashLogo.height);
		
		// Draw
    	if(Event.current.type.Equals(EventType.Repaint)) {

			// Draw logo		
			UnityEngine.Graphics.DrawTexture ( logoRect, m_SplashLogo, new Rect( 0, 0, 1, 1 ), 0, 0, 0, 0, new Color( 0.5f,0.5f,0.5f,0.25f) );	
		}
		
		/*// Splash click
		if( Input.GetMouseButtonDown(0)  ) {
			if( Time.time-m_LastLogoClick > 2.6f || m_LastLogoClick == 0 ) {
				m_LastLogoClick = Time.time;
				if( !Application.isEditor ) {
					Application.OpenURL ("http://uniswf.com");		
				}
			}
		}*/
	
	}	
}
