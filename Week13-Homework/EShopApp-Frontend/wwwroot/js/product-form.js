(function () {
    const MAX_FILE_SIZE = 5 * 1024 * 1024;
    const ALLOWED_TYPES= ['image/png','image/jpeg'];

    const form = document.querySelector('form[data-ajax-product-form]');
    if (!form) return;

    const fileInput = document.getElementById('image-file');
    const preview = document.getElementById('product-image-preview');
    const submitBtn = form.querySelector('button[type="submit"]');
    const summary = form.querySelector('[data-valsummary]');
    const fileError = form.querySelector('[data-valmsg-for="imageFile"]');

    function checkFile(file){
        if(!ALLOWED_TYPES.includes(file.type)) return 'Lütfen png, jpg ya da jpeg formatında bir resim seçin.';
        if(file.size>MAX_FILE_SIZE) return 'Resim en fazla 5 mb olabilir.';
        return null;
    }

    fileInput?.addEventListener('change', function (event) {
        if(fileError) file.Error.textContent='';
        const file = event.target.files?.[0];
        if (!file || !preview) return;

        const problem = checkFile(file);
        if(problem){
            if(fileError) fileError.textContent = problem;
            fileInput.value = '';
            return;
        }
        
        const reader = new FileReader();
        reader.onload = function (e) {
            preview.src = e.target?.result;
            preview.hidden = false;
        }
        reader.readAsDataURL(file);
    });

    function clearErrors() {
        form.querySelectorAll('[data-valmsg-for]').forEach(function (el) {
            el.textContent = '';
        });
        if (summary) summary.textContent = '';
    };

    function showErrors(errors) {
        const general = [];
        Object.entries(errors || {}).forEach(function ([key, messages]) {
            const span = key ? form.querySelector('[data-valmsg-for="' + key + '"]') : null;
            if (span)
                span.textContent = messages.join(' ')
            else
                general.push(...messages);
        });
        if (general.length && summary) summary.textContent = general.join(' ');
    }

    form.addEventListener('submit', async function (event) {
        event.preventDefault();
        clearErrors();
        if (submitBtn) submitBtn.disabled = true;

        try {
            const response = await fetch(form.action, {
                method: 'POST',
                body: new FormData(form)
            });
            const result = await response.json().catch(function () { return null; });
            if (response.ok && result?.success) {
                console.log("Başarılı.")
                window.location.href = result.redirectUrl;
                return;
            }
            showErrors(result?.errors ?? { '': ['İşlem sırasında bir hata oluştu.'] });
        } catch (error) {
            showErrors({ '': ['Sunucuya ulaşılamadı.']});
        } finally {
            if (submitBtn) submitBtn.disabled = false;
        }
    });

})();