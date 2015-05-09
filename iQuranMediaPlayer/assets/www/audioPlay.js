//////////////////////////playing audio & voice notes//////////////////////

function playAudio(src) {

	if (mediaPlay == null){
		mediaPlay = new Media(src, onSuccess, onError);
		mediaPlay.play();
	} 
	else 
	{
		mediaPlay.stop();
		mediaPlay = new Media(src, onSuccess, onError);
		mediaPlay.play();

	}

	var playTime = 0;
	playInterval = setInterval(function() {
		playTime = playTime + 1;
		setPlayAudioPosition(playTime + " sec");
		if (playTime >= 100000) {
			clearInterval(playInterval);
			mediaPlay.stopRecord();
		}
	}, 1000);
}