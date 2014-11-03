jQuery(document).ready(function($) {
	a=parseFloat(400);// valor inccial para el background 1
	b=parseFloat(0);// valor inccial para el background 1
	c=parseFloat(400);// valor inccial para el background 2
	d=parseFloat(0);// valor inccial para el background 2
	var scrollTop = $(window).scrollTop();			
	var scroll_actually= new Array();// identifica los valoares del background X y  Y
		
	$(window).scroll(function(){//this is not the cleanest way to do this, I'm just keeping it short.
		if(scrollTop>$(this).scrollTop()) // desplazamiento hacia arriba
		{
			if (getScrollTop()<=1600 && getScrollTop()>=0)// identyifica cuando la posicion del background_1 esta en scroll
			{
					a=a+35;// posicion del background1 decrementa en 35 pixeles
					b=b+10;// posicion de background1 decrementa en 15 pizeles 
					$('.img_1').css('backgroundPosition', '50% '+a+'px');
					$('.bk_0').css('backgroundPosition', '0 '+b+'px');		
			}
			if (getScrollTop()>=2050 && getScrollTop()<=3650)
			{
					c=c+35;// posicion del background2 decrementa en 35 pixeles
					d=d+10;// posicion del background2 decrementa en 35 pixeles
					$('.img_2').css('backgroundPosition', '50% '+c+'px');
					$('.bk_1').css('backgroundPosition', '0 '+d+'px');				
			}
		}
		else
		{// desplazamiento hacia  abajo
			if (getScrollTop()>=0 && getScrollTop()<=1600)			
			{
				  a=a-35;// posicion del background1 incrementa en 35 pixeles
				  b=b-10;// posicion del background1 incrementa en 35 pixeles
				  $('.img_1').css('backgroundPosition', '50% '+a+'px');
				  $('.bk_0').css('backgroundPosition', '0 '+b+'px');				
		    }
				if (getScrollTop()>=2050 && getScrollTop()<=3650)			
			{
				  c=c-35;// posicion del background1 incrementa en 35 pixeles
				  d=d-10;// posicion del background1 incrementa en 35 pixeles
				  $('.img_2').css('backgroundPosition', '50% '+c+'px');
				  $('.bk_1').css('backgroundPosition', '0 '+d+'px');				
		    }
	 	}
		if (getScrollTop()==0)// ajusta la posiciones y las reseatea en cero cuando hace scroll havciaa arriba
		{
			a=parseFloat(400);
			b=parseFloat(0);
			c=parseFloat(400);
			d=parseFloat(0);
			$('.bk_0').css('backgroundPosition', '0 0');	
			$('.bk_1').css('backgroundPosition', '0 0');				
   		    $('.img_2').css('backgroundPosition', '50% '+400+'px');			
   		    $('.img_1').css('backgroundPosition', '50% '+400+'px');						
		}
	  scrollTop = $(this).scrollTop();		
	});
});
function getScrollTop(){ ///  verifica el calculo total en pixeles de toda la pagina

    if(typeof pageYOffset!= 'undefined'){
        //most browsers
        return pageYOffset;
    }
    else{
        var B= document.body; //IE 'quirks'
        var D= document.documentElement; //IE with doctype
        D= (D.clientHeight)? D: B;
        return D.scrollTop;
    }
}
