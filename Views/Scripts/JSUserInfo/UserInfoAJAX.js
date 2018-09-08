//请求个人信息
function GetUserInfo() {
    $.ajax({
        type: 'post',
        url: '/UserInfo/GetUserInfoByAJAX',
        dataType: 'json',
        contentType: "application/json",
        success: function (result) {
            $('#UserInfoList').html("");
            //将个人信息插入
            $("#UserInfoList").append("<li  class='UserInfoSinger'><label class='UserInfoHeader'>用户信息ID:</label><label class='UserInfoFooter'>" + result.UserInfoID + "</label></li>");
            $("#UserInfoList").append("<li  class='UserInfo'><label class='UserInfoHeader'>用户姓名:</label><label class='UserInfoFooter'>" + result.UserInfoName + "</label></li>");
            $("#UserInfoList").append("<li  class='UserInfoSinger'><label class='UserInfoHeader'>用户年龄:</label><label class='UserInfoFooter'>" + result.UserInfoAge + "</label></li>");
            $("#UserInfoList").append("<li  class='UserInfo'><label class='UserInfoHeader'>用户地址:</label><label class='UserInfoFooter'>" + result.UserInfoAddress + "</label></li>");

            $("#UserInfoList").append("<li  class='UserInfoSinger'><label class='UserInfoHeader'>用户生日:</label><label class='UserInfoFooter'>" + result.UserInfoBirthday + "</label></li>");
            $("#UserInfoList").append("<li  class='UserInfo'><label class='UserInfoHeader'>用户电话:</label><label class='UserInfoFooter'>" + result.UserPhone + "</label></li>");
            $("#UserInfoList").append("<li  class='UserInfoSinger'><label class='UserInfoHeader'>用户邮箱:</label><label class='UserInfoFooter'>" + result.UserInfoEmail + "</label></li>");
            $("#UserInfoList").append("<li  class='UserInfo'><label class='UserInfoHeader'>用户工作电话:</label><label class='UserInfoFooter'>" + result.UserInfoWorkPhone + "</label></li>");

            $("#UserInfoList").append("<li  class='UserInfoSinger'><label class='UserInfoHeader'>用户现居地址:</label><label class='UserInfoFooter'>" + result.UserCurrentAddress + "</label></li>");
            $("#UserInfoList").append("<li  class='UserInfo'><label class='UserInfoHeader'>用户QQ:</label><label class='UserInfoFooter'>" + result.UserInfoQQ + "</label></li>");
            $("#UserInfoList").append("<li  class='UserInfoSinger'><label class='UserInfoHeader'>用户介绍:</label><label class='UserInfoFooter'>" + result.UserInfoDetails + "</label></li>");
            $("#UserInfoList").append("<li  class='UserInfo'><label class='UserInfoHeader'>用户角色:</label><label class='UserInfoFooter'>" + result.RoleID + "</label></li>");

            $("#UserInfoList").append("<li  class='UserInfoSinger'><label class='UserInfoHeader'>用户账号:</label><label class='UserInfoFooter'>" + result.UserID + "</label></li>");
        },
    });
}
//页面加载完成后
$(document).ready(function () {
    GetUserInfo();
});

//请求核心技能信息
function UserInfoAClick() {
    $.ajax({
        type: 'post',
        dataType: 'json',
        url: '/UserInfo/GetCoreSkillsByAJAX',
        success: function (result) {
            $("#UserInfoCoreSkillsList").html("");
            $("#UserInfoCoreSkillsList").append(" <tr class='UserInfoCoreSkillsListItem'><td>角色</td><td>职业</td><td>技能</td><td>等级</td><td>等级评价</td></tr >");
            for (var i = 0; typeof (result[i]) !== "undefined"; i++) {
                $("#UserInfoCoreSkillsList").append(" <tr class='UserInfoCoreSkillsListItem'><td>" + result[i].Role.RoleName +"</td><td>"+result[i].Professional.ProfessionalName+"</td><td>"+result[i].CoreSkills.CoreSkillsName+"</td><td>"+result[i].CoreLever.CoreLeverNum+"</td><td>"+result[i].CoreLever.CoreLeverDetails+"</td></tr >");
            }
        },
    });
};
//请求专业技能信息
function UserInfoBClick() {
    $.ajax({
        type: 'post',
        dataType: 'json',
        url: '/UserInfo/GetTeachSkillsByAJAX"',
        success: function (result) { },
    });
};
//请求角色和职业信息
function UserInfoCClick() {
    $.ajax({
        type: 'post',
        dataType: 'json',
        url: '/UserInfo/GetRolesByAJAX',
        success: function (result) { },
    });
    return false;
};
