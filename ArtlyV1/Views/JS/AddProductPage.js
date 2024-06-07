const fileUpload = document.querySelector('input[type=file]');

function previewFile() {
    var preview = document.getElementById('ContentPlaceHolder2_productImage');
    var file = document.querySelector('input[type=file]').files[0];
    var reader = new FileReader();

    reader.onloadend = function () {
        preview.src = reader.result;
    }

    if (file) {
        reader.readAsDataURL(file);
    } else {
        preview.src = "";
    }
}

fileUpload.addEventListener('change', previewFile);