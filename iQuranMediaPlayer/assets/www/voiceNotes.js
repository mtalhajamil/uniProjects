//////////////////////////Append VoiceNotes//////////////////////////////

function appendVoiceNotes(){

	db.transaction(function(transaction) 
	{ 

		transaction.executeSql('SELECT AiyahNo,VNote from VoiceNotes where SurahNo='+ surahNo +';', [],function(transaction, result) 
		{ 
			if (result != null && result.rows != null) 
			{ 
				if(result.rows.length != 0){
					for (var k = 0; k < result.rows.length; k++) 
					{ 
						var row_note = result.rows.item(k); 

						if (vHistory_ayat != row_note.AiyahNo)
							$('#V'+ row_note.AiyahNo).html('');

						vHistory_ayat = row_note.AiyahNo;

						$('#V'+ row_note.AiyahNo).append('<li><input type="button" value="PlayVoiceNote:'+ row_note.VNote +'" id="playVoiceNote'+row_note.VNote+'" data-VNote=\''+ row_note.VNote + '\' style="white-space:normal; text-align: center; background-color: Azure; border: none; color: blue; width: 100%" onClick="playAudio(\''+audioDir+row_note.VNote+'.mp3\')" ></li>');
					} 
					vHistory_ayat = 0;
				}

				else{
					alert("No VoiceNotes in this Surah");
					toggleDisplayVNotes = 0;
				}
			} 

		},errorHandler); 
	},errorHandler,nullHandler);

}

///////////////////////////////////Remove VoiceNotes////////////////////////////////////////////

function removeVoiceNotes(){

	db.transaction(function(transaction) 
	{ 

		transaction.executeSql('SELECT AiyahNo,VNote from VoiceNotes where SurahNo='+ surahNo +';', [],function(transaction, result) 
		{ 
			if (result != null && result.rows != null) 
			{ 
				if(result.rows.length != 0){
					for (var k = 0; k < result.rows.length; k++) 
					{ 
						var row_note = result.rows.item(k); 

						if (vHistory_ayat != row_note.AiyahNo)
							$('#V'+ row_note.AiyahNo).html('');

						vHistory_ayat = row_note.AiyahNo;
					} 
					vHistory_ayat = 0;
				}

			} 

		},errorHandler); 
	},errorHandler,nullHandler);

}


////CREATE VOICE FILE///
function createVoiceFile(){
	window.requestFileSystem(LocalFileSystem.PERSISTENT, 0, gotFS, function fail(){});
}

////////rECORD aUDIO////

function recordAudio(mediaRec) {

// Record audio
mediaRec.startRecord();


// Stop recording after 10 sec
var recTime = 0;
recInterval = setInterval(function() {
	recTime = recTime + 1;
	setAudioPosition(recTime + " sec");
	if (recTime >= 100000) {
		clearInterval(recInterval);
		mediaRec.stopRecord();
	}
}, 1000);
}

///////////gotFS//////
function gotFS(fileSystem,path) {
	fileSystem.root.getDirectory("iQuranMedia", {create: true});
	fileSystem.root.getDirectory("iQuranMedia/VoiceNotes", {create: true});
	fileSystem.root.getFile(voiceNotePath,
{ create: true, exclusive: false }, //create if it does not exist
function success(entry) {
	var src = entry.toURI();
console.log(src); //logs blank.wav's path starting with file://
},
function fail() {}
);
}

/////////////////////////////////////////////////////