jQuery(function ($) {
	
	$.validator.addMethod('number', function (value, element) {

		return this.optional(element) || /^[0-9]{1,}$/.test(value);
	});
	$.validator.methods.range = function (value, element, param) {

		return this.optional(element) || (Number(value.replace(',', '.'))>= Number(param[0]) && Number(value.replace(',', '.')) <= Number(param[1]));
	}
})