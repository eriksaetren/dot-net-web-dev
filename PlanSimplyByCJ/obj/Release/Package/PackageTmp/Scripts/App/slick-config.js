
function slickInit(data){
	//console.log(data.data);
	var i = 0;
	var instaPost;
	var slide;
	var mobileRes;
	var imgSrc;
	
	for(i; i < data.data.length; i++){
		instaPost = data.data[i];
		slide = "";
		imgSrc = (jQuery(window).width < 480) ? instaPost.images.low_resolution.url : instaPost.images.standard_resolution.url;  // Are we on mobile?
		
		slide += '<div class="slide slick-slide" >';
		slide += '	<a class="img-thumbnail" href="' + instaPost.link + '">';
		slide += '		<img class="slide-img" data-lazy="' + imgSrc +'" />';
		slide += '		<div class="openInfo"><i class="fa fa-caret-up" aria-hidden="true"></i></div>';
		slide += '		<div class="slide-infoBox">';
		slide += '			<div class="closeInfo" style="display: none;"><i class="fa fa-caret-down" aria-hidden="true"></i></div>';
		slide += '			<p class="slide-caption">' + instaPost.caption.text + '</p>';
		slide += '		</div>';
		slide += '	</a>';
		slide += '</div>';
		
		jQuery(".slick-main").append(slide);
	}
	
	jQuery(".openInfo").click(function (e){
		var botOffset = (jQuery(window).width() > 480) ? "6vw" : "10vw";
		botOffset = (jQuery(window).width() > 768) ? "4vw" : botOffset;
		
		e.preventDefault();
		jQuery(this).css("display", "none");
		jQuery(this).siblings(".slide-infoBox").css({
			opacity: "1",
			bottom: botOffset
		}).children(".closeInfo").css("display", "block");
	});
	
	jQuery(".closeInfo").click(function (e){
		e.preventDefault();
		jQuery(this).css("display", "none");
		jQuery(this).parent().siblings(".openInfo").css("display", "block");
		jQuery(this).parent().css({
			opacity: "0",
			bottom: "-200px"
		});
	});
	
	jQuery(".slick-main").slick({
		lazyLoad: 'ondemand',
		slidesToShow: 5,
		autoplay: false,
		arrows: true,
		responsive: [
		{
		  breakpoint: 1400,
		  settings: {
			slidesToShow: 4
		  }
		},
		{
		  breakpoint: 1025,
		  settings: {
			slidesToShow: 3
		  }
		},
		{
		  breakpoint: 769,
		  settings: {
			slidesToShow: 2
		  }
		},
		{
		  breakpoint: 480,
		  settings: {
			slidesToShow: 1
		  }
		}
	  ]
	});
	
	
}
