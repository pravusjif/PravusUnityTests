using UnityEngine;
using System.Collections;
using pumpkin.display;
using pumpkin.text;
using pumpkin.events;
using pumpkin.logging;
using pumpkin.tweener;

public class DemoOverlayCamera : MovieClipOverlayCameraBehaviour {
	
	public bool displayAtTop = true;
	public float fadeAfter = 0;
	public string title = "";
	protected TextField debug_txt;
	
	void Start () {
		
		MovieClip overlay = new MovieClip( "uniSWF/Examples/common/swf/common_uniswf_overlay.swf:DemoOverlay" );
		stage.addChild( overlay );
		
		TextField txt = overlay.getChildByName<TextField>("txt");
		if( txt != null ) {
			txt.text = title;
		}
		
		MovieClip logo = overlay.getChildByName<MovieClip>("logo");
		logo.addEventListener( MouseEvent.CLICK, onLogoClick );
		
		Logger.instance.addEventListener( LogEvent.LOGEVENT, onLog );
		
		debug_txt = overlay.getChildByName<TextField>("debug_txt");
		
		if( !displayAtTop ) {
			overlay.y = Screen.height - overlay.height;
		}
		
		if( fadeAfter > 0 ) {
			Tweener.addTween( overlay, Tweener.Hash( "delay",fadeAfter, "time",3, "alpha",0 ) );
		}
	}
	
	void onLogoClick( CEvent e ) {
	
		if( Application.absoluteURL.IndexOf( "uniswf.com" ) == -1 ) {
			Application.OpenURL("http://uniswf.com");			
		}
		
	}
	
	void onLog( CEvent e ) {
		
		LogEvent logEvent = e as LogEvent;
		
		debug_txt.alpha = 1;
		debug_txt.text = logEvent.logStr;	
			
		Tweener.addTween( debug_txt, Tweener.Hash( "time", 1, "alpha", 0, "delay", 3 ) );		
	}
	
}
