tinymce.init({
    selector: 'textarea',
    plugins: "textcolor colorpicker hr autoresize charmap contextmenu directionality image imagetools link lists table searchreplace advlist visualblocks preview",
    toolbar: "insertfile undo redo |  ltr rtl  |  styleselect | bold italic forecolor backcolor | sizeselect  fontselect  fontsizeselect | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image  charmap table hr| searchreplace preview ",
    style_formats_merge: true,
    style_formats: [
        {
            title: 'Image Format', items: [
    { title: 'Image Left', selector: 'img', styles: { 'float': 'left', 'margin': '0 10px 0 10px' } },
    { title: 'Image Right', selector: 'img', styles: { 'float': 'right', 'margin': '0 0 10px 10px' } }
            ]
        }
    ],
    menubar: false,

    contextmenu_never_use_native: true,
    spellchecker_language: 'en',

    statusbar: false,
    height: 700,

    force_br_newlines: true,
    force_p_newlines: false,
    image_advtab: false,
    resize: false,
    image_dimensions: false

});