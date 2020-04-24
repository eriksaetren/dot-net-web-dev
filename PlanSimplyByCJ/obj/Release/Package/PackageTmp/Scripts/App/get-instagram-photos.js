function GetInstagramPhotos() {   
	var instagramaccessid = "4466122088";
	var instagramaccesstoken = "4466122088.4e8538b.4b55a5fca56d41548900c81e58faff14";
	$.ajax({  
		type: "GET",  
		async: true,  
		contentType: "application/json; charset=utf-8",  
		//Recent user photos  
		url: 'https://api.instagram.com/v1/users/' + instagramaccessid + '/media/recent?access_token=' + instagramaccesstoken,  
		//Most popular photos  
		//url: "https://api.instagram.com/v1/media/popular?access_token=" + instagramaccesstoken,  
		//For most recent pictures from a specific location:  
		//url:  "https://api.instagram.com/v1/media/search?lat=[LAT]&lng=[LNG]&distance=[DST]?client_id=[ClientID]&access_token=[CODE]",  
		//For min and max images  
		//url: "https://api.instagram.com/v1/users/"+ userId+ "/media/recent/"+ "?access_token="+ token+ "&count=" + mediaCount+ "&max_id=" + mOldestId",  
		//By Tags  
		//url: "https://api.instagram.com/v1/tags/coffee/media/recent?client_id=[]&access_token=[]",  
		//To get a user’s detail  
		//url: "https://api.instagram.com/v1/users/usert_id/?access_token=youraccesstoken",  
		dataType: "jsonp",  
		cache: false,  
		beforeSend: function () {  
			// Nothing for now
		},  
		success: function (data) {   
			if(!data) {  
				$(".slick-content").hide();  
			} else { 
				slickInit(data);
			}  
		}  

	});  
}  
