$("body").on("click", ".close", function (evt) {
    let id = '#' + evt.target.id;
    let idd = $(id).parent()[0].id;
    let iddname = $('#' + idd).attr('name');
    // indexOf method in object array
    let pos = array.map(function (e) {
        return e.name;
    }).indexOf(iddname);

    // delete array
    array.splice(pos, 1);

    // 依照檔名刪除陣列
    fd.delete(iddname);
    $('#' + idd).remove();
});