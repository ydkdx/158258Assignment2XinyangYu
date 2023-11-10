$(document).ready(function () {

    // Sticky header
    $(window).scroll(function () {
        if ($(this).scrollTop() > 50) {
            $('header.sticky-top').addClass('shadow');
        } else {
            $('header.sticky-top').removeClass('shadow');
        }
    });

    // Search bar functionality (Example of a basic search function)
    $('.search-bar .btn').click(function () {
        var searchTerm = $('.search-bar input[type="text"]').val().trim();
        // Perform search using searchTerm
        console.log('Searching for:', searchTerm);
        // You would typically make an AJAX call to your server here
    });

    // Initialize Bootstrap Carousel for testimonials
    $('.testimonials .carousel').carousel({
        interval: 3000
    });

});