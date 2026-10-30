(() => {
    "use strict";

    const DEFAULT_REDIRECT = "/Admin/Category";
    const GENERIC_ERROR = "İşlem tamamlanamadı. Lütfen tekrar deneyin.";
    const NETWORK_ERROR = "Sunucuya ulaşılamadı. Bağlantınızı kontrol edin.";

    const forms = document.querySelectorAll("form[data-ajax-category-form]");
    forms.forEach((form) => form.addEventListener("submit", (e) => onSubmit(e, form)));

    async function onSubmit(event, form) {
        event.preventDefault();
        clearErrors(form);

        const submitButton = form.querySelector("button[type=submit]");
        setBusy(submitButton, true);

        try {
            const formData = buildFormData(form);
            const token = formData.get("__RequestVerificationToken");

            const response = await fetch(form.action, {
                method: "POST",
                body: formData,
                headers: {
                    "X-Requested-With": "XMLHttpRequest",
                    "Accept": "application/json",
                    ...(token ? { "RequestVerificationToken": token } : {})
                }
            });

            await handleResponse(response, form);
        } catch (err) {
            console.error(err);
            showSummary(form, [NETWORK_ERROR]);
        } finally {
            setBusy(submitButton, false);
        }
    }

    function buildFormData(form) {
        const formData = new FormData(form);
        const tokens = formData.getAll("__RequestVerificationToken");
        if (tokens.length > 1) {
            formData.set("__RequestVerificationToken", tokens[0]);
        }
        return formData;
    }

    async function handleResponse(response, form) {
        const contentType = response.headers.get("content-type") || "";
        const isJson = contentType.includes("application/json");

        if (!isJson && response.redirected) {
            window.location.href = response.url;
            return;
        }

        if (isJson) {
            const data = await response.json();

            if (response.ok && data.success !== false) {
                window.location.href = data.redirectUrl || form.dataset.redirectUrl || DEFAULT_REDIRECT;
                return;
            }

            const { fields, general } = extractErrors(data);
            showFieldErrors(form, fields);

            const hasFieldErrors = Object.keys(fields).length > 0;
            if (general.length > 0) {
                showSummary(form, general);
            } else if (!hasFieldErrors) {
                showSummary(form, [GENERIC_ERROR]);
            }
            return;
        }

        if (response.ok) {
            window.location.href = form.dataset.redirectUrl || DEFAULT_REDIRECT;
            return;
        }

        console.error("Sunucu cevabı:", response.status, await response.text());
        showSummary(form, [GENERIC_ERROR]);
    }

    function extractErrors(data) {
        const fields = {};
        const general = [];

        if (data && data.message) {
            general.push(data.message);
        }

        const errors = data && data.errors;
        if (Array.isArray(errors)) {
            errors.forEach((msg) => general.push(String(msg)));
        } else if (errors && typeof errors === "object") {
            Object.entries(errors).forEach(([key, messages]) => {
                const list = Array.isArray(messages) ? messages : [messages];
                if (key) {
                    fields[key] = list.map(String);
                } else {
                    list.forEach((m) => general.push(String(m)));
                }
            });
        }

        return { fields, general };
    }

    function showFieldErrors(form, fields) {
        const spans = form.querySelectorAll("[data-valmsg-for]");
        Object.entries(fields).forEach(([key, messages]) => {
            const span = Array.from(spans).find(
                (s) => s.dataset.valmsgFor.toLowerCase() === key.toLowerCase()
            );
            if (span) {
                span.textContent = messages.join(" ");
            } else {
                showSummary(form, messages, true);
            }
        });
    }

    function showSummary(form, messages, append = false) {
        const summary = form.querySelector("[data-valsummary]");
        if (!summary) return;

        const list = document.createElement("ul");
        list.className = "mb-0";
        messages.forEach((m) => {
            const li = document.createElement("li");
            li.textContent = m; 
            list.appendChild(li);
        });

        if (!append) summary.innerHTML = "";
        summary.appendChild(list);
    }

    function clearErrors(form) {
        form.querySelectorAll("[data-valmsg-for]").forEach((s) => (s.textContent = ""));
        const summary = form.querySelector("[data-valsummary]");
        if (summary) summary.innerHTML = "";
    }

    function setBusy(button, busy) {
        if (!button) return;
        button.disabled = busy;
    }
})();