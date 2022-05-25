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
  swipe: false, 
  centerMode: false,
  focusOnSelect: true
});

 $('.slaid_mits').slick({
  slidesToShow: 1,
  slidesToScroll: 1,
  arrows: false,
  fade: true,
  swipe: false,
  asNavFor: '.flex_wh2'
});
$('.flex_wh2').slick({
  slidesToShow: 4,
  slidesToScroll: 1,
  asNavFor: '.slaid_mits',
  dots: false,
  swipe: false,
  centerMode: false,
  focusOnSelect: true
});


$('.nmg_slaid').slick({
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


 var iframe = $('#vid');
 var player = new Vimeo.Player(iframe); 
 var iframe1 = $('#vid1');
 var player1 = new Vimeo.Player(iframe1);
 var iframe2 = $('#vid2');
 var player2 = new Vimeo.Player(iframe2);
  var iframe3 = $('#vid3');
 var player3 = new Vimeo.Player(iframe3);
 var iframe4 = $('#vid4');
 var player4 = new Vimeo.Player(iframe4);
 var iframe5 = $('#vid5');
 var player5 = new Vimeo.Player(iframe5);
 var iframe6 = $('#vid6');
 var player6 = new Vimeo.Player(iframe6);
 var iframe7 = $('#vid7');
 var player7 = new Vimeo.Player(iframe7);
 var iframe8 = $('#vid8');
 var player8 = new Vimeo.Player(iframe8);
 var iframe9 = $('#vid9');
 var player9 = new Vimeo.Player(iframe9);
  var iframe10 = $('#vid11');
 var player10 = new Vimeo.Player(iframe10);



$(".bask").click(function() {
  $(".flipper").css('transform','rotateY(180deg)');
   player.pause();
})

$(".baskd").click(function() {
  $(".flipper").css('transform','rotateY(0deg)');
})


var onPlay = function(data) {
  $(".flipper").css('transform','rotateY(180deg)');
};

player.on('ended', onPlay);

var onPlay1 = function(data) {
  $(".flipper1").css('transform','rotateY(180deg)');
};

player1.on('ended', onPlay1);

var onPlay2 = function(data) {
  $(".flipper2").css('transform','rotateY(180deg)');
};

player2.on('ended', onPlay2);

var onPlay3 = function(data) {
  $(".flipper3").css('transform','rotateY(180deg)');
};

player3.on('ended', onPlay3);

var onPlay4 = function(data) {
  $(".flipper4").css('transform','rotateY(180deg)');
};

player4.on('ended', onPlay4);

var onPlay5 = function(data) {
  $(".flipper5").css('transform','rotateY(180deg)');
};

player5.on('ended', onPlay5);

var onPlay6 = function(data) {
  $(".flipper6").css('transform','rotateY(180deg)');
};

player6.on('ended', onPlay6);

var onPlay8 = function(data) {
  $(".flipper8").css('transform','rotateY(180deg)');
};

player8.on('ended', onPlay8);

var onPlay7 = function(data) {
  $(".flipper7").css('transform','rotateY(180deg)');
};

player7.on('ended', onPlay7);

var onPlay9 = function(data) {
  $(".flipper9").css('transform','rotateY(180deg)');
};

player9.on('ended', onPlay9);

var onPlay10 = function(data) {
  $(".flipper11").css('transform','rotateY(180deg)');
};

player10.on('ended', onPlay10);

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
  player1.play();
  console.log(123123);
  $(".flipper1").css('transform','rotateY(0deg)');
})

$(".slhh2").click(function() {
  $("#vid2").trigger('play');
  player2.play();
  $(".flipper2").css('transform','rotateY(0deg)');
})

$(".slhh3").click(function() {
  $("#vid3").trigger('play');
  player3.play();
  $(".flipper3").css('transform','rotateY(0deg)');
})

$(".slhh4").click(function() {
  $("#vid4").trigger('play');
  player4.play();
  $(".flipper4").css('transform','rotateY(0deg)');
})

$(".slhh5").click(function() {
  $("#vid5").trigger('play');
  player5.play();
  $(".flipper5").css('transform','rotateY(0deg)');
})

$(".slhh6").click(function() {
  $("#vid6").trigger('play');
  player6.play();
  $(".flipper6").css('transform','rotateY(0deg)');
})

$(".slhh7").click(function() {
  $("#vid7").trigger('play');
  player7.play();
  $(".flipper7").css('transform','rotateY(0deg)');
})

$(".slhh8").click(function() {
  $("#vid8").trigger('play');
  player6.play();
  $(".flipper8").css('transform','rotateY(0deg)');
})

$(".slhh9").click(function() {
  $("#vid9").trigger('play');
  player9.play();
  $(".flipper9").css('transform','rotateY(0deg)');
})

$(".slhh11").click(function() {
  $("#vid11").trigger('play');
  player10.play();
  $(".flipper11").css('transform','rotateY(0deg)');
})


$(".fff1").click(function() {
  $(".flipper1").css('transform','rotateY(180deg)');
  player1.pause();
})

$(".fff2").click(function() {
  $(".flipper2").css('transform','rotateY(180deg)');
   player2.pause();
})

$(".fff3").click(function() {
  $(".flipper3").css('transform','rotateY(180deg)');
   player3.pause();
})

$(".fff4").click(function() {
  $(".flipper4").css('transform','rotateY(180deg)');
   player4.pause();
})

$(".fff5").click(function() {
  $(".flipper5").css('transform','rotateY(180deg)');
   player5.pause();
})

$(".fff6").click(function() {
  $(".flipper6").css('transform','rotateY(180deg)');
   player6.pause();
})

$(".fff7").click(function() {
  $(".flipper7").css('transform','rotateY(180deg)');
   player7.pause();
})

$(".fff8").click(function() {
  $(".flipper8").css('transform','rotateY(180deg)');
   player8.pause();
})

$(".fff9").click(function() {
  $(".flipper9").css('transform','rotateY(180deg)');
   player9.pause();
})

$(".fff11").click(function() {
  $(".flipper11").css('transform','rotateY(180deg)');
   player10.pause();
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
            
            CountUpFlag = 1;
        }
    });
   

    
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

   /* if(value == 'НМГ'){
      $('.slaid_contact').css('display','none');

      $('.nmg_slaid').css('display','block');
    }

    if( (value == 'СТС') || (value == 'Домашний') || (value == 'СТС Love') || (value == 'СТС Kids') || (value == 'ЧЕ!')){ 
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


    if((value == 'More.tv')){
      $('.slaid_contact').css('display','none');

      $('.mor_slaid').css('display','block');
    }

    if( (value == 'Эверест')){
      $('.slaid_contact').css('display','none');

      $('.ever_slaid').css('display','block');
    }


     if((value == 'НМГ ТЕХ (аналитический Хаб)') || (value == 'Медиа Бизнес Солюшнс')){
      $('.slaid_contact').css('display','none');

      $('.tex_slaid').css('display','block');
    }

    if((value == 'Медиа Телеком') ||  (value == 'Art Picture Distribution')){
      $('.slaid_contact').css('display','none');

      $('.art_slaid').css('display','block');
    }


    if( (value == 'Витрина ТВ')){
      $('.slaid_contact').css('display','none');

      $('.med_slaid').css('display','block');
    }




    if(value == 'Известия'){
      $('.nemits2').css("display", "none");
      $('.nemits').css("display", "none");
      $('.mits2').css("display", "block");
      $('.mits').css("display", "block");
    }else{
      $('.mits2').css("display", "none");
      $('.mits').css("display", "none");
      $('.nemits2').css("display", "block");
      $('.nemits').css("display", "block");
    }*/






});


$('.open-popup-link').magnificPopup({
  type:'inline',
  midClick: true // Allow opening popup on middle mouse click. Always set it to true if you don't provide alternative source in href.
});



$('.open-popup-link').click(function() {
     $('.osn').each(function(){
        $(this).css("display", "block");
      });
     $('.ppop').each(function(){
        $(this).css("display", "none");
      });
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