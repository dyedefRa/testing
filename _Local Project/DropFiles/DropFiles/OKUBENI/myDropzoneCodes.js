$(document).ready(function () {
    _dropzone = function (callback) {
        Dropzone.options.dropzoneForm = {
            autoProcessQueue: false,
            uploadMultiple: true,
            maxFiles: 20,
            parallelUploads: 20,
            addRemoveLinks: true,
            dictRemoveFile: "Sil",
            dictRemoveFileConfirmation: "Silmek istediğinizden emin misiniz?",
            dictCancelUpload: "İptal Et",
            dictUploadCanceled: "İptal etmek istediğinize emin misiniz?",
            init: function () {
                var submitButton = document.querySelector("#submit-all-file");
                var myDropzone = this;
                submitButton.addEventListener("click", function () {
                    myDropzone.processQueue();
                });

                if (typeof callback === 'function') {
                    callback(myDropzone);
                }
            }
        };
    }
});