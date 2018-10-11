    var userInfo = new Vue({
        el: '#bodyVue',
        data: {
            id: '1',
            name: '付博文',
            age: '22',
            birthday: '1998-08-08',
            sex: '男',
            phone: '17854118859',
            workPhone: '17854118859',
            qq: '2251754654',
            email: '2251754654@qq.com',
            address: '山东济南',
            currentAddress: '山东济南',
            imgUser: '头像',
            details: '个人简介',
            update: false,//是否显示提交按钮
            hide: true,//是否显示修改按钮
        },
        methods: {
            updateUser: function () {
                if (this.update) {
                    this.update = false;
                } else {
                    this.update = true;
                }
            },//是否隐藏提交按钮
            updateHide: function () {
                if (this.hide) {
                    this.hide = false;
                } else {
                    this.hide = true;
                }
            },//是否隐藏更新按钮
            submitUser: function () {
                //提交表单数据
                //表单序列化
                var formData = {
                    UserInfoID: this.id,
                    UserInfoName: this.name,
                    UserInfoBirthday: this.birthday,
                    sex: this.sex,
                    UserPhone: this.phone,
                    UserInfoWorkPhone: this.workPhone,
                    UserInfoQQ: this.qq,
                    UserInfoEmail: this.email,
                    UserInfoAddress: this.address,
                    UserCurrentAddress: this.currentAddress,
                    imgUser: this.imgUser,
                    UserInfoDetails: this.details
                };
                var formJson = JSON.stringify(formData);
                this.post('/UserInfo/UpdateUserInfo', formJson);
            },//提交数据
            FindUserIn: function () {  //填充查询的数据

            },
            post: function (url, formJson) {
                this.$http.post(url, formJson, { emulateJSON: true }).then(function (result) {
                    alert("修改成功!");
                    return result;
                }, function (error) {
                    alert("服务器错误");
                    return error;
                });
            },
        },
        filters: {
            //过滤器
        },
    });
