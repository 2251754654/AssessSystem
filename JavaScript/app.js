var ReadFile = require("./ReadFile");

//ReadFile.ReadTextFile();

//�����¼�ģ��
var events = require("events");
//���¼�����
var emitter = new events.EventEmitter();
var eventHandler = function () {
    console.log("Handler_1");
    //����ڶ����¼���
    emitter.emit("eventName2");
}
var eventHandler2 = function () {
    console.log("Handle-----------r_2");
}
emitter.on("eventName", eventHandler);
emitter.on("eventName2", eventHandler2);
emitter.emit("eventName");
var buf = Buffer.from("this", "base64");
console.log(buf.toString("hex"));
console.log(buf.byteLength);

for (var  in { 1: 2, 3: 4 }) {
    console.log(i);
}



























ReadFile.ListenReauest();


