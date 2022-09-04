// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
$(document).ready(function () {
    'use strict';
    $(".navbar").addClass("nav-height");
    shrinkNavbarOnScroll();
    scrollToUp();
    getScreenWidthAndHeight();
    getViewPortWidthAndHeight();

    // jQuery to shrink the navbar on scroll
    function shrinkNavbarOnScroll() {
        $(window).scroll(function () {
            if ($(".navbar").offset().top > 60) {


                $("nav").removeClass("nav-height");
                $("nav").addClass("nav-height-shrink");


                $("nav .container > a").removeClass("navbar-brand");
                $("nav .container > a").addClass("navbar-brand-shrink");

                $("nav li > a").removeClass("nav-link");
                $("nav li > a").addClass("nav-link-shrink");

            } else {

                $("nav").addClass("nav-height");
                $("nav").removeClass("nav-height-shrink");

                $("nav .container > a").addClass("navbar-brand");
                $("nav .container > a").removeClass("navbar-brand-shrink");

                $("nav li > a").addClass("nav-link");
                $("nav li > a").removeClass("nav-link-shrink");

            }
        });

    }

    //Show screen width & height for development stage
    function getScreenWidthAndHeight() {
        $('.screen-width').html($(window).width());
        $('.screen-height').html($(window).height());

        $(window).resize(function () {
            var viewportWidth = $(window).width();
            var viewportHeight = $(window).height();
            $('.screen-width').html(viewportWidth);
            $('.screen-height').html(viewportHeight);
        });
    }

    function getViewPortWidthAndHeight() {
        $('.viewport-width').html(viewportSize.getWidth());
        $('.viewport-height').html(viewportSize.getHeight());

        $(window).resize(function () {
            var viewportWidth = viewportSize.getWidth();
            var viewportHeight = viewportSize.getHeight();
            $('.viewport-width').html(viewportWidth);
            $('.viewport-height').html(viewportHeight);
        });
    }

    function scrollToUp() {
        $(window).scroll(function () {
            if ($(this).scrollTop() > 80) {
                $('#back-to-top').fadeIn();
                //   $('.scroll-to-top').fadeIn();
            } else {
                $('#back-to-top').fadeOut();
                //  $('.scroll-to-top').fadeOut();
            }
        });
        // scroll body to 0px on click
        $('#back-to-top').click(function () {
            $('body,html').animate({
                scrollTop: 0
            }, 400);
            return false;
        });

        $('.scroll-to-top').click(function () {
            $('body,html').animate({
                scrollTop: 0
            }, 400);
            return false;
        });

    }

}());
(function ($) {
    $('.dropdown-menu a.dropdown-toggle').on('click', function (e) {
        if (!$(this).next().hasClass('show')) {
            $(this).parents('.dropdown-menu').first().find('.show').removeClass("show");
        }
        var $subMenu = $(this).next(".dropdown-menu");
        $subMenu.toggleClass('show');

        $(this).parents('li.nav-item.dropdown.show').on('hidden.bs.dropdown', function (e) {
            $('.dropdown-submenu .show').removeClass("show");
        });

        return false;
    });
})(jQuery)