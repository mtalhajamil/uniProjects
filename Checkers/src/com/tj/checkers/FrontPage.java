package com.tj.checkers;

import com.example.checkers.R;

import android.app.Activity;
import android.content.Intent;
import android.media.MediaPlayer;
import android.os.Bundle;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;
import android.widget.Button;

public class FrontPage extends Activity {

	Button b,bex;
	MediaPlayer sound;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
	// TODO Auto-generated method stub
		super.onCreate(savedInstanceState);
		requestWindowFeature(Window.FEATURE_NO_TITLE);
		getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN, WindowManager.LayoutParams.FLAG_FULLSCREEN);
			setContentView(R.layout.activity_starting);


	sound=MediaPlayer.create(this,R.raw.thunder);
		

		sound.start();
			b=(Button) findViewById(R.id.play);
				bex=(Button) findViewById(R.id.close);
					bex.setOnClickListener(new View.OnClickListener() {

						
	
	@Override
	public void onClick(View v) {
	// TODO Auto-generated method stub
			finish();
			System.exit(0);
		}
	});
				b.setOnClickListener(new View.OnClickListener() {

	@Override
	public void onClick(View v) {
	Intent i =new Intent(FrontPage.this,boardactivity.class);
	startActivity(i);


	}
	});
	}

	@Override
	public void onBackPressed() {
		// TODO Auto-generated method stub
		super.onBackPressed();
	}

	@Override
	protected void onResume() {
		// TODO Auto-generated method stub
		super.onResume();
		sound.start();
		if(!sound.isPlaying()){
			sound.start();
		}
	}




	}
