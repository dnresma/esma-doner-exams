(function () {

    document.querySelectorAll('form[data-ajax-form]').forEach(function (form) {
        const submitBtn = form.querySelector('button[type="submit"]');
        const summary = form.querySelector('[data-valsummary]');

        function clearErrors() {
            form.querySelectorAll('[data-valmsg-for]').forEach(function (el) {
                el.textContent = '';
            });
            if (summary) summary.textContent = '';
        }

        function showErrors(errors) {
            const general = [];
            Object.entries(errors || {}).forEach(function ([key, messages]) {
                const span = Array.from(form.querySelectorAll('[data-valmsg-for]')).find(function (el) {
                    return key !== '' && el.dataset.valmsgFor.toLowerCase() === key.toLowerCase();
                })
                if (span) {
                    span.textContent = messages.join(' ')
                } else {
                    general.push(...messages);
                }
            });
            if (general.length && summary) summary.textContent = general.join(' ');
        }

        form.addEventListener('submit', async function (event) {
            event.preventDefault();
            if (form.dataset.confirm && !window.confirm(form.dataset.confirm)) return;

            clearErrors();
            if (submitBtn) submitBtn.disabled = true;
            try {
                const response = await fetch(form.action, {
                    method: 'POST',
                    body: new FormData(form),
                    headers: { 'X-Requested-With': 'XMLHttpRequest' }
                });
                if (response.status === 401) {
                    window.location.href = '/Account/Login?returnUrl=' + encodeURIComponent(window.location.search);
                }
                const result = await response.json().catch(function () { return null; });
                if (response.ok && result && result.success) {
                    window.location.href = result.redirectUrl;
                    return;
                }
                showErrors(result?.errors ?? { '': ['İşlem sırasında bir hata oluştu.'] });
            } catch (error) {
                showErrors({ '': ['Sunucuya ulaşılamadı.'] });
            } finally {
                if (submitBtn) submitBtn.disabled = false;
            }
        })
    })


})();