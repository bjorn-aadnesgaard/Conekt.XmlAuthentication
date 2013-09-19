$(document).ready(function () {
	xmldemo.load();

	//Check to see if the hash has changed and load new content
	$(window).bind('hashchange', function (e) {
		xmldemo.load();
	});
});

var xmldemo = {
	load: function () {

		//Check for google crawler escape fragment
		var hasFragment = window.location.href.indexOf('?_escaped_fragment_=/') > 0;
		
		//Check for hashbang
		var hasHashbang = window.location.href.indexOf('#!/') > 0;

		if (hasFragment) {
			var qs = xmlauth.parameters();
			xmlauth.load(qs['_escaped_fragment_'].substr(1));

		} else if (hasHashbang) {

			var hash = window.location.hash.replace('#!/', '');
			if (hash != undefined && hash != '')
				xmlauth.load(hash);
			else
				xmldemo.start();

		} else {
			xmldemo.start();
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