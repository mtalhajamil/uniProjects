package com.tj.checkers;

import com.example.checkers.R;


import android.content.Intent;
import android.media.MediaPlayer;
import android.os.Bundle;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;
import android.widget.ImageButton;



public class boardactivity extends checking {

	public int boardcheck;
	

	float pressx;
	float pressy;
	ImageButton board1;
	ImageButton board2;
	ImageButton board3;
	ImageButton board4;


	MediaPlayer sound;


	

//	final float boardleft = 56;
//	final float boardwidth = 168;
//	final float boardtop = 126;
//	final float boardheight = 374;
//	final float boardxdiff = 52;
//	final float boardydiff = 30;
	
	
	
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		super.onCreate(savedInstanceState);
		requestWindowFeature(Window.FEATURE_NO_TITLE);
		getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN, WindowManager.LayoutParams.FLAG_FULLSCREEN);
		setContentView(R.layout.boardlayout);
		
		
		sound = MediaPlayer.create(this,R.raw.gunshot);
		board1 = (ImageButton)findViewById(R.id.board1);
		board2 = (ImageButton)findViewById(R.id.board2);
		board3 = (ImageButton)findViewById(R.id.board3);
		board4 = (ImageButton)findViewById(R.id.board4);
		
		sound.start();
		
		board1.setOnClickListener(new View.OnClickListener() {
			
			@Override
			public void onClick(View v) {
				checking.setBoardcheck(1);
				
				sound.start();
				Intent next = new Intent(boardactivity.this,Instructions.class);
				
				
				startActivity(next);
				finish();
				
			}
		});
		board2.setOnClickListener(new View.OnClickListener() {
			
			@Override
			public void onClick(View v) {
				checking.setBoardcheck(2);
				
				sound.start();
				Intent next = new Intent(boardactivity.this,Instructions.class);
				
				
				startActivity(next);
				finish();
				
			}
		});
		board3.setOnClickListener(new View.OnClickListener() {
			
			@Override
			public void onClick(View v) {
				checking.setBoardcheck(3);
				
				sound.start();
				Intent next = new Intent(boardactivity.this,Instructions.class);
				
				startActivity(next);
				finish();
				
			}
		});
		board4.setOnClickListener(new View.OnClickListener() {
			
			@Override
			public void onClick(View v) {
				checking.setBoardcheck(4);
				
				sound.start();
				Intent next = new Intent(boardactivity.this,Instructions.class);
				
				startActivity(next);
				finish();
				
			}
		});
		
	}





//	@Override
//	public boolean onTouch(View arg0, MotionEvent arg1) {
//		
//
//		
//		if(arg1.getAction() == MotionEvent.ACTION_DOWN){
//			
//
//			pressx = arg1.getX();
//			pressy = arg1.getY();
//		
//		if ((pressx>=boardleft && pressx<= boardleft + boardwidth) && (pressy>=boardtop && pressy<=boardtop + boardwidth)){
//			boardcheck = 1;
//		}
//		if ((pressx>=boardleft + boardwidth + boardxdiff && pressx<= boardleft + boardwidth + boardwidth + boardxdiff) 
//				&& (pressy>=boardtop && pressy<=boardtop + boardwidth)){
//			boardcheck = 2;
//		}
//		if ((pressx>=boardleft && pressx<= boardleft + boardwidth)
//				&& (pressy>=boardtop + boardwidth + boardydiff && pressy<=boardtop + boardwidth + boardwidth + boardydiff )){
//			boardcheck = 3;
//		}
//		if ((pressx>=boardleft + boardwidth + boardxdiff && pressx<= boardleft + boardwidth + boardwidth + boardxdiff) 
//				&& (pressy>=boardtop + boardwidth + boardydiff && pressy<=boardtop + boardwidth + boardwidth + boardydiff )){
//			boardcheck = 4;
//		}
//		
//		if (boardcheck>=1 && boardcheck<=4){
//			Intent next = new Intent(boardactivity.this,Board.class);
//			
//			startActivity(next);
//			finish();
//		}
//	}
//		
//		
//		return super.onTouchEvent(arg1);
//	}
	
	
	
	
	
}
