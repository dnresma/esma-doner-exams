(function () {
    
    const badge = document.getElementById('cart-count');
    
    function setCount(count) {
        if (!badge) return;
        badge.textContent = count;
        badge.hidden = count === 0;
    }

    function showMessage(text, isError) {
        const box = document.createElement('div');
        box.className = 'alert ' + (isError ? 'alert-danger' : 'alert-success') + ' shadow';
        box.style.cssText = 'position: fixed; top: 70px; right: 50px; z-index: 2000; max-width: 340px;';
        box.textContent = text;
        document.body.appendChild(box);
        setTimeout(() => {
            box.remove();
        }, 3000);
    }

    async function addToCart(button) {
        const formData = new FormData();
        formData.append('productId', button.dataset.productId);
        const quantityInput = button.dataset.quantityInput ? document.querySelector(button.dataset.quantityInput) : null;
        formData.append('quantity', quantityInput ? quantityInput.value : '1');
        button.disabled = true;
        try {
            const response = await fetch('/Cart/Add', {
                method: 'POST',
                body: formData,
                headers: { 'X-Requested-With': 'XMLHttpRequest' }
            })

            if (response.status === 401) {
                window.location.href = '/Account/Login?returnUrl=' + encodeURIComponent(window.location.pathname + window.location.search);
                return;
            }

            const result = await response.json().catch(function () {
                return null;
            });
            if (response.ok && result && result.success) {
                setCount(result.count);
                showMessage(result.message, false);
            } else {
                const messages = result?.errors?.[''] ?? ['Ürün sepete eklenemedi.'];
                showMessage(messages.join(' ', true));
            }
        } catch (error) {
            showMessage('Sunucuya ulaşılamadı!', true);
        } finally {
            button.disabled = false;
        }
    }

    async function loadCount() {
        if (!badge) return;
        try {
            const response = await fetch('/Cart/Count', {
                headers: {
                'X-Requested-Width':'XMLHttpRequest'
                }
            })
            if (response.ok) {
                const data = await response.json();
                setCount(data.count);
            }
        } catch (error) {
            // Sayı gösterilemeyecek olsa bile sayfa çalışmaya devam etsin.
        }
    } 

    document.addEventListener('click', function (event) {
        const button = event.target.closest('[data-add-to-cart]');
        if (!button) return;
        event.preventDefault();
        addToCart(button);
    })

    loadCount();

})();