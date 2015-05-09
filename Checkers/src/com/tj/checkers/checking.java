package com.tj.checkers;

import android.app.Activity;

public class checking extends Activity {
	
	private static int boardcheck;

	public static int getBoardcheck() {
		return boardcheck;
	}

	public static void setBoardcheck(int boardcheck) {
		checking.boardcheck = boardcheck;
	}

}
