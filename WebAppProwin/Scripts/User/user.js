$(function () {
    $('.lazy').lazy({
        afterLoad: function (element) {
            element.parent().addClass("loaded");
            if ($("#demo").length != 0) {
                $("#demo").trigger("loaded");
            }
        }
    });

});

$(document).ready(function () {/*
    
    */
    $(".left-first-section").click(function () {
        $('.main-section').toggleClass("open-more");

    });
    $(".main-section .fa-minus").click(function () {
        $('.main-section').toggleClass("open-more");
    });
    $(window).scroll(function () {
        var sticky = $('header'),
            scroll = $(window).scrollTop();

        if (scroll >= 70) {
            sticky.addClass('fixed');
            // sticky.css("display", "none");
            sticky.slideDown(100);
        }
        else {
            sticky.removeClass('fixed');
        }
    });
    //alert($(document).width());
    $(".product-list .item").hover(function () {
        $(this).addClass("hovered");
    });
    $(".product-list .item").mouseleave(function () {
        $(this).removeClass("hovered");
    });
    $(document).on("click", function (e) {
        var curr = $(e.target);
        if ($("#mobile-menu").has(curr).length == 0 && $(".main-menu-mobile").has(curr).length == 0 && $(".main-menu-mobile").hasClass("active")) {
            $("#mobile-menu").slideUp();
            $(".main-menu-mobile").toggleClass("active");
        }

    });
    $("#mobile-menu > .navbar-nav").on("click", function (e) {
        var curr = $(e.target);
        var parrent = curr.parent();
        // alert(curr.parent().attr("class"));
        if (parrent.hasClass("nav-menu-item") || curr.hasClass("dropdown-toggle-button-icon")) {

            var child = parrent.children(".dropdown-menu");
            if (parrent.hasClass("toggled")) {
                parrent.toggleClass("toggled");
                child.slideUp();
            } else {
                parrent.toggleClass("toggled");
                child.slideToggle(300);
            }

        }
    });

    var event = $(".main-menu-mobile").find("a");
    event.click(function () {
        if ($(".main-menu-mobile").hasClass("active")) {
            $("#mobile-menu").slideUp();
            $(".main-menu-mobile").toggleClass("active");
        } else {
            $(".main-menu-mobile").toggleClass("active");
            $("#mobile-menu").slideToggle(320);
        }
    });
    function Init() {
        $('.slimScrollDiv').children().unwrap();
        $('.slimScrollBar, .slimScrollRail').remove();
        if ($(window).width() > 990) {
            $('#news').slimScroll({
                height: $("#demo").height(),
                color: 'rgba(0,0,0,0.5)',
                size: '4px',
                position: 'right',
                alwaysVisible: false,
                railBorderRadius: '1px',
                borderRadius: '1px',
            });
        } else {
            $('#news').css("height", "auto");
            $('#news').css("overflow", "none");
        }

    }
    $(window).resize(function () {
        Init();
    });
    $("#demo").on("loaded", function () {
        Init();
    });
});
function XuLyDK() {
    var flag = true;
    var ho = $("#ho").val();
    var ns = $("#ns").val();
    var ten = $("#ten").val();
    var email = $("#email").val();
    var sdt = $("#sdt").val();
    var dc = $("#dc").val();
    var mk = $("#mk").val();
    var rmk = $("#rmk").val();
    if (ho.trim().length == 0) {
        turnError("ho", "Họ không được để trống");
    } else {
        if (ho.trim().length >= 25) {

            flag = turnError("ho", "Họ không được quá 25 ký tự");
        } else {
            hideError('ho');
        }
    }


    if (ten.trim().length == 0) {
        flag = turnError("ten", "Tên khẩu không được để trống");
    } else {

        if (ten.trim().length >= 25) {
            flag = turnError("ten", "Tên không được quá 25 ký tự");
        } else {
            hideError('ten');
        }
    }


    if (email.trim().length == 0) {
        flag = turnError("email", "Email không được để trống");
    } else {
        if (email.trim().length >= 25) {
            flag = turnError("email", "Email không được quá 25 ký tự");
        } else {
            if (!validateEmail(email)) {
                flag = turnError("email", "Email không hợp lệ");
            } else {

                $.get("/DangNhap/KiemTraEmail?email=" + email, function (data) {
                    if (data == "HAS") {
                        flag = turnError("email", "Email đã tồn tại");
                    } else {
                        hideError('email');
                    }
                });
            }
        }
        
    }
  


    if (dc.trim().length == 0) {
        flag = turnError("dc", "Địa chỉ không được để trống");
    } else {
        if (dc.trim().length >= 100) {
            flag = turnError("dc", "Địa chỉ không được quá 100 ký tự");
        } else {
            hideError('dc');
        }

    }

    if (ns.length == 0) {
        flag = turnError("ns", "Ngày sinh không được để trống");
    } else {
            hideError('ns');

    }
    
    var intRegex = /[0-9 -()+]+$/;

    if (sdt.trim().length == 0) {
        flag = turnError("sdt", "Số điện thoại không được để trống");
    } else {

        if (sdt.trim().length >= 20) {
            flag = turnError("sdt", "Số điện thoại không được vượt quá 20 ký tự");
        } else {
            if (!intRegex.test(sdt)) {
                flag = turnError("sdt", "Số điện thoại phải là kiểu số");
            } else {
                hideError('sdt');
            }
        }
    }


    if (mk.length == 0) {
        flag = turnError("mk", "Mật khẩu không được để trống");
    } else {
        if (mk.length >= 15) {
            flag = turnError("mk", "Mật khẩu không được vượt quá 15 ký tự");
        } else {
            hideError('mk');
        }
    }
   
    if (mk != rmk) {
        flag = turnError("rmk", "Mật khẩu không trùng khớp");
    } else {
        hideError('rmk');
    }

    if (flag == true) {
        $(".form-signup").submit();
    } else {
        $(".form-signup").children("div").scrollTop(0);
    }
}

function XuLyDN() {
    if ($(this).hasClass("disabled")) {
        return;
    }
    var flag = true;
    var email = $("#emailDN").val();
    var matkhau = $("#passDN").val();
    if (email.trim().length == 0) {
       flag = turnError("emailDN", "Email không được để trống");
    } else {
        if (!validateEmail(email)) {
            flag = turnError("emailDN", "Email không hợp lệ");
        }
        else {
            hideError('emailDN');
        }
    }
   


    if (matkhau.length == 0) {
        flag = turnError("passDN", "mật khẩu không được để trống");
    } else {
        hideError('passDN');
    }
    if (flag) {
        $.ajax({
            url: '/DangNhap/KiemTraDN',
            dataType: 'json',
            type: 'post',
            contentType: 'application/x-www-form-urlencoded',
            data: $(".form-signin").serialize(),
            success: function (data) {
                if (data == "Error") {
                    turnError("passDN", "Email và password không tồn tại");
                } else {
                    $(".btn-signin").addClass("disabled");
                    $(".login").css("display", "none");
                    $(".quanly").css("display", "block");
                    count = 3;
                    var timer = setInterval(function () {
                        if (count == 0) {
                            clearInterval(timer);
                            $(".form-login .close").trigger("click");
                        } else {
                            $(".btn-signin").html("Bạn đã đăng nhập thành công. Bạn hãy đợi trong " + count + "s để hoàn tất quá trình đăng nhập");
                            count = count - 1;
                        }
                    }, 1000);
                }
            }
        });
    }
}
function validateEmail(email) {
    var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
}
function turnError(name, error) {
    $("#" + name).addClass('is-invalid');
    $("." + name + '-error').html(error);
    $("." + name + '-error').css("display", "block");
    return false;
}
function hideError(name) {
    $("#" + name).removeClass('is-invalid');
    $("." + name + '-error').css("display", "none");
}

function CapNhat() {
    var flag = true;
    var ho = $("#ho").val();
    var ten = $("#ten").val();
    var sdt = $("#sdt").val();
    var dc = $("#dc").val();
    if (ho.trim().length == 0) {
        turnError("ho", "Họ không được để trống");
    } else {
        if (ho.trim().length >= 25) {

            flag = turnError("ho", "Họ không được quá 25 ký tự");
        } else {
            hideError('ho');
        }
    }


    if (ten.trim().length == 0) {
        flag = turnError("ten", "Tên khẩu không được để trống");
    } else {

        if (ten.trim().length >= 25) {
            flag = turnError("ten", "Tên không được quá 25 ký tự");
        } else {
            hideError('ten');
        }
    }



    if (dc.trim().length == 0) {
        flag = turnError("dc", "Địa chỉ không được để trống");
    } else {
        if (dc.trim().length >= 100) {
            flag = turnError("dc", "Địa chỉ không được quá 100 ký tự");
        } else {
            hideError('dc');
        }

    }

    var intRegex = /[0-9 -()+]+$/;
    if (sdt.trim().length == 0) {
        flag = turnError("sdt", "Số điện thoại không được để trống");
    } else {

        if (sdt.trim().length >= 20) {
            flag = turnError("sdt", "Số điện thoại không được vượt quá 20 ký tự");
        } else {
            if (!intRegex.test(sdt)) {
                flag = turnError("sdt", "Số điện thoại phải là kiểu số");
            } else {
                hideError('sdt');
            }
        }
    }


    if (flag == true) {
        $("#iForm").submit();
    }
}

function ChangePassword() {
    var flag = true;
    var mkc = $("#mkc").val();
    var mk = $("#mk").val();
    var rmk = $("#rmk").val();
    if (mkc.length == 0) {
        flag = turnError("mkc", "Mật khẩu cũ không được để trống");
    } else {
        if (mkc.length >= 15) {
            flag = turnError("mkc", "Mật khẩu cũ không được vượt quá 15 ký tự");
        } else {
            hideError('mkc');
        }
    }

    if (mk.length == 0) {
        flag = turnError("mk", "Mật khẩu không được để trống");
    } else {
        if (mk.length >= 15) {
            flag = turnError("mk", "Mật khẩu không được vượt quá 15 ký tự");
        } else {
            hideError('mk');
        }
    }

    if (mk != rmk) {
        flag = turnError("rmk", "Mật khẩu không trùng khớp");
    } else {
        hideError('rmk');
    }

    if (flag == true) {
        $.ajax({
            url: '/DangNhap/ChangePassword',
            dataType: 'json',
            type: 'post',
            contentType: 'application/x-www-form-urlencoded',
            data: $("#pForm").serialize(),
            success: function (data) {
                if (data == "Error") {
                    turnError("rmk", "Mật khẩu cũ không chính xác");
                } else {
                    turnError("rmk", "Thay đổi mật khẩu thành công");
                    $(".rmk-error").addClass("text-success");
                }
            }
        });
    } 
}

function SendInfor()
{
    var flag = true;
    var hoten = $("#tenInf").val();
    var email = $("#emailInf").val();
    var sdt = $("#dtInf").val();
    var noidung = $("#noidungInf").val();
    if (hoten.trim().length == 0) {
        turnError("tenInf", "Họ tên không được để trống");
    } else {
        if (hoten.trim().length >= 40) {

            flag = turnError("tenInf", "Họ tên không được quá 40 ký tự");
        } else {
            hideError('tenInf');
        }
    }


    if (email.trim().length == 0) {
        flag = turnError("emailInf", "Email không được để trống");
    } else {
        if (email.trim().length >= 25) {
            flag = turnError("emailInf", "Email không được quá 25 ký tự");
        } else {
            if (!validateEmail(email)) {
                flag = turnError("emailInf", "Email không hợp lệ");
            } else {
                hideError('emailInf');
            }
        }

    }


    if (noidung.length == 0) {
        flag = turnError("noidungInf", "Ngày sinh không được để trống");
    } else {
        if (noidung.trim().length >= 240) {
            flag = turnError("noidungInf", "Nội dung không được quá 25 ký tự");
        } else {
            hideError('noidungInf');
        }
    }

    var intRegex = /[0-9 -()+]+$/;
    if (sdt.trim().length == 0) {
        flag = turnError("dtInf", "Số điện thoại không được để trống");
    } else {

        if (sdt.trim().length >= 20) {
            flag = turnError("dtInf", "Số điện thoại không được vượt quá 20 ký tự");
        } else {
            if (!intRegex.test(sdt)) {
                flag = turnError("dtInf", "Số điện thoại phải là kiểu số");
            } else {
                hideError('dtInf');
            }
        }
    }
    if (flag) {
        $.ajax({
            url: '/DangNhap/ThemKHLH',
            dataType: 'json',
            type: 'post',
            contentType: 'application/x-www-form-urlencoded',
            data: $("#inforForm").serialize(),
            success: function (data) {
                if (data == "OK") {
                    $(".noidungInf-error").css("display", "block");
                    $(".noidungInf-error").html("Chúng tôi đã nhận được yêu cầu từ bạn. Chúng tôi sẽ liên hệ với bạn sớm nhất");
                    $(".noidungInf-error").addClass("text-success");
                } else {
                    alert("Bạn đã gửi quá nhiều yêu cầu");
                }
            }
        });
    }
}