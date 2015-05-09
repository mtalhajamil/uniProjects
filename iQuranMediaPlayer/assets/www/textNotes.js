


/////////////////////////Append TextNotes//////////////////////

function appendTextNotes(){
	db.transaction(function(transaction) 
	{ 

		transaction.executeSql('SELECT TNote,AiyahNo from TextNotes where SurahNo='+ surahNo +';', [],function(transaction, result) 
		{ 
			if (result != null && result.rows != null) 
			{ 
				if(result.rows.length != 0){
					for (var k = 0; k < result.rows.length; k++) 
					{ 
						var row_note = result.rows.item(k); 
						var l=k+1;

						if (tHistory_ayat != row_note.AiyahNo)
							$('#T'+ row_note.AiyahNo).html('');

						tHistory_ayat = row_note.AiyahNo;

						/*          $('#T'+ row_note.AiyahNo).style.display = "show";*/
						$('#T'+ row_note.AiyahNo).append('<li><div data-role="content" style="white-space:normal; text-align: left; background-color: white; color: black;" > <b> Note: </b>' + row_note.TNote + '</div></li>');
					} 
					tHistory_ayat = 0;
				}


				else{
					alert("No Notes in this Surah");
					toggleDisplayTNotes = 0;
				}
			} 

		},errorHandler); 
	},errorHandler,nullHandler);
}


//////////////////////////Remove TextNotes///////////////////////////////////////////

function removeTextNotes(){
	db.transaction(function(transaction) 
	{ 

		transaction.executeSql('SELECT TNote,AiyahNo from TextNotes where SurahNo='+ surahNo +';', [],function(transaction, result) 
		{ 
			if (result != null && result.rows != null) 
			{ 
				if(result.rows.length != 0){
					for (var k = 0; k < result.rows.length; k++) 
					{ 
						var row_note = result.rows.item(k); 
						var l=k+1;

						if (tHistory_ayat != row_note.AiyahNo)
							$('#T'+ row_note.AiyahNo).html('');

						tHistory_ayat = row_note.AiyahNo;
					} 
					tHistory_ayat = 0;
				}

			} 

		},errorHandler); 
	},errorHandler,nullHandler);
}