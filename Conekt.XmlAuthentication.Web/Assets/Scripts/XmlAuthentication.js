$(function () {
	//Ref http://stackoverflow.com/a/13550556/612113
	//Adds re-usable hide function to boostrap toolset
	$('.login [data-hide]').on('click', function () {
		xmlauth.alert('');
	});
});

var xmlauth = {
	login: function () {
		$('.login .btn').button('loading');
		xmlauth.alert('reset');
		$.ajax({
			type: 'POST',
			url: '/App_WebServices/Xml/Authentication.asmx/Login',
			data: '{ "email": "' + $('#email').val() + '", "password" : "' + $('#password').val() + '" }',
			contentType: 'application/json; charset=utf-8',
			dataType: 'json'
		}).done(function (data) {

			//Set the alert content
			var content = $('.login .alert div');
			content.html(data.d.Message)

			switch (data.d.Status) {
				case 0:
					xmlauth.alert('alert-danger');
					xmlauth.formClear();
					break;
				case 1:
					xmlauth.alert('alert-success');
					xmlauth.formClear();
					$('.anonymous').hide();
					$('.authenticated').show();
					break;
			}
		}).fail(function (jqXHR, status, error) {
			var response = $.parseJSON(jqXHR.responseText);
			xmlauth.alert('alert-danger');

			//Set the alert content
			var content = $('.login .alert div');
			content.html(response.Message);

		}).always(function () {
			$('.login .btn').button('reset');
		});
	},
	logout: function () {
		xmlauth.alert('reset');
		$.ajax({
			type: 'POST',
			url: '/App_WebServices/Xml/Authentication.asmx/Logout',
			data: '{}',
			contentType: 'application/json; charset=utf-8',
			dataType: 'json'
		}).done(function (data) {
			xmlauth.alert('alert-success');

			//Set the alert content
			var content = $('.login .alert div');
			content.html('You are now <strong>logged out</strong>.');

			//Show and hide content
			$('.anonymous').show();
			$('.authenticated').hide();
		}).fail(function (jqXHR, status, error) {
			var response = $.parseJSON(jqXHR.responseText);
			xmlauth.alert('alert-danger');

			//Set the alert content
			var content = $('.login .alert div');
			content.html(response.Message);
		});
	},
	show: function (location) {
		xmlauth.alert('reset');
		
		//Check session authentication
		var isAuthenticated = false
		$.ajax({
			type: 'GET',
			url: '/App_WebServices/Xml/Authentication.asmx/IsAuthenticated',
			data: '{}',
			contentType: 'application/json; charset=utf-8',
			dataType: 'json',
			async: false
		}).done(function (data) {
			isAuthenticated = data.d;
		});

		var anon = $('.login .anonymous');
		var auth = $('.login .authenticated');

		anon.hide();
		auth.hide();

		if (isAuthenticated) {
			auth.show();
			return;
		}

		switch (location) {
			case "anon":
				anon.show();
				break;

			case "auth":
				auth.show();
				break;

			default:
				anon.show();
				break;
		}

	},
	alert: function (style) {
		var target = $('.login .alert');

		if (style != undefined && style != 'reset') {
			if (target.is(':visible')) {
				//If the alert is visible, we hide it
				target.hide().removeClass().addClass('alert');
			} else {
				//If the alert is hidden, we show it
				target.removeClass().addClass('alert ' + style).show();
			}
		} else {
			//If there are no styles to add, reset the alert
			target.hide().removeClass().addClass('alert');
		}

		//TODO: Add animation support
		////If the style is not defined or is not 'reset', we initiate animations for the alert element.
		//if (style != undefined && style != 'reset') {
		//	if (target.is(':visible')) {

		//		//If the opacity is 0, but the alert is visible, do not slide up, instead set opacity to 1, we re-apply classes and fade in without a slide to prevent akward sliding.
		//		if (target.css('opacity') == 0) {
		//			target.addClass('alert ' + style).animate({ opacity: '1' }, 200);
		//		} else {
		//			//If the alert is visible, we fade out and slideup
		//			target.animate({ opacity: '0' }, 200, function () {
		//				target.slideUp(200, function () {
		//					target.removeClass().addClass('alert');
		//				});
		//			});
		//		}
		//	} else {
		//		//If the alert is hidden, we set the opacity to 0, add the apropriate classes, slide the element down and fade in.
		//		target.css({ 'opacity': '0' }).removeClass().addClass('alert ' + style).slideDown(200, function () {
		//			target.animate({ opacity: '1' }, 200);
		//		});
		//	}
		//} else {
		//	if (target.is(':visible')) {

		//		//If the alert is visible, do not slide up. We do this to prevent akward sliding.
		//		target.animate({ opacity: '0' }, 200, function () {
		//			target.removeClass().addClass('alert');
		//		});
		//	} else {

		//		//If the style is set to 'reset', we set the opacity to 0, slide up and reset the applied classes.
		//		target.animate({ opacity: '0' }, 200, function () {
		//			target.slideUp(200, function () {
		//				target.removeClass().addClass('alert');
		//			});
		//		})
		//	}
		//}
	},
	formClear: function () {
		$('.login input[type="password"]').val('');
		$('.login .reset .email').val('');
	},
	passwordReset: function () {
		$('.login .reset .btn').button('loading');
		xmlauth.alert('reset');
		$.ajax({
			type: 'POST',
			url: '/App_WebServices/Xml/Authentication.asmx/PasswordReset',
			data: '{ "email": "' + $('.login .reset .email').val() + '" }',
			contentType: 'application/json; charset=utf-8',
			dataType: 'json'
		}).done(function (data) {

			//Set the alert content
			var content = $('.login .alert div');
			content.html(data.d.Message)

			switch (data.d.Status) {
				case 0:
					xmlauth.alert('alert-danger');
					break;
				case 1:
					xmlauth.alert('alert-success');
					break;
			}
		}).fail(function (jqXHR, status, error) {
			var response = $.parseJSON(jqXHR.responseText);
			xmlauth.alert('alert-danger');

			//Set the alert content
			var content = $('.login .alert div');
			content.html(response.Message);

		}).always(function () {
			$('.login .reset .btn').button('reset');
			formClear();
		});
	},
	passwordChange: function (email, token) {
		$('.login .reset .btn').button('loading');
		xmlauth.alert('reset');
		$.ajax({
			type: 'POST',
			url: '/App_WebServices/Xml/Authentication.asmx/PasswordChange',
			data: '{ "email": "' + email + '", "token": "' + (token != undefined ? token : null) + '", "oldPassword": "' + $('.login .reset #oldPassword').val() + '", "newPassword": "' + $('.login .reset #newPassword').val() + '" }',
			contentType: 'application/json; charset=utf-8',
			dataType: 'json'
		}).done(function (data) {

			//Set the alert content
			var content = $('.login .alert div');
			content.html(data.d.Message)

			switch (data.d.Status) {
				case 0:
					xmlauth.alert('alert-danger');
					break;
				case 1:
					xmlauth.alert('alert-success');
					$('.login .reset .content').hide();
					$('.login .reset .success').show();
					break;
			}
		}).fail(function (jqXHR, status, error) {
			var response = $.parseJSON(jqXHR.responseText);
			xmlauth.alert('alert-danger');

			//Set the alert content
			var content = $('.login .alert div');
			content.html(response.Message);

		}).always(function () {
			$('.login .reset .btn').button('reset');
			formClear();
		});
	},
	accountCreate: function () {
		$('.login .create .btn').button('loading');
		xmlauth.alert('reset');
		$.ajax({
			type: 'POST',
			url: '/App_WebServices/Xml/Authentication.asmx/AccountCreate',
			data: '{ "email": "' + $('.login .create #email').val() + '", "password": "' + $('.login .create #password').val() + '" }',
			contentType: 'application/json; charset=utf-8',
			dataType: 'json'
		}).done(function (data) {

			//Set the alert content
			var content = $('.login .alert div');
			content.html(data.d.Message)

			switch (data.d.Status) {
				case 0:
					xmlauth.alert('alert-danger');
					break;
				case 1:
					xmlauth.alert('alert-success');
					$('.login .create .content').hide();
					$('.login .create .success').show();
					break;
			}
		}).fail(function (jqXHR, status, error) {
			var response = $.parseJSON(jqXHR.responseText);
			xmlauth.alert('alert-danger');

			//Set the alert content
			var content = $('.login .alert div');
			content.html(response.Message);

		}).always(function () {
			$('.login .create .btn').button('reset');
		});
	},
	load: function (content, callback) {
		var target = $('#page-content');
		target.html('<div style=\"text-align: center; padding: 20px 0px;\"><img src=\"/assets/styles/images/loading.gif\" /></div>');
		$.ajax({
			type: 'POST',
			url: '/App_WebServices/Xml/Authentication.asmx/Load',
			data: '{ "content": "' + content + '" }',
			contentType: 'application/json; charset=utf-8',
			dataType: 'json'
		}).done(function (data) {
			target.html(data.d);
		}).fail(function (jqXHR, status, error) {
			var response = $.parseJSON(jqXHR.responseText);
			alert(response.Message);
		}).always(function () {
			if (typeof callback == 'function') {
				callback.call(this);
			}
		});
	}
}