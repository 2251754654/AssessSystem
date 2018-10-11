var roleManage = new Vue({
    el: '#RoleManage',
    data: {
        //对象数组
        roleList: [],
        //对象数组中每一个对象临时存储
        roleObj: {
            Guid: '',
            RoleName: '',
            Specific: '',
            State: '',
            CreateTime: '',
            UpdateTime: '',
            VisitCount:'',
        },
        //未分配的职业列表
        jobList: [],
        jobListCopy: [],
        //从未分配的职业列表检索数据
        findInput: '',

        //已分配的职业列表
        roleJobList: [],
    },
    methods: {
        GetRole: function () {
            this.$http.get('http://localhost:65363/Api/Role/Get').then(function (success) {
                //数据处理
                this.roleList.splice(0, this.roleList.length);
                for (var item = 0; item < success.data.length; item++) {
                    var obj = {
                        Guid: success.data[item].Guid,
                        RoleName: success.data[item].RoleName,
                        Specific: success.data[item].Specific,
                        State: success.data[item].State,
                        CreateTime: success.data[item].CreateTime,
                        UpdateTime: success.data[item].UpdateTime,
                    };
                    this.roleList.push(obj);
                }
            }, function (error) {
                $.growl.error({
                    title: "提示",
                    message: "数据加载失败！"
                });
            });
        },

        updateRole: function () {
            var formJson = JSON.stringify(this.roleObj);
            this.$http.post('/Role/UpdateRole', formJson, { emulateJSON: true }).then(function (success) {
                this.findRole();
                //提示窗体
                $.growl.notice({
                    title: "提示",
                    message: "数据更新成功！"
                });
            }, function (error) {
                $.growl.error({
                    title: "提示",
                    message: "数据更新失败！"
                });
            });
        },
        daleteRole: function (index) {
            if (!confirm("确认删除吗？")) {
                return;
            }
            this.roleObj = this.roleList[index];
            var formJson = JSON.stringify(this.roleObj);
            this.$http.post('/Role/DeleteRole', formJson, { emulateJSON: true }).then(function (success) {
                this.findRole();
                $.growl.notice({
                    title: "提示",
                    message: "数据删除成功！"
                });
            }, function (error) {
                $.growl.error({
                    title: "提示",
                    message: "数据删除失败！"
                });
            });
        },
        insertRole: function () {
            var formJson = JSON.stringify(this.roleObj);
            this.$http.post('/Role/InsertRole', formJson, { emulateJSON: true }).then(function (success) {
                this.findRole();
                //提示窗体
                $.growl.notice({
                    title: "提示",
                    message: "数据插入成功！"
                });
            }, function (error) {
                $.growl.error({
                    title: "提示",
                    message: "数据插入失败！"
                });
            });
        },
        GetRole: function (index) {
            this.roleObj = this.roleList[index];
        },
        findJob: function () {
            this.$http.get('/Job/FindAllJob').then(function (success) {
                //数据处理
                this.jobList.splice(0, this.jobList.length);
                for (var item = 0; item < success.data.length; item++) {
                    var obj = {
                        ProfessionalID: success.data[item].ProfessionalID,
                        ProfessionalName: success.data[item].ProfessionalName,
                    };
                    this.jobList.push(obj);
                }
                this.jobListCopy = this.jobList;
            }, function (error) {
                $.growl.error({
                    title: "提示",
                    message: "数据加载失败！"
                });
            });
        },
        //分配职业
        allotProfession: function (roleIndex, jobIndex) {
            //选中的数据关系添加到数据库
            if (confirm("确认给角色<" + this.roleList[roleIndex].RoleName + ">分配职业:<" + this.jobList[jobIndex].ProfessionalName + ">吗？")) {
                var obj = { RoleID: this.roleList[roleIndex].RoleID, ProfessionalID: this.jobList[jobIndex].ProfessionalID };
                var formJson = JSON.stringify(obj);
                this.$http.post('/Role/InsertRoleProfessional', formJson, { emulateJSON: true }).then(function (success) {
                    //提示窗体
                    alert("InsertRoleProfessional Success");
                    this.refreshAllotJobList(roleIndex);
                }, function (error) {
                    $.growl.error({
                        title: "提示",
                        message: "数据分配失败！"
                    });
                });
            }
        },
        findJobList: function () {
            //检索
            var result = [];
            for (var i = 0; i < this.jobListCopy.length; i++) {
                if (this.jobListCopy[i].ProfessionalName.indexOf(this.findInput) != -1) {
                    result.push(this.jobListCopy[i]);
                }
            }
            this.jobList = result;
        },
        loseFocus: function () {

        },
        //显示选择的角色的所有职业
        showSelectedInfo: function (index) {
            this.roleJobList.splice(0, this.roleJobList.length);
            var obj = { RoleID: this.roleList[index].RoleID };
            var json = JSON.stringify(obj);
            this.$http.post('/Job/AllotedProfessional', json, { emulateJSON: true }).then(function (success) {
                //数据处理
                for (var item = 0; item < success.data.length; item++) {
                    var obj1 = {
                        ProfessionalID: success.data[item].ProfessionalID,
                        ProfessionalName: success.data[item].ProfessionalName,
                    };
                    this.roleJobList.push(obj1);
                }

                $("#DropList table:not(#" + index + ")").hide();
                if ($("#" + index + "").is(":hidden")) {
                    $("#" + index + "").show();
                } else {
                    $("#" + index + "").hide();
                }
            }, function (error) {
                $.growl.error({
                    title: "提示",
                    message: "数据加载失败！"
                });
            });
        },
        DeleteAllotJob: function (rindex, pindex) {
            var ProfessionalID = this.roleJobList[pindex].ProfessionalID;
            var RoleID = this.roleList[rindex].RoleID;

            if (confirm("确定删除<" + this.roleJobList[pindex].ProfessionalName + ">吗？")) {
                var json = JSON.stringify({ ProfessionalID: ProfessionalID, RoleID: RoleID });
                this.$http.post("/Job/DeleteAllotJob", json, { emulateJSON: true }).then(function (success) {

                    alert("DeleteAllotJobSuccess");
                    this.refreshAllotJobList(rindex);
                }, function (error) {
                    $.growl.error({
                        title: "提示",
                        message: "数据删除失败！"
                    });
                });
            }

        },
        refreshAllotJobList: function (index) {
            this.roleJobList.splice(0, this.roleJobList.length);
            var obj = { RoleID: this.roleList[index].RoleID };
            var json = JSON.stringify(obj);
            this.$http.post('/Job/AllotedProfessional', json, { emulateJSON: true }).then(function (success) {
                //数据处理
                for (var item = 0; item < success.data.length; item++) {
                    var obj = {
                        ProfessionalID: success.data[item].ProfessionalID,
                        ProfessionalName: success.data[item].ProfessionalName,
                    };
                    this.roleJobList.push(obj);
                }
            }, function (error) {
                $.growl.error({
                    title: "提示",
                    message: "数据刷新失败！"
                });
            });
        }
    },
    //监视查询文本框的变化
    watch: {
        findInput() {
            this.findJobList();
        }
    },
    mounted() {
        this.GetRole();
    },
});