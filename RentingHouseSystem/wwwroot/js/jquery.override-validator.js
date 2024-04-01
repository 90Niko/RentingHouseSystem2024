jQuery(function ($) {
	$.validator.addMethod("phone", function (value, element) {
		return this.optional(element) || /^[0-9]{10}$/.test(value);
	}, "Please enter a valid phone number");

	$.validator.addMethod("password", function (value, element) {
		return this.optional(element) || /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$/.test(value);
	}, "Password must contain at least one number, one uppercase and one lowercase letter, and at least 8 or more characters");

	$.validator.addMethod('number', function (value, element) {

		return this.optional(element) || /^[0-9]{1,}$/.test(value);
	});
	$.validator.methods.range = function (value, element, param) {

		return this.optional(element) || (Number(value.replace(',', '.'))>= Number(param[0]) && Number(value.replace(',', '.')) <= Number(param[1]));
		
	}
})