 $('.big_slaid').slick({
  slidesToShow: 1,
  slidesToScroll: 1,
  arrows: false,
  fade: true,
  asNavFor: '.smol_slaid'
});
$('.smol_slaid').slick({
  slidesToShow: 4,
  slidesToScroll: 1,
  asNavFor: '.big_slaid',
  dots: false,
  centerMode: false,
  focusOnSelect: true,
  responsive: [
  {
    breakpoint: 1300,
     settings: {
        slidesToShow: 3
     }
  }
  ]
});



 $('.slaid').slick({
  slidesToShow: 1,
  slidesToScroll: 1,
  arrows: false,
  fade: true,
  swipe: false,
  asNavFor: '.flex_wh'
});
$('.flex_wh').slick({
  slidesToShow: 4,
  slidesToScroll: 1,
  asNavFor: '.slaid',
  dots: false,
  centerMode: false,
  focusOnSelect: true
});


$('.nmg_slaid').slick({
  slidesToShow: 1,
  slidesToScroll: 1,
});

$('.sts_slaid').slick({
  slidesToShow: 1,
  slidesToScroll: 1,
});

$('.trk_slaid').slick({
  slidesToShow: 1,
  slidesToScroll: 1,
});

$('.ren_slaid').slick({
  slidesToShow: 1,
  slidesToScroll: 1,
});

$('.med_slaid').slick({
  slidesToShow: 1,
  slidesToScroll: 1,
});
$('.mor_slaid').slick({
  slidesToShow: 1,
  slidesToScroll: 1,
});
$('.tex_slaid').slick({
  slidesToShow: 1,
  slidesToScroll: 1,
});
 

$(document).ready(function() {
  $("a.scrollto").click(function() {
    var elementClick = $(this).attr("href")
    var destination = $(elementClick).offset().top;
    jQuery("html:not(:animated),body:not(:animated)").animate({
      scrollTop: destination
    }, 800);

   

    return false;

  });
});


$(".bask").click(function() {
	$(".flipper").css('transform','rotateY(180deg)');
})

$(".baskd").click(function() {
	$(".flipper").css('transform','rotateY(0deg)');
})

/*$(".menu_of").click(function() {
	$.removeCookie('name');
	document.location.href='/nmg';
})*/


$(".slhh1").click(function() {
	$("#vid1").trigger('play');
	$(".flipper1").css('transform','rotateY(0deg)');
})

$(".slhh2").click(function() {
	$("#vid2").trigger('play');
	$(".flipper2").css('transform','rotateY(0deg)');
})

$(".slhh3").click(function() {
	$("#vid3").trigger('play');
	$(".flipper3").css('transform','rotateY(0deg)');
})

$(".slhh4").click(function() {
	$("#vid4").trigger('play');
	$(".flipper4").css('transform','rotateY(0deg)');
})

$(".slhh5").click(function() {
	$("#vid5").trigger('play');
	$(".flipper5").css('transform','rotateY(0deg)');
})

$(".slhh6").click(function() {
	$("#vid6").trigger('play');
	$(".flipper6").css('transform','rotateY(0deg)');
})

$(".slhh7").click(function() {
	$("#vid7").trigger('play');
	$(".flipper7").css('transform','rotateY(0deg)');
})

$(".slhh8").click(function() {
	$("#vid8").trigger('play');
	$(".flipper8").css('transform','rotateY(0deg)');
})

$(".slhh9").click(function() {
	$("#vid9").trigger('play');
	$(".flipper9").css('transform','rotateY(0deg)');
})

$(".slhh11").click(function() {
	$("#vid11").trigger('play');
	$(".flipper11").css('transform','rotateY(0deg)');
})


$(".fff1").click(function() {
	$(".flipper1").css('transform','rotateY(180deg)');
})

$(".fff2").click(function() {
	$(".flipper2").css('transform','rotateY(180deg)');
})

$(".fff3").click(function() {
	$(".flipper3").css('transform','rotateY(180deg)');
})

$(".fff4").click(function() {
	$(".flipper4").css('transform','rotateY(180deg)');
})

$(".fff5").click(function() {
	$(".flipper5").css('transform','rotateY(180deg)');
})

$(".fff6").click(function() {
	$(".flipper6").css('transform','rotateY(180deg)');
})

$(".fff7").click(function() {
	$(".flipper7").css('transform','rotateY(180deg)');
})

$(".fff8").click(function() {
	$(".flipper8").css('transform','rotateY(180deg)');
})

$(".fff9").click(function() {
	$(".flipper9").css('transform','rotateY(180deg)');
})

$(".fff11").click(function() {
	$(".flipper11").css('transform','rotateY(180deg)');
})

$(".baskd1").click(function() {
	$(".flipper1").css('transform','rotateY(0deg)');
})

$(".baskd2").click(function() {
	$(".flipper2").css('transform','rotateY(0deg)');
})

$(".baskd3").click(function() {
	$(".flipper3").css('transform','rotateY(0deg)');
})

$(".baskd4").click(function() {
	$(".flipper4").css('transform','rotateY(0deg)');
})

$(".baskd5").click(function() {
	$(".flipper5").css('transform','rotateY(0deg)');
})

$(".baskd6").click(function() {
	$(".flipper6").css('transform','rotateY(0deg)');
})
$(".baskd7").click(function() {
	$(".flipper7").css('transform','rotateY(0deg)');
})
$(".baskd8").click(function() {
	$(".flipper8").css('transform','rotateY(0deg)');
})
$(".baskd9").click(function() {
	$(".flipper9").css('transform','rotateY(0deg)');
})
$(".baskd11").click(function() {
	$(".flipper11").css('transform','rotateY(0deg)');
})

$(".bask1").click(function() {
	$(".flipper1").css('transform','rotateY(180deg)');
})

$(".bask2").click(function() {
	$(".flipper2").css('transform','rotateY(180deg)');
})


$(".bask3").click(function() {
	$(".flipper3").css('transform','rotateY(180deg)');
})


$(".bask4").click(function() {
	$(".flipper4").css('transform','rotateY(180deg)');
})


$(".bask5").click(function() {
	$(".flipper5").css('transform','rotateY(180deg)');
})
$(".bask6").click(function() {
	$(".flipper6").css('transform','rotateY(180deg)');
})
$(".bask7").click(function() {
	$(".flipper7").css('transform','rotateY(180deg)');
})
$(".bask8").click(function() {
	$(".flipper8").css('transform','rotateY(180deg)');
})
$(".bask9").click(function() {
	$(".flipper9").css('transform','rotateY(180deg)');
})
$(".bask11").click(function() {
	$(".flipper11").css('transform','rotateY(180deg)');
})




jQuery('.lightzoom').lightzoom({speed: 400, viewTitle: false, imgPadding: 2});


var video = document.getElementById('vid');

   video.addEventListener('ended',function(){
    $(".flipper").css('transform','rotateY(180deg)');
     $(".ofset_cul").css('height','auto');
})

var video1 = document.getElementById('vid1');

   video1.addEventListener('ended',function(){
    $(".flipper1").css('transform','rotateY(180deg)');
})

   var video2 = document.getElementById('vid2');

   video2.addEventListener('ended',function(){
    $(".flipper2").css('transform','rotateY(180deg)');
})

   var video3 = document.getElementById('vid3');

   video3.addEventListener('ended',function(){
    $(".flipper3").css('transform','rotateY(180deg)');
})

   var video4 = document.getElementById('vid4');

   video4.addEventListener('ended',function(){
    $(".flipper4").css('transform','rotateY(180deg)');
})

   var video5 = document.getElementById('vid5');

   video5.addEventListener('ended',function(){
    $(".flipper5").css('transform','rotateY(180deg)');
})



$(window).scroll(function(){
      if ($(this).scrollTop() > 600) {
          $('.header').addClass('fixed');
      } else {
          $('.header').removeClass('fixed');
      }
});


$(function() {
    var blockTop = $('#rol').offset().top;
    var CountUpFlag = 0;
    var $window = $(window);
    $window.on('load scroll', function() {
        var top = $window.scrollTop();
        var height = $window.height();
        if (top + height >= blockTop && CountUpFlag == 0) {
            CountUp();
            CountUpFlag = 1;
        }
    });
    function CountUp() {
        $('.menu').css('color','#fff');
         $('.menu').css('cursor','pointer');
         $('.menu1').attr('href', '#rol');
         $('.menu2').attr('href', '#bg_white');
         $('.menu3').attr('href', '#cont');
    }

    
});

     $(function () {
              $("#pet-select").selectize();
            });

$(".btn_expo").click(function() {

  $('#vidtop').css('display','block');
   $(".ofset_cul").css('height','auto');

  $('html, body').animate({
        scrollTop: $("#vidtop").offset().top  
    }, 500); 

    let value = $("#pet-select").val();

    if(value == 'НМГ'){
      $('.slaid_contact').css('display','none');

      $('.nmg_slaid').css('display','block');
    }

    if( (value == 'СТС') || (value == 'Домашний') || (value == 'СТС Love') || (value == 'СТС Kids') || (value == 'ЧЕ!') || (value == '31')){ 
      $('.slaid_contact').css('display','none');

      $('.sts_slaid').css('display','block');
    }

    if(value == 'ТРК'){
      $('.slaid_contact').css('display','none');

      $('.trk_slaid').css('display','block');
    }

    if((value == 'Ren TV') || (value == '78 канал') || (value == 'Известия') || (value == 'Cпорт-Экспресс') || (value == 'Деловой Петербург')){
      $('.slaid_contact').css('display','none');

      $('.ren_slaid').css('display','block');
    }

    if((value == 'Медиа Телеком') || (value == 'Витрина ТВ') || (value == 'Индустрия') || (value == 'Art Picture Distribution')){
      $('.slaid_contact').css('display','none');

      $('.med_slaid').css('display','block');
    }

    if((value == 'More.tv') || (value == 'Эверест')){
      $('.slaid_contact').css('display','none');

      $('.mor_slaid').css('display','block');
    }

     if((value == 'НМГ ТЕХ (аналитический Хаб)') || (value == 'Медиа Бизнес Солюшнс')){
      $('.slaid_contact').css('display','none');

      $('.tex_slaid').css('display','block');
    }
});


$('.open-popup-link').magnificPopup({
  type:'inline',
  midClick: true // Allow opening popup on middle mouse click. Always set it to true if you don't provide alternative source in href.
});




$('.per').click(function() {
   var dt = "." + $(this).data('per');
   $(this).parent().css( "display", "none" );
   $(dt).css( "display", "block" );
  });

$('.slaider_cort1').click(function() {
  $('#slaid1').trigger('click');
})

$('.slaider_cort2').click(function() {
  $('#slaid2').trigger('click');
})

$('.slaider_cort3').click(function() {
  $('#slaid3').trigger('click');
})

$('.slaider_cort4').click(function() {
  $('#slaid4').trigger('click');
})

$('.slaider_cort5').click(function() {
  $('#slaid5').trigger('click');
})

$('.slaider_cort6').click(function() {
  $('#slaid6').trigger('click');
})

$('.slaider_cort7').click(function() {
  $('#slaid7').trigger('click');
})

$('.slaider_cort8').click(function() {
  $('#slaid8').trigger('click');
})

$('.slaider_cort9').click(function() {
  $('#slaid9').trigger('click');
})

$('.slaider_cort10').click(function() {
  $('#slaid10').trigger('click');
})