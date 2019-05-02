
/* belge yüklendikten sonra ready metodu çalıştırılacaktır. Çalıma için zorunlu*/
$(document).ready(function(e) {
    
	/*özellikleri eklerken her özellik arasında ,(virgül) olduğunu unutmayın.*/
	$("#panel").accordion({
			icons: { "header": "ui-icon-pin-w", "activeHeader": "ui-icon-pin-s" },
			event: "mouseover",
			active:1,
			animate:500,
			collapsible: true
			});
	
});