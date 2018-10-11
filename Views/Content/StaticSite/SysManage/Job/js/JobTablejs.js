var JobManage = new Vue({
    el: '#JobManage',
    data: {
        //对象数组
        jobList: [],
        //对象数组中每一个对象临时存储
        jobObj: {
            ProfessionalID: '',
            ProfessionalName: '',
            ProfessionalDetails: '',
        },
        findInput: '',//查询条件
        coreSkillsList: [],
        coreSkillsListCopy: [],

        findTeachInput: '',//查询条件
        teachSkillsList: [],
        teachSkillsListCopy: [],

        selectedCoreSkillsList: [],
        selectedTeachSkillsList: [],
    },
    methods: {
        updateJob: function () {
            var formJson = JSON.stringify(this.jobObj);
            this.$http.post('/Job/UpdateJob', formJson, { emulateJSON: true }).then(function (success) {
                alert("Update Success");
                this.findjob();
                //提示窗体
            }, function (error) {
                alert("失败!");
            });
        },
        daleteJob: function (index) {
            this.jobObj = this.jobList[index];
            var formJson = JSON.stringify(this.jobObj);
            this.$http.post('/Job/DeleteJob', formJson, { emulateJSON: true }).then(function (success) {
                this.findJob();
                //提示窗体
                //alert("Delete Success");
            }, function (error) {
                alert("失败!");
            });
        },
        findJob: function () {
            this.$http.get('/Job/FindAllJob').then(function (success) {
                //数据处理
                this.jobList.splice(0, this.jobList.length);
                for (var item = 0; item < success.data.length; item++) {
                    var obj = {
                        ProfessionalID: success.data[item].ProfessionalID,
                        ProfessionalName: success.data[item].ProfessionalName,
                        ProfessionalDetails: success.data[item].ProfessionalDetails
                    };
                    this.jobList.push(obj);
                }
            }, function (error) {
                alert("失败");
            });
        },
        insertJob: function () {
            var formJson = JSON.stringify(this.jobObj);
            this.$http.post('/Job/InsertJob', formJson, { emulateJSON: true }).then(function (success) {
                this.findJob();
                //提示窗体
                alert("Insert Success");
            }, function (error) {
                alert("失败!");
            });
        },
        GetJob: function (index) {
            this.jobObj = this.jobList[index];
        },
        //查询核心技能
        findCoreSkills: function () {
            this.$http.get('/CoreSkills/FindAllCoreSkills').then(function (success) {
                //数据处理
                this.coreSkillsList.splice(0, this.coreSkillsList.length);
                for (var item = 0; item < success.data.length; item++) {
                    var obj = {
                        CoreSkillsID: success.data[item].CoreSkillsID,
                        CoreSkillsName: success.data[item].CoreSkillsName,
                    };
                    this.coreSkillsList.push(obj);
                    this.coreSkillsListCopy = this.coreSkillsList;
                }
            }, function (error) {
                alert("失败");
            });
        },
        //分配核心技能
        allotCoreSkills: function (firstIndex, secondIndex) {
            if (confirm("确认给角色<" + this.jobList[firstIndex].ProfessionalName + ">分配核心技能:<" + this.coreSkillsList[secondIndex].CoreSkillsName + ">吗？")) {
                var obj = { ProfessionalID: this.jobList[firstIndex].ProfessionalID, CoreSkillsID: this.coreSkillsList[secondIndex].CoreSkillsID };
                var formJson = JSON.stringify(obj);
                this.$http.post('/Job/InsertProfessionalCoreSkills', formJson, { emulateJSON: true }).then(function (success) {
                    //提示窗体
                    this.refreshSelected(firstIndex);
                    alert("InsertProfessionalCoreSkills Success");
                }, function (error) {
                    alert("失败!");
                });
            }
        },
        //条件检索
        findCoreSkillsList: function () {
            //检索
            var result = [];
            for (var i = 0; i < this.coreSkillsListCopy.length; i++) {
                if (this.coreSkillsListCopy[i].CoreSkillsName.indexOf(this.findInput) != -1) {
                    result.push(this.coreSkillsListCopy[i]);
                }
            }
            this.coreSkillsList = result;
        },
        //查询框失去焦点
        loseFocus: function () {

        },
        /********************************************************************/
        //分配专业技能
        findTeachSkills: function () {
            this.$http.get('/TeachSkills/FindAllTeachSkills').then(function (success) {
                //数据处理
                this.teachSkillsList.splice(0, this.teachSkillsList.length);
                for (var item = 0; item < success.data.length; item++) {
                    var obj = {
                        TeachSkillsID: success.data[item].TeachSkillsID,
                        TeachSkillsName: success.data[item].TeachSkillsName,
                    };
                    this.teachSkillsList.push(obj);
                }
                this.teachSkillsListCopy = this.teachSkillsList;
            }, function (error) {
                alert("失败");
            });
        },
        //分配专业技能
        allotTeachSkills: function (firstIndex, secondIndex) {
            if (confirm("确认给角色<" + this.jobList[firstIndex].ProfessionalName + ">分配专业技能:<" + this.teachSkillsList[secondIndex].TeachSkillsName + ">吗？")) {
                var obj = { ProfessionalID: this.jobList[firstIndex].ProfessionalID, TeachSkillsID: this.teachSkillsList[secondIndex].TeachSkillsID };
                var formJson = JSON.stringify(obj);
                this.$http.post('/Job/InsertProfessionalTeachSkills', formJson, { emulateJSON: true }).then(function (success) {
                    //提示窗体
                    this.refreshSelected(firstIndex);
                    alert("InsertProfessionalTeachSkills Success");
                }, function (error) {
                    alert("失败!");
                });
            }
        },
        findTeachSkillsList: function () {
            //检索
            var result = [];
            for (var i = 0; i < this.teachSkillsListCopy.length; i++) {
                if (this.teachSkillsListCopy[i].TeachSkillsName.indexOf(this.findTeachInput) != -1) {
                    result.push(this.teachSkillsListCopy[i]);
                }
            }
            this.teachSkillsList = result;
        },
        loseTeachFocus: function () {

        },
        //显示已经分配的技能
        showSelectedInfo: function (index) {
            var obj = { ProfessionalID: this.jobList[index].ProfessionalID };
            var json = JSON.stringify(obj);
            this.$http.post('/CoreSkills/AllotCoreSkills', json, { emulateJSON: true }).then(function (success) {
                //数据处理
                this.selectedCoreSkillsList.splice(0, this.selectedCoreSkillsList.length);
                for (var item = 0; item < success.data.length; item++) {
                    var obj = {
                        CoreSkillsID: success.data[item].CoreSkillsID,
                        CoreSkillsName: success.data[item].CoreSkillsName,
                    };
                    this.selectedCoreSkillsList.push(obj);
                }
            }, function (error) {
                alert("失败");
            });
            this.$http.post('/TeachSkills/AllotTeachSkills', json, { emulateJSON: true }).then(function (success) {
                //数据处理
                this.selectedTeachSkillsList.splice(0, this.selectedTeachSkillsList.length);
                for (var item = 0; item < success.data.length; item++) {
                    var obj = {
                        TeachSkillsID: success.data[item].TeachSkillsID,
                        TeachSkillsName: success.data[item].TeachSkillsName,
                    };
                    this.selectedTeachSkillsList.push(obj);
                }
            }, function (error) {
                alert("失败");
            });
            $("#JobManage>table table:not(#c" + index + "):not(#t" + index + ")").hide();

            if ($("#c" + index + "").is(":hidden")) {
                $("#c" + index + "").show();
            } else {
                $("#c" + index + "").hide();
            }

            if ($("#t" + index + "").is(":hidden")) {
                $("#t" + index + "").show();
            } else {
                $("#t" + index + "").hide();
            }
        },
        refreshSelected: function (index) {
            var obj = { ProfessionalID: this.jobList[index].ProfessionalID };
            var json = JSON.stringify(obj);
            this.$http.post('/CoreSkills/AllotCoreSkills', json, { emulateJSON: true }).then(function (success) {
                //数据处理
                this.selectedCoreSkillsList.splice(0, this.selectedCoreSkillsList.length);
                for (var item = 0; item < success.data.length; item++) {
                    var obj = {
                        CoreSkillsID: success.data[item].CoreSkillsID,
                        CoreSkillsName: success.data[item].CoreSkillsName,
                    };
                    this.selectedCoreSkillsList.push(obj);
                }
            }, function (error) {
                alert("失败");
            });
            this.$http.post('/TeachSkills/AllotTeachSkills', json, { emulateJSON: true }).then(function (success) {
                //数据处理
                this.selectedTeachSkillsList.splice(0, this.selectedTeachSkillsList.length);
                for (var item = 0; item < success.data.length; item++) {
                    var obj = {
                        TeachSkillsID: success.data[item].TeachSkillsID,
                        TeachSkillsName: success.data[item].TeachSkillsName,
                    };
                    this.selectedTeachSkillsList.push(obj);
                }
            }, function (error) {
                alert("失败");
            });
        }

    },
    watch: {
        findInput() {
            this.findCoreSkillsList();
        },
        findTeachInput() {
            this.findTeachSkillsList();
        }
    },
    mounted() {
        this.findJob();
    },
});