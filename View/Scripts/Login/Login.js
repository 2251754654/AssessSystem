function Login() {
    //获得登陆数据
    var userName = $("#UserNameText").val();
    var password = $("#PasswordText").val();
    //异步登陆请求
    $.post({
        url: 'Login/Login',
        data: { userName: userName, password: password },
        dataType: 'json',
        success: function (data) {
            $("#messagePassword").text(data.UserPassword);
            $("#messageUserName").text(data.UserName);
            if (data.UserPassword !== "0") {
                window.setTimeout(function () {
                    window.location.href = "/Home/HomePage";
                }, 500);
            }
        }
    });
}

function GetData() {
    $.ajax({
        type: 'post',
        url: '/Home/GetAJAXEvaluation',
        dataType: 'json',
        contentType: "application/json",
        success: function (result) {
            $('#Content-List').html("");
            for (var i = 0; typeof (result[i]) !== "undefined"; i++) {
                if (i % 2 === 0) {
                    $('#Content-List').append("<li class='itemSingleBG'> <a href='#'>第" + result[i].EvaluationID + "条评论：用户：<label class='LableList'>" + result[i].UserIDMainName + "</label >对用户：<label class='LableList'>" + result[i].UserIDByName + "</label>总体评价是：" + result[i].EvaluationDetails + ".</a></li >");
                }
                else {
                    $('#Content-List').append(" <li class='itemSecondBG'><a href='#'>第" + result[i].EvaluationID + "条评论：用户：<label class='LableList'>" + result[i].UserIDMainName + "</label >对用户：<label class='LableList'>" + result[i].UserIDByName + "</label>总体评价是：" + result[i].EvaluationDetails + ".</a></li >");
                }
            }
        },
    });
}
$(document).ready(function () {
    GetData();
});