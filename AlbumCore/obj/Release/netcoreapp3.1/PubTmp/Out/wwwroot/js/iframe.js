//$(document).ready(function () {
//    $("[data-fancybox]").fancybox({
//        afterClose: function () {
//            history.go(0);
//        }
//    });
//});


$(document).ready(function () {
	$(".fancybox-thumb").fancybox({
		prevEffect: 'none',
		nextEffect: 'none',
		helpers: {
			title: {
				type: 'outside'
			},
			thumbs: {
				width: 50,
				height: 50
			}
		}
	});
});