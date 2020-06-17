var viewcontroller = function () {
    this.init = function (epi) {
        if (epi !== 0) {
            $(".btnEpi").each(function (index) {
                if ($(this).data("id") == epi) {
                    $('#btnClick').html($.parseHTML(decodeURI($(this).data('src'))));
                    $(".btnEpi").removeClass("active");
                    $(this).addClass("active");
                }
            });

        }
        register();
    }
    function register() {
        $("body").on("click", ".btnEpi", function () {
            // $('.btnEpi').on('click', function () {
            //alert($(this).data('src'));
            //$('#btnClick').html($(this).data('src'));
            $(".btnEpi").removeClass("active");
            $(this).addClass("active");
            $('#btnClick').html($.parseHTML(decodeURI($(this).data('src'))));
        });
        
    }
   
}