var app = {};

app.shwdialog = function (title, url) {
    parent.layer.open({
        type: 2,
        title: 'layer mobile页',
        shadeClose: true,
        shade: 0.8,
        area: ['50%', '90%'],
        content: url
    });
}

app.changeRecharge = function (_this) {
    var czdm = $(_this).val();
    if (czdm.length == 0) {
        $("#rechargeDetail").hide();
        return;
    }
    $.post("/member/GetArchive", { czdm: czdm }, function (resp) {
        if (resp.code == 0) {
            $("#rechargeDetail").show();
            var html = template('rechargeDetailtmpl', resp.data);
            $("#rechargeDetail").html(html);
        }
    })
}

app.queryshangpin = function (spdm) {
    $.get("/", { spdm: spdm }, function (resp) {

    })
}

Date.prototype.format = function (format) //author: meizz
{
    var o = {
        "M+": this.getMonth() + 1, //month
        "d+": this.getDate(),    //day
        "h+": this.getHours(),   //hour
        "m+": this.getMinutes(), //minute
        "s+": this.getSeconds(), //second
        "q+": Math.floor((this.getMonth() + 3) / 3),  //quarter
        "S": this.getMilliseconds() //millisecond
    }
    if (/(y+)/.test(format)) format = format.replace(RegExp.$1,
    (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o) if (new RegExp("(" + k + ")").test(format))
        format = format.replace(RegExp.$1,
      RegExp.$1.length == 1 ? o[k] :
        ("00" + o[k]).substr(("" + o[k]).length));
    return format;
}