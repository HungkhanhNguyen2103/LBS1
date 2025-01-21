(function($) {

	"use strict";

	var fullHeight = function() {
		//$(window).height()
		let height = $(window).height();
		//console.log(height);
		if (height > 703) {
			$('.js-fullheight').css('height', $(window).height());
		}
		else {
			$('.js-fullheight').css('height', '703px');
		}
		
		$(window).resize(function(){
			let height1 = $(window).height();
			if (height1 > 703) {
				$('.js-fullheight').css('height', $(window).height());
			}
			else {
				$('.js-fullheight').css('height', '703px');
			}
		});
		//$(window).height()
	};
	fullHeight();

	$(".toggle-password").click(function() {

	  $(this).toggleClass("fa-eye fa-eye-slash");
	  var input = $($(this).attr("toggle"));
	  if (input.attr("type") == "password") {
	    input.attr("type", "text");
	  } else {
	    input.attr("type", "password");
	  }
	});

})(jQuery);
