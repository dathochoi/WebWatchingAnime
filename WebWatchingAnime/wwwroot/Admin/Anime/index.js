var animeController = function () {
    var oldsize = 0;
    this.init = function () {
        loadCategories();
        loadYears();
        loadSubs();
        loadData();
        register();
        
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
                ddlCategoryIdM: {
                    required: true,

                },
                ddlYearIdM: {
                    required: true,
                },
                ddlSubIdM: {
                    required: true,
                },
                txtDescM: {
                    required: true,

                },
                txtEpisodesMaxM: {
                    required: true,

                }

            }
        });


        $("#btnCreate").on("click", function () {
            resetFormMaintainance();
            $('#modal-add-edit').modal('show')
        })
        $('#ddlShowPage').on('change', function () {
            lib.configsAdmin.pageSize = $(this).val();
            lib.configsAdmin.pageIndex = $(this).val();
            loadData(true);
        });

        $('#btnSearch').on('click', function () {
            lib.configsAdmin.pageIndex = 1;
            loadData();
        });


        $('#txtKeyword').on('keypress', function (e) {
            if (e.which === 13) {
                lib.configsAdmin.pageIndex = 1;
                loadData();
            }
        });

        $("#fileInputImage").on("change", function () {
            var fileUpload = $(this).get(0);
            var files = fileUpload.files;
            //console.log(fileUpload.files);
            var data = new FormData();

            //console.log(files.length + " file upload do dai");
            for (var i = 0; i < files.length; i++) {
                data.append(files[i].name, files[i]);
            }
            $.ajax({
                type: "POST",
                url: "/Admin/Upload/UploadImage",
                contentType: false,
                processData: false,
                data: data,
                success: function (path) {
                    $("#txtImage").text(path);
                    $("#fileInputImage").text(path);
                    $("#imageShow").attr("src", path);
                    //lib.notify("Upload ảnh thành công.", "success");
                    $.growl.notice({ message: 'Upload ảnh thành công' });
                },
                error: function () {
                    //lib.notify("Upload ảnh thất bại!", "error");
                    $.growl.error({ message: "Upload ảnh thất bại!" });
                }
            });
        });

        $("body").on("click", ".btn-edit", function (e) {
            e.preventDefault();
            //console.log("edit enter");
            resetFormMaintainance();

            var that = $(this).data("id");
            $.ajax({
                type: "GET",
                url: "/Admin/Index/GetById",
                data: { id: that },
                dataType: "json",
                beforeSend: function () {
                    lib.startLoading();
                },
                success: function (response) {
                    var data = response;
                    $('#hidIdM').val(data.Id);
                    $('#txtNameM').val(data.Name);
                    $('#ddlCategoryIdM').val(data.CategoryId);
                    $('#ddlYearIdM').val(data.YearId);
                    $('#ddlSubIdM').val(data.SubId);

                    $('#txtOderNameM').val(data.OrderName);
                    $('#txtDescM').val(data.Description);

                    $("#txtImage").text(data.ImgSrc);
                    $("#fileInputImage").text(data.ImgSrc);
                    $('#imageShow').attr("src", data.ImgSrc);
                    //$("#imageShow").attr("src", path);

                    $('#txtSrcTrailerM').val(data.SrcTrailer);
                    $('#txtEpisodesMaxM').val(data.EpisodesMax);
                    $('#ckIsAnimeM').prop('checked', data.IsAnime);
                    $('#modal-add-edit').modal('show');
                    for (var i = 0; i < data.CategoryIds.length; i++) {
                        $('#ddlCategoryIdM').tokenize2().trigger('tokenize:tokens:add', [data.CategoryIds[i], data.CategoryNames[i], true]);
                    }


                    lib.stopLoading();
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
                    url: "/Admin/Index/Delete",
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
                var name = $('#txtNameM').val();
                var orderName = $("#txtOderNameM").val();
                //var categoryId = $("#ddlCategoryIdM").val();
                var categoryId = "1";
                var yearId = $("#ddlYearIdM").val();
                var subId = $("#ddlSubIdM").val();
                var description = $("#txtDescM").val();
                var imageSrc = $("#imageShow").attr("src");
                var trailerSrc = $("#txtSrcTrailerM").val();
                var episodesMax = $("#txtEpisodesMaxM").val();
                var isAnime = $('#ckIsAnimeM').prop('checked');
                var categoryIds = [];
                var tokens = document.getElementsByClassName("token");
                for (var i = 0; i < tokens.length; i++) {
                    categoryIds.push(tokens[i].getAttribute('data-value'));
                }


                $.ajax({
                    type: "POST",
                    url: "/Admin/Index/SaveEntity",

                    data: {
                        __RequestVerificationToken: $("[name='__RequestVerificationToken']").val(),
                        Id: id,
                        Name: name,
                        CategoryId: categoryId,
                        OrderName: orderName,
                        ImgSrc: imageSrc,
                        YearId: yearId,
                        Description: description,
                        SrcTrailer: trailerSrc,
                        IsAnime: isAnime,
                        EpisodesMax: episodesMax,
                        CategoryIds: categoryIds,
                        SubId: subId
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
        $('#txtNameM').val("");
        loadCategories();
        loadYears();
        loadSubs();
        $('#txtOderNameM').val("");
        $('#txtDescM').val("");
        //$('#txtImage').val("");
        $('#fileInputImage').val("");
        $('#txtSrcTrailerM').val("");
        $('#txtEpisodesMaxM').val("??");
        $('#ckIsAnimeM').prop('checked', true);
        $('#imageShow').attr("src", "");
        $("#txtImage").text("Chọn ảnh");
        $(".token").remove();
    }

    function loadCategories() {
        $.ajax({
            type: "GET",
            url: "/Admin/Category/GetAll",
            dataType: 'json',
            success: function (res) {
                var render = "<option value=''> -- Danh mục --  </option>";
                $.each(res, function (i, item) {
                    render += "<option value='" + item.Id + "'>" + item.Name + "</option>"
                });
                $('#ddlCategorySearch').html(render);
                $('#ddlCategoryIdM').html(render);
                $('#ddlCategoryIdM').tokenize2();

            },
            error: function (status) {
                //console.log(status);
                //lib.notify("Không thể hiển thị danh sách thể loại", "error");
                $.growl.error({ message: "Không thể hiển thị danh sách thể loại" });
            }
        });
    }
   
    function loadYears() {
        $.ajax({
            type: "GET",
            url: "/Admin/Year/GetAll",
            dataType: 'json',
            success: function (res) {
                var render = "";
                $.each(res, function (i, item) {
                    render += "<option value='" + item.Id + "'>" + item.Name + "</option>"
                });
                //$('#ddlCategorySearch').html(render);
                $('#ddlYearIdM').html(render);
            },
            error: function (status) {
               // console.log(status);
                //lib.notify("Không thể hiển thị danh sách năm", "error");
                $.growl.error({ message: "Không thể hiển thị danh sách năm" });
            }
        });
    }

    function loadSubs() {
        $.ajax({
            type: "GET",
            url: "/Admin/Sub/GetAll",
            dataType: 'json',
            success: function (res) {
                var render = "";
                $.each(res, function (i, item) {
                    render += "<option value='" + item.Id + "'>" + item.Name + "</option>"
                });
                //$('#ddlCategorySearch').html(render);
                $('#ddlSubIdM').html(render);
            },
            error: function (status) {
                // console.log(status);
                //lib.notify("Không thể hiển thị danh sách sub", "error");
                $.growl.error({ message: "Không thể hiển thị danh sách sub" });
            }
        });
    }

    //function registerControls() {
    //    CKEDITOR.replace("txtContent", {});
    //    //Fix: cannot click on element ck in modal
    //    $.fn.modal.Constructor.prototype.enforceFocus = function () {
    //        $(document)
    //            .off('focusin.bs.modal') // guard against infinite focus loop
    //            .on('focusin.bs.modal', $.proxy(function (e) {
    //                if (
    //                    this.$element[0] !== e.target && !this.$element.has(e.target).length
    //                    // CKEditor compatibility fix start.
    //                    && !$(e.target).closest('.cke_dialog, .cke').length
    //                    // CKEditor compatibility fix end.
    //                ) {
    //                    this.$element.trigger('focus');
    //                }
    //            }, this));
    //    };

    //}

    function loadData(isPageChanged){
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
                page: lib.configsAdmin.pageIndex,
                pageSize: lib.configsAdmin.pageSize
            },
            url: "/Admin/Index/GetAllPaging",
            dataType: 'json',
            success: function (res) {
               // console.log(res);
                if (res.Results.length > 0) {
                    $.each(res.Results, function (i, item) {
                        render += Mustache.render(template, {
                            Id: item.Id,
                            Name: item.Name,
                            Episode: item.EpisodeName,
                            Description: item.Description,
                            Year: item.YearName
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
               // console.log(status);
               // lib.notify("Không tìm thấy anime", "error");
                $.growl.error({ message: "Không tìm thấy anime" });
            }
        });
    }

    function wrapPaging(recordCount, callBack, changePageSize) {
        var totalsize = Math.ceil(recordCount / lib.configsAdmin.pageSize);
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
                lib.configsAdmin.pageIndex = p;
                setTimeout(callBack(), 200);
            }
        });
    }
}