var categoryController = function () {
    this.init = function () {
         loadData();
         register();

    }
    function register() {
        $("#frmMaintainance").validate({
            errorClass: 'red',
            ignore: [],
            lang: 'vi',
            rules: {
                txtKeyword: {
                    required: true
                }
            }
        });
        $("#frmMaintainance2").validate({
            errorClass: 'red',
            ignore: [],
            lang: 'vi',
            rules: {
                txtNameM: {
                    required: true
                }
            }
        });

        $('#txtKeyword').on('keypress', function (e) {
            
            if (e.which === 13) {
                e.preventDefault();
                if ($('#frmMaintainance').valid()) {
                    Save($("#txtKeyword").val());
                }
            }
        });

        $("body").on("click", ".btn-edit", function (e) {
            e.preventDefault();
            //console.log("edit enter");
            resetFormMaintainance();

            var that = $(this).data("id");
            $.ajax({
                type: "GET",
                url: "/Admin/Category/GetById",
                data: { id: that },
                dataType: "json",
                beforeSend: function () {
                    lib.startLoading();
                },
                success: function (response) {
                    var data = response;
                    $('#hidIdM').val(data.Id);
                    $('#txtNameM').val(data.Name);
                    $('#modal-add-edit').modal('show');
                    lib.stopLoading();
                },
                error: function (status) {
                    //lib.notify("Error", "error");
                    $.growl.error({ message: "Error" });
                    lib.stopLoading();
                }
            });
        });

        $("body").on("click", ".btnDelete", function (e) {
            e.preventDefault();
            var that = $(this).data("id");
            lib.confirm("Bạn có muốn  xóa không?", function () {
                $.ajax({
                    type: "POST",
                    url: "/Admin/Category/Delete",
                    data: { id: that },
                    dataType: "json",
                    beforeSend: function () {
                        lib.startLoading();
                    },
                    success: function (response) {
                        $.growl.notice({ message: 'Đã xóa thành công' });

                        lib.stopLoading();
                        loadData();
                    },
                    error: function (status) {
                        $.growl.error({ message: "Xóa năm bị lỗi" });
                        //lib.notify('Xóa sản phẩm bị lỗi', 'error');
                        lib.stopLoading();
                    }
                });
            });
        });
        $("#btnSave").on("click", function (e) {
            if ($('#frmMaintainance').valid()) {
                e.preventDefault();
                Save($("#txtKeyword").val());
            }
        });
        $("#btnUpdate").on('click', function (e) {
            if ($('#frmMaintainance2').valid()) {
                e.preventDefault();
                Save($("#txtNameM").val(), $("#hidIdM").val());
                $("#modal-add-edit").modal("hide");
                resetFormMaintainance();
            }
        })
    }

    function Save(txtName, idHid) {
             var name = txtName;
              var id = idHid;
            $.ajax({
                type: "POST",
                url: "/Admin/Category/SaveEntity",

                data: {
                    __RequestVerificationToken: $("[name='__RequestVerificationToken']").val(),
                    Name: name,
                     Id : id
                },
                dataType: "json",
                before: function () {
                    lib.startLoading();
                },

                success: function (res) {
                    $.growl.notice({ message: "Lưu danh mục thành công" });
                    $("#txtKeyword").val("");
                    lib.stopLoading();
                    loadData();
                },
                error: () => {
                    $.growl.error({ message: "Danh mục lưu thất bại" });
                    lib.stopLoading();
                }
            });
            return false;
    }

    function resetFormMaintainance() {
        $('#hidIdM').val(0);
        $('#txtNameM').val("");
    }

    function loadData() {
        var template = $('#table-template').html();
        var render = "";

        
        $.ajax({
            type: "GET",
            url: "/Admin/Category/GetAll",
            dataType: 'json',
            success: function (res) {
                console.log(res);
                if (res.length > 0) {
                    $.each(res, function (i, item) {
                        render += Mustache.render(template, {
                            Id: item.Id,
                            Name: item.Name,
                        });

                    });
                }
                else {
                    render = "Không có danh mục hiển thị";
                }
                if (render != '') {
                    $('#tbl-content').html(render);
                }
            },
            error: function (status) {
                console.log(status);
                lib.notify("Không hiển thi danh mục được!", "error");
            }
        });
    }
}