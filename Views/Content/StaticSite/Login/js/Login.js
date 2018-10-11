new Vue({
    el: '#login',
    data: {
        UserName: '',
        Password: '',
        SerialNumber: -1,
        msg: '',
    },
    methods: {
        login: function () {
            this.SerialNumber = 2;
            window.setTimeout(function () { }, 2000);
            var json = { UserName: this.UserName, Password: this.Password };
            this.$http.post("/Login/Login", json, { emulateJSON: true }).then(
                function (success) {
                    if (success.data.UserPassword == "1") {
                        this.SerialNumber = 1;
                        window.setTimeout(function () {
                            window.location.href = "/Home/Index";
                        }, 1000);
                    }
                    else {
                        this.SerialNumber = 0;
                    }
                }, function (error) {
                    alert("服务器繁忙！");
                }
            );
        },
        focus: function () {
            this.SerialNumber = -1;
        }
    },
});