
function ReadTextFile() {
    var fs = require("fs");
    fs.readFile('./text.html', function (err, data) {
        if (err) {
            return console.log("读取失败！");
        }
        return console.log(data.toLocaleString());
    });
    console.log("程序执行成功！");
}

function ListenReauest() {
    var http = require('http');
    http.createServer(function (request, response) {

        // 发送 HTTP 头部 
        // HTTP 状态值: 200 : OK
        // 内容类型: text/plain
        response.writeHead(200, { 'Content-Type': 'text/plain' });

        // 发送响应数据 "Hello World"
        response.end('hello ');
    }).listen(8888);
    console.log('Server running at http://127.0.0.1:8888/');
}


module.exports.ReadTextFile = ReadTextFile;
module.exports.ListenReauest = ListenReauest;