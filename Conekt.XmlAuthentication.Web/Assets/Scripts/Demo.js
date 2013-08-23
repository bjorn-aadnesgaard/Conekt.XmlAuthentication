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
			var target = $('.readme');
			target.html('<div style=\"text-align: center; padding-bottom: 20px;\"><img src=\"/assets/styles/images/loading.gif\" /></div>');

			$.ajax({
				url: 'https://api.github.com/repos/bjorn-aadnesgaard/conekt.xmlauthentication/readme',
				dataType: 'json',
				success: function (data) {
					var md = $.base64.decode(data['content'].replace(/\s/g, ''))

					var converter = new Markdown.Converter();
					md = converter.makeHtml(md);

					target.html(md);

					$('pre code').each(function (i, e) { hljs.highlightBlock(e) });
				}
			});

		});
	}
}