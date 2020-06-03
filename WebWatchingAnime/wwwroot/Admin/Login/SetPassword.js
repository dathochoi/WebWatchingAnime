var SetPasswordController = function () {
    this.init = function () {
        registerEvent();
    }
    function registerEvent() {
        $("#frmReset").validate({
            errorClass: 'red',
            ignore: [],
            lang: 'vi',
            rules: {
                txtOldPassword: {
                    required: true,
                    minlength: 1
                },
                txtNewPassword: {
                    required: true,
                    minlength: 6
                },
                txtConfirmPassword: {
                    required: true,
                    minlength: 6,
                    equalTo: "#txtNewPassword"
                }
            }
            //message: {
            //    txtPasswordRe: "Mật khẩu chưa giống",
            //    txtPassword: "Mật khẩu chưa giống",
            //    txtEmail: "Chưa nhập email",
            //    txtName: "Chưa nhập password"
            //}
        });
        $("#btnSave").on("click", function (e) {
            e.preventDefault();
            var token = $("[name='__RequestVerificationToken']").val();
            if ($("#frmReset").valid()) {
                $.ajax({

                    type: 'POST',
                    //beforeSend: function (request) {
                    //    request.setRequestHeader("RequestVerificationToken", $("[name='__RequestVerificationToken']").val());
                    //},
                    data: {
                        __RequestVerificationToken: token,
                        OldPassword: $("#txtOldPassword").val(),
                        NewPassword: $("#txtNewPassword").val(),
                        ConfirmPassword: $("#txtConfirmPassword").val(),
                        UserName: $("#txtUsername").val()

                    },
                    dataTyoe: 'json',
                    url: '/Admin/Login/ResetPassword',
                    success: function (res) {
                        //alert(res);
                        if (res.Succeeded) {
                           // bootbox.alert("Đã thay đổi password thành công")
                            $.growl.notice({ message: 'Đã thay đổi password thành công' });
                            //window.location.href = '/Admin/Login';
                        }
                        else {
                            //alert("Đăng kí thất bại");
                            //bootbox.alert("Thay đổi password thất bại")
                            $.growl.error({ message: "Thay đổi password thất bại" });
                        }
                    }
                });
            }
        });
    }
}