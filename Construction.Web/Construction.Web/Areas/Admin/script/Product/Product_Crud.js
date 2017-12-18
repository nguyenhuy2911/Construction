
var Upload360 = {
    _filecontainer: ".list-360file",
    initial: function (link) {
        var html = "";
        if (link != null && link != "") {
            html = '<div class="list-group-item list-group-item-success">' +
                                        '<a  class="btn-link pull-right btn-loadding" onclick="Upload360.deletefile(this)" >' +
                                            '<span class="glyphicon glyphicon-remove"></span>' +
                                        '</a>' +
                                        '<a href="' + link + '" target="_blank">' +
                                          '' + link +
                                        '</a>' +
                                '</div>';
        }


        $(Upload360._filecontainer).html(html);
    },
    upload: function (btn, id, file) {
        var formData = new FormData();
        formData.append("id", id);
        formData.append("File_360", file);
        $.ajax({
            type: "POST",
            enctype: 'multipart/form-data',
            processData: false,
            contentType: false,
            cache: false,
            dataType: "json",
            data: formData,
            url: "/admin/san-pham/upload-360",
            beforeSend: function () {
                $(btn).button('loading')
            },
            error: function (jqXHR) {
                $(btn).button('reset');
            },
            success: function (response) {
                $(btn).button('reset');
                if (response.StatusCode == 0) {
                    Upload360.initial(response.Results.Link);
                }
            }
        });
    },
    deletefile: function (btn) {
        $(btn).button('loading')
        //$.ajax({
        //    type: "POST",
        //    url: "/admin/san-pham/upload-360",
        //    mimeType :"multipart/form-data",
        //    beforeSend: function(){
        //        $(btn).button('loading')
        //    },
        //    success: function (response) {
        //        $(btn).button('reset');
        //        if (response.status) {

        //        }
        //    }
        //});
    }
}

var editor = CKEDITOR.replace('Description');
var myDropzone = new Dropzone("div#div-thumb", {
    autoProcessQueue: true,
    url: "/admin/san-pham/save-image",
    params: { id: id },
    acceptedFiles: "image/jpeg, image/jpg, image/png",
    parallelUploads: 1,
    maxFiles: 1,
    uploadMultiple: false,
    addRemoveLinks: true,
    thumbnailWidth: 250,
    thumbnailHeight: 250,
    init: function () {
        var thisDropzone = this;

        //var url = [thumbImg];
        var blob = new Blob([thumbImg], { type: 'images' });
        reader = new FileReader();
        reader.readAsDataURL(blob);
        var mockFile = {
            name: productName,
            id: id,
            path: thumbImg,
            size: blob.size,
            accepted: true,
            kind: 'image'
        };
        thisDropzone.options.addedfile.call(thisDropzone, mockFile);
        thisDropzone.files.push(mockFile);
        thisDropzone.createThumbnailFromUrl(mockFile, thumbImg);
        thisDropzone.emit("success", mockFile);
        thisDropzone.emit("complete", mockFile);
    },
    //    removedfile: function (file, _) {
    //        $.ajax({
    //            type: "POST",
    //            url: "/images/delete-image",
    //            data: { id: file.id },
    //            dataType: "json",
    //            success: function (response) {
    //                if (response.StatusCode != 0)
    //                    showErrorMessage(response.StatusMessage, "#div-crud-modal");
    //                else {
    //                    showSuccessMessage(response.StatusMessage, "#div-crud-modal");
    //                    var _ref;
    //                    if (file.previewElement) {
    //                        if ((_ref = file.previewElement) != null) {
    //                            _ref.parentNode.removeChild(file.previewElement);
    //                        }
    //                    }
    //                }
    //            }
    //        });
    //        return this._updateMaxFilesReachedClass();
    //    },

});
myDropzone.on("maxfilesexceeded", function (file) {
    myDropzone.removeFile(file);
});

$(function () {
    if (id > 0)
        $(".update-view").show()
    else
        $(".update-view").hide()

    $('#chk-status').bootstrapToggle({
        on: 'Kích hoạt',
        off: 'Khóa'
    });
    $('#chk-status').change(function () {
        if ($(this).prop('checked') == true)
            $("#Status").val(ACTIVE_TYPE.ACTIVE)
        else
            $("#Status").val(ACTIVE_TYPE.BLOCK)
    });

    $('#Upload360').on('click', function () {
        Upload360.upload(this, id, document.getElementById("File_360").files[0]);
    });

    $('.clear-upload-file').click(function () {
        $('.file-preview').attr("data-content", "").popover('hide');
        $('.file-preview-filename').val("");
        $('.clear-upload-file').hide();
        $('.file-preview-input input:file').val("");
        $(".file-preview-input-title").text("Browse");
    });

    $(".file-preview-input input:file").change(function () {
        var file = this.files[0];
        var reader = new FileReader();
        reader.onload = function (e) {
            $(".file-preview-input-title").text("Change");
            $(".clear-upload-file").show();
            $(".file-preview-filename").val(file.name);
        }
        reader.readAsDataURL(file);
    });
    Upload360.initial(Link_360);
});