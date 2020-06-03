var episodeController = function () {
    var oldsize = 0;
    this.init = function () {
        register();
        loadData();
    }
    function register() {
        $("#frmMaintainance").validate({
            errorClass: 'red',
            ignore: [],
            lang: 'vi',
            rules: {
                txtNameM: {
                    required: true,
                    minlength: 3
                },
                txtSTTM: {
                    required: true
                },
                txtSrcM: {
                    required: true
                }

            }
        });


        $("#btnCreate").on("click", function () {
            resetFormMaintainance();
            $('#modal-add-edit').modal('show')
        })
        $('#ddlShowPage').on('change', function () {
            lib.configs.pageSize = $(this).val();
            lib.configs.pageIndex = $(this).val();
            loadData(true);
        });

        $('#btnSearch').on('click', function () {
            lib.configs.pageIndex = 1;
            loadData();
        });

        $('#txtKeyword').on('keypress', function (e) {
            if (e.which === 13) {
                lib.configs.pageIndex = 1;
                loadData();
            }
        });

        $("body").on("click", ".btn-edit", function (e) {
            e.preventDefault();
            //console.log("edit enter");
            resetFormMaintainance();

            var that = $(this).data("id");
            $.ajax({
                type: "GET",
                url: "/Admin/Episode/GetById",
                data: { id: that },
                dataType: "json",
                beforeSend: function () {
                    lib.startLoading();
                },
                success: function (response) {
                    var data = response;
                    $('#hidIdM').val(data.Id);
                    $('#txtAnimeIdM').val(data.AnimeId);
                    $('#txtNameM').val(data.Number);
                    $('#txtSTTM').val(data.STT);
                    $('#txtSrcM').val(data.Src);
                    lib.stopLoading();
                    $('#modal-add-edit').modal('show');
                },
                error: function (status) {
                    //lib.notify("Error", "error");
                    $.growl.error({ message: "Error" });
                    lib.stopLoading();
                }
            });
        });

        $("body").on("click", ".btn-delete", function (e) {
            e.preventDefault();
            var that = $(this).data("id");
            lib.confirm("Bạn có muốn  xóa không?", function () {
                //console.log("delete enter click");
                $.ajax({
                    type: "POST",
                    url: "/Admin/Episode/Delete",
                    data: { id: that },
                    dataType: "json",
                    beforeSend: function () {
                        lib.startLoading();
                    },
                    success: function (response) {
                        $.growl.notice({ message: 'Đã xóa thành công' });
                        // lib.notify('Đã xóa thành công', 'success');
                        lib.stopLoading();
                        loadData();
                    },
                    error: function (status) {
                        //lib.notify('Xóa sản phẩm bị lỗi', 'error');
                        $.growl.error({ message: "Xóa năm bị lỗi" });
                        lib.stopLoading();
                    }
                });
            });
        });

        $("#btnSave").on("click", function (e) {
            //e.preventDefault();
            if ($('#frmMaintainance').valid()) {
                e.preventDefault();
                var id = $("#hidIdM").val();
                var animeId = $('#txtAimeIdM').val();
                var name = $("#txtNameM").val();
                var stt = $("#txtSTTM").val();
                var src = $("#txtSrcM").val();

                $.ajax({
                    type: "POST",
                    url: "/Admin/Episode/SaveEntity",

                    data: {
                        __RequestVerificationToken: $("[name='__RequestVerificationToken']").val(),
                        Id: id,
                        AnimeId: animeId,
                        Number: name,
                        STT: stt,
                        Src: src
                    },
                    dataType: "json",
                    before: function () {
                        lib.startLoading();
                    },

                    success: function (res) {
                        //lib.notify("Lưu sản phẩm thành công", "successs");
                        $.growl.notice({ message: 'Lưu anime thành công' });
                        $("#modal-add-edit").modal("hide");
                        resetFormMaintainance();
                        lib.stopLoading();
                        loadData();
                    },
                    error: () => {
                        //lib.notify("Sản phẩm lưu thất bại", "error");
                        $.growl.error({ message: "Anime lưu thất bại" });
                        lib.stopLoading();
                    }
                });
                return false;
            }
        });
    }

    function resetFormMaintainance() {
        $('#hidIdM').val(0);
        $('#txtAnimeIdM').val("");
        $('#txtNameM').val("");
        $('#txtSTTM').val("");
        $('#txtSrcM').val("");
    }

    function loadData(isPageChanged) {
        var template = $('#table-template').html();
        var render = "";
       
        $.ajax({
            type: "GET",
            data: {
                animeId: $('#AnimeId').data('id'),
                keyword: $('#txtKeyword').val(),
                page: lib.configs.pageIndex,
                pageSize: lib.configs.pageSize
            },
            url: "/Admin/Episode/GetAllPaging",
            dataType: 'json',
            success: function (res) {
                // console.log(res);
                if (res.Results.length > 0) {
                    $.each(res.Results, function (i, item) {
                        render += Mustache.render(template, {
                            Id: item.Id,
                            STT: item.STT,
                            Name: item.Number,
                            Src: item.Src 
                        });

                    });
                    $("#lblTotalRecords").text(res.RowCount);
                }
                else {
                    render = "Không có tập nào hiển thị!";
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
                // console.log(status);
                // lib.notify("Không tìm thấy anime", "error");
                $.growl.error({ message: "Không tìm thấy" });
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
            first: 'First',
            prev: 'Previous',
            next: 'Next',
            last: 'End',
            onPageClick: function (event, p) {
                lib.configs.pageIndex = p;
                setTimeout(callBack(), 200);
            }
        });
    }
}