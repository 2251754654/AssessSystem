var CoreManage = new Vue({
    el: '#CoreManage',
    data: {
        //对象数组
        coreSkillsList: [],
        //对象数组中每一个对象临时存储
        coreSkillsObj: {
            CoreSkillsID: '',
            CoreSkillsGUID: '',
            CoreSkillsName: '',
            CoreSkillsDetails: '',
        },
        leverList: [],
        LeverItem: {
            CoreLeverNum: '',
            CoreSkillsID: '',
            CoreLeverDetails: '',
        },
    },
    methods: {
        updateCoreSkills: function () {
            var formJson = JSON.stringify(this.coreSkillsObj);
            this.$http.post('/CoreSkills/UpdateCoreSkills', formJson, { emulateJSON: true }).then(function (success) {
                alert("Update Success");
                this.findCoreSkills();
                //提示窗体
            }, function (error) {
                alert("失败!");
            });
        },
        daleteCoreSkills: function (index) {
            this.coreSkillsObj = this.coreSkillsList[index];
            var formJson = JSON.stringify(this.coreSkillsObj);
            this.$http.post('/CoreSkills/DeleteCoreSkills', formJson, { emulateJSON: true }).then(function (success) {
                this.findCoreSkills();
                //提示窗体
                //alert("Delete Success");
            }, function (error) {
                alert("失败!");
            });
        },
        findCoreSkills: function () {
            this.$http.get('/CoreSkills/FindAllCoreSkills').then(function (success) {
                //数据处理
                this.coreSkillsList.splice(0, this.coreSkillsList.length);
                for (var item = 0; item < success.data.length; item++) {
                    var obj = {
                        CoreSkillsID: success.data[item].CoreSkillsID,
                        CoreSkillsGUID: success.data[item].CoreSkillsGUID,
                        CoreSkillsName: success.data[item].CoreSkillsName,
                        CoreSkillsDetails: success.data[item].CoreSkillsDetails
                    };
                    this.coreSkillsList.push(obj);
                }
            }, function (error) {
                alert("失败");
            });
        },
        insertCoreSkills: function () {
            var formJson = JSON.stringify(this.coreSkillsObj);
            this.$http.post('/CoreSkills/InsertCoreSkills', formJson, { emulateJSON: true }).then(function (success) {
                this.findCoreSkills();
                //提示窗体
                alert("Insert Success");
            }, function (error) {
                alert("失败!");
            });
        },
        GetCoreSkills: function (index) {
            this.coreSkillsObj = this.coreSkillsList[index];
        },
        /**************************************************************/
        //添加等级
        insertLever: function () {
            var formJson = JSON.stringify(this.LeverItem);
            this.$http.post('/CoreSkills/InsertLever', formJson, { emulateJSON: true }).then(function (success) {
                alert("InsertLever Success");
            }, function (error) {
                alert("失败");
            });
        },
        //查询等级
        findLeverList: function (index) {
            this.leverList.splice(0, this.leverList.length);
            var obj = { CoreSkillsID: this.coreSkillsList[index].CoreSkillsID };
            var formJson = JSON.stringify(obj);
            this.$http.post('/CoreSkills/FindAllLever', formJson).then(function (success) {
                //数据处理
                for (var item = 0; item < success.data.length; item++) {
                    var obj = {
                        CoreLeverID: success.data[item].CoreLeverID,
                        CoreLeverNum: success.data[item].CoreLeverNum,
                    };
                    this.leverList.push(obj);
                }
            }, function (error) {

                alert("失败");
            });
        },

        //删除等级
        deleteLever: function (firstIndex, secondIndex) {
            if (confirm("确认删除技能<" + this.coreSkillsList[firstIndex].CoreSkillsName + ">下的:<" + this.leverList[secondIndex].CoreLeverNum + ">等级吗？")) {
                var obj = { CoreSkillsID: this.coreSkillsList[firstIndex].CoreSkillsID, CoreLeverID: this.leverList[secondIndex].CoreLeverID };
                var formJson = JSON.stringify(obj);
                this.$http.post('/CoreSkills/DeleteLever', formJson, { emulateJSON: true }).then(function (success) {
                    //提示窗体
                    alert("DeleteLever Success");
                }, function (error) {
                    alert("失败!");
                });
            }
        },
        GetCoreSkillsID: function (index) {
            this.LeverItem.CoreSkillsID = this.coreSkillsList[index].CoreSkillsID;
        }
    },
    mounted() {
        this.findCoreSkills();
    },
});