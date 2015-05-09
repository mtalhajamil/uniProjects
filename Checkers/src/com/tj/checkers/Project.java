package com.tj.checkers;

import com.example.checkers.R;

import android.app.Activity;
import android.content.Intent;
import android.media.MediaPlayer;
import android.os.Bundle;
import android.view.Window;
import android.view.WindowManager;

public class Project extends Activity {

	MediaPlayer sound;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		super.onCreate(savedInstanceState);
		
		requestWindowFeature(Window.FEATURE_NO_TITLE);
		getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN, WindowManager.LayoutParams.FLAG_FULLSCREEN);
		setContentView(R.layout.project);
		
		sound=MediaPlayer.create(this,R.raw.sweep);
		sound.start();
		

		
		Thread timer = new Thread(){
			
			public void run(){
				
				try {
					Thread.sleep(3000);
				} catch (InterruptedException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}finally{
					Intent next = new Intent(Project.this,FrontPage.class);
					
					startActivity(next);
					finish();
				}
			}
		
		};
		timer.start();
	}
	
}
