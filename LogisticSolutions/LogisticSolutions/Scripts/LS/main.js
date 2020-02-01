$(document).ready(function () {
    $('.menu > li > a').click(function () {
        $('.menu li').removeClass('active');
        $(this).closest('li').addClass('active');
        var checkElement = $(this).next();
        if ((checkElement.is('ul')) && (checkElement.is(':visible'))) {
            $(this).closest('li').removeClass('active');
            checkElement.slideUp('normal');
        }
        if ((checkElement.is('ul')) && (!checkElement.is(':visible'))) {
            $('.menu ul:visible').slideUp('normal');
            checkElement.slideDown('normal');
        }
        if ($(this).closest('li').find('ul').children().length == 0) {
            return true;
        } else {
            return false;
        }
    });


    $(".MobileMenuBtn").click(function () {
        $(".MobileSideBar").toggleClass("MobileSideBaractive")
    });


    $('#example').DataTable({
        "scrollX": true,
        "bSort": false,
        "bLengthChange": false,
        //dom: 'Bfrtip',
        "bFilter": false,
        //buttons: [
        //    'copy', 'csv', 'excel', 'pdf', 'print'
        //]
    });

});
