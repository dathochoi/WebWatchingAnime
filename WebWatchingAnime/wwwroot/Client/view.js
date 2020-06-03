var viewcontroller = function () {
    this.init= function (){
        register();
    }
    function register() {
        $("body").on("click", ".btnEpi", function () {
            // $('.btnEpi').on('click', function () {
            alert($(this).data('src'));
            //$('#btnClick').html($(this).data('src'));
            $('#btnClick').html($.parseHTML(decodeURI($(this).data('src'))));
        });
        //$('#btnClic2').on("load", function () {
        //    alert('1');
        //    var iframe = document.getElementById("btnClic2");
        //    var elmnt = iframe.contentWindow.document.getElementById("embedVideoE");
        //    alert(elmnt);
        //    //$("#btnClic2").contents().find("#embedVideoE").on("click"), function () {
        //    //    alert('E');
        //    //}
        //    //$("#btnClic2").contents().find("#embedVideoE").on('click', function () {
        //    //    alert('E');
        //    //});
        //    //$("#btnClic2").contents().find("#embedVideoC").on('click', function () {
        //    //    alert('C');
        //    //});
        //    //$("#btnClic2").contents().find("#hook_Block_Require").on('click', function () {
        //    //    alert('block');
        //    //});

        //    //$("#btnClic2").contents().find(".videoembed").on('click', function () {
        //    //    alert('block');
        //   // });
        //});
    }
   
}