var app = {};

app.shwdialog = function (title,url) {
    parent.layer.open({
        type: 2,
        title: 'layer mobile页',
        shadeClose: true,
        shade: 0.8,
        area: ['50%', '90%'],
        content: url
    });
}