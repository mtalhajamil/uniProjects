package tj.technobrick.iQuranMediaPlayer;

import org.apache.cordova.DroidGap;
import android.os.Bundle;
import android.content.res.Configuration;
import android.webkit.WebSettings;

public class MainActivity extends DroidGap {

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		super.setIntegerProperty("loadUrlTimeoutValue", 6000000);
		super.loadUrl("file:///android_asset/www/iQuranMediaPlayer.html");
		
		
		WebSettings settings = super.appView.getSettings();
	    settings.setBuiltInZoomControls(true);
	    settings.setSupportZoom(true);
	    
	}
	
	@Override
	public void onConfigurationChanged(Configuration newConfig) { 
		super.onConfigurationChanged(newConfig); }
	
	

}




