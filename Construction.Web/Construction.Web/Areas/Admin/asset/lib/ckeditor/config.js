/**
 * @license Copyright (c) 2003-2017, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function (config) {
    // Define changes to default configuration here. For example:
    // config.language = 'fr';
    // config.uiColor = '#AADC6E';
    config.height = '400px';
    // config.extraPlugins = 'imageuploader';
    config.filebrowserBrowseUrl = '/Areas/Admin/asset/lib/ckfinder/ckfinder.html',
    config.filebrowserImageBrowseUrl = '/Areas/Admin/asset/lib/ckfinder/ckfinder.html?type=Images',
    config.filebrowserUploadUrl = '/Areas/Admin/asset/lib/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
    config.filebrowserImageUploadUrl = '/Areas/Admin/asset/lib/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images';
    config.filebrowserFlashUploadUrl = '/Areas/Admin/asset/lib/ckfissnder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';

    
};
