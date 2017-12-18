var _PRODUCT = null;

var PRODUCT = function () {
    this.variable = {
        pageIndex: 0,
        pageSize: 10
    };
    this.DataTables = null;
}
PRODUCT.prototype = new Base();

PRODUCT.prototype.init = function () {
    this.regisEvent();
    this.getList();
}

PRODUCT.prototype.regisEvent = function () {
    var $this = this;

}

PRODUCT.prototype.getList = function () {
    var $this = this;
    var page = new Page(0, 10);
    var column = JSON.parse(columnGrid);
    var columnRender = [];
    $.each(column, function (index, objColumn) {
        if (objColumn.data == "Action") {
            objColumn.render = function (data, type, row, meta) {
                var $btnEdit = '<a class="btn btn-info" href="/admin/san-pham/sua/' + row.Id + '">'
                             + '<span class="glyphicon glyphicon-pencil" aria-hidden="true"></span> Sửa</a>';
                var $btnDelete = ''; //'<a class="btn btn-danger"><span class="glyphicon glyphicon-trash" aria-hidden="true"></span> Xóa</a>';
                var $div = $("<div>").append($btnEdit).append($btnDelete);
                return $div.html();
            }
        }
        if (objColumn.data == "Status") {
            objColumn.render = function (data, type, row, meta) {
                if (row.Status == 1)
                    return '<button type="button" class="btn btn-success btn-xs">Đã kích hoạt</button>';
                else
                    return '<button type="button" class="btn btn-danger btn-xs">Bị khóa</button>';

            }
        }
        if (objColumn.data == "Thumbnail") {
            objColumn.render = function (data, type, row, meta) {
                return '<img src="' + row.Thumbnail + '" style="width: 100px; height: 70px" />';

            }
        }

        columnRender.push(objColumn);
    })
    $this.DataTables = $('#grid-data').DataTable({
        responsive: true,
        processing: true,
        serverSide: true,
        searching: false,
        autoWidth: false,
        keys: true,
        columns: column,
        ajax: {
            url: '/admin/san-pham/get-list',
            dataType: "json",
            type: 'POST',
            data: function () {
                var model = {};
                model.Page = page;
                return model;
            },
            dataFilter: function (response) {
                var data = JSON.parse(response);
                var jsonObj = {};
                jsonObj.recordsTotal = data.TotalRow;
                jsonObj.recordsFiltered = data.TotalRow;
                jsonObj.data = data.Results;
                return JSON.stringify(jsonObj);
            }
        },

    })
    .on('page.dt', function () {
        var info = $this.DataTables.page.info();
        page = new Page(info.page, info.length)
    })
    .on('length.dt', function (e, settings, len) {
        page = new Page(0, len)
    });

}

$(function () {
    _PRODUCT = new PRODUCT();
    _PRODUCT.init();
});