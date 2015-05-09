package com.tj.checkers;



import com.example.checkers.R;

import android.content.Context;
import android.content.pm.ActivityInfo;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Canvas;
import android.media.MediaPlayer;
import android.os.Bundle;
import android.view.MotionEvent;
import android.view.SurfaceHolder;
import android.view.SurfaceView;
import android.view.View;
import android.view.WindowManager;
import android.view.View.OnTouchListener;
import android.view.Window;


public class Board extends checking implements OnTouchListener {

	
	
	public static final float startingx = 70;
	public static final float startingy = 24;
	public static final float differencex = 58;
	public static final float differencey = 90;
	public static final float upperlimit = startingy;
	public static final float lowerlimit = startingy + differencey + differencey + differencey + differencey + differencey + differencey + differencey;
	public static final float rightlimit = startingx + differencex + differencex + differencex + differencex + differencex + differencex;
	public static final float leftlimit = startingx - differencex;
	public static final float tabahi = 3000;
	public static final int sleeptime = 9000;
	public static final int downdisplay = 765;
	
	
	int i = 0;
	int changingY = 700;
	
	MyBoard BackView;
		float[] blackx= {startingx,startingx + differencex+ differencex,startingx + differencex + differencex + differencex + differencex,startingx + differencex + differencex + differencex + differencex + differencex + differencex,
						startingx - differencex,startingx + differencex,startingx + differencex + differencex + differencex,startingx + differencex+ differencex+ differencex+ differencex+ differencex,
							startingx,startingx + differencex+ differencex,startingx + differencex + differencex + differencex + differencex,startingx + differencex + differencex + differencex + differencex + differencex + differencex,
								tabahi,tabahi,tabahi,tabahi,
									tabahi,tabahi,tabahi,tabahi,
										tabahi,tabahi,tabahi,tabahi,
										tabahi},
			blacky = {startingy,startingy,startingy,startingy,
						startingy + differencey ,startingy + differencey,startingy + differencey,startingy + differencey,
							startingy + differencey + differencey,startingy + differencey + differencey,startingy + differencey + differencey,startingy + differencey + differencey,
								tabahi,tabahi,tabahi,tabahi,
									tabahi,tabahi,tabahi,tabahi,
										tabahi,tabahi,tabahi,tabahi,
										tabahi},
			whitex= {startingx - differencex,startingx + differencex,startingx + differencex + differencex + differencex,startingx + differencex+ differencex+ differencex+ differencex+ differencex,
						startingx,startingx + differencex+ differencex,startingx + differencex + differencex + differencex + differencex,startingx + differencex + differencex + differencex + differencex + differencex + differencex,
							startingx - differencex,startingx + differencex,startingx + differencex + differencex + differencex,startingx + differencex+ differencex+ differencex+ differencex+ differencex,
								tabahi,tabahi,tabahi,tabahi,
									tabahi,tabahi,tabahi,tabahi,
										tabahi,tabahi,tabahi,tabahi,
										tabahi},
			whitey = {startingy + differencey + differencey + differencey + differencey + differencey,startingy + differencey + differencey + differencey + differencey + differencey,startingy + differencey + differencey + differencey + differencey + differencey,startingy + differencey + differencey + differencey + differencey + differencey,
						startingy + differencey + differencey + differencey + differencey + differencey + differencey,startingy + differencey + differencey + differencey + differencey + differencey + differencey,startingy + differencey + differencey + differencey + differencey + differencey + differencey,startingy + differencey + differencey + differencey + differencey + differencey + differencey,
							startingy + differencey + differencey + differencey + differencey + differencey + differencey + differencey,startingy + differencey + differencey + differencey + differencey + differencey + differencey + differencey,startingy + differencey + differencey + differencey + differencey + differencey + differencey + differencey,startingy + differencey + differencey + differencey + differencey + differencey + differencey + differencey,
								tabahi,tabahi,tabahi,tabahi,
									tabahi,tabahi,tabahi,tabahi,
										tabahi,tabahi,tabahi,tabahi,
										tabahi};

	float wb1,wb2;
	float pressx,pressy;
	float leavex,leavey;
	float checkx,checky;
	boolean istouched=false;
	
	MediaPlayer move;
	MediaPlayer beat;
	MediaPlayer king;
	MediaPlayer sound;
	MediaPlayer noway;
	MediaPlayer cheers;
	MediaPlayer cross;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {

		super.onCreate(savedInstanceState);
		requestWindowFeature(Window.FEATURE_NO_TITLE);
		getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN, WindowManager.LayoutParams.FLAG_FULLSCREEN);
		BackView = new MyBoard(this);

		BackView.setOnTouchListener(this);
		move = MediaPlayer.create(this, R.raw.move);
		beat = MediaPlayer.create(this, R.raw.move2);
		king = MediaPlayer.create(this, R.raw.king);
		sound=MediaPlayer.create(this,R.raw.thunder);
		noway=MediaPlayer.create(this,R.raw.error);
		cheers=MediaPlayer.create(this,R.raw.winsound);
		cross=MediaPlayer.create(this,R.raw.crosssound);

		setContentView(BackView);
	}


	


	@Override
	protected void onPause() {
		// TODO Auto-generated method stub
		super.onPause();
		BackView.pause();
	}


	@Override
	protected void onResume() {
		// TODO Auto-generated method stub
		super.onResume();
		BackView.resume();
	}
	
	@Override
	public boolean onTouch(View v, MotionEvent event) {
		// TODO Auto-generated method stub
		switch(event.getAction()){
		case MotionEvent.ACTION_DOWN:
			pressx = event.getX();
			pressy = event.getY();
	istouched=true;
			
			int checkblack = 0;
			int checkwhite = 0;
			
			
			for (int l = 0; l < 24; l++){
				

				
				
				if (i == 0){
					if(!((pressx>=blackx[l] && pressx<=(blackx[l]+differencex)) && (pressy>=blacky[l] && pressy<=(blacky[l]+differencey)))){
						checkblack++;
					}
					else{
						
					}
				}
				
				if (i == 1){
					if (!((pressx>=whitex[l] && pressx<=(whitex[l]+differencex)) && (pressy>=whitey[l] && pressy<=(whitey[l]+differencey)))){
						checkwhite++;	
					}
					else{
						
					}
				}
			
				
			}
			
			if (checkblack == 24 && i==0){
				noway.start();
			}
			
			
			if (checkwhite == 24 && i==1){
				noway.start();
			}
			
			
		break;
		
		case MotionEvent.ACTION_UP:
			leavex = event.getX();
			leavey = event.getY();
			
			break;
		}
		
		return true;
	}
	
	
	
	
	
	
	
	
	
	
	
	
	public class MyBoard extends SurfaceView implements Runnable {

		SurfaceHolder Holder;
		Thread thread = null;
		boolean Running = false;
		int dentx,denty;
		float ax,ay,bx,by,middlex,middley;
		int changex = 0,changey = 0;
		boolean checkspace = true;
		boolean checkmiddle = false;
		boolean beat2 = false;
		boolean beat3 = false;
		boolean doublespace1 = true;
		boolean doublespace2 = false;
		boolean blackwin = true;
		boolean whitewin = true;
		int or=0;
		int fn=0;
		
float beatx=5000,beaty=5000;
	


		Bitmap beatbox=BitmapFactory.decodeResource(getResources(), R.drawable.beat);
		Bitmap rbb0 = BitmapFactory.decodeResource(getResources(), R.drawable.black);
		Bitmap rbb1 = BitmapFactory.decodeResource(getResources(), R.drawable.black);
		Bitmap rbb2 = BitmapFactory.decodeResource(getResources(), R.drawable.black);
		Bitmap rbb3 = BitmapFactory.decodeResource(getResources(), R.drawable.black);
		Bitmap rbb4 = BitmapFactory.decodeResource(getResources(), R.drawable.black);
		Bitmap rbb5 = BitmapFactory.decodeResource(getResources(), R.drawable.black);
		Bitmap rbb6 = BitmapFactory.decodeResource(getResources(), R.drawable.black);
		Bitmap rbb7 = BitmapFactory.decodeResource(getResources(), R.drawable.black);
		Bitmap rbb8 = BitmapFactory.decodeResource(getResources(), R.drawable.black);
		Bitmap rbb9 = BitmapFactory.decodeResource(getResources(), R.drawable.black);
		Bitmap rbb10 = BitmapFactory.decodeResource(getResources(), R.drawable.black);
		Bitmap rbb11 = BitmapFactory.decodeResource(getResources(), R.drawable.black);
		
		Bitmap rwb0 = BitmapFactory.decodeResource(getResources(), R.drawable.white);
		Bitmap rwb1 = BitmapFactory.decodeResource(getResources(), R.drawable.white);
		Bitmap rwb2 = BitmapFactory.decodeResource(getResources(), R.drawable.white);
		Bitmap rwb3 = BitmapFactory.decodeResource(getResources(), R.drawable.white);
		Bitmap rwb4 = BitmapFactory.decodeResource(getResources(), R.drawable.white);
		Bitmap rwb5 = BitmapFactory.decodeResource(getResources(), R.drawable.white);
		Bitmap rwb6 = BitmapFactory.decodeResource(getResources(), R.drawable.white);
		Bitmap rwb7 = BitmapFactory.decodeResource(getResources(), R.drawable.white);
		Bitmap rwb8 = BitmapFactory.decodeResource(getResources(), R.drawable.white);
		Bitmap rwb9 = BitmapFactory.decodeResource(getResources(), R.drawable.white);
		Bitmap rwb10 = BitmapFactory.decodeResource(getResources(), R.drawable.white);
		Bitmap rwb11 = BitmapFactory.decodeResource(getResources(), R.drawable.white);

		Bitmap kbb0 = BitmapFactory.decodeResource(getResources(), R.drawable.blackking);
		Bitmap kbb1 = BitmapFactory.decodeResource(getResources(), R.drawable.blackking);
		Bitmap kbb2 = BitmapFactory.decodeResource(getResources(), R.drawable.blackking);
		Bitmap kbb3 = BitmapFactory.decodeResource(getResources(), R.drawable.blackking);
		Bitmap kbb4 = BitmapFactory.decodeResource(getResources(), R.drawable.blackking);
		Bitmap kbb5 = BitmapFactory.decodeResource(getResources(), R.drawable.blackking);
		Bitmap kbb6 = BitmapFactory.decodeResource(getResources(), R.drawable.blackking);
		Bitmap kbb7 = BitmapFactory.decodeResource(getResources(), R.drawable.blackking);
		Bitmap kbb8 = BitmapFactory.decodeResource(getResources(), R.drawable.blackking);
		Bitmap kbb9 = BitmapFactory.decodeResource(getResources(), R.drawable.blackking);
		Bitmap kbb10 = BitmapFactory.decodeResource(getResources(), R.drawable.blackking);
		Bitmap kbb11 = BitmapFactory.decodeResource(getResources(), R.drawable.blackking);
		
		Bitmap kwb0 = BitmapFactory.decodeResource(getResources(), R.drawable.whiteking);
		Bitmap kwb1 = BitmapFactory.decodeResource(getResources(), R.drawable.whiteking);
		Bitmap kwb2 = BitmapFactory.decodeResource(getResources(), R.drawable.whiteking);
		Bitmap kwb3 = BitmapFactory.decodeResource(getResources(), R.drawable.whiteking);
		Bitmap kwb4 = BitmapFactory.decodeResource(getResources(), R.drawable.whiteking);
		Bitmap kwb5 = BitmapFactory.decodeResource(getResources(), R.drawable.whiteking);
		Bitmap kwb6 = BitmapFactory.decodeResource(getResources(), R.drawable.whiteking);
		Bitmap kwb7 = BitmapFactory.decodeResource(getResources(), R.drawable.whiteking);
		Bitmap kwb8 = BitmapFactory.decodeResource(getResources(), R.drawable.whiteking);
		Bitmap kwb9 = BitmapFactory.decodeResource(getResources(), R.drawable.whiteking);
		Bitmap kwb10 = BitmapFactory.decodeResource(getResources(), R.drawable.whiteking);
		Bitmap kwb11 = BitmapFactory.decodeResource(getResources(), R.drawable.whiteking);
		

		Bitmap bwin = BitmapFactory.decodeResource(getResources(), R.drawable.blackwin);
		Bitmap wwin = BitmapFactory.decodeResource(getResources(), R.drawable.whitewin);
		Bitmap bturn = BitmapFactory.decodeResource(getResources(), R.drawable.blackturn);
		Bitmap wturn = BitmapFactory.decodeResource(getResources(), R.drawable.whiteturn);
		Bitmap redcover = BitmapFactory.decodeResource(getResources(), R.drawable.redchange);
		Bitmap whitebg=BitmapFactory.decodeResource(getResources(), R.drawable.whitebg);
		Bitmap beatb=BitmapFactory.decodeResource(getResources(), R.drawable.beat1);
		Bitmap blackdisplay =BitmapFactory.decodeResource(getResources(), R.drawable.wblack);
		Bitmap whitedisplay =BitmapFactory.decodeResource(getResources(), R.drawable.wwhite);
			
		

		
  
  
		
		public MyBoard(Context context) {
			super(context);
			
			Holder = getHolder();
			
		}

		

		

		
		@Override
		public void run() {
			
			// TODO Auto-generated method stub
			while (Running){
				if (!Holder.getSurface().isValid())
					continue;
				
				
				
				Canvas canvas = Holder.lockCanvas();
				setRequestedOrientation(ActivityInfo.SCREEN_ORIENTATION_PORTRAIT);
				if (checking.getBoardcheck() == 1){
				Bitmap board1 = BitmapFactory.decodeResource(getResources(), R.drawable.image);
				canvas.drawBitmap(board1, 0, 0, null);
				}
				
				if (checking.getBoardcheck() == 2){
				Bitmap board2 = BitmapFactory.decodeResource(getResources(), R.drawable.image2);
				canvas.drawBitmap(board2, 0, 0, null);
				}
				
				if (checking.getBoardcheck() == 3){
				Bitmap board3 = BitmapFactory.decodeResource(getResources(), R.drawable.image3);
				canvas.drawBitmap(board3, 0, 0, null);
				}
				
				if (checking.getBoardcheck() == 4){
				Bitmap board4 = BitmapFactory.decodeResource(getResources(), R.drawable.image4);
				canvas.drawBitmap(board4, 0, 0, null);
				}
				


				
				
				
				
				canvas.drawBitmap(rbb0, blackx[0], blacky[0],null);
				canvas.drawBitmap(rbb1, blackx[1], blacky[1],null);
				canvas.drawBitmap(rbb2, blackx[2], blacky[2],null);
				canvas.drawBitmap(rbb3, blackx[3], blacky[3],null);
				canvas.drawBitmap(rbb4, blackx[4], blacky[4],null);
				canvas.drawBitmap(rbb5, blackx[5], blacky[5],null);
				canvas.drawBitmap(rbb6, blackx[6], blacky[6],null);
				canvas.drawBitmap(rbb7, blackx[7], blacky[7],null);
				canvas.drawBitmap(rbb8, blackx[8], blacky[8],null);
				canvas.drawBitmap(rbb9, blackx[9], blacky[9],null);
				canvas.drawBitmap(rbb10, blackx[10], blacky[10],null);
				canvas.drawBitmap(rbb11, blackx[11], blacky[11],null);
				
				canvas.drawBitmap(rwb0, whitex[0], whitey[0],null);
				canvas.drawBitmap(rwb1, whitex[1], whitey[1],null);
				canvas.drawBitmap(rwb2, whitex[2], whitey[2],null);
				canvas.drawBitmap(rwb3, whitex[3], whitey[3],null);
				canvas.drawBitmap(rwb4, whitex[4], whitey[4],null);
				canvas.drawBitmap(rwb5, whitex[5], whitey[5],null);
				canvas.drawBitmap(rwb6, whitex[6], whitey[6],null);
				canvas.drawBitmap(rwb7, whitex[7], whitey[7],null);
				canvas.drawBitmap(rwb8, whitex[8], whitey[8],null);
				canvas.drawBitmap(rwb9, whitex[9], whitey[9],null);
				canvas.drawBitmap(rwb10, whitex[10], whitey[10],null);
				canvas.drawBitmap(rwb11, whitex[11], whitey[11],null);

				canvas.drawBitmap(kbb0, blackx[12], blacky[12],null);
				canvas.drawBitmap(kbb1, blackx[13], blacky[13],null);
				canvas.drawBitmap(kbb2, blackx[14], blacky[14],null);
				canvas.drawBitmap(kbb3, blackx[15], blacky[15],null);
				canvas.drawBitmap(kbb4, blackx[16], blacky[16],null);
				canvas.drawBitmap(kbb5, blackx[17], blacky[17],null);
				canvas.drawBitmap(kbb6, blackx[18], blacky[18],null);
				canvas.drawBitmap(kbb7, blackx[19], blacky[19],null);
				canvas.drawBitmap(kbb8, blackx[10], blacky[20],null);
				canvas.drawBitmap(kbb9, blackx[21], blacky[21],null);
				canvas.drawBitmap(kbb10, blackx[22], blacky[22],null);
				canvas.drawBitmap(kbb11, blackx[23], blacky[23],null);
				
				canvas.drawBitmap(kwb0, whitex[12], whitey[12],null);
				canvas.drawBitmap(kwb1, whitex[13], whitey[13],null);
				canvas.drawBitmap(kwb2, whitex[14], whitey[14],null);
				canvas.drawBitmap(kwb3, whitex[15], whitey[15],null);
				canvas.drawBitmap(kwb4, whitex[16], whitey[16],null);
				canvas.drawBitmap(kwb5, whitex[17], whitey[17],null);
				canvas.drawBitmap(kwb6, whitex[18], whitey[18],null);
				canvas.drawBitmap(kwb7, whitex[19], whitey[19],null);
				canvas.drawBitmap(kwb8, whitex[20], whitey[20],null);
				canvas.drawBitmap(kwb9, whitex[21], whitey[21],null);
				canvas.drawBitmap(kwb10, whitex[22], whitey[22],null);
				canvas.drawBitmap(kwb11, whitex[23], whitey[23],null);
				
				
				canvas.drawBitmap(whitebg, 0, downdisplay , null);
				
				
				changex = changey = 24;
				
				if(fn==1){
					or=1;
					fn=0;
				}
				beatx=5000;
				beaty=5000;
			

//				for (int l = 0; l < 24; l++){
//				if (i == 0){
//					if((pressx>=blackx[l] && pressx<=(blackx[l]+differencex)) && (pressy>=blacky[l] && pressy<=(blacky[l]+differencey))){
//						canvas.drawBitmap(redcover, blackx[l], blacky[l], null);
//					}
//					
//				}
//				
//				if (i == 1){
//					if ((pressx>=whitex[l] && pressx<=(whitex[l]+differencex)) && (pressy>=whitey[l] && pressy<=(whitey[l]+differencey))){
//						canvas.drawBitmap(redcover, whitex[l], whitey[l], null);
//					}
//				}
//				}
				
				
				

				
				

				for (int j = 0; j < 24; j++){
					
					if ((leavex>=blackx[j] && leavex<=(blackx[j]+differencex)) && (leavey>=blacky[j] && leavey<=(blacky[j]+differencey))){
							checkspace = false;
					}
					
					if ((leavex>=whitex[j] && leavex<=(whitex[j]+differencex)) && (leavey>=whitey[j] && leavey<=(whitey[j]+differencey))){
						checkspace = false;
					}
					
					if ((leavex > (rightlimit + differencex)) || (leavex < (leftlimit)) || (leavey < (upperlimit)) || (leavey > (lowerlimit + differencex)) )
							checkspace = false;
				}
				
			
				
		if (i==0){
			canvas.drawBitmap(bturn, leftlimit - 12, upperlimit  - 25 ,null);
			canvas.drawBitmap(blackdisplay, 0, downdisplay , null);
		}
		
		if (i==1){
			canvas.drawBitmap(wturn, leftlimit - 12, lowerlimit + differencey - 10 ,null);
			canvas.drawBitmap(whitedisplay, 0, downdisplay , null);
		}
		
		
//************************************************Checking Mouse Click For Black*************************************************************//
		try {
				for (int j = 0; j < 24; j++){
					
					if ((pressx>=blackx[j] && pressx<=(blackx[j]+differencex)) && (pressy>=blacky[j] && pressy<=(blacky[j]+differencey))){
							changex = changey = j;
					}

				}
			} catch (Exception e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		
//************************************************Checking Ends*************************************************************//
		
//************************************************Checking Mouse Click For White*************************************************************//	
						try {
							for (int j = 0; j < 24; j++){
								
								if ((pressx>=whitex[j] && pressx<=(whitex[j]+differencex)) && (pressy>=whitey[j] && pressy<=(whitey[j]+differencey))){
										changex =  changey = j;
								}
								
								
								
							}
						} catch (Exception e) {
							// TODO Auto-generated catch block
							e.printStackTrace();
						}
						
						
		//************************************************Checking Ends*************************************************************//
		
				
//************************************************Turn Of Black*************************************************************//					
						canvas.drawBitmap(beatb,beatx, beaty, null);			
				
if (i==0 && checkspace){

	
//************************************************Black Beat*************************************************************//		
	
	

			
		
	
	
	
	for (int j = 0; j < 24; j++){
		

		if ((pressx>=blackx[j] && pressx<=(blackx[j]+differencex)) && (pressy>=blacky[j] && pressy<=(blacky[j]+differencey))){
			if((pressx < leavex) && (pressy < leavey)){
				middlex = blackx[j] + differencex;
				middley = blacky[j] + differencey;
			}
			else if((pressx > leavex) && (pressy < leavey)){
				
				middlex = blackx[j] - differencex;
				middley = blacky[j] + differencey;
				
			}
		}	
	}	

		for (int j = 0; j < 24; j++){
			
			if(		(middlex == whitex[j])	&&	(middley == whitey[j])	){
				dentx = denty = j;
	
				checkmiddle = true;
			}
		}
	
//************************************************Black Beat Ends*************************************************************//		
				

				
		
				if (changex>=0 && changex<=11){
					
					if ((checkx != leavex)&& (leavey != checky)){
								
						if (leavex>=(blackx[changex]+differencex) && (leavex<=(blackx[changex]+differencex+differencex)) 
										&& leavey>=(blacky[changey]+differencey) && (leavey<=(blacky[changey]+differencey+differencey))){
								
									
									leavex = blackx[changex]+differencex;
									leavey = blacky[changey]+differencey;
									

									
									blackx[changex] = leavex;
									blacky[changey] = leavey;
									
									
									move.start();
								
									
									i = 1;
									
									
									
									
//									canvas.drawBitmap(beatbox , leftlimit, (upperlimit+lowerlimit+differencey)/2 - beatbox.getHeight(), null);
//
//									
//									try {
//										thread.sleep(2000);
//									} catch (InterruptedException e) {
//										// TODO Auto-generated catch block
//										e.printStackTrace();
//									}
//				
									
									
								}
								
								else if((leavex<=(blackx[changex]) && (leavex>=(blackx[changex]-differencex)) &&
										(leavey>=(blacky[changey]+differencey) && (leavey<=(blacky[changey]+differencey +differencey))))){
									
									leavex = blackx[changex]-differencex;
									leavey = blacky[changey]+differencey;
									
									
									blackx[changex] = leavex;
									blacky[changey] = leavey;
						
									
									move.start();
									
									i = 1;
									
								}
						
						
								else if(leavex>=(blackx[changex]+differencex+differencex) 
										&& (leavex<=(blackx[changex]+differencex+differencex+differencex)) 
										&& leavey>=(blacky[changey]+differencey+differencey)
										&& (leavey<=(blacky[changey]+differencey+differencey+differencey))
										&& checkmiddle){
									
									
									leavex = blackx[changex] + differencex + differencex;
									leavey = blacky[changey] + differencey + differencey;
									
									
									blackx[changex] = leavex;
									blacky[changey] = leavey;
									
									
									whitex[dentx] = tabahi;
									whitey[denty] = tabahi;
									
									
									beat2 = true;
									
									beat.start();
									
									cross.start();
									
									//*********************************BEAT BOX********************
								beatx=leftlimit;
								beaty=(upperlimit+lowerlimit+differencey)/2 - bwin.getHeight();
								fn=1;	
									
									
									i = 1;
								}
						
								else if(leavex<=(blackx[changex]-differencex) 
										&& (leavex>=(blackx[changex]-differencex-differencex)) 
										&& leavey>=(blacky[changey]+differencey+differencey)
										&& (leavey<=(blacky[changey]+differencey+differencey+differencey))
										&& checkmiddle){
									
									
									leavex = blackx[changex] - differencex - differencex;
									leavey = blacky[changey] + differencey + differencey;
									
									
									blackx[changex] = leavex;
									blacky[changey] = leavey;
									
									
									whitex[dentx] = tabahi;
									whitey[denty] = tabahi;
									
									beat2 = true;
									
									beat.start();
									
									cross.start();
									//************************BEATBOX**************

									beatx=leftlimit;
									beaty=(upperlimit+lowerlimit+differencey)/2 - bwin.getHeight();								
	fn=1;
									i = 1;
								}
						
						checkmiddle = false;
						
						if(beat2){
							
							

							for (int j = 0; j < 24; j++){
								
								if(		((blackx[changex] + differencex ) == whitex[j])	&&	((blacky[changey] + differencey) == whitey[j])	){	
									checkmiddle = true;
									
									dentx = denty = j;
								}
								
							}
							
							
							for (int j = 0; j < 24; j++){
								

								
								if ( ((blackx[changex] + differencex + differencex)==blackx[j]) &&
										((blacky[changey] + differencey + differencey)==blacky[j])){
									doublespace1 = false;
								}
								
								if ( ((blackx[changex] + differencex + differencex)==whitex[j]) && 
										((blacky[changey] + differencey + differencey)==whitey[j]) ){
									doublespace1 = false;
								}
								if((blackx[changex] + differencex + differencex) > rightlimit )
								{
									doublespace1 = false;
								}
								
							if((blacky[changey] + differencey + differencey) > lowerlimit )
								{
									doublespace1 = false;
								}
								
							}
							
							if(doublespace1 && checkmiddle){
								i = 0;
								beat2 = false;
								

							}
							
						}
						
						checkmiddle = false;
						doublespace1 = true;
									
					if(beat2){
							
							

							for (int j = 0; j < 24; j++){
								
								if(		((blackx[changex] - differencex ) == whitex[j])	&&	((blacky[changey] + differencey) == whitey[j])	){
									dentx = denty = j;
									checkmiddle = true;
								}
								
							}
							
							
							
							
							for (int j = 0; j < 24; j++){
								

								
								if ( ((blackx[changex] - differencex - differencex)==blackx[j]) &&
										((blacky[changey] + differencey + differencey)==blacky[j])){
									doublespace1 = false;
								}
								
								if ( ((blackx[changex] - differencex - differencex)==whitex[j]) && 
										((blacky[changey] + differencey + differencey)==whitey[j]) ){
									doublespace1 = false;
								}
								
								if((blackx[changex] - differencex - differencex) < leftlimit)
								{
									doublespace1 = false;
								}
								
								if((blacky[changey] + differencey + differencey) > lowerlimit )
								{
									doublespace1 = false;
								}
								
							}
							
							if(doublespace1 && checkmiddle){
								
							
								
								i = 0;
								
							}
							
						}				
					checkmiddle = false;
					doublespace1 = true;				
								
					}
				}
				checkmiddle = false;
				doublespace1 = true;
				middlex = 0;
				middley = 0;
				
					//******************
					//*Black King Moves*
					//******************
					
//					float tempx = changex;
//					float tempy = changey;
//					float temx[] = blackx;
//					float temy[] = blacky;
					
					
					if (changex>=12 && changex<=23){
						
						
						
						for (int j = 0; j < 24; j++){
							

							if ((pressx>=blackx[j] && pressx<=(blackx[j]+differencex)) && (pressy>=blacky[j] && pressy<=(blacky[j]+differencey))){
								if((pressx < leavex) && (pressy < leavey)){
									middlex = blackx[j] + differencex;
									middley = blacky[j] + differencey;
								}
								else if((pressx > leavex) && (pressy < leavey)){
									
									middlex = blackx[j] - differencex;
									middley = blacky[j] + differencey;
									
								}
							}	
						}	

							for (int j = 0; j < 24; j++){
								
								if(		(middlex == whitex[j])	&&	(middley == whitey[j])	){
									dentx = denty = j;
						
									checkmiddle = true;
								}
							}
						
						
						
						
						for (int j = 0; j < 24; j++){
							
							if ((pressx>=blackx[j] && pressx<=(blackx[j]+differencex)) && (pressy>=blacky[j] && pressy<=(blacky[j]+differencey))){
								if((pressx < leavex)&& (pressy > leavey)){
									middlex = blackx[j] + differencex;
									middley = blacky[j] - differencey;
								}
								else if((pressx > leavex)&& (pressy > leavey)){
									
									middlex = blackx[j] - differencex;
									middley = blacky[j] - differencey;
									
								}
							}	
						}	

							for (int j = 0; j < 24; j++){
								
								if(		(middlex == whitex[j])	&&	(middley == whitey[j])	){
									dentx = denty = j;
							
									checkmiddle = true;
								}

							}
						

						
							if (leavex>=(blackx[changex]+differencex) &&
									(leavex<=(blackx[changex]+differencex+differencex)) && 
										(leavey>=(blacky[changey]+differencey)) && 
											(leavey<=(blacky[changey]+differencey+differencey)) &&
												(!((leavex>=(rightlimit+differencex) && 
														(leavey>=(lowerlimit+differencey)))))){
								
								blackx[changex]+=differencex;
								blacky[changey]+=differencey;	
								
								move.start();
								
								i = 1;
							}
					
					else if((leavex<=(blackx[changex]) &&
								(leavex>=(blackx[changex]-differencex)) &&
									(leavey>=(blacky[changey]+differencey)) &&
										(leavey<=(blacky[changey]+differencey+differencey)) &&
											(!((leavex<=(leftlimit)) &&
													(leavey>=(lowerlimit+differencey)))))){
								
								blackx[changex]-=differencex;
								blacky[changey]+=differencey;
											
								move.start();
								
								i = 1;
								
							}
						
						
							
					else if (leavex>=(blackx[changex]+differencex) &&
									(leavex<=(blackx[changex]+differencex+differencex)) &&
									leavey<=(blacky[changey]) &&
									(leavey>=(blacky[changey]-differencey)) &&
									(leavex<=(rightlimit+differencex) &&
									(leavey>=(upperlimit)))){
							
								
								blackx[changex]+=differencex;
								blacky[changey]-=differencey;

								move.start();
								
								i = 1;
								
							}
							
					else if((leavex<=(blackx[changex]) && (leavex>=(blackx[changex]-differencex)) &&
									(leavey<=(blacky[changey]) && (leavey>=(blacky[changey]-differencey))) &&
									(leavex>=(leftlimit) && (leavey>=(upperlimit))))){
								
								blackx[changex]-=differencex;
								blacky[changey]-=differencey;

								move.start();
								
								i = 1;
								
							}	
							
					
					
					else if(leavex>=(blackx[changex]+differencex+differencex) 
							&& (leavex<=(blackx[changex]+differencex+differencex+differencex)) 
							&& leavey>=(blacky[changey]+differencey+differencey)
							&& (leavey<=(blacky[changey]+differencey+differencey+differencey))
							&& checkmiddle){
						
						
						leavex = blackx[changex] + differencex + differencex;
						leavey = blacky[changey] + differencey + differencey;
						
						
						blackx[changex] = leavex;
						blacky[changey] = leavey;
						
						
						whitex[dentx] = tabahi;
						whitey[denty] = tabahi;
						
						checkmiddle = false;
						
						beat3 = true;
						
						beat.start();
						
						cross.start();
						
						//******************BEATBOX*************
						beatx=leftlimit;
						beaty=(upperlimit+lowerlimit+differencey)/2 - bwin.getHeight();
						fn=1;			

i = 1;
						}
			
					else if(leavex<=(blackx[changex]-differencex) 
							&& (leavex>=(blackx[changex]-differencex-differencex)) 
							&& leavey>=(blacky[changey]+differencey+differencey)
							&& (leavey<=(blacky[changey]+differencey+differencey+differencey))
							&& checkmiddle){
						
						
						leavex = blackx[changex] - differencex - differencex;
						leavey = blacky[changey] + differencey + differencey;
						
						
						blackx[changex] = leavex;
						blacky[changey] = leavey;
						
						
						whitex[dentx] = tabahi;
						whitey[denty] = tabahi;
						
						beat3 = true;
						checkmiddle = false;
						beat.start();
						
						cross.start();
						
						i = 1;
						}
					
							
					else if(leavex>=(blackx[changex]+differencex+differencex) 
							&& (leavex<=(blackx[changex]+differencex+differencex+differencex)) 
							&& leavey<=(blacky[changey]-differencey)
							&& (leavey>=(blacky[changey]-differencey-differencey))
							&& checkmiddle){
						
						
						leavex = blackx[changex] + differencex + differencex;
						leavey = blacky[changey] - differencey - differencey;
						
						
						blackx[changex] = leavex;
						blacky[changey] = leavey;
						
						
						whitex[dentx] = tabahi;
						whitey[denty] = tabahi;
						
						checkmiddle = false;
						i = 1;
						
						beat.start();
						
						cross.start();
						
						//**************BEATBOX***********************
						beatx=leftlimit;
						beaty=(upperlimit+lowerlimit+differencey)/2 - bwin.getHeight();
						
						
			fn=1;		

beat3 = true;
						}
			
			
					else if(leavex<=(blackx[changex]-differencex) 
							&& (leavex>=(blackx[changex]-differencex-differencex)) 
							&& leavey<=(blacky[changey]-differencey)
							&& (leavey>=(blacky[changey]-differencey-differencey))
							&& checkmiddle){
						
						
						leavex = blackx[changex] - differencex - differencex;
						leavey = blacky[changey] - differencey - differencey;
						
						
						blackx[changex] = leavex;
						blacky[changey] = leavey;
						
						checkmiddle = false;
						whitex[dentx] = tabahi;
						whitey[denty] = tabahi;
						
						
						i = 1;
						beat.start();
						
						
						cross.start();
					
						//********************BEATBOX****************
				
						beatx=leftlimit;
						beaty=(upperlimit+lowerlimit+differencey)/2 - bwin.getHeight();
						
						fn=1;	
			
beat3 = true;
						}
							
							
							if(beat3){
								
								

								for (int j = 0; j < 24; j++){
									
									if(		((blackx[changex] + differencex ) == whitex[j])	&&	((blacky[changey] + differencey) == whitey[j])	){	
										checkmiddle = true;
									}
									
								}
								
								
								for (int j = 0; j < 24; j++){
									

									
									if ( ((blackx[changex] + differencex + differencex)==blackx[j]) &&
											((blacky[changey] + differencey + differencey)==blacky[j])){
										doublespace1 = false;
									}
									
									if ( ((blackx[changex] + differencex + differencex)==whitex[j]) && 
											((blacky[changey] + differencey + differencey)==whitey[j]) ){
										doublespace1 = false;
									}
									if((blackx[changex] + differencex + differencex) > (rightlimit))
									{
										doublespace1 = false;
									}
									
									if((blacky[changey] + differencey + differencey) > (lowerlimit))
									{
										doublespace1 = false;
									}
									
								}
								
								if(doublespace1 && checkmiddle){
									i = 0;
									beat3 = false;
								}
								
							}
							
							checkmiddle = false;
							doublespace1 = true;
										
						if(beat3){
								
								

								for (int j = 0; j < 24; j++){
									
									if(		((blackx[changex] - differencex ) == whitex[j])	&&	((blacky[changey] + differencey) == whitey[j])	){
										
										checkmiddle = true;
									}
									
								}
								
								
								
								
								for (int j = 0; j < 24; j++){
									

									
									if ( ((blackx[changex] - differencex - differencex)==blackx[j]) &&
											((blacky[changey] + differencey + differencey)==blacky[j])){
										doublespace1 = false;
									}
									
									if ( ((blackx[changex] - differencex - differencex)==whitex[j]) && 
											((blacky[changey] + differencey + differencey)==whitey[j]) ){
										doublespace1 = false;
									}
									
									if((blackx[changex] - differencex - differencex) < leftlimit)
									{
										doublespace1 = false;
									}
									
									if((blacky[changey] + differencey + differencey) > (lowerlimit))
									{
										doublespace1 = false;
									}
									
								}
								
								if(doublespace1 && checkmiddle){			
									i = 0;
									beat3 = false;
								}
								
							}
						
						checkmiddle = false;
						doublespace1 = true;
							
						
						if(beat3){
							
							

							
							
							for (int j = 0; j < 24; j++){
								
								if(		((blackx[changex] + differencex ) == whitex[j]) &&((blacky[changey] - differencey) == whitey[j])	){								
									checkmiddle = true;
								}

							}
						
							
						
						
						
						for (int j = 0; j < 24; j++){
							

							
							if ( ((blackx[changex] + differencex + differencex)==blackx[j]) &&
									((blacky[changey] - differencey - differencey)==blacky[j])){
								doublespace1 = false;
							}
							
							if ( ((blackx[changex] + differencex + differencex)==whitex[j]) && 
									((blacky[changey] - differencey - differencey)==whitey[j]) ){
								doublespace1 = false;
							}
							if((blackx[changex] + differencex + differencex) > (rightlimit))
							{
								doublespace1 = false;
							}
							
							if((blacky[changey] - differencey - differencey) < upperlimit)
							{
								doublespace1 = false;
							}
							
						}
						
						if(doublespace1 && checkmiddle){

							i = 0;
							beat3 = false;
							
						}
						
					}
					
					checkmiddle = false;
					doublespace1 = true;
								
				if(beat3){
						
						

						for (int j = 0; j < 24; j++){
							
							if(		((blackx[changex] - differencex ) == whitex[j])	&&	((blacky[changey] - differencey) == whitey[j])	){						
								checkmiddle = true;
							}
							
						}
						
						
						for (int j = 0; j < 24; j++){
							

							
							if ( ((blackx[changex] - differencex - differencex)==whitex[j]) &&
									((blacky[changey] - differencey - differencey)==whitey[j])){
								doublespace1 = false;
							}
							
							if ( ((blackx[changex] - differencex - differencex)==blackx[j]) && 
									((blacky[changey] - differencey - differencey)==blacky[j]) ){
								doublespace1 = false;
							}
							
							if((blackx[changex] - differencex - differencex) < leftlimit)
							{
								doublespace1 = false;
							}
							
							if((blacky[changey] - differencey - differencey) < upperlimit)
							{
								doublespace1 = false;
							}
							
						}
						
						if(doublespace1 && checkmiddle){

							
							i = 0;
							beat3 = false;
							
						}
						
					}	
							
							
					}
					

					//**********************
					//*Black King Move Ends*
					//**********************

							
				checkmiddle = false;		
				beat2 = false;
				beat3 = false;
				checkspace = false;
					}
				
//************************************************Turn Of Black Ends********************************************************//					
				
//************************************************Turn Of White*************************************************************//			
			
if (i==1 && checkspace){

	


	
//************************************************White Beat*************************************************************//		
	
	for (int j = 0; j < 24; j++){
		
		if ((pressx>=whitex[j] && pressx<=(whitex[j]+differencex)) && (pressy>=whitey[j] && pressy<=(whitey[j]+differencey))){
			if((pressx < leavex)&& (pressy > leavey)){
				middlex = whitex[j] + differencex;
				middley = whitey[j] - differencey;
			}
			else if((pressx > leavex)&& (pressy > leavey)){
				
				middlex = whitex[j] - differencex;
				middley = whitey[j] - differencey;
				
			}
		}	
	}	

		for (int j = 0; j < 24; j++){
			
			if(		(middlex == blackx[j])	&&	(middley == blacky[j])	){
				dentx = denty = j;
		
				checkmiddle = true;
			}

		}
		
	
//************************************************White Beat Ends*************************************************************//			
	

					
				  if (changex>=0 && changex<=11){
				
					if ((checkx != leavex)&& (leavey != checky)){
								
						if (leavex>=(whitex[changex]+differencex) && (leavex<=(whitex[changex]+differencex+differencex)) 
										&& leavey<=(whitey[changey]) && (leavey>=(whitey[changey]-differencey))){
								
									
									leavex = whitex[changex]+differencex;
									leavey = whitey[changey]-differencey;
									

									
									whitex[changex] = leavex;
									whitey[changey] = leavey;

									move.start();
									
									i = 0;
									
								}
								
								else if((leavex<=(whitex[changex]) && (leavex>=(whitex[changex]-differencex)) &&
										(leavey<=(whitey[changey]) && (leavey>=(whitey[changey]-differencey))))){
									
									leavex = whitex[changex]-differencex;
									leavey = whitey[changey]-differencey;
									
									
									whitex[changex] = leavex;
									whitey[changey] = leavey;
							
									move.start();
									
									i = 0;
									
								}
						
								else if(leavex>=(whitex[changex]+differencex+differencex) 
										&& (leavex<=(whitex[changex]+differencex+differencex+differencex)) 
										&& leavey<=(whitey[changey]-differencey)
										&& (leavey>=(whitey[changey]-differencey-differencey))
										&& checkmiddle){
									
									
									leavex = whitex[changex] + differencex + differencex;
									leavey = whitey[changey] - differencey - differencey;
									
									
									whitex[changex] = leavex;
									whitey[changey] = leavey;
									
									
									blackx[dentx] = tabahi;
									blacky[denty] = tabahi;
							
									
									i = 0;
									
									beat.start();
									cross.start();
									
									
									//*****************BEATBOX**************8
									
									beatx=leftlimit;
									beaty=(upperlimit+lowerlimit+differencey)/2 - bwin.getHeight();
									
fn=1;
									checkmiddle = false;
									beat2 = true;
								}
						
						
								else if(leavex<=(whitex[changex]-differencex) 
										&& (leavex>=(whitex[changex]-differencex-differencex)) 
										&& leavey<=(whitey[changey]-differencey)
										&& (leavey>=(whitey[changey]-differencey-differencey))
										&& checkmiddle){
									
									
									leavex = whitex[changex] - differencex - differencex;
									leavey = whitey[changey] - differencey - differencey;
									
									
									whitex[changex] = leavex;
									whitey[changey] = leavey;
									
									
									blackx[dentx] = tabahi;
									blacky[denty] = tabahi;
									checkmiddle = false;
									beat.start();
									cross.start();
									
									//********************BEAtBOX*****************
									beatx=leftlimit;
									beaty=(upperlimit+lowerlimit+differencey)/2 - bwin.getHeight();
							
							fn=1;
							
	i = 0;
									
									beat2 = true;
								}
									
									
						checkmiddle = false;
						
						if(beat2){
							
							

						
								
								for (int j = 0; j < 24; j++){
									
									if(		((whitex[changex] + differencex ) == blackx[j]) &&((whitey[changey] - differencey) == blacky[j])	){								
										checkmiddle = true;
									}

								}
							
								
							
							
							
							for (int j = 0; j < 24; j++){
								

								
								if ( ((whitex[changex] + differencex + differencex)==blackx[j]) &&
										((whitey[changey] - differencey - differencey)==blacky[j])){
									doublespace1 = false;
								}
								
								if ( ((whitex[changex] + differencex + differencex)==whitex[j]) && 
										((whitey[changey] - differencey - differencey)==whitey[j]) ){
									doublespace1 = false;
								}
								if((whitex[changex] + differencex + differencex) > (rightlimit))
								{
									doublespace1 = false;
								}
								
								if((whitey[changey] - differencey - differencey) < upperlimit)
								{
									doublespace1 = false;
								}
								
							}
							
							if(doublespace1 && checkmiddle){

								i = 1;
								
							}
							
						}
						
						checkmiddle = false;
						doublespace1 = true;
									
					if(beat2){
							
							

							for (int j = 0; j < 24; j++){
								
								if(		((whitex[changex] - differencex ) == blackx[j])	&&	((whitey[changey] - differencey) == blacky[j])	){						
									checkmiddle = true;
								}
								
							}
							
							
							for (int j = 0; j < 24; j++){
								

								
								if ( ((whitex[changex] - differencex - differencex)==blackx[j]) &&
										((whitey[changey] - differencey - differencey)==blacky[j])){
									doublespace1 = false;
								}
								
								if ( ((whitex[changex] - differencex - differencex)==whitex[j]) && 
										((whitey[changey] - differencey - differencey)==whitey[j]) ){
									doublespace1 = false;
								}
								
								if((whitex[changex] - differencex - differencex) < leftlimit)
								{
									doublespace1 = false;
								}
								
								if((whitey[changey] - differencey - differencey) < upperlimit)
								{
									doublespace1 = false;
								}
								
							}
							
							if(doublespace1 && checkmiddle){

								
								i = 1;
								
							}
							
						}	
					
					checkmiddle = false;
					doublespace1 = true;
					
				}
			}
				  
					checkmiddle = false;
					doublespace1 = true;
					middlex = 0;
					middley = 0;
					
					//******************
					//*White King Moves*
					//******************
					
//					float tempx = changex;
//					float tempy = changey;
//					float temx[] = blackx;
//					float temy[] = blacky;
					
					
					if (changex>=12 && changex<=23){
						
						
						for (int j = 0; j < 24; j++){
							
							if ((pressx>=whitex[j] && pressx<=(whitex[j]+differencex)) && (pressy>=whitey[j] && pressy<=(whitey[j]+differencey))){
								if((pressx < leavex)&& (pressy > leavey)){
									middlex = whitex[j] + differencex;
									middley = whitey[j] - differencey;
								}
								else if((pressx > leavex)&& (pressy > leavey)){
									
									middlex = whitex[j] - differencex;
									middley = whitey[j] - differencey;
									
								}
							}	
						}	

							for (int j = 0; j < 24; j++){
								
								if(		(middlex == blackx[j])	&&	(middley == blacky[j])	){
									dentx = denty = j;
							
									checkmiddle = true;
								}

							}
						
						
						
						for (int j = 0; j < 24; j++){
							

							if ((pressx>=whitex[j] && pressx<=(whitex[j]+differencex)) && (pressy>=whitey[j] && pressy<=(whitey[j]+differencey))){
								if((pressx < leavex) && (pressy < leavey)){
									middlex = whitex[j] + differencex;
									middley = whitey[j] + differencey;
								}
								else if((pressx > leavex) && (pressy < leavey)){
									
									middlex = whitex[j] - differencex;
									middley = whitey[j] + differencey;
									
								}
							}	
						}	

							for (int j = 0; j < 24; j++){
								
								if(		(middlex == blackx[j])	&&	(middley == blacky[j])	){
									dentx = denty = j;
						
									checkmiddle = true;
								}
							}
						
						
						
						

						
							if (leavex>=(whitex[changex]+differencex) &&
									(leavex<=(whitex[changex]+differencex+differencex)) && 
										(leavey>=(whitey[changey]+differencey)) && 
											(leavey<=(whitey[changey]+differencey+differencey)) &&
												(!((leavex>=(rightlimit+differencex) && 
														(leavey>=(lowerlimit+differencey)))))){
								
								whitex[changex]+=differencex;
								whitey[changey]+=differencey;	
								
								move.start();
								
								i = 0;
							}
					
					else if((leavex<=(whitex[changex]) &&
								(leavex>=(whitex[changex]-differencex)) &&
									(leavey>=(whitey[changey]+differencey)) &&
										(leavey<=(whitey[changey]+differencey+differencey)) &&
											(!((leavex<=(leftlimit)) &&
													(leavey>=(lowerlimit+differencey)))))){
								
						whitex[changex]-=differencex;
						whitey[changey]+=differencey;
											
						move.start();		
						
								i = 0;
								
							}
						
						
							
					else if (leavex>=(whitex[changex]+differencex) &&
									(leavex<=(whitex[changex]+differencex+differencex)) &&
									leavey<=(whitey[changey]) &&
									(leavey>=(whitey[changey]-differencey)) &&
									(leavex<=(rightlimit+differencex) &&
									(leavey>=(upperlimit)))){
							
								
						whitex[changex]+=differencex;
						whitey[changey]-=differencey;

						move.start();
						
								i = 0;
								
							}
							
					else if((leavex<=(whitex[changex]) && (leavex>=(whitex[changex]-differencex)) &&
									(leavey<=(whitey[changey]) && (leavey>=(whitey[changey]-differencey))) &&
									(leavex>=(leftlimit) && (leavey>=(upperlimit))))){
								
						whitex[changex]-=differencex;
						whitey[changey]-=differencey;

						move.start();
						
								i = 0;
								
							}	
					
					
					else if(leavex>=(whitex[changex]+differencex+differencex) 
							&& (leavex<=(whitex[changex]+differencex+differencex+differencex)) 
							&& leavey>=(whitey[changey]+differencey+differencey)
							&& (leavey<=(whitey[changey]+differencey+differencey+differencey))
							&& checkmiddle){
						
						
						leavex = whitex[changex] + differencex + differencex;
						leavey = whitey[changey] + differencey + differencey;
						
						
						whitex[changex] = leavex;
						whitey[changey] = leavey;
						
						
						blackx[dentx] = tabahi;
						blacky[denty] = tabahi;
						
						beat.start();
						cross.start();
						//******************BEATBOX***************************
						beatx=leftlimit;
						beaty=(upperlimit+lowerlimit+differencey)/2 - bwin.getHeight();
fn=1;
					
beat3 = true;
						
						checkmiddle = false;
						
						i = 0;
					}
			
					else if(leavex<=(whitex[changex]-differencex) 
							&& (leavex>=(whitex[changex]-differencex-differencex)) 
							&& leavey>=(whitey[changey]+differencey+differencey)
							&& (leavey<=(whitey[changey]+differencey+differencey+differencey))
							&& checkmiddle){
						
						
						leavex = whitex[changex] - differencex - differencex;
						leavey = whitey[changey] + differencey + differencey;
						
						
						whitex[changex] = leavex;
						whitey[changey] = leavey;
						
						
						blackx[dentx] = tabahi;
						blacky[denty] = tabahi;
						checkmiddle = false;
						beat.start();
						
						cross.start();
						//**************************BEATBOX****************
						beatx=leftlimit;
						beaty=(upperlimit+lowerlimit+differencey)/2 - bwin.getHeight();
				
fn=1;
						beat3 = true;
						
						i = 0;
					}
							
							
					else if(leavex>=(whitex[changex]+differencex+differencex) 
							&& (leavex<=(whitex[changex]+differencex+differencex+differencex)) 
							&& leavey<=(whitey[changey]-differencey)
							&& (leavey>=(whitey[changey]-differencey-differencey))
							&& checkmiddle){
						
						
						leavex = whitex[changex] + differencex + differencex;
						leavey = whitey[changey] - differencey - differencey;
						
						
						whitex[changex] = leavex;
						whitey[changey] = leavey;
						
						
						blackx[dentx] = tabahi;
						blacky[denty] = tabahi;
						
						checkmiddle = false;
						i = 0;
						
						beat.start();
						cross.start();
						//*************BEATBOX**************************
						beatx=leftlimit;
						beaty=(upperlimit+lowerlimit+differencey)/2 - bwin.getHeight();
						
						
						fn=1;

beat3 = true;
					}
			
			
					else if(leavex<=(whitex[changex]-differencex) 
							&& (leavex>=(whitex[changex]-differencex-differencex)) 
							&& leavey<=(whitey[changey]-differencey)
							&& (leavey>=(whitey[changey]-differencey-differencey))
							&& checkmiddle){
						
						
						leavex = whitex[changex] - differencex - differencex;
						leavey = whitey[changey] - differencey - differencey;
						
						
						whitex[changex] = leavex;
						whitey[changey] = leavey;
						
						
						blackx[dentx] = tabahi;
						blacky[denty] = tabahi;
						checkmiddle = false;
						
						i = 0;
						
						beat.start();
						cross.start();
						
						//*************************BEATBOX********************
						beatx=leftlimit;
						beaty=(upperlimit+lowerlimit+differencey)/2 - bwin.getHeight();
						
						fn=1;
						
beat3 = true;
					}
					
							if(beat3){
								
								

								for (int j = 0; j < 24; j++){
									
									if(		((whitex[changex] + differencex ) == blackx[j])	&&	((whitey[changey] + differencey) == blacky[j])	){	
										checkmiddle = true;
									}
									
								}
								
								
								for (int j = 0; j < 24; j++){
									

									
									if ( ((whitex[changex] + differencex + differencex)==blackx[j]) &&
											((whitey[changey] + differencey + differencey)==blacky[j])){
										doublespace1 = false;
									}
									
									if ( ((whitex[changex] + differencex + differencex)==whitex[j]) && 
											((whitey[changey] + differencey + differencey)==whitey[j]) ){
										doublespace1 = false;
									}
									if((whitex[changex] + differencex + differencex) > (rightlimit))
									{
										doublespace1 = false;
									}
									
									if((whitey[changey] + differencey + differencey) > (lowerlimit))
									{
										doublespace1 = false;
									}
									
								}
								
								if(doublespace1 && checkmiddle){
									i = 1;
									beat3 = false;
								}
								
							}
							
							checkmiddle = false;
							doublespace1 = true;
										
						if(beat3){
								
								

								for (int j = 0; j < 24; j++){
									
									if(		((whitex[changex] - differencex ) == blackx[j])	&&	((whitey[changey] + differencey) == blacky[j])	){
										
										checkmiddle = true;
									}
									
								}
								
								
								
								
								for (int j = 0; j < 24; j++){
									

									
									if ( ((whitex[changex] - differencex - differencex)==blackx[j]) &&
											((whitey[changey] + differencey + differencey)==blacky[j])){
										doublespace1 = false;
									}
									
									if ( ((whitex[changex] - differencex - differencex)==whitex[j]) && 
											((whitey[changey] + differencey + differencey)==whitey[j]) ){
										doublespace1 = false;
									}
									
									if((whitex[changex] - differencex - differencex) < leftlimit)
									{
										doublespace1 = false;
									}
									
									if((whitey[changey] + differencey + differencey) > (lowerlimit))
									{
										doublespace1 = false;
									}
									
								}
								
								if(doublespace1 && checkmiddle){
											i = 1;
											beat3 = false;
									
								}
						}
						
						checkmiddle = false;
						doublespace1 = true;
						
						
						if(beat3){
							
							

							
							
							for (int j = 0; j < 24; j++){
								
								if(		((whitex[changex] + differencex ) == blackx[j]) &&((whitey[changey] - differencey) == blacky[j])	){								
									checkmiddle = true;
								}

							}
						
							
						
						
						
						for (int j = 0; j < 24; j++){
							

							
							if ( ((whitex[changex] + differencex + differencex)==blackx[j]) &&
									((whitey[changey] - differencey - differencey)==blacky[j])){
								doublespace1 = false;
							}
							
							if ( ((whitex[changex] + differencex + differencex)==whitex[j]) && 
									((whitey[changey] - differencey - differencey)==whitey[j]) ){
								doublespace1 = false;
							}
							if((whitex[changex] + differencex + differencex) > (rightlimit))
							{
								doublespace1 = false;
							}
							
							if((whitey[changey] - differencey - differencey) < upperlimit)
							{
								doublespace1 = false;
							}
							
						}
						
						if(doublespace1 && checkmiddle){

							i = 1;
							beat3 = false;
						}
						
					}
					
					checkmiddle = false;
					doublespace1 = true;
								
				if(beat3){
						
						

						for (int j = 0; j < 24; j++){
							
							if(		((whitex[changex] - differencex ) == blackx[j])	&&	((whitey[changey] - differencey) == blacky[j])	){						
								checkmiddle = true;
							}
							
						}
						
						
						for (int j = 0; j < 24; j++){
							

							
							if ( ((whitex[changex] - differencex - differencex)==blackx[j]) &&
									((whitey[changey] - differencey - differencey)==blacky[j])){
								doublespace1 = false;
							}
							
							if ( ((whitex[changex] - differencex - differencex)==whitex[j]) && 
									((whitey[changey] - differencey - differencey)==whitey[j]) ){
								doublespace1 = false;
							}
							
							if((whitex[changex] - differencex - differencex) < leftlimit)
							{
								doublespace1 = false;
							}
							
							if((whitey[changey] - differencey - differencey) < upperlimit)
							{
								doublespace1 = false;
							}
							
						}
						
						if(doublespace1 && checkmiddle){

							
							i = 1;
							beat3 = false;
						}
						
					}

					
					}
					

					//**********************
					//*White King Move Ends*
					//**********************
					
					
						

					}


//************************************************Turn Of White Ends*************************************************************//		
			

				if (changey<12){

				if (blacky[changey] == (startingy + (differencey + differencey + differencey + differencey + differencey + differencey + differencey))){
					blackx[changex + 12] = blackx[changex];
					blacky[changey + 12] = blacky[changey];
					blackx[changex] = tabahi;
					blacky[changey] = tabahi;
					king.start();
					
				}
				
				
				if (whitey[changey] == startingy){
					whitex[changex + 12] = whitex[changex];
					whitey[changey + 12] = whitey[changey];
					whitex[changex] = tabahi;
					whitey[changey] = tabahi;
					king.start();
					
				}
				}
				
				
//				try {
//					if((leavex == 0) && (i == 0)){
//						canvas.drawBitmap(redcover, blackx[changex], blacky[changey], null);
//					}
//					else if ((leavex == 0) && (i == 1)){
//						canvas.drawBitmap(redcover, whitex[changex], whitey[changey], null);
//					}
//				} catch (Exception e) {
//					// TODO Auto-generated catch block
//					e.printStackTrace();
//				}
				
				
				
				
				for (int j = 0; j < 24; j++){
					
					if(whitex[j] != tabahi){						
						whitewin = false;
					}
					
				}
				for (int j = 0; j < 24; j++){
					
					if(blackx[j] != tabahi){						
						blackwin = false;
					}
					
				}
				
				
				if(whitewin){
					canvas.drawBitmap(bwin, leftlimit , (upperlimit+lowerlimit+differencey)/2 - bwin.getHeight(), null);
					cheers.start();
				}
				
				if(blackwin){
					canvas.drawBitmap(wwin, leftlimit, (upperlimit+lowerlimit+differencey)/2 - wwin.getHeight(), null);
					cheers.start();
				}
		/*			if(or==1)
					{
						try {
							Thread.sleep(2000);
						} catch (InterruptedException e) {
							// TODO Auto-generated catch block
							e.printStackTrace();
						}
						or=0;
					}
*/
				Holder.unlockCanvasAndPost(canvas);
				leavex  = leavey = 0;
				checkspace = true;
				checkmiddle = false;
				beat2 = false;
				beat3 = false;
				doublespace1 = true;
				doublespace2 = false;
				middlex = middley = 0;
				blackwin = true;
				whitewin = true;
				
				
				if(!sound.isPlaying()){
					sound.start();
					
				}
			
		}
	}
		










		public void pause(){
			Running = false;
			
			while(true){
				try {
					thread.join();
				} catch (InterruptedException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
				break;
			}
			thread = null;
		}
		
		public void resume(){
			Running = true;
			
			thread = new Thread(this);
			thread.start();
		}

	}
	

	

}
