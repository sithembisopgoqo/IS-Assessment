function InitializeProductSlider() {
    jQuery('.product-slider').slick({
        slidesToShow: 1,
        slidesToScroll: 1,
        arrows: true,
        infinite: true,
        speed: 1000,
        fade: true,
        asNavFor: '.product-slider-nav'
    });
    jQuery('.product-slider-nav').slick({
        slidesToShow: 3,
        slidesToScroll: 1,
        asNavFor: '.product-slider',
        dots: false,
        infinite: true,
        arrows: false,
        speed: 1000,
        centerMode: true,
        focusOnSelect: true
    });

    
}