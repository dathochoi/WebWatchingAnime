var viewController = function () {
    var oldsize = 0;
    var category = '';
    var year = '';
    var anime = false;
    var film = false;
    var txtSearch = '';
    this.init = function (categoryId, yearId,  textSearch,animes, films) {
        if (categoryId !== 0) {
            category = categoryId;
        }
        if (yearId !== 0) {
            year = yearId;
        }
        if (textSearch.localeCompare("z00000zzzzz")  !== 0 ) {
            txtSearch = textSearch;
        }
        if (animes !== 0) {
            animes = animes;
        }
        if (films !== 0) {
            film = films;
        }
        loadData();
        Register();
    };
    function Register() {
        $("body").on("click", ".btnCategory", function (e) {
            e.preventDefault();

            year = '';
            anime = false;
            film = false;
            txtSearch = '';
            lib.configsAdmin.pageIndex = 1;

            category = $(this).data("id");

            loadData();
            //console.log(that);
        });
        $("body").on("click", ".btnYear", function (e) {
            e.preventDefault();
            category = '';
            anime = false;
            film = false;
            txtSearch = '';
            lib.configsAdmin.pageIndex = 1;

            year = $(this).data("id");

            loadData();

            //var that = $(this).data("id");
            //console.log(that);
        });
        $("body").on("click", ".btnAnimes", function (e) {
            e.preventDefault();
            category = '';
            year = '';
            anime = true;
            film = false;
            txtSearch = '';
            lib.configsAdmin.pageIndex = 1;
            loadData();
            //var that = $(this).data("id");
            //console.log("animes");
        });
        $("body").on("click", ".btnFilms", function (e) {
            e.preventDefault();
            category = '';
            year = '';
            anime = false;
            film = true;
            txtSearch = '';
            lib.configsAdmin.pageIndex = 1;
            loadData();
            //var that = $(this).data("id");
            //console.log("films");
        });
        $('#btnSearch').on('click', function () {
            lib.configsAdmin.pageIndex = 1;
            category = '';
            year = '';
            
            anime = false;
            film = false;

            txtSearch = $('#txtKeyword').val();
            loadData();
        });


        $('#txtKeyword').on('keypress', function (e) {
            if (e.which === 13) {
                lib.configsAdmin.pageIndex = 1;
                category = '';
                year = '';
                anime = false;
                film = false;

                txtSearch = $('#txtKeyword').val();
                loadData();
            }
        });
    }
    function loadData(isPageChanged) {
        var template = $('#table-template').html();
        var render = "";

        //var catelogryID = "";
        //if ($('#ddlCategorySearch').val() != null) {
            catelogryID = $('#ddlCategorySearch').val();
        //}
        $.ajax({
            type: "GET",
            data: {
                categoryId: category,
                anime: anime,
                film: film,
                year: year,
                keyword: txtSearch,
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