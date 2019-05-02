
/* belge yüklendikten sonra ready metodu çalıştırılacaktır. Çalıma için zorunlu*/
$(document).ready(function(e) {
    
	$(".liste .tasi").draggable({
	
		/*taşıma işlemi yapıldıktan sonra nesneyi eski yerine getirir.*/
		revert:true,
	});
		
	$(".sepet").droppable({
		
		drop:function(event,ui){
			
			/*fonksiyon ile gelen ui.draggable elementi taşınan nesneyi verir*/
			var nesne =ui.draggable;//taşınan nesneyi seçer.
			var kopya=nesne.clone();//taşınan nesnenin kopyasını oluşturur.
			kopya.prepend("<p class='kaldir'>KAPAT</p>");//kopya nesnenin içine p etiketi ekler. (prepend etiket başına ekle)
			kopya.attr('style','');//kopya nesnenin içindeki style etiketinde bulunan stil kodlarını siler.
			
			/*yukarıdaki 4 satırlık kodu tek satırda yazmak için aşağıdaki kod kullanılabilir.*/
			//var kopya= ui.draggable.clone().prepend("<p>KAPAT</p>");
			
			
			/*DİKKAT: kopya nesne içindeki kaldır yazısına tıkladğımızda kaldırma işlemini yapması için tanımladık.*/
			kopya.find('.kaldir').click(function(){
				console.log(kopya.html());
				kopya.closest('.tasi').remove();
			});
			
			
			$(this).append(kopya);//sepet nesnesinin içine kopya nesnesini ekler.
		}
		
	});
	
	/*kaldır yazısına tıkladığımızda kaldırır.
	DİKKAT:kopya olarak oluşturulan nesneler jquery kütüphanesine sonradan eklendiği için bu metod kopyalamalar içinde çalışmayacaktır. aynı metodu kopyalama yaptığımız bölümde de kullanmamız gerekir.
	*/
	$(".sepet .kaldir").on('click',function(){
			$(this).closest('.tasi').remove();
	});
});
