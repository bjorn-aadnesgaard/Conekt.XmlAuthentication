$(document).ready(function () {
	xmldemo.load();

	$(window).bind('hashchange', function (e) {
		xmldemo.load();
	});
});

var xmldemo = {
	load: function () {
		
		//Check for hashbang
		var hash = window.location.hash.replace("#!/", "");
		if(hash == undefined || hash == "") {
			xmldemo.start();
		} else {
			xmlauth.load(hash);
		}
	},
	start: function () {
		xmlauth.load('default', function () {
			$('.readme').html('<div style=\"text-align: center; padding-bottom: 20px;\"><img src=\"/assets/styles/images/loading.gif\" /></div>').load('http://markdown.io/_rawhtml/https://raw.github.com/bjorn-aadnesgaard/Conekt.XmlAuthentication/master/README.md', function () { });
		});
	}
}