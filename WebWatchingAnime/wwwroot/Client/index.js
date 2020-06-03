var viewController = function () {
    var oldsize = 0;
    this.init = function () {
        loadData();
        Register();
    };
    function Register() {
        //$("#btnClick").on("click", function () {
        //    console.log("clicked video ");
        //    var x = $(".html5-vpl_panel_btn html5-vpl_ok");
        //    x.remove();
        //});
        //console.log("clicked video ssds ");
        ////var iframe = document.getElementById("btnClick");
        ////var elmnt = document.getElementsByClassName("html5-vpl_panel_btn html5-vpl_ok");
        ////elmnt[0].remove();
        //var elmnt = document.getElementsByClassName("html5-vpl_panel_btn html5-vpl_ok")[0];
        //elmnt.remove();
    }
    function loadData(isPageChanged) {
        var template = $('#table-template').html();
        var render = "";

        var catelogryID = "";
        if ($('#ddlCategorySearch').val() != null) {
            catelogryID = $('#ddlCategorySearch').val();
        }
        $.ajax({
            type: "GET",
            data: {
                categoryId: catelogryID,
                keyword: $('#txtKeyword').val(),
                page: lib.configs.pageIndex,
                pageSize: lib.configs.pageSize
            },
            url: "/Home/GetAllPaging",
            dataType: 'json',
            success: function (res) {
                // console.log(res);
                if (res.Results.length > 0) {
                    $.each(res.Results, function (i, item) {
                        render += Mustache.render(template, {
                            Id: item.Id,
                            Name: item.Name,
                            EpisodeName: item.EpisodeName,
                            SubName: item.SubName,
                            Image: '<img class="img-fluid" src="' + item.Image + '" />'
                        });

                    });
                    $("#lblTotalRecords").text(res.RowCount);
                }
                else {
                    render = "Không có anime nào hiển thị!";
                }
                if (render != '') {
                    $('#tbl-content').html(render);
                }

                // $('#paginationUL').remove("a");
                wrapPaging(res.RowCount, function () {
                    loadData();
                }, isPageChanged);
            },
            error: function (status) {
                $.growl.error({ message: "Không tìm thấy anime" });
            }
        });
    }

    function wrapPaging(recordCount, callBack, changePageSize) {
        var totalsize = Math.ceil(recordCount / lib.configs.pageSize);
        //Unbind pagination if it existed or click change pagesize
        if ($('#paginationUL a').length === 0 || changePageSize === true || totalsize != oldsize) {
            $('#paginationUL').empty();
            $('#paginationUL').removeData("twbs-pagination");
            $('#paginationUL').unbind("page");
            oldsize = totalsize;
        }
        //Bind Pagination Event
        $('#paginationUL').twbsPagination({
            totalPages: totalsize,
            visiblePages: 7,
            first: '<i class="fas fa-angle-double-left"></i>',
            prev: '<i class="fas fa-angle-left"></i>',
            next: '<i class="fas fa-angle-right"></i>',
            last: '<i class="fas fa-angle-double-right"></i>',
            onPageClick: function (event, p) {
                lib.configs.pageIndex = p;
                setTimeout(callBack(), 200);
            }
        });
    }
}