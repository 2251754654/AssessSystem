function GetLogin() {
    $("#LoginCheck").ajaxSubmit({
        type: 'post',
        url: '/Login/LoginCheck',
        dataType: 'json',
        //contentType: "application/json",//含有这个参数，执行不成功，为啥？？？？,-》无此参数
        success: function (data) {
            $("#messagePassword").text(data.UserPassword);
            $("#messageUserName").text(data.UserName);
            if (data.UserPassword !== "失败") {
                window.setTimeout(function () {
                    window.location.href = "/Home/HomePage";
                }, 1000);
            }
        },
        resetForm:'true',
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
            for (var i = 0; typeof(result[i]) !== "undefined"; i++) {
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