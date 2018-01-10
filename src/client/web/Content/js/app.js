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