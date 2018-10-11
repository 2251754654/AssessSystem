var TeachManage = new Vue({
    el: '#TeachManage',
    data: {
        //对象数组
        teachSkillsList: [],
        //对象数组中每一个对象临时存储
        teachSkillsObj: {
            TeachSkillsID: '',
            TeachSkillsGUID: '',
            TeachSkillsName: '',
            TeachSkillsDetails: '',
        },
        leverTeachList: [],
        leverTeachItem: {
            TeachSkillsID: '',
            TeachLeverNum: '',
            TeachLeverDetails: '',
        },
    },
    methods: {
        updateTeachSkills: function () {
            var formJson = JSON.stringify(this.teachSkillsObj);
            this.$http.post('/TeachSkills/UpdateTeachSkills', formJson, { emulateJSON: true }).then(function (success) {
                alert("Update Success");
                this.findTeachSkills();
                //提示窗体
            }, function (error) {
                alert("失败!");
            });
        },
        daleteTeachSkills: function (index) {
            this.teachSkillsObj = this.teachSkillsList[index];
            var formJson = JSON.stringify(this.teachSkillsObj);
            this.$http.post('/TeachSkills/DeleteTeachSkills', formJson, { emulateJSON: true }).then(function (success) {
                this.findTeachSkills();
                //提示窗体
                //alert("Delete Success");
            }, function (error) {
                alert("失败!");
            });
        },
        findTeachSkills: function () {
            this.$http.get('/TeachSkills/FindAllTeachSkills').then(function (success) {
                //数据处理
                this.teachSkillsList.splice(0, this.teachSkillsList.length);
                for (var item = 0; item < success.data.length; item++) {
                    var obj = {
                        TeachSkillsID: success.data[item].TeachSkillsID,
                        TeachSkillsGUID: success.data[item].TeachSkillsGUID,
                        TeachSkillsName: success.data[item].TeachSkillsName,
                        TeachSkillsDetails: success.data[item].TeachSkillsDetails
                    };
                    this.teachSkillsList.push(obj);
                }
            }, function (error) {
                alert("失败");
            });
        },
        insertTeachSkills: function () {
            var formJson = JSON.stringify(this.teachSkillsObj);
            this.$http.post('/TeachSkills/InsertTeachSkills', formJson, { emulateJSON: true }).then(function (success) {
                this.findTeachSkills();
                //提示窗体
                alert("Insert Success");
            }, function (error) {
                alert("失败!");
            });
        },
        GetTeachSkills: function (index) {
            this.teachSkillsObj = this.teachSkillsList[index];
        },
        /**************************************************************/
        //添加等级
        insertLever: function () {
            var formJson = JSON.stringify(this.leverTeachItem);
            this.$http.post('/TeachSkills/InsertLever', formJson, { emulateJSON: true }).then(function (success) {
                alert("InsertLever Success");
            }, function (error) {
                alert("失败");
            });
        },
        //查询等级
        findLeverList: function (index) {
            this.leverTeachList.splice(0, this.leverTeachList.length);
            var obj = { TeachSkillsID: this.teachSkillsList[index].TeachSkillsID };
            var formJson = JSON.stringify(obj);
            this.$http.post('/TeachSkills/FindAllLever', formJson).then(function (success) {
                //数据处理
                for (var item = 0; item < success.data.length; item++) {
                    var obj = {
                        TeachLeverID: success.data[item].TeachLeverID,
                        TeachLeverNum: success.data[item].TeachLeverNum,
                    };
                    this.leverTeachList.push(obj);
                }
            }, function (error) {

                alert("失败");
            });
        },
        //删除等级
        deleteLever: function (firstIndex, secondIndex) {
            if (confirm("确认删除技能<" + this.teachSkillsList[firstIndex].TeachSkillsName + ">下的:<" + this.leverTeachList[secondIndex].TeachLeverNum + ">等级吗？")) {
                var obj = { TeachSkillsID: this.teachSkillsList[firstIndex].TeachSkillsID, TeachLeverID: this.leverTeachList[secondIndex].TeachLeverID };
                var formJson = JSON.stringify(obj);
                this.$http.post('/TeachSkills/DeleteLever', formJson, { emulateJSON: true }).then(function (success) {
                    //提示窗体
                    alert("DeleteLever Success");
                }, function (error) {
                    alert("失败!");
                });
            }
        },
        GetTeachSkillsIDX: function (index) {
            this.leverTeachItem.TeachSkillsID = this.teachSkillsList[index].TeachSkillsID;
        },
    },
    mounted() {
        this.findTeachSkills();
    },
});