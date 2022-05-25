var btnContactFile = document.querySelector('#uploadFile');

async function addContactFile(fileInput, contactId) {

    const formData = new FormData();
    formData.append("file", fileInput.files[0]);
    formData.append("id", contactId);

    let label = document.querySelector('#uploadFileLabel');

    try {
        const response = await fetch('UploadFile', {
            method: 'POST',
            body: formData
        });
        const result = await response.json();
        console.log('Успех:', JSON.stringify(result));
        label.innerHTML = JSON.stringify(result);
        document.querySelector('#uploadFileBtn').style.display = 'none';

    } catch (error) {
        console.error('Ошибка:', error);
    }
}

btnContactFile.addEventListener('change', function () {
    var that = this;
    addContactFile (that, that.dataset.contactId);
});