//角色管理:
function RoleManagement() {
    if ($(".RList").is(":hidden")) {
        $(".RList").show();
        $(".RListH").hide();
    } else {
        $(".RListH").show();
        $(".RList").hide();
    }
    $(".RoleList").children().slideToggle(200);
}

//插入角色
function InsertRole() {
    $('#AddRole').modal('toggle');
}
//插入模态框提交
function AddRoleButton() {

    var roleName = $("input[name='RoleName']").val();
    var roleDetails = $("input[name='RoleDetails']").val();
    $.ajax({
        url: '/GetAdministratorPage/InsertRole',
        type: 'post',
        data: { RoleName: roleName, RoleDetails: roleDetails },
        success: function (result) {
            if (result.RoleName === "0") {
                alert("插入失败！");
            } else {
                alert("插入成功！");
                $("#AddRole").modal("hide");
            }
        },
    }).done().fail(function () {
        alert("网络连接错误！");
    });
}

function FindRole(page) {
    $.ajax({
        url: '/GetAdministratorPage/SelectRole?page=' + page + '',
        type: 'post',
        success: function (result) {
            //请求的数据插入到表格
            $("#tbodyContent").html("");
            $("#PageListP").html("");
            var item = 0;
            for (; item < result.length - 1; item++) {

                $("#tbodyContent").append("<tr draggable='true'><td>" + result[item].RoleID + "</td><td>" + result[item].RoleName + "</td><td>" + result[item].RoleDetails + "</td></tr>");
            }
            for (var num = 1; num <= result[result.length - 1].RoleID; num++) {
                $("#PageListP").append('<a href="javascript:void(0);" onclick="FindRole(' + num + ')">第 ' + num + '页</a>');
            }
        },
    }).done().fail(function () {
        alert("网络连接错误！");
    });

}

//职业管理:
function ProfessionalManagement() {
    if ($(".PList").is(":hidden")) {
        $(".PList").show();
        $(".PListH").hide();
    } else {
        $(".PListH").show();
        $(".PList").hide();
    }
    $(".ProfessionalList").children().slideToggle(200);

}
//核心技能:
function CoreSkilllManagement() {
    if ($(".CList").is(":hidden")) {
        $(".CList").show();
        $(".CListH").hide();
    } else {
        $(".CListH").show();
        $(".CList").hide();
    }
    $(".CoreSkilllList").children().slideToggle(200);
}

//专业技能:
function TeachSkillManagement() {
    if ($(".TList").is(":hidden")) {
        $(".TList").show();
        $(".TListH").hide();
    } else {
        $(".TListH").show();
        $(".TList").hide();
    }
    $(".TeachSkillList").children().slideToggle(200);
}


//系统管理:
function SystemManagement() {
    if ($(".SList").is(":hidden")) {
        $(".SList").show();
        $(".SListH").hide();
    } else {
        $(".SListH").show();
        $(".SList").hide();
    }
    $(".System").children().slideToggle(200);
}


//职务管理:
function PositionManagement() {
    if ($(".PPList").is(":hidden")) {
        $(".PPList").show();
        $(".PPListH").hide();
    } else {
        $(".PPListH").show();
        $(".PPList").hide();
    }
    $(".Position").children().slideToggle(200);
}
